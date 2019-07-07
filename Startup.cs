using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using Microsoft.IdentityModel.Tokens;
using PtcApi.Model;

namespace PtcAPi {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            //Get JWT settings from jwtsettings json file
            JwtSettings settings = GetJwtSettings ();
            //Create singleton of Jwt setting - can be accessed by SecurityControoler by D-Injection
            services.AddSingleton<JwtSettings> (settings);
            //reginster Jwt as the authentication service
            services.AddAuthentication (options => {
                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";
                })
                .AddJwtBearer ("JwtBearer", JwtBearerOptions => {
                    JwtBearerOptions.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey (Encoding.UTF8.GetBytes (settings.Key)),
                    ValidateIssuer = true,
                    ValidIssuer = settings.Issuer,
                    ValidAudience = settings.Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes (settings.MinutesToExpiration)
                    };
                });

            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_2);
            services.AddCors ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts ();
            }

            app.UseHttpsRedirection ();

            // app.UseCors(
            //         options => options.WithOrigins(
            //           "http://localhost:4200").AllowAnyMethod().AllowAnyHeader()
            //       );

            app.UseAuthentication ();

            app.UseMvc ();
        }

        public JwtSettings GetJwtSettings () {
            JwtSettings settings = new JwtSettings ();
            settings.Key = Configuration["JwtSettings:key"];
            settings.Issuer = Configuration["JwtSettings:issuer"];
            settings.Audience = Configuration["JwtSettings:audience"];
            settings.MinutesToExpiration = Convert.ToInt32 (Configuration["JwtSettings:minutesToExpiration"]);

            return settings;
        }
    }
}