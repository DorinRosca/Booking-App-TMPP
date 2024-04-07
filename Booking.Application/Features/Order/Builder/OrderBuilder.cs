using Booking.Application.Contracts.Database.Car;
using Booking.Application.Features.Car.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Features.Order.Builder
{
     public class OrderBuilder
     {
          private readonly OrderModel _orderModel = new OrderModel();
          private readonly ICheckCarAvailability _checkCar; // Dependency Injection for car related operations
          private readonly IMediator _mediator;
          private readonly IGetCarPrice _getCarPrice;
          private readonly IHttpContextAccessor _httpContextAccessor;
          public OrderBuilder(ICheckCarAvailability checkCarAvailability, IMediator mediator, IGetCarPrice getCarPrice, IHttpContextAccessor httpContextAccessor) // Inject car service dependency in constructor
          {
               _checkCar = checkCarAvailability;
               _mediator = mediator;
               _getCarPrice=getCarPrice;
               _httpContextAccessor= httpContextAccessor;
          }

          public OrderBuilder WithUserId()
          {
               var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
               _orderModel.UserId = userId;
               return this;
          }

          public OrderBuilder WithCarId(int? carId)
          {
               _orderModel.CarId = carId;
               return this;
          }

          public async Task<OrderBuilder> WithRentalDates(DateTime rentalStart, DateTime rentalEnd)
          {
               if (!await IsCarAvailable(rentalStart, rentalEnd))
               {
                    throw new ArgumentException("Selected car is not available for the chosen dates.");
               }

               _orderModel.RentalStartDate = rentalStart;
               _orderModel.RentalEndDate = rentalEnd;
               return this;
          }

          private async Task<bool> IsCarAvailable(DateTime rentalStart, DateTime rentalEnd)
          {
               return await _checkCar.CheckAsync(_orderModel.CarId, rentalStart, rentalEnd);
          }

          public OrderBuilder WithStatusId(byte? statusId)
          {
               _orderModel.StatusId = statusId;
               return this;
          }

          public async Task<OrderBuilder> WithTotalAmount() // Removed days parameter
          {
               var getCar = new GetCarQuery(_orderModel.CarId);

               var car = await _mediator.Send(getCar); // Fetch car details for calculation
               if (car == null)
               {
                    throw new ArgumentException("Car not found for ID: " + _orderModel.CarId);
               }

               int days = (int)(_orderModel.RentalEndDate.Date - _orderModel.RentalStartDate.Date).TotalDays;
               _orderModel.TotalAmount = await _getCarPrice.GetAsync(car.CarId, days); // Delegate calculation to car service
               return this;
          }

          public OrderModel Build()
          {
               return _orderModel;
          }


     }
}
