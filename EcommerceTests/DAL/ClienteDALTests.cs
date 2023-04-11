using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ecommerce.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Services;

namespace Ecommerce.DAL.Tests
{
    [TestClass()]
    public class ClienteDALTests
    {
        [TestMethod()]
        public void LoginTest()
        {

            ClienteService serv = new ClienteService();
            Models.Cliente cli = new Models.Cliente();
            (bool,string)res = serv.ValidarLogin(cli,"paulo@hotmail","123");

            Assert.IsNotNull(cli);
        }
    }
}

namespace EcommerceTests.DAL
{
    class ClienteDALTests
    {
    }
}
