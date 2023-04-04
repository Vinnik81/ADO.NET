using MyDapper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDapper.Repositories
{
   public interface IMailingRepository
    {
        ///////////////////////////////////////////////////////////////

        void AddClient(Client client);
        void AddCity(City city);
        void AddCity(params City[] city);
        void AddCountry(Country country);
        void AddCountry(params Country[] country);
        void AddCategory(Category category);
        void AddCategory(params Category[] category);
        void AddPromotion(Promotion promotion);
        void AddPromotion(params Promotion[] promotion);

        //////////////////////////////////////////////////////////

        List<Client> GetClients();
        List<string> GetClientsEmail();
        List<Category> GetCategories();
        List<City> GetCities();
        List<Country> GetCountries();
        List<Client> GetClientsByCountry(string country);
        List<Client> GetClientsByCity(string city);
        List<Promotion> GetPromotions();
        List<Promotion> GetPromotionsByCountry(string country);
        List<City> GetCitiesByCountry(string country);
        List<Category> GetCategoriesByClient(string client);
        List<Promotion> GetPromotionsByCategory(string category);
        List<Promotion> GetPromotionsProducts(string product);
        List<Product> GetProducts();

        ////////////////////////////////////////////////////////////

        void UpdateClient(Client client);
        void UpdateCoutry(Country country);
        void UpdateCity(City city);
        void UpdateCategory(Category category);
        void UpdatePromotion(Promotion promotion);

        /////////////////////////////////////////////////////////////////

        void DeleteClient(int id);
        void DeleteCountry(int id);
        void DeleteCity(int id);
        void DeleteCategory(int id);
        void DeletePromotion(int id);
    }
}
