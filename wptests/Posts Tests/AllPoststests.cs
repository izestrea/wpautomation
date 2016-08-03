using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpautomation;

namespace wptests.Posts_Tests
{
    [TestClass]
    public class AllPoststests : WpTests
    {
        // added posts to show up in all posts
        // can activate excerpt mode
        // can add new post

        // single post selections

        // can select a post by title
        // can select a post by edit
        // can select a post by quickedit
        // can trash a post
        // can view a post
        // can filter by author
        // can filter by category
        // can filter by tag
        // can go to post comments

        // bulk actions

        // can edit multiple posts
        // can trash multiple posts
        // can select all posts

        // drop down filters

        // can filter by month
        // can filter by category
        // can view published only
        // can view drafts only
        // can view trash only

        // can search posts

        // added posts show up in all posts
        // can trash a post
        // can search posts

        [TestMethod]
        public void Added_Posts_Show_Up()
        {
            // go to posts, get post count, store
            ListPostsPage.GoTo(PostType.Posts);
            ListPostsPage.StoreCount();

            // add a new post
            PostCreator.CreatePost();

            // go to posts, get new post count
            ListPostsPage.GoTo(PostType.Posts);
            Assert.AreEqual(ListPostsPage.PreviousPostCount + 1, ListPostsPage.CurrentPostCount, "Count of posts did not increase");

            // check for added post
            Assert.IsTrue(ListPostsPage.DoesPostExistWithTitle(PostCreator.PreviousTitle));

            // trash post (clean up)
            ListPostsPage.TrashPost(PostCreator.PreviousTitle);
            Assert.AreEqual(ListPostsPage.PreviousPostCount, ListPostsPage.CurrentPostCount, "Couldn't trash post");
        }
        [TestMethod]
        public void Can_Search_Posts()
        {
            // create a new post
            NewPostPage.GoTo();
            NewPostPage.CreatePost("Searching posts, title").WithBody("Searching posts, body").Publish();
            
            // go to list posts
            ListPostsPage.GoTo(PostType.Posts);

            // search for post
            ListPostsPage.SearchForPost("Searching posts, title");

            // check that post shows up in results
            Assert.IsTrue(ListPostsPage.DoesPostExistWithTitle("Searching posts, title"));

            // cleanup - trash post
            ListPostsPage.TrashPost("Searching posts, title");
        }
    }
}
