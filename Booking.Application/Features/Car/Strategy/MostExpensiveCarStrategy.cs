
namespace Booking.Application.Features.Car.Strategy
{
     internal class MostExpensiveCarStrategy : ICarSearchStrategy
     {
          public CarFilterModel SearchCars(CarFilterModel filter)
          {
               var cars = filter.Cars.OrderByDescending(car => car.PricePerDay).ToList();
               filter.Cars = cars;
               return filter;
          }
     }
}
