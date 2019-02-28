using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestWithASPNETUdemy.Service;
using RestWithASPNETUdemy.Service.Implementation;
using RestWithASPNETUdemy.Repository;
using RestWithASPNETUdemy.Repository.Implementation;
using RestWithASPNETUdemy.Model.Context;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace RestWithASPNETUdemy {
    public class Startup {
        private readonly ILogger _logger;
        public IConfiguration _configuration { get; }
        public IHostingEnvironment _environment { get; }
        
        public Startup(IConfiguration configuration, IHostingEnvironment environment, ILogger<Startup> logger)
        {
            this._configuration = configuration;
            this._environment = environment;
            this._logger = logger;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connectionString));
            if (this._environment.IsDevelopment()) {
                try {
                    var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection();
                    var evolve = new Evolve.Evolve("evolve.json", evolveConnection, msg => this._logger.LogInformation(msg)) {
                        Locations = new List<string> { "db/migrations" },
                        IsEraseDisabled = true
                    };
                } catch (Exception ex) {
                    this._logger.LogCritical("Database migration failed.", ex);
                    throw ex;
                }
            }
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddApiVersioning();
            //Dependency Injection
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped(typeof(IRepository<>),typeof(GenericRepository<>));
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
