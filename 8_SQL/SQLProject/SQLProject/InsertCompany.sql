CREATE TRIGGER InsertCompany
   ON Employee
   AFTER INSERT
AS 
BEGIN
	SET NOCOUNT ON;

	DECLARE @CompanyName nvarchar(20) SELECT @CompanyName = [CompanyName]
	FROM Employee

	DECLARE @AddressId INT SELECT @AddressId = [AddressId]
	FROM Employee

	INSERT INTO Company VALUES (@CompanyName, @AddressId)

END
GO