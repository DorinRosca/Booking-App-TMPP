using Booking.Application.Features.Common;

namespace Booking.Application.Features.Drive
{
    public class DriveModel : ICarSetting
    {
        public string SettingId { get; set; }
        public byte? DriveId { get; set; }
        public string? DriveName { get; set; }

          public DriveModel DeepCopy()
          {
               return new DriveModel { SettingId = SettingId, DriveId = DriveId, DriveName = DriveName };
          }
     }
}
