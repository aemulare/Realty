//=================================================================================================
// Class Offer
// Offer model.
// Represents all buyer's offers within the system.
//=================================================================================================
using System;

namespace Realty.Models
{
   /// <summary>
   /// Offer model.
   /// Represents all buyer's offers within the system.
   /// </summary>
   public class Offer : PersistentEntity
   {
      #region Constructors

      /// <summary>
      /// Default constructor.
      /// </summary>
      public Offer()
      {
      }



      /// <summary>
      /// Constructor.
      /// </summary>
      /// <param name="listing">Listing item.</param>
      /// <param name="buyer">A user who makes an offer.</param>
      /// <param name="price">Suggested price.</param>
      public Offer(Listing listing, User buyer, decimal price)
      {
         if(listing == null)
            throw new ArgumentNullException(nameof(listing));
         if(buyer == null)
            throw new ArgumentNullException(nameof(buyer));
         if(price < 1)
            throw new ArgumentOutOfRangeException(nameof(price));

         Listing = listing;
         Buyer = buyer;
         OfferPrice = price;

         Listing.AddOffer(this);
      }

      #endregion

      #region Public properties

      /// <summary>
      /// Offer status: ACTIVE, EXPIRED, ACCEPTED, CANCELLED.
      /// </summary>
      public OfferStatus Status { get; set; } = OfferStatus.ACTIVE;

      /// <summary>
      /// Property listing, based on which buyer is making the offer.
      /// </summary>
      public Listing Listing { get; internal set; }

      /// <summary>
      /// Buyer who is making the offer.
      /// </summary>
      public User Buyer { get; internal set; }

      /// <summary>
      /// Offering price for the listed property.
      /// </summary>
      public decimal? OfferPrice { get; set; }

      /// <summary>
      /// Date and time when the offer was made.
      /// </summary>
      public DateTime CreatedAt { get; set; } = DateTime.Now;

      /// <summary>
      /// Expiration date and time for the offer.
      /// </summary>
      public DateTime ExpiredAt { get; set; } = DateTime.Today + TimeSpan.FromDays(10);

      /// <summary>
      /// Date and time when the offer was completed (property was sold/rented).
      /// </summary>
      public DateTime? CompletedAt { get; private set; }

      /// <summary>
      /// Determines whether the given offer is expired.
      /// </summary>
      public bool IsExpired => DateTime.Today > ExpiredAt;

      /// <summary>
      /// Determines whether the given offer is active.
      /// </summary>
      public bool IsActive => Status == OfferStatus.ACTIVE;

      /// <summary>
      /// Determines whether the given offer is accepted.
      /// </summary>
      public bool IsAccepted => Status == OfferStatus.ACCEPTED;

      /// <summary>
      /// Determines whether the given offer is cancelled.
      /// </summary>
      public bool IsCancelled => Status == OfferStatus.CANCELED;

      #endregion

      #region Public methods

      /// <summary>
      /// Accepts the given offer.
      /// </summary>
      public void Accept()
      {
         if(IsExpired)
            throw new InvalidOperationException("Offer is expired.");

         Status = OfferStatus.ACCEPTED;
         Listing.Hold();
      }



      /// <summary>
      /// Cancels the given offer.
      /// </summary>
      public void Cancel()
      {
         Status = OfferStatus.CANCELED;
      }

      #endregion

      #region Internal methods

      /// <summary>
      /// Completes the given offer
      /// </summary>
      internal void Complete()
      {
         Listing.Complete(this);
         CompletedAt = DateTime.Now;
      }

      #endregion
   }
}
