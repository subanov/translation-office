using HotChocolate.Types.Descriptors;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TranslationOffice.Application.Data;

namespace TranslationOffice.Api;

public static class ObjectFieldDescriptorExtensions
{
    public static IObjectFieldDescriptor UseDbContext<TDbContext>(
        this IObjectFieldDescriptor descriptor)
        where TDbContext : DbContext
    {
        return descriptor.UseScopedService(
            create: s => s.GetRequiredService<IDbContextFactory<TDbContext>>().CreateDbContext(),
            disposeAsync: (_, c) => c.DisposeAsync());
    }
}

public class UseTranslationOfficeDbContextAttribute : ObjectFieldDescriptorAttribute
{
    public override void OnConfigure(
        IDescriptorContext context,
        IObjectFieldDescriptor descriptor,
        MemberInfo member)
    {
        descriptor.UseDbContext<TranslationOfficeDbContext>();
    }
}
