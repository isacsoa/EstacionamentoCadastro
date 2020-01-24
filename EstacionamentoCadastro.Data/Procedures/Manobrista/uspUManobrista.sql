IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'uspUManobrista')
DROP PROCEDURE [dbo].[uspUManobrista]
GO 
CREATE PROCEDURE [dbo].[uspUManobrista]

@Id bigint,
@NomeManobrista varchar(100), 
@CPF varchar(11),
@DataNascimento Date

AS
BEGIN 

UPDATE dbo.Tab_Manobrista set 
NomeManobrista = @NomeManobrista,
CPF = @CPF,
DataNascimento = @DataNascimento 
WHERE 
Id = @Id

END