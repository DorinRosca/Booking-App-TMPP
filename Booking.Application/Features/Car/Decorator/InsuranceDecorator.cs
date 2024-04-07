
namespace Booking.Application.Features.Car.Decorator
{
     public class InsuranceDecorator : CarDecorator
     {
          private readonly decimal _insurancePrice;

          public InsuranceDecorator(ICar car, decimal insurancePrice) : base(car)
          {
               _insurancePrice = insurancePrice;
          }

          public override string GetDescription()
          {
               return base.GetDescription() + ", with Insurance";
          }

          public override decimal? GetDailyPrice()
          {
               return base.GetDailyPrice() + _insurancePrice;
          }
     }
}
