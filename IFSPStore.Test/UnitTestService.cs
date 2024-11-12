using Microsoft.Extensions.DependencyInjection;
using IFSPStore.Repository.Context;
using Microsoft.EntityFrameworkCore;
using IFSPStore.Domain.Base;
using IFSPStore.Domain.Entities;
using IFSPStore.Service.Services;
using AutoMapper;

namespace IFSPStore.Test
{
    [TestClass]
    public class UnitTestService
    {
        private ServiceCollection? services;
        public ServiceProvider ConfigureServices()
        {
            services = new ServiceCollection();
            services.AddDbContext<MySqlContext>(options =>
            {
                var server = "localhost";
                var port = "3306";
                var database = "IFSPStore";
                var username = "root";
                var password = "admin";
                var strCon = $"Server={server};Port={port};Database={database};Uid={username};Pwd={password}";
                options.UseMySql(strCon, ServerVersion.AutoDetect(strCon), opt =>
                {
                    opt.CommandTimeout(180);
                    opt.EnableRetryOnFailure(5);
                });
            });

            services.AddScoped<IBaseRepository<Usuario>, IBaseRepository<Usuario>>();
            services.AddScoped<IBaseService<Usuario>, BaseService<Usuario>>();
            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<Usuario, Usuario>();
            }).CreateMapper());
            return services.BuildServiceProvider();
        }
    }
}
