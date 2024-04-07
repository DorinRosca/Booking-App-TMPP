using Booking.Application.Features.Common;

namespace Booking.Application.Features.Brand
{
    public class BrandModel :ICarSetting
    {
        public string SettingId { get; set; }
        public byte? BrandId { get; set; }
        public string? BrandName { get; set; }

          public BrandModel DeepCopy()
          {
               return new BrandModel { SettingId = SettingId, BrandId = BrandId, BrandName = BrandName};
          }
     }
}
