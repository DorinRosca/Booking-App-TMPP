using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Features.Car.Strategy
{
     public interface ICarSearchStrategy
     {
          CarFilterModel SearchCars(CarFilterModel filter);
     }
}
