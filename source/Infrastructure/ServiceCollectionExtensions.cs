using Core.Services;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection servicesParam)
        {
            servicesParam.AddHttpClient<IJSONPlaceHolderService, JSONPlaceHolderService>(client =>
            {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            });
        }
    }
}
