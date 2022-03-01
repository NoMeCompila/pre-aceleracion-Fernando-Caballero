using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using proyectoAlkemy.Contexts;
using proyectoAlkemy.Interfaces;
using proyectoAlkemy.Models;
using proyectoAlkemy.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

//inyeccion de dependencias
builder.Services.AddEntityFrameworkSqlServer(); // se indica que se trabajara con EF
builder.Services.AddDbContext<DisneyContext>((services, options) =>
{
    options.UseApplicationServiceProvider(services);
    //para que no esté hardocodeado se le pasa como parametro una variable que contiene el string de conexion
    options.UseSqlServer(builder.Configuration.GetConnectionString("DisneyConnectionString"));
});

builder.Services.AddDbContext<UserContext>((services, options) =>
{
    options.UseApplicationServiceProvider(services);
    //para que no esté hardocodeado se le pasa como parametro una variable que contiene el string de conexion
    options.UseSqlServer(builder.Configuration.GetConnectionString("UsersConnectionString"));
});

//----------------------------------------INYECCIONES----------------------------------------
//-------------------------------------------------------------------------------------------
builder.Services.AddScoped<IGenresRepository, GenresRepository>();
builder.Services.AddScoped<ICharactersRepository, CharactersRepository>();
builder.Services.AddScoped<IMovieSeriesRepository, MovieSeriesRepository>();
//builder.Services.AddScoped<ICharacterMsRepository, CharacterMsRepository>();


//builder.Services.AddSingleton(builder.Configuration);



builder.Services.AddIdentity<User, IdentityRole>().
    AddEntityFrameworkStores<UserContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme= JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme= JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false, //quien hace el token
        ValidateAudience = false, //para quien es el token
        //la palabra secreta para la firma del token
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtKey"]))
    };

});
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

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
