//=================================================================================================
// Class SessionsController
// Sessions controller
// Represents a controller performing sign in and sign out operations.
//=================================================================================================
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Realty.Models;
using Realty.Services;

namespace Realty.Controllers
{
   /// <summary>
   /// Sessions controller
   /// Represents a controller performing sign in and sign out operations.
   /// </summary>
   public class SessionsController : ApplicationController
   {
      /// <summary>
      /// GET new action.
      /// Returns a user sign in page.
      /// </summary>
      public IActionResult New()
      {
         return View(new User());
      }



      /// <summary>
      /// POST create action.
      /// Performs user sign in operation and stored user ID in the session.
      /// </summary>
      [HttpPost]
      public IActionResult Create(User user)
      {
         if(user?.Login != null && user.Password != null)
         {
            var foundUser = AppServices.Get<User>().FirstOrDefault(u => u.Login.ToLower() == user.Login.ToLower());
            if(foundUser != null && foundUser.Password == user.Password)
            {
               HttpContext.Session.SetInt32("CurrentUserId", foundUser.Id.Value);
               return RedirectToAction("Index", "Users");
            }
         }

         return RedirectToAction(nameof(New));
      }



      /// <summary>
      /// POST destroy action.
      /// Performs user sign out operation and deletes user ID from the session.
      /// </summary>
      public IActionResult Destroy()
      {
         HttpContext.Session.Clear();
         return RedirectToAction("Index", "Home");
      }
   }
}
