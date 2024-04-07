
namespace Booking.Application.Features.Car.Strategy
{
     public static class CarSearchStrategy
     {
          public static ICarSearchStrategy  SetStrategy(CarFilterModel filter)
          {
               if (filter.GetCheapest)
               {
                    return new CheapestCarSearchStrategy();
               }
               else 
               {
                    return new MostExpensiveCarStrategy();
               }
          }
     }
}
