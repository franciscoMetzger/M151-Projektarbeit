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
	Bezahlt			DATETIME,
	Rabatt			INT,
	KundeId			INT FOREIGN KEY REFERENCES Kunde(ID_Kunde) NOT NULL
);


CREATE TABLE ArtikelVermietung(
	ID_ArtikelVermietung INT PRIMARY KEY IDENTITY(1,1),
	ArtikelId			 INT FOREIGN KEY REFERENCES Artikel(ID_Artikel) NOT NULL,
	VermietungsId		 INT FOREIGN KEY REFERENCES Vermietung(ID_Vermietung) NOT NULL,
);

CREATE TABLE Benutzer(
	ID_Bennutzer	INT PRIMARY KEY IDENTITY(1,1),
	Benutzername	VARCHAR(50)  NOT NULL UNIQUE,
	IsAdmin			BIT DEFAULT(0) NOT NULL,
	PasswordHash	VARCHAR(29)  NOT NULL,
	PasswordSalt	VARCHAR(60)  NOT NULL,

);

INSERT INTO Kategorie VALUES('Ski');
INSERT INTO Kategorie VALUES('Snowboard');
INSERT INTO Kategorie VALUES('Snowblaids');