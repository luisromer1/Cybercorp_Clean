using Aplication.Mapping;
using Aplication.UseCases;
using Domain.Interfaces;
using Infraestructure.Data;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Base de Datos
builder.Services.AddDbContext<CyberCorpDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// 3. Registro de Repositorios (Infraestructure)
builder.Services.AddScoped<IProducto, ProductoRepositorio>();
builder.Services.AddScoped<IUsuario, UsuarioRepositorio>();
builder.Services.AddScoped<IVenta, VentaRepositorio>();
builder.Services.AddScoped<IDevolucion, DevolucionRepositorio>();

// 4. Registro de Casos de Uso (Aplication)
builder.Services.AddScoped<RegistrarVenta>();
builder.Services.AddScoped<CrearProducto>();
builder.Services.AddScoped<RegistrarDevolucion>();
builder.Services.AddScoped<CrearUsuario>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();