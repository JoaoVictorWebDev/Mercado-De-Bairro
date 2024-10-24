using Microsoft.EntityFrameworkCore;
using SuperMarket.Core.Mappings;
using SuperMarket.Data.Contexts;
using SuperMarket.Core.Interface;
using SuperMarket.Data.Repositories;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseNpgsql(builder.Configuration
    .GetConnectionString("WebApiDatabase"), x => x.MigrationsAssembly("SuperMarket.API").ToString()));

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
