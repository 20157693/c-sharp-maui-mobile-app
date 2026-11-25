using UnsplashApp.Models;

namespace UnsplashApp.Services
{
    internal interface IUnsplashService
    {
        Task<SearchResult?> SearchPhotosAsync(string query);

        Task<Photo?> GetPhotoDetailsAsync(string id);

        Task<List<UnsplashCollection>?> GetCollectionsAsync();

        Task<List<Photo>?> GetCollectionPhotosAsync(string id);
    }
}
