using BookstoreData;

using Microsoft.Practices.Unity;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationFacadeService
{
    public class ApplicationFacadeService
    {
        public IDataObjectFactory DataObjectFactory { get; }
        public IBookstoreService BookstoreService { get; }
        public IShoppingCartService ShoppingCartService { get; }

        public ApplicationFacadeService()
        {
            var container = new UnityContainer();
            
            //Register services to use
            container.RegisterType<IBookstoreService, BookstoreService.BookstoreDataService>();
            container.RegisterType<IShoppingCartService, BookstoreService.ShoppingCartService>();

            // Register the data object factory
            container.RegisterType<IDataObjectFactory, DataObjectFactory>();

            DataObjectFactory = new DataObjectFactory(container);
            BookstoreService = container.Resolve<IBookstoreService>();
            ShoppingCartService = container.Resolve<IShoppingCartService>();
        }
    }
}
