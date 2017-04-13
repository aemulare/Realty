using System.Collections.Generic;

namespace Realty.Models.ViewModels
{
   public class PropertiesViewModel
   {
      public IEnumerable<Property> Properties { get; set; }
      public IEnumerable<Property> MyProperties { get; set; }

      public int? PropertyTypeId { get; set; }
      public int? PropertyStyleId { get; set; }
      public decimal? MinFloorFootage { get; set; }
      public int? CountryId { get; set; }
      public string City { get; set; }
      public int? MinYearBuilt { get; set; }
   }
}
