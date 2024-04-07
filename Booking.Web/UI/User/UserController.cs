﻿using Booking.Application.Features.User;
using Booking.Application.Features.User.Commands.DeleteRole;
using Booking.Application.Features.User.Commands.Logout;
using Booking.Application.Features.User.Commands.Register;
using Booking.Application.Features.User.Commands.SetRole;
using Booking.Application.Features.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Booking.Web.UI.User
{
     public class UserController : Controller
     {
          private readonly IMediator _mediator;
          private readonly ILoginProxy _loginProxy;

          public UserController(IMediator mediator, ILoginProxy loginProxy)
          {
               _mediator = mediator;
               _loginProxy = loginProxy;
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
               var registrationResponse = await _mediator.Send(registerCommand);

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
               var loginResponse = new LoginResponse();

               // Use the proxy to perform login
               var result = await _loginProxy.LoginAsync(loginModel.Email, loginModel.Password, loginModel.RememberMe);

               if (result.Succeeded)
               {
                    // Login successful, redirect to home page
                    return RedirectToAction("Index", "Home");
               }
               else
               {
                    // Login failed, return view with appropriate message
                    loginResponse.Success = false;
                    loginResponse.BaseMessage = "Wrong username or password";
                    return View(loginResponse);
               }
          }

          public async Task<IActionResult> Logout()
          {
               var logoutCommand = new LogoutCommand();
               var logoutResponse = await _mediator.Send(logoutCommand);

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
