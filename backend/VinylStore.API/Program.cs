using Microsoft.EntityFrameworkCore;
using VinylStore.Application.Services;
using VinylStore.Core.Abstractions;
using VinylStore.Persistence;
using VinylStore.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<VinylStoreDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(VinylStoreDbContext)));
});

builder.Services.AddScoped<IVinylPlatesService, VinylPlatesService>();
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

app.UseCors(x =>
{
    x.WithHeaders().AllowAnyHeader();
    x.WithOrigins("http://localhost:3000");
    x.WithMethods().AllowAnyMethod();
});

app.Run();
