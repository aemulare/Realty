//=================================================================================================
// Class Property
// Real Estate Property model.
// Represents all real estate properties within the system.
//=================================================================================================
using System;

namespace Realty.Models
{
   /// <summary>
   /// Real Estate Property model.
   /// Represents all real estate properties within the system.
   /// </summary>
   public class Property : PersistentEntity
   {
      #region Private members

      private string photo;

      #endregion

      #region Constructors

      /// <summary>
      /// Default constructor.
      /// </summary>
      public Property()
      {
      }



      /// <summary>
      /// Constructor.
      /// </summary>
      /// <param name="owner">Property owner</param>
      public Property(User owner)
      {
         if(owner == null)
            throw new ArgumentNullException(nameof(owner));
         Owner = owner;
      }

      #endregion

      #region Public properties

      /// <summary>
      /// Owner of the property.
      /// </summary>
      public User Owner { get; internal set; }

      /// <summary>
      /// Date the property was added to database.
      /// </summary>
      public DateTime CreatedAt { get; set; } = DateTime.Now;

      /// <summary>
      /// Year when the propery was built.
      /// </summary>
      public int? YearBuilt { get; set; }

      /// <summary>
      /// Address of the property.
      /// </summary>
      public Address Address { get; internal set; } = new Address();

      /// <summary>
      /// Address map URL: link to google map to property location.
      /// </summary>
      public string PropertyAddressUrl { get; set; }

      /// <summary>
      /// Property type.
      /// </summary>
      public PropertyType PropertyType { get; set; }

      /// <summary>
      /// Property style.
      /// </summary>
      public PropertyStyle PropertyStyle { get; set; }

      /// <summary>
      /// Basement type (development).
      /// </summary>
      public BasementType BasementType { get; set; }

      /// <summary>
      /// Roof type.
      /// </summary>
      public RoofType RoofType { get; set; }

      /// <summary>
      /// Parking type.
      /// </summary>
      public ParkingType ParkingType { get; set; }

      /// <summary>
      /// Heating type.
      /// </summary>
      public HeatingType HeatingType { get; set; }

      /// <summary>
      /// Air conditioning type.
      /// </summary>
      public AirConditioningType AirConditioningType { get; set; }

      /// <summary>
      /// Floor square footage.
      /// </summary>
      public decimal? FloorFootage { get; set; }

      /// <summary>
      /// Lot square footage.
      /// </summary>
      public decimal? LotFootage { get; set; }

      /// <summary>
      /// Number of floors.
      /// </summary>
      public byte? FloorsCount { get; set; }

      /// <summary>
      /// Number of bedrooms.
      /// </summary>
      public byte? BedroomsCount { get; set; }

      /// <summary>
      /// Number of bathrooms.
      /// </summary>
      public decimal? BathroomsCount { get; set; }

      /// <summary>
      /// Number of parking spaces.
      /// </summary>
      public int? ParkingSpacesCount { get; set; }

      /// <summary>
      /// Maximum Home Owners Association (HOA) Fee.
      /// </summary>
      public decimal? MaxHoa { get; set; }

      /// <summary>
      /// List of appliances.
      /// </summary>
      public string Appliances { get; set; }

      /// <summary>
      /// List of amenities.
      /// </summary>
      public string Amenities { get; set; }

      /// <summary>
      /// Additional realtor's comments about property.
      /// </summary>
      public string Comments { get; set; }

      /// <summary>
      /// Property photo.
      /// Represents a file name containing the property photo.
      /// </summary>
      public string Photo
      {
         get { return this.photo ?? "default.png"; }
         set { this.photo = value; }
      }

      #endregion

      #region Internal methods

      /// <summary>
      /// Updates properties of the given property instance from the specified property instance.
      /// </summary>
      /// <param name="property">Property instance</param>
      internal void UpdateProperties(Property property)
      {
         CreatedAt = property.CreatedAt;
         YearBuilt = property.YearBuilt;
         Address.UpdateProperties(property.Address);
         PropertyAddressUrl = property.PropertyAddressUrl;
         PropertyType = property.PropertyType;
         PropertyStyle = property.PropertyStyle;
         BasementType = property.BasementType;
         RoofType = property.RoofType;
         ParkingType = property.ParkingType;
         HeatingType = property.HeatingType;
         AirConditioningType = property.AirConditioningType;
         FloorFootage = property.FloorFootage;
         LotFootage = property.LotFootage;
         FloorsCount = property.FloorsCount;
         BedroomsCount = property.BedroomsCount;
         BathroomsCount = property.BathroomsCount;
         ParkingSpacesCount = property.ParkingSpacesCount;
         MaxHoa = property.MaxHoa;
         Appliances = property.Appliances;
         Amenities = property.Amenities;
         Comments = property.Comments;
      }

      #endregion
   }
}
