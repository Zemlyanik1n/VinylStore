using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.CookiePolicy;
using VinylStore.Application.Abstractions.Auth;
using VinylStore.Application.Abstractions.Services;
using VinylStore.Application.Extensions;
using VinylStore.Application.Services;
using VinylStore.Extensions;
using VinylStore.Infrastructure.Auth;
using VinylStore.Persistence;
using VinylStore.Persistence.Mappings;
using AuthorizationOptions = VinylStore.Persistence.AuthorizationOptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions))); // дописать exts для токенов
builder.Services.Configure<AuthorizationOptions>(builder.Configuration.GetSection(nameof(AuthorizationOptions))); // дописать exts для токенов

builder.Services.AddPersistence(builder.Configuration); // бд
builder.Services.AddApplication(); // сервисы
builder.Services.AddAutoMapper(typeof(DataBaseMappings));
builder.Services.AddSwaggerDocumentation(); 
builder.Services.AddApiAuthentication(builder.Configuration); // аутентификация

builder.Services.AddScoped<IJwtProvider, JwtProvider>(); // дописать exts для токенов
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
builder.Services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();



var app = builder.Build();

app.UseStaticFiles();

app.UseCors(x =>
{
    x.WithHeaders().AllowAnyHeader();
    x.WithOrigins("http://localhost:3000");
    x.WithMethods().AllowAnyMethod();
});

app.Use(async (context, next) =>
{
    var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
    logger.LogInformation("Запрос: {Method} {Path} {QueryString}", context.Request.Method, context.Request.Path, context.Request.QueryString.Value);
    
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
