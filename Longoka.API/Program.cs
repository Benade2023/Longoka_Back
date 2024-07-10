using Longoka.BL.BL;
using Longoka.BL.Interfaces;
using Longoka.Dapper.Providers;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var configuration = builder.Configuration;
var connexionString = configuration.GetConnectionString("DefaultConnection");

//CORS POLICY

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => builder.AllowAnyOrigin() //Tous les origin && WhithOrigin pour specifier ("https://hlcongo.com")
                                                .AllowAnyMethod() // Toutes les methode && WhithMethod pour specifier ("POST", "PUT"...)
                                                .AllowAnyHeader()); // Tous les headers && WhithHeader pour specifier
});

builder.Services.AddScoped<IProvider<Ecoles, Guid>>(_ => new EcoleProviderDapper(connexionString));
builder.Services.AddScoped<IEcoleManager, EcoleManager>();

builder.Services.AddScoped<IProvider<AnneeScolaires, Guid>>(_ => new AnneeScolaireProviderDapper(connexionString));
builder.Services.AddScoped<IAnneeScolaireManager, AnneeScolaireManager>();

builder.Services.AddScoped<IProvider<Profiles, Guid>>(_ => new ProfileProviderDapper(connexionString));
builder.Services.AddScoped<IProfileManager, ProfileManager>();

builder.Services.AddScoped<IProvider<Classes, Guid>>(_ => new ClasseProviderDapper(connexionString));
builder.Services.AddScoped<IClasseManager, ClasseManager>();

builder.Services.AddScoped<IProvider<Users, Guid>>(_ => new UserProviderDapper(connexionString));
builder.Services.AddScoped<IUserManager, UserManager>();

builder.Services.AddScoped<IProvider<PersonnelEnseignants, Guid>>(_ => new PersonnelEnseignantProviderDapper(connexionString));
builder.Services.AddScoped<IPersonnelEnseignantManager, PersonnelEnseignantManager>();

builder.Services.AddScoped<IProvider<Matieres, Guid>>(_ => new MatiereProviderDapper(connexionString));
builder.Services.AddScoped<IMatiereManager, MatiereManager>();

builder.Services.AddScoped<IProvider<ParentEleves, Guid>>(_ => new ParentEleveProviderDapper(connexionString));
builder.Services.AddScoped<IParentEleveManager, ParentEleveManager>();

builder.Services.AddScoped<IProvider<Eleves, Guid>>(_ => new EleveProviderDapper(connexionString));
builder.Services.AddScoped<IEleveManager, EleveManager>();




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
