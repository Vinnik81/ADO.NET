USE MailingsDb
GO
SELECT * FROM Cities;
SELECT * FROM Countries;
SELECT * FROM Clients;
SELECT * FROM Categories;
SELECT * FROM Promotions;
SELECT * FROM Products;
SELECT * FROM InterestedBuyers;
SELECT ct.Name FROM InterestedBuyers ib JOIN Categories ct ON ib.CategoryId = ct.Id JOIN Clients cl ON ib.ClientId = cl.Id where cl.FullName = 'Valentino Flannigan';
SELECT ci.Name FROM Clients cl JOIN Cities ci ON cl.CityId = ci.Id JOIN Countries co ON cl.CountryId = co.Id where co.Name = 'Russian';
SELECT cl.Id, cl.FullName, cl.Gender FROM Clients cl, Cities ci where cl.CityId = ci.Id and ci.Name = 'Moscow';
SELECT cl.Id, cl.FullName, cl.Gender FROM Clients cl, Countries co where cl.CountryId = co.Id and co.Name = 'Russian';
SELECT pr.[Percent], pr.StartDate, pr.EndDate, pr.CountryId, pr.ProducId FROM Promotions pr JOIN Products p ON pr.ProducId = p.Id JOIN Categories c ON p.CategoryId = c.Id where c.Name = 'Cars';
SELECT pr.Id, pr.[Percent], pr.StartDate, pr.EndDate, pr.ProducId FROM Promotions pr, Countries co, Products p where pr.CountryId = co.Id and pr.ProducId = p.Id and co.Name = 'Russian';
SELECT pr.Id, pr.[Percent], pr.StartDate, pr.EndDate, pr.CountryId, pr.ProducId FROM Promotions pr, Countries co, Products p where pr.CountryId = co.Id and pr.ProducId = p.Id and p.Name = 'Camry';