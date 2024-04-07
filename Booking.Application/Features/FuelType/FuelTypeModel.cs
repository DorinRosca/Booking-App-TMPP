using Booking.Application.Features.Common;

namespace Booking.Application.Features.FuelType
{
     public class FuelTypeModel : ICarSetting
     {
          public string SettingId { get; set; }

          public byte? FuelTypeId { get; set; }

          public string? FuelTypeName { get; set; }

          public FuelTypeModel DeepCopy()
          {
               return new FuelTypeModel { SettingId = SettingId, FuelTypeId = FuelTypeId , FuelTypeName= FuelTypeName};
          }
     }
}
