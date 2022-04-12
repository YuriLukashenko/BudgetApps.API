using BudgetApps.API.Helpers;
using BudgetApps.API.Interfaces;
using BudgetApps.API.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Helpers.Builders;
using BudgetApps.API.Services.ArmyArea;
using BudgetApps.API.Services.BetArea;
using BudgetApps.API.Services.CaseArea;
using BudgetApps.API.Services.CreditArea;
using BudgetApps.API.Services.DepositArea;
using BudgetApps.API.Services.EwerArea;
using BudgetApps.API.Services.FluxArea;
using BudgetApps.API.Services.FopArea;
using BudgetApps.API.Services.FundArea;
using BudgetApps.API.Services.LocationArea;
using BudgetApps.API.Services.RefluxArea;
using BudgetApps.API.Services.SalaryArea;
using BudgetApps.API.Services.StackArea;

namespace BudgetApps.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // configure strongly typed settings object
            services.Configure<AppSettings>(_configuration.GetSection("AppSettings"));

            services.AddControllers();
            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BudgetApps.API", Version = "v1" });
            });

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IConnectionService, DbConnectionService>();

            services.AddScoped<FluxService>();
            services.AddScoped<RefluxService>();
            services.AddScoped<SalaryService>();
            services.AddScoped<CaseService>();
            services.AddScoped<BetService>();
            services.AddScoped<EwerService>();
            services.AddScoped<FundService>();
            services.AddScoped<StackService>();
            services.AddScoped<CreditService>();
            services.AddScoped<FopService>();
            services.AddScoped<RateService>();
            services.AddScoped<LocationService>();
            services.AddScoped<ArmyService>();
            services.AddScoped<DepositService>();

            services.AddScoped<CurrentCashService>();
            services.AddScoped<TotalValuesService>();

            services.AddScoped<QueryBuilder>();

            services.AddSingleton<DeltaService>();
            services.AddSingleton<StatisticService>();

            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BudgetApps.API v1"));
            }

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
