using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EstacionamentoCadastro.Business;
using EstacionamentoCadastro.Common;
using EstacionamentoCadastro.Data;
using EstacionamentoCadastro.Modelo.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;
using NLog.Extensions.Logging;
using NToastNotify;

namespace EstacionamentoCadastro
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

            services.AddAutoMapper(typeof(Startup));
            services.AddMvc().AddNToastNotifyToastr(null, new NToastNotifyOption()
            {
                DefaultErrorTitle = "Erro",
                DefaultErrorMessage = "Ocorreu um erro inesperado. Por favor, tente novamente mais tarde.",

                DefaultSuccessTitle = "Sucesso",
                DefaultSuccessMessage = "Operação realizada com sucesso.",

                DefaultWarningTitle = "Atenção"
            });

            services.Configure<Parametros>(Configuration.GetSection("ConnectionStrings"));
            //services.AddTransient<IDataAccessObject<Acao, AcaoFiltro, long>, AcaoData>();
            services.AddTransient<IDbConnection>(sp =>
            {
                var connectionString = sp.GetService<Parametros>().EstacionamentoCadastro;
                return new SqlConnection(connectionString);
            });
            services.AddTransient<CarroData>();
            services.AddTransient<ManobristaData>();
            services.AddTransient<CarroManobradoData>();
            services.AddTransient<CarroBLL>();
            services.AddTransient<ManobristaBLL>();
            services.AddTransient<CarroManobradoBLL>();
            services.AddParametros(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            var cultureInfo = new CultureInfo("pt-BR");

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            //LogManager.Configuration.Variables["connectionString"] = Configuration["ConnectionStrings:EstacionamentoCadastro"];
            loggerFactory.AddNLog();
            var logger = loggerFactory.CreateLogger<Startup>();
            logger.LogInformation($"Iniciando Estacionamento Cadastro\n{JsonConvert.SerializeObject(env, Formatting.Indented)}");

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
            app.UseNToastNotify();
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
        }
    }
}
