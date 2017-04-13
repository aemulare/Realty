//=================================================================================================
// Class Sale
// Sale transaction model.
// Represents all sale transactions within the system.
// If property was rented - it's sale transaction, too, with price per month.
//=================================================================================================
using System;

namespace Realty.Models
{
   /// <summary>
   /// Sale transaction model.
   /// Represents all sale transactions within the system.
   /// If property was rented - it's sale transaction, too, with price per month.
   /// </summary>
   public class Sale : PersistentEntity
   {
      #region Constructors

      /// <summary>
      /// Default constructor.
      /// </summary>
      public Sale()
      {
      }



      /// <summary>
      /// Constructor.
      /// </summary>
      /// <param name="offer">Offer.</param>
      /// <param name="realtorFee">Realtor fee.</param>
      public Sale(Offer offer, decimal realtorFee)
      {
         if(offer == null)
            throw new ArgumentNullException(nameof(offer));
         if(realtorFee < 0)
            throw new ArgumentOutOfRangeException(nameof(realtorFee));
         if(!offer.IsAccepted)
            throw new InvalidOperationException("Offer must be accepted to perform sale.");
         if(offer.IsExpired)
            throw new InvalidOperationException("Offer is expired.");

         Offer = offer;
         RealtorFee = realtorFee;
         Offer.Complete();
      }

      #endregion

      #region Public properties

      /// <summary>
      /// Date and time when the property was sold/rented.
      /// </summary>
      public DateTime SoldAt { get; private set; } = DateTime.Now;

      /// <summary>
      /// Offer based on which sale transaction was made.
      /// </summary>
      public Offer Offer { get; set; }

      /// <summary>
      /// Realtor fee for the deal (percentage).
      /// </summary>
      public decimal RealtorFee { get; set; }

      #endregion
   }
}
