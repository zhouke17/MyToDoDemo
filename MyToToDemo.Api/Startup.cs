using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MyToToDemo.Api.Context;
using MyToToDemo.Api.Context.Repository;
using MyToToDemo.Api.Context.UnitOfWork;
using MyToToDemo.Api.Entities;
using MyToToDemo.Api.Helper;
using MyToToDemo.Api.Services;

namespace MyToToDemo.Api
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
            services.AddDbContext<MyDbContext>(option =>
            {
                string connStr = Configuration.GetConnectionString("DbConnectString");
                option.UseSqlite(connStr);
            })
            //添加第三方库UnitOfWork仓库服务
            .AddUnitOfWork<MyDbContext>()
            .AddCustomRepository<ToDo, TodoRepository>()
            .AddCustomRepository<Memo, MemoRepository>()
            .AddCustomRepository<User, UserRepository>();
            
            //添加各个接口所需服务
            services.AddTransient<ITodoService, TodoService>();
            services.AddTransient<IMemoService, MemoService>();
            services.AddTransient<IUserService , UserService>();

            var autoMapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MyTodoMappingProfile());
            });
            services.AddSingleton(autoMapper.CreateMapper());
            

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyToToDemo.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyToToDemo.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
