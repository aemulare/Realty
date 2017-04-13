//=================================================================================================
// Class PropertiesController
// Properties controller
// Represents a controller for Property related operations.
//=================================================================================================
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Realty.Models;
using Realty.Models.ViewModels;
using Realty.Services;

namespace Realty.Controllers
{
   /// <summary>
   /// Properties controller
   /// Represents a controller for Property related operations.
   /// </summary>
   public class PropertiesController : ApplicationController
   {
      /// <summary>
      /// GET index action.
      /// Returns the view displaying the list of all properties in the system.
      /// </summary>
      public IActionResult Index()
      {
         if(!IsAuthenticated)
            return RedirectToAction("New", "Sessions");

         ViewBag.CurrentUser = CurrentUser;
         var properties = AppServices.Get<Property>();
         ViewBag.PropertyTypes = GetSelectListItems(PropertyTypes);
         ViewBag.PropertyStyles = GetSelectListItems(PropertyStyles);
         ViewBag.Countries = GetSelectListItems(Countries);

         var viewModel = new PropertiesViewModel
         {
            Properties = properties,
            MyProperties = properties.Where(p => p.Owner == CurrentUser),
         };

         return View(viewModel);
      }



      [HttpPost]
      public IActionResult FilteredIndex(PropertiesViewModel viewModel)
      {
         if(!IsAuthenticated)
            return RedirectToAction("New", "Sessions");

         ViewBag.CurrentUser = CurrentUser;
         ViewBag.PropertyTypes = GetSelectListItems(PropertyTypes);
         ViewBag.PropertyStyles = GetSelectListItems(PropertyStyles);
         ViewBag.Countries = GetSelectListItems(Countries);

         IEnumerable<Property> properties = AppServices.Get<Property>();
         if(viewModel.PropertyTypeId != null)
            properties = properties.Where(p => p.PropertyType.Id == viewModel.PropertyTypeId);
         if(viewModel.PropertyStyleId != null)
            properties = properties.Where(p => p.PropertyStyle.Id == viewModel.PropertyStyleId);
         if(viewModel.CountryId != null)
         {
            var country = AppServices.Get<Country>(viewModel.CountryId.Value);
            properties = properties.Where(p => p.Address.CountryCode.ToLower() == country.Code.ToLower());
         }
         if(!string.IsNullOrWhiteSpace(viewModel.City))
            properties = properties.Where(p => p.Address.City.ToLower() == viewModel.City.ToLower());
         if(viewModel.MinFloorFootage != null)
            properties = properties.Where(p => p.FloorFootage >= viewModel.MinFloorFootage);
         if(viewModel.MinYearBuilt != null)
            properties = properties.Where(p => p.YearBuilt >= viewModel.MinYearBuilt);

         viewModel.Properties = properties;
         viewModel.MyProperties = properties.Where(p => p.Owner == CurrentUser);

         return View(nameof(Index), viewModel);
      }



      /// <summary>
      /// GET new action.
      /// Returns HTML form to create a new property.
      /// </summary>
      public IActionResult New(int userId)
      {
         if(!IsAuthenticated)
            return RedirectToAction("New", "Sessions");

         ViewBag.CurrentUser = CurrentUser;
         var user = AppServices.Get<User>(userId);
         var address = new Address();
         address.UpdateProperties(user.Person.Address);
         var property = new Property { Owner = user, Address = address };

         ViewBag.PropertyTypes = GetSelectListItems(PropertyTypes);
         ViewBag.PropertyStyles = GetSelectListItems(PropertyStyles);
         ViewBag.BasementTypes = GetSelectListItems(BasementTypes);
         ViewBag.RoofTypes = GetSelectListItems(RoofTypes);
         ViewBag.ParkingTypes = GetSelectListItems(ParkingTypes);
         ViewBag.HeatingTypes = GetSelectListItems(HeatingTypes);
         ViewBag.AirConditioningTypes = GetSelectListItems(AirConditioningTypes);
         return View(property);
      }



      /// <summary>
      /// POST create action.
      /// Perform create a new property operation.
      /// </summary>
      [HttpPost]
      public IActionResult Create(Property property, int userId)
      {
         if(!IsAuthenticated)
            return RedirectToAction("New", "Sessions");

         if(ModelState.IsValid)
         {
            var user = AppServices.Get<User>(userId);
            property.Owner = user;
            AppServices.Save(property);
            return RedirectToAction(nameof(Index));
         }
         return View(nameof(New));
      }



      /// <summary>
      /// GET edit action.
      /// Returns HTML form to edit a property.
      /// </summary>
      /// <param name="propertyId">User property id.</param>
      public IActionResult Edit(int propertyId)
      {
         if(!IsAuthenticated)
            return RedirectToAction("New", "Sessions");

         ViewBag.CurrentUser = CurrentUser;
         var property = AppServices.Get<Property>(propertyId);
         ViewBag.PropertyTypes = GetSelectListItems(PropertyTypes);
         ViewBag.PropertyStyles = GetSelectListItems(PropertyStyles);
         ViewBag.BasementTypes = GetSelectListItems(BasementTypes);
         ViewBag.RoofTypes = GetSelectListItems(RoofTypes);
         ViewBag.ParkingTypes = GetSelectListItems(ParkingTypes);
         ViewBag.HeatingTypes = GetSelectListItems(HeatingTypes);
         ViewBag.AirConditioningTypes = GetSelectListItems(AirConditioningTypes);

         return View(property);
      }



      /// <summary>
      /// POST update action.
      /// </summary>
      /// <param name="propertyId">Property id.</param>
      /// <param name="property">Property instance.</param>
      [HttpPost]
      public IActionResult Update(int propertyId, Property property)
      {
         if(!IsAuthenticated)
            return RedirectToAction("New", "Sessions");

         if(ModelState.IsValid)
         {
            var existingProperty = AppServices.Get<Property>(propertyId);
            existingProperty.UpdateProperties(property);
            AppServices.Save(existingProperty);
            return RedirectToAction(nameof(Index));
         }
         return View(nameof(Edit));
      }



      /// <summary>
      /// POST destroy action.
      /// </summary>
      /// <param name="propertyId">Property unique id.</param>
      [HttpPost]
      public IActionResult Destroy(int propertyId)
      {
         if(!IsAuthenticated)
            return RedirectToAction("New", "Sessions");

         var property = AppServices.Get<Property>(propertyId);
         if(property != null)
            AppServices.Delete(property);
         return RedirectToAction(nameof(Index));
      }
   }
}
