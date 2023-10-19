namespace Ct.Interview.Infrastructure.Data.ServiceCollection
{
    public static class DependencyInjection
    {
        public static IServiceCollection CtInterviewAddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<ASXListedCompaniesContext>(opt => opt.UseInMemoryDatabase( databaseName: "ASXListedCompaniesDb"));
            services.AddScoped<ASXListedCompaniesContext>();
            services.AddTransient< ListedCompanySeeder>();

            services.AddTransient<IListedCompanyRepository, ListedCompanyRepository>();

            return services;
        }

        public static IApplicationBuilder MigrateDatabaseAsync(this IApplicationBuilder app)
        {
            using(var scope = app.ApplicationServices.CreateScope())
            {
                var seed = scope.ServiceProvider.GetRequiredService<ListedCompanySeeder>();
                seed.ConfigureDatabase().Wait();

                return app;
            }
        }
    }
}
