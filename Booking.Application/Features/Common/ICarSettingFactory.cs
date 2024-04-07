
namespace Booking.Application.Features.Common
{
     public interface ICarSettingFactory<TEntity> where TEntity : class
     {
          TEntity Create();
     }
}
