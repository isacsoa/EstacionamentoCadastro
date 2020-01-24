IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'uspUCarro')
DROP PROCEDURE [dbo].[uspUCarro]
GO 
CREATE PROCEDURE [dbo].[uspUCarro]

@Id bigint,
@Marca varchar(50), 
@Modelo varchar(50),
@Placa varchar(7)

AS
BEGIN 

UPDATE dbo.Tab_Carro set 
Marca = @Marca, 
Modelo = @Modelo,
Placa = @Placa
WHERE 
Id = @Id

END