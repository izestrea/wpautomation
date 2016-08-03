using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using wpautomation;

namespace wptests
{
    [TestClass]
    public class LoginTests : WpTests
    {       
        [TestMethod]
        public void Admin_User_Can_Login()
        {
            Assert.IsTrue(DashboardPage.IsAt, "Failed to login");
        }
    }
}
