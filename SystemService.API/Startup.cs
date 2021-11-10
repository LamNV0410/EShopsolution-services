using CLSK12.BaseService.Services.IdentityService;
using EshopSolution.Extensions;
using EshopSolution.Extensions.Services.IdentityService;
using GraphiQl;
using GraphQL.Server.Ui.Playground;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Steeltoe.Discovery.Client;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using SystemService.Domain.IQueries;
using SystemService.Domain.IRepositories;
using SystemService.Infrastructure.DBContext;
using SystemService.Infrastructure.Queries;
using SystemService.Infrastructure.Repositoies;

namespace SystemService.API
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
            services.AddCustomDbContext(Configuration);
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            var audienceConfig = Configuration.GetSection("Audience");

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(audienceConfig["Secret"]));
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidIssuer = audienceConfig["Iss"],
                ValidateAudience = true,
                ValidAudience = audienceConfig["Aud"],
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true,
            };

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = ServiceSettings.AuthenticateScheme; //
            })
            .AddJwtBearer(ServiceSettings.AuthenticateScheme, x =>
            {
                x.RequireHttpsMetadata = false;
                x.TokenValidationParameters = tokenValidationParameters;
            });

            services.AddControllers()
                .AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            services.AddCustomSwagger();

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
            app.UseGraphiQl("/graphql");
            app.UseRouting();
            app.UseCors("MyPolicy");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());
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
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IIdentityService, IdentityService>();
            #region REPOSITORIES
            #region User
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion
            #region UserType
            services.AddScoped<IUserTypeRepository, UserTypeRepository>();
            #endregion

            #region Product

            #endregion
            #endregion

            #region QUERIES
            services.AddScoped<IUserQueries>(s => new UsersQueries(configuration["ConnectionStrings:DefaultConnection"]));
            services.AddScoped<IUserTypeQueries>(s => new UserTypeQueries(configuration["ConnectionStrings:DefaultConnection"]));
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

        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<SystemDBContext>(options =>
                {
                    options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"],
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    });
                }
            );

            return services;
        }
    }
}
