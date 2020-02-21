insert into Funcionarios (Nome, Sobrenome)
values  ('Catarina','Strada'),
		('Tadeu','Vitelli')
go

update Funcionarios
set DataNasc = '09-08-2001'
where IdFuncionario = 1;

update Funcionarios
set DataNasc = '23-03-2001'
where IdFuncionario = 2;