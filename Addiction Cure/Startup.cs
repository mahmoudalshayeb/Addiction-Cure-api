using Addiction_Cure.core.Repository;
using Addiction_Cure.core.Service;
using Addiction_Cure.core.Common;
using Addiction_Cure.infra.Repository;
using Addiction_Cure.infra.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stripe;

namespace Addiction_Cure
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
            StripeConfiguration.ApiKey = Configuration.GetSection("Stripe")["sk_test_51MbSgMC5iNj1HcZ7EGz8Kgk3N4aATKeR0W3eOgmGXkWq1hIm0O4HgEgSoscVJcYIo7IukRXMsnHSPxoHisNffuRc00khS1hFeS"];

            services.AddScoped<IDBContext, DBContext>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IPatientRepostory, PatientRepostory>();
            services.AddScoped<IAboutUsRepository, AboutUsRepository>();
            services.AddScoped<IContactUsRepository, ContactUsRepository>();
            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<IHomeRepository, HomeRepository>();

            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IAboutUsService, AboutUsService>();
            services.AddScoped<IContactUsService, ContactUsService>();
            services.AddScoped<IBankService, BankService>();
            services.AddScoped<IHomeService, HomeService>();

            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAddictionsRepository, AddictionsRepository>();
            services.AddScoped<IAddictionService, AddictionService>();
            services.AddScoped<ITestimonialsRepository,TestimonialsRepository>();
            services.AddScoped<ITestimonialsService, TestimonialsService>();

            services.AddScoped<IPaymentRepository,PaymentRepository>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ITestRepository, TestRepository>();
            services.AddScoped<ITestService, TestService>();
            services.AddScoped<IResultTestRepository, ResultTestRepository>();
            services.AddScoped<IResultTestService, ResultTestService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
