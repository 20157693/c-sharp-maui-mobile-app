using UnsplashApp.Models;
using UnsplashApp.Services;

namespace UnsplashApp.Tests
{
    internal class TestUnsplashService : IUnsplashService
    {
        public Task<SearchResult?> SearchPhotosAsync(string query)
        {
            SearchResult result = new SearchResult
            {
                Total = 2,
                Results = new List<Photo>
                {
                    // Simulated test data
                    new Photo { Id = "photo1" },
                    new Photo { Id = "photo2" }
                }
            };
            // Fictional item SearchResult
            return Task.FromResult<SearchResult?>(result);
        }

        public Task<Photo?> GetPhotoDetailsAsync(string id)
        {
            return Task.FromResult<Photo?>(
                new Photo { Id = id }
            );
        }

        public Task<List<UnsplashCollection>?> GetCollectionsAsync()
        {
            return Task.FromResult<List<UnsplashCollection>?>(
                new List<UnsplashCollection>()
            );
        }

        public Task<List<Photo>?> GetCollectionPhotosAsync(string id)
        {
            return Task.FromResult<List<Photo>?>(
                new List<Photo>
                {
                    new Photo { Id = "photo1" },
                    new Photo { Id = "photo2" }
                }
            );
        }
    }
}