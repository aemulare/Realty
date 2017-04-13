//=================================================================================================
// Class UsersController
// Users controller
// Represents a controller for User related operations.
//=================================================================================================
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Realty.Models;
using Realty.Services;

namespace Realty.Controllers
{
   /// <summary>
   /// Users controller
   /// Represents a controller for User related operations.
   /// </summary>
   public class UsersController : ApplicationController
   {
      /// <summary>
      /// GET index action.
      /// Returns the view displaying the list of all users in the system.
      /// </summary>
      public IActionResult Index()
      {
         if(!IsAuthenticated)
            return RedirectToAction("New", "Sessions");

         var users = AppServices.Get<User>();
         ViewBag.CurrentUser = CurrentUser;
         if(CurrentUser.IsAdmin || CurrentUser.IsRealtor)
         {
            ViewBag.Clients = users.Where(u => !u.IsRealtor && !u.IsAdmin).OrderBy(u => u.Person.LastName);
            ViewBag.Realtors = users.Where(u => u.IsRealtor).OrderBy(u => u.Person.LastName);
            ViewBag.Admins = users.Where(u => u.IsAdmin).OrderBy(u => u.Person.LastName);
         }
         else
         {
            ViewBag.Clients = users.Where(u => u.Id == CurrentUser.Id);
            ViewBag.Realtors = users.Where(u => u.IsRealtor).OrderBy(u => u.Person.LastName);
            ViewBag.Admins = new User[0];
         }

         return View(users);
      }



      /// <summary>
      /// GET new action.
      /// Returns HTML form to create the new user.
      /// </summary>
      public IActionResult New()
      {
         if(!IsAuthenticated)
            return RedirectToAction("New", "Sessions");

         ViewBag.CurrentUser = CurrentUser;
         return View(new User());
      }



      /// <summary>
      /// POST create action.
      /// Perform create a new user operation.
      /// </summary>
      /// <param name="user">User instance.</param>
      [HttpPost]
      public IActionResult Create(User user)
      {
         if(!IsAuthenticated)
            return RedirectToAction("New", "Sessions");

         if(ModelState.IsValid)
         {
            AppServices.Save(user);
            return RedirectToAction(nameof(Index));
         }
         return View(nameof(New));
      }



      /// <summary>
      /// GET show action.
      /// Returns HTML form to view a user properties.
      /// </summary>
      /// <param name="userId">User unique id.</param>
      public IActionResult Show(int userId)
      {
         if(!IsAuthenticated)
            return RedirectToAction("New", "Sessions");

         ViewBag.CurrentUser = CurrentUser;
         var user = AppServices.Get<User>(userId);
         return View(user);
      }



      /// <summary>
      /// GET edit action.
      /// Returns HTML form to edit a user properties.
      /// </summary>
      /// <param name="userId">User unique id.</param>
      public IActionResult Edit(int userId)
      {
         if(!IsAuthenticated)
            return RedirectToAction("New", "Sessions");

         ViewBag.CurrentUser = CurrentUser;
         var user = AppServices.Get<User>(userId);
         return View(user);
      }



      /// <summary>
      /// POST update action.
      /// </summary>
      /// <param name="userId">User id.</param>
      /// <param name="user">User instance.</param>
      [HttpPost]
      public IActionResult Update(int userId, User user)
      {
         if(!IsAuthenticated)
            return RedirectToAction("New", "Sessions");

         if(ModelState.IsValid)
         {
            var existingUser = AppServices.Get<User>(userId);
            existingUser.UpdateProperties(user);
            AppServices.Save(existingUser);
            return RedirectToAction(nameof(Index));
         }
         return View(nameof(Edit));
      }



      /// <summary>
      /// POST destroy action.
      /// </summary>
      /// <param name="userId">User unique id.</param>
      [HttpPost]
      public IActionResult Destroy(int userId)
      {
         if(!IsAuthenticated)
            return RedirectToAction("New", "Sessions");

         var user = AppServices.Get<User>(userId);
         if(user != null)
            AppServices.Delete(user);
         return RedirectToAction(nameof(Index));
      }
   }
}
