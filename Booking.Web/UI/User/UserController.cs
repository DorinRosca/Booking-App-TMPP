using Booking.Application.Features.User;
using Booking.Application.Features.User.Commands.DeleteRole;
using Booking.Application.Features.User.Commands.Logout;
using Booking.Application.Features.User.Commands.Register;
using Booking.Application.Features.User.Commands.SetRole;
using Booking.Application.Features.User.Facade;
using Booking.Application.Features.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Booking.Web.UI.User
{
    public class UserController : Controller
     {
          private readonly IMediator _mediator;
          private readonly IAuthenticationFacade _authenticationFacade;

          public UserController(IMediator mediator, IAuthenticationFacade authenticationFacade)
          {
               _mediator = mediator;
               _authenticationFacade= authenticationFacade;
          }

          public IActionResult SignUp()
          {
               return View();
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> SignUp(RegisterModel registrationModel)
          {
               var registerCommand = new RegisterCommand(registrationModel);
               var registrationResponse = await _authenticationFacade.Register(registrationModel);

               if (registrationResponse.LoginIsSuccessful)
               {
                    return RedirectToAction("Index", "Home");
               }

               return View(registrationResponse);
          }

          [HttpGet]
          public IActionResult Login()
          {
               return View();
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> Login(LoginModel loginModel)
          {

               var result = await _authenticationFacade.Login(loginModel);

               if (result.Success)
               {
                    return RedirectToAction("Index", "Home");
               }
               else
               {
                    return View(result);
               }
          }

          public async Task<IActionResult> Logout()
          {
               var logoutResponse = await _authenticationFacade.Logout();
               if (logoutResponse.LogoutIsSuccessful)
               {
                    return RedirectToAction("Login", "User");
               }

               return RedirectToAction("Error", "Home");
          }

          [Authorize(Roles = "Admin")]
          [HttpGet]
          public async Task<ActionResult> Index()
          {
               var getUserRoleQuery = new GetUserRoleQuery();
               var users = await _mediator.Send(getUserRoleQuery);

               return View(users);
          }

          [HttpGet]
          public IActionResult AddRole()
          {
               return View();
          }

          [Authorize(Roles = "Admin")]
          [HttpPost]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> AddRole(UserRoleModel userRoleModel)
          {
               var setUserRoleCommand = new SetUserRoleCommand(userRoleModel);
               var roleResponse = await _mediator.Send(setUserRoleCommand);

               return View(roleResponse);
          }

          [Authorize(Roles = "Admin")]
          [HttpPost]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> DeleteRole(UserRoleModel userRoleModel)
          {
               var deleteRoleCommand = new DeleteUserRoleCommand(userRoleModel);
               var deleteRoleResponse = await _mediator.Send(deleteRoleCommand);

               return View(deleteRoleResponse);
          }
     }
}
