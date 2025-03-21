using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.Extensions.FileProviders;
using VinylStore.Application.Extensions;
using VinylStore.Extensions;
using VinylStore.Infrastructure.Extensions;
using VinylStore.Persistence;
using VinylStore.Persistence.Mappings;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddAuthInfrastructure(configuration);
services.AddInfrastructureServices();
services.AddPersistence(builder.Configuration); // бд
services.AddApplication(); // сервисы
services.AddAutoMapper(typeof(DataBaseMappings));
services.AddSwaggerDocumentation();
services.AddApiAuthentication(configuration); // аутентификация
services.AddHttpContextAccessor();

var app = builder.Build();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
    RequestPath = "/images"
});

app.UseCors(x =>
{
    x.WithHeaders().AllowAnyHeader();
    x.WithOrigins("http://localhost:3000");
    x.WithMethods().AllowAnyMethod();
});

app.Use(async (context, next) =>
{
    var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
    logger.LogInformation("Запрос: {Method} {Path} {QueryString}", context.Request.Method, context.Request.Path,
        context.Request.QueryString.Value);

    await next();

    logger.LogInformation("Ответ: {StatusCode}", context.Response.StatusCode);
});

app.UseSwaggerDocumentation();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCookiePolicy(new CookiePolicyOptions()
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    Secure = CookieSecurePolicy.Always,
    HttpOnly = HttpOnlyPolicy.Always
});

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();