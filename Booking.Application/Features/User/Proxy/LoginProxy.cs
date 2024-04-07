using Booking.Application.Contracts.Database.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Features.User.Proxy
{
    public class LoginProxy : ILoginProxy
    {
        private readonly ILogin _realLogin;

        public LoginProxy(ILogin realLogin)
        {
            _realLogin = realLogin;
        }

        public async Task<SignInResult> LoginAsync(string email, string password, bool rememberMe)
        {
            return await _realLogin.ApplyAsync(email, password, rememberMe);
        }

    }
}
