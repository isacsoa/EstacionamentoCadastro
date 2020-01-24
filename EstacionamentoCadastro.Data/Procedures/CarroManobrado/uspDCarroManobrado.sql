IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' And Name = '[dbo].[uspDCarroManobrado]')
DROP PROCEDURE [dbo].[uspDCarroManobrado]
GO
CREATE PROCEDURE [dbo].[uspDCarroManobrado]

@Id bigint

AS
BEGIN

DELETE FROM dbo.Tab_CarroManobrado WHERE Id = @Id

End