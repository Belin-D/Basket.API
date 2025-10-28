using Basket.DAL;
using Basket.DAL.Repositories;
using Basket.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


builder.Services.AddScoped<ISaisonRepository, SaisonRepository>();
builder.Services.AddScoped<IAdresseTerrainRepository, AdresseTerrainRepository>();
builder.Services.AddScoped<ICategorieRepository, CategorieRepository>();
builder.Services.AddScoped<ICoachRepository, CoachRepository>();
builder.Services.AddScoped<IEquipeRepository, EquipeRepository>();
builder.Services.AddScoped<IJoueurRepository, JoueurRepository>();
builder.Services.AddScoped<IEvenementRepository, EvenementRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IUtilisateurRepository, UtilisateurRepository>();
builder.Services.AddScoped<IClassementRepository, ClassementRepository>();
builder.Services.AddScoped<ICalendrierMatchRepository, CalendrierMatchRepository>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
