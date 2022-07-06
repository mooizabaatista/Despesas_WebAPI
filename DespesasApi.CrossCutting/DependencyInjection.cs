using DespesasApi.Application.Interfaces;
using DespesasApi.Application.Services;
using DespesasApi.Application.Validators;
using DespesasApi.Domain.Entities;
using DespesasApi.Domain.Interfaces;
using DespesasApi.Infra.Context;
using DespesasApi.Infra.Repositories;
using DespesasApi.UnitOfWork;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DespesasApi.CrossCutting
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterApps(IServiceCollection services)
        {
            //Context
            services.AddDbContext<ApplicationDbContext>();

            //Repositories
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ILancamentoRepository, LancamentoRepository>();

            //Services
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<ILancamentoService, LancamentoService>();

            //UnitOfWork
            services.AddScoped<IUoW, UoW>();

            //Fluent validation
            services.AddScoped<IValidator<Categoria>, CategoriaValidator>();
            services.AddScoped<IValidator<Lancamento>, LancamentoValidator>();

            return services;
        }
    }
}
