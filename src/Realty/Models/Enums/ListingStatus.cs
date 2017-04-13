//=================================================================================================
// Enumeration ListingStatus
// Listing status.
//=================================================================================================
namespace Realty.Models
{
   /// <summary>
   /// Listing status.
   /// </summary>
   public enum ListingStatus
   {
      /// <summary>
      /// Initial status (when a listing item created).
      /// </summary>
      INITIAL,

      /// <summary>
      /// Valid offer exists for a listing item.
      /// </summary>
      IN_PROGRESS,

      /// <summary>
      /// Listing item is on hold.
      /// </summary>
      HOLD,

      /// <summary>
      /// Completed status.
      /// Property sold.
      /// </summary>
      COMPLETED,

      /// <summary>
      /// Cancelled status.
      /// </summary>
      CANCELLED
   }
}
