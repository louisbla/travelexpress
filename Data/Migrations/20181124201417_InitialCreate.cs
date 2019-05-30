using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garderie.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activites",
                columns: table => new
                {
                    ActiviteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(unicode: false, maxLength: 45, nullable: true),
                    Description = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    NbEnfantsMax = table.Column<int>(nullable: true),
                    Lieu = table.Column<string>(unicode: false, maxLength: 45, nullable: true),
                    Visible = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activites", x => x.ActiviteId);
                });

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    AdresseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ligne1 = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Ligne2 = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Ligne3 = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Ville = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CodePostal = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    Pays = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Visible = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.AdresseId);
                });

            migrationBuilder.CreateTable(
                name: "CategoriesArticle",
                columns: table => new
                {
                    CategorieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(unicode: false, maxLength: 45, nullable: true),
                    Visible = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesArticle", x => x.CategorieId);
                });

            migrationBuilder.CreateTable(
                name: "InventairesEnfant",
                columns: table => new
                {
                    InventaireId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Visible = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventairesEnfant", x => x.InventaireId);
                });

            migrationBuilder.CreateTable(
                name: "Lieux",
                columns: table => new
                {
                    SalleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Libelle = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Occupe = table.Column<byte>(nullable: true),
                    Visible = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lieux", x => x.SalleId);
                });

            migrationBuilder.CreateTable(
                name: "Maladies",
                columns: table => new
                {
                    MaladieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(unicode: false, maxLength: 45, nullable: true),
                    Descriptif = table.Column<string>(type: "text", nullable: true),
                    Visible = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maladies", x => x.MaladieId);
                });

            migrationBuilder.CreateTable(
                name: "Personnes",
                columns: table => new
                {
                    PersonneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(unicode: false, maxLength: 45, nullable: true),
                    Prenom = table.Column<string>(unicode: false, maxLength: 45, nullable: true),
                    Sexe = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    DateNaissance = table.Column<DateTime>(type: "date", nullable: true),
                    NumSecu = table.Column<string>(unicode: false, maxLength: 45, nullable: true),
                    Visible = table.Column<byte>(nullable: true),
                    Discriminator = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnes", x => x.PersonneId);
                });

            migrationBuilder.CreateTable(
                name: "StatutsFacture",
                columns: table => new
                {
                    StatutFactureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Libelle = table.Column<string>(unicode: false, maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatutsFacture", x => x.StatutFactureId);
                });

            migrationBuilder.CreateTable(
                name: "TVAs",
                columns: table => new
                {
                    TVAId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(unicode: false, maxLength: 45, nullable: true),
                    Valeur = table.Column<double>(nullable: true),
                    Visible = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVAs", x => x.TVAId);
                });

            migrationBuilder.CreateTable(
                name: "TypesConges",
                columns: table => new
                {
                    TypeCongeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesConges", x => x.TypeCongeId);
                });

            migrationBuilder.CreateTable(
                name: "TypesContrat",
                columns: table => new
                {
                    TypeContratId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Libelle = table.Column<string>(unicode: false, maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesContrat", x => x.TypeContratId);
                });

            migrationBuilder.CreateTable(
                name: "TypesGroupe",
                columns: table => new
                {
                    TypeGroupeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Libelle = table.Column<string>(unicode: false, maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesGroupe", x => x.TypeGroupeId);
                });

            migrationBuilder.CreateTable(
                name: "ComptesUser",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(unicode: false, maxLength: 45, nullable: true),
                    Password = table.Column<string>(unicode: false, maxLength: 45, nullable: true),
                    Privilege = table.Column<byte>(nullable: false),
                    PersonneId = table.Column<int>(nullable: false),
                    Visible = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComptesUser", x => x.UserId);
                    table.ForeignKey(
                        name: "ComptesUser_Personnes_FK",
                        column: x => x.PersonneId,
                        principalTable: "Personnes",
                        principalColumn: "PersonneId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactsUrgence",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Telephone = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    ContactPersonneId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactsUrgence", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_ContactsUrgence_Personnes_ContactPersonneId",
                        column: x => x.ContactPersonneId,
                        principalTable: "Personnes",
                        principalColumn: "PersonneId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employes",
                columns: table => new
                {
                    EmployeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Poste = table.Column<string>(unicode: false, maxLength: 45, nullable: true),
                    Externe = table.Column<byte>(nullable: true),
                    Telephone = table.Column<string>(unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employes", x => x.EmployeId);
                    table.ForeignKey(
                        name: "FK_Employes_Personnes_EmployeId",
                        column: x => x.EmployeId,
                        principalTable: "Personnes",
                        principalColumn: "PersonneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    ParentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NbEnfantsInscrits = table.Column<int>(nullable: true),
                    Telephone = table.Column<string>(unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.ParentId);
                    table.ForeignKey(
                        name: "FK_Parents_Personnes_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Personnes",
                        principalColumn: "PersonneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonneAdresses",
                columns: table => new
                {
                    AdresseId = table.Column<int>(nullable: false),
                    PersonneId = table.Column<int>(nullable: false),
                    Domicile = table.Column<byte>(nullable: true),
                    Facturation = table.Column<byte>(nullable: true),
                    Visible = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonneAdresses", x => new { x.AdresseId, x.PersonneId });
                    table.ForeignKey(
                        name: "PersonneAdresses_Adresses_FK",
                        column: x => x.AdresseId,
                        principalTable: "Adresses",
                        principalColumn: "AdresseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "PersonneAdresses_Personnes_FK",
                        column: x => x.PersonneId,
                        principalTable: "Personnes",
                        principalColumn: "PersonneId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Factures",
                columns: table => new
                {
                    FactureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateEmission = table.Column<DateTime>(type: "date", nullable: true),
                    DatePaiement = table.Column<DateTime>(type: "date", nullable: true),
                    MontantTTC = table.Column<double>(nullable: true),
                    Visible = table.Column<byte>(nullable: true),
                    StatutFactureId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factures", x => x.FactureId);
                    table.ForeignKey(
                        name: "Factures_StatutsFacture_FK",
                        column: x => x.StatutFactureId,
                        principalTable: "StatutsFacture",
                        principalColumn: "StatutFactureId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ObjetsFacturables",
                columns: table => new
                {
                    ObjetFacturableId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PrixHT = table.Column<double>(nullable: true),
                    Nom = table.Column<string>(unicode: false, maxLength: 45, nullable: true),
                    TVAId = table.Column<int>(nullable: false),
                    ActiviteId = table.Column<int>(nullable: true),
                    Visible = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetsFacturables", x => x.ObjetFacturableId);
                    table.ForeignKey(
                        name: "ObjetsFacturables_Activites_FK",
                        column: x => x.ActiviteId,
                        principalTable: "Activites",
                        principalColumn: "ActiviteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ObjetsFacturables_TVAs_FK",
                        column: x => x.TVAId,
                        principalTable: "TVAs",
                        principalColumn: "TVAId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Calendriers",
                columns: table => new
                {
                    CalendrierId = table.Column<int>(nullable: false),
                    DateDebut = table.Column<DateTime>(type: "date", nullable: true),
                    DateFin = table.Column<DateTime>(type: "date", nullable: true),
                    EmployeId = table.Column<int>(nullable: false),
                    Visible = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendriers", x => new { x.CalendrierId, x.EmployeId });
                    table.ForeignKey(
                        name: "Calendriers_Employes_FK",
                        column: x => x.EmployeId,
                        principalTable: "Employes",
                        principalColumn: "EmployeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DossiersEmploye",
                columns: table => new
                {
                    DossierId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateEntree = table.Column<DateTime>(type: "date", nullable: true),
                    NbMoisAnciennete = table.Column<int>(nullable: true),
                    TauxHoraireBrut = table.Column<double>(nullable: true),
                    Visible = table.Column<byte>(nullable: true),
                    TypeContratId = table.Column<int>(nullable: false),
                    EmployeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DossiersEmploye", x => x.DossierId);
                    table.ForeignKey(
                        name: "DossiersEmploye_Employes_FK",
                        column: x => x.EmployeId,
                        principalTable: "Employes",
                        principalColumn: "EmployeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "DossiersEmploye_TypesContrat_FK",
                        column: x => x.TypeContratId,
                        principalTable: "TypesContrat",
                        principalColumn: "TypeContratId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Groupes",
                columns: table => new
                {
                    GroupeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descriptif = table.Column<string>(type: "text", nullable: true),
                    ReferantId = table.Column<int>(nullable: true),
                    Visible = table.Column<byte>(nullable: true),
                    TypeGroupeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupes", x => x.GroupeId);
                    table.ForeignKey(
                        name: "Groupes_Employes_FK",
                        column: x => x.ReferantId,
                        principalTable: "Employes",
                        principalColumn: "EmployeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Groupes_TypesGroupe_FK",
                        column: x => x.TypeGroupeId,
                        principalTable: "TypesGroupe",
                        principalColumn: "TypeGroupeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventaires",
                columns: table => new
                {
                    InventaireId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StockMax = table.Column<int>(nullable: true),
                    StockActuel = table.Column<int>(nullable: true),
                    EmployeId = table.Column<int>(nullable: false),
                    Visible = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventaires", x => x.InventaireId);
                    table.ForeignKey(
                        name: "Inventaires_Employes_FK",
                        column: x => x.EmployeId,
                        principalTable: "Employes",
                        principalColumn: "EmployeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParentsFactures",
                columns: table => new
                {
                    FactureId = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    Visible = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentsFactures", x => new { x.FactureId, x.ParentId });
                    table.ForeignKey(
                        name: "ParentsFactures_Factures_FK",
                        column: x => x.FactureId,
                        principalTable: "Factures",
                        principalColumn: "FactureId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ParentsFactures_Parents_FK",
                        column: x => x.ParentId,
                        principalTable: "Parents",
                        principalColumn: "ParentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LignesFactures",
                columns: table => new
                {
                    LigneId = table.Column<int>(nullable: false),
                    TotalHT = table.Column<double>(nullable: true),
                    TotalTTC = table.Column<double>(nullable: true),
                    Quantite = table.Column<int>(nullable: true),
                    FactureId = table.Column<int>(nullable: false),
                    ObjetFacturableId = table.Column<int>(nullable: false),
                    Visible = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LignesFactures", x => new { x.LigneId, x.FactureId });
                    table.ForeignKey(
                        name: "LignesFactures_ObjetsFacturables_FK",
                        column: x => x.ObjetFacturableId,
                        principalTable: "ObjetsFacturables",
                        principalColumn: "ObjetFacturableId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Horaires",
                columns: table => new
                {
                    HoraireId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    HeureDebut = table.Column<TimeSpan>(nullable: true),
                    HeureFin = table.Column<TimeSpan>(nullable: true),
                    CalendrierId = table.Column<int>(nullable: false),
                    Visible = table.Column<byte>(nullable: true),
                    EmployeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horaires", x => new { x.HoraireId, x.CalendrierId });
                    table.ForeignKey(
                        name: "Horaires_Calendriers_FK",
                        columns: x => new { x.CalendrierId, x.EmployeId },
                        principalTable: "Calendriers",
                        principalColumns: new[] { "CalendrierId", "EmployeId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Conges",
                columns: table => new
                {
                    CongeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Debut = table.Column<DateTime>(type: "date", nullable: true),
                    Duree = table.Column<int>(nullable: true),
                    TypeCongeId = table.Column<int>(nullable: false),
                    Visible = table.Column<byte>(nullable: true),
                    DossierEmployeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conges", x => x.CongeId);
                    table.ForeignKey(
                        name: "Conges_DossiersEmploye_FK",
                        column: x => x.DossierEmployeId,
                        principalTable: "DossiersEmploye",
                        principalColumn: "DossierId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Conges_TypesConges_FK",
                        column: x => x.TypeCongeId,
                        principalTable: "TypesConges",
                        principalColumn: "TypeCongeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FichesPaye",
                columns: table => new
                {
                    FichePayeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SalaireBrut = table.Column<double>(nullable: false),
                    NbHeuresPrevu = table.Column<double>(nullable: false),
                    NbHeuresReel = table.Column<double>(nullable: false),
                    DossierEmployeId = table.Column<int>(nullable: false),
                    Visible = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichesPaye", x => x.FichePayeId);
                    table.ForeignKey(
                        name: "FichesPaye_DossiersEmploye_FK",
                        column: x => x.DossierEmployeId,
                        principalTable: "DossiersEmploye",
                        principalColumn: "DossierId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeGroupes",
                columns: table => new
                {
                    GroupeId = table.Column<int>(nullable: false),
                    EmployeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeGroupes", x => new { x.GroupeId, x.EmployeId });
                    table.ForeignKey(
                        name: "EmployeGroupes_Employes_FK",
                        column: x => x.EmployeId,
                        principalTable: "Employes",
                        principalColumn: "EmployeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "EmployeGroupes_Groupes_FK",
                        column: x => x.GroupeId,
                        principalTable: "Groupes",
                        principalColumn: "GroupeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enfants",
                columns: table => new
                {
                    EnfantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Photo = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    GroupeId = table.Column<int>(nullable: false),
                    InventaireEnfantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfants", x => x.EnfantId);
                    table.ForeignKey(
                        name: "FK_Enfants_Personnes_EnfantId",
                        column: x => x.EnfantId,
                        principalTable: "Personnes",
                        principalColumn: "PersonneId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Enfants_Groupes_FK",
                        column: x => x.GroupeId,
                        principalTable: "Groupes",
                        principalColumn: "GroupeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Enfants_InventairesEnfant_FK",
                        column: x => x.InventaireEnfantId,
                        principalTable: "InventairesEnfant",
                        principalColumn: "InventaireId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Participation",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    ActiviteId = table.Column<int>(nullable: false),
                    GroupeId = table.Column<int>(nullable: false),
                    SalleId = table.Column<int>(nullable: false),
                    Visible = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participation", x => new { x.ActiviteId, x.GroupeId, x.SalleId });
                    table.ForeignKey(
                        name: "Participation_Activites_FK",
                        column: x => x.ActiviteId,
                        principalTable: "Activites",
                        principalColumn: "ActiviteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Participation_Groupes_FK",
                        column: x => x.GroupeId,
                        principalTable: "Groupes",
                        principalColumn: "GroupeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Participation_Lieux_FK",
                        column: x => x.SalleId,
                        principalTable: "Lieux",
                        principalColumn: "SalleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(unicode: false, maxLength: 45, nullable: true),
                    Quantite = table.Column<int>(nullable: true),
                    Photo = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Visible = table.Column<byte>(nullable: true),
                    Description = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    InventaireId = table.Column<int>(nullable: true),
                    EnfantInventaireId = table.Column<int>(nullable: true),
                    CategorieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleId);
                    table.ForeignKey(
                        name: "Articles_CategoriesArticle_FK",
                        column: x => x.CategorieId,
                        principalTable: "CategoriesArticle",
                        principalColumn: "CategorieId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Articles_InventairesEnfant_FK",
                        column: x => x.EnfantInventaireId,
                        principalTable: "InventairesEnfant",
                        principalColumn: "InventaireId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Articles_Inventaires_FK",
                        column: x => x.InventaireId,
                        principalTable: "Inventaires",
                        principalColumn: "InventaireId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DossiersInscription",
                columns: table => new
                {
                    DossierId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateInscription = table.Column<DateTime>(type: "date", nullable: true),
                    NbDemiJourneesInscrit = table.Column<int>(nullable: true),
                    NbDemiJourneesAbsent = table.Column<int>(nullable: true),
                    MedecinTraitant = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    EnfantId = table.Column<int>(nullable: false),
                    Visible = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DossiersInscription", x => x.DossierId);
                    table.ForeignKey(
                        name: "DossiersInscription_Enfants_FK",
                        column: x => x.EnfantId,
                        principalTable: "Enfants",
                        principalColumn: "EnfantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Filiations",
                columns: table => new
                {
                    ParentId = table.Column<int>(nullable: false),
                    EnfantId = table.Column<int>(nullable: false),
                    LienParente = table.Column<string>(unicode: false, maxLength: 6, nullable: true),
                    Visible = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiations", x => new { x.ParentId, x.EnfantId });
                    table.ForeignKey(
                        name: "Filiations_Enfants_FK",
                        column: x => x.EnfantId,
                        principalTable: "Enfants",
                        principalColumn: "EnfantId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Filiations_Parents_FK",
                        column: x => x.ParentId,
                        principalTable: "Parents",
                        principalColumn: "ParentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Traitements",
                columns: table => new
                {
                    MaladieId = table.Column<int>(nullable: false),
                    EnfantId = table.Column<int>(nullable: false),
                    NomMedicament = table.Column<string>(unicode: false, maxLength: 45, nullable: true),
                    Specification = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Type = table.Column<string>(unicode: false, maxLength: 45, nullable: true),
                    Quantite = table.Column<double>(nullable: true),
                    Frequence = table.Column<int>(nullable: true),
                    Visible = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traitements", x => new { x.MaladieId, x.EnfantId });
                    table.ForeignKey(
                        name: "Traitements_Enfants_FK",
                        column: x => x.EnfantId,
                        principalTable: "Enfants",
                        principalColumn: "EnfantId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Traitements_Maladies_FK",
                        column: x => x.MaladieId,
                        principalTable: "Maladies",
                        principalColumn: "MaladieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocumentsOfficiels",
                columns: table => new
                {
                    DocumentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(unicode: false, maxLength: 45, nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    DossierId = table.Column<int>(nullable: false),
                    Visible = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentsOfficiels", x => x.DocumentId);
                    table.ForeignKey(
                        name: "DocumentsOfficiels_DossiersInscription_FK",
                        column: x => x.DossierId,
                        principalTable: "DossiersInscription",
                        principalColumn: "DossierId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DossiersContactUrgence",
                columns: table => new
                {
                    DossierContactUrgenceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LienParente = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    ContactId = table.Column<int>(nullable: false),
                    Visible = table.Column<byte>(nullable: false),
                    DossierInscriptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DossiersContactUrgence", x => x.DossierContactUrgenceId);
                    table.ForeignKey(
                        name: "DossiersContactUrgence_ContactsUrgence_FK",
                        column: x => x.ContactId,
                        principalTable: "ContactsUrgence",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "DossiersContactUrgence_DossiersInscription_FK",
                        column: x => x.DossierInscriptionId,
                        principalTable: "DossiersInscription",
                        principalColumn: "DossierId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RapportJournalier",
                columns: table => new
                {
                    RapportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Present = table.Column<byte>(nullable: true),
                    Resume = table.Column<string>(type: "text", nullable: true),
                    Visible = table.Column<byte>(nullable: true),
                    DossierInscriptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RapportJournalier", x => x.RapportId);
                    table.ForeignKey(
                        name: "RapportJournalier_DossiersInscription_FK",
                        column: x => x.DossierInscriptionId,
                        principalTable: "DossiersInscription",
                        principalColumn: "DossierId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategorieId",
                table: "Articles",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_EnfantInventaireId",
                table: "Articles",
                column: "EnfantInventaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_InventaireId",
                table: "Articles",
                column: "InventaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendriers_EmployeId",
                table: "Calendriers",
                column: "EmployeId");

            migrationBuilder.CreateIndex(
                name: "IX_ComptesUser_PersonneId",
                table: "ComptesUser",
                column: "PersonneId");

            migrationBuilder.CreateIndex(
                name: "IX_Conges_DossierEmployeId",
                table: "Conges",
                column: "DossierEmployeId");

            migrationBuilder.CreateIndex(
                name: "IX_Conges_TypeCongeId",
                table: "Conges",
                column: "TypeCongeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactsUrgence_ContactPersonneId",
                table: "ContactsUrgence",
                column: "ContactPersonneId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentsOfficiels_DossierId",
                table: "DocumentsOfficiels",
                column: "DossierId");

            migrationBuilder.CreateIndex(
                name: "IX_DossiersContactUrgence_ContactId",
                table: "DossiersContactUrgence",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_DossiersContactUrgence_DossierInscriptionId",
                table: "DossiersContactUrgence",
                column: "DossierInscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_DossiersEmploye_EmployeId",
                table: "DossiersEmploye",
                column: "EmployeId");

            migrationBuilder.CreateIndex(
                name: "IX_DossiersEmploye_TypeContratId",
                table: "DossiersEmploye",
                column: "TypeContratId");

            migrationBuilder.CreateIndex(
                name: "IX_DossiersInscription_EnfantId",
                table: "DossiersInscription",
                column: "EnfantId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeGroupes_EmployeId",
                table: "EmployeGroupes",
                column: "EmployeId");

            migrationBuilder.CreateIndex(
                name: "IX_Enfants_GroupeId",
                table: "Enfants",
                column: "GroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_Enfants_InventaireEnfantId",
                table: "Enfants",
                column: "InventaireEnfantId");

            migrationBuilder.CreateIndex(
                name: "IX_Factures_StatutFactureId",
                table: "Factures",
                column: "StatutFactureId");

            migrationBuilder.CreateIndex(
                name: "IX_FichesPaye_DossierEmployeId",
                table: "FichesPaye",
                column: "DossierEmployeId");

            migrationBuilder.CreateIndex(
                name: "IX_Filiations_EnfantId",
                table: "Filiations",
                column: "EnfantId");

            migrationBuilder.CreateIndex(
                name: "IX_Groupes_ReferantId",
                table: "Groupes",
                column: "ReferantId");

            migrationBuilder.CreateIndex(
                name: "IX_Groupes_TypeGroupeId",
                table: "Groupes",
                column: "TypeGroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_Horaires_CalendrierId_EmployeId",
                table: "Horaires",
                columns: new[] { "CalendrierId", "EmployeId" });

            migrationBuilder.CreateIndex(
                name: "IX_Inventaires_EmployeId",
                table: "Inventaires",
                column: "EmployeId");

            migrationBuilder.CreateIndex(
                name: "IX_LignesFactures_ObjetFacturableId",
                table: "LignesFactures",
                column: "ObjetFacturableId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjetsFacturables_ActiviteId",
                table: "ObjetsFacturables",
                column: "ActiviteId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjetsFacturables_TVAId",
                table: "ObjetsFacturables",
                column: "TVAId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentsFactures_ParentId",
                table: "ParentsFactures",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Participation_GroupeId",
                table: "Participation",
                column: "GroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_Participation_SalleId",
                table: "Participation",
                column: "SalleId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonneAdresses_PersonneId",
                table: "PersonneAdresses",
                column: "PersonneId");

            migrationBuilder.CreateIndex(
                name: "IX_RapportJournalier_DossierInscriptionId",
                table: "RapportJournalier",
                column: "DossierInscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Traitements_EnfantId",
                table: "Traitements",
                column: "EnfantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "ComptesUser");

            migrationBuilder.DropTable(
                name: "Conges");

            migrationBuilder.DropTable(
                name: "DocumentsOfficiels");

            migrationBuilder.DropTable(
                name: "DossiersContactUrgence");

            migrationBuilder.DropTable(
                name: "EmployeGroupes");

            migrationBuilder.DropTable(
                name: "FichesPaye");

            migrationBuilder.DropTable(
                name: "Filiations");

            migrationBuilder.DropTable(
                name: "Horaires");

            migrationBuilder.DropTable(
                name: "LignesFactures");

            migrationBuilder.DropTable(
                name: "ParentsFactures");

            migrationBuilder.DropTable(
                name: "Participation");

            migrationBuilder.DropTable(
                name: "PersonneAdresses");

            migrationBuilder.DropTable(
                name: "RapportJournalier");

            migrationBuilder.DropTable(
                name: "Traitements");

            migrationBuilder.DropTable(
                name: "CategoriesArticle");

            migrationBuilder.DropTable(
                name: "Inventaires");

            migrationBuilder.DropTable(
                name: "TypesConges");

            migrationBuilder.DropTable(
                name: "ContactsUrgence");

            migrationBuilder.DropTable(
                name: "DossiersEmploye");

            migrationBuilder.DropTable(
                name: "Calendriers");

            migrationBuilder.DropTable(
                name: "ObjetsFacturables");

            migrationBuilder.DropTable(
                name: "Factures");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "Lieux");

            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "DossiersInscription");

            migrationBuilder.DropTable(
                name: "Maladies");

            migrationBuilder.DropTable(
                name: "TypesContrat");

            migrationBuilder.DropTable(
                name: "Activites");

            migrationBuilder.DropTable(
                name: "TVAs");

            migrationBuilder.DropTable(
                name: "StatutsFacture");

            migrationBuilder.DropTable(
                name: "Enfants");

            migrationBuilder.DropTable(
                name: "Groupes");

            migrationBuilder.DropTable(
                name: "InventairesEnfant");

            migrationBuilder.DropTable(
                name: "Employes");

            migrationBuilder.DropTable(
                name: "TypesGroupe");

            migrationBuilder.DropTable(
                name: "Personnes");
        }
    }
}
