
CREATE PROCEDURE UserGetAllDetails
	
AS
BEGIN
	SELECT UserID,
	Name,
	CAST(DateOfBirth AS DATE) AS DateOfBirth
	FROM [User]
END