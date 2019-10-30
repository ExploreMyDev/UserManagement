
CREATE PROCEDURE UserAddDetails
	@name varchar(200),
	@dateOfBirth date
AS
BEGIN
	INSERT INTO [User]
	Values (@name, @dateOfBirth)
END