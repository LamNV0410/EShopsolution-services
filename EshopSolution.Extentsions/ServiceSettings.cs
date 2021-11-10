namespace EshopSolution.Extensions
{
    /// <summary>
    ///
    /// </summary>
    public class ServiceSettings
    {
        public const string AuthenticateScheme = "ESHOP";
        public string SubscriptionClientName { get; set; }
        public AudienceSettings Audience { get; set; }

        public EventBusSettings EventBus { get; set; }
        public EurekaSettings Eureka { get; set; }
        public SpringSettings Spring { get; set; }

        public class AudienceSettings
        {
            public string Secret { get; set; }
            public string Iss { get; set; }
            public string Aud { get; set; }
        }

        public class EventBusSettings
        {
            public int EventBusRetryCount { get; set; }
            public string EventBusUserName { get; set; }
            public string EventBusPassword { get; set; }
            public string EventBusConnection { get; set; }
        }

        public class SpringSettings
        {
            public ApplicationSettings Application { get; set; }

            public class ApplicationSettings
            {
                public string Name { get; set; }
            }
        }

        public class EurekaSettings
        {
            public ClientSettings Client { get; set; }
            public class ClientSettings
            {
                public string ServiceUrl { get; set; }
                public bool ShouldFetchRegistry { get; set; }
                public bool ShouldRegisterWithEureka { get; set; }
                public bool ValidateCertificates { get; set; }

            }
        }
    }
}
