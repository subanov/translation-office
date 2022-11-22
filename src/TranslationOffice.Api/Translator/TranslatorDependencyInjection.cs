using TranslationOffice.Application;
using TranslationOffice.Domain;

namespace TranslationOffice.Api;

internal static class TranslatorDependencyInjection
{
    internal static IServiceCollection AddTranslatorDependencies(this IServiceCollection services)
    {
        services.AddScoped<ITranslatorInsertDataCommand, TranslatorEfInsertDataCommand>();
        services.AddScoped<ITranslatorRepository, TranslatorEfRepository>();
        
        services.AddScoped<ITranslatorAddCommand, TranslatorAddCommand>();
        return services;
    }
}