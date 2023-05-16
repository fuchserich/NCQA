using Core.Services;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
