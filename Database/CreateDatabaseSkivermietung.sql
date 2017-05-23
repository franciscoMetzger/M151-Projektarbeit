CREATE DATABASE Skivermietung;
USE Skivermietung;

CREATE TABLE Kategorie(
	ID_Kategorie	INT	PRIMARY KEY IDENTITY(1,1),
	Bezeichnung		VARCHAR(200) NOT NULL
);

CREATE TABLE Artikel(
	ID_Artikel		INT PRIMARY KEY IDENTITY(1,1),
	Bezeichnung		VARCHAR(200) NOT NULL,
	Farbe			VARCHAR(200),
	Marke			VARCHAR(200),
	PreisProTag		DECIMAL NOT NULL,
	KategorieId		INT FOREIGN KEY REFERENCES Kategorie(ID_Kategorie) NOT NULL
);

CREATE TABLE Kunde(
	ID_Kunde		INT PRIMARY KEY IDENTITY(1,1),
	Vorname			VARCHAR(200) NOT NULL,
	Name			VARCHAR(200) NOT NULL,
	TelefonNr		VARCHAR(50),
	Geburtstag		DATETIME NOT NULL
);

CREATE TABLE Vermietung(
	ID_Vermietung	INT PRIMARY KEY IDENTITY(1,1),
	Von				DATETIME NOT NULL,
	Bis				DATETIME NOT NULL,
	Bezahlt			BIT NOT NULL DEFAULT(0),
	Rabatt			INT,
	KundeId			INT FOREIGN KEY REFERENCES Kunde(ID_Kunde) NOT NULL
);


CREATE TABLE ArtikelVermietung(
	ID_ArtikelVermietung INT PRIMARY KEY IDENTITY(1,1),
	ArtikelId			 INT FOREIGN KEY REFERENCES Artikel(ID_Artikel) NOT NULL,
	VermietungsId		 INT FOREIGN KEY REFERENCES Vermietung(ID_Vermietung) NOT NULL,
);

INSERT INTO Kategorie VALUES('Ski');
INSERT INTO Kategorie VALUES('Snowboard');
INSERT INTO Kategorie VALUES('Snowblaids');