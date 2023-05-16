namespace Core.Services
{
    public interface IJSONPlaceHolderService
    {
        Task<HttpResponseMessage> GetPostsAsync();
        Task<HttpResponseMessage> GetPostsForUserAsync(int userId);
        Task<HttpResponseMessage> AddPostAsync(string title, string body);
        Task<HttpResponseMessage> GetUserAsync(int userId);
        Task<HttpResponseMessage> GetAlbumsByUserAsync(int userId);
        Task<HttpResponseMessage> GetPhotosByAlbumAsync(int albumId);
        Task<HttpResponseMessage> GetPhotoAsync(int photoId);
    }
}
