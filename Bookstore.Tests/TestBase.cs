using ApplicationFacadeService;
using BookstoreData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Tests
{
    [TestClass]
    public class TestBase
    {
        
        private ApplicationFacadeService.ApplicationFacadeService _applicationFacadeService;
        protected IDataObjectFactory DataObjectFactory => _applicationFacadeService.DataObjectFactory;


        [TestInitialize]
        public void Initialize()
        {
            _applicationFacadeService = new ApplicationFacadeService.ApplicationFacadeService();
        }


    }
}
