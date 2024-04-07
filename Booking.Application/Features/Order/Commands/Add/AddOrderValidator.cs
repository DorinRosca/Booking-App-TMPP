﻿using FluentValidation;

namespace Booking.Application.Features.Order.Commands.Add
{
    internal class AddOrderValidator : AbstractValidator<OrderModel>
    {
        public AddOrderValidator()
        {
             RuleFor(x => x.UserId)
                  .NotNull().WithMessage("The User Id is required")
                  .NotEmpty().WithMessage("The user id cannot be empty");

             RuleFor(x => x.CarId)
                  .NotNull().WithMessage("The Car Id is required")
                  .NotEmpty().WithMessage("The Car id cannot be empty");

             RuleFor(x => x.StatusId)
                  .NotNull().WithMessage("The status Id is required")
                  .NotEmpty().WithMessage("The status id cannot be empty");

             RuleFor(x => x.TotalAmount)
                  .NotNull().WithMessage("The total amount is required")
                  .NotEmpty().WithMessage("The total amount cannot be empty")
                  .GreaterThan(0).WithMessage("The total amount must be greater than 0");

             RuleFor(x => x.RentalStartDate)
                  .NotEmpty().WithMessage("The rental start date is required")
                  .NotNull().WithMessage("The rental start date is required")
                  .NotEmpty().WithMessage("The rental start date cannot be empty")
                  .Must(date => date > DateTime.Today).WithMessage("The rental start date cannot be today or earlier");

             RuleFor(x => x.RentalEndDate)
                  .NotEmpty().WithMessage("The rental end date is required")
                  .NotNull().WithMessage("The rental end date is required")
                  .NotEmpty().WithMessage("The rental end date cannot be empty")
                  .Must((order, endDate) => endDate > order.RentalStartDate).WithMessage("The rental end date cannot be earlier than the start date");
          }
     }
}
