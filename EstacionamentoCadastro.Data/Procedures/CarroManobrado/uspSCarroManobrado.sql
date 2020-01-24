IF EXISTS (SELECT * FROM SYS.objects WHERE type = 'P' and name = 'uspSCarroManobrado')
DROP PROCEDURE  [dbo].[uspSCarroManobrado]
GO

CREATE PROCEDURE [dbo].[uspSCarroManobrado]
AS
BEGIN 

SELECT Id, IdCarro, IdManobrista FROM dbo.Tab_CarroManobrado

END