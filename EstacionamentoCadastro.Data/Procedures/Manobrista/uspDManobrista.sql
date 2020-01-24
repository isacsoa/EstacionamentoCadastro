IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' And Name = '[uspDManobrista]')
DROP PROCEDURE [dbo].[uspDManobrista]
GO
CREATE PROCEDURE [dbo].[uspDManobrista]

@Id bigint

AS
BEGIN

DELETE FROM dbo.Tab_Manobrista WHERE Id = @Id

End