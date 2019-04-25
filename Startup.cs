using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CheckIT.API.Data;
using CheckIT.API.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace CheckIT.API
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
            bool useSQLServer = bool.Parse(Configuration.GetSection("AppSettings:UseSQLServer").Value);

            if (useSQLServer)
            {
                if(Environment.MachineName == "QUINN-PC")
                {
                    services.AddDbContext<DataContext>(x => x.UseSqlServer(Configuration.GetConnectionString("SQLServerConnectionLocal")));
                }
                else
                {
                    services.AddDbContext<DataContext>(x => x.UseSqlServer(Configuration.GetConnectionString("SQLServerConnection")));
                }
            }
            else
            {
                services.AddDbContext<DataContext>(x => x.UseSqlite(Configuration.GetConnectionString("LocalSQLite")));
            }

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                // this adds JSON Security
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

                services.AddCors();
                services.AddAutoMapper();
                services.AddScoped<AuthRepository>();
                services.AddScoped<InvoiceRepository>();
                services.AddScoped<CustRepository>();
                services.AddScoped<AddressRepository>();
                services.AddScoped<InventoryRepository>();
                services.AddScoped<LocRepository>();
                services.AddScoped<AlertRepository>();
                services.AddScoped<MockRepository>();
                services.AddScoped<QuickRepository>();
                //setup the use of token
                services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    });

            services.AddAuthentication(sharedOptions => { })
                .AddCookie()
                .AddOpenIdConnect("QuickBooks", "QuickBooks", openIdConnectOptions =>
                {
                    openIdConnectOptions.Authority = "QuickBooks";
                    openIdConnectOptions.UseTokenLifetime = true;
                    openIdConnectOptions.ClientId = "L0DmejFFXUqcTekLnCsfYPhMOelKJ4NajoabbbEVsQZZXLtZ1C";
                    openIdConnectOptions.ClientSecret = "2fIgJ5b2SG4YJLgklJYfjZe2kKVvY7lhLtRyMEKI";
                    openIdConnectOptions.ResponseType = OpenIdConnectResponseType.Code;
                    openIdConnectOptions.MetadataAddress = "https://developer.api.intuit.com/.well-known/openid_sandbox_configuration/";    //development path
                    openIdConnectOptions.ProtocolValidator.RequireNonce = false;
                    openIdConnectOptions.SaveTokens = true;
                    openIdConnectOptions.GetClaimsFromUserInfoEndpoint = true;
                    openIdConnectOptions.Scope.Add("openid");
                    openIdConnectOptions.Scope.Add("phone");
                    openIdConnectOptions.Scope.Add("email");
                    openIdConnectOptions.Scope.Add("address");
                    openIdConnectOptions.Scope.Add("com.intuit.quickbooks.accounting");
                    openIdConnectOptions.Scope.Add("com.intuit.quickbooks.payment");
                });
        }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // This sends any *throw* to the webpage for easier debugging.
                app.UseExceptionHandler(builder => {
                    builder.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        var error = context.Features.Get<IExceptionHandlerFeature>();

                        if (error != null)
                        {
                            // adds more info to error headers
                            context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    });
                });
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                // app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            //tell asp.net core to use our token
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
