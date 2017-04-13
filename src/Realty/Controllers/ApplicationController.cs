using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Realty.Models;
using Realty.Services;
using System.Linq;

namespace Realty.Controllers
{
   public abstract class ApplicationController : Controller
   {
      #region Public properties

      public User CurrentUser => IsAuthenticated ? AppServices.Get<User>(CurrentUserId.Value) : null;


      public bool IsAuthenticated => CurrentUserId != null;

      #endregion

      #region Protected properties

      /// <summary>
      /// A collection of available property types.
      /// </summary>
      protected IEnumerable<PropertyType> PropertyTypes => AppServices.Get<PropertyType>();

      /// <summary>
      /// A collection of available property styles.
      /// </summary>
      protected IEnumerable<PropertyStyle> PropertyStyles => AppServices.Get<PropertyStyle>();

      /// <summary>
      /// A collection of available basement types.
      /// </summary>
      protected IEnumerable<BasementType> BasementTypes => AppServices.Get<BasementType>();

      /// <summary>
      /// A collection of available roof types.
      /// </summary>
      protected IEnumerable<RoofType> RoofTypes => AppServices.Get<RoofType>();

      /// <summary>
      /// A collection of available parking types.
      /// </summary>
      protected IEnumerable<ParkingType> ParkingTypes => AppServices.Get<ParkingType>();

      /// <summary>
      /// A collection of available heating types.
      /// </summary>
      protected IEnumerable<HeatingType> HeatingTypes => AppServices.Get<HeatingType>();

      /// <summary>
      /// A collection of available air conditioning types.
      /// </summary>
      protected IEnumerable<AirConditioningType> AirConditioningTypes => AppServices.Get<AirConditioningType>();

      /// <summary>
      /// A collection of available countries.
      /// </summary>
      protected IEnumerable<Country> Countries => AppServices.Get<Country>();

      #endregion

      #region Protected methods

      /// <summary>
      /// Gets a collection of select list items (needed for select HTML element).
      /// </summary>
      protected IEnumerable<SelectListItem> GetSelectListItems<T>(IEnumerable<T> collection)
         where T : ReferenceEntity =>
         collection.Select(item => new SelectListItem { Text = item.Name, Value = item.Id.ToString() });

      #endregion

      #region Private properties

      private int? CurrentUserId => HttpContext.Session.GetInt32("CurrentUserId");

      #endregion
   }
}
