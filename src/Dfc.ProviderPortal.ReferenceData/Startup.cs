using System;
using Dfc.ProviderPortal.ReferenceData;
using Dfc.ProviderPortal.ReferenceData.Helpers;
using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Dfc.ProviderPortal.ReferenceData.Services;
using Dfc.ProviderPortal.ReferenceData.Settings;
using DFC.Swagger.Standard;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
[assembly: FunctionsStartup(typeof(Startup))]

namespace Dfc.ProviderPortal.ReferenceData
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = builder.GetContext().Configuration;

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
            builder.Services.AddScoped<ISwaggerDocumentGenerator, SwaggerDocumentGenerator>();
        }
    }
}