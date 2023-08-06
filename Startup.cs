using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Example
{
    public class Startup
    {

        // RegisterValidatorsFromAssemblyContaining Assemply nin içerisindeki bütün validator
        // sınıflarını bul ve gerekli validatorı olan sınıflara bu kütüphanenin uygulanmasını sağla 
        //Yani mimaride uygulmaa sırasında bunu bağlı validatoru olan tüm view modellardaki verilerde  
        //valdasyonları uygula demek oldu
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());
            
        }
         
       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                //endpoints.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");
                
                endpoints.MapDefaultControllerRoute();
                
                endpoints.MapControllerRoute("CustomRoute","{controller=Home}/{action=Index}/{a}/{b}/{id}"); 
            });
        }
    }
}
