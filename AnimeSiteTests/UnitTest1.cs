using NUnit.Framework;
using AnimeSite.Database.Services;
using AnimeSite.Database;
using AnimeSite.Models;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AnimeSiteTests;

namespace AnimeSiteTests
{
    public class Tests
    {

        private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=animesitedb;Trusted_Connection=True;";

        private EntitiesService entitiesService;
        private PostService postService;
        private ViewModelService viewModelService;

        [SetUp]
        public void Setup()
        {

            SetUpServices();
            
        }

        private void SetUpServices()
        {
            
            Mock<ApplicationContext> MockDB = SetUpMockDB();

            this.entitiesService = new EntitiesService(MockDB.Object);
            this.postService = new PostService(MockDB.Object, entitiesService);
            this.viewModelService = new ViewModelService(MockDB.Object, entitiesService, postService);
        }

        private Mock<ApplicationContext> SetUpMockDB()
        {
            Mock<ApplicationContext> MockDB = new Mock<ApplicationContext>();

            // POST
            var postDbSetMock = DbSetMockBuilder<Post>.Build(
                    data: DbSetMocksData.GetPostsMockData()
                );

            // TAGS
            var tagsDbSetMock = DbSetMockBuilder<Tag>.Build(
                    data: DbSetMocksData.GetTags()
                );
            // TAGS ENTITIES
            var tagEntitiesDbSetMock = DbSetMockBuilder<TagEntity>.Build(
                    data: DbSetMocksData.GetTagEntities()
                );
            // STUDIOS
            var studiosDbSetMock = DbSetMockBuilder<Studio>.Build(
                    data: DbSetMocksData.GetStudios()
                );
            // STUDIO ENTITIES
            var studioEntitiesDbSetMock = DbSetMockBuilder<StudioEntity>.Build(
                    data: DbSetMocksData.GetStudioEntities()
                );
            // DIRECTORS
            var directorsDbSetMock = DbSetMockBuilder<Director>.Build(
                    data: DbSetMocksData.GetDirectors()
                );
            // DIRECTOR ENTITIES
            var directorEntitiesDbSetMock = DbSetMockBuilder<DirectorEntity>.Build(
                    data: DbSetMocksData.GetDirectorEntities()
                );
            // USER VIEW
            var userViewsDbSetMock = DbSetMockBuilder<UserView>.Build(
                    data: DbSetMocksData.GetUserViews()
                );
            // COMMENTS
            var commentDbSetMock = DbSetMockBuilder<Comment>.Build(
                    data: DbSetMocksData.GetComments()
                );

            MockDB.Setup(c => c.Posts).Returns(postDbSetMock.Object);
            MockDB.Setup(c => c.Tags).Returns(tagsDbSetMock.Object);
            MockDB.Setup(c => c.TagEntities).Returns(tagEntitiesDbSetMock.Object);
            MockDB.Setup(c => c.Studios).Returns(studiosDbSetMock.Object);
            MockDB.Setup(c => c.StudioEntities).Returns(studioEntitiesDbSetMock.Object);
            MockDB.Setup(c => c.Directors).Returns(directorsDbSetMock.Object);
            MockDB.Setup(c => c.DirectorEntities).Returns(directorEntitiesDbSetMock.Object);
            MockDB.Setup(c => c.UserViews).Returns(userViewsDbSetMock.Object);
            MockDB.Setup(c => c.Comments).Returns(commentDbSetMock.Object);


            return MockDB;
        }


        [Test]
        public void GetPostByDirectorID1_PostDirectorEqualsDirectorWithID1()
        {
            Post post = postService.GetPostsIQueryableByDirector(1, AnimeSite.Enums.OrderBy.Name).First();
            postService.SetMetadataToPosts(post);

            Director expectedDirector = entitiesService.GetDirectorByID(1);
            Director actualDirector = post.Directors.First(d => d.ID == 1);

            Assert.AreEqual(expectedDirector.Name, actualDirector.Name);
            Assert.AreEqual(expectedDirector.ID, actualDirector.ID);
        }

        [Test]
        public void GetPostByStudioID1_PostStudioEqualsStudioWithID1()
        {
            Post post = postService.GetPostsIQueryableByStudio(1, AnimeSite.Enums.OrderBy.Name).First();
            postService.SetMetadataToPosts(post);

            Studio expectedStudio = entitiesService.GetStudioByID(1);
            Studio actualStudio = post.Studios.First(s => s.ID == 1);

            Assert.AreEqual(expectedStudio.Name, actualStudio.Name);
            Assert.AreEqual(expectedStudio.ID, actualStudio.ID);
        }


        [Test]
        public void GetPostByTagID1_PostTagEqualsTagWithID1()
        {
            var id = new List<int>() { 1 };

            Post post = postService.GetPostsByTagsIDs(id).First();
            postService.SetMetadataToPosts(post);

            Tag expectedTag = entitiesService.GetTagByID(1);
            Tag actualTag = post.Tags.First(t => t.ID == 1);

            Assert.AreEqual(expectedTag.Name, actualTag.Name);
            Assert.AreEqual(expectedTag.ID, actualTag.ID);
        }

        [Test]
        public void GetPostsByYear2016_AllPostYearEquals2016()
        {

            var posts = postService.GetPostsByYear(2016, AnimeSite.Enums.OrderBy.Name);
            foreach(Post post in posts)
            {
                int expectedYear = 2016;
                int actualYear = post.ReleaseYear;
                Assert.AreEqual(expectedYear, actualYear);
            }
        }

        [Test]
        public void Foo()
        {
            var posts = postService.GetPostsIQueryable(AnimeSite.Enums.OrderBy.Name , year: null, tagIDs: null, s: null);
        }

    }

}
