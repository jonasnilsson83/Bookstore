using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreData
{
    public class ServiceBase
    {
        /// <summary>
        /// The data object factory.
        /// </summary>
        protected readonly IDataObjectFactory DataObjectFactory;
      

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBase"/> class.
        /// </summary>
        /// <param name="dataObjectFactory">
        /// The data object factory.
        /// </param>
        protected ServiceBase(IDataObjectFactory dataObjectFactory)
        {
            DataObjectFactory = dataObjectFactory;
        }
    }
}
