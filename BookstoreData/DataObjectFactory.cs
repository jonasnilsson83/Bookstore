using BookstoreData.BookData;
using Microsoft.Practices.Unity;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreData
{

    /// <summary>
    /// The data object factory.
    /// </summary>
    public class DataObjectFactory : IDataObjectFactory
    {
        #region Fields
        private readonly IUnityContainer container;
        #endregion

        #region Constructors and Destructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DataObjectFactory"/> class.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public DataObjectFactory(IUnityContainer container)
        {
            this.container = container;

            container.RegisterType<IBookDataObject, BookDataObject>();
            //container.RegisterType<IAttendanceCodeDataObject, AttendanceCodeDataObject>();
            //container.RegisterType<IAttendanceCodeCombinationDataObject, AttendanceCodeCombinationDataObject>();
           
        }
        #endregion

        #region Public Methods and Operators
        /// <summary>
        /// Creates a new instance of <typeparamref name="T"/>
        /// </summary>
        /// <param name="interval">
        /// The interval.
        /// </param>
        /// <typeparam name="T">
        /// The type to create. 
        /// </typeparam>
        /// <returns>
        /// A new instance of <typeparamref name="T"/>
        /// </returns>
        public T Create<T>()
        {
            return container.Resolve<T>();
        }
        #endregion
    }
}
