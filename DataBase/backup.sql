create database spmedicalgroup
go

use spmedicalgroup
go

create table Clinica (
	IdClinica int primary key identity,
	NomeFantasia varchar(255) not null unique,
	Cnpj char(18) not null unique,
	RazaoSocial varchar (255) not null,
	Rua varchar(255) not null,
	Bairro varchar(255) not null,
	Cep char(9) not null,
	Numero int not null,
	Uf varchar (100) not null,
	Localidade varchar (100) not null,
	Complemento varchar(255),
	Telefone varchar(100) not null,
	HorarioAbre Time not null,
	HorarioFecha Time not null
);
go

create table Especialidade (
	IdEspecialidade int primary key identity,
	NomeEspecialidade varchar(255) not null unique
);
go

create table TipoUsuario (
	IdTipoUsuario int primary key identity,
	NomeTipoUsuario varchar(100) unique
);
go

create table Usuario (
	IdUsuario int primary key identity,
	Nome varchar(255) not null,
	Rg char(12) not null unique,
	Cpf char(14) not null unique,
	DataNascimento Date not null,
	Email varchar(255) not null,
	Senha varchar(255) not null,
	Rua varchar(255) not null,
	Bairro varchar(255) not null,
	Cep char(9) not null,
	Numero int not null,
	Uf varchar (100) not null,
	Localidade varchar (100) not null,
	Complemento varchar(255),
	Telefone varchar(255) not null,
	IdTipoUsuario int not null foreign key references TipoUsuario (IdTipoUsuario)
);
go

create table Medico (
	IdMedico int primary key identity,
	Crm char(8) not null unique,
	IdClinica int foreign key references Clinica (IdClinica),
	IdEspecialidade int foreign key references Especialidade (IdEspecialidade),
	IdUsuario int foreign key references Usuario (IdUsuario)
);
go



create table SituacaoConsulta (
	IdSituacaoConsulta int primary key identity,
	NomeSituacaoConsulta varchar(100) not null unique
);
go

create table Consulta (
	IdConsulta int primary key identity,
	DataConsulta datetime not null default getdate(),
	DescricaoPaciente varchar(255),
	IdMedico int not null foreign key references Medico (IdMedico),
	IdUsuario int not null foreign key references Usuario (IdUsuario),
	IdSituacaoConsulta int not null foreign key references SituacaoConsulta (IdSituacaoConsulta)
);
go

insert into TipoUsuario
values ('Paciente'),('Administrador'),('Medico')
go


insert into SituacaoConsulta
values ('Realizada'),('Cancelada'),('Agendada')
go

insert into Especialidade
values ('Acupuntura'),('Anestesiologia'),('Angiologia'),('Cardiologia'),('Cirurgia Cardiovascular'),('Cirurgia da Mão'),
('Cirurgia do Aparelho Digestivo'),('Cirurgia Geral'),('Cirurgia Pediátrica'),('Cirurgia Plástica'),('Cirurgia Torácica'),('Cirurgia Vascular'),('Dermatologia'),
('Radioterapia'),('Urologia'),('Pediatria'),('Psiquiatria')
go

insert into Clinica 
values ('Clinica Porsalle','86.400.902/0001-30','SP Medical Group','Alameda Barao de Limeira','Santa Cecilia','01202-002','539','São Paulo','São Paulo','','11 2541-2356','08:00','18:00');
go

insert into Usuario
values	('Administrador','11.111.111-1','111.111.111-11','01/01/0001','adm@adm.com','adm','adm','adm','adm','0','adm','adm','adm','adm','2'),
		('Ricardo Lemos','32.411.432-9','948.398.595-89','13/10/1983','ricardo.lemos@spmedicalgroup.com.br','235225435','Rua Estado de Israel','São Paulo','04022-000','240','São Paulo','São Paulo','complemnto empty','(11) 3456-7654','3'),
		('Roberto Possarle','43.522.510-1','948.398.591-03','13/10/1983','roberto.possarle@spmedicalgroup.com.br','235225435','Rua Estado de Israel','São Paulo','04022-000','240','São Paulo','São Paulo','complemnto empty','(11) 3456-7654','3'),
		('Helena Strada','43.522.510-0','948.398.592-22','13/10/1983','helena.souza@spmedicalgroup.com.br','235225435','Rua Estado de Israel','São Paulo','04022-000','240','São Paulo','São Paulo','complemnto empty','(11) 3456-7654','3'),
		('Ligia','43.522.543-5','948.398.590-00','13/10/1983','ligia@gmail.com','235225435','Rua Estado de Israel','São Paulo','04022-000','240','São Paulo','São Paulo','complemnto empty','(11) 3456-7654','1'),
		('Alexandre','32.654.345-7','948.398.598-23','23/07/2001','alexandre@gmail.com','426543457','Av. Paulista','Bela Vista','01310-200','1578','São Paulo','São Paulo','complemnto empty','(11) 1234-5678','1'),
		('Fernando','54.636.525-3','948.398.594-12','10/10/1978','fernando@gmail.com','646365253','Av. Ibirapuera','Indianopolis','04029-200','23','São Paulo','São Paulo','complemnto empty','(11) 2541-2356','1'),
		('Henrique','54.366.362-5','948.398.599-87','13/10/1985','henrique@gmail.com','643663625','R. Vitória','Vila São Jorge','03807-300','546','São Paulo','Barueri','complemnto empty','(11) 3422-2342','1'),
		('Joao','32.544.444-1','940.839.859-99','27/08/1975','joao@gmail.com','425444441','R. Ver. Geraldo de Camargo','Santa Luzia','02902-030','12','São Paulo','Ribeirão Pires','complemnto empty','(11) 7675-2313','1'),
		('Bruno','54.566.266-7','948.398.590-23','21/03/1972','bruno@gmail.com','345662667','Alameda dos Arapanés','Indianopolis','04524-001','7809','São Paulo','São Paulo','complemnto empty','(11) 5325-6532','1'),
		('Mariana','54.566.266-8','948.398.590-01','05/03/2018','mariana@gmail.com','445662668','R Sao Antonio','Vila Universal','02202-100','3272','São Paulo','Barueri','complemnto empty','(11) 4324-7431','1')
go

insert into Medico
values ('54356-SP','1','1', '2'),('53452-SP','1','2', '3'),('65463-SP','1','3', '4')
go

insert into Consulta (DescricaoPaciente,IdMedico,IdUsuario,IdSituacaoConsulta)
values ('Paciente está sobrevivendo','3','5','1'),('Paciente está triste','2','6','2'),('Paciente está bem','2','7','1'),
('Paciente está melhorando','2','10','1'),('Paciente está melhor do que nunca','1','9','1'),('Paciente está feliz','3','8','3'),
('Paciente está impaciente','1','7','3')
go

--mostrar a consulta do paciente
select c.DataConsulta, c.DescricaoPaciente, Usuario.Nome, SituacaoConsulta.NomeSituacaoConsulta
from Consulta c
inner join Usuario on Usuario.IdUsuario =  c.IdUsuario
inner join SituacaoConsulta on SituacaoConsulta.IdSituacaoConsulta = c.IdSituacaoConsulta
where Usuario.IdTipoUsuario = 1 

--mostrar a consulta do paciente e seu medico
select c.DataConsulta, c.DescricaoPaciente, Usuario.Nome as NomePaciente, SituacaoConsulta.NomeSituacaoConsulta
from Consulta c
inner join Usuario on Usuario.IdUsuario =  c.IdUsuario
inner join SituacaoConsulta on SituacaoConsulta.IdSituacaoConsulta = c.IdSituacaoConsulta
inner join Medico on Medico.IdMedico = c.IdMedico
where Usuario.IdTipoUsuario = 1

--mostrar o medico e sua respectiva especialidade
select m.Crm, Usuario.Nome, Especialidade.NomeEspecialidade
from Medico m
inner join Especialidade on Especialidade.IdEspecialidade = m.IdEspecialidade
inner join Usuario on Usuario.IdUsuario = m.IdUsuario

--mostrar o medico , especialidade e a clinica
select m.Crm, Usuario.Nome, Especialidade.NomeEspecialidade, Clinica.NomeFantasia
from Medico m
inner join Especialidade on Especialidade.IdEspecialidade = m.IdEspecialidade
inner join Clinica on Clinica.IdClinica = m.IdClinica
inner join Usuario on Usuario.IdUsuario = m.IdUsuario

--converter data de nascimento em MM/DD/YYYY)
select p.Nome ,CONVERT(varchar(10), DataNascimento, 110) AS [mm/dd/yyyy]
from Usuario p

--mostrar total de usuarios
select count(IdUsuario)
from Usuario

--calcular idade paciente
select	p.Nome, p.DataNascimento,
case when DATEPART(MONTH,p.DataNascimento)<= DATEPART(MONTH,GETDATE()) AND DATEPART(DAY,p.DataNascimento)<= DATEPART(DAY,GETDATE())
then (DATEDIFF(YEAR,p.DataNascimento,GETDATE())) else (DATEDIFF(YEAR,p.DataNascimento,GETDATE()))- 1 END AS Idade
from Usuario p

--procedure para consultar quantidade de medicos em determinada especialidade
create procedure MedicoEspecialidade 
@Quantd INT
AS
SELECT Usuario.Nome, Especialidade.NomeEspecialidade  FROM Medico
INNER JOIN Especialidade ON Medico.IdEspecialidade = Especialidade.IdEspecialidade
inner join Usuario on Usuario.IdUsuario = Medico.IdUsuario
WHERE Especialidade.IdEspecialidade = @Quantd

execute MedicoEspecialidade 1;

select * from Especialidade

