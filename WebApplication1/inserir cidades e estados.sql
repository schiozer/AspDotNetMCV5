



select * from dbo.estado

insert into dbo.estado (UF, Nome) values ('SP', 'S�o Paulo')
insert into dbo.estado (UF, Nome) values ('RJ', 'Rio de Janeiro')
insert into dbo.estado (UF, Nome) values ('PR', 'Paran�')
insert into dbo.estado (UF, Nome) values ('BA', 'Bahia')
insert into dbo.estado (UF, Nome) values ('MG', 'Minas Gerais')

select * from dbo.Cidade

insert into dbo.Cidade (EstadoID, Nome)
values (
	(Select EstadoID from dbo.estado where UF = 'SP'),
	'Itatiba'
)

insert into dbo.Cidade (EstadoID, Nome)
values (
	(Select EstadoID from dbo.estado where UF = 'SP'),
	'S�o Paulo'
)

insert into dbo.Cidade (EstadoID, Nome)
values (
	(Select EstadoID from dbo.estado where UF = 'RJ'),
	'Rio de Janeiro'
)

insert into dbo.Cidade (EstadoID, Nome)
values (
	(Select EstadoID from dbo.estado where UF = 'RJ'),
	'Teres�polis'
)

insert into dbo.Cidade (EstadoID, Nome)
values (
	(Select EstadoID from dbo.estado where UF = 'RJ'),
	'Itaipava'
)

insert into dbo.Cidade (EstadoID, Nome)
values (
	(Select EstadoID from dbo.estado where UF = 'RJ'),
	'B�zios'
)

insert into dbo.Cidade (EstadoID, Nome)
values (
	(Select EstadoID from dbo.estado where UF = 'BA'),
	'Salavador'
)