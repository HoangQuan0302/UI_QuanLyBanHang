using Blazored.LocalStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Syncfusion.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UI_QuanLyCuaHang.Data;
using UI_QuanLyCuaHang.Services;

namespace UI_QuanLyCuaHang {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            var appSettingSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingSection);

            services.AddScoped<AuthenticationStateProvider, AuthenticationStateUser>();

            services.AddBlazoredLocalStorage();
            services.AddHttpClient<IUserService, UserService>();
            services.AddHttpClient<ICuaHangService, CuaHangService>();
            services.AddHttpClient<IHopDongService, HopDongService>();
            services.AddHttpClient<ISanPhamService, SanPhamService>();
            services.AddHttpClient<ILoaiCuaHangService<LoaiCuaHang>, LoaiCuaHangService<LoaiCuaHang>>();
            services.AddSingleton<HttpClient>();
            services.AddSingleton<WeatherForecastService>();
            services.AddSyncfusionBlazor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDUzNjk5QDMxMzkyZTMxMmUzMFNJQXQra2NtRloydjQxekxRN256ZDF6NU1oZENHem93K0l3TnVzRmExYWM9");
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
