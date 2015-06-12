
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ImportXML]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;



INSERT INTO XMLwithOpenXML(XMLData, LoadedDateTime)
SELECT CONVERT(XML, BulkColumn) AS BulkColumn, GETDATE() 
FROM OPENROWSET(BULK 'C:\Projects\WindowsApp\StarTrek\enmemoryalpha_pages_current.xml', SINGLE_BLOB) AS x;


SELECT * FROM XMLwithOpenXML
DECLARE @XML AS XML, @hDoc AS INT, @SQL NVARCHAR (MAX)


SELECT @XML = XMLData FROM XMLwithOpenXML


EXEC sp_xml_preparedocument @hDoc OUTPUT, @XML

INSERT INTO dbo.MemoryAlpha
SELECT Title,[Text]
FROM OPENXML(@hDoc, 'mediawiki/page/revision')
WITH 
(
Title [nvarchar](255) '../title',
[Text] text 'text'
)


EXEC sp_xml_removedocument @hDoc
END

