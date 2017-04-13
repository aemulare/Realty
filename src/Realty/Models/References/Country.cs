//=================================================================================================
// Class Country
// Country model.
//=================================================================================================
namespace Realty.Models
{
   /// <summary>
   /// Country model.
   /// </summary>
   public class Country : ReferenceEntity
   {
      #region Public properties

      /// <summary>
      /// Country code.
      /// </summary>
      public string Code { get; private set; }

      /// <summary>
      /// Determines whether the given country is US.
      /// </summary>
      public bool IsUS => Code.ToUpper() == "US";

      #endregion

      #region Internal properties

      /// <summary>
      /// The U.S.
      /// </summary>
      internal static Country US => new Country { Code = "US", Name = "United States" };

      #endregion
   }
}
