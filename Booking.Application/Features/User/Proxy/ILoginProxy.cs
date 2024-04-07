using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Features.User.Proxy
{
    public interface ILoginProxy
    {
        Task<SignInResult> LoginAsync(string email, string password, bool rememberMe);
    }
}
