using Dfc.ProviderPortal.ReferenceData.Helpers;
using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Dfc.ProviderPortal.ReferenceData.Services;
using Dfc.ProviderPortal.ReferenceData.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace Dfc.ProviderPortal.ReferenceData.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.Configure<CosmosDbSettings>(Configuration.GetSection(nameof(CosmosDbSettings)));
            services.Configure<CosmosDbCollectionSettings>(Configuration.GetSection(nameof(CosmosDbCollectionSettings)));
            services.AddScoped<ICosmosDbHelper, CosmosDbHelper>();
            services.AddScoped<IProgTypeService, ProgTypeService>();
            services.AddScoped<IFeChoiceService, FeChoiceService>();
            services.AddScoped<IStandardSectorCodeService, StandardSectorCodeService>();
            services.AddScoped<ISectorSubjectAreaTier1Service, SectorSubjectAreaTier1Service>();
            services.AddScoped<ISectorSubjectAreaTier2Service, SectorSubjectAreaTier2Service>();
            services.AddScoped<IApprenticeshipStandardService, ApprenticeshipStandardService>();
            services.AddScoped<IApprenticeshipFrameworkService, ApprenticeshipFrameworkService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Apprenticeship Reference Data API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Apprenticeship Reference Data API");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}