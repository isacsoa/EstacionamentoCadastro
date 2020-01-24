USE [Estacionamento_Cadastro]
GO

/****** Object:  Table [dbo].[Tab_CarroManobrado]    Script Date: 23/01/2020 22:28:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tab_CarroManobrado](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[IdCarro] [bigint] NOT NULL,
	[IdManobrista] [bigint] NOT NULL,
 CONSTRAINT [tb_carrosmanobrados_pk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Tab_CarroManobrado]  WITH CHECK ADD  CONSTRAINT [CarrosManobradosCarroIdFK] FOREIGN KEY([IdCarro])
REFERENCES [dbo].[Tab_Carro] ([Id])
GO

ALTER TABLE [dbo].[Tab_CarroManobrado] CHECK CONSTRAINT [CarrosManobradosCarroIdFK]
GO

ALTER TABLE [dbo].[Tab_CarroManobrado]  WITH CHECK ADD  CONSTRAINT [CarrosManobradosManobristaIdFK] FOREIGN KEY([IdManobrista])
REFERENCES [dbo].[Tab_Manobrista] ([Id])
GO

ALTER TABLE [dbo].[Tab_CarroManobrado] CHECK CONSTRAINT [CarrosManobradosManobristaIdFK]
GO
