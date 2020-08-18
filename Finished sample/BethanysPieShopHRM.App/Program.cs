using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BethanysPieShopHRM.App.Services;
using BethanysPieShopHRM.App.MessageHandlers;

namespace BethanysPieShopHRM.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services
                .AddTransient<BethanysPieShopHRMApiAuthorizationMessageHandler>();

            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("OidcConfiguration", options.ProviderOptions);
                builder.Configuration.Bind("UserOptions", options.UserOptions);
            });

            builder.Services.AddAuthorizationCore(authorizationOptions =>
            {
                authorizationOptions.AddPolicy(
                    BethanysPieShopHRM.Shared.Policies.CanManageEmployees,
                    BethanysPieShopHRM.Shared.Policies.CanManageEmployeesPolicy());
            });

            builder.Services.AddHttpClient<IEmployeeDataService, EmployeeDataService>(
                client => client.BaseAddress = new Uri("https://localhost:44340/"))
                .AddHttpMessageHandler<BethanysPieShopHRMApiAuthorizationMessageHandler>();

            builder.Services.AddHttpClient<ICountryDataService, CountryDataService>(
                client => client.BaseAddress = new Uri("https://localhost:44340/"))
                .AddHttpMessageHandler<BethanysPieShopHRMApiAuthorizationMessageHandler>();

            builder.Services.AddHttpClient<IJobCategoryDataService, JobCategoryDataService>(
                client => client.BaseAddress = new Uri("https://localhost:44340/"))
                .AddHttpMessageHandler<BethanysPieShopHRMApiAuthorizationMessageHandler>();

            await builder.Build().RunAsync();
        }
    }
}
