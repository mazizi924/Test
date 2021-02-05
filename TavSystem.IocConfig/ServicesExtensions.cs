using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using TavSystem.Framework;
using TavSystem.DataLayer;
using AutoMapper;
using TavSystem.DataLayer.Repositories.Contracts;
using TavSystem.DataLayer.Repositories;
using TavSystem.Services.Contracts;
using TavSystem.Services.Services;

namespace TavSystem.IocConfig
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<SiteSettings>(x => configuration.Bind(x));
            var siteSettings = service.GetSiteSetting();

            service.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<TavsystemDbContext>());
            service.AddEntityFrameworkSqlServer();
            service.AddDbContext<TavsystemDbContext>(o => o.UseSqlServer(siteSettings.connectionStrings.DefaultConnection));
            //https://stackoverflow.com/questions/48443567/adddbcontext-or-adddbcontextpool

            return service;
        }
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.Configure<CookiePolicyOptions>(options =>
            { 
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            service.AddTransient<IAccountingDocumentRepository, AccountingDocumentRepository>();
            service.AddTransient<IInventoryRepository, InventoryRepository>();
            service.AddTransient<IInvitemRepository, InvitemRepository>();
            service.AddTransient<IProductRepository, ProductRepository>(); 


            service.AddTransient<IInventoryService, InventoryService>();
            service.AddTransient<IInvItemService, InvItemService>();
            service.AddTransient<IProductService, ProductService>();
            service.AddTransient<ITest, Test>();
            return service;
        }

        public static SiteSettings GetSiteSetting(this IServiceCollection service)
        {
            var provider = service.BuildServiceProvider();
            var siteSettingsOptions = provider.GetRequiredService<IOptionsSnapshot<SiteSettings>>();
            var siteSettings = siteSettingsOptions.Value;
            if (siteSettings == null) throw new ArgumentNullException(nameof(siteSettings));
            return siteSettings;

        }
        public static IServiceCollection AutoMapperConfiguration(this IServiceCollection service)
        { 
           var mapperConfig = new MapperConfiguration(mc =>
           {
               mc.AddProfile(new MappingProfile());
           }); 
            IMapper mapper = mapperConfig.CreateMapper();
            service.AddSingleton(mapper);
            return service;
        }
    }
}
