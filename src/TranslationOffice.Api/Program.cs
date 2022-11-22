using Microsoft.EntityFrameworkCore;
using TranslationOffice.Api;
using TranslationOffice.Application.Data;
using TranslationOffice.Application.Data.Commands;
using TranslationOffice.Domain;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;


services.AddPooledDbContextFactory<TranslationOfficeDbContext>(optionsBuilder =>
{
    var connectionString = configuration.GetConnectionString("TranslationOffice");
    ArgumentNullException.ThrowIfNull(connectionString);
    TranslationOfficeDbContext.BuildOptions(optionsBuilder, connectionString);
});

services.AddScoped(sp =>
{
    var dbContextFactory = sp.GetRequiredService<IDbContextFactory<TranslationOfficeDbContext>>();
    return dbContextFactory.CreateDbContext();
});

services.AddScoped<IUnitOfWork, TranslationOfficeUnitOfWork>();
services.AddSingleton<IAsyncMaker, EfAsyncMaker>();

services.AddTranslatorDependencies();

services.AddGraphQLServer()
    .AddTranslatorGraphQL();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseRouting();
app.MapGraphQL();


app.Run();
