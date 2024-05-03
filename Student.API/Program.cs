using Microsoft.OpenApi.Models;
using Student.Application.Extensions;
using Student.Infrastructure.DbContext;
using Student.Infrastructure.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Register Configuration
builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceLayer();

// Add services to the container
builder.Services.Configure<DapperContext>(builder.Configuration.GetSection("ConnectionString"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Student.API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student.API v1"));
}

app.UseAuthorization();

app.MapControllers();

app.Run();
