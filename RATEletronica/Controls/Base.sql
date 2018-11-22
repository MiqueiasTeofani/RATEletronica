
DROP TABLE Atendimentos;
DROP TABLE Requisicoes;
DROP TABLE Tecnicos;


use Manutencao
go

CREATE TABLE Tecnicos
(
	idTecnico int identity(1,1) primary key
	, tipo smallint default 0 -- {Tecnico, Empresa}
	, nome varchar(max)
	, email varchar(max)
	, telefone varchar(max)
	, endereco varchar(max)
	, numero smallint default 0
	, uf varchar(2)
	, cidade varchar(max)
	, bairro varchar(max)
	, contato varchar(max)
	, status bit default 1
	, dataCadastro datetime default getdate()
	, ultimaModificacao datetime 
	, modificadoPor varchar(30)
)

/*

insert into Tecnicos(nome, email, telefone, endereco, numero, bairro, cidade, uf, contato, status) values(@nome, @email, @telefone, @endereco, @numero, @bairro, @cidade, @uf, @contato, @status)
update Tecnicos set status = 0  where idTecnico = @idTecnico;
Select idTecnico, nome, email, telefone, endereco, numero, bairro, cidade, uf, contato FROM Tecnicos where status = 1;
update Tecnicos set  nome = @nome, email = @email, telefone = @telefone, endereco = @endereco, numero = @numero, bairro = @bairro, cidade = @cidade, uf = @uf, contato = @contato where idTecnico = @idTecnico;

Select idTecnico, nome, email, telefone, endereco, numero, bairro, cidade, uf, contato FROM Tecnicos where status = 1;

*/


CREATE TABLE Requisicoes
(
	idRequisicao int identity(1,1) primary key
	, idTecnico int references Tecnicos(idTecnico) not null
	, codigo varchar(15)
	, serie varchar(20)
	, tipoFalha smallint default 0 --{Qualidade, Operacional}
	, descricao varchar(max) not null
	, usuario varchar(max)
	, emailUsuario varchar(max)
	, foneUsuario varchar(max)
	, dataAbertura datetime default Getdate()
	, dataEncerramento datetime
	, status smallint default 0 --{Aberto, Aguardando atendimento, Aguardando peças/suprimentos, Encerrado}
)

/*

insert into Requisicoes (idTecnico, codigo, serie, tipoFalha, descricao, usuario, emailUsuario, foneUsuario, dataAbertura, status)
Values (@idTecnico, @codigo, @serie, @tipoFalha, @descricao, @usuario, @emailUsuario, @foneUsuario, @dataAbertura, @status)
select idRequisicao, idTecnico, codigo, serie, tipoFalha, descricao, usuario, emailUsuario, foneUsuario, dataAbertura, dataEncerramento, status from Requisicoes where status <> 0

Update Requisicoes set status = @status where idRequisicao = @idrequisicao;

Update Requisicoes set idTecnico = @idTecnico, tipoFalha = @tipoFalha, descricao = @descricao, usuario = @usuario
, emailUsuario = @emailUsuario, foneUsuario = @foneUsuario, dataEncerramento, status = @status
where idRequisicao = @idRequisicao


*/

CREATE TABLE Atendimentos
(
	idAtendimento int identity(1,1) primary key
	, idTecnico int references tecnicos(idTecnico) not null
	, idRequisicao int references Requisicoes(idrequisicao) null
	, serie varchar(20)
	, tipoAtendimento smallint default 0 --{MC, MP, etc}
	, dataPrevista datetime
	, dataAtendimento datetime
	, contador int
	, tempoViagem time
	, horaInicio time
	, horaFim time
	, iti1 varchar(2) default 'BC' --{BC, CC, CB}
	, km1 smallint
	, iti2 varchar(2) default 'BC' --{BC, CC, CB}
	, km2 smallint
	, cfm smallint default 0 -- Condição final de manutenção {Operacional, Precário, Parado}
	, csi smallint default 0 -- Condição solicitação material {Sem necessidade, Necessita de Peças, Necessita de Suprimentos, Necessita de Peças e Suprimentos}
	, observacoes varchar(max)
	, status bit default 1
)


/*

insert into Atendimentos(idTecnico, idRequisicao, serie, tipoAtendimento, dataPrevista, dataAtendimento, contador, tempoViagem
, horaInicio, horaFim, iti1, km1, iti2, km2, cfm, csi, observacoes)
Values(@idTecnico, @idRequisicao, @serie, @tipoAtendimento, @dataPrevista, @dataAtendimento, @contador, @tempoViagem, @horaInicio
, @horaFim, @iti1, @km1, @iti2, @km2, @cfm, @csi, @observacoes)

SELECT idAtendimento, idTecnico, idRequisicao, serie, tipoAtendimento, dataPrevista, dataAtendimento, contador, tempoViagem, horaInicio, horaFim, iti1, km1, iti2, km2, cfm, csi, observacoes
FROM Atendimentos WHERE  status = 1

*/
