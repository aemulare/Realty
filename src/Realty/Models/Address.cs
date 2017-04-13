//=================================================================================================
// Class Address
// Address model.
//================================================================================================ =
namespace Realty.Models
{
   /// <summary>
   /// Address model.
   /// </summary>
   public class Address : PersistentEntity
   {
      #region Public properties

      /// <summary>
      /// Street address 1 (street number and street name).
      /// </summary>
      public string StreetAddress1 { get; set; }

      /// <summary>
      /// Street address 2 (number of apartment, flat, office, suite, etc.).
      /// </summary>
      public string StreetAddress2 { get; set; }

      /// <summary>
      /// City name.
      /// </summary>
      public string City { get; set; }

      /// <summary>
      /// US state (for US addresses only).
      /// </summary>
      public string State { get; set; }

      /// <summary>
      /// Region (for non-US addresses only).
      /// </summary>
      public string Region { get; set; }

      /// <summary>
      /// Postal code.
      /// </summary>
      public string PostalCode { get; set; }

      /// <summary>
      /// Country.
      /// </summary>
      public Country Country { get; set; } = Country.US;

      /// <summary>
      /// Determines whether the given address us US address.
      /// </summary>
      public bool IsUSAddress => CountryCode == Country.US.Code;

      /// <summary>
      /// Country code.
      /// </summary>
      public string CountryCode { get; set; } = "US";

      /// <summary>
      /// Full address 
      /// </summary>
      public string FullAddress
      {
         get
         {
            var line1 = $"{StreetAddress1} {StreetAddress2},";
            var line2 = $"{City}, {(IsUSAddress ? State : Region)}, {PostalCode} {CountryCode}";
            return line1.Trim() + " " + line2.Trim();
         }
      }

      #endregion

      #region Internal properties

      /// <summary>
      /// Updates properties of the given address instance from the specified other address instance.
      /// </summary>
      /// <param name="address">Address instance</param>
      internal void UpdateProperties(Address address)
      {
         StreetAddress1 = address.StreetAddress1;
         StreetAddress2 = address.StreetAddress2;
         City = address.City;
         State = address.State;
         Region = address.Region;
         PostalCode = address.PostalCode;
         CountryCode = address.CountryCode;
      }

      #endregion
   }
}
