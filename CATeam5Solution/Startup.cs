using CATeam5Solution.Method;
using CATeam5Solution.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CATeam5Solution
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
            services.AddControllersWithViews();

            services.AddDbContext<DBContext>(opt =>
            opt.UseLazyLoadingProxies().UseSqlServer(
            Configuration.GetConnectionString("db_conn"))
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //[FromServices]DBContext dbContext
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            [FromServices] DBContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
        
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            if (!dbContext.Database.CanConnect())
            {
                dbContext.Database.EnsureCreated();
            }
            DB db = new DB(dbContext);
            TestSeedOnly ts = new TestSeedOnly(dbContext);

            db.Seed();
            ts.MakeOrders();
        }         
    }
    
}
