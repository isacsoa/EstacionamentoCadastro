IF EXISTS (SELECT * FROM SYS.objects WHERE type = 'P' and name = 'uspSManobristaPorId')
DROP PROCEDURE  [dbo].[uspSManobristaPorId]
GO

CREATE PROCEDURE [dbo].[uspSManobristaPorId]

@Id int

AS
BEGIN 

SELECT Id, NomeManobrista, CPF , DataNAscimento
FROM dbo.Tab_Manobrista
WHERE Id = @Id

END