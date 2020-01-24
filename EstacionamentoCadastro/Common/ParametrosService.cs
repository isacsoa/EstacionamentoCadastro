using EstacionamentoCadastro.Modelo.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamentoCadastro.Common
{
    public class ParametrosService
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<ParametrosService> logger;

        public ParametrosService(IConfiguration configuration, ILogger<ParametrosService> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }

        public Parametros ObterParametros()
        {
            try
            {
                Parametros parametros = new Parametros()
                {
                    EstacionamentoCadastro = configuration.GetSection("ConnectionStrings").GetValue<string>("EstacionamentoCadastro")
                };

                return parametros;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }

    public static class ParametrosServiceExtensions
    {
        public static void AddParametros(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ParametrosService>();
            services.AddTransient(sp =>
            {
                var paramService = sp.GetService<ParametrosService>();
                return paramService.ObterParametros();
            });
        }
    }
}
