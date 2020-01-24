IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'uspUCarroManobrado')
DROP PROCEDURE [dbo].[uspUCarroManobrado]
GO 
CREATE PROCEDURE [dbo].[uspUCarroManobrado]

@Id bigint,
@IdCarro bigint, 
@IdManobrista bigint

AS
BEGIN 

UPDATE dbo.Tab_CarroManobrado set 
IdCarro = @IdCarro, 
IdManobrista = @IdManobrista
WHERE 
Id = @Id

END