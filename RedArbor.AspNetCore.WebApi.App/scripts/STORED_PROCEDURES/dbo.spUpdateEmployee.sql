CREATE PROCEDURE [dbo].[spUpdateEmployee]
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
	UPDATE [dbo].[Employee]
	SET [CreatedOn] = @CreatedOn,
	[DeletedOn] = @DeletedOn,
	[Email] = @Email,
	[Fax] = @Fax,
	[Name] = @Name,
	[Lastlogin] = @LastLogin,
	[Password] = @Password,
	[PortalId] = @PortalId,
	[RoleId] = @RoleId,
	[StatusId] = @StatusId,
	[Telephone] = @Telephone,
	[UpdatedOn] = @UpdatedOn,
	[Username] = @Username
	WHERE [CompanyId] = @CompanyId
END
