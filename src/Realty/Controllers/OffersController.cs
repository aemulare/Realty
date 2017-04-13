//=================================================================================================
// Class OffersController
// Offers controller
// Represents a controller for Offer related operations.
//=================================================================================================

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Realty.Models;
using Realty.Services;

namespace Realty.Controllers
{
   /// <summary>
   /// Offers controller
   /// Represents a controller for Offer related operations.
   /// </summary>
   public class OffersController : ApplicationController
   {
      /// <summary>
      /// GET index action.
      /// Returns the view displaying the list of all offers in the system.
      /// </summary>
      public IActionResult Index()
      {
         if(!IsAuthenticated)
            return RedirectToAction("New", "Sessions");

         ViewBag.CurrentUser = CurrentUser;
         var offers = AppServices.Get<Offer>();

         IEnumerable<Offer> allOffers;

         if(CurrentUser.IsAdmin)
            allOffers = offers;
         else if(CurrentUser.IsRealtor)
            allOffers = offers.Where(of => of.Listing.Realtor == CurrentUser
            || of.Listing.Property.Owner == CurrentUser || of.Buyer == CurrentUser);
         else
            allOffers = offers.Where(of => of.Listing.Property.Owner == CurrentUser || of.Buyer == CurrentUser);

         ViewBag.MyOffers = offers.Where(of => of.Buyer == CurrentUser);
         ViewBag.OffersToMe = offers.Where(of => of.Listing.Property.Owner == CurrentUser);
         return View(allOffers);
      }



      /// <summary>
      /// GET new action.
      /// Displays a listing details page allowing to create the new offer.
      /// </summary>
      public IActionResult New(int listingId)
      {
         if(!IsAuthenticated)
            return RedirectToAction("New", "Sessions");

         ViewBag.CurrentUser = CurrentUser;
         var listing = AppServices.Get<Listing>(listingId);
         var offer = new Offer { Listing = listing, Buyer = CurrentUser };
         return View(offer);
      }



      /// <summary>
      /// POST create action.
      /// Perform create a new offer operation.
      /// </summary>
      [HttpPost]
      public IActionResult Create(Offer offer, int listingId)
      {
         if(!IsAuthenticated)
            return RedirectToAction("New", "Sessions");

         if(ModelState.IsValid)
         {
            var listing = AppServices.Get<Listing>(listingId);
            offer.Listing = listing;
            offer.Buyer = CurrentUser;
            AppServices.Save(offer);
            return RedirectToAction(nameof(Index));
         }
         return View(nameof(New));
      }



      [HttpPost]
      public IActionResult CreateOffer(int listingId, decimal? offerPrice)
      {
         if(!IsAuthenticated)
            return RedirectToAction("New", "Sessions");

         if(ModelState.IsValid)
         {
            var listing = AppServices.Get<Listing>(listingId);
            var offer = new Offer { Listing = listing, Buyer = CurrentUser, OfferPrice = offerPrice };
            AppServices.Save(offer);
            return RedirectToAction(nameof(Index));
         }
         return View("Index", "Listings");
      }



      /// <summary>
      /// GET accept action.
      /// Accept the specified offer.
      /// </summary>
      public IActionResult Accept(int offerId)
      {
         if(!IsAuthenticated)
            return RedirectToAction("New", "Sessions");

         var offer = AppServices.Get<Offer>(offerId);
         offer.Accept();
         AppServices.Save(offer);
         AppServices.Save(offer.Listing);

         return RedirectToAction(nameof(Index));
      }



      public IActionResult Cancel(int offerId)
      {
         if(!IsAuthenticated)
            return RedirectToAction("New", "Sessions");

         var offer = AppServices.Get<Offer>(offerId);
         offer.Cancel();
         AppServices.Save(offer);
         return RedirectToAction(nameof(Index));
      }
   }
}
