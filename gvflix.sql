CREATE DATABASE GVFLIX;
USE GVFLIX;
GO

CREATE TABLE Filme (
	ID int IDENTITY(1,1) PRIMARY KEY,
	nome varchar(255) NOT NULL,
	ano int
);

CREATE TABLE Ator (
	ID int IDENTITY(1,1) PRIMARY KEY,
	nome varchar(255) NOT NULL,
	nacionalidade varchar(255),
);

CREATE TABLE Usuario (
	ID int IDENTITY(1,1) PRIMARY KEY,
	nome varchar(255) NOT NULL,
	email varchar(255) NOT NULL,
	senha varchar(64) NOT NULL,
);

/* Insere os dados na tabela Ator*/
INSERT INTO dbo.Ator (NOME, NACIONALIDADE)
VALUES ('Keanu Reeves', 'Canadá'),('Pierce Brosnan', 'Irlanda'),('Katherine Zheta Jones', 'Japão'),
('Kate Winslet', 'Tunísia'),('Will Smith', 'Chile'),('Joseph Gordon-Levitt', 'EUA'),
('Victoria Justice', 'Itália'),('Vin Diesel', 'Brasil'),('Bruce Willis', 'Brasil'),
('Woody Harrelson', 'EUA'),('Chris Evans', 'EUA'),('Samuel L Jackson','EUA'),
('Jonah Hill', 'EUA'),('Robert Downey Jr', 'EUA'),('Lázaro Ramos', 'Brasil'),('John Travolta', 'USA');

/* Filme */
INSERT INTO dbo.Filme (NOME, ANO)
VALUES ('Matrix',  1997), ('O Homem que Copiava', 2001),('O Senhor dos Anéis', 2003),
('Titanic', 1997),('Hitch',2001),('Inception',2009),('Fast and Furious', 2007),
('Vingadores', 2010),('Matrix Reloaded', 2002),('Matrix Revolutions',2003),('Pulp Fiction', 1994),
('Ilha das Flores', 1999)

/* Usuários */
INSERT INTO dbo.Usuario(NOME, EMAIL, SENHA)
VALUES ('admin','admin@admin.com','admin'),('John Smith', 'johnsmith@gmail.com', '123456'),
('Bia Joe', 'biajoe@outlook.percom','789897'),('Parks Belle','kilokura@pop.com.br','1111111111'),
('Tony Montana', 'realtmontana@ibest.com.br', 'adasdasd'),('Harry Potter', 'hp@hewlett.com', 'inimigosdahp');