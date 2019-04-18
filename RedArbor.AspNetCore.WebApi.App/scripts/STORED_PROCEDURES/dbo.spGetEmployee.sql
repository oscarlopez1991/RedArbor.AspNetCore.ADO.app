CREATE PROCEDURE [dbo].[spGetEmployee]
(
	@CompanyId INTEGER
)
AS
BEGIN
	SELECT *      
    FROM [dbo].[Employee] AS e
	WHERE e.CompanyId = @CompanyId 
END