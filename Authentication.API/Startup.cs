using Authentication.API.Application.Queries;
using Authentication.API.Queries;
using CLSK12.BaseService.Services.IdentityService;
using EshopSolution.Extensions;
using EshopSolution.Extensions.Services.IdentityService;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Steeltoe.Discovery.Client;
using System.Collections.Generic;
using System.Reflection;

namespace Authentication.API
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
            services.AddDiscoveryClient(Configuration);
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddControllers()
                .AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            services.AddCustomSwagger();
            services.AddCustomConfiguration(this.Configuration);
            services.AddCustomDependency(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDiscoveryClient();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseRouting();
            app.UseCors("MyPolicy");
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
    static class CustomExtensionsMethods
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                      {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                      });
            });

            return services;
        }

        public static IServiceCollection AddCustomDependency(this IServiceCollection services, IConfiguration configuration)
        {

            #region REPOSITORIES

            #region Category
            #endregion

            #region Product

            #endregion
            #endregion

            #region QUERIES
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<IUserQueries>(s => new UserQueries(configuration["ConnectionStrings:DefaultConnection"]));
            #endregion

            #region GraphQL
            //services.AddTransient<IOrdersRepository, OrdersRepository>();
            //services.AddTransient<IDocumentExecuter, DocumentExecuter>();
            //services.AddTransient<OrderQuery>();
            //services.AddScoped<OrderQuerySchema>();
            //services.AddGraphQL()
            //    .AddSystemTextJson()
            //    .AddGraphTypes(typeof(OrderQuerySchema), ServiceLifetime.Scoped);

            #endregion
            return services;
        }

        private static IServiceCollection AddCustomGraphQL(this IServiceCollection services)
        {
            return services;
        }
        public static IServiceCollection AddCustomIntegrations(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IIdentityService, IdentityService>();

            return services;
        }

        public static IServiceCollection AddCustomConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //inject IOptions<T>
            services.AddOptions();

            //inject AppSettings
            services.Configure<ServiceSettings>(configuration);
            return services;
        }
    }
}
