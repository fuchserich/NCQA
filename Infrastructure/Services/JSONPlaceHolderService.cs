using Core.Domain;
using Core.Services;
using Flurl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class JSONPlaceHolderService : IJSONPlaceHolderService
    {
        private readonly HttpClient _httpClient;

        public JSONPlaceHolderService(HttpClient clientParam)
        {
            _httpClient = clientParam;
        }

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

        public async Task<HttpResponseMessage> GetUserAsync(int userId)
        {
            var uri = _httpClient.BaseAddress.ToString()
                .AppendPathSegment("users")
                .AppendPathSegment(userId)
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
    }
}
