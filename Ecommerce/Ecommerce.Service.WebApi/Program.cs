using AutoMapper;
using Ecommerce.Service.WebApi.Helpers;
using Ecommerce.Service.WebApi.Modules.Authentication;
using Ecommerce.Service.WebApi.Modules.Feature;
using Ecommerce.Service.WebApi.Modules.Injection;
using Ecommerce.Service.WebApi.Modules.Mapper;
using Ecommerce.Service.WebApi.Modules.Swagger;

var myPolicy = "policyEcommerce";
var builder = WebApplication.CreateBuilder(args);
var appSettingsSection = builder.Configuration.GetSection("Config");
var appSettings = appSettingsSection.Get<AppSettings>();

//builder.Services.AddAutoMapper()

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("Config"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Add services to the container.
// Metodos extensores
builder.Services.AddSwagger();
builder.Services.AddAuthenticacion(builder.Configuration);
builder.Services.AddFeature(builder.Configuration);
builder.Services.AddInjection(builder.Configuration);
builder.Services.AddMapper();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API Ecommerce v1");
    });
}

app.UseCors(myPolicy);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
