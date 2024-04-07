using Booking.Application.Features.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Features.Vehicle
{
     public class VehicleFactory : ICarSettingFactory<VehicleModel>
     {
          public VehicleModel Create()
          {
               return new VehicleModel();
          }
     }
}
