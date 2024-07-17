using Longoka.BL.BL;
using Longoka.BL.Interfaces;
using Longoka.Dapper.Providers;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

//Gestion de CORS
builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(
        builder => builder.AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin());

});

var configuration = builder.Configuration;
var connexionString = configuration.GetConnectionString("Longokadb");

// Add services to the container.

builder.Services.AddScoped<IProvider<Etablissement, int>>(_ => new EtablissementProviderDapper(connexionString));
builder.Services.AddScoped<IEtablissementManager, EtablissementManager>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
