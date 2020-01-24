IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'uspIManobrista')
DROP PROCEDURE [dbo].[uspIManobrista]
GO

CREATE PROCEDURE [dbo].[uspIManobrista]

@NomeManobrista varchar(100), 
@CPF varchar(11),
@DataNascimento Date

AS 
BEGIN

INSERT INTO dbo.Tab_Manobrista (NomeManobrista, CPF, DataNascimento)
VALUES (@NomeManobrista , @CPF, @DataNascimento)

SELECT CAST(@@IDENTITY AS BIGINT)

END