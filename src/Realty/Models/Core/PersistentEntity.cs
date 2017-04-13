//=================================================================================================
// Class PersistentEntity
// The root of all class hierarchy.
//=================================================================================================
namespace Realty.Models
{
   /// <summary>
   /// Persistent entity
   //// The root of all class hierarchy.
   /// </summary>
   public abstract class PersistentEntity
   {
      #region Public properties

      /// <summary>
      /// Unique object id.
      /// </summary>
      public int? Id { get; set; }

      /// <summary>
      /// Determines whether the object is new.
      /// </summary>
      public bool IsNew => Id == null;

      /// <summary>
      /// Determines whether the object is persisted (saved in DB).
      /// </summary>
      public bool IsPersisted => !IsNew;

      #endregion

      #region Public methods

      /// <summary>
      /// Determines whether the specified object is equal to the given object.
      /// </summary>
      public override bool Equals(object obj)
      {
         var entity = obj as PersistentEntity;
         return entity?.Id == Id;
      }



      /// <summary>
      /// Returns a hash code for the object.
      /// </summary>
      /// <returns></returns>
      public override int GetHashCode() => GetType().GetHashCode() ^ (Id?.GetHashCode() ?? 0);

      /// <summary>
      /// Overridden equality operator.
      /// </summary>
      public static bool operator ==(PersistentEntity obj1, PersistentEntity obj2) => Equals(obj1, obj2);

      /// <summary>
      /// Overridden inequality operator.
      /// </summary>
      public static bool operator !=(PersistentEntity obj1, PersistentEntity obj2) => !(obj1 == obj2);

      #endregion
   }
}
