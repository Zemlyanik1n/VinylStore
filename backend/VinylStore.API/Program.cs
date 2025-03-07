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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.MapOpenApi();
//app.MapGet("/", () => "Hello World!");
app.MapControllers();
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
    logger.LogInformation("Запрос: {Method} {Path}", context.Request.Method, context.Request.Path);
    
    await next();
    
    logger.LogInformation("Ответ: {StatusCode}", context.Response.StatusCode);
});
app.Run();
