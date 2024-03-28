//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Localization;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;

//namespace YourNamespace
//{
//    public class Startup
//    {
//        // Constructor to initialize configuration
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        // Property to hold the configuration
//        public IConfiguration Configuration { get; }

//        // This method gets called by the runtime. Use this method to add services to the container.
//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.Configure<RequestLocalizationOptions>(options =>
//            {
//                options.DefaultRequestCulture = new RequestCulture("en-US");
//            });

//            // Add services to the container
//            // For example:
//            // services.AddControllers();
//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            // Configure the HTTP request pipeline
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//                app.UseSwagger(c =>
//                {
//                    c.RouteTemplate = "/swagger/{documentName}/swagger.json";
//                });
//                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
//            }
//            else
//            {
//                // In production, use exception handling middleware, error pages, etc.
//                app.UseExceptionHandler("/Error");
//                app.UseHsts();
//            }

//            // Other middleware configurations
//            // For example:
//            // app.UseHttpsRedirection();
//            // app.UseStaticFiles();

//            // Configure routing
//            // For example:
//            // app.UseRouting();

//            // Configure authorization
//            // For example:
//            // app.UseAuthorization();

//            // Configure endpoints
//            // For example:
//            // app.UseEndpoints(endpoints =>
//            // {
//            //     endpoints.MapControllers();
//            // });
//        }
//    }
//}
