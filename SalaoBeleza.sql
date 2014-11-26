
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

create table pessoas
(
	id int not null primary key identity,
	nome varchar(50) not null,
	cpf varchar(12) not null unique,
	cep varchar(20) not null,
	datanascimento date not null,
	logradouro varchar(200) not null,
	nome_usuario varchar(50) not null unique,
	senha varchar(50) not null,
	sexo int not null,
	cidade_id int references cidades
)
go

create table telefones
(
	pessoa_id int not null references pessoas,
	numero varchar(16) not null,
	tipo varchar(20)
	primary key (pessoa_id, numero)
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
	tipo_permicao int,
	check (tipo_permicao in (1,2))
)
go

select * from profissionaisbeleza pb, pessoas p
where pb.pessoa_id = p.id

select * from clientes c, pessoas p
where c.pessoa_id = p.id

select * from telefones

create table agendamentos
(
	id int not null primary key identity,
	data_agendamento Date not null,
	data_realizacao Date not null,
	horario Time not null,
	status int,
	check (status in(1,2,3)),
	cliente_id int not null references clientes,
)
go

create table servicos
(
	id int not null primary key identity,
	nome varchar(50),
	valor decimal(10,2) not null,
	descricao varchar(75) not null
)
go

create table agendamentos_servicos
(
	agendamento_numero int not null references agendamentos,
	servico_id int not null references servicos,
	profissional_id int references profissionaisbeleza,
	primary key(agendamento_numero, servico_id)
)
go

-- Insercoes --
-- Ufs --
insert into ufs  values
	('MG', 'Minas Gerais'),
	('RJ', 'Rio de Janeiro'),
	('SP', 'São Paulo');
go
-- Cidades --

insert into cidades values ('Rio de Janeiro', 'RJ'),
                           ('São José do Rio Preto', 'SP'), 
				           ('Poços de Caldas', 'MG'); 
go

-- Pessoas --

insert into pessoas values ('Fulano', '123456789012', '15120333', '1995/01/01', 'Endereço 1', 'Fulanão', '123qweasdzxc', 1, 1);
insert into pessoas values ('Ciclano', '999999999999', '15120555', '1992/01/30', 'Endereço 2', 'Cil', '123', 2,2);
insert into pessoas values ('Deltrano', '098765432109', '15150333', '1988/12/09', 'Endereço 3', 'D', '321', 3, 3);
insert into pessoas values ('Mano', '123456789099', '15000333','1980/09/08', 'Endereço 1', 'Man', 'lol', 1, 1);
insert into pessoas values ('Cara','000000000000', '16155533', '1999/12/12', 'Endereço 2', 'C', '123', 2, 2);
insert into pessoas values ('Karen', '123123123123', '18000333', '1991/12/21', 'Endereço 3', 'Karen', '123', 3,3);

-- Telefones --

insert into telefones values (1, '1319-4190', 'celular');
insert into telefones values (1, '99051-9910', 'casa');
insert into telefones values (3, '3098-4126', 'trabalho');


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

insert into agendamentos values ('09/09/2014', '09/09/2014','12:12', 1, 1);
insert into agendamentos values ('09/09/2014', '09/09/2014', '11:11', 3, 2);
insert into agendamentos values ('09/09/2014', '09/09/2014','11:44', 2, 3);

-- Servicos --

insert into servicos values (12.00, 'Cortar Cabelo');
insert into servicos values (10.00, 'Fazer Unha');
insert into servicos values (15.00, 'Alisamento');

-- Agendamentos_Servicos --

insert into agendamentos_servicos values (1, 2, 4);
insert into agendamentos_servicos values (2, 1, 5);
insert into agendamentos_servicos values (3, 3, 6);

-- Views --
-- Ufs --

create view v_ufs
as
	select u.sigla Sigla,
		   u.nome Nome
	from ufs u
	
-- Teste -- 

	select * from v_ufs
	
	
-- Cidades --

create view v_cidades
as
	select c.id Id,
		   c.nome Nome,
		   c.uf_sigla Sigla
	from cidades c

-- Teste -- 
	
	select * from v_cidades
	
	
-- Pessoas --

create view v_pessoas
as
	select p.id Id,
		   p.nome Nome,
		   p.cpf CPF,
		   p.cep CEP,
		   p.datanascimento DataNascimento,
		   p.logradouro Endereco,
		   p.nome_usuario NomeDeUsuario,
		   p.senha Senha,
		   p.sexo Sexo,
		   p.cidade_id Cidade
		   
	from pessoas p

-- Teste -- 
	
	select * from v_pessoas
	
-- Telefones --

create view v_telefones
as
	select p.id Id,
		   p.nome Nome,
		   t.numero Numero,
		   t.tipo Tipo
	from telefones t, pessoas p
	where p.id = t.pessoa_id

-- Teste -- 
	
	select * from v_telefones
	
-- Emails --

create view v_emails
as
	select p.id Id,
		   p.nome Nome,
		   e.endereco Email
	from emails e, pessoas p
	where p.id = e.pessoa_id

-- Teste -- 
	
	select * from v_emails
	
-- Telefones e Emails --

create view v_tel_emails
as
	select p.id Id,
		   p.nome Nome,
		   e.endereco Email,
		   t.numero Numero,
		   t.tipo Tipo
	from emails e, pessoas p, telefones t
	where p.id = e.pessoa_id and
		  p.id = t.pessoa_id

-- Teste -- 
	
	select * from v_tel_emails

-- Clientes --

create view v_clientes
as
	select p.id Id,
		   p.nome Nome,
		   p.cpf CPF,
		   p.cep CEP,
		   p.datanascimento DataNascimento,
		   p.logradouro Endereco,
		   p.sexo Sexo,
		   p.cidade_id Cidade,
		   cl.status 'Status'
	from clientes cl, pessoas p
	where p.id = cl.pessoa_id

-- Teste -- 
	
	select * from v_clientes
	
-- Profissional Beleza --

create view v_pbeleza
as
	select p.id Id,
		   p.nome Nome,
		   p.cpf CPF,
		   p.cep CEP,
		   p.datanascimento DataNascimento,
		   p.logradouro Endereco,
		   p.sexo Sexo,
		   p.cidade_id Cidade,
		   pb.salario Salario,
		   pb.tipo_permicao 'Status'
	from profissionaisbeleza pb, pessoas p
	where p.id = pb.pessoa_id

-- Teste -- 
	
	select * from v_pbeleza


-- Agendamentos --

create view v_agendamentos
as
	select a.id Numero,
		   a.data_agendamento DataAgendamento,
		   a.data_realizacao DataRealizacao,
		   a.horario Horario,
		   a.status 'Status',
		   cl.pessoa_id IDCliente
	from agendamentos a, clientes cl
	where a.cliente_id = cl.pessoa_id


		  -- Teste -- 

	select * from v_agendamentos
	
-- Servicos --

create view v_servicos
as
	select s.id Id,
		   s.valor Preco,
		   s.descricao Descricao
	from servicos s

	-- Teste -- 

	select * from v_servicos
	
-- Agendamentos_Servicos --

create view v_agenda_servicos
as
	select ags.servico_id IdServico,
		   ags.agendamento_numero NumeroDoAgendamento,
		   ags.profissional_id Profissional
	from agendamentos_servicos ags

	-- Teste -- 

	select * from v_agenda_servicos

-- Procedures --
-- Ufs Adicionar--

create procedure ufAdd
(
    @sigla char(2),
    @nome varchar(30)
)
as
begin
     insert into ufs values (@sigla, @nome)
end

-- Teste --

execute ufAdd 'SP', 'Sao Paulo'

-- Ufs Alterar --

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

-- Teste --

execute ufAlt 'RJ','Rio de Janeiro'

-- Cidades Adicionar--

create procedure cidadeAdd
(
    @nome varchar(50),
    @uf_sigla char(2)
)
as
begin
     insert into cidades values (@nome, @uf_sigla)
end

-- Teste --

execute cidadeAdd 'Sao Paulo', 'SP'

-- Cidades Alterar --

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

-- Teste --

execute cidadeAlt 4, 'Rio de Janeiro', 'RJ'




-- Pessoas Adicionar--

create procedure pessoaAdd
(
    @nome varchar(50),
    @cpf varchar(12),
	@cep varchar(10),
    @data_nascimento date,
    @logradouro varchar(200),
    @nome_usuario varchar(50),
	@senha varchar(50),
    @sexo int,
	@cidade int
)
as
begin
     insert into pessoas values (@nome, @cpf, @cep, @data_nascimento, @logradouro, @sexo, @cidade)
end
-- Teste --

execute pessoaAdd 'Maria','123412341234', '15120665', '2000/01/01', 'Casa 1 Rua 1', 'Usuario','senha', 2, 2

--Pessoas Alterar--

create procedure pessoaAlt
(
    @id int,
    @nome varchar(50),
    @cpf varchar(12),
	@cep varchar(10),
	@data_nascimento date,
    @logradouro varchar(200),
    @nome_usuario varchar(50),
	@senha varchar(50),
    @sexo int,
	@cidade int

)
as
begin
     update pessoas set
			nome = @nome,
			cpf = @cpf,
			cep = @cep,
			datanascimento = @data_nascimento,
			logradouro = @logradouro,
			nome_usuario = @nome_usuario,
			senha = @senha,
			sexo = @sexo,
			cidade_id = @cidade
			
	 where id = @id
end

-- Teste --

execute pessoaAlt 7, 'Mario','9090909090', '19100665', '1990/13/12', 'Casa 2 Rua 2', 'Eu', 'Senha', 1, '200'

-- Telefones Adicionar--

create procedure telefoneAdd
(
    @pessoa_id int,
    @numero varchar(16),
    @tipo varchar(20)
)
as
begin
     insert into telefones values (@pessoa_id, @numero, @tipo)
end

-- Teste --

execute telefoneAdd 7, '99000-0000', 'celular'

-- Telefones Alterar --

create procedure telefoneAlt
(
    @pessoa_id int,
    @numero varchar(16),
    @tipo varchar(20)
)
as
begin
     update telefones set
			pessoa_id = @pessoa_id,
			numero = @numero,
			tipo = @tipo
	 where pessoa_id = @pessoa_id
end

-- Teste --

execute telefoneAlt 7, '88000-000', 'casa'

-- Emails Adicionar --

create procedure emailAdd
(
    @pessoa_id int,
    @endereco varchar(50)
)
as
begin
     insert into emails values (@pessoa_id, @endereco)
end

-- Teste --

execute emailAdd 7, 'maria@gmail.com'

-- Email Alterar --

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

-- Teste --

execute emailAlt 7, 'mario@gmail.com'

-- Clientes Adicionar --

create procedure clienteAdd
(
    @pessoa_id int,
    @status int
)
as
begin
     insert into clientes values (@pessoa_id, @status)
end

-- Teste --

execute clienteAdd 7, 1

-- Clientes Alterar--

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

-- Teste --

execute clienteAlt 7, 2

-- Profissionais Beleza Adicionar--

create procedure pbelezaAdd
(
    @pessoa_id int,
    @salario decimal(10,2),
    @tipo_permicao int
)
as
begin
     insert into profissionaisbeleza values (@pessoa_id, @salario, @tipo_permicao)
end

-- Teste --

execute pbelezaAdd 8, 600.99, 1

-- Profissionais Beleza Alterar --

create procedure pbelezaAlt
(
    @pessoa_id int,
    @salario decimal(10,2),
    @tipo_permicao int
)
as
begin
     update profissionaisbeleza set
			pessoa_id = @pessoa_id,
			salario = @salario,
			tipo_permicao = @tipo_permicao
	 where pessoa_id = @pessoa_id
end

-- Teste --

execute pbelezaAlt 7, 552.10, 2

-- Agendamentos Adicionar --

create procedure agendamentoAdd
(
    @numero int,
    @data_agendamento DateTime,
    @data_realizacao DateTime,
    @horario Time,
    @status int,
    @cliente_id int
)
as
begin
     insert into agendamentos values (@data_agendamento, @data_realizacao, @horario, @status, @cliente_id)
end

-- Teste --

execute agendamentoAdd 4, '2014/19/29', null,'20:00', 1, 2

-- Agendamento Alterar --

create procedure agendamentoAlt
(
    @id int,
    @data_agendamento Date,
    @data_realizacao Date,
    @horario Time,
    @status int,
    @cliente_id int
)
as
begin
     update agendamentos set
			data_agendamento = @data_agendamento,
			data_realizacao = @data_realizacao,
			horario = @horario,
			status = @status,
			cliente_id = @cliente_id
	 where id = @id
end

-- Teste --

execute agendamentoAlt 2, '10/10/2014', '10/10/2014', '20:00', 1, 2

-- Servicos Adicionar --

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

-- Teste --

execute servicoAdd 4 ,9.00, 'Maquiagem'

-- Servico Alterar --

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

-- Teste --

execute servicoAlt 4,10.00,'Maquiagem'

-- Agendamento_Servicos Adicionar --

create procedure agenda_servicoAdd
(
    @agendamento_numero int,
    @servico_id int,
	@profissional_id int
)
as
begin
     insert into agendamentos_servicos values (@agendamento_numero, @servico_id, @profissional_id)
end

-- Teste --

execute agenda_servicoAdd 4,1,4

-- Agendamento_Servico Alterar --

create procedure agenda_servicoAlt
(
    @agendamento_numero int,
    @servico_id int,
	@profissional_id int
)
as
begin
     update agendamentos_servicos set
			agendamento_numero = @agendamento_numero,
			servico_id = @servico_id,
			profissional_id = @profissional_id
	 where agendamento_numero = @agendamento_numero
end

-- Teste --

execute agenda_servicoAlt 5,2,1

