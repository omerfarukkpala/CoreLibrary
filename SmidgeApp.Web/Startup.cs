using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Smidge;
using Smidge.Options;
using Smidge.Cache;

namespace SmidgeApp.Web
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
            services.AddSmidge(Configuration.GetSection("smidge"));

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSmidge(bundle =>
            {
                bundle.CreateJs("my-js-bundle", "~/js/").WithEnvironmentOptions(BundleEnvironmentOptions.Create().ForDebug(builder => builder.EnableCompositeProcessing().EnableFileWatcher().SetCacheBusterType<AppDomainLifetimeCacheBuster>().CacheControlOptions(enableEtag: false, cacheControlMaxAge: 0)).Build()); // B� koda
                bundle.CreateCss("my-css-bundle", "~/css/site.css", "~/lib/bootstrap/dist/css/bootstrap.css");
            }); // Burda olmas� �nemli

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

/*
 * bundle.CreateJs("my-js-bundle", "~/js/"): CreateJs metodu, my-js-bundle ad�nda bir JavaScript paketi olu�turur. Bu paket, ~/js/ dizininde bulunan JavaScript dosyalar�n� i�erecek.

.WithEnvironmentOptions(...): WithEnvironmentOptions metodu, paketin derleme ortam�yla ilgili se�enekleri belirtmek i�in kullan�l�r. Devam�nda gelen kod blo�u, derleme ortam� se�eneklerini yap�land�r�r.

BundleEnvironmentOptions.Create(): BundleEnvironmentOptions s�n�f�n�n Create statik metodu, bir derleme ortam� yap�land�rmas� olu�turur.

.ForDebug(...): Bu y�ntem, derleme ortam�n� hata ay�klama (debug) modunda yap�land�rmak i�in kullan�l�r. ��ine gelen kod blo�u, hata ay�klama modu i�in �zel se�enekleri yap�land�r�r.

builder => builder.EnableCompositeProcessing().EnableFileWatcher().SetCacheBusterType<AppDomainLifetimeCacheBuster>().CacheControlOptions(enableEtag: false, cacheControlMaxAge: 0): Bu kod blo�u, hata ay�klama modunda yap�land�rma i�in kullan�lan se�enekleri belirtir.

EnableCompositeProcessing(): Bu se�enek, JavaScript dosyalar�n� birle�tirme i�lemini etkinle�tirir. Yani, birden fazla dosyay� tek bir dosya haline getirir.
EnableFileWatcher(): Bu se�enek, dosya izleme �zelli�ini etkinle�tirir. Yani, kaynak dosyalarda yap�lan de�i�iklikleri alg�layarak otomatik olarak paketin g�ncellenmesini sa�lar.
SetCacheBusterType<AppDomainLifetimeCacheBuster>(): Bu se�enek, �nbelle�i temizlemek i�in kullan�lan bir "cache buster" stratejisi belirtir. Burada AppDomainLifetimeCacheBuster kullan�l�yor, yani uygulama etki alan� �mr� boyunca �nbelle�i temizlemek i�in bir y�ntem kullan�l�yor.
CacheControlOptions(enableEtag: false, cacheControlMaxAge: 0): Bu se�enek, Cache-Control ba�l���n� yap�land�rmak i�in kullan�l�r. enableEtag: false ile etag �zelli�inin devre d��� b�rak�ld���n�, cacheControlMaxAge: 0 ile de �nbellek s�resinin s�f�r (an�nda s�resi dolmu�) oldu�unu belirtir.
.Build(): Bu y�ntem, yap�land�r�lm�� derleme ortam� se�eneklerini kullanarak bir derleme ortam� nesnesi olu�turur.*/
