using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpautomation;

namespace wptests
{    
    [TestClass]
    public class PageTests : WpTests
    {       
        [TestMethod]
        public void Can_Edit_A_Page()
        {
            LoginPage.GotTo();
            LoginPage.LoginAs("admin").WithPassword("password").Login();

            ListPostsPage.GoTo(PostType.Page);
            ListPostsPage.SelectPost("Sample Page");

            Assert.IsTrue(NewPostPage.IsInEditMode(), "Wasn't in edit mode");
            Assert.AreEqual("Sample Page", NewPostPage.Title, "Title did not match");
        }
    }
}
