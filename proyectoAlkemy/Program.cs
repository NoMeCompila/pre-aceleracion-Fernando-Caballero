using Microsoft.EntityFrameworkCore;
using proyectoAlkemy.Contexts;
using proyectoAlkemy.Interfaces;
using proyectoAlkemy.Repositories;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//inyeccion de dependencias
builder.Services.AddEntityFrameworkSqlServer(); // se indica que se trabajara con EF
builder.Services.AddDbContext<DisneyContext>((services, options) =>
{
    options.UseApplicationServiceProvider(services);
    //para que no esté hardocodeado se le pasa como parametro una variable que contiene el string de conexion
    options.UseSqlServer(builder.Configuration.GetConnectionString("DisneyConnectionString"));
});

builder.Services.AddScoped<IGenresRepository, GenresRepository>();
//DESKTOP-C7M4JOU

//3 maneras de inyectar dependencias
//builder.Services.AddTransient();
//builder.Services.AddScoped(); //por default
//builder.Services.AddSingleton();

var app = builder.Build();

var service = builder.Services.BuildServiceProvider();
var context = service.GetRequiredService<DisneyContext>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
