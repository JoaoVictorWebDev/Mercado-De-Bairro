using Microsoft.EntityFrameworkCore;
using SuperMarket.Core.Mappings;
using SuperMarket.Data.Contexts;
using SuperMarket.Data.Repositories;
using SuperMarket.Core.Service;
using SuperMarket.Core.Strategies;
using SuperMarket.Core.Structs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using SuperMarket.Core.Interface.Service;
using SuperMarket.Core.Interface.Repositories;
using SuperMarket.Core.Interface.Strategies;
using SuperMarket.API.JWT.Interface;
using SuperMarket.API.JWT.Config;

var builder = WebApplication.CreateBuilder(args);

// Configurações de serviços
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "Bearer",
                Name = "Authorization",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

// Configuração do DbContext
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseNpgsql(builder.Configuration
    .GetConnectionString("WebApiDatabase"), x => x.MigrationsAssembly("SuperMarket.API").ToString()).EnableSensitiveDataLogging());

// Mapeamento
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Registro de serviços
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ExpirationDateAvailableStrategy>();
builder.Services.AddScoped<StockAvaliableStrategy>();
builder.Services.AddScoped<IProductStrategy, StockAvaliableStrategy>();
builder.Services.AddScoped<IProductStrategy, ExpirationDateAvailableStrategy>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Configuração de autenticação JWT
var tokenKey = builder.Configuration.GetValue<string>("JwtSettings:TokenKey");
var key = Encoding.ASCII.GetBytes(tokenKey);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidateAudience = false,
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        ValidateLifetime = true
    };
});

// Configuração de serviços adicionais
builder.Services.AddSingleton<ITokenRefresh>(x =>
    new TokenRefresher(key, x.GetService<IJwtAuthenticationManager>()));
builder.Services.AddSingleton<IRefreshTokenGenerator, RefreshTokenGenerator>();
builder.Services.AddSingleton<IJwtAuthenticationManager>(x =>
    new JwtAuthenticationManager(tokenKey, x.GetService<IRefreshTokenGenerator>()));

var app = builder.Build();

// Configuração do pipeline de requisições
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
