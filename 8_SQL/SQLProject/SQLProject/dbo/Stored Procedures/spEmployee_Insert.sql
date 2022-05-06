CREATE PROCEDURE [dbo].[spEmployee_Insert]

@EmployeeName nvarchar(100)  =null, 

@FirstName nvarchar(50) = 'default',

@LastName nvarchar(50) = 'default',

@CompanyName nvarchar(20),

@Position nvarchar(30) = null,

@Street nvarchar(50),

@City nvarchar(50) =null,

@State nvarchar(50) = null,

@ZipCode nvarchar(50) = null



AS

BEGIN

IF (@EmployeeName is null or TRIM(@EmployeeName) LIKE '') 
or (@FirstName    is null or TRIM(@FirstName)    LIKE '') 
or (@LastName     is null or TRIM(@LastName)     LIKE '')

BEGIN

        PRINT 'Contains null or spaces!'  

        RETURN  

END 

ELSE

IF LEN(@CompanyName)>20

BEGIN

 SET @CompanyName=SUBSTRING(@CompanyName, 1, 20)

END



INSERT INTO Person(FirstName, LastName)

VALUES (@FirstName,@LastName)

DECLARE @PersonId INT

SET @PersonId = SCOPE_IDENTITY()

INSERT into Address(Street, City, State, ZipCode)

VALUES (@Street, @City, @State, @ZipCode)

DECLARE @AddressId int

SET @AddressId = SCOPE_IDENTITY()

INSERT INTO Employee(EmployeeName,CompanyName,Position, AddressId, PersonId)

VALUES (@EmployeeName,@CompanyName,@Position, @AddressId, @PersonId)

End
