using Microsoft.BuildingBlocks.EventBusRabbitMQ;
using Microsoft.BuildingBlocks.IntegrationEventLogEF.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace EshopSolution.Extensions.Extensions
{
    public static class CustomEventbusExtention
    {
        public static IServiceCollection AddCustomEventBus(this IServiceCollection services, MicroSettings configuration)
        {

            services.AddTransient<Func<DbConnection, IIntegrationEventLogService>>(sp => (DbConnection c) => new IntegrationEventLogService(c));

            //services.AddTransient<IServiceIntegrationEventService, LessonServiceIntegrationEventService>();

            services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();


                var factory = new ConnectionFactory()
                {
                    HostName = configuration.EventBus.EventBusConnection
                };

                if (!string.IsNullOrEmpty(configuration.EventBus.EventBusUserName))
                {
                    factory.UserName = configuration.EventBus.EventBusUserName;
                }

                if (!string.IsNullOrEmpty(configuration.EventBus.EventBusPassword))
                {
                    factory.Password = configuration.EventBus.EventBusPassword;
                }

                factory.AutomaticRecoveryEnabled = true;

                var retryCount = configuration.EventBus.EventBusRetryCount;

                return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
            });

            var subscriptionClientName = configuration.SubscriptionClientName;

            services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
            {
                var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                var retryCount = configuration.EventBus.EventBusRetryCount;

                return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, iLifetimeScope, eventBusSubcriptionsManager, subscriptionClientName, retryCount);
            });

            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();
            return services;
        }
    }
}
