CREATE PROCEDURE [dbo].[spAddEmployee]
(
	@CompanyId INTEGER,
	@CreatedOn DATE,
	@DeletedOn DATE,
	@Email VARCHAR(50),
	@Fax VARCHAR(11),
	@Name VARCHAR(50),
	@LastLogin DATETIME,
	@Password NVARCHAR(20),
	@PortalId INTEGER,
	@RoleId INTEGER,
	@StatusId INTEGER,
	@Telephone VARCHAR(11),
	@UpdatedOn DATETIME,
	@Username VARCHAR(50)
)
AS
BEGIN
	INSERT INTO [dbo].[Employee]
	([CompanyId], [CreatedOn], [DeletedOn], [Email], [Fax], [Name], [Lastlogin], [Password], [PortalId], [RoleId], [StatusId], [Telephone], [UpdatedOn], [Username])
	VALUES
	(@CompanyId, @CreatedOn, @DeletedOn, @Email, @Fax, @Name, @LastLogin, @Password, @PortalId, @RoleId, @StatusId, @Telephone, @UpdatedOn, @Username)
END