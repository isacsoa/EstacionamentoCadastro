IF EXISTS (SELECT * FROM SYS.objects WHERE type = 'P' and name = 'uspSCarro')
DROP PROCEDURE  [dbo].[uspSCarro]
GO

CREATE PROCEDURE [dbo].[uspSCarro]
AS
BEGIN 

SELECT Id, Marca, Modelo , Placa FROM dbo.Tab_Carro

END