using Booking.Application.Features.Common;

namespace Booking.Application.Features.Transmission
{
     public class TransmissionFactory : ICarSettingFactory<TransmissionModel>
     {
          public TransmissionModel Create()
          {
               return new TransmissionModel();
          }
     }
}
