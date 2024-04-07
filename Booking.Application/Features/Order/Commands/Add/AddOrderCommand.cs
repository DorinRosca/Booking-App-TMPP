using AutoMapper;
using Booking.Application.Contracts.Database;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Booking.Application.Contracts.Database.Car;
using Booking.Application.Contracts.Database.Status;
using Booking.Application.Features.Order.Builder;
using Booking.Domain.Entities;
using FluentValidation;

namespace Booking.Application.Features.Order.Commands.Add;

public record AddOrderCommand(OrderModel Model) : IRequest<AddOrderResponse>
{
     public string? UserId = Model.UserId;
     public int? CarId = Model.CarId;
     public byte? StatusId =Model.StatusId;
     public DateTime RentalStartDate = Model.RentalStartDate;
     public DateTime RentalEndDate = Model.RentalEndDate;
     public double? TotalAmount = Model.TotalAmount;

}

public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, AddOrderResponse>
{
     private readonly IAddEntity<Domain.Entities.Order> _addEntity;
     private readonly IMapper _mapper;
     private readonly ICheckCarAvailability _checkAvailability;
     private readonly IMediator _mediator; // Use Mediator for car details retrieval
     private readonly IGetCarPrice _getCarPrice;
     private readonly IGetStatusIdByName _getStatus;
     private readonly IHttpContextAccessor _httpContextAccessor;


     public AddOrderCommandHandler(IAddEntity<Domain.Entities.Order> addEntity, IMapper mapper, ICheckCarAvailability checkAvailability, IMediator mediator, IGetCarPrice getCarPrice, IGetStatusIdByName getStatus, IHttpContextAccessor httpContextAccessor)
     {
          _addEntity = addEntity;
          _mapper = mapper;
          _checkAvailability = checkAvailability;
          _mediator = mediator;
          _getCarPrice = getCarPrice;
          _getStatus=getStatus;
          _httpContextAccessor=httpContextAccessor;
     }

     public async Task<AddOrderResponse> Handle(AddOrderCommand request, CancellationToken cancellationToken)
     {
          var validator = new AddOrderValidator();

          var response = new AddOrderResponse
          {
               ValidationErrors = new List<string>()
          };

          var builder = new OrderBuilder(_checkAvailability, _mediator, _getCarPrice, _httpContextAccessor);

         
          try
          {
               builder.WithUserId();
               builder.WithCarId(request.CarId);
               await builder.WithRentalDates(request.RentalStartDate, request.RentalEndDate);
               await builder.WithTotalAmount();
               builder.WithStatusId(await _getStatus.GetAsync("Processing"));
               var order = builder.Build();

               var validationResult = await validator.ValidateAsync(order, cancellationToken);

               if (!validationResult.IsValid)
               {
                    foreach (var e in validationResult.Errors)
                    {
                         response.ValidationErrors.Add(e.ErrorMessage);
                    }
                    return InsertFailed(response, "There are Some validation Errors");
               }
               var entity = _mapper.Map<Domain.Entities.Order>(order);
               var insertedResponse = await _addEntity.InsertAsync(entity);
               if (!insertedResponse)
               {
                    return InsertFailed(response, "Insert Order database error");
               }

               response.Success = true;
               response.AddedIsSuccessful = true;
               response.Order = _mapper.Map<OrderModel>(entity);
               return response;
          }
          catch (ArgumentException ex)
          {
               response.ValidationErrors.Add(ex.Message);
               return InsertFailed(response, "Error");
          }
     }

     private static AddOrderResponse InsertFailed(AddOrderResponse response, string message)
     {
          response.Success = false;
          response.AddedIsSuccessful = false;
          response.BaseMessage = message;
          return response;
     }
}
