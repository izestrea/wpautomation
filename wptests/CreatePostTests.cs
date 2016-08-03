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
    public class CreatePostTests : WpTests
    {
        [TestMethod]
        public void Can_Create_A_Basic_Post()
        {
            LoginPage.GotTo();
            LoginPage.LoginAs("admin").WithPassword("password").Login();

            NewPostPage.GoTo();
            NewPostPage.CreatePost("This is the test post title").WithBody("Hi, this is the body.").Publish();

            NewPostPage.GoToNewPost();

            Assert.AreEqual(PostPage.Title, "This is the test post title", "Title did not match new post.");
        }
    }
}
