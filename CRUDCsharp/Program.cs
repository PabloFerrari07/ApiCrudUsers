using CRUDCsharp.Automappers;
using CRUDCsharp.Dtos;
using CRUDCsharp.Models;
using CRUDCsharp.Services;
using CRUDCsharp.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Configura los servicios de CORS para permitir cualquier origen, método y encabezado
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", // Nombre de la política de CORS
        builder =>
        {
            builder
                .AllowAnyOrigin()  // Permite cualquier origen
                .AllowAnyMethod()  // Permite cualquier método HTTP (GET, POST, etc.)
                .AllowAnyHeader(); // Permite cualquier encabezado
        });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//INYECCION SERVICIOS
builder.Services.AddScoped<IUsersService, UserService>();
builder.Services.AddSwaggerGen();
//BASE DE DATOS
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection"));
});
//VALIDADORES
builder.Services.AddScoped<IValidator<UserInsertDto>, UserInsertValidator>();
//MAPERS
builder.Services.AddAutoMapper(typeof(MappingProfile));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // Usa la página de excepción del desarrollador para mostrar errores detallados
    app.UseDeveloperExceptionPage();
}

// Habilita la política de CORS configurada anteriormente
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
