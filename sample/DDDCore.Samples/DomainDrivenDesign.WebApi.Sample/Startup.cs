using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainDrivenDesign.Application.Sample.Command;
using DomainDrivenDesign.Application.Sample.EventHandler;
using DomainDrivenDesign.Core.CQRS;
using DomainDrivenDesign.Core.CQRS.Command;
using DomainDrivenDesign.Core.CQRS.Interface;
using DomainDrivenDesign.Core.Events;
using DomainDrivenDesign.Domain.Sample.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace DomainDrivenDesign.WebApi.Sample
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
            services.AddControllers();
            
            // Inject Mediator
            services.AddScoped<IMediatorCQRS, MediatorCQRS>();

            // Inject Command Handlers
            services.AddScoped<ICommandHandler<ProcessCardPaymentCommand>, ProcessCardPaymentCommandHandler>();

            // Inject Event handlers
            services.AddScoped<IEventHandler<PaymentCreated>, PaymentCreatedEventHandler>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DDD Core", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "DDD Core");
            });
        }
    }
}

