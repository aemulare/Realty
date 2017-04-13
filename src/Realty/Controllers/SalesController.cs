//=================================================================================================
// Class SalesController
// Sales controller
// Represents a controller for Sale related operations.
//=================================================================================================

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Realty.Models;
using Realty.Services;

namespace Realty.Controllers
{
   /// <summary>
   /// Sales controller
   /// Represents a controller for Sale related operations.
   /// </summary>
   public class SalesController : ApplicationController
   {
      /// <summary>
      /// GET index action.
      /// Returns the view displaying the list of all sales in the system.
      /// </summary>
      public IActionResult Index()
      {
         if(!IsAuthenticated)
            return RedirectToAction("New", "Sessions");

         ViewBag.CurrentUser = CurrentUser;
         var sales = AppServices.Get<Sale>();
         ViewBag.MySales = sales.Where(s => s.Offer.Listing.Property.Owner == CurrentUser ||
            s.Offer.Buyer == CurrentUser);
         ViewBag.RealtorSales = CurrentUser.IsRealtor ?
            sales.Where(s => s.Offer.Listing.Realtor == CurrentUser) : new Sale[0];
         return View(sales);
      }



      /// <summary>
      /// GET new action.
      /// Returns HTML form to create the new sale.
      /// </summary>
      public IActionResult New(int offerId)
      {
         if(!IsAuthenticated)
            return RedirectToAction("New", "Sessions");

         ViewBag.CurrentUser = CurrentUser;
         var offer = AppServices.Get<Offer>(offerId);
         var sale = new Sale { Offer = offer };
         return View(sale);
      }



      /// <summary>
      /// POST create action.
      /// Perform create a new sale operation.
      /// </summary>
      [HttpPost]
      public IActionResult Create(Sale sale, int offerId)
      {
         if(!IsAuthenticated)
            return RedirectToAction("New", "Sessions");

         if(ModelState.IsValid)
         {
            var offer = AppServices.Get<Offer>(offerId);
            sale.Offer = offer;
            AppServices.Save(sale);
            return RedirectToAction(nameof(Index));
         }
         return View(nameof(New));
      }



      /// <summary>
      /// GET show action.
      /// Returns HTML form to view sale details.
      /// </summary>
      public IActionResult Show(int saleId)
      {
         if(!IsAuthenticated)
            return RedirectToAction("New", "Sessions");

         ViewBag.CurrentUser = CurrentUser;
         var sale = AppServices.Get<Sale>(saleId);
         return View(sale);
      }
   }
}
