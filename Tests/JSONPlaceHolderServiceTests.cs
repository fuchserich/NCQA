using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Services;
using Microsoft.Extensions.Logging;

namespace Tests
{
    public class JSONPlaceHolderServiceTests
    {
        private MockRepository _mockRepository;

        private Mock<HttpMessageHandler> _handlerMock;
        private HttpClient _magicHttpClient;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new(MockBehavior.Default);
            _handlerMock = _mockRepository.Create<HttpMessageHandler>();
        }

        [Test]
        public async Task GetPosts_ShouldBeCalled()
        {
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"[{""userId"": 1,""id"": 1,""title"": ""sunt aut facere repellat provident occaecati excepturi optio reprehenderit"",""body"": ""quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto""}]"),
            };

            _handlerMock
              .Protected()
              .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
              .ReturnsAsync(response);
            var httpClient = new HttpClient(_handlerMock.Object) { BaseAddress = new Uri("http://test.com/")};
            var service = new JSONPlaceHolderService(httpClient);

            var retrievedPosts = await service.GetPostsAsync();

            Assert.NotNull(retrievedPosts);
            _handlerMock.Protected().Verify(
              "SendAsync",
              Times.Exactly(1),
              ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
              ItExpr.IsAny<CancellationToken>());
        }

        [Test]
        public async Task AddPosts_ShouldBeCalled()
        {
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"[{""userId"": 1,""id"": 1,""title"": ""sunt aut facere repellat provident occaecati excepturi optio reprehenderit"",""body"": ""quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto""}]"),
            };

            _handlerMock
              .Protected()
              .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
              .ReturnsAsync(response);
            var httpClient = new HttpClient(_handlerMock.Object) { BaseAddress = new Uri("http://test.com/") };
            var service = new JSONPlaceHolderService(httpClient);

            var retrievedPosts = await service.AddPostAsync("Test", "Body");

            Assert.NotNull(retrievedPosts);
            _handlerMock.Protected().Verify(
              "SendAsync",
              Times.Exactly(1),
              ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post),
              ItExpr.IsAny<CancellationToken>());
        }
    }
}