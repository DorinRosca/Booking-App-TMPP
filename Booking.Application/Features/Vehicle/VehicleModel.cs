using Booking.Application.Features.Common;

namespace Booking.Application.Features.Vehicle
{
    public class VehicleModel : ICarSetting
    {
        public string SettingId { get; set; }

        public byte? VehicleId { get; set; }
        public string? VehicleName { get; set; }
        public byte? SeatNumber { get; set; }

          public VehicleModel DeepCopy()
          {
               return new VehicleModel
               {
                    SettingId= SettingId,
                    VehicleId = VehicleId,
                    VehicleName = VehicleName,
                    SeatNumber = SeatNumber,
               };
          }
     }
}
