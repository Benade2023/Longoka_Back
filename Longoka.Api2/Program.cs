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

builder.Services.AddScoped<IProvider<AnneeScolaires, int>>(_ => new AnneeScolaireProviderDapper(connexionString));
builder.Services.AddScoped<IAnneeScolaireManager, AnneeScolaireManager>();

builder.Services.AddScoped<IProvider<Profile, int>>(_ => new ProfileProviderDapper(connexionString));
builder.Services.AddScoped<IProfileManager, ProfileManager>();

builder.Services.AddScoped<IProvider<Eleve, int>>(_ => new EleveProviderDapper(connexionString));
builder.Services.AddScoped<IEleveManager, EleveManager>();

builder.Services.AddScoped<IProvider<ParentEleve, int>>(_ => new ParentEleveProviderDapper(connexionString));
builder.Services.AddScoped<IParentEleveManager, ParentEleveManager>();

builder.Services.AddScoped<IProvider<Enseignant, int>>(_ => new PersonnelEnseignantProviderDapper(connexionString));
builder.Services.AddScoped<IPersonnelEnseignantManager, EnseignantManager>();

builder.Services.AddScoped<IProvider<Matiere, int>>(_ => new MatiereProviderDapper(connexionString));
builder.Services.AddScoped<IMatiereManager, MatiereManager>();

builder.Services.AddScoped<IProvider<Classe, int>>(_ => new ClasseProviderDapper(connexionString));
builder.Services.AddScoped<IClasseManager, ClasseManager>();

builder.Services.AddScoped<IProvider<Cours, int>>(_ => new CoursProviderDapper(connexionString));
builder.Services.AddScoped<ICoursManager, CoursManager>();

builder.Services.AddScoped<IProvider<Salle, int>>(_ => new SalleProviderDapper(connexionString));
builder.Services.AddScoped<ISalleManager, SalleManager>();

builder.Services.AddScoped<IProvider<Adresse, int>>(_ => new AdresseProviderDapper(connexionString));
builder.Services.AddScoped<IAdresseManager, AdresseManager>();

builder.Services.AddScoped<IProvider<Contact, int>>(_ => new ContactProviderDapper(connexionString));
builder.Services.AddScoped<IContactManager, ContactManager>();

builder.Services.AddScoped<ITableIntermediare<AnneeScolaire_Etablissement>>(_ => new Etablissement_AnneeScolaireProvider(connexionString));
builder.Services.AddScoped<IEtablissementAnneeScolaireManager, Etablissement_AnneeScolaireManager>();

builder.Services.AddScoped<ITableIntermediare<Etablissement_Enseignant_Matiere>>(_ => new EtablissmentEnseignantMatiereProvider(connexionString));
builder.Services.AddScoped<IEtablissementMatiereEnseignantManager, EtablissementMatiereEnseignantManager>();

builder.Services.AddScoped<ITableIntermediare<Eleve_Cours>>(_ => new EleveCoursProviderDapper(connexionString));
builder.Services.AddScoped<IEleveCoursManager, EleveCoursManager>();

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
