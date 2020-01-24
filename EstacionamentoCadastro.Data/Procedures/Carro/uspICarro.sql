IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'uspICarro')
DROP PROCEDURE [dbo].[uspICarro]
GO

CREATE PROCEDURE [dbo].[uspICarro]

@Marca varchar(50), 
@Modelo varchar(50), 
@Placa varchar(7)

AS 
BEGIN

INSERT INTO dbo.Tab_Carro (Marca, Modelo, Placa)
VALUES (@Marca, @Modelo, @Placa)

SELECT CAST(@@IDENTITY AS BIGINT)

END