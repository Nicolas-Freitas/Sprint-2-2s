create database Filmes;

use Filmes 

create table Genero (
IdGenero int primary key identity,
Nome varchar(200)
);

create table Filme (
IdFilme int primary key identity,
Titulo varchar(200),
IdGenero int foreign key references Genero (IdGenero)
)

insert into Genero (Nome)
values ('Ação')

insert into Filme (Titulo,IdGenero)
values ('Furiosos muito velozes vrum vrum relampago marquinhos grau de moto',1)

select * from Filme

select Titulo,Genero.Nome from Filme 
inner join Genero on Filme.IdGenero = Genero.IdGenero
