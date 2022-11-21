using HotChocolate.Execution.Configuration;
using TranslationOffice.Domain;

namespace TranslationOffice.Api;

internal static class TranslatorGraphQLExtensions
{
    internal static IRequestExecutorBuilder AddTranslatorGraphQL(this IRequestExecutorBuilder builder)
    {
        builder
            .BindRuntimeType<TranslatorIdentity, UuidType>()
            .AddTypeConverter<TranslatorIdentity, Guid>(ti => ti.Value)
            .AddTypeConverter<Guid, TranslatorIdentity>(v => new TranslatorIdentity(v));
        
        builder.AddQueryType<TranslatorQuery>();
        builder.AddMutationType<TranslatorMutations>();
        return builder;
    }
}