using Booking.Application.Contracts.Database.User;
using Booking.Application.Features.User.Commands.Logout;
using Booking.Application.Features.User.Commands.Register;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Features.User.Facade
{
    public class AuthenticationFacade : IAuthenticationFacade
    {
        private readonly ILogin _login;
        private readonly IMediator _mediator;
        public AuthenticationFacade(ILogin login, IMediator mediator)
        {
            _login = login;
            _mediator = mediator;
        }
        public async Task<LoginResponse> Login(LoginModel loginModel)
        {
            var email = loginModel.Email;
            var password = loginModel.Password;
            var rememberMe = loginModel.RememberMe;
            var result = await _login.ApplyAsync(email, password, rememberMe);
            var loginResponse = new LoginResponse();
            if (result.Succeeded)
            {
                loginResponse.Success = true;
                loginResponse.LoginIsSuccessful = true;
                loginResponse.BaseMessage = "User Authenticated successfully";
            }
            else
            {
                loginResponse.Success = false;
                loginResponse.LoginIsSuccessful = false;
                loginResponse.BaseMessage = "Wrong username or password";
            }
            return loginResponse;

        }

        public async Task<RegisterResponse> Register(RegisterModel registerModel)
        {
            var registerCommand = new RegisterCommand(registerModel);
            return await _mediator.Send(registerCommand);
        }

        public async Task<LogoutResponse> Logout()
        {
            var logoutCommand = new LogoutCommand();
            var result = await _mediator.Send(logoutCommand);
            return result;

        }
    }
}
