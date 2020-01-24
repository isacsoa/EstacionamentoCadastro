IF EXISTS (SELECT * FROM SYS.objects WHERE type = 'P' and name = 'uspSManobrista')
DROP PROCEDURE  [dbo].[uspSManobrista]
GO

CREATE PROCEDURE [dbo].[uspSManobrista]
AS
BEGIN 

SELECT Id, NomeManobrista, CPF, DataNascimento FROM dbo.Tab_Manobrista

END