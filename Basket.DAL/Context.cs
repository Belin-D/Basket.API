using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basket.DOMAINE.Models;
using Microsoft.EntityFrameworkCore;

namespace Basket.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        // === DbSets ===
        public DbSet<Adresse_Terrain> AdressesTerrains { get; set; }
        public DbSet<Calendrier_Match> CalendriersMatchs { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Classement> Classements { get; set; }
        public DbSet<Coach> Coachs { get; set; }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Evenement> Evenements { get; set; }
        public DbSet<Joueur> Joueurs { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Saison> Saisons { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // === Equipe → Saison / Categorie / Coach ===
            modelBuilder.Entity<Equipe>()
                .HasOne(e => e.Saison)
                .WithMany(s => s.Equipes)
                .HasForeignKey(e => e.SaisonId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Equipe>()
                .HasOne(e => e.Categorie)
                .WithMany(c => c.Equipes)
                .HasForeignKey(e => e.CategorieId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Equipe>()
                .HasOne(e => e.Coach)
                .WithMany(c => c.Equipes)
                .HasForeignKey(e => e.CoachId)
                .OnDelete(DeleteBehavior.Restrict);

            // === Joueur → Equipe ===
            modelBuilder.Entity<Joueur>()
                .HasOne(j => j.Equipe)
                .WithMany(e => e.Joueurs)
                .HasForeignKey(j => j.EquipeId)
                .OnDelete(DeleteBehavior.Cascade);

            // === Equipe ↔ Adresse_Terrain (Many-to-Many) ===
            modelBuilder.Entity<Equipe>()
                .HasMany(e => e.Terrains)
                .WithMany(t => t.Equipes)
                .UsingEntity(j => j.ToTable("EquipeTerrains"));

            // === Calendrier_Match → Équipes (Local / Visiteur) ===
            modelBuilder.Entity<Calendrier_Match>()
                .HasOne(m => m.EquipeLocal)
                .WithMany()
                .HasForeignKey(m => m.EquipeLocalId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Calendrier_Match>()
                .HasOne(m => m.EquipeVisiteur)
                .WithMany()
                .HasForeignKey(m => m.EquipeVisiteurId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Calendrier_Match>()
                .HasOne(m => m.Saison)
                .WithMany()
                .HasForeignKey(m => m.SaisonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Calendrier_Match>()
                .HasOne(m => m.Adresse_Terrain)
                .WithMany()
                .HasForeignKey(m => m.Adresse_TerrainId)
                .OnDelete(DeleteBehavior.SetNull);

            // === Classement ===
            modelBuilder.Entity<Classement>()
                .HasOne(c => c.Equipe)
                .WithMany()
                .HasForeignKey(c => c.EquipeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Classement>()
                .HasOne(c => c.Saison)
                .WithMany()
                .HasForeignKey(c => c.SaisonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Classement>()
                .HasOne(c => c.Categorie)
                .WithMany()
                .HasForeignKey(c => c.CategorieId)
                .OnDelete(DeleteBehavior.Cascade);

            // === Evenement ===
            modelBuilder.Entity<Evenement>()
                .HasOne(e => e.Saison)
                .WithMany()
                .HasForeignKey(e => e.SaisonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Evenement>()
                .HasOne(e => e.AdresseTerrain)
                .WithMany()
                .HasForeignKey(e => e.AdresseTerrainId)
                .OnDelete(DeleteBehavior.Cascade);

            // === Reservation ===
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Evenement)
                .WithMany()
                .HasForeignKey(r => r.EvenementId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Utilisateur)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.UtilisateurId)
                .OnDelete(DeleteBehavior.Cascade);

            // === Types SQL personnalisés ===
            modelBuilder.Entity<Calendrier_Match>()
                .Property(m => m.DateMatch)
                .HasColumnType("date");

            modelBuilder.Entity<Calendrier_Match>()
                .Property(m => m.HeureMatch)
                .HasColumnType("time");

            modelBuilder.Entity<Evenement>()
                .Property(e => e.DateEvenement)
                .HasColumnType("date");

            modelBuilder.Entity<Evenement>()
                .Property(e => e.HeureEvenement)
                .HasColumnType("time");

            modelBuilder.Entity<Classement>()
                .Property(c => c.DateMiseAJour)
                .HasColumnType("datetime2");

            modelBuilder.Entity<Reservation>()
                .Property(r => r.DateReservation)
                .HasColumnType("datetime2");
        }
    }
}

