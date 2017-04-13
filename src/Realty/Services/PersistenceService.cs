//=================================================================================================
// Class PersistenceService
// Persistence service.
// Provides a database related CRUD operations (database access layer).
//=================================================================================================
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using Realty.Models;

namespace Realty.Services
{
   /// <summary>
   /// Persistence service.
   /// Provides a database related CRUD operations (database access layer).
   /// </summary>
   public class PersistenceService
   {
      #region Public methods

      /// <summary>
      /// Gets a collection of all entities from DB.
      /// </summary>
      /// <typeparam name="T">The actual persistent entity type.</typeparam>
      /// <returns>A collection of all entities of the specified type in the database.</returns>
      public IList<T> Get<T>() where T : PersistentEntity
      {
         using(var session = Factory.OpenSession())
         {
            var criteria = session.CreateCriteria<T>();
            return criteria.List<T>();
         }
      }



      /// <summary>
      /// Gets an entity of the specified type from DB.
      /// </summary>
      /// <typeparam name="T">The actual persistent entity type.</typeparam>
      /// <param name="id">Persistent entity unique id.</param>
      /// <returns>The instance of the specified type.</returns>
      public T Get<T>(int id) where T : PersistentEntity
      {
         using(var session = Factory.OpenSession())
         {
            var criteria = session.CreateCriteria<T>();
            criteria.Add(Restrictions.Eq("Id", id));
            return criteria.UniqueResult<T>();
         }
      }



      /// <summary>
      /// Saves the entity instance in the database.
      /// </summary>
      /// <typeparam name="T">The actual persistent entity type.</typeparam>
      /// <param name="entity">Persistent entity instance.</param>
      public void Save<T>(T entity) where T : PersistentEntity
      {
         using(var session = Factory.OpenSession())
         using(var trans = session.BeginTransaction())
         {
            session.SaveOrUpdate(entity);
            trans.Commit();
         }
      }



      /// <summary>
      /// Deletes the persistent entity.
      /// </summary>
      /// <typeparam name="T">The actual persistent entity type.</typeparam>
      /// <param name="entity">Persistent entity instance.</param>
      public void Delete<T>(T entity) where T : PersistentEntity
      {
         using(var session = Factory.OpenSession())
         using(var trans = session.BeginTransaction())
         {
            session.Delete(entity);
            trans.Commit();
         }
      }

      #endregion

      #region Private properties

      /// <summary>
      /// NHibernate session factory.
      /// </summary>
      private ISessionFactory Factory { get; } = new Configuration().Configure().BuildSessionFactory();

      #endregion
   }
}
