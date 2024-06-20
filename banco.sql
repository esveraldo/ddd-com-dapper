-- ---------------------------------------------------------------------------------
-- DOMAIN DRIVEN DESIGN
-- ME.EXPRESS
-- Criado para o curso IMPACTA DDD por Eduardo Grasso (eduardo.grasso@live.com)
-- --------------------------------------------------------------------------------


------------------------------------------------------
-- BANCO DE DADOS
------------------------------------------------------
USE master;
GO

CREATE DATABASE MeExpressDB;
GO

USE MeExpressDB;
GO

------------------------------------------------------
-- TABELA: Cliente
------------------------------------------------------
CREATE TABLE Cliente(
 Id varchar(36) PRIMARY KEY,
 Nome varchar(100),
 Email varchar(100),
 CPF varchar(18),
 Empresa varchar(100),
 Endereco varchar(100),
 Numero varchar(20),
 Complemento varchar(20),
 Bairro varchar(100),
 Cidade varchar(100),
 Estado varchar(2),
 CEP varchar(9)
);
GO

------------------------------------------------------
-- TABELA: Produto
------------------------------------------------------
CREATE TABLE Produto(
 Id varchar(36) PRIMARY KEY,
 Nome varchar(100) NOT NULL,
 Preco money
);
GO

INSERT INTO Produto(Id, Nome, Preco) VALUES('84148464-6689-4db2-a044-d5bcd0edff00', 'Papel A4 - Bloco 500 fl', 21.50);
INSERT INTO Produto(Id, Nome, Preco) VALUES('c0f6707e-98cd-4f0c-93f9-a31f0dd56a80', 'Caneta Esferográfica ', 1.00);
INSERT INTO Produto(Id, Nome, Preco) VALUES('0a2e1771-96f1-4812-97bf-7415a3d4c715', 'Lapis HB', 1.50);
INSERT INTO Produto(Id, Nome, Preco) VALUES('9b84a176-3b4b-4a64-a3d7-68a6956cddc3', 'Caneta Esferográfica ', 1.00);
INSERT INTO Produto(Id, Nome, Preco) VALUES('4571cd3a-9045-44c2-a0e3-f5214e4c9404', 'Toner para Impressora Lazer', 120.00);
GO

------------------------------------------------------
-- TABELA: PedidoStatus
------------------------------------------------------
CREATE TABLE PedidoStatus(
Id int Primary Key,
Nome varchar(50)
);
GO

INSERT INTO PedidoStatus(Id,Nome) VALUES(1, 'Solicitado');
INSERT INTO PedidoStatus(Id,Nome) VALUES(2, 'Em Produção');
INSERT INTO PedidoStatus(Id,Nome) VALUES(3, 'Produzido');
INSERT INTO PedidoStatus(Id,Nome) VALUES(4, 'Em Transporte');
INSERT INTO PedidoStatus(Id,Nome) VALUES(5, 'Entregue');
GO

------------------------------------------------------
-- TABELA: Pedido
------------------------------------------------------
CREATE TABLE Pedido(
Id varchar (36) Primary Key,
Numero int Identity(1,1),
DataSolicitado DateTime NOT NULL,
DataEmProducao DateTime,
DataProduzido DateTime,
DataEmTransporte DateTime,
DataEntregue DateTime,
PedidoStatusId int FOREIGN KEY REFERENCES PedidoStatus(Id),
ClienteId varchar(36) FOREIGN KEY REFERENCES Cliente(Id),
ClienteNome varchar(100),
ClienteEmail varchar(100),
ClienteCPF varchar(18),
ClienteEmpresa varchar(100),
ClienteEndereco varchar(100),
ClienteNumero varchar(20),
ClienteComplemento varchar(20),
ClienteBairro varchar(100),
ClienteCidade varchar(100),
ClienteEstado varchar(2),
ClienteCep varchar(9)
);
GO

------------------------------------------------------
-- TABELA: PedidoProdutoItem
------------------------------------------------------
CREATE TABLE PedidoProdutoItem(
Id varchar (36) Primary Key,
PedidoId varchar(36) FOREIGN KEY REFERENCES Pedido(Id),
ProdutoId varchar(36) FOREIGN KEY REFERENCES Produto(Id),
ProdutoNome varchar(100),
ProdutoPreco money,
Quantidade int
);
GO




------------------------------------------------------
-- STORED Procedures: PedidoIncluir
------------------------------------------------------
CREATE PROCEDURE PedidoIncluir

@Id varchar(36),
@DataSolicitado DateTime,
@ClienteId varchar(36),
@ClienteNome varchar(100),
@ClienteEmail varchar(100),
@ClienteEmpresa varchar(100),
@ClienteEndereco varchar(100),
@ClienteNumero varchar(20),
@ClienteComplemento varchar(20),
@ClienteBairro varchar(100),
@ClienteCidade varchar(100),
@ClienteEstado varchar(2),
@ClienteCPF varchar(14),
@ClienteCEP varchar(9),
@PedidoStatusId int
AS

INSERT INTO Pedido(Id,DataSolicitado,ClienteId,ClienteNome,ClienteEmail,ClienteEmpresa,ClienteEndereco,ClienteNumero,ClienteComplemento,ClienteBairro,ClienteCidade,ClienteEstado,ClienteCPF,ClienteCEP,PedidoStatusId)
VALUES (@Id, @DataSolicitado, @ClienteId, @ClienteNome, @ClienteEmail, @ClienteEmpresa, @ClienteEndereco, @ClienteNumero, @ClienteComplemento, @ClienteBairro, @ClienteCidade, @ClienteEstado, @ClienteCPF,@ClienteCEP, @PedidoStatusId);

GO

------------------------------------------------------
-- STORED Procedures: PedidoProdutoIncluir
------------------------------------------------------
CREATE PROCEDURE PedidoProdutoIncluir

@Id varchar(36),
@PedidoId varchar(36),
@ProdutoId varchar(36),
@ProdutoNome varchar(100),
@ProdutoPreco money,
@Quantidade int
AS

INSERT INTO PedidoProdutoItem(Id,PedidoId,ProdutoId,ProdutoNome,ProdutoPreco,Quantidade)
VALUES (@Id,@PedidoId,@ProdutoId,@ProdutoNome,@ProdutoPreco,@Quantidade);

GO


------------------------------------------------------
-- STORED Procedures: ClienteIncluir
------------------------------------------------------
CREATE PROCEDURE ClienteIncluir

@Id varchar(36),
@Nome varchar(100),
@Email varchar(100),
@Empresa varchar(100),
@Endereco varchar(100),
@Numero varchar(20),
@Complemento varchar(20),
@Bairro varchar(100),
@Cidade varchar(100),
@Estado varchar(2),
@CPF varchar(14),
@CEP varchar(9)

AS

INSERT INTO Cliente(Id,Email, Nome,Empresa,Endereco,Numero,Complemento,Bairro,Cidade,Estado,CPF, CEP)
VALUES (@Id,@Email,@Nome,@Empresa,@Endereco,@Numero,@Complemento,@Bairro,@Cidade,@Estado,@CPF,@CEP );
GO

------------------------------------------------------
-- STORED Procedures: ClienteAlterar
------------------------------------------------------
CREATE PROCEDURE ClienteAlterar

@Id varchar(36),
@Nome varchar(100),
@Email varchar(100),
@Empresa varchar(100),
@Endereco varchar(100),
@Numero varchar(20),
@Complemento varchar(20),
@Bairro varchar(100),
@Cidade varchar(100),
@Estado varchar(2),
@CEP varchar(9),
@CPF varchar(14)

AS

UPDATE Cliente 
SET Nome=@Nome,Email=@Email, Empresa=@Empresa,Endereco=@Endereco, Numero=@Numero, Complemento=@Complemento, Bairro=@Bairro,Cidade=@Cidade,Estado=@Estado,CEP=@Cep, Cpf=@Cpf
WHERE Id=@Id

GO



------------------------------------------------------
-- STORED Procedures: PedidoStatusAlterar
------------------------------------------------------
CREATE PROCEDURE PedidoStatusAlterar

@PedidoId varchar(36),
@PedidoStatusId int

as 

UPDATE Pedido SET PedidoStatusId=@PedidoStatusId WHERE Id=@PedidoId

GO



------------------------------------------------------
-- STORED Procedures: PedidoProdutoObterPorPedidoId
------------------------------------------------------
CREATE PROCEDURE PedidoProdutoItemObterPorPedidoId

@PedidoId varchar(36)

AS

SELECT Id, PedidoId, ProdutoId, ProdutoNome, ProdutoPreco, Quantidade
FROM PedidoProdutoItem
WHERE PedidoId=@PedidoId
GO



------------------------------------------------------
-- STORED Procedures: PedidoObterPorPedidoStatus
------------------------------------------------------
CREATE PROCEDURE PedidoObterPorPedidoStatus

@PedidoStatusId int

AS

Select Id, Numero, DataSolicitado, DataEmProducao,DataProduzido,DataEmTransporte,DataEntregue,
ClienteId,ClienteNome,ClienteEmpresa,ClienteEndereco,ClienteNumero,ClienteComplemento,ClienteBairro,ClienteCidade,ClienteEstado,ClienteCPF,ClienteCep
FROM Pedido
WHERE Pedido.PedidoStatusId=@PedidoStatusId
GO


------------------------------------------------------
-- STORED Procedures: PedidoObterPorPedidoStatus
------------------------------------------------------
CREATE PROCEDURE PedidoObterPorId

@id varchar(36)

AS

Select Id, Numero, DataSolicitado, DataEmProducao,DataProduzido,DataEmTransporte,DataEntregue,
ClienteId,ClienteNome,ClienteEmpresa,ClienteEndereco,ClienteNumero,ClienteComplemento,ClienteBairro,ClienteCidade,ClienteEstado,ClienteCPF,ClienteCep
FROM Pedido
WHERE Pedido.Id=@Id
GO



------------------------------------------------------
-- STORED Procedures: ClienteObterPorCPF
------------------------------------------------------
CREATE PROCEDURE ProdutoObterList

AS

SELECT Id,Nome,Preco
FROM Produto

GO

------------------------------------------------------
-- STORED Procedures: ClienteObterPorCPF
------------------------------------------------------
CREATE PROCEDURE ClienteObterPorCPF

@CPF varchar(14)

AS

SELECT Id,Email, Nome,Empresa,Endereco,Numero,Complemento,Bairro,Cidade,Estado,CEP, CPF
FROM Cliente
WHERE CPF=@CPF

GO

------------------------------------------------------
-- STORED Procedures: ClienteObterPorId
------------------------------------------------------
CREATE PROCEDURE ClienteObterPorId

@Id varchar(36)

AS

SELECT Id,Email, Nome,Empresa,Endereco,Numero,Complemento,Bairro,Cidade,Estado,CEP, CPF
FROM Cliente
WHERE Id=@Id

GO
