IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'uspICarroManobrado')
DROP PROCEDURE [dbo].[uspICarroManobrado]
GO

CREATE PROCEDURE [dbo].[uspICarroManobrado]
 
@IdCarro bigint, 
@IdManobrista bigint

AS 
BEGIN

INSERT INTO dbo.Tab_CarroManobrado (IdCarro, IdManobrista)
VALUES (@IdCarro , @IdManobrista)

SELECT CAST(@@IDENTITY AS BIGINT)

END