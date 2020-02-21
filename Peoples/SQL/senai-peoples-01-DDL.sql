create database M_Peoples
go
use M_Peoples
go

create table Funcionarios (
	IdFuncionario int primary key identity,
	Nome varchar (100) not null,
	Sobrenome varchar (100) not null
)

alter table Funcionarios 
add DataNasc date 