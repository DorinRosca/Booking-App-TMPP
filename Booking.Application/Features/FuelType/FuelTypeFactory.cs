using Booking.Application.Features.Common;

namespace Booking.Application.Features.FuelType
{
     public class FuelTypeFactory : ICarSettingFactory<FuelTypeModel>
     {
          public FuelTypeModel Create()
          {
               return new FuelTypeModel();
          }
     }
}
