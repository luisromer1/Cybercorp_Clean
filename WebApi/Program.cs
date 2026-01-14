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

// --- NUEVO: CONFIGURACIÓN DE CORS ---
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy.WithOrigins("http://localhost:5173") // Puerto de tu Vite
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

// 3. Registro de Repositorios
builder.Services.AddScoped<IProducto, ProductoRepositorio>();
builder.Services.AddScoped<IUsuario, UsuarioRepositorio>();
builder.Services.AddScoped<IVenta, VentaRepositorio>();
builder.Services.AddScoped<IDevolucion, DevolucionRepositorio>();

// 4. Registro de Casos de Uso
builder.Services.AddScoped<RegistrarVenta>();
builder.Services.AddScoped<CrearProducto>();
builder.Services.AddScoped<RegistrarDevolucion>();
builder.Services.AddScoped<CrearUsuario>();
builder.Services.AddScoped<ObtenerStockReporte>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// --- NUEVO: USAR POLÍTICA DE CORS ---
app.UseCors("AllowReactApp");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Aquí está lo que buscabas:
app.UseHttpsRedirection();

app.UseAuthorization(); // Es buena práctica tenerlo antes de los Map
app.MapControllers();
app.Run();