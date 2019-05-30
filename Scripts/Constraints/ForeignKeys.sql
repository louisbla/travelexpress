USE Garderie
GO

ALTER TABLE AspNetRoleClaims
ADD
	CONSTRAINT FK_AspNetRoleClaims_AspNetRoles_RoleId FOREIGN KEY (RoleId) REFERENCES AspNetRoles(Id) ON DELETE CASCADE ON UPDATE CASCADE;
GO

ALTER TABLE AspNetUserClaims
ADD
	CONSTRAINT FK_AspNetUserClaims_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id) ON DELETE CASCADE ON UPDATE CASCADE;
GO

ALTER TABLE AspNetUserLogins
ADD
	CONSTRAINT FK_AspNetUserLogins_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id) ON DELETE CASCADE ON UPDATE CASCADE;
GO

ALTER TABLE AspNetUserRoles
ADD
	CONSTRAINT FK_AspNetUserRoles_AspNetRoles_RoleId FOREIGN KEY (RoleId) REFERENCES AspNetRoles(Id) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT FK_AspNetUserRoles_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id) ON DELETE CASCADE ON UPDATE CASCADE;	
GO

ALTER TABLE AspNetUserTokens
ADD
	CONSTRAINT FK_AspNetUserTokens_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id) ON DELETE CASCADE ON UPDATE CASCADE;
GO

ALTER TABLE AspNetUsers
ADD
	CONSTRAINT AppUser_Personne_FK FOREIGN KEY (PersonneId) REFERENCES Personnes(PersonneId) ON DELETE CASCADE ON UPDATE CASCADE;
GO

ALTER TABLE Articles
ADD 
	CONSTRAINT Articles_CategoriesArticle_FK FOREIGN KEY (CategorieId) REFERENCES CategoriesArticle(CategorieId),
	CONSTRAINT Articles_InventairesEnfant_FK FOREIGN KEY (EnfantInventaireId) REFERENCES InventairesEnfant(InventaireId),
	CONSTRAINT Articles_Inventaires_FK FOREIGN KEY (InventaireId) REFERENCES Inventaires(InventaireId);
GO

ALTER TABLE Calendriers
ADD
    CONSTRAINT Calendriers_Employes_FK FOREIGN KEY (EmployeId) REFERENCES Employes(EmployeId);
GO

ALTER TABLE Conges
ADD
	CONSTRAINT Conges_DossiersEmploye_FK FOREIGN KEY (DossierEmployeId) REFERENCES DossiersEmploye(DossierId),
	CONSTRAINT Conges_TypesConges_FK FOREIGN KEY (TypeCongeId) REFERENCES TypesConges(TypeCongeId);
GO

ALTER TABLE ContactsUrgence
ADD
	CONSTRAINT ContactsUrgence_Personnes_FK FOREIGN KEY (ContactId) REFERENCES Personnes(PersonneId);	
GO

ALTER TABLE DocumentsOfficiels
ADD
	CONSTRAINT DocumentsOfficiels_DossiersInscription_FK FOREIGN KEY (DossierId) REFERENCES DossiersInscription(DossierId); 
GO

ALTER TABLE DossiersContactUrgence
ADD 
	CONSTRAINT DossiersContactUrgence_ContactsUrgence_FK FOREIGN KEY (ContactId) REFERENCES ContactsUrgence(ContactId),
	CONSTRAINT DossiersContactUrgence_DossiersInscription_FK FOREIGN KEY (DossierInscriptionId) REFERENCES DossiersInscription(DossierId);
GO

ALTER TABLE DossiersEmploye
ADD 
	CONSTRAINT DossiersEmploye_Employes_FK FOREIGN KEY (EmployeId) REFERENCES Employes(EmployeId),
	CONSTRAINT DossiersEmploye_TypesContrat_FK FOREIGN KEY (TypeContratId) REFERENCES TypesContrat(TypeContratId);
GO

ALTER TABLE DossiersInscription
ADD 
	CONSTRAINT DossiersInscription_Enfants_FK FOREIGN KEY (EnfantId) REFERENCES Enfants(EnfantId);
GO

ALTER TABLE EmployeGroupes
ADD 
	CONSTRAINT EmployeGroupes_Employes_FK FOREIGN KEY (EmployeId) REFERENCES Employes(EmployeId) ,
	CONSTRAINT EmployeGroupes_Groupes_FK FOREIGN KEY (GroupeId) REFERENCES Groupes(GroupeId);
GO

ALTER TABLE Employes
ADD 
	CONSTRAINT Employes_Personnes_FK FOREIGN KEY (EmployeId) REFERENCES Personnes(PersonneId);
GO

ALTER TABLE Enfants
ADD 
	CONSTRAINT Enfants_Groupes_FK FOREIGN KEY (GroupeId) REFERENCES Groupes(GroupeId),
	CONSTRAINT Enfants_InventairesEnfant_FK FOREIGN KEY (InventaireEnfantId) REFERENCES InventairesEnfant(InventaireId),
	CONSTRAINT Enfants_Personnes_FK FOREIGN KEY (EnfantId) REFERENCES Personnes(PersonneId);
GO

ALTER TABLE Factures
ADD 
	CONSTRAINT Factures_StatutsFacture_FK FOREIGN KEY (StatutFactureId) REFERENCES StatutsFacture(StatutFactureId);
GO

ALTER TABLE FichesPaye
ADD
	CONSTRAINT FichesPaye_DossiersEmploye_FK FOREIGN KEY (DossierEmployeId) REFERENCES DossiersEmploye(DossierId);
GO

ALTER TABLE Filiations
ADD
	CONSTRAINT Filiations_Enfants_FK FOREIGN KEY (EnfantId) REFERENCES Enfants(EnfantId) ,
	CONSTRAINT Filiations_Parents_FK FOREIGN KEY (ParentId) REFERENCES Parents(ParentId);
GO

ALTER TABLE Groupes
ADD
	CONSTRAINT Groupes_Employes_FK FOREIGN KEY (ReferantId) REFERENCES Employes(EmployeId) ,
	CONSTRAINT Groupes_TypesGroupe_FK FOREIGN KEY (TypeGroupeId) REFERENCES TypesGroupe(TypeGroupeId);	
GO

ALTER TABLE Horaires
ADD
	CONSTRAINT Horaires_Calendriers_FK FOREIGN KEY (CalendrierId,EmployeId) REFERENCES Calendriers(CalendrierId,EmployeId);
GO

ALTER TABLE Inventaires
ADD
	CONSTRAINT Inventaires_Employes_FK FOREIGN KEY (EmployeId) REFERENCES Employes(EmployeId);
GO

ALTER TABLE LignesFactures
ADD
	CONSTRAINT LignesFactures_ObjetsFacturables_FK FOREIGN KEY (ObjetFacturableId) REFERENCES ObjetsFacturables(ObjetFacturableId);
GO

ALTER TABLE ObjetsFacturables
ADD
	CONSTRAINT ObjetsFacturables_Activites_FK FOREIGN KEY (ActiviteId) REFERENCES Activites(ActiviteId) ,
	CONSTRAINT ObjetsFacturables_TVAs_FK FOREIGN KEY (TVAId) REFERENCES TVAs(TVAId);
GO

ALTER TABLE Parents
ADD
	CONSTRAINT Parents_Personnes_FK FOREIGN KEY (ParentId) REFERENCES Personnes(PersonneId);
GO

ALTER TABLE ParentsFactures
ADD
	CONSTRAINT ParentsFactures_Factures_FK FOREIGN KEY (FactureId) REFERENCES Factures(FactureId) ,
	CONSTRAINT ParentsFactures_Parents_FK FOREIGN KEY (ParentId) REFERENCES Parents(ParentId);
GO

ALTER TABLE Participation
ADD
	CONSTRAINT Participation_Activites_FK FOREIGN KEY (ActiviteId) REFERENCES Activites(ActiviteId) ,
	CONSTRAINT Participation_Groupes_FK FOREIGN KEY (GroupeId) REFERENCES Groupes(GroupeId) ,
	CONSTRAINT Participation_Lieux_FK FOREIGN KEY (SalleId) REFERENCES Lieux(SalleId);
GO

ALTER TABLE PersonneAdresses
ADD
	CONSTRAINT PersonneAdresses_Adresses_FK FOREIGN KEY (AdresseId) REFERENCES Adresses(AdresseId) ,
	CONSTRAINT PersonneAdresses_Personnes_FK FOREIGN KEY (PersonneId) REFERENCES Personnes(PersonneId);
GO

ALTER TABLE RapportJournalier
ADD
	CONSTRAINT RapportJournalier_DossiersInscription_FK FOREIGN KEY (DossierInscriptionId) REFERENCES DossiersInscription(DossierId);
GO

ALTER TABLE Traitements
ADD
	CONSTRAINT Traitements_Enfants_FK FOREIGN KEY (EnfantId) REFERENCES Enfants(EnfantId) ,
	CONSTRAINT Traitements_Maladies_FK FOREIGN KEY (MaladieId) REFERENCES Maladies(MaladieId);
GO