using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LoginExample.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SEP3_Tier1.Data;
using Syncfusion.Blazor;

namespace SEP3_Tier1
{
    public class Startup
    {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<ISaleService, SaleService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            services.AddSyncfusionBlazor();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("MustBeAdmin", a =>
                    a.RequireAuthenticatedUser().RequireClaim("Role", "Admin"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzYwNTUyQDMxMzgyZTMzMmUzMEIxV1g4TnVCRGRtNjdOODg3TGVGVWFQVzl2RWRmRGp4ZU5CUVYzZitLUGs9;MzYwNTUzQDMxMzgyZTMzMmUzMEVPZW9Ja3FiSzBLcHU2RjFUOGxwb2pqd3FMWTFUbmM1QThSR20xdUtoS2c9;MzYwNTU0QDMxMzgyZTMzMmUzMG9vRTV3ODFWVkJpVWtpSVdCaXJGSGRORXpYOHRMejZIb1hzWDdRb2JIaDA9;MzYwNTU1QDMxMzgyZTMzMmUzMGV6SVR3S0M3TndJOW9DVUsvN3l0V2gvbStSOU42Q0RjNzlPVXNFaHVSQVk9;MzYwNTU2QDMxMzgyZTMzMmUzMG5OUnRFSTZ0WFdWM3JsWE53Q2ZudlRJTGpYRWY5RytLb2xJQ25sT1pvNms9;MzYwNTU3QDMxMzgyZTMzMmUzMFlCUXBqY1FzOWJ0bjJhWW00VlV6TDVBT1poZU0rbjd5eEFOQzZrSGlQL0E9;MzYwNTU4QDMxMzgyZTMzMmUzMGNBWWtuNlZhYURlMGlIbk5SZGlFZldiYzhrbTRyL21vR1JzZXRrUlQ3akE9;MzYwNTU5QDMxMzgyZTMzMmUzMG9HaGIyYTBuZXdRdFZZaEN1WFFwK216QngwSXBvSFVuTTNzbnR3V3h4L2M9;MzYwNTYwQDMxMzgyZTMzMmUzMEtzRk5UeUlKK1lMNmxkVEpzSThjd3dRNFlOK1lScit1WWtlcTAwY0hpVm89;MzYwNTYxQDMxMzgyZTMzMmUzMEt6dDRzbVB1Q2RBN3pPUUx4dytsa1NHWGFUVHptKzBKWDhYVW82ckluZmc9");
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

            app.UseEndpoints(endpoints => {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}