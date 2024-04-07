using Booking.Application.Features.Common;

namespace Booking.Application.Features.Transmission
{
     public class TransmissionModel : ICarSetting
     {
          public string SettingId { get; set; }
          public byte? TransmissionId { get; set; }
          public string? TransmissionName { get; set; }

          public TransmissionModel DeepCopy()
          {
               return new TransmissionModel { SettingId = SettingId, TransmissionId = TransmissionId, TransmissionName = TransmissionName };
          }
     }
}
