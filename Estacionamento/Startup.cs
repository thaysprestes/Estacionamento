using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estacionamento.DAL;
using Estacionamento.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Estacionamento
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
            //Inserir os DAOs
            services.AddScoped<ClienteDAO>();
            services.AddScoped<FuncionarioDAO>();
            services.AddScoped<CarroDAO>();
            services.AddScoped<EstacionamentoDAO>();


            //Definicao do BD e string de conexao
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("Connection")));


            services.AddControllersWithViews();
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Estacionamento}/{action=Index}/{id?}");
            });
        }
    }
}
