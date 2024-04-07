using Booking.Application.Features.Common;

namespace Booking.Application.Features.Drive
{
     public class DriveFactory : ICarSettingFactory<DriveModel>
     {
          public DriveModel Create()
          {
               return new DriveModel();
          }
     }
}
