USE [DB_MyWaiter]
GO
/****** Object:  StoredProcedure [dbo].[addComanda]    Script Date: 22/06/2015 04:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[addComanda]
  @nome_Pessoa varchar(50),
  @fk_idConta int
as
  insert into Comanda(nome_Pessoa,hora_Comanda,status_Comanda,valor_Total,fk_idConta)
  values(@nome_Pessoa,CURRENT_TIMESTAMP,1,0,@fk_idConta)











GO
/****** Object:  StoredProcedure [dbo].[addComanda_Produto]    Script Date: 22/06/2015 04:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[addComanda_Produto]
  @qtd_Item int,
  @fk_idProd int,
  @fk_idComanda int,
  @fk_idConta int
as
insert into Comanda_Produto(qtd_Item_Comanda,fk_idProduto,fk_idComanda,status_ComandaProduto, fk_idConta)
values(@qtd_Item,@fk_idProd,@fk_idComanda,1, @fk_idConta)













GO
/****** Object:  StoredProcedure [dbo].[addConta]    Script Date: 22/06/2015 04:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE procedure [dbo].[addConta](
  @fk_idMesa int
)
as
insert into Conta(fk_idMesa,horaInicio)
values(@fk_idMesa,GETDATE())



















GO
/****** Object:  StoredProcedure [dbo].[addProd]    Script Date: 22/06/2015 04:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[addProd](
  @nome_Produto varchar(40),
  @categoria_Produto varchar(40),
  @prioridade_Produto int,
  @quantidade_Produto int,
  @img_src varchar(100),
  @preco_Produto float,
  @descricao_Produto varchar(200),
  @disponibilidade_Produto int
)
as
insert into Produto(nome_Produto,categoria_Produto,preco_Produto,descricao_Produto,disponibilidade_Produto,quantidade_Produto,prioridade_Produto,img_src)
values(@nome_Produto,@categoria_Produto,@preco_Produto,@descricao_Produto,@disponibilidade_Produto,@quantidade_Produto,@prioridade_Produto,@img_src)
















GO
/****** Object:  StoredProcedure [dbo].[checarComandaProduto]    Script Date: 22/06/2015 04:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[checarComandaProduto]
@idComanda int
AS
SELECT COUNT(*) FROM Comanda_Produto WHERE fk_idComanda = @idComanda







GO
/****** Object:  StoredProcedure [dbo].[checarComandas]    Script Date: 22/06/2015 04:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[checarComandas]
@idConta int
AS
SELECT COUNT(*) FROM Comanda WHERE fk_idConta = @idConta AND status_Comanda = 1







GO
/****** Object:  StoredProcedure [dbo].[deleteComanda]    Script Date: 22/06/2015 04:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[deleteComanda]
@idComanda int
AS
DELETE FROM Comanda WHERE id_Comanda = @idComanda







GO
/****** Object:  StoredProcedure [dbo].[disponibilizarMesa]    Script Date: 22/06/2015 04:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[disponibilizarMesa]
  @idMesa int
as
update Mesa set status_Mesa=1
where id_Mesa=@idMesa















GO
/****** Object:  StoredProcedure [dbo].[editProd]    Script Date: 22/06/2015 04:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[editProd]
@id_Produto int,
  @nome_Produto varchar(40),
  @categoria_Produto varchar(40),
  @prioridade_Produto int,
  @quantidade_Produto int,
  @img_src varchar(100),
  @preco_Produto float,
  @descricao_Produto varchar(200),
  @disponibilidade_Produto int
as
update Produto set nome_Produto=@nome_Produto,
categoria_Produto=@categoria_Produto,
preco_Produto=@preco_Produto,
descricao_Produto=@descricao_Produto,
disponibilidade_Produto=@disponibilidade_Produto,
quantidade_Produto=@quantidade_Produto,
prioridade_Produto=@prioridade_Produto,
img_src=@img_src
where id_Produto=@id_Produto















GO
/****** Object:  StoredProcedure [dbo].[finalizarComanda]    Script Date: 22/06/2015 04:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[finalizarComanda]
@idComanda int
AS
UPDATE Comanda SET status_Comanda = 0, final_HoraComanda = CURRENT_TIMESTAMP WHERE id_Comanda = @idComanda AND status_Comanda = 1









GO
/****** Object:  StoredProcedure [dbo].[finalizarConta]    Script Date: 22/06/2015 04:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[finalizarConta]
@idConta int
AS
UPDATE Comanda SET status_Comanda = 0, final_HoraComanda = CURRENT_TIMESTAMP WHERE fk_idConta = @idConta AND status_Comanda = 1
UPDATE Conta SET horaFim = CURRENT_TIMESTAMP WHERE id_Conta = @idConta





GO
/****** Object:  StoredProcedure [dbo].[getAllContas]    Script Date: 22/06/2015 04:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create procedure [dbo].[getAllContas]
AS
select ct.fk_idMesa as 'Número da Mesa',ct.id_Conta as 'Número da Conta',
ct.horaInicio as 'Hora de início da Conta',ct.horaFim as 'Hora do fim da Conta',
c.id_Comanda as 'Número da Comanda',c.nome_Pessoa as 'Nome',c.hora_Comanda as 'Hora do início da Comanda',
c.final_HoraComanda as 'Hora do Fim da Comanda',p.id_Produto as 'Código do Produto',
p.nome_Produto as 'Nome do Produto',cp.valor_Comanda_produto as 'Valor do Pedido',
c.valor_Total 'Valor total da Comanda' from Comanda_Produto as cp
inner join Comanda as c on c.id_Comanda=cp.fk_idComanda
inner join Conta as ct on ct.id_Conta=cp.fk_idConta
inner join Produto as p on p.id_Produto=cp.fk_idProduto
order by ct.id_Conta desc









GO
/****** Object:  StoredProcedure [dbo].[getComandaByStatus]    Script Date: 22/06/2015 04:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getComandaByStatus]
@idConta int
AS
SELECT id_Comanda, nome_Pessoa, valor_Total FROM Comanda WHERE fk_idConta = @idConta AND status_Comanda = 1









GO
/****** Object:  StoredProcedure [dbo].[getComandaUnica]    Script Date: 22/06/2015 04:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getComandaUnica]
@idConta int
AS
DECLARE
@max int
SELECT @max = MAX(id_Comanda) FROM Comanda WHERE fk_idConta = @idConta AND status_Comanda = 1

SELECT id_Comanda, nome_Pessoa, valor_Total FROM Comanda WHERE id_Comanda = @max







GO
/****** Object:  StoredProcedure [dbo].[getContaComanda]    Script Date: 22/06/2015 04:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getContaComanda]
@idComanda int,
@idConta int
AS
SELECT Produto.nome_Produto,
 Comanda_Produto.qtd_Item_Comanda, Comanda_Produto.valor_Comanda_produto
 FROM Comanda_Produto INNER JOIN Comanda ON Comanda.id_Comanda = Comanda_Produto.fk_idComanda
 INNER JOIN Produto ON Produto.id_Produto = Comanda_Produto.fk_idProduto WHERE Comanda_Produto.fk_idConta = @idConta AND fk_idComanda = @idComanda AND status_ComandaProduto >= 2









GO
/****** Object:  StoredProcedure [dbo].[getIdConta]    Script Date: 22/06/2015 04:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getIdConta]
  @idConta int output
as
set @idConta=(select max(id_Conta) from Conta)













GO
/****** Object:  StoredProcedure [dbo].[getModelPedido]    Script Date: 22/06/2015 04:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getModelPedido]
@idConta int
AS
SELECT Comanda.nome_Pessoa, Comanda_Produto.id_Comanda_Produto, Comanda_Produto.qtd_Item_Comanda,
Comanda_Produto.status_ComandaProduto, Comanda_Produto.fk_idConta, Comanda_Produto.valor_Comanda_produto,
Produto.img_src, Produto.nome_Produto
FROM Comanda INNER JOIN Comanda_Produto 
ON Comanda.id_Comanda = Comanda_Produto.fk_idComanda
INNER JOIN Produto ON Produto.id_Produto = Comanda_Produto.fk_idProduto WHERE Comanda_Produto.fk_idConta = @idConta AND Comanda_Produto.status_ComandaProduto = 1 ORDER BY Comanda_Produto.id_Comanda_Produto DESC








GO
/****** Object:  StoredProcedure [dbo].[getNomePrecoComanda]    Script Date: 22/06/2015 04:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getNomePrecoComanda]
@idconta int
AS

SELECT Comanda.nome_Pessoa, Comanda.id_Comanda,
SUM(Comanda_Produto.valor_Comanda_produto) as 'Soma'
FROM Comanda INNER JOIN Comanda_Produto 
ON Comanda.id_Comanda = Comanda_Produto.fk_idComanda
INNER JOIN Produto ON Produto.id_Produto = Comanda_Produto.fk_idProduto WHERE Comanda_Produto.fk_idConta = @idconta AND Comanda_Produto.status_ComandaProduto = 1 GROUP BY id_Comanda, nome_Pessoa











GO
/****** Object:  StoredProcedure [dbo].[getNumeroComandaPedidoById]    Script Date: 22/06/2015 04:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getNumeroComandaPedidoById]
@idComanda int
AS
SELECT COUNT(*) FROM Comanda_Produto WHERE fk_idComanda = @idComanda AND status_ComandaProduto = 1








GO
/****** Object:  StoredProcedure [dbo].[getPedidos]    Script Date: 22/06/2015 04:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getPedidos]
	@idPedido int
	AS
    select ct.fk_idMesa as 'Número da Mesa',p.nome_Produto as 'Nome do Produto',SUM(cp.qtd_Item_Comanda) as 'Quantidade' from Comanda_Produto as cp
	inner join Produto as p on p.id_Produto=cp.fk_idProduto
	inner join Conta as ct on ct.id_Conta=cp.fk_idConta
	where cp.status_ComandaProduto=2 AND id_Pedido = @idPedido
	GROUP BY ct.fk_idMesa, p.nome_Produto, cp.qtd_Item_Comanda




GO
/****** Object:  StoredProcedure [dbo].[getProdutoByCategoria]    Script Date: 22/06/2015 04:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getProdutoByCategoria]
  @categoria varchar(50)
as
select id_Produto,nome_Produto,preco_Produto,categoria_Produto,descricao_Produto,quantidade_Produto,prioridade_Produto,disponibilidade_Produto,img_src from Produto
where categoria_Produto=@categoria















GO
/****** Object:  StoredProcedure [dbo].[logarAdmin]    Script Date: 22/06/2015 04:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[logarAdmin](
  @userName varchar(40),
  @passWord varchar(20),
  @Result int output
)
as
set @Result=(select count(*) from Mesa
where loginMesa=@userName and senhaMesa=@passWord)
if(@Result=1)
begin
set @Result=1 --Login bem sucedido
end
else
begin
set @Result=0 --Login mal sucedido
end
















GO
/****** Object:  StoredProcedure [dbo].[ocuparMesa]    Script Date: 22/06/2015 04:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[ocuparMesa]
  @idMesa int
as
update Mesa set status_Mesa=0
where id_Mesa=@idMesa














GO
/****** Object:  StoredProcedure [dbo].[updateStatusComandaProduto]    Script Date: 22/06/2015 04:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updateStatusComandaProduto]
@idComandaProd int,
@idPedido int
AS
  UPDATE Comanda_Produto SET status_ComandaProduto = 2,hora_Comanda_Produto=GETDATE(),id_Pedido=@idPedido WHERE id_Comanda_Produto = @idComandaProd




GO
/****** Object:  StoredProcedure [dbo].[updateStatusComandaProdutoCozinha]    Script Date: 22/06/2015 04:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updateStatusComandaProdutoCozinha]
	@idPedido int
	AS

	UPDATE Comanda_Produto SET status_ComandaProduto = 3 WHERE id_Pedido = @idPedido




GO
/****** Object:  StoredProcedure [dbo].[updateValorComandaProduto]    Script Date: 22/06/2015 04:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updateValorComandaProduto]
@idComanda_Produto int,
@fk_idConta int
as
declare
@valorTotal float

	SELECT @valorTotal = Comanda_Produto.qtd_Item_Comanda * Produto.preco_Produto
	FROM Comanda_Produto INNER JOIN Produto ON Produto.id_Produto = Comanda_Produto.fk_idProduto
	WHERE Comanda_Produto.fk_idConta = @fk_idConta AND id_Comanda_Produto = @idComanda_Produto


	UPDATE Comanda_Produto SET valor_Comanda_Produto = @valorTotal WHERE id_Comanda_Produto = @idComanda_Produto











GO
/****** Object:  StoredProcedure [dbo].[updateValorTotalComanda]    Script Date: 22/06/2015 04:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updateValorTotalComanda]
@idComandaProduto int
AS
DECLARE
@fk_idComanda int,
@soma float

SELECT @fk_idComanda = fk_idComanda FROM Comanda_Produto WHERE id_Comanda_Produto = @idComandaProduto

SELECT @soma = SUM(valor_Comanda_produto) FROM Comanda_Produto WHERE fk_idComanda = @fk_idComanda AND status_ComandaProduto = 2

UPDATE Comanda SET valor_Total = @soma WHERE id_Comanda = @fk_idComanda










GO
/****** Object:  StoredProcedure [dbo].[viewProd]    Script Date: 22/06/2015 04:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[viewProd]
  @nomeProd varchar(50)
as
select id_Produto as 'Id',nome_Produto as 'Produto',categoria_Produto as 'Categoria','Disponibilidade' = case when Produto.disponibilidade_Produto=1 then 'Disponivel' else 'Indisponível' end,'Prioridade' = case when Produto.prioridade_Produto=0 then 'Normal' else 'Alta' end, quantidade_Produto as 'Quantidade',preco_Produto as 'Preço (R$)' from Produto
where nome_Produto like '%'+@nomeProd+'%'

















GO
/****** Object:  Table [dbo].[Comanda]    Script Date: 22/06/2015 04:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Comanda](
	[id_Comanda] [int] IDENTITY(1,1) NOT NULL,
	[hora_Comanda] [datetime] NOT NULL,
	[nome_Pessoa] [varchar](50) NOT NULL,
	[status_Comanda] [int] NOT NULL,
	[valor_Total] [float] NOT NULL,
	[fk_idConta] [int] NOT NULL,
	[final_HoraComanda] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_Comanda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Comanda_Produto]    Script Date: 22/06/2015 04:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comanda_Produto](
	[id_Comanda_Produto] [int] IDENTITY(1,1) NOT NULL,
	[qtd_Item_Comanda] [int] NOT NULL,
	[fk_idProduto] [int] NOT NULL,
	[fk_idComanda] [int] NOT NULL,
	[status_ComandaProduto] [int] NOT NULL,
	[fk_idConta] [int] NOT NULL,
	[valor_Comanda_produto] [float] NULL,
	[hora_Comanda_Produto] [datetime] NULL,
	[id_Pedido] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_Comanda_Produto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Conta]    Script Date: 22/06/2015 04:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conta](
	[id_Conta] [int] IDENTITY(1,1) NOT NULL,
	[fk_idMesa] [int] NULL,
	[horaInicio] [datetime] NOT NULL,
	[horaFim] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_Conta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Mesa]    Script Date: 22/06/2015 04:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mesa](
	[id_Mesa] [int] NOT NULL,
	[status_Mesa] [int] NOT NULL,
	[loginMesa] [varchar](50) NOT NULL,
	[senhaMesa] [varchar](30) NOT NULL,
	[permissaoUser] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_Mesa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 22/06/2015 04:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Produto](
	[id_Produto] [int] IDENTITY(1,1) NOT NULL,
	[categoria_Produto] [varchar](40) NOT NULL,
	[preco_Produto] [float] NOT NULL,
	[nome_Produto] [varchar](40) NOT NULL,
	[descricao_Produto] [varchar](500) NULL,
	[disponibilidade_Produto] [int] NOT NULL,
	[prioridade_Produto] [int] NOT NULL,
	[quantidade_Produto] [int] NOT NULL,
	[img_src] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_Produto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Mesa] ([id_Mesa], [status_Mesa], [loginMesa], [senhaMesa], [permissaoUser]) VALUES (1, 1, N'mesa01', N'mesa01', 0)
INSERT [dbo].[Mesa] ([id_Mesa], [status_Mesa], [loginMesa], [senhaMesa], [permissaoUser]) VALUES (2, 1, N'mesa02', N'mesa02', 0)
INSERT [dbo].[Mesa] ([id_Mesa], [status_Mesa], [loginMesa], [senhaMesa], [permissaoUser]) VALUES (3, 1, N'mesa03', N'mesa03', 0)
INSERT [dbo].[Mesa] ([id_Mesa], [status_Mesa], [loginMesa], [senhaMesa], [permissaoUser]) VALUES (4, 1, N'mesa04', N'mesa04', 0)
INSERT [dbo].[Mesa] ([id_Mesa], [status_Mesa], [loginMesa], [senhaMesa], [permissaoUser]) VALUES (5, 1, N'mesa05', N'mesa05', 0)
INSERT [dbo].[Mesa] ([id_Mesa], [status_Mesa], [loginMesa], [senhaMesa], [permissaoUser]) VALUES (6, 1, N'mesa06', N'mesa06', 0)
INSERT [dbo].[Mesa] ([id_Mesa], [status_Mesa], [loginMesa], [senhaMesa], [permissaoUser]) VALUES (101, 1, N'admin', N'admin', 1)
INSERT [dbo].[Mesa] ([id_Mesa], [status_Mesa], [loginMesa], [senhaMesa], [permissaoUser]) VALUES (102, 1, N'cozinha', N'cozinha', 2)
SET IDENTITY_INSERT [dbo].[Produto] ON 

INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (1, N'Saladas', 11.99, N'Salada de Azeitona', N'Uma salada de alface e tomate com azeitonas', 1, 1, 10, N'~/imagens_Produto/Azeitona.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (2, N'Saladas', 9.99, N'Salada Caprese', N'Uma salada light', 1, 0, 10, N'~/imagens_Produto/Caprese.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (3, N'Saladas', 20.99, N'Salada de Chicoria', N'Com chicoria', 1, 1, 10, N'~/imagens_Produto/Chicoria.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (4, N'Burger', 21.86, N'Italian Style', N'Hamburger de 150 gramas com queijo provolone derretido, rúcula, tomate seco, no pão com gergelim pincelado com molho especial de ketchup e mostarda.', 1, 1, 30, N'~/imagens_Produto/italian-style.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (5, N'Burger', 23.54, N'Barbecue Burger', N'Hamburger de 150 gramas com queijo prato derretido, bacon crocante, cebola grelhada e molho barbecue, no pão com gergelim.', 1, 1, 30, N'~/imagens_Produto/barbecue-burger.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (6, N'Burger', 26.29, N'Burger Patriota', N'Hamburger de 200 gramas servido com queijo gorgonzola derretido, fatias crocantes de bacon caramelizado com mel, tomate e maionese no pão sem gergelim. Acompanha batatas  fritas rústicas e molho barbe', 1, 0, 30, N'~/imagens_Produto/burger-patriota.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (7, N'Burger', 19.99, N'Caesar Burger', N'Hambúrger de 150 gramas com queijo cheddar, alface americana, parmesão, maionese caesar, no pão integral com gergelim.', 1, 1, 30, N'~/imagens_Produto/caesar-burger.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (8, N'Burger', 20.49, N'Cheeseburger Salada Americano', N'Hamburger de 150 gramas com queijo prato derretido, alface, tomate, maionese, relish de pepino, no pão com gergelim.', 1, 2, 30, N'~/imagens_Produto/cheeseburger-salada-america.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (9, N'Burger', 22.99, N'Veggie Burger', N'Hamburger vegetariano de quinua, abobrinha e cenoura (empanado) acompanhado de coalhada seca, rúcula, tomate e molho de romã, no pão integral com gergelim', 1, 1, 30, N'~/imagens_Produto/veggie-burger.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (10, N'Sanduíches', 30.97, N'Beirute Americano', N'Queijo prato derretido, alface, tomate, maionese e relish de pepino, no pão sírio.', 1, 1, 30, N'~/imagens_Produto/beirute-america.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (11, N'Sanduíches', 25.99, N'Churrasquinho na Baquete', N'Sanduíche de filet mignon grelhado de 100 gramas com queijo, maionese, alface e vinagre. Acompanha batatas fritas', 1, 1, 30, N'~/imagens_Produto/churrasquinho-na-baguete.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (12, N'Sanduíches', 25.96, N'Sunny Americano', N'Sanduíche de filet de frango grelhado de 120 gramas, queijo prato, molho champignon, maionese caesar, alface americana, tomate no pão de hambúrguer com gergelim, acompanhado de maionese caesar. Servid', 1, 0, 30, N'~/imagens_Produto/sunny-america.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (13, N'Sanduíches', 17.99, N'Times Square Dog', N'Delicoso hot dog com sasicha especial grelhada, coberta com molho cremoso de queijo, acompanhada de potinho de mostarda, no pão baquete. Servido com onion rings ou batatas fritas.', 1, 1, 30, N'~/imagens_Produto/times-square-dog.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (14, N'Sanduíches', 18.99, N'Veggie Sandwich', N'Sanduíchae de beringela grelhada, abobrinha grelhada,  mussarela de búfala, tomate seco e rúcula com molho mostarda, no pão ciabatta.', 1, 0, 30, N'~/imagens_Produto/veggie-sandwich.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (15, N'Saladas', 27.97, N'Salada Italiana', N'Salada de alface americana, tomate seco, mussarela de búfala, gomos de laranja, azeitonas pretas, salpicadas com manjericão, crôutons e molho vinagre.', 1, 2, 30, N'~/imagens_Produto/salada-italiana.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (16, N'Bebidas', 4.5, N'Cerveja Budweiser', N'Cerveja Budweiser (300 ml).', 1, 1, 30, N'~/imagens_Produto/cerveja-budweiser.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (17, N'Peixes', 29.97, N'Grilled Salmon', N'Filet de salmão grelhado de 150 gramas com manteiga temperada, acompanhada de batatas fritas e arroz', 1, 1, 31, N'~/imagens_Produto/grilled-salmon.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (18, N'Peixes', 29.97, N'Saint Peter', N'Filet de Saint Peter grelhado 180 gramas com molho à base de shallots, creme de leite e vinho branco acompanhado de arroz primavera e aspargos grelhados.', 1, 2, 30, N'~/imagens_Produto/saint-peter.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (19, N'Bebidas', 4.5, N'H2OH!', N'H2OH! (500 ml).', 1, 1, 30, N'~/imagens_Produto/h2oh.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (20, N'Bebidas', 3.99, N'Coca-Cola', N'Coca-Cola (350 ml).', 1, 1, 30, N'~/imagens_Produto/coca_cola_lata.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (21, N'Bebidas', 3.99, N'Pepsi', N'Pepsi (350 ml).', 1, 1, 30, N'~/imagens_Produto/0003386_refrigerante-pepsi-350ml-lata.png')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (22, N'Bebidas', 5.5, N'Suco de Laranja', N'Suco feito na hora, com laranjas.', 1, 0, 30, N'~/imagens_Produto/Suco-Detox-de-Laranja.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (23, N'Peixes', 40, N'Salmon & Pasta', N'Fettuccine servido com filet de salmão grelhado de 150 gramas com manteigas temperada.', 1, 1, 30, N'~/imagens_Produto/salmon-pasta.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (24, N'Peixes', 30.97, N'Salmon Light', N'Filet de salmão de 150 gramas com manteiga temperada, acompanhada de salada de endívia, rúcula, tomate cereja, cogumelos frescos, com molho mostarda, salpicada com manjericão.', 1, 0, 30, N'~/imagens_Produto/salmon-light.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (25, N'Grelhados', 30.97, N'California', N'Fraldinha grelhada de 220 gramas acompanhada de salada Yuppie (agrião, tomate cereja, mussarela de búfala e cogumelos frescos, com molho de azeite, limão e alcaparras).', 1, 2, 30, N'~/imagens_Produto/california.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (26, N'Grelhados', 29, N'Chicken Light', N'Filet de peito de frango grelhado de 120 gramas pincelado com manteiga derretida e vegetais grelhados (abobrinha, acompanhados de potinho com molho à base de gengibre fresco, shoyu e cebolinha.', 1, 1, 30, N'~/imagens_Produto/chicken-light.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (27, N'Grelhados', 27.97, N'Liberty', N'Filet de peito de frango grelhado de 120 gramas pincelado com manteiga derretida, com molho de champignon e leve to que de ricota temperada, acompanhado de batatas fritas e salada de alface americana ', 1, 1, 30, N'~/imagens_Produto/liberty.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (28, N'Grelhados', 35.97, N'Minuano', N'Ribeye de 220 gramas acompanhado de salada Cole Slaw (repolho, cenoura, uvas passas com molho de creme e maionese) e baked potato com molho de queijo e creme gorgonzola.', 1, 0, 30, N'~/imagens_Produto/minuano.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (29, N'Grelhados', 26.99, N'Texas', N'Hamburger grelhado de 200 gramas com molho especial, servido sobre uma base de pão australiano, acompanhado de relishes de milho e pepino, batatas fritas rústicas e onion rings.', 1, 1, 30, N'~/imagens_Produto/texas.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (30, N'Prato_Feito', 30.5, N'Dallas', N'Ribeye 220 gramas acompanhados de home made e salsinha Caesar (alface americana, molho à base de creme de leite, parmesão e alho, crôutons e queijo parmesão).', 1, 1, 30, N'~/imagens_Produto/dallas.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (31, N'Prato_Feito', 25.99, N'Salada Oriental', N'Salada de alface americana, cenoura, pepino, manga, com molo honey mustard e tiras de frango grelhado, salpicada com gergelim torrado.', 1, 1, 30, N'~/imagens_Produto/salada-oriental.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (32, N'Prato_Feito', 33.5, N'Carpaccio', N'Carpaccio, alface americana e rúcula temperada com molho de alcaparras, azeitonas pretas, crôutons e queijo parmesão.', 1, 1, 30, N'~/imagens_Produto/carpaccio-america.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (33, N'Prato_Feito', 28.97, N'Mexican Italian', N'Fettuccine servido com hamburger de 200 gramas, coberto com TexMex levemente apimentado e queijo provolone derretido.', 1, 1, 30, N'~/imagens_Produto/mexican-italian.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (34, N'Sobremesas', 14, N'Farofino', N'Sorverte de chocolate, morango ou creme com farofa crocante, cobertura de chocolate e creme chantily', 1, 1, 30, N'~/imagens_Produto/farofino.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (35, N'Sobremesas', 7.99, N'Mini Farofino', N'Sorvete de chocolate, morango ou creme com farofa crocante', 1, 1, 30, N'~/imagens_Produto/mini-farofino.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (36, N'Sobremesas', 18.99, N'Volcano', N'Delicioso sorvete de doce de leite, totalmente coberto por uma casquinha de chocolate ao leite recheada de doce de leite argentino... na hora de servir... uma surpresa.', 1, 1, 30, N'~/imagens_Produto/volcano.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (37, N'Sobremesas', 15.97, N'Devils Food Cake', N'Delicioso e macio bolo de chocolate servido com calda quente e sorvete de creme.', 1, 0, 30, N'~/imagens_Produto/devils-food-cake.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (38, N'Sobremesas', 14.96, N'Cheese Cake', N'Cheese cake com calda de frutas vermelhas, doce de leite argentino e creme de chatily.', 1, 2, 30, N'~/imagens_Produto/cheese-cake-america.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (39, N'Porçoes', 20.99, N'Batata Frita', N'Batatas fritas', 1, 1, 30, N'~/imagens_Produto/batata-frita.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (40, N'Porçoes', 15.97, N'Baked Potato', N'Com molho de queijos e creme de gorgonzola.', 1, 2, 30, N'~/imagens_Produto/baked-potato.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (41, N'Porçoes', 12.99, N'Onion Rings', N'Rodelas fritas de cebola empanda.', 1, 1, 30, N'~/imagens_Produto/onion-rings.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (42, N'Porçoes', 15.97, N'Vegetais Grelhados', N'Abobrinha, berinjela, pimentões vermelhos, cebola, cenoura e brócolis, acompanhados de potinho com molho à base de gengibre fresco, shoyu e cebolinha.', 1, 0, 30, N'~/imagens_Produto/vegetais-grelhados.jpg')
INSERT [dbo].[Produto] ([id_Produto], [categoria_Produto], [preco_Produto], [nome_Produto], [descricao_Produto], [disponibilidade_Produto], [prioridade_Produto], [quantidade_Produto], [img_src]) VALUES (43, N'Porçoes', 20.99, N'Batata Frita com Cheddar Picante e Bacon', N'Batata Frita com Cheddar Picante e Bacon', 1, 1, 30, N'~/imagens_Produto/batata-frita-com-cheddar-picante-e-bacon.jpg')
SET IDENTITY_INSERT [dbo].[Produto] OFF
ALTER TABLE [dbo].[Comanda_Produto] ADD  DEFAULT ((1)) FOR [id_Pedido]
GO
ALTER TABLE [dbo].[Comanda]  WITH CHECK ADD  CONSTRAINT [foreign_idConta] FOREIGN KEY([fk_idConta])
REFERENCES [dbo].[Conta] ([id_Conta])
GO
ALTER TABLE [dbo].[Comanda] CHECK CONSTRAINT [foreign_idConta]
GO
ALTER TABLE [dbo].[Comanda_Produto]  WITH CHECK ADD  CONSTRAINT [fkIdConta] FOREIGN KEY([fk_idConta])
REFERENCES [dbo].[Conta] ([id_Conta])
GO
ALTER TABLE [dbo].[Comanda_Produto] CHECK CONSTRAINT [fkIdConta]
GO
ALTER TABLE [dbo].[Comanda_Produto]  WITH CHECK ADD  CONSTRAINT [foreign_idComanda] FOREIGN KEY([fk_idComanda])
REFERENCES [dbo].[Comanda] ([id_Comanda])
GO
ALTER TABLE [dbo].[Comanda_Produto] CHECK CONSTRAINT [foreign_idComanda]
GO
ALTER TABLE [dbo].[Comanda_Produto]  WITH CHECK ADD  CONSTRAINT [foreign_idProduto] FOREIGN KEY([fk_idProduto])
REFERENCES [dbo].[Produto] ([id_Produto])
GO
ALTER TABLE [dbo].[Comanda_Produto] CHECK CONSTRAINT [foreign_idProduto]
GO
ALTER TABLE [dbo].[Conta]  WITH CHECK ADD  CONSTRAINT [foreign_idMesa] FOREIGN KEY([fk_idMesa])
REFERENCES [dbo].[Mesa] ([id_Mesa])
GO
ALTER TABLE [dbo].[Conta] CHECK CONSTRAINT [foreign_idMesa]
GO
/****** Object:  Trigger [dbo].[updateValorComanda_Produto]    Script Date: 22/06/2015 04:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[updateValorComanda_Produto]
ON [dbo].[Comanda_Produto] AFTER INSERT
AS
	declare
	@valor float,
	@fk_idConta int,
	@id_Comanda_Produto int

	SELECT @fk_idConta = fk_idConta, @id_Comanda_Produto = id_Comanda_Produto FROM inserted

	SELECT @valor = Comanda_Produto.qtd_Item_Comanda * Produto.preco_Produto
	FROM Comanda_Produto INNER JOIN Produto ON Produto.id_Produto = Comanda_Produto.fk_idProduto
	WHERE Comanda_Produto.fk_idConta = @fk_idConta AND id_Comanda_Produto = @id_Comanda_Produto


	UPDATE Comanda_Produto SET valor_Comanda_Produto = @valor WHERE id_Comanda_Produto = @id_Comanda_Produto











GO
/****** Object:  Trigger [dbo].[alterar_Disp]    Script Date: 22/06/2015 04:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE trigger [dbo].[alterar_Disp] on [dbo].[Produto]
after update  as
declare @id int
set @id=(select id_Produto from deleted)
if((select count(*) from Produto where quantidade_Produto=0)>0)
begin
update Produto set disponibilidade_Produto = 0 where id_Produto=@id
end
else
begin
update Produto set disponibilidade_Produto = 1 where id_Produto=@id
end











GO
