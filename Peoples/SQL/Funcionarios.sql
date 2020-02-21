create database M_Peoples
go
use M_Peoples
go

create table Funcionarios (
	IdFuncionario int primary key identity,
	Nome varchar (100) not null,
	Sobrenome varchar (100) not null
)
go
insert into Funcionarios (Nome, Sobrenome)
values  ('Catarina','Strada'),
		('Tadeu','Vitelli')
go

alter table Funcionarios 
add DataNasc date 

update Funcionarios
set DataNasc = '09-08-2001'
where IdFuncionario = 1;

update Funcionarios
set DataNasc = '23-03-2001'
where IdFuncionario = 2;


select * from Funcionarios

select IdFuncionario, Nome, Sobrenome from Funcionarios where Nome like  'Catarina'




