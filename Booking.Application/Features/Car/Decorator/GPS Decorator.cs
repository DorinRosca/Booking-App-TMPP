using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Features.Car.Decorator
{
     public class GPSDecorator : CarDecorator
     {
          private readonly decimal _gpsPrice;

          public GPSDecorator(ICar car, decimal gpsPrice) : base(car)
          {
               _gpsPrice = gpsPrice;
          }

          public override string GetDescription()
          {
               return base.GetDescription() + ", with GPS";
          }

          public override decimal? GetDailyPrice()
          {
               return base.GetDailyPrice() + _gpsPrice;
          }
     }
}
