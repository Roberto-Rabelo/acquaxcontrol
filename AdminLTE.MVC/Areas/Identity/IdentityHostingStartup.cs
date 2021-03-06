using System;
using AdminLTE.MVC.Areas.Admin.Repositories;
using AdminLTE.MVC.Data;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AdminLTE.MVC.Areas.Identity.IdentityHostingStartup))]
namespace AdminLTE.MVC.Areas.Identity
{
public class IdentityHostingStartup : IHostingStartup
{  public void Configure(IWebHostBuilder builder)
  {
        builder.ConfigureServices((context, services) => {
            services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

         


            services.AddTransient<ICondominio, CondominioRepository>();
            services.AddTransient<IBloco, BlocoRepository>();
        });
   }
}
}