using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnsplashApp.Controllers;
using UnsplashApp.Models;

namespace UnsplashApp.Tests
{
    [TestClass]
    public class UnsplashControllerTests
    {
        [TestMethod]
        public async Task ValidSearch_ReturnsPhotos()
        {
            // Arrange
            TestUnsplashService service = new();
            UnsplashController controller = new(service);

            // Act
            SearchResult? result = await controller.SearchAsync("cats");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Total);
            Assert.AreEqual(2, result.Results?.Count);
        }

        [TestMethod]
        public async Task EmptySearch_ThrowsException()
        {
            TestUnsplashService service = new();
            UnsplashController controller = new(service);

            await Assert.ThrowsExactlyAsync<ArgumentException>(
                () => controller.SearchAsync("")
            );
        }

        [TestMethod]
        public async Task WhitespaceSearch_ThrowsException()
        {
            TestUnsplashService service = new();
            UnsplashController controller = new(service);

            await Assert.ThrowsExactlyAsync<ArgumentException>(
                () => controller.SearchAsync("   ")
            );
        }

        [TestMethod]
        public async Task CollectionPhotos_ReturnsSearchResult()
        {
            TestUnsplashService service = new();
            UnsplashController controller = new(service);

            SearchResult result =
                await controller.GetCollectionPhotosAsync("collection1");

            Assert.AreEqual(2, result.Total);
            Assert.AreEqual(2, result.Results?.Count);
        }

        [TestMethod]
        public async Task PhotoDetails_ReturnsCorrectPhoto()
        {
            TestUnsplashService service = new();
            UnsplashController controller = new(service);

            Photo? result =
                await controller.GetPhotoDetailsAsync("photo1");

            Assert.IsNotNull(result);
            Assert.AreEqual("photo1", result.Id);
        }
    }
}
