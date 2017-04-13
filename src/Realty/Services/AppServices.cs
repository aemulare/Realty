//=================================================================================================
// Class AppServices
// Application services
// Represents an abstract service layer providing access to data related operations.
//=================================================================================================
using System.Collections.Generic;
using Realty.Models;

namespace Realty.Services
{
   /// <summary>
   /// Application services
   /// Represents an abstract service layer providing access to data related operations.
   /// </summary>
   internal static class AppServices
   {
      #region Internal methods

      /// <summary>
      /// Gets a list of models of the specified type.
      /// </summary>
      /// <typeparam name="T">The model type.</typeparam>
      /// <returns>A list of model instances.</returns>
      internal static IList<T> Get<T>() where T : PersistentEntity => PersistenceService.Get<T>();

      /// <summary>
      /// Gets an entity of the specified type from DB.
      /// </summary>
      /// <typeparam name="T">The actual model type.</typeparam>
      /// <param name="id">The model unique id.</param>
      /// <returns>The instance of the specified type.</returns>
      internal static T Get<T>(int id) where T : PersistentEntity => PersistenceService.Get<T>(id);


      /// <summary>
      /// Saves the specified model instance.
      /// </summary>
      /// <typeparam name="T">The actual model type.</typeparam>
      /// <param name="model">A model instance.</param>
      internal static void Save<T>(T model) where T : PersistentEntity
      {
         PersistenceService.Save(model);
      }



      /// <summary>
      /// Deletes the specified model instance.
      /// </summary>
      /// <typeparam name="T">The actual model type.</typeparam>
      /// <param name="model">A model instance.</param>
      internal static void Delete<T>(T model) where T : PersistentEntity
      {
         PersistenceService.Delete(model);
      }

      #endregion

      #region Private properties

      /// <summary>
      /// Persistence service instance.
      /// </summary>
      private static PersistenceService PersistenceService { get; } = new PersistenceService();

      #endregion
   }
}
