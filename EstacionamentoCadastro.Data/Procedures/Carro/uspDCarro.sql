IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' And Name = 'uspDCarro')
DROP PROCEDURE [dbo].[uspDCarro]
GO
CREATE PROCEDURE [dbo].[uspDCarro]

@Id bigint

AS
BEGIN

DELETE FROM dbo.Tab_Carro WHERE Id = @Id

End