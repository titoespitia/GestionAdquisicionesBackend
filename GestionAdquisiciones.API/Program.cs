using GestionAdquisiciones.Aplicacion.CasosDeUso.Adquisiciones.Commands;
using GestionAdquisiciones.Dominio.Puertos;
using GestionAdquisiciones.Dominio.Servicios;
using GestionAdquisiciones.Infraestructura.Adaptadores;
using GestionAdquisiciones.Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ContextoBaseDatos>(opciones =>
    opciones.UseInMemoryDatabase("BaseDeDatosMemoria")
);

builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:4200", "https://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
    });
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CrearAdquisicionCommand).Assembly));


builder.Services.AddControllers();
builder.Services.AddOpenApi();


builder.Services.AddScoped<IRepositorioAdquisiciones, RepositorioAdquisiciones>();
builder.Services.AddScoped<IRepositorioHistorial, RepositorioHistorial>();

builder.Services.AddScoped<IServicioAdquisiciones, ServicioAdquisiciones>();
builder.Services.AddScoped<IServicioHistorial, ServicioHistorial>();


var app = builder.Build();

app.UseCors("AllowSpecificOrigin");

using (var scope = app.Services.CreateScope())
{
    var servicios = scope.ServiceProvider;
    var contexto = servicios.GetRequiredService<ContextoBaseDatos>();
    InicializadorBaseDatos.Seed(contexto); 
}


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
