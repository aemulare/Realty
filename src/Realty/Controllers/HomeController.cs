using Microsoft.AspNetCore.Mvc;

namespace Realty.Controllers
{
   public class HomeController : ApplicationController
   {
      public IActionResult Index()
      {
         return View();
      }
   }
}
