using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateLimit.API
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
            services.AddOptions();

            services.AddMemoryCache();

            //services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting")); // Bu kod, IpRateLimitOptions s�n�f�n�n yap�land�rma b�l�m�n� ("IpRateLimiting") kullanarak IP s�n�rlama se�eneklerini yap�land�r�r. Yap�land�rma dosyas�nda belirli bir b�l�m ad� alt�nda tan�mlanan IP s�n�rlama ayarlar�, bu se�eneklere yans�t�l�r.
            services.Configure<ClientRateLimitOptions>(Configuration.GetSection("ClientRateLimiting"));

            //services.Configure<IpRateLimitPolicies>(Configuration.GetSection("IpRateLimitPolicies")); // Bu kod, IpRateLimitPolicies s�n�f�n�n yap�land�rma b�l�m�n� ("IpRateLimitPolicies") kullanarak IP s�n�rlama politikalar�n� yap�land�r�r. Yap�land�rma dosyas�nda belirli bir b�l�m ad� alt�nda tan�mlanan IP s�n�rlama politikalar�, bu yap�land�rmaya yans�t�l�r. 
            services.Configure<ClientRateLimitPolicies>(Configuration.GetSection("ClientRateLimitPolicies"));

            //services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>(); // Bu kod, IIpPolicyStore arabirimini MemoryCacheIpPolicyStore s�n�f�na ba��ml�l�k olarak kaydeder. IIpPolicyStore, IP s�n�rlama politikalar�n� saklamak ve y�netmek i�in kullan�lan bir arabirimdir. Bu durumda, bellek tabanl� depolama kullan�larak IP s�n�rlama politikalar� saklan�r.
            services.AddSingleton<IClientPolicyStore, MemoryCacheClientPolicyStore>();

            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>(); // Bu kod, IRateLimitCounterStore arabirimini MemoryCacheRateLimitCounterStore s�n�f�na ba��ml�l�k olarak kaydeder. IRateLimitCounterStore, IP s�n�rlama saya�lar�n� saklamak ve y�netmek i�in kullan�lan bir arabirimdir. Bu durumda, bellek tabanl� depolama kullan�larak IP s�n�rlama saya�lar� saklan�r.

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); // Bu kod, IHttpContextAccessor arabirimini HttpContextAccessor s�n�f�na ba��ml�l�k olarak kaydeder. IHttpContextAccessor, HTTP istekleri ve yan�tlar�yla ilgili bilgilere eri�mek i�in kullan�l�r. Bu ba��ml�l�k, IP s�n�rlama i�lemleri s�ras�nda mevcut HTTP iste�inin bilgisine eri�mek i�in kullan�l�r.

            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseIpRateLimiting(); // Bu yukarda yazd�klar�m� kullanarak bir IP k�s�tlamas� ekleyecek.
            app.UseClientRateLimiting();

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
