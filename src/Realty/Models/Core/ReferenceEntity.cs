//=================================================================================================
// Class ReferenceEntity
// Base abstract class for all reference entities.
//=================================================================================================
namespace Realty.Models
{
   /// <summary>
   /// Reference entity.
   /// Base abstract class fo all reference entities.
   /// </summary>
   public abstract class ReferenceEntity : PersistentEntity
   {
      #region Public properties

      /// <summary>
      /// Reference entity name.
      /// </summary>
      public string Name { get; protected set; }

      #endregion
   }
}
