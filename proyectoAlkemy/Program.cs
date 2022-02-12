using Microsoft.EntityFrameworkCore;
using proyectoAlkemy.Contexts;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//inyeccion de dependencias
builder.Services.AddEntityFrameworkSqlServer();
builder.Services.AddDbContext<DisneyContext>((services, options) =>
{
    options.UseApplicationServiceProvider(services);
    options.UseSqlServer("Data Source=DESKTOP-C7M4JOU;DataBase=DysneyDb;Integrated Security = True;");
});
//DESKTOP-C7M4JOU
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
