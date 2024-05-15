using Booking.Application.Contracts.Database.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Database.User
{
     public class LoginProxy : Application.Contracts.Database.User.ILogin
     {
          private readonly Login _realLogin;

          public LoginProxy(Login realLogin)
          {
               _realLogin = realLogin;
          }

          public async Task<SignInResult> ApplyAsync(string email, string password, bool rememberMe)
          {
               return await _realLogin.ApplyAsync(email, password, rememberMe);
          }

     }
}
