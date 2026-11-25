using UnsplashApp.Models;
using UnsplashApp.Services;

namespace UnsplashApp.Controllers
{
    internal class UnsplashController
    {
        private readonly IUnsplashService _service;

        public UnsplashController(IUnsplashService service)
        {
            _service = service;
        }

        public async Task<SearchResult?> SearchAsync(string? query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentException("Please enter a search keyword.");
            }

            return await _service.SearchPhotosAsync(query);
        }

        public async Task<List<UnsplashCollection>?> GetCollectionsAsync()
        {
            return await _service.GetCollectionsAsync();
        }

        public async Task<SearchResult> GetCollectionPhotosAsync(string id)
        {
            // Send API request to receive group of photos from collection
            List<Photo>? photos =
                await _service.GetCollectionPhotosAsync(id);
            // Return all photos
            return new SearchResult
            {
                Total = photos?.Count ?? 0,
                Results = photos
            };
        }

        public async Task<Photo?> GetPhotoDetailsAsync(string id)
        {
            return await _service.GetPhotoDetailsAsync(id);
        }
    }
}
