using Booking.Application.Features.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Features.Brand
{
     public class BrandFactory : ICarSettingFactory<BrandModel>
     {
          public BrandModel Create()
          {
                    return new BrandModel();
          }
     }
}
