namespace Ct.Interview.Application.ServiceRegistration
{
    public static class DependencyInjection
    {
        private static IServiceCollection CtInterviewAddMappingProfile(
            this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mapperConfig => mapperConfig.AddProfile(new MappingProfile()));

            services.AddTransient<IMapper>(x => mapperConfig.CreateMapper());

            return services;
        }

        private static IServiceCollection CtInterviewRegisterAppServices(this IServiceCollection services)
        {
            services.AddTransient<IAsxListedCompaniesService, AsxListedCompaniesService>();

            return services;
        }

        public static IServiceCollection CtInterViewApplicationServiceRegistration(this IServiceCollection services)
        {
            services.CtInterviewAddMappingProfile();
            services.CtInterviewRegisterAppServices(); 

            return services;
        }
    }
}
