namespace MyDigitalCV
{
    using Factories;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Messaging;
    using Models.Web.ViewModels;

    public class Startup
    {
       //private IFactory<PrivacyInformationModel> factory;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAntiforgery();
          
            services.AddRazorPages();
            services.AddTransient<Factories.IFactory<IEnumerable<EducationViewModel>>, EducationFactory>();
            services.AddTransient<Factories.IFactory<IEnumerable<ProfessionalExperienceViewModel>>,ProfessionalExperienceFactory>();
            services.AddTransient<Factories.IFactory<PrivacyInformationViewModel>, PrivacyInformationFactory>();
            services.AddTransient<Factories.IFactory<HomeViewModel>, IndexFactory>();
            services.AddTransient<Factories.IFactory<IEnumerable<ProjectViewModel>>, ProjectFactory>();

            services.AddTransient<IEmailSender>(
                serviceProvider => new SendGridEmailSender(this.Configuration["SendGrid:ApiKey"]));
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();
            
            
            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapRazorPages();
            });
        }
    }
}
