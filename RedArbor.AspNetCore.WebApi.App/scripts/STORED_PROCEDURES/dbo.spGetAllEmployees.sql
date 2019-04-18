CREATE PROCEDURE [dbo].[spGetAllEmployees]
AS
BEGIN
	SELECT *      
    FROM [dbo].[Employee] AS e  
    ORDER BY e.CompanyId
END