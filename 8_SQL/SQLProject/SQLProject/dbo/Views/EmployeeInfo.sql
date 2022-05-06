
CREATE VIEW [dbo].[EmployeeInfo]
	AS

SELECT TOP 1000 e.Id, (CASE WHEN e.EmployeeName IS NULL THEN CONCAT(p.FirstName,' ', p.LastName) ELSE e.EmployeeName END) AS employeeName,

CONCAT(a.zipCode, '_', a.state,',',a.city,'-',a.street) AS EmployeeFullAddress,

concat(e.companyName,'(',e.position,')') AS EmployeeCompanyInfo

FROM employee e 

inner join Address a ON e.addressId=a.Id
inner join Person p ON e.PersonId = p.Id

ORDER BY a.City ASC;
	