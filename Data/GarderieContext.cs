using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Garderie.Models;

namespace Garderie.Data
{
    public class GarderieContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public GarderieContext()
        {
        }

        public GarderieContext(DbContextOptions<GarderieContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activite> Activites { get; set; }
        public virtual DbSet<Adresse> Adresses { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Calendrier> Calendriers { get; set; }
        public virtual DbSet<CategorieArticle> CategoriesArticle { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Conge> Conges { get; set; }
        public virtual DbSet<ContactUrgence> ContactsUrgence { get; set; }
        public virtual DbSet<DocumentOfficiel> DocumentsOfficiels { get; set; }
        public virtual DbSet<DossierEmploye> DossiersEmploye { get; set; }
        public virtual DbSet<DossierInscription> DossiersInscription { get; set; }
        public virtual DbSet<EmployeGroupe> EmployeGroupes { get; set; }
        public virtual DbSet<Employe> Employes { get; set; }
        public virtual DbSet<Enfant> Enfants { get; set; }
        public virtual DbSet<Facture> Factures { get; set; }
        public virtual DbSet<FichePaye> FichesPaye { get; set; }
        public virtual DbSet<Filiation> Filiations { get; set; }
        public virtual DbSet<Groupe> Groupes { get; set; }
        public virtual DbSet<Horaire> Horaires { get; set; }
        public virtual DbSet<Inventaire> Inventaires { get; set; }
        public virtual DbSet<InventaireEnfant> InventairesEnfant { get; set; }
        public virtual DbSet<Lieu> Lieux { get; set; }
        public virtual DbSet<LigneFacture> LignesFactures { get; set; }
        public virtual DbSet<Maladie> Maladies { get; set; }
        public virtual DbSet<ObjetFacturable> ObjetsFacturables { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<ParentFacture> ParentsFactures { get; set; }
        public virtual DbSet<Participation> Participation { get; set; }
        public virtual DbSet<PersonneAdresse> PersonneAdresses { get; set; }
        public virtual DbSet<Personne> Personnes { get; set; }
        public virtual DbSet<RapportJournalier> RapportJournalier { get; set; }
        public virtual DbSet<StatutFacture> StatutsFacture { get; set; }
        public virtual DbSet<Traitement> Traitements { get; set; }
        public virtual DbSet<Tva> Tvas { get; set; }
        public virtual DbSet<TypeConge> TypesConges { get; set; }
        public virtual DbSet<TypeContrat> TypesContrat { get; set; }
        public virtual DbSet<TypeGroupe> TypesGroupe { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Activite>(entity =>
            {
                entity.HasKey(e => e.ActiviteId);

                entity.Property(e => e.ActiviteId).ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lieu)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            builder.Entity<Adresse>(entity =>
            {
                entity.HasKey(e => e.AdresseId);

                entity.Property(e => e.AdresseId).ValueGeneratedOnAdd();

                entity.Property(e => e.CodePostal)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ligne1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ligne2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ligne3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pays)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ville)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            builder.Entity<Article>(entity =>
            {
                entity.HasKey(e => e.ArticleId);

                entity.Property(e => e.ArticleId).ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Categorie)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.CategorieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Articles_CategoriesArticle_FK");

                entity.HasOne(d => d.EnfantInventaire)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.EnfantInventaireId)
                    .HasConstraintName("Articles_InventairesEnfant_FK");

                entity.HasOne(d => d.Inventaire)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.InventaireId)
                    .HasConstraintName("Articles_Inventaires_FK");
            });

            builder.Entity<Calendrier>(entity =>
            {
                entity.HasKey(e => new { e.CalendrierId, e.EmployeId });

                entity.Property(e => e.DateDebut).HasColumnType("date");

                entity.Property(e => e.DateFin).HasColumnType("date");

                entity.HasOne(d => d.Employe)
                    .WithMany(p => p.Calendriers)
                    .HasForeignKey(d => d.EmployeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Calendriers_Employes_FK");
            });

            builder.Entity<CategorieArticle>(entity =>
            {
                entity.HasKey(e => e.CategorieId);

                entity.Property(e => e.CategorieId).ValueGeneratedOnAdd();

                entity.Property(e => e.Nom)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            builder.Entity<Conge>(entity =>
            {
                entity.HasKey(e => e.CongeId);

                entity.Property(e => e.CongeId).ValueGeneratedOnAdd();

                entity.Property(e => e.Debut).HasColumnType("date");

                entity.HasOne(d => d.DossierEmploye)
                    .WithMany(p => p.Conges)
                    .HasForeignKey(d => d.DossierEmployeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Conges_DossiersEmploye_FK");

                entity.HasOne(d => d.TypeConge)
                    .WithMany(p => p.Conges)
                    .HasForeignKey(d => d.TypeCongeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Conges_TypesConges_FK");
            });

            builder.Entity<ContactUrgence>(entity =>
            {
                entity.HasKey(e => e.ContactId);

                entity.Property(e => e.ContactId).ValueGeneratedOnAdd();

                entity.Property(e => e.Telephone)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            builder.Entity<DocumentOfficiel>(entity =>
            {
                entity.HasKey(e => e.DocumentId);

                entity.Property(e => e.DocumentId).ValueGeneratedOnAdd();

                entity.Property(e => e.Nom)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Url).HasColumnType("text");

                entity.HasOne(d => d.Dossier)
                    .WithMany(p => p.DocumentsOfficiels)
                    .HasForeignKey(d => d.DossierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DocumentsOfficiels_DossiersInscription_FK");
            });

            //builder.Entity<DossierContactUrgence>(entity =>
            //{
            //    entity.HasKey(e => new { e.ContactId, e.DossierInscriptionId });

            //    entity.Property(e => e.LienParente)
            //        .IsRequired()
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.HasOne(d => d.Contact)
            //        .WithMany(p => p.DossiersContactUrgence)
            //        .HasForeignKey(d => d.ContactId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("DossiersContactUrgence_ContactsUrgence_FK");

            //    entity.HasOne(d => d.DossierInscription)
            //        .WithMany(p => p.DossiersContactUrgence)
            //        .HasForeignKey(d => d.DossierInscriptionId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("DossiersContactUrgence_DossiersInscription_FK");
            //});

            builder.Entity<DossierEmploye>(entity =>
            {
                entity.HasKey(e => e.DossierId);

                entity.Property(e => e.DossierId).ValueGeneratedOnAdd();

                entity.Property(e => e.DateEntree).HasColumnType("date");

                entity.HasOne(d => d.Employe)
                    .WithMany(p => p.DossiersEmploye)
                    .HasForeignKey(d => d.EmployeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DossiersEmploye_Employes_FK");

                entity.HasOne(d => d.TypeContrat)
                    .WithMany(p => p.DossiersEmploye)
                    .HasForeignKey(d => d.TypeContratId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DossiersEmploye_TypesContrat_FK");
            });

            builder.Entity<DossierInscription>(entity =>
            {
                entity.HasKey(e => e.DossierId);

                entity.Property(e => e.DossierId).ValueGeneratedOnAdd();

                entity.Property(e => e.DateInscription).HasColumnType("date");

                entity.Property(e => e.MedecinTraitant)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Enfant)
                    .WithMany(p => p.DossiersInscription)
                    .HasForeignKey(d => d.EnfantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DossiersInscription_Enfants_FK");
            });

            builder.Entity<EmployeGroupe>(entity =>
            {
                entity.HasKey(e => new { e.GroupeId, e.EmployeId });

                entity.HasOne(d => d.Employe)
                    .WithMany(p => p.EmployeGroupes)
                    .HasForeignKey(d => d.EmployeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EmployeGroupes_Employes_FK");

                entity.HasOne(d => d.Groupe)
                    .WithMany(p => p.EmployeGroupes)
                    .HasForeignKey(d => d.GroupeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EmployeGroupes_Groupes_FK");
            });

            builder.Entity<Employe>(entity =>
            {
                entity.HasKey(e => e.EmployeId);

                entity.Property(e => e.EmployeId).ValueGeneratedOnAdd();

                entity.Property(e => e.Poste)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            builder.Entity<Enfant>(entity =>
            {
                entity.HasKey(e => e.EnfantId);

                entity.Property(e => e.EnfantId).ValueGeneratedOnAdd();

                entity.Property(e => e.Photo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Groupe)
                    .WithMany(p => p.Enfants)
                    .HasForeignKey(d => d.GroupeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Enfants_Groupes_FK");

                entity.HasOne(d => d.InventaireEnfant)
                    .WithMany(p => p.Enfants)
                    .HasForeignKey(d => d.InventaireEnfantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Enfants_InventairesEnfant_FK");
            });

            builder.Entity<Facture>(entity =>
            {
                entity.HasKey(e => e.FactureId);

                entity.Property(e => e.FactureId).ValueGeneratedOnAdd();

                entity.Property(e => e.DateEmission).HasColumnType("date");

                entity.Property(e => e.DatePaiement).HasColumnType("date");

                entity.Property(e => e.MontantTtc).HasColumnName("MontantTTC");

                entity.HasOne(d => d.StatutFacture)
                    .WithMany(p => p.Factures)
                    .HasForeignKey(d => d.StatutFactureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Factures_StatutsFacture_FK");
            });

            builder.Entity<FichePaye>(entity =>
            {
                entity.HasKey(e => e.FichePayeId);

                entity.Property(e => e.FichePayeId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.DossierEmploye)
                    .WithMany(p => p.FichesPaye)
                    .HasForeignKey(d => d.DossierEmployeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FichesPaye_DossiersEmploye_FK");
            });

            builder.Entity<Filiation>(entity =>
            {
                entity.HasKey(e => new { e.ParentId, e.EnfantId });

                entity.Property(e => e.LienParente)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.Enfant)
                    .WithMany(p => p.Filiations)
                    .HasForeignKey(d => d.EnfantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Filiations_Enfants_FK");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Filiations)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Filiations_Parents_FK");
            });

            builder.Entity<Groupe>(entity =>
            {
                entity.HasKey(e => e.GroupeId);

                entity.Property(e => e.GroupeId).ValueGeneratedOnAdd();

                entity.Property(e => e.Descriptif).HasColumnType("text");

                entity.HasOne(d => d.Referant)
                    .WithMany(p => p.Groupes)
                    .HasForeignKey(d => d.ReferantId)
                    .HasConstraintName("Groupes_Employes_FK");

                entity.HasOne(d => d.TypeGroupe)
                    .WithMany(p => p.Groupes)
                    .HasForeignKey(d => d.TypeGroupeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Groupes_TypesGroupe_FK");
            });

            builder.Entity<Horaire>(entity =>
            {
                entity.HasKey(e => new { e.HoraireId, e.CalendrierId });

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Calendrier)
                    .WithMany(p => p.Horaires)
                    .HasForeignKey(d => new { d.CalendrierId, d.EmployeId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Horaires_Calendriers_FK");
            });

            builder.Entity<Inventaire>(entity =>
            {
                entity.HasKey(e => e.InventaireId);

                entity.Property(e => e.InventaireId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Employe)
                    .WithMany(p => p.Inventaires)
                    .HasForeignKey(d => d.EmployeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Inventaires_Employes_FK");
            });

            builder.Entity<InventaireEnfant>(entity =>
            {
                entity.HasKey(e => e.InventaireId);

                entity.Property(e => e.InventaireId).ValueGeneratedOnAdd();
            });

            builder.Entity<Lieu>(entity =>
            {
                entity.HasKey(e => e.SalleId);

                entity.Property(e => e.SalleId).ValueGeneratedOnAdd();

                entity.Property(e => e.Libelle)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            builder.Entity<LigneFacture>(entity =>
            {
                entity.HasKey(e => new { e.LigneId, e.FactureId });

                entity.Property(e => e.TotalHt).HasColumnName("TotalHT");

                entity.Property(e => e.TotalTtc).HasColumnName("TotalTTC");

                entity.HasOne(d => d.ObjetFacturable)
                    .WithMany(p => p.LignesFactures)
                    .HasForeignKey(d => d.ObjetFacturableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("LignesFactures_ObjetsFacturables_FK");
            });

            builder.Entity<Maladie>(entity =>
            {
                entity.HasKey(e => e.MaladieId);

                entity.Property(e => e.MaladieId).ValueGeneratedOnAdd();

                entity.Property(e => e.Descriptif).HasColumnType("text");

                entity.Property(e => e.Nom)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            builder.Entity<ObjetFacturable>(entity =>
            {
                entity.HasKey(e => e.ObjetFacturableId);

                entity.Property(e => e.ObjetFacturableId).ValueGeneratedOnAdd();

                entity.Property(e => e.Nom)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PrixHt).HasColumnName("PrixHT");

                entity.Property(e => e.Tvaid).HasColumnName("TVAId");

                entity.HasOne(d => d.Activite)
                    .WithMany(p => p.ObjetsFacturables)
                    .HasForeignKey(d => d.ActiviteId)
                    .HasConstraintName("ObjetsFacturables_Activites_FK");

                entity.HasOne(d => d.Tva)
                    .WithMany(p => p.ObjetsFacturables)
                    .HasForeignKey(d => d.Tvaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ObjetsFacturables_TVAs_FK");
            });

            builder.Entity<Parent>(entity =>
            {
                entity.HasKey(e => e.ParentId);

                entity.Property(e => e.ParentId).ValueGeneratedOnAdd();

                entity.Property(e => e.Telephone)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            builder.Entity<ParentFacture>(entity =>
            {
                entity.HasKey(e => new { e.FactureId, e.ParentId });

                entity.HasOne(d => d.Facture)
                    .WithMany(p => p.ParentsFactures)
                    .HasForeignKey(d => d.FactureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ParentsFactures_Factures_FK");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.ParentsFactures)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ParentsFactures_Parents_FK");
            });

            builder.Entity<Participation>(entity =>
            {
                entity.HasKey(e => new { e.ActiviteId, e.GroupeId, e.SalleId });

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.Activite)
                    .WithMany(p => p.Participations)
                    .HasForeignKey(d => d.ActiviteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Participation_Activites_FK");

                entity.HasOne(d => d.Groupe)
                    .WithMany(p => p.Participation)
                    .HasForeignKey(d => d.GroupeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Participation_Groupes_FK");

                entity.HasOne(d => d.Salle)
                    .WithMany(p => p.Participation)
                    .HasForeignKey(d => d.SalleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Participation_Lieux_FK");
            });

            builder.Entity<PersonneAdresse>(entity =>
            {
                entity.HasKey(e => new { e.AdresseId, e.PersonneId });

                entity.HasOne(d => d.Adresse)
                    .WithMany(p => p.PersonneAdresses)
                    .HasForeignKey(d => d.AdresseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PersonneAdresses_Adresses_FK");

                entity.HasOne(d => d.Personne)
                    .WithMany(p => p.PersonneAdresses)
                    .HasForeignKey(d => d.PersonneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PersonneAdresses_Personnes_FK");
            });

            builder.Entity<Personne>(entity =>
            {
                entity.HasKey(e => e.PersonneId);

                entity.Property(e => e.PersonneId).ValueGeneratedOnAdd();

                //entity.HasDiscriminator<String>("Discriminator")
                      //.HasValue<Enfant>("Enfant")
                      //.HasValue<Employe>("Employe")
                      //.HasValue<ContactUrgence>("ContactUrgence")
                      //.HasValue<Parent>("Parent");

                entity.Property(e => e.DateNaissance).HasColumnType("date");

                entity.Property(e => e.Nom)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.NumSecu)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Sexe)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.ApplicationUser)
                       .WithOne(p => p.Personne)
                       .HasForeignKey<Personne>(d => d.PersonneId)
                       .HasConstraintName("AppUser_Personne_FK");
            });

            builder.Entity<RapportJournalier>(entity =>
            {
                entity.HasKey(e => e.RapportId);

                entity.Property(e => e.RapportId).ValueGeneratedOnAdd();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Resume).HasColumnType("text");

                entity.HasOne(d => d.DossierInscription)
                    .WithMany(p => p.RapportJournalier)
                    .HasForeignKey(d => d.DossierInscriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RapportJournalier_DossiersInscription_FK");
            });

            builder.Entity<StatutFacture>(entity =>
            {
                entity.HasKey(e => e.StatutFactureId);

                entity.Property(e => e.StatutFactureId).ValueGeneratedOnAdd();

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            builder.Entity<Traitement>(entity =>
            {
                entity.HasKey(e => new { e.MaladieId, e.EnfantId });

                entity.Property(e => e.NomMedicament)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Specification)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Enfant)
                    .WithMany(p => p.Traitements)
                    .HasForeignKey(d => d.EnfantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Traitements_Enfants_FK");

                entity.HasOne(d => d.Maladie)
                    .WithMany(p => p.Traitements)
                    .HasForeignKey(d => d.MaladieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Traitements_Maladies_FK");
            });

            builder.Entity<Tva>(entity =>
            {
                entity.HasKey(e => e.Tvaid);

                entity.ToTable("TVAs");

                entity.Property(e => e.Tvaid)
                    .HasColumnName("TVAId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nom)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            builder.Entity<TypeConge>(entity =>
            {
                entity.HasKey(e => e.TypeCongeId);

                entity.Property(e => e.TypeCongeId).ValueGeneratedOnAdd();

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            builder.Entity<TypeContrat>(entity =>
            {
                entity.HasKey(e => e.TypeContratId);

                entity.Property(e => e.TypeContratId).ValueGeneratedOnAdd();

                entity.Property(e => e.Libelle)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            builder.Entity<TypeGroupe>(entity =>
            {
                entity.HasKey(e => e.TypeGroupeId);

                entity.Property(e => e.TypeGroupeId).ValueGeneratedOnAdd();

                entity.Property(e => e.Libelle)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });
        }
    }
}
