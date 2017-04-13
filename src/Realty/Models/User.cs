//=================================================================================================
// Class User
// User model.
// Represents all users within the system.
//=================================================================================================
using System;

namespace Realty.Models
{
   /// <summary>
   /// User model.
   /// Represents all users within the system.
   /// </summary>
   public class User : PersistentEntity
   {
      #region Public properties

      /// <summary>
      /// Login name.
      /// </summary>
      public string Login { get; set; }

      /// <summary>
      /// Password.
      /// </summary>
      public string Password { get; set; }

      /// <summary>
      /// Person who owns user account
      /// </summary>
      public Person Person { get; private set; } = new Person();

      /// <summary>
      /// Is active: lock/unlock user activity in the system.
      /// </summary>
      /// <remarks>
      /// This property is initialized as true by default.
      /// </remarks>
      public bool IsActive { get; set; } = true;

      /// <summary>
      /// Is admin: determines whether the user has admin access.
      /// </summary>
      public bool IsAdmin { get; set; }

      /// <summary>
      /// Is realtor: determines whether the user has realtor access.
      /// </summary>
      public bool IsRealtor { get; set; }

      #endregion

      #region Public methods

      /// <summary>
      /// Determines whether the specified offer can be accepted by the given user.
      /// </summary>
      /// <param name="offer">Offer instance.</param>
      /// <returns>True, if the offer can be accepted by the given user; otherwise, false.</returns>
      public bool CanAcceptOffer(Offer offer)
      {
         if(offer == null)
            throw new ArgumentNullException(nameof(offer));

         return offer.IsActive && !offer.IsExpired && offer.Listing.Property.Owner == this;
      }



      /// <summary>
      /// Determines whether the specified offer can be cancelled by the given user.
      /// </summary>
      /// <param name="offer">Offer instance.</param>
      /// <returns>True, if the offer can be cancelled by the given user; otherwise, false.</returns>
      public bool CanCancelOffer(Offer offer)
      {
         if(offer == null)
            throw new ArgumentNullException(nameof(offer));

         return !offer.IsCancelled && !offer.Listing.IsCompleted && offer.Buyer == this;
      }



      /// <summary>
      /// Determines whether the given user can registered sale for the specified offer.
      /// </summary>
      /// <param name="offer">Offer instance.</param>
      /// <returns>True, if the sale can be registered for the specified offer; otherwise, false.</returns>
      public bool CanRegisterSale(Offer offer)
      {
         if(offer == null)
            throw new ArgumentNullException(nameof(offer));

         return offer.IsAccepted && !offer.IsExpired && IsRealtor && offer.Listing.Realtor == this;
      }



      /// <summary>
      /// Determines whether the given user can create new listing.
      /// </summary>
      /// <returns></returns>
      public bool CanCreateListing() => IsRealtor;

      /// <summary>
      /// Determines whether the specified listing can be edited by the given user.
      /// </summary>
      /// <param name="listing">Listing instance.</param>
      /// <returns>True, if the given user can edit the specified listing; otherwise, false.</returns>
      public bool CanEditListing(Listing listing)
      {
         if(listing == null)
            throw new ArgumentNullException(nameof(listing));

         return listing.IsInitial && !listing.HasOffers && listing.Realtor == this;
      }



      /// <summary>
      /// Determines whether the specified listing can be managed (hold/unhold/cancel) by the given user.
      /// </summary>
      /// <param name="listing">Listing instance.</param>
      /// <returns>True, if the given user can manage (hold/unhold/cancel) the specified listing; otherwise, false.</returns>
      public bool CanManageListing(Listing listing)
      {
         if(listing == null)
            throw new ArgumentNullException(nameof(listing));

         return !listing.IsCompleted && listing.Realtor == this;
      }

      #endregion

      #region Internal methods

      /// <summary>
      /// Updates properties of the given user from the specified user instance.
      /// </summary>
      /// <param name="user">User instance</param>
      internal void UpdateProperties(User user)
      {
         IsActive = user.IsActive;
         IsAdmin = user.IsAdmin;
         IsRealtor = user.IsRealtor;
         Person.UpdateProperties(user.Person);
      }

      #endregion
   }
}
