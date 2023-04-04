using Dapper;
using Microsoft.Data.SqlClient;
using MyDapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyDapper.Repositories
{
    public class MailingRepository : IMailingRepository
    {
        private readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MailingsDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void AddCategory(Category category)
        {
            using var db = new SqlConnection(connectionString);
            var query = "INSERT INTO Categories ([Name]) VALUES (@Name)";
            db.Execute(query, category);
        }

        public void AddCategory(params Category[] category)
        {
            using var db = new SqlConnection(connectionString);
            var query = "INSERT INTO Categories([Name]) VALUES (@Name)";
            db.Execute(query, category);
        }

        public void AddCity(City city)
        {
            using var db = new SqlConnection(connectionString);
            var query = "INSERT INTO Cities ([Name]) VALUES (@Name)";
            db.Execute(query, city);
        }

        public void AddCity(params City[] city)
        {
            using var db = new SqlConnection(connectionString);
            var query = "INSERT INTO Cities ([Name]) VALUES (@Name)";
            db.Execute(query, city);
        }

        public void AddClient(Client client)
        {
            using var db = new SqlConnection(connectionString);
            var query = "INSERT INTO Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) VALUES (@FullName, @DateOfBith, @Gender, @Email, @CountryId, @CityId)";
            db.Execute(query, client);
        }

        public void AddCountry(Country country)
        {
            using var db = new SqlConnection(connectionString);
            var query = "INSERT INTO Countries ([Name]) VALUES (@Name)";
            db.Execute(query, country);
        }

        public void AddCountry(params Country[] country)
        {
            using var db = new SqlConnection(connectionString);
            var query = "INSERT INTO Countries ([Name]) VALUES (@Name)";
            db.Execute(query, country);
        }

        public void AddPromotion(Promotion promotion)
        {
            using var db = new SqlConnection(connectionString);
            var query = "INSERT INTO Promotions ([Percent], StartDate, EndDate, CountryId, ProducId) " +
                "VALUES (@Percent, @StartDate, @EndDate, @CountryId, @ProductId)";
            db.Execute(query, promotion);
        }

        public void AddPromotion(params Promotion[] promotion)
        {
            using var db = new SqlConnection(connectionString);
            var query = "INSERT INTO Promotions ([Percent], StartDate, EndDate, CountryId, ProducId) " +
                "VALUES (@Percent, @StartDate, @EndDate, @CountryId, @ProductId)";
            db.Execute(query, promotion);
        }

        public void DeleteCategory(int id)
        {
            using var db = new SqlConnection(connectionString);
            var query = "DELETE FROM Categories WHERE Id = @id";
            db.Execute(query, new { id });
        }

        public void DeleteCity(int id)
        {
            using var db = new SqlConnection(connectionString);
            var query = "DELETE FROM Cities WHERE Id = @id";
            db.Execute(query, new { id });
        }

        public void DeleteClient(int id)
        {
            using var db = new SqlConnection(connectionString);
            var query = "DELETE FROM Clients WHERE Id = @id";
            db.Execute(query, new { id });
        }

        public void DeleteCountry(int id)
        {
            using var db = new SqlConnection(connectionString);
            var query = "DELETE FROM Countries WHERE Id = @id";
            db.Execute(query, new { id });
        }

        public void DeletePromotion(int id)
        {
            using var db = new SqlConnection(connectionString);
            var query = "DELETE FROM Promotions WHERE Id = @id";
            db.Execute(query, new { id });
        }

        public List<Category> GetCategories()
        {
            using var db = new SqlConnection(connectionString);
            var query = "SELECT * FROM Categories";
            return db.Query<Category>(query).ToList();
        }

        public List<Category> GetCategoriesByClient(string client)
        {
            using var db = new SqlConnection(connectionString);
            var query = "SELECT ct.Name FROM InterestedBuyers ib JOIN Categories ct ON ib.CategoryId = ct.Id JOIN Clients cl ON ib.ClientId = cl.Id where cl.FullName = @client";
            var categories = db.Query<Category>(query, new { client });
            return categories.ToList();
        }

        public List<City> GetCities()
        {
            using var db = new SqlConnection(connectionString);
            var query = "SELECT * FROM Cities";
            return db.Query<City>(query).ToList();
        }

        public List<City> GetCitiesByCountry(string country)
        {
            using var db = new SqlConnection(connectionString);
            var query = "SELECT ci.Name FROM Clients cl JOIN Cities ci ON cl.CityId = ci.Id JOIN Countries co ON cl.CountryId = co.Id where co.Name = @country";
            var cities = db.Query<City>(query, new { country });
            return cities.ToList();
        }

        public List<Client> GetClients()
        {
            using var db = new SqlConnection(connectionString);
            var query = "SELECT * FROM Clients";
            return db.Query<Client>(query).ToList();
        }

        public List<Client> GetClientsByCity(string city)
        {
            using var db = new SqlConnection(connectionString);
            var query = "SELECT cl.Id, cl.FullName, cl.Gender FROM Clients cl, Cities ci where cl.CityId = ci.Id and ci.Name = @city";
            return db.Query<Client>(query, new { city }).ToList();
        }

        public List<Client> GetClientsByCountry(string country)
        {
            using var db = new SqlConnection(connectionString);
            var query = "SELECT cl.Id, cl.FullName, cl.Gender FROM Clients cl, Countries co where cl.CountryId = co.Id and co.Name = @country";
            return db.Query<Client>(query, new { country }).ToList();
        }

        public List<string> GetClientsEmail()
        {
            using var db = new SqlConnection(connectionString);
            var query = "SELECT Email FROM Clients";
            return db.Query<string>(query).ToList();
        }

        public List<Country> GetCountries()
        {
           using var db = new SqlConnection(connectionString);
            var query = "SELECT * FROM Countries";
            return db.Query<Country>(query).ToList();
        }

        public List<Product> GetProducts()
        {
            using var db = new SqlConnection(connectionString);
            var query = "SELECT * FROM Products";
            return db.Query<Product>(query).ToList();
        }

        public List<Promotion> GetPromotions()
        {
            using var db = new SqlConnection(connectionString);
            var query = "SELECT * FROM Promotions";
            return db.Query<Promotion>(query).ToList();
        }

        public List<Promotion> GetPromotionsByCategory(string category)
        {
            using var db = new SqlConnection(connectionString);
            var query = "SELECT pr.[Percent], pr.StartDate, pr.EndDate, pr.CountryId, pr.ProducId FROM Promotions pr JOIN Products p ON pr.ProducId = p.Id JOIN Categories c ON p.CategoryId = c.Id where c.Name = @category";
            return db.Query<Promotion>(query, new { category }).ToList();
        }

        public List<Promotion> GetPromotionsByCountry(string country)
        {
            using var db = new SqlConnection(connectionString);
            var query = "SELECT pr.Id, pr.[Percent], pr.StartDate, pr.EndDate, pr.ProducId FROM Promotions pr, Countries co, Products p where pr.CountryId = co.Id and pr.ProducId = p.Id and co.Name = @country";
            return db.Query<Promotion>(query, new { country }).ToList();
        }

        public List<Promotion> GetPromotionsProducts(string product)
        {
            using var db = new SqlConnection(connectionString);
            var query = "SELECT pr.Id, pr.[Percent], pr.StartDate, pr.EndDate, pr.CountryId, pr.ProducId FROM Promotions pr, Countries co, Products p where pr.CountryId = co.Id and pr.ProducId = p.Id and p.Name = @product";
            return db.Query<Promotion>(query, new { product }).ToList();
        }

        public void UpdateCategory(Category category)
        {
            using var db = new SqlConnection(connectionString);
            var query = @"UPDATE Categories SET Name = @Name WHERE Id = @id";
            db.Execute(query, category);
        }

        public void UpdateCity(City city)
        {
            using var db = new SqlConnection(connectionString);
            var query = @"UPDATE Cities SET Name = @Name WHERE Id = @id";
            db.Execute(query, city);
        }

        public void UpdateClient(Client client)
        {
            using var db = new SqlConnection(connectionString);
            var query = @"UPDATE Clients SET FullName = @FullName, DateOfBith = @DateBith, Gender = @Gender, Email = @Email, CountryId = @CountryId, CityId = @CityId WHERE Id = @id";
            db.Execute(query, client);
        }

        public void UpdateCoutry(Country country)
        {
            using var db = new SqlConnection(connectionString);
            var query = @"UPDATE Countries SET Name = @Name WHERE Id = @id";
            db.Execute(query, country);
        }

        public void UpdatePromotion(Promotion promotion)
        {
            using var db = new SqlConnection(connectionString);
            var query = @"UPDATE Promotions SET
            [Percent] = @Percent, StartDate = @StartDate, EndDate = @EndDate,
            CountryId = @CountryId, ProducId = @ProductId
            WHERE Id = @id";
            db.Execute(query, promotion);
        }
    }
}
