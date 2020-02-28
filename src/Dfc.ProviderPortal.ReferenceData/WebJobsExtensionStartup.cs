using Dfc.ProviderPortal.Packages.AzureFunctions.DependencyInjection;
using Dfc.ProviderPortal.ReferenceData;
using Dfc.ProviderPortal.ReferenceData.Helpers;
using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Dfc.ProviderPortal.ReferenceData.Services;
using Dfc.ProviderPortal.ReferenceData.Settings;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: WebJobsStartup(typeof(WebJobsExtensionStartup), "Web Jobs Extension Startup")]

namespace Dfc.ProviderPortal.ReferenceData
{
    public class WebJobsExtensionStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddDependencyInjection();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                //.AddApplicationInsightsSettings()
                .Build();

            //builder.Services.AddApplicationInsightsTelemetry(configuration);

            var documentClient = new DocumentClient(new Uri(configuration.GetValue<string>("CosmosDbSettings:EndpointUri")), configuration.GetValue<string>("CosmosDbSettings:PrimaryKey"), new ConnectionPolicy()
            {
                ConnectionMode = ConnectionMode.Direct,
                ConnectionProtocol = Protocol.Tcp
            });

            builder.Services.AddSingleton(documentClient);
            builder.Services.AddSingleton<IConfiguration>(configuration);
            builder.Services.Configure<CosmosDbSettings>(configuration.GetSection(nameof(CosmosDbSettings)));
            builder.Services.Configure<CosmosDbCollectionSettings>(configuration.GetSection(nameof(CosmosDbCollectionSettings)));
            builder.Services.AddSingleton<ICosmosDbHelper, CosmosDbHelper>();
            builder.Services.AddScoped<IProgTypeService, ProgTypeService>();
            builder.Services.AddScoped<IFeChoiceService, FeChoiceService>();
            builder.Services.AddScoped<IStandardSectorCodeService, StandardSectorCodeService>();
            builder.Services.AddScoped<ISectorSubjectAreaTier1Service, SectorSubjectAreaTier1Service>();
            builder.Services.AddScoped<ISectorSubjectAreaTier2Service, SectorSubjectAreaTier2Service>();
            builder.Services.AddScoped<IApprenticeshipStandardService, ApprenticeshipStandardService>();
            builder.Services.AddScoped<IApprenticeshipFrameworkService, ApprenticeshipFrameworkService>();
        }
    }
}