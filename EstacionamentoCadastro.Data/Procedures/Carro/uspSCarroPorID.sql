IF EXISTS (SELECT * FROM SYS.objects WHERE type = 'P' and name = 'uspSCarroPorId')
DROP PROCEDURE  [dbo].[uspSCarroPorId]
GO

CREATE PROCEDURE [dbo].[uspSCarroPorId]

@Id int

AS
BEGIN 

SELECT Id, Marca, Modelo , Placa
FROM dbo.Tab_Carro
WHERE Id = @Id

END