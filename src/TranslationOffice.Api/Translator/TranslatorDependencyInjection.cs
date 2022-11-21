using TranslationOffice.Application;
using TranslationOffice.Domain;

namespace TranslationOffice.Api;

internal static class TranslatorDependencyInjection
{
    internal static IServiceCollection AddTranslatorDependencies(this IServiceCollection services)
    {
        services.AddScoped<ITranslatorInsertDataCommand, TranslatorInsertDbContextDataCommand>();
        services.AddScoped<ITranslatorAddCommand, TranslatorAddCommand>();
        return services;
    }
}