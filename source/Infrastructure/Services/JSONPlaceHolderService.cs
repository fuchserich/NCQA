using Core.Services;
using Flurl;
using System.Text;
using System.Text.Json;

namespace Infrastructure.Services
{
    public class JSONPlaceHolderService : IJSONPlaceHolderService
    {
        private readonly HttpClient _httpClient;

        public JSONPlaceHolderService(HttpClient clientParam)
        {
            _httpClient = clientParam;
        }

        #region Posts
        public async Task<HttpResponseMessage> GetPostsAsync()
        {
            var uri = _httpClient.BaseAddress.ToString()
                .AppendPathSegment("posts")
                .ToUri();

            var response = await _httpClient.GetAsync(uri);
            return response;
        }

        public async Task<HttpResponseMessage> GetPostsForUserAsync(int userId)
        {
            var uri = _httpClient.BaseAddress.ToString()
                .AppendPathSegment("user")
                .AppendPathSegment(userId)
                .AppendPathSegment("posts")
                .ToUri();

            var response = await _httpClient.GetAsync(uri);
            return response;
        }

        public async Task<HttpResponseMessage> AddPostAsync(string title, string body)
        {
            var uri = _httpClient.BaseAddress.ToString()
                .AppendPathSegment("posts")
                .ToUri();

            var post = JsonSerializer.Serialize(new { title = title, body = body });
            var requestContent = new StringContent(post, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, requestContent);
            return response;
        }
        #endregion

        #region User
        public async Task<HttpResponseMessage> GetUserAsync(int userId)
        {
            var uri = _httpClient.BaseAddress.ToString()
                .AppendPathSegment("users")
                .AppendPathSegment(userId)
                .ToUri();

            var response = await _httpClient.GetAsync(uri);
            return response;
        }
        #endregion

        #region Albums
        public async Task<HttpResponseMessage> GetAlbumsByUserAsync(int userId)
        {
            var uri = _httpClient.BaseAddress.ToString()
                .AppendPathSegment("user")
                .AppendPathSegment(userId)
                .AppendPathSegment("albums")
                .ToUri();

            var response = await _httpClient.GetAsync(uri);
            return response;
        }
        #endregion

        #region Photos
        public async Task<HttpResponseMessage> GetPhotosByAlbumAsync(int albumId)
        {
            var uri = _httpClient.BaseAddress.ToString()
                .AppendPathSegment("album")
                .AppendPathSegment(albumId)
                .AppendPathSegment("photos")
                .ToUri();

            var response = await _httpClient.GetAsync(uri);
            return response;
        }

        public async Task<HttpResponseMessage> GetPhotoAsync(int photoId)
        {
            var uri = _httpClient.BaseAddress.ToString()
                .AppendPathSegment("photos")
                .AppendPathSegment(photoId)
                .ToUri();

            var response = await _httpClient.GetAsync(uri);
            return response;
        }
        #endregion
    }
}
