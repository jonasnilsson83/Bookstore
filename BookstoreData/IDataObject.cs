using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreData
{
    public interface IDataObject<T>
    {
        /// <summary>
        /// Set global database for multiple actions in same transaction
        /// </summary>
        /// <param name="database"></param>
        void SetDatabase(Database database);

        /// <summary>
        /// Get an object
        /// </summary>
        /// <param name="domainObjectId"></param>
        /// <returns></returns>
        T Get(int domainObjectId);

        /// <summary>
        /// Get all objects
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Insert an object
        /// </summary>
        /// <param name="domainObject"></param>
        /// <returns></returns>
        int Create(T domainObject);

        /// <summary>
        /// Delete an object
        /// </summary>
        /// <param name="domainObject"></param>
        /// <returns></returns>
        int Delete(int domainObjectId);

        /// <summary>
        /// Update a data object
        /// </summary>
        /// <param name="domainObject"></param>
        /// <returns></returns>
        int Update(T domainObject);
    }
}
