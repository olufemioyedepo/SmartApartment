using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using SmartApartment.Application;
using SmartApartment.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartApartment.Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // we are telling EF Core to get the connection string from DefaultConnection node of aspsettings.json file.
            // And the appsettings.json file should be searched in the assembly called “WebApi”. This also means our Web API project should be named as “WebApi”.
            //services.AddDbContext<AppDbContext>(options =>
            //    options.UseSqlServer(
            //        configuration.GetConnectionString("DefaultConnection"),
            //        b => b.MigrationsAssembly("WebApi")));

            string mySqlConnectionStr = configuration.GetConnectionString("DefaultConnection");
            try
            {
                services.AddDbContextPool<AppDbContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr), b => b.MigrationsAssembly("SmartApartment.NetCoreApp.Api")));
            }
            catch (Exception ex)
            {
                Log.Error(Utility.ErrorLog(ex));
                throw ex;
            }


            services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());
        }
    }
}
