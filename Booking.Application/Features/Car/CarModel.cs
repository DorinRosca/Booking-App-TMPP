using Booking.Application.Features.Brand;
using Booking.Application.Features.Car.Decorator;
using Booking.Application.Features.Drive;
using Booking.Application.Features.FuelType;
using Booking.Application.Features.Order;
using Booking.Application.Features.Transmission;
using Booking.Application.Features.Vehicle;
using Microsoft.AspNetCore.Http;

namespace Booking.Application.Features.Car
{
    public class CarModel : ICar
    {
         public int? CarId { get; set; }

         public string? ModelName { get; set; }
         public short? Year { get; set; }
         public decimal? PricePerDay { get; set; }
         public byte[]? Image { get; set; }

         public byte? VehicleId { get; set; }
         public byte? BrandId { get; set; }
         public byte? FuelTypeId { get; set; }
         public byte? TransmissionId { get; set; }
         public byte? DriveId { get; set; }


         public BrandModel? Brand { get; set; }
         public DriveModel? Drive { get; set; }
         public FuelTypeModel? FuelType { get; set; }
         public TransmissionModel? Transmission { get; set; }
         public VehicleModel? Vehicle { get; set; }
          public ICollection<OrderModel>? Order { get; set; }
         public IFormFile? ImageFile { get; set; }

          public virtual string GetDescription()
          {
               return $"Car ID: {CarId}, Model: {ModelName}";
          }

          public virtual decimal? GetDailyPrice()
          {
               return PricePerDay;
          }

     }
}
