using System.Collections.Generic;

namespace Realty.Models.ViewModels
{
    public class ListingsViewModel
    {
      public IEnumerable<Listing> Listings { get; set; }

      public int? PropertyTypeId { get; set; }
      public int? PropertyStyleId { get; set; }
      public decimal? MinFloorFootage { get; set; }
      public int? CountryId { get; set; }
      public string City { get; set; }
      public int? MinYearBuilt { get; set; }
      public decimal? MinPrice { get; set; }
      public decimal? MaxPrice { get; set; }
   }
}
