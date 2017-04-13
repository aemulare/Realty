//=================================================================================================
// Class Listing
// Real estate property listing model.
// Represents all property listings within the system.
//=================================================================================================
using System;
using System.Collections.Generic;
using System.Linq;

namespace Realty.Models
{
   /// <summary>
   /// Real estate property listing model.
   /// Represents all property listings within the system.
   /// </summary>
   public class Listing : PersistentEntity
   {
      #region Constructor

      /// <summary>
      /// Default constructor.
      /// </summary>
      public Listing()
      {
      }



      /// <summary>
      /// Constructor.
      /// </summary>
      /// <param name="property">Property instance.</param>
      /// <param name="realtor"></param>
      /// <param name="askingPrice">Asking price.</param>
      public Listing(Property property, User realtor, decimal askingPrice)
      {
         if(property == null)
            throw new ArgumentNullException(nameof(property));
         if(realtor == null)
            throw new ArgumentNullException(nameof(realtor));
         if(askingPrice < 1)
            throw new ArgumentOutOfRangeException(nameof(askingPrice));

         Property = property;
         AskingPrice = askingPrice;
         Realtor = realtor;
      }

      #endregion

      #region Public properties

      /// <summary>
      /// Purpose of the listing: FOR SALE or FOR RENT.
      /// </summary>
      public ListingPurpose Purpose { get; set; } = ListingPurpose.FOR_SALE;

      /// <summary>
      /// Listing status: INITIAL, IN_PROGRESS, HOLD, COMPLETED, CANCELLED.
      /// </summary>
      public ListingStatus Status { get; private set; } = ListingStatus.INITIAL;

      /// <summary>
      /// Listing property.
      /// </summary>
      public Property Property { get; internal set; }

      /// <summary>
      /// Listing realtor.
      /// </summary>
      public User Realtor { get; internal set; }

      /// <summary>
      /// Asking price for the listed property.
      /// </summary>
      public decimal? AskingPrice { get; set; }

      /// <summary>
      /// Date and time when the listing was created.
      /// </summary>
      public DateTime CreatedAt { get; set; } = DateTime.Now;

      /// <summary>
      /// Date and time when status of the listing was changed.
      /// </summary>
      public DateTime StatusChangedAt { get; set; } = DateTime.Now;

      /// <summary>
      /// Date and time when the listing was completed (property was sold/rented).
      /// </summary>
      public DateTime? CompletedAt { get; set; }

      /// <summary>
      /// Realtor's comments about listing.
      /// </summary>
      public string Comments { get; set; }

      /// <summary>
      /// A list of offers for the given listing.
      /// </summary>
      public IList<Offer> Offers { get; private set; } = new List<Offer>();

      /// <summary>
      /// Determines whether the given listing has any offer.
      /// </summary>
      public bool HasOffers => Offers.Any();

      /// <summary>
      /// Determines whether the given listing is in initial status.
      /// </summary>
      public bool IsInitial => Status == ListingStatus.INITIAL;

      /// <summary>
      /// Determines whether the given listing is in progress.
      /// </summary>
      public bool IsInProgress => Status == ListingStatus.IN_PROGRESS;

      /// <summary>
      /// Determines whether the given listing is on hold.
      /// </summary>
      public bool IsHold => Status == ListingStatus.HOLD;

      /// <summary>
      /// Determines whether the given listing is completed.
      /// </summary>
      public bool IsCompleted => Status == ListingStatus.COMPLETED;

      /// <summary>
      /// Determines whether the given listing is cancelled.
      /// </summary>
      public bool IsCancelled => Status == ListingStatus.CANCELLED;

      #endregion

      #region Public methods

      /// <summary>
      /// Makes a new offer.
      /// </summary>
      /// <param name="offer">The new offer.</param>
      public void AddOffer(Offer offer)
      {
         if(offer == null)
            throw new ArgumentNullException(nameof(offer));

         if(Status == ListingStatus.INITIAL)
         {
            Status = ListingStatus.IN_PROGRESS;
            StatusChangedAt = DateTime.Now;
         }
         Offers.Add(offer);
      }



      /// <summary>
      /// Holds the given listing.
      /// </summary>
      public void Hold()
      {
         if(IsHold)
            return;

         if(IsInitial || IsInProgress)
         {
            Status = ListingStatus.HOLD;
            StatusChangedAt = DateTime.Now;
            return;
         }

         throw new InvalidOperationException("The listing must be in initial or in progress status to be on hold.");
      }



      /// <summary>
      /// Unholds the given listing.
      /// </summary>
      public void Unhold()
      {
         if(!IsHold)
            throw new InvalidOperationException("The listing must be on hold to be unholded.");

         Status = ListingStatus.IN_PROGRESS;
         StatusChangedAt = DateTime.Now;
      }



      /// <summary>
      /// Cancels the given listing.
      /// </summary>
      public void Cancel()
      {
         if(IsCompleted)
            throw new InvalidOperationException("Completed listing cannot be cancelled.");

         Status = ListingStatus.CANCELLED;
         StatusChangedAt = DateTime.Now;
      }

      #endregion

      #region Internal methods

      /// <summary>
      /// Completes the given listing.
      /// </summary>
      internal void Complete(Offer offer)
      {
         Status = ListingStatus.COMPLETED;
         CompletedAt = StatusChangedAt = DateTime.Now;
         Property.Owner = offer.Buyer;
      }

      #endregion
   }
}
