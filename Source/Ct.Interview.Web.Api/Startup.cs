namespace Ct.Interview.Web.Api
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IWebHostEnvironment Env { get; set; }
        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options => {

                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Asx Listed Company API",
                    Description = "Asx Listed Company API",
                });

            });

            services.AddControllers().SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddLogging(builder => {
               
                builder.AddConfiguration(Configuration.GetSection("Logging"));
                builder.AddConsole();
               
            });

            services.AddCors(options =>
            {
                if (this.Env.IsDevelopment())
                {
                    options.AddPolicy("AsxListeCompaniesCorsPolicy", (builder =>
                    {
                        builder
                            .WithOrigins("http://localhost:3000", "https://localhost:3000")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    }));
                }
            });

            services.CtInterviewAddDatabase();
            services.CtInterViewApplicationServiceRegistration();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.MigrateDatabaseAsync();

            app.UseRouting();
            app.UseCors("AsxListeCompaniesCorsPolicy");
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Asx Listed Company API");
            });
        }
    }
}
