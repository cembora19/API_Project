using Microsoft.EntityFrameworkCore;
using Repositories.EFCore;
using WebApi.Extensions;
using Services;
using Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Presentation.ActionFilters;
using Entities.Models;
using AspNetCoreRateLimit;


var builder = WebApplication.CreateBuilder(args);

LogManager.Setup().LoadConfigurationFromFile(Path.Combine(Directory.GetCurrentDirectory(), "NLog.config"));

// Add services to the container
builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
    config.CacheProfiles.Add("5mins", new CacheProfile() { Duration = 300 });
})
    .AddXmlDataContractSerializerFormatters()
    .AddCustomCsvFormatter()
    .AddApplicationPart(typeof(Presentation.AssemblyRefence).Assembly)
    .AddNewtonsoftJson(opt =>
        opt.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore);


builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// DbContext
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureLoggerService();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureActionFilters();
// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureCors();
builder.Services.ConfigureDataShapper();
builder.Services.AddCustomMediaTypes();
builder.Services.AddScoped<IBookLinks, BookLinks>();
builder.Services.ConfigureVersioning();
builder.Services.ConfigureResponseCaching();
builder.Services.ConfigureHttpCacheHeaders();
builder.Services.AddMemoryCache();
builder.Services.ConfigureRateLimitingOptions();
builder.Services.AddHttpContextAccessor();

builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);

builder.Services.RegisterRepositories();
builder.Services.RegisterServices();

// Authorization (isteğe bağlı, auth kullanacaksan)
builder.Services.AddAuthorization();

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(s =>
    {
        s.SwaggerEndpoint("/swagger/v1/swagger.json", "cembora v1");
        s.SwaggerEndpoint("/swagger/v2/swagger.json", "cembora v2");
    });
}

if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseIpRateLimiting();
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseResponseCaching();
app.UseHttpCacheHeaders();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
