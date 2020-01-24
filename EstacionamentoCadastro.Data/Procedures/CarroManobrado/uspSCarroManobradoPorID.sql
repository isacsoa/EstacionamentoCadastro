IF EXISTS (SELECT * FROM SYS.objects WHERE type = 'P' and name = 'uspSCarroManobradoPorId')
DROP PROCEDURE  [dbo].[uspSCarroManobradoPorId]
GO

CREATE PROCEDURE [dbo].[uspSCarroManobradoPorId]

@Id int

AS
BEGIN 

SELECT Id, IdCarro, IdManobrista
FROM dbo.Tab_CarroManobrado
WHERE Id = @Id

END