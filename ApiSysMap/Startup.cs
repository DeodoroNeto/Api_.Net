using ApiSysMap.Data;
using ApiSysMap.Models;
using ApiSysMap.Repository;
using ApiSysMap.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSysMap
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // this method gets called by the runtime.use this method to add services to the container.
        public class UserReposity<TContext> : IUserReposity where TContext : DbContext
        {
            protected DbContext dbContext;
            public UserReposity(TContext context)
            {
                dbContext = context;
            }

            public Task<UserModels> Add(UserModels user)
            {
                throw new NotImplementedException();
            }

            public async Task<int> CreateAsync<T>(T entity) where T : class
            {
                this.dbContext.Set<T>().Add(entity);
                return await this.dbContext.SaveChangesAsync();
            }

            public Task<bool> Delete(int id)
            {
                throw new NotImplementedException();
            }

            public Task<List<UserModels>> GetAllUser()
            {
                throw new NotImplementedException();
            }

            public Task<UserModels> GetUserId(int id)
            {
                throw new NotImplementedException();
            }

            public Task<UserModels> Update(UserModels user, int id)
            {
                throw new NotImplementedException();
            }
        }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiSysMap", Version = "v1" });
            });
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<SystemSalesDBContex>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DataBase"))
                );
            services.AddScoped<IUserReposity, UserReposity<SystemSalesDBContex>>();  
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiSysMap v1"));
            }

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
