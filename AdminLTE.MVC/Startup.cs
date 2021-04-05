using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using AdminLTE.MVC.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

using AdminLTE.MVC.Areas.Admin.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Localization;
using System;

namespace AdminLTE.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string CorsPolicy = "_CorsPolicy";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));


            //services.AddHsts(options =>
            //{
            //    options.Preload = true;
            //    options.IncludeSubDomains = true;
            //    options.MaxAge = TimeSpan.FromDays(60);
            //    options.ExcludedHosts.Add("acquaxcontrol.com.br");
            //    options.ExcludedHosts.Add("www.acquaxcontrol.com.br");
            //});



            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {

                        builder.WithOrigins("https://localhost:44342/",
                                            "https://acquaxsuperpredio.com.br/");
                    });

                options.AddPolicy("AnotherPolicy",
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:44342/", "https://acquaxsuperpredio.com.br/")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    }); ;



                services.AddTransient<ICondominio, CondominioRepository>();
                services.AddTransient<IBloco, BlocoRepository>();

                //services.Configure<StorageConfig>(Configuration.GetSection("StorageConfig"));
                services.AddSingleton<IConfiguration>(Configuration);
                services.AddControllersWithViews();
                services.AddRazorPages();
                services.AddMvc(o =>
                {
                    //Add Authentication to all Controllers by default.
                    var policy = new AuthorizationPolicyBuilder()
                                        .RequireAuthenticatedUser()
                            .Build();
                    o.Filters.Add(new AuthorizeFilter(policy));
                });
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRequestLocalization(new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture("pt-BR")
            });

            app.UseRouting();
            app.UseCors(policy => policy.WithHeaders(HeaderNames.CacheControl));

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // routes.MapRoute("areaRoute", "{area:exists}/{Controller=Admin}/{Action=Index}{id?}");

                endpoints.MapControllerRoute(
                   name: "AdminArea",
                   pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
