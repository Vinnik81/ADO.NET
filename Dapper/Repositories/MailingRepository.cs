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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void AddPromotion(params Promotion[] promotion)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteCity(int id)
        {
            using var db = new SqlConnection(connectionString);
            var query = "DELETE FROM Cities WHERE Id = @id";
            db.Execute(query, new { id });
        }

        public void DeleteClient(int id)
        {
           
        }

        public void DeleteCountry(int id)
        {
            using var db = new SqlConnection(connectionString);
            var query = "DELETE FROM Countries WHERE Id = @id";
            db.Execute(query, id);
        }

        public void DeletePromotion(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategories()
        {
            using var db = new SqlConnection(connectionString);
            var query = "SELECT * FROM Categories";
            return db.Query<Category>(query).ToList();
        }

        public List<Category> GetCategoriesByClient(string client)
        {
            throw new NotImplementedException();
        }

        public List<City> GetCities()
        {
            using var db = new SqlConnection(connectionString);
            var query = "SELECT * FROM Cities";
            return db.Query<City>(query).ToList();
        }

        public List<City> GetCitiesByCountry(string country)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetClients()
        {
            throw new NotImplementedException();
        }

        public List<Client> GetClientsByCity(string city)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetClientsByCountry(string country)
        {
            throw new NotImplementedException();
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

        public List<Promotion> GetPromotions()
        {
            throw new NotImplementedException();
        }

        public List<Promotion> GetPromotionsByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public List<Promotion> GetPromotionsByCountry(string country)
        {
            throw new NotImplementedException();
        }

        public List<Promotion> GetPromotionsProducts()
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void UpdateCity(City city)
        {
            using var db = new SqlConnection(connectionString);
            var query = @"UPDATE Cities SET Name = @Name WHERE Id = @id";
            db.Execute(query, city);
        }

        public void UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }

        public void UpdateCoutry(Country country)
        {
            using var db = new SqlConnection(connectionString);
            var query = @"UPDATE Countries SET Name = @Name WHERE Id = @id";
            db.Execute(query, country);
        }

        public void UpdatePromotion(Promotion promotion)
        {
            throw new NotImplementedException();
        }
    }
}
