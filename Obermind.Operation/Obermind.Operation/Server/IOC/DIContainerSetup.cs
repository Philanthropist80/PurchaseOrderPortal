using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Obermind.Operation.Business.Contract.Security;
using Obermind.Operation.Data.Access.DAL;
using Obermind.Operation.Data.Access.DAL.Agreements;
using Obermind.Operation.Data.Access.DAL.Contracts;
using Obermind.Operation.Security.Auth;
using Obermind.Operation.Security.Contracts;
using Obermind.Operation.Server.Filters;
using Obermind.Operation.Server.Helpers;
using Obermind.Operation.Server.Mapping.Agreements;
using Obermind.Operation.Server.Mapping.Contracts;

namespace Obermind.Operation.Server.IOC
{
    public static class DIContainerSetup
    {
        public static void Setup(IServiceCollection services, IConfiguration configuration)
        {
            AddRepositories(services, configuration);
            AddBusinessManagers(services);
            ConfigureAutoMapper(services);
            ConfigureAuth(services);
            
        }

        private static void ConfigureAuth(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ITokenBuilder, TokenBuilder>();
            services.AddScoped<ISecurityContract, Business.Manager.Security.SecurityManager>();
        }

        private static void ConfigureAutoMapper(IServiceCollection services)
        {
            var mapperConfig = AutoMapperConfigurator.Configure();
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(x => mapper);
            services.AddTransient<IAutoMapper, AutoMapperManager>();
        }

        private static void AddRepositories(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:ObermindDB"];
            //Console.WriteLine(connectionString);
            //services.AddEntityFrameworkSqlServer();

            services.AddDbContext<ObermindDBContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IUnitOfWork>(ctx => new UnitOfWork(ctx.GetRequiredService<ObermindDBContext>()));

            services.AddScoped<IActionTransactionHelper, ActionTransactionHelper>();
            services.AddScoped<UnitOfWorkFilterAttribute>();
        }

        private static void AddBusinessManagers(IServiceCollection services)
        {
            Assembly managerContractAssembly = Assembly.Load("Obermind.Operation.Business.Contract");

            var managerContractInterfaces = from t in managerContractAssembly.DefinedTypes
                where t.IsInterface
                select t;

            Assembly managerContractImplementationAssembly = Assembly.Load("Obermind.Operation.Business.Manager");

            foreach (var type in managerContractInterfaces)
            {
                var managerContractInterfaceImplementations = (from t in managerContractImplementationAssembly.DefinedTypes
                    where t.GetInterface(type.Name) != null && !t.IsAbstract && t.IsClass
                    select t);
                if (managerContractInterfaceImplementations.Count() > 0)
                {
                    foreach (var implementation in managerContractInterfaceImplementations)
                    {
                        services.AddScoped(type, implementation);
                    }
                    
                }
                    
            }
        }
    }
}
