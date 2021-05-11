--DROP TABLE [Utilisateur]
--DROP TABLE [Canal]
--DROP TABLE [Publication]

--CREATE TABLE [dbo].[Utilisateur]
--(
--	[Id] INT IDENTITY NOT NULL, 
--	[Pseudo] NCHAR(10) NOT NULL,
--    [Nom] VARCHAR(80) NOT NULL, 
--    [Prenom] VARCHAR(80) NOT NULL, 
--    [Email] VARCHAR(MAX) NOT NULL, 
--    [Mdp] VARCHAR(80) NOT NULL, 
--    [DateCreation] DATETIME NOT NULL, 
--    [Avatar] VARCHAR(MAX) NOT NULL DEFAULT 0, 
--    [Actif] INT NOT NULL DEFAULT 0,
--    [Admin] INT NOT NULL DEFAULT 0
--    PRIMARY KEY CLUSTERED ([Id] ASC)
--)

--CREATE TABLE [dbo].[Canal]
--(
--	[Id] INT IDENTITY NOT NULL, 
--    [Theme] VARCHAR(80) NOT NULL, 
--    [Description] VARCHAR(MAX) NULL, 
--    [DateCreation] DATETIME NOT NULL, 
--    [Actif] INT NOT NULL DEFAULT 0,
--    [IdUtilisateur] INT NOT NULL
--    PRIMARY KEY CLUSTERED ([Id] ASC)
--)

--CREATE TABLE [dbo].[Publication]
--(
--	[Id] INT IDENTITY NOT NULL, 
--    [Contenu] VARCHAR(80) NOT NULL, 
--    [DateCreation] DATETIME NOT NULL, 
--    [Actif] INT NOT NULL DEFAULT 0,
--    [IdCanal] INT NOT NULL
--    PRIMARY KEY CLUSTERED ([Id] ASC)
--)

--INSERT INTO Canal (Theme, Description, DateCreation, Actif, IdUtilisateur) VALUES('Voiture', 'Pour tous les pasionnés de voiture', CURRENT_TIMESTAMP, 0, 1);
--INSERT INTO Canal (Theme, Description, DateCreation, Actif, IdUtilisateur) VALUES('Camion', 'Pour tous les pasionnés de camion', CURRENT_TIMESTAMP, 0, 2);
--INSERT INTO Canal (Theme, Description, DateCreation, Actif, IdUtilisateur) VALUES('Voiture', 'Pour tous les pasionnés de voiture', CURRENT_TIMESTAMP, 0, 1);
--INSERT INTO Canal (Theme, Description, DateCreation, Actif, IdUtilisateur) VALUES('Camion', 'Pour tous les pasionnés de camion', CURRENT_TIMESTAMP, 0, 2);

INSERT INTO Publication (Contenu, DateCreation, Actif, IdCanal) VALUES('Pour tous les pasionnés de voiture', CURRENT_TIMESTAMP, 0, 1);
INSERT INTO Publication (Contenu, DateCreation, Actif, IdCanal) VALUES('Pour tous les pasionnés de camion', CURRENT_TIMESTAMP, 0, 1);
INSERT INTO Publication (Contenu, DateCreation, Actif, IdCanal) VALUES('Pour tous les pasionnés de voiture', CURRENT_TIMESTAMP, 0, 3);
INSERT INTO Publication (Contenu, DateCreation, Actif, IdCanal) VALUES('Pour tous les pasionnés de camion', CURRENT_TIMESTAMP, 0, 3);
INSERT INTO Publication (Contenu, DateCreation, Actif, IdCanal) VALUES('Pour tous les pasionnés de voiture', CURRENT_TIMESTAMP, 0, 4);
INSERT INTO Publication (Contenu, DateCreation, Actif, IdCanal) VALUES('Pour tous les pasionnés de camion', CURRENT_TIMESTAMP, 0, 4);
INSERT INTO Publication (Contenu, DateCreation, Actif, IdCanal) VALUES('Pour tous les pasionnés de voiture', CURRENT_TIMESTAMP, 0, 5);
INSERT INTO Publication (Contenu, DateCreation, Actif, IdCanal) VALUES('Pour tous les pasionnés de camion', CURRENT_TIMESTAMP, 0, 5);
