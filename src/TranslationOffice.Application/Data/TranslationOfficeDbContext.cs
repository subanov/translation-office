using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TranslationOffice.Domain;
#pragma warning disable CS8618

namespace TranslationOffice.Application.Data;

public sealed class TranslationOfficeDbContext : DbContext
{
    public TranslationOfficeDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Translator> Translator { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TranslationOfficeDbContext).Assembly);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        configurationBuilder.Properties<TranslatorIdentity>().HaveConversion<TranslatorIdentityValueConverter>();
    }

    public static void BuildOptions(DbContextOptionsBuilder builder, string connectionString)
    {
        ArgumentNullException.ThrowIfNull(connectionString);
        builder
            .UseNpgsql(
                connectionString,
                options =>
                {
                    options.MigrationsHistoryTable("migration_history");
                    var assembly = typeof(TranslationOfficeDbContext).Assembly.GetName().Name;
                    options.MigrationsAssembly(assembly);
                }
            )
            .UseSnakeCaseNamingConvention();
    }

    public static TranslationOfficeDbContext Create(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TranslationOfficeDbContext>();
        BuildOptions(optionsBuilder, connectionString);
        return new TranslationOfficeDbContext(optionsBuilder.Options);
    }
}

public sealed class TranslationOfficeDbContextDesignTimeFactory
    : IDesignTimeDbContextFactory<TranslationOfficeDbContext>
{
    public TranslationOfficeDbContext CreateDbContext(string[] args)
    {
        var connectionString = args.Length > 0 ? args.First() : string.Empty;
        return TranslationOfficeDbContext.Create(connectionString);
    }
}