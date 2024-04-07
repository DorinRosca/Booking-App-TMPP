using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Features.Car.Strategy
{
     public class CheapestCarSearchStrategy : ICarSearchStrategy
     {
          public CarFilterModel SearchCars(CarFilterModel filter)
          {
               var cars = filter.Cars.OrderBy(car => car.PricePerDay).ToList();
               filter.Cars = cars;
               return filter;
          }
     }
}
