//=================================================================================================
// Class ListingsController
// Listings controller
// Represents a controller for Listing related operations.
//=================================================================================================
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Realty.Models;
using Realty.Models.ViewModels;
using Realty.Services;
using System.Linq;

namespace Realty.Controllers
{
   /// <summary>
   /// Listings controller
   /// Represents a controller for Listing related operations.
   /// </summary>
   public class ListingsController : ApplicationController
   {
      /// <summary>
      /// GET index action.
      /// Returns the view displaying the list of all listings in the system.
      /// </summary>
      public IActionResult Index()
      {
         if(!IsAuthenticated)
            return RedirectToAction("New", "Sessions");

         ViewBag.CurrentUser = CurrentUser;
         ViewBag.PropertyTypes = GetSelectListItems(PropertyTypes);
         ViewBag.PropertyStyles = GetSelectListItems(PropertyStyles);
         ViewBag.Countries = GetSelectListItems(Countries);
         var listings = new ListingsViewModel { Listings = AppServices.Get<Listing>() };
         return View(listings);
      }




      [HttpPost]
      public IActionResult FilteredIndex(ListingsViewModel viewModel)
      {
         if(!IsAuthenticated)
            return RedirectToAction("New", "Sessions");

         ViewBag.CurrentUser = CurrentUser;
         ViewBag.PropertyTypes = GetSelectListItems(PropertyTypes);
         ViewBag.PropertyStyles = GetSelectListItems(PropertyStyles);
         ViewBag.Countries = GetSelectListItems(Countries);

         IEnumerable<Listing> listings = AppServices.Get<Listing>();
         if(viewModel.PropertyTypeId != null)
            listings = listings.Where(l => l.Property.PropertyType.Id == viewModel.PropertyTypeId);
         if(viewModel.PropertyStyleId != null)
            listings = listings.Where(l => l.Property.PropertyStyle.Id == viewModel.PropertyStyleId);
         if(viewModel.CountryId != null)
         {
            var country = AppServices.Get<Country>(viewModel.CountryId.Value);
            listings = listings.Where(l => l.Property.Address.CountryCode.ToLower() == country.Code.ToLower());
         }
         if(!string.IsNullOrWhiteSpace(viewModel.City))
            listings = listings.Where(l => l.Property.Address.City.ToLower() == viewModel.City.ToLower());
         if(viewModel.MinFloorFootage != null)
            listings = listings.Where(l => l.Property.FloorFootage >= viewModel.MinFloorFootage);
         if(viewModel.MinYearBuilt != null)
            listings = listings.Where(l => l.Property.YearBuilt >= viewModel.MinYearBuilt);
         if(viewModel.MinPrice != null)
            listings = listings.Where(l => l.AskingPrice >= viewModel.MinPrice);
         if(viewModel.MaxPrice != null)
            listings = listings.Where(l => l.AskingPrice <= viewModel.MaxPrice);

         viewModel.Listings = listings;

         return View(nameof(Index), viewModel);
      }


      /// <summary>
      /// GET new action.
      /// Returns HTML form to create the new listing.
      /// </summary>
      public IActionResult New(int propertyId)
      {
         if(!IsAuthenticated)
            return RedirectToAction("New", "Sessions");

         ViewBag.CurrentUser = CurrentUser;
         var property = AppServices.Get<Property>(propertyId);
         var listing = new Listing { Property = property, Realtor = CurrentUser };
         return View(listing);
      }



      /// <summary>
      /// POST create action.
      /// Perform create a new listing operation.
      /// </summary>
      [HttpPost]
      public IActionResult Create(Listing listing, int propertyId)
      {
         if(!IsAuthenticated)
            return RedirectToAction("New", "Sessions");

         if(ModelState.IsValid)
         {
            var property = AppServices.Get<Property>(propertyId);
            listing.Property = property;
            listing.Realtor = CurrentUser;
            AppServices.Save(listing);
            return RedirectToAction(nameof(Index));
         }
         return View(nameof(New));
      }
   }
}
