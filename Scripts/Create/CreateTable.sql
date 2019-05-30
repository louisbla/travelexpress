USE Garderie
GO
-- Drop table
DROP TABLE IF EXISTS AspNetRoleClaims
GO

CREATE TABLE AspNetRoleClaims (
	Id int NOT NULL IDENTITY(1,1),
	RoleId int NOT NULL,
	ClaimType nvarchar(4000),
	ClaimValue nvarchar(4000)
);
GO

-- Drop table
DROP TABLE IF EXISTS AspNetRoles
GO

CREATE TABLE AspNetRoles (
	Id int NOT NULL IDENTITY(1,1),
	Name nvarchar(256),
	NormalizedName nvarchar(256),
	ConcurrencyStamp nvarchar(4000),
	Access nvarchar(4000)
);
GO

-- Drop table
DROP TABLE IF EXISTS AspNetUserClaims
GO

CREATE TABLE AspNetUserClaims (
	Id int NOT NULL IDENTITY(1,1),
	UserId int NOT NULL,
	ClaimType nvarchar(4000),
	ClaimValue nvarchar(4000)
);
GO

DROP TABLE IF EXISTS AspNetUserLogins
GO

CREATE TABLE AspNetUserLogins (
	LoginProvider nvarchar(450) NOT NULL,
	ProviderKey nvarchar(450) NOT NULL,
	ProviderDisplayName nvarchar(4000),
	UserId int NOT NULL
);
GO

DROP TABLE IF EXISTS AspNetUserRoles
GO

CREATE TABLE AspNetUserRoles (
	UserId int NOT NULL,
	RoleId int NOT NULL
);
GO

DROP TABLE IF EXISTS AspNetUserTokens
GO

CREATE TABLE AspNetUserTokens (
	UserId int NOT NULL,
	LoginProvider nvarchar(450) NOT NULL,
	Name nvarchar(450) NOT NULL,
	Value nvarchar(4000)
);
GO

DROP TABLE IF EXISTS AspNetUsers
GO

CREATE TABLE AspNetUsers (
	Id int NOT NULL IDENTITY(1,1),
	UserName nvarchar(256),
	NormalizedUserName nvarchar(256),
	Email nvarchar(256),
	NormalizedEmail nvarchar(256),
	EmailConfirmed bit NOT NULL,
	PasswordHash nvarchar(4000),
	SecurityStamp nvarchar(4000),
	ConcurrencyStamp nvarchar(4000),
	PhoneNumber nvarchar(4000),
	PhoneNumberConfirmed bit NOT NULL,
	TwoFactorEnabled bit NOT NULL,
	LockoutEnd datetimeoffset,
	LockoutEnabled bit NOT NULL,
	AccessFailedCount int NOT NULL,
	PersonneId int,
	Visible tinyint
);
GO

-- Drop table
-- DROP TABLE Garderie.dbo.Activites
DROP TABLE IF EXISTS Activites
GO

CREATE TABLE Activites (
	ActiviteId int NOT NULL IDENTITY,
	Nom varchar(45),
	Description varchar(255),
	NbEnfantsMax int,
	Lieu varchar(45),
	Visible tinyint
);
GO

-- Drop table

-- DROP TABLE Garderie.dbo.Adresses
DROP TABLE IF EXISTS Adresses
GO

CREATE TABLE Adresses (
	AdresseId int NOT NULL IDENTITY,
	Ligne1 varchar(50),
	Ligne2 varchar(50),
	Ligne3 varchar(50),
	Ville varchar(50),
	CodePostal varchar(10),
	Pays varchar(20),
	Visible tinyint
);
GO

-- Drop table

-- DROP TABLE Garderie.dbo.Articles
DROP TABLE IF EXISTS Articles
GO

CREATE TABLE Articles (
	ArticleId int NOT NULL IDENTITY,
	Nom varchar(45),
	Quantite int,
	Photo varchar(255),
	Visible tinyint,
	Description varchar(255),
	InventaireId int,
	EnfantInventaireId int,
	CategorieId int NOT NULL
);
GO

-- Drop table

-- DROP TABLE Garderie.dbo.Calendriers
DROP TABLE IF EXISTS Calendriers
GO

CREATE TABLE Calendriers (
	CalendrierId int NOT NULL IDENTITY,
	DateDebut date,
	DateFin date,
	EmployeId int NOT NULL,
	Visible tinyint
);
GO

-- Drop table

-- DROP TABLE Garderie.dbo.CategoriesArticle
DROP TABLE IF EXISTS CategoriesArticle
GO

CREATE TABLE CategoriesArticle (
	CategorieId int NOT NULL IDENTITY,
	Nom varchar(45),
	Visible tinyint
);
GO

-- Drop table

-- DROP TABLE Garderie.dbo.Conges
DROP TABLE IF EXISTS Conges
GO

CREATE TABLE Conges (
	CongeId int NOT NULL IDENTITY,
	Debut date,
	Duree int,
	TypeCongeId int NOT NULL,
	Visible tinyint,
	DossierEmployeId int NOT NULL
); 
GO

-- Drop table

-- DROP TABLE Garderie.dbo.ContactsUrgence
DROP TABLE IF EXISTS ContactsUrgence
GO

CREATE TABLE ContactsUrgence (
	ContactId int NOT NULL,
	Telephone varchar(15)
); 
GO

-- Drop table

-- DROP TABLE Garderie.dbo.DocumentsOfficiels
DROP TABLE IF EXISTS DocumentsOfficiels
GO

CREATE TABLE DocumentsOfficiels (
	DocumentId int NOT NULL IDENTITY,
	Nom varchar(45),
	Url text,
	DossierId int NOT NULL,
	Visible tinyint
); 
GO

-- Drop table

-- DROP TABLE Garderie.dbo.DossiersContactUrgence
DROP TABLE IF EXISTS DossiersContactUrgence
GO

CREATE TABLE DossiersContactUrgence (
	LienParente varchar(20) NOT NULL,
	ContactId int NOT NULL,
	Visible tinyint NOT NULL,
	DossierInscriptionId int NOT NULL
); 
GO

-- Drop table

-- DROP TABLE Garderie.dbo.DossiersEmploye
DROP TABLE IF EXISTS DossiersEmploye
GO

CREATE TABLE DossiersEmploye (
	DossierId int NOT NULL IDENTITY,
	DateEntree date,
	NbMoisAnciennete int,
	TauxHoraireBrut float,
	Visible tinyint,
	TypeContratId int NOT NULL,
	EmployeId int NOT NULL
); 
GO

-- Drop table

-- DROP TABLE Garderie.dbo.DossiersInscription
DROP TABLE IF EXISTS DossiersInscription
GO

CREATE TABLE DossiersInscription (
	DossierId int NOT NULL IDENTITY,
	DateInscription date,
	NbDemiJourneesInscrit int,
	NbDemiJourneesAbsent int,
	MedecinTraitant varchar(255),
	EnfantId int NOT NULL,
	Visible tinyint
); 
GO

-- Drop table

-- DROP TABLE Garderie.dbo.EmployeGroupes
DROP TABLE IF EXISTS EmployeGroupes
GO

CREATE TABLE EmployeGroupes (
	GroupeId int NOT NULL,
	EmployeId int NOT NULL
); 
GO

-- Drop table

-- DROP TABLE Garderie.dbo.Employes
DROP TABLE IF EXISTS Employes
GO

CREATE TABLE Employes (
	EmployeId int NOT NULL,
	Poste varchar(45),
	Externe tinyint,
	Telephone varchar(15),
); 
GO

-- Drop table

-- DROP TABLE Garderie.dbo.Enfants
DROP TABLE IF EXISTS Enfants
GO

CREATE TABLE Enfants (
	EnfantId int NOT NULL,
	Photo varchar(255),
	GroupeId int NOT NULL,
	InventaireEnfantId int NOT NULL
); 
GO

-- Drop table

-- DROP TABLE Garderie.dbo.Factures
DROP TABLE IF EXISTS Factures
GO

CREATE TABLE Factures (
	FactureId int NOT NULL IDENTITY,
	DateEmission date,
	DatePaiement date,
	MontantTTC float,
	Visible tinyint,
	StatutFactureId int NOT NULL
); 
GO

-- Drop table

-- DROP TABLE Garderie.dbo.FichesPaye
DROP TABLE IF EXISTS FichesPaye
GO

CREATE TABLE FichesPaye (
	FichePayeId int NOT NULL IDENTITY,
	SalaireBrut float NOT NULL,
	NbHeuresPrevu float NOT NULL,
	NbHeuresReel float NOT NULL,
	DossierEmployeId int NOT NULL,
	Visible tinyint NOT NULL
); 
GO

-- Drop table

-- DROP TABLE Garderie.dbo.Filiations
DROP TABLE IF EXISTS Filiations
GO

CREATE TABLE Filiations (
	ParentId int NOT NULL,
	EnfantId int NOT NULL,
	LienParente varchar(6),
	Visible tinyint NOT NULL
); 
GO

-- Drop table

-- DROP TABLE Garderie.dbo.Groupes
DROP TABLE IF EXISTS Groupes
GO

CREATE TABLE Groupes (
	GroupeId int NOT NULL IDENTITY,
	Descriptif text,
	ReferantId int,
	Visible tinyint,
	TypeGroupeId int NOT NULL
); 
GO

-- Drop table

-- DROP TABLE Garderie.dbo.Horaires
DROP TABLE IF EXISTS Horaires
GO

CREATE TABLE Horaires (
	HoraireId int NOT NULL IDENTITY,
	[Date] date,
	HeureDebut time(7),
	HeureFin time(7),
	CalendrierId int NOT NULL,
	Visible tinyint,
	EmployeId int NOT NULL
); 
GO

-- Drop table

-- DROP TABLE Garderie.dbo.Inventaires
DROP TABLE IF EXISTS Inventaires
GO

CREATE TABLE Inventaires (
	InventaireId int NOT NULL IDENTITY,
	StockMax int,
	StockActuel int,
	EmployeId int NOT NULL,
	Visible tinyint
); 
GO

-- Drop table

-- DROP TABLE Garderie.dbo.InventairesEnfant
DROP TABLE IF EXISTS InventairesEnfant
GO

CREATE TABLE InventairesEnfant (
	InventaireId int NOT NULL IDENTITY,
	Visible tinyint
); 
GO

-- Drop table

-- DROP TABLE Garderie.dbo.Lieux
DROP TABLE IF EXISTS Lieux
GO

CREATE TABLE Lieux (
	SalleId int NOT NULL IDENTITY,
	Libelle varchar(50),
	Occupe tinyint,
	Visible tinyint
); 
GO

-- Drop table

-- DROP TABLE Garderie.dbo.LignesFactures
DROP TABLE IF EXISTS LignesFactures
GO

CREATE TABLE LignesFactures (
	LigneId int NOT NULL IDENTITY,
	TotalHT float,
	TotalTTC float,
	Quantite int,
	FactureId int NOT NULL,
	ObjetFacturableId int NOT NULL,
	Visible tinyint
); 
GO

-- Drop table

-- DROP TABLE Garderie.dbo.Maladies
DROP TABLE IF EXISTS Maladies
GO

CREATE TABLE Maladies (
	MaladieId int NOT NULL IDENTITY,
	Nom varchar(45),
	Descriptif text,
	Visible tinyint
); 
GO

-- Drop table

-- DROP TABLE Garderie.dbo.ObjetsFacturables
DROP TABLE IF EXISTS ObjetsFacturables
GO

CREATE TABLE ObjetsFacturables (
	ObjetFacturableId int NOT NULL IDENTITY,
	PrixHT float,
	Nom varchar(45),
	TVAId int NOT NULL,
	ActiviteId int,
	Visible tinyint
); 
GO

-- Drop table

-- DROP TABLE Garderie.dbo.Parents
DROP TABLE IF EXISTS Parents
GO

CREATE TABLE Parents (
	ParentId int NOT NULL,
	NbEnfantsInscrits int,
	Telephone varchar(15)
); 
GO

-- Drop table

-- DROP TABLE Garderie.dbo.ParentsFactures
DROP TABLE IF EXISTS ParentsFactures
GO

CREATE TABLE ParentsFactures (
	FactureId int NOT NULL,
	ParentId int NOT NULL,
	Visible int NOT NULL
); 
GO

-- Drop table

-- DROP TABLE Garderie.dbo.Participation
DROP TABLE IF EXISTS Participation
GO

CREATE TABLE Participation (
	[Date] datetime NOT NULL,
	ActiviteId int NOT NULL,
	GroupeId int NOT NULL,
	SalleId int NOT NULL,
	Visible tinyint NOT NULL
); 
GO

-- Drop table

-- DROP TABLE Garderie.dbo.PersonneAdresses
DROP TABLE IF EXISTS PersonneAdresses
GO

CREATE TABLE PersonneAdresses (
	AdresseId int NOT NULL,
	PersonneId int NOT NULL,
	Domicile tinyint,
	Facturation tinyint,
	Visible tinyint NOT NULL
); 
GO

-- Drop table

-- DROP TABLE Garderie.dbo.Personnes
DROP TABLE IF EXISTS Personnes
GO

CREATE TABLE Personnes (
	PersonneId int NOT NULL IDENTITY,
	Nom varchar(45),
	Prenom varchar(45),
	Sexe varchar(10),
	DateNaissance date,
	NumSecu varchar(45),
	Visible tinyint,
	Discriminator varchar(100) DEFAULT ('Enfant') NOT NULL
); 
GO

-- Drop table

-- DROP TABLE Garderie.dbo.RapportJournalier
DROP TABLE IF EXISTS RapportJournalier
GO

CREATE TABLE RapportJournalier (
	RapportId int NOT NULL IDENTITY,
	[Date] date NOT NULL,
	Present tinyint,
	Resume text,
	Visible tinyint,
	DossierInscriptionId int NOT NULL
); 
GO

-- Drop table

-- DROP TABLE Garderie.dbo.StatutsFacture
DROP TABLE IF EXISTS StatutsFacture
GO

CREATE TABLE StatutsFacture (
	StatutFactureId int NOT NULL IDENTITY,
	Libelle varchar(45) NOT NULL
); 
GO

-- Drop table

-- DROP TABLE Garderie.dbo.TVAs
DROP TABLE IF EXISTS TVAs
GO

CREATE TABLE TVAs (
	TVAId int NOT NULL IDENTITY,
	Nom varchar(45),
	Valeur float,
	Visible tinyint NOT NULL
);
GO

-- Drop table

-- DROP TABLE Garderie.dbo.Traitements
DROP TABLE IF EXISTS Traitements
GO

CREATE TABLE Traitements (
	MaladieId int NOT NULL,
	EnfantId int NOT NULL,
	NomMedicament varchar(45),
	Specification varchar(255),
	[Type] varchar(45),
	Quantite float,
	Frequence int,
	Visible tinyint NOT NULL
); 
GO

-- Drop table

-- DROP TABLE Garderie.dbo.TypesConges
DROP TABLE IF EXISTS TypesConges
GO

CREATE TABLE TypesConges (
	TypeCongeId int NOT NULL IDENTITY,
	[Type] varchar(50)
);
GO

-- Drop table

-- DROP TABLE Garderie.dbo.TypesContrat
DROP TABLE IF EXISTS TypesContrat
GO

CREATE TABLE TypesContrat (
	TypeContratId int NOT NULL IDENTITY,
	Libelle varchar(45)
); 
GO

-- Drop table

-- DROP TABLE Garderie.dbo.TypesGroupe
DROP TABLE IF EXISTS TypesGroupe
GO

CREATE TABLE TypesGroupe (
	TypeGroupeId int NOT NULL IDENTITY,
	Libelle varchar(45)
); 
GO