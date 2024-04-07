using Booking.Application.Features.User.Commands.Logout;
using Booking.Application.Features.User.Commands.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Features.User.Facade
{
    public interface IAuthenticationFacade
    {
        Task<LoginResponse> Login(LoginModel loginModel);
        Task<RegisterResponse> Register(RegisterModel registerModel);

        Task<LogoutResponse> Logout();
    }
}
