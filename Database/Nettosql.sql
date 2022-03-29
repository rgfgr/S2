--CREATE DATABASE Netto_db
CREATE TABLE Varre(
	ID int IDENTITY(1,1) PRIMARY KEY,
	Vare_Navn varchar(255),
	Beskrivelse varchar(255),
	Pris int,
	Afdeling varchar(255)
)
INSERT INTO Varre (Vare_Navn, Beskrivelse, Pris, Afdeling)
VALUES ('Æble', 'Frugt', 2, 'Frugt og grønt')
INSERT INTO Varre (Vare_Navn, Beskrivelse, Pris, Afdeling)
VALUES ('Kylling', 'Kød', 40, 'Frost')
INSERT INTO Varre (Vare_Navn, Beskrivelse, Pris, Afdeling)
VALUES ('Headset', 'Hardware', 200, 'IT')
INSERT INTO Varre (Vare_Navn, Beskrivelse, Pris, Afdeling)
VALUES ('Cola', 'Læskedrik', 20, 'Sodavand')
INSERT INTO Varre (Vare_Navn, Beskrivelse, Pris, Afdeling)
VALUES ('Matador mix', 'Slik', 30, 'Slik')