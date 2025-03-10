using Microsoft.EntityFrameworkCore;
using VinylStore.Application.Services;
using VinylStore.Core.Abstractions;
using VinylStore.Core.Abstractions.Repositories;
using VinylStore.Persistence;
using VinylStore.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<VinylStoreDbContext>();

builder.Services.AddScoped<IVinylsService, VinylsService>();
builder.Services.AddScoped<IVinylPlatesRepository, VinylPlatesRepository>();
builder.Services.AddScoped<IGenresRepository, GenresRepository>();

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

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.MapControllers();

app.Run();

