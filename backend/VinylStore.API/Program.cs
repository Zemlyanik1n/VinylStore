using Microsoft.AspNetCore.CookiePolicy;
using VinylStore.Application.Abstractions.Auth;
using VinylStore.Application.Abstractions.Services;
using VinylStore.Application.Services;
using VinylStore.Core.Abstractions.Repositories;
using VinylStore.Extensions;
using VinylStore.Infrastructure;
using VinylStore.Persistence;
using VinylStore.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<VinylStoreDbContext>();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
builder.Services.AddSwaggerDocumentation();
builder.Services.AddApiAuthentication(builder.Configuration);

builder.Services.AddScoped<IVinylsService, VinylsService>();
builder.Services.AddScoped<IUsersService, UsersService>();

builder.Services.AddScoped<IVinylPlatesRepository, VinylPlatesRepository>();
builder.Services.AddScoped<IGenresRepository, GenresRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();

builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();


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
