using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IJSONPlaceHolderService
    {
        Task<HttpResponseMessage> GetPostsAsync();
        Task<HttpResponseMessage> GetPostsForUserAsync(int userId);
        Task<HttpResponseMessage> GetUserAsync(int userId);
        Task<HttpResponseMessage> AddPostAsync(string title, string body);
    }
}
