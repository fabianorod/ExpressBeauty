
create database ExpressBeauty
go

use ExpressBeauty
go

create table ufs
(
	sigla char(2) not null primary key,
	nome varchar(30) not null
)
go

create table cidades
(
	id int not null primary key identity,
	nome varchar(50) not null,
	uf_sigla char(2) not null references ufs
)
go

create table ceps
(
	numero varchar(10) not null primary key,
	cidade_id int not null references cidades
)
go

create table pessoas
(
	id int not null primary key identity,
	nome varchar(50) not null,
	cpf varchar(12) not null unique,
	idade int not null,
	logradouro varchar(200) not null,
	cep varchar(10) not null references ceps,
	sexo int not null,
	check(sexo in(1,2))
)
go

create table telefones
(
	pessoa_id int not null references pessoas,
	numero varchar(10) not null,
	ddd varchar(6) not null
	primary key (pessoa_id, numero, ddd)
)
go

create table emails
(
	pessoa_id int not null references pessoas,
	endereco varchar(50) not null,
	primary key (pessoa_id, endereco)
)
go

create table clientes
(
	pessoa_id int not null primary key references pessoas, 
	status int,
	check (status in (1,2,3,4))
)
go

create table profissionaisbeleza
(
	pessoa_id int not null primary key references pessoas,
	salario decimal(10,2) not null,
	status int,
	check (status in (1,2,3,4))
)
go

create table agendamentos
(
	numero int not null primary key identity,
	data_inicial DateTime not null,
	data_final DateTime,
	horario Time not null,
	status int,
	check (status in(1,2,3,4)),
	cliente_id int not null references clientes,
	profissional_id int not null references profissionaisbeleza
)
go

create table servicos
(
	id int not null primary key identity,
	valor decimal(10,2) not null,
	descricao varchar(75) not null
)
go

create table agendamentos_servicos
(
	agendamento_numero int not null references agendamentos,
	servico_id int not null references servicos,
	primary key(agendamento_numero, servico_id)
)
go

create table profissionais_servicos
(
	profissional_id int not null references profissionaisbeleza,
	servico_id int not null references servicos,
	primary key (profissional_id, servico_id)
)
go

-- Insercoes --
-- Ufs --

insert into ufs values ('RJ', 'Rio de Janeiro');
insert into ufs values ('SP', 'São Paulo');
insert into ufs values ('MG', 'Minas Gerais');

-- Cidades --

insert into cidades values ('Rio de Janeiro', 'RJ');
insert into cidades values ('São José do Rio Preto', 'SP');
insert into cidades values ('Poços de Caldas', 'MG');

-- Ceps --

insert into ceps values ('100', 1);
insert into ceps values ('200', 2);
insert into ceps values ('300', 3);

-- Pessoas --

insert into pessoas values ('Fulano', '123456789012', 30, 'Endereço 1', '100', 1);
insert into pessoas values ('Ciclano', '999999999999', 20, 'Endereço 2', '200', 2);
insert into pessoas values ('Deltrano', '098765432109', 60, 'Endereço 3', '300', 3);
insert into pessoas values ('Mano', '123456789099', 30, 'Endereço 1', '100', 1);
insert into pessoas values ('Cara','000000000000', 20, 'Endereço 2', '200', 2);
insert into pessoas values ('Malandro', '123123123123', 60, 'Endereço 3', '300', 3);

-- Telefones --

insert into telefones values (1, '1319-4190', '234');
insert into telefones values (1, '99051-9910', '234');
insert into telefones values (3, '3098-4126', '000');

-- Emails --

insert into emails values (2, 'ciclano@hotmail.com');
insert into emails values (2, 'ciclano@gmail.com');
insert into emails values (3, 'deltrano@hotmail.com');

-- Clientes -- 

insert into clientes values (1, 3);
insert into clientes values (2, 2);
insert into clientes values (3, 1);

-- Profissionais Beleza -- 

insert into profissionaisbeleza values (4, 500.22, 1);
insert into profissionaisbeleza values (5, 510.22, 2);
insert into profissionaisbeleza values (6, 520.22, 3);

-- Agendamentos --

insert into agendamentos values ('09/09/2014 12:12', '09/09/2014 12:45','12:12', 1, 1, 4);
insert into agendamentos values ('09/09/2014 11:11', '09/09/2014 11:30', '11:11', 3, 2, 5);
insert into agendamentos values ('09/09/2014 11:44', '09/09/2014 12:00','11:44', 2, 3, 6);

-- Servicos --

insert into servicos values (12.00, 'Cortar Cabelo');
insert into servicos values (10.00, 'Fazer Unha');
insert into servicos values (15.00, 'Alizamento');

-- Agendamentos_Servicos --

insert into agendamentos_servicos values (1, 2);
insert into agendamentos_servicos values (2, 1);
insert into agendamentos_servicos values (3, 3);

-- Profissionais_Servicos --

insert into profissionais_servicos values (4, 1);
insert into profissionais_servicos values (5, 2);
insert into profissionais_servicos values (6, 3);

-- Views --
-- Ufs --

create view v_ufs
as
	select u.sigla Sigla,
		   u.nome Nome
	from ufs u
	
	select * from v_ufs
	
	
-- Cidades --

create view v_cidades
as
	select c.id Id,
		   c.nome Nome,
		   c.uf_sigla Sigla
	from cidades c
	
	select * from v_cidades
	
	
-- Ceps --

create view v_ceps
as
	select cp.numero Numero,
		   cp.cidade_id Cidade
	from ceps cp
	
	select * from v_ceps
	
	
-- Ceps, Cidades, Ufs --

create view v_ccu
as
	select u.sigla Sigla,
		   u.nome Estado,
		   c.nome Cidade,
		   cp.numero CEP
	from ufs u, cidades c, ceps cp
	where u.sigla = c.uf_sigla and
		  c.id = cp.cidade_id
	
	select * from v_ccu
	
-- Pessoas --

create view v_pessoas
as
	select p.id Id,
		   p.nome Nome,
		   p.cpf CPF,
		   p.idade Idade,
		   p.logradouro Endereco,
		   p.cep CEP,
		   p.sexo Sexo
	from pessoas p
	
	select * from v_pessoas
	
-- Telefones --

create view v_telefones
as
	select p.id Id,
		   p.nome Nome,
		   t.numero Numero,
		   t.ddd DDD
	from telefones t, pessoas p
	where p.pessoas = t.pessoa_id
	
	select * from v_telefones
	
-- Emails --

create view v_emails
as
	select p.id Id,
		   p.nome Nome,
		   e.endereco Email
	from emails e, pessoas p
	where p.pessoas = e.pessoa_id
	
	select * from v_emails
	
-- Telefones e Emails --

create view v_tel_emails
as
	select p.id Id,
		   p.nome Nome,
		   e.endereco Email,
		   t.numero Numero,
		   t.ddd DDD
	from emails e, pessoas p, telefones t
	where p.pessoas = e.pessoa_id and
		  p.pessoas = t.telefones
	
	select * from v_tel_emails

-- Clientes --

create view v_clientes
as
	select p.id Id,
		   p.nome Nome,
		   p.cpf CPF,
		   p.idade Idade,
		   p.logradouro Endereco,
		   p.cep CEP,
		   p.sexo Sexo,
		   cl.status 'Status'
	from clientes cl, pessoas p
	where p.pessoas = cl.pessoa_id
	
	select * from v_clientes
	
-- Profissional Beleza --

create view v_pbeleza
as
	select p.id Id,
		   p.nome Nome,
		   p.cpf CPF,
		   p.idade Idade,
		   p.logradouro Endereco,
		   p.cep CEP,
		   p.sexo Sexo,
		   pb.salario Salario,
		   pb.status 'Status'
	from profissionaisbeleza pb, pessoas p
	where p.pessoas = pb.pessoa_id
	
	select * from v_pbeleza


-- Agendamentos --

create view v_agendamentos
as
	select a.numero Numero,
		   a.data_inicial Data Incial,
		   a.data_final Data Final,
		   a.horario Horario,
		   a.status 'Status',
		   cl.pessoa_id ID Cliente,
		   pb.pessoa_id ID Profissional
	from agendamentos a, clientes cl, profissionaisbeleza
	where a.cliente_id = cl.pessoa_id and
		  a.cliente_id = pb.pessoa_id
	select * from v_agendamentos
	
-- Servicos --

create view v_servicos
as
	select s.id Id,
		   s.valor Preco,
		   s.descricao Descricao
	from servicos s
	select * from v_servicos
	
-- Agendamentos_Servicos --

create view v_agenda_servicos
as
	select ags.servico_id Id Servico,
		   ags.agendamento_numero Numero do Agendamento,
	from agendamentos_servicos ags
	select * from v_agenda_servicos
	
-- Profissionais_Servicos --

create view v_profissionais_servicos
as
	select ps.profissional_id Id Profissional,
		   ps.agendamento_numero Numero do Agendamento,
	from profissionais_servicos ps
	select * from v_profissionais_servicos
	
-- Procedures --
-- Ufs --

create procedure ufAdd
(
    @sigla char(2),
    @nome varchar(30)
)
as
begin
     insert into ufs values (@sigla, @nome)
end

ufAdd 'SP', 'Sao Paulo'

create procedure ufAlt
(
    @sigla char(2),
    @nome varchar(30)
)
as
begin
     update ufs set
			sigla = @sigla,
			nome = @nome
	 where sigla = @sigla
end

ufAlt 'RJ','Rio de Janeiro'

-- Cidades --

create procedure cidadeAdd
(
    @id int,
    @nome varchar(50),
    @uf_sigla char(2)
)
as
begin
     insert into cidades values (@nome, @uf_sigla)
end

cidadeAdd 'Sao Paulo', 'SP'

create procedure cidadeAlt
(
    @id int,
    @nome varchar(50),
    @uf_sigla char(2)
)
as
begin
     update cidades set
			nome = @nome,
			uf_sigla = @uf_sigla
	 where id = @id
end

cidadeAlt 'Rio de Janeiro', 'RJ'

-- Ceps --

create procedure cepAdd
(
    @numero varchar(50),
    @cidade_id int
)
as
begin
     insert into ceps values (@numero, @cidade_id)
end

cepAdd '1010101010', '1'

create procedure cepAlt
(
    @numero varchar(50),
    @cidade_id int
)
as
begin
     update ceps set
			numero = @numero,
			cidade_id = @cidade_id
	 where numero = @numero
end

cepAlt '2020202020', '2'

-- Pessoas --

create procedure pessoaAdd
(
    @id int,
    @nome varchar(50),
    @cpf varchar(12),
    @idade int,
    @logradouro varchar(200),
    @cep varchar(10),
    @sexo int
)
as
begin
     insert into pessoas values (@nome, @cpf, @idade, @logradouro, @cep, @sexo)
end

pessoaAdd 'Maria','123412341234', 90, 'Casa 1 Rua 1', '100', 2

create procedure pessoaAlt
(
    @id int,
    @nome varchar(50),
    @cpf varchar(12),
    @idade int,
    @logradouro varchar(200),
    @cep varchar(10),
    @sexo int
)
as
begin
     update pessoas set
			nome = @nome,
			cpf = @cpf,
			idade = @idade,
			logradouro = @logradouro
			cep = @cep
			sexo = @sexo
	 where id = @id
end

pessoaAlt 'Mario','9090909090', 50, 'Casa 2 Rua 2', '200', 1

-- Telefones --

create procedure telefoneAdd
(
    @pessoa_id int,
    @numero varchar(10),
    @ddd varchar(6)
)
as
begin
     insert into telefones values (@pessoa_id, @numero, @ddd)
end

telefoneAdd 7, '99000-0000', '000'

create procedure telefoneAlt
(
    @pessoa_id int,
    @numero varchar(10),
    @ddd varchar(6)
)
as
begin
     update telefones set
			pessoa_id = @pessoa_id,
			numero = @numero,
			ddd = @ddd
	 where pessoa_id = @pessoa_id
end

telefoneAlt 7, '88000-000', '111'

-- Emails --

create procedure emailAdd
(
    @pessoa_id int,
    @endereco varchar(50)
)
as
begin
     insert into emails values (@pessoa_id, @endereco)
end

emailAdd 7, 'maria@gmail.com'

create procedure emailAlt
(
    @pessoa_id int,
    @endereco varchar(50)
)
as
begin
     update emails set
			pessoa_id = @pessoa_id,
			endereco = @endereco
	 where pessoa_id = @pessoa_id
end

emailAlt 7, 'mario@gmail.com'

-- Clientes --

create procedure clienteAdd
(
    @pessoa_id int,
    @status int
)
as
begin
     insert into clientes values (@pessoa_id, @status)
end

clienteAdd 7, 1

create procedure clienteAlt
(
    @pessoa_id int,
    @status int
)
as
begin
     update clientes set
			pessoa_id = @pessoa_id,
			status = @status
	 where pessoa_id = @pessoa_id
end

clienteAlt 7, 2

-- Profissionais Beleza --

create procedure pbelezaAdd
(
    @pessoa_id int,
    @salario decimal(10,2),
    @status int
)
as
begin
     insert into profissionaisbeleza values (@pessoa_id, @salario, @status)
end

pbelezaAdd 8, 600.99, 1

create procedure pbelezaAlt
(
    @pessoa_id int,
    @salario decimal(10,2),
    @status int
)
as
begin
     update profissionaisbeleza set
			pessoa_id = @pessoa_id,
			salario = @salario,
			status = @status
	 where pessoa_id = @pessoa_id
end

pbelezaAlt 7, 552.10, 2

-- Agendamentos --

create procedure agendamentoAdd
(
    @numero int,
    @data_inicial DateTime,
    @data_final DateTime,
    @horario Time,
    @status int,
    @cliente_id int,
    @profissional_id int
)
as
begin
     insert into agendamentos values (@data_inicial, @data_final, @horario, @status, @cliente_id, @profissional_id)
end

agendamentoAdd 10/10/2014 20:00, 20:00, 1, 2, 6

create procedure agendamentoAlt
(
    @numero int,
    @data_inicial DateTime,
    @data_final DateTime,
    @horario Time,
    @status int,
    @cliente_id int,
    @profissional_id int
)
as
begin
     update agendamentos set
			data_inicial = @data_inicial,
			data_final = @data_final,
			horario = @horario,
			status = @status,
			cliente_id = @cliente_id,
			profissional_id = @profissional_id
	 where numero = @numero
end

agendamentoAlt 10/10/2014 20:00, 10/10/2014 21:00, 20:00, 1, 2, 6

-- Servicos --

create procedure servicoAdd
(
    @id int,
    @valor decimal(10,2),
    @descricao varchar(75)
)
as
begin
     insert into servicos values (@valor, @descricao)
end

servicoAdd 9.00, 'Maquiagem'

create procedure servicoAlt
(
    @id int,
    @valor decimal(10,2),
    @descricao varchar(75)
)
as
begin
     update servicos set
			valor = @valor,
			descricao = @descricao
	 where id = @id
end

servicoAlt 10.00,'Maquiagem'

-- Agendamento_Servicos --

create procedure agenda_servicoAdd
(
    @agendamento_numero int,
    @servico_id int
)
as
begin
     insert into agendamentos_servicos values (@agendamento_numero, @servico_id)
end

agenda_servicoAdd 4,1

create procedure agenda_servicoAlt
(
    @agendamento_numero int,
    @servico_id int
)
as
begin
     update agendamentos_servicos set
			agendamento_numero = @agendamento_numero,
			servico_id = @servico_id
	 where agendamento_numero = @agendamento_numero
end

agenda_servicoAlt 5,2

-- Profissionais_Servicos --

create procedure profissional_servicoAdd
(
    @profissional_id int,
    @servico_id int
)
as
begin
     insert into profissionais_servicos values (@profissional_id, @servico_id)
end

profissional_servicoAdd 6,3

create procedure agenda_servicoAlt
(
    @agendamento_numero int,
    @servico_id int
)
as
begin
     update profissionais_servicos set
			profissional_servico = @profissional_servico,
			servico_id = @servico_id
	 where profissional_id = @profissional_id
end

profissional_servicoAlt 5,2
