using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceInterface
{
    public interface IDataObjectFactory
    {
        /// <summary>
        /// Create a new instance of <see cref="T"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The type to create. 
        /// </typeparam>
        /// <returns>
        /// A new instance of <see cref="T"/>.
        /// </returns>
        T Create<T>();
    }
}
