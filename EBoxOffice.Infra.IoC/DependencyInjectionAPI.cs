using EBoxOffice.Application.Interfaces;
using EBoxOffice.Application.Mappings;
using EBoxOffice.Application.Services;
using EBoxOffice.Domain.Account;
using EBoxOffice.Domain.Interfaces;
using EBoxOffice.Infra.Data.Context;
using EBoxOffice.Infra.Data.Identity;
using EBoxOffice.Infra.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EBoxOffice.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();

            services.AddScoped<IEventService, EventService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITicketService, TicketService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myHandlers = AppDomain.CurrentDomain.Load("EBoxOffice.Application");
            services.AddMediatR(myHandlers);

            return services;
        }
    }
}
