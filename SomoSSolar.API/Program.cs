using Microsoft.EntityFrameworkCore;
using SomoSSolar.API.Data;
using SomoSSolar.API.EndPoints;
using SomoSSolar.API.Handlers;
using SomoSSolar.Core.Handlers.Clientes;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(x => {
    x.UseSqlServer(connectionString);
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.CustomSchemaIds(n => n.FullName);
});

builder.Services.AddTransient<IClienteHandler, ClienteHandler>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => new { message = "ok" });
app.MapEndpoints();

app.Run();
