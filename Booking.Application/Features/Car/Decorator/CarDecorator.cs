using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Features.Car.Decorator
{
     public abstract class CarDecorator : ICar
     {
          protected readonly ICar _car;

          public CarDecorator(ICar car)
          {
               _car = car;
          }

          public virtual string GetDescription()
          {
               return _car.GetDescription();
          }

          public virtual decimal? GetDailyPrice()
          {
               return _car.GetDailyPrice();
          }

     }
}
