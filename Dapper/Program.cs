using MyDapper.Models;
using MyDapper.Repositories;
using MyDapper.Services;
using System;
using System.Collections.Generic;

namespace MyDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Category category;
            Category category2;
            City city;
            City city2;
            Country country;
            Country country2;
            Client client;
            Promotion promotion;
            Promotion promotion2;

            var db = new MailingService(new MailingRepository());

            int select = 0;
            do
            {
                Console.WriteLine("1 - Добавить Категорий\n2 - Вывести Категории\n3 - Добавить Город\n4 - Вывести Город\n5 - Добавить Категории\n6 - Добавить Городa\n7 - Добавить Страну\n"
                                  + "8 - Добавить Страны\n9 - Вывести Страны\n10 - Обновить Город\n11 - Обновить Страну\n12 - Удалить Страну\n13 - Удалить Город\n14 - Вывести email всех клиентов\n" +
                                  "15- Добавить клиента\n16- Вывести всех клиентов\n17- Обновить категорию\n18- Обновить клиента\n19- Удалить категорию\n20- Удалить клиента\n" +
                                  "21- Вывести все промошены\n22- Добавить промошин\n23- Добавить промошины\n24- Обновить промошин\n25- Удалить промошин\n26- Вывести категории по клиенту\n" +
                                  "27- Вывести города по стране\n28- Вывести клиента по городу\n29- Вывести клиентов по стране\n30- Вывести промошин по категории\n" +
                                  "31- Вывести промошин по стране\n32- Вывести промошин по продукту\n- 1 - Выход");
                int.TryParse(Console.ReadLine(), out select);
                if (select == -1)
                {
                    Console.WriteLine("Вы вышли с программы");
                    break;
                }
                else if (select == 1)
                {
                    category = new Category();
                    Console.WriteLine("Enter Category name: ");
                    category.Name = Console.ReadLine();

                    try
                    {
                        db.mailingRepository.AddCategory(category);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 2)
                {
                    Console.WriteLine("All categories: ");

                    try
                    {
                        var categories = db.mailingRepository.GetCategories();
                        for (int i = 0; i < categories.Count; i++) Console.WriteLine($"{i + 1}) " + categories[i].Name);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 3)
                {
                    city = new City();
                    Console.WriteLine("Enter City name: ");
                    city.Name = Console.ReadLine();

                    try
                    {
                        db.mailingRepository.AddCity(city);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 4)
                {
                    Console.WriteLine("All cities: ");

                    try
                    {
                        var cities = db.mailingRepository.GetCities();
                        for (int i = 0; i < cities.Count; i++) Console.WriteLine($"{i + 1}) " + cities[i].Name);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 5)
                {
                    category = new Category();
                    category2 = new Category();
                    Console.WriteLine("Enter category 1: ");
                    category.Name = Console.ReadLine();
                    Console.WriteLine("Enter category 2: ");
                    category2.Name = Console.ReadLine();

                    try
                    {
                        db.mailingRepository.AddCategory(category, category2);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 6)
                {
                    city = new City();
                    Console.WriteLine("Enter City name 1: ");
                    city.Name = Console.ReadLine();
                    city2 = new City();
                    Console.WriteLine("Enter City name 2: ");
                    city2.Name = Console.ReadLine();

                    try
                    {
                        db.mailingRepository.AddCity(city, city2);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 7)
                {
                    country = new Country();
                    Console.WriteLine("Enter Country name: ");
                    country.Name = Console.ReadLine();

                    try
                    {
                        db.mailingRepository.AddCountry(country);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 8)
                {
                    country = new Country();
                    Console.WriteLine("Enter Country 1: ");
                    country.Name = Console.ReadLine();
                    country2 = new Country();
                    Console.WriteLine("Enter Country 2: ");
                    country2.Name = Console.ReadLine();

                    try
                    {
                        db.mailingRepository.AddCountry(country, country2);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 9)
                {
                    Console.WriteLine("All country: ");

                    try
                    {
                        var countries = db.mailingRepository.GetCountries();
                        for (int i = 0; i < countries.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}) " + countries[i].Name);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 10)
                {
                    Console.WriteLine("All cities: ");

                    try
                    {
                        var cities = db.mailingRepository.GetCities();
                        for (int i = 0; i < cities.Count; i++)
                        {
                            Console.WriteLine($"{cities[i].Id}" + cities[i].Name);
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }

                    Console.WriteLine("Enter index for change: ");
                    int.TryParse(Console.ReadLine(), out int index);

                    city = new City { Id = index };
                    Console.Write("Enter City Name: ");
                    city.Name = Console.ReadLine();

                    try
                    {
                        db.mailingRepository.UpdateCity(city);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 11)
                {
                    Console.WriteLine("All countries: ");

                    List<Country> countries = null;

                    try
                    {
                        countries = db.mailingRepository.GetCountries();
                        for (int i = 0; i < countries.Count; i++)
                        {
                            Console.WriteLine($"{i+1} " + countries[i].Name);
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                    Console.Write("Enter index for change: ");
                    int.TryParse(Console.ReadLine(), out int index);
                    country = new Country { Id = countries[--index].Id };
                    Console.WriteLine(country.Id);
                    Console.Write("Enter country name: ");
                    country.Name = Console.ReadLine();

                    try
                    {
                        db.mailingRepository.UpdateCoutry(country);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 12)
                {
                    Console.WriteLine("All countries: ");

                    try
                    {
                       var countries = db.mailingRepository.GetCountries();
                        for (int i = 0; i < countries.Count; i++)
                        {
                            Console.WriteLine($"{countries[i].Id} " + countries[i].Name);
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                    Console.Write("Enter index for delete: ");
                    int.TryParse(Console.ReadLine(), out int index);

                    try
                    {
                        db.mailingRepository.DeleteCountry(index);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 13)
                {
                    Console.WriteLine("All cities: ");

                    try
                    {
                        var cities = db.mailingRepository.GetCities();
                        for (int i = 0; i < cities.Count; i++)
                        {
                            Console.WriteLine($"{cities[i].Id} " + cities[i].Name);
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }

                    Console.WriteLine("Entet index for delete: ");
                    int.TryParse(Console.ReadLine(), out int index);

                    try
                    {
                        db.mailingRepository.DeleteCity(index);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 14)
                {
                    Console.WriteLine("All emails: ");

                    try
                    {
                        var emails = db.mailingRepository.GetClientsEmail();
                        for (int i = 0; i < emails.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}) " + emails[i]);
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 15)
                {
                    client = new Client();
                    Console.WriteLine("Enter Client FullName: ");
                    client.FullName = Console.ReadLine();
                    Console.WriteLine("Enter Client DateOfBith: ");
                    client.DateOfBith = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Client Gender: ");
                    client.Gender = Console.ReadLine();
                    Console.WriteLine("Enter Client Email: ");
                    client.Email = Console.ReadLine();
                    Console.WriteLine("Enter Client CountryId: ");
                    int.TryParse(Console.ReadLine(), out int countryId);
                    client.CountryId = countryId;
                    Console.WriteLine("Enter Client CitiyId: ");
                    int.TryParse(Console.ReadLine(), out int cityId);
                    client.CityId = cityId;

                    try
                    {
                        db.mailingRepository.AddClient(client);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 16)
                {
                    Console.WriteLine("All clients: ");

                    try
                    {
                        var clients = db.mailingRepository.GetClients();
                        var countries = db.mailingRepository.GetCountries();
                        var cities = db.mailingRepository.GetCities();
                        for (int i = 0; i < clients.Count; i++)
                        {
                            for (int j = 0; j < countries.Count; j++)
                            {
                                for (int k = 0; k < cities.Count; k++)
                                {
                                    if (countries[j].Id == clients[i].CountryId && cities[k].Id == clients[i].CityId)
                                    {
                                        Console.WriteLine($"{i + 1}) " + " " + clients[i].FullName + " " + clients[i].DateOfBith + " " + " " + clients[i].Gender + " "
                                        + " " + clients[i].Email + " " + $"{clients[i].CountryId}) " + countries[j].Name + " " + $"{clients[i].CityId}) " + cities[k].Name);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 17)
                {
                    Console.WriteLine("All categories: ");

                    List<Category> categories = null;

                    try
                    {
                        categories = db.mailingRepository.GetCategories();
                        for (int i = 0; i < categories.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} " + categories[i].Name);
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                    Console.Write("Enter index for change: ");
                    int.TryParse(Console.ReadLine(), out int index);
                    category = new Category { Id = categories[--index].Id };
                    Console.WriteLine(category.Id);
                    Console.Write("Enter category name: ");
                    category.Name = Console.ReadLine();

                    try
                    {
                        db.mailingRepository.UpdateCategory(category);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 18)
                {
                    Console.WriteLine("All clients: ");

                    List<Client> clients = null;

                    try
                    {
                        clients = db.mailingRepository.GetClients();
                        for (int i = 0; i < clients.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} " + clients[i].FullName + " " + clients[i].DateOfBith + " " + clients[i].Gender + " " + clients[i].Email + " "
                                + clients[i].CountryId + " " + clients[i].CityId);
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                    Console.Write("Enter index for change: ");
                    int.TryParse(Console.ReadLine(), out int index);
                    client = new Client { Id = clients[--index].Id };
                    Console.WriteLine(client.Id);
                    Console.Write("Enter client FullName: ");
                    client.FullName = Console.ReadLine();
                    Console.WriteLine("Enter client DateOfBith: ");
                    client.DateOfBith = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter client Gender: ");
                    client.Gender = Console.ReadLine();
                    Console.WriteLine("Enter clien Email: ");
                    client.Email = Console.ReadLine();
                    Console.WriteLine("Enter client CountryId: ");
                    int.TryParse(Console.ReadLine(), out int countryId);
                    client.CountryId = countryId;
                    Console.WriteLine("Enter client CityId: ");
                    int.TryParse(Console.ReadLine(), out int cityId);
                    client.CityId = cityId;

                    try
                    {
                        db.mailingRepository.UpdateClient(client);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 19)
                {
                    Console.WriteLine("All categories: ");

                    try
                    {
                        var categories = db.mailingRepository.GetCategories();
                        for (int i = 0; i < categories.Count; i++)
                        {
                            Console.WriteLine($"{categories[i].Id} " + categories[i].Name);
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                    Console.Write("Enter index for delete: ");
                    int.TryParse(Console.ReadLine(), out int index);

                    try
                    {
                        db.mailingRepository.DeleteCategory(index);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 20)
                {
                    Console.WriteLine("All clients: ");

                    try
                    {
                        var clients = db.mailingRepository.GetClients();
                        for (int i = 0; i < clients.Count; i++)
                        {
                            Console.WriteLine($"{clients[i].Id}) " + clients[i].FullName + " " + clients[i].DateOfBith + " " + clients[i].Gender + " " + clients[i].Email + " "
                                + clients[i].CountryId + " " + clients[i].CityId);
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                    Console.Write("Enter index for delete: ");
                    int.TryParse(Console.ReadLine(), out int index);

                    try
                    {
                        db.mailingRepository.DeleteClient(index);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 21)
                {
                    Console.WriteLine("All promotion: ");

                    try
                    {
                        var promotions = db.mailingRepository.GetPromotions();
                        for (int i = 0; i < promotions.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}) " + " " + promotions[i].Percent + " " + promotions[i].StartDate + " " + " " + promotions[i].EndDate + " "
                                        +  promotions[i].CountryId + " " + promotions[i].ProductId);
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 22)
                {
                    promotion = new Promotion();
                    Console.WriteLine("Enter Percent: ");
                    int.TryParse(Console.ReadLine(), out int percent);
                    promotion.Percent = percent;
                    Console.WriteLine("Enter StartDate: ");
                    promotion.StartDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter EndDate: ");
                    promotion.EndDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter CountryId: ");
                    int.TryParse(Console.ReadLine(), out int countryId);
                    promotion.CountryId = countryId;
                    Console.WriteLine("Enter ProductId: ");
                    int.TryParse(Console.ReadLine(), out int productId);
                    promotion.ProductId = productId;

                    try
                    {
                        db.mailingRepository.AddPromotion(promotion);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 23)
                {
                    promotion = new Promotion();
                    Console.WriteLine("Enter Percent: ");
                    int.TryParse(Console.ReadLine(), out int percent);
                    promotion.Percent = percent;
                    Console.WriteLine("Enter StartDate: ");
                    promotion.StartDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter EndDate: ");
                    promotion.EndDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter CountryId: ");
                    int.TryParse(Console.ReadLine(), out int countryId);
                    promotion.CountryId = countryId;
                    Console.WriteLine("Enter ProductId: ");
                    int.TryParse(Console.ReadLine(), out int productId);
                    promotion.ProductId = productId;

                    promotion2 = new Promotion();
                    Console.WriteLine("Enter Percent2: ");
                    int.TryParse(Console.ReadLine(), out int percent2);
                    promotion2.Percent = percent2;
                    Console.WriteLine("Enter StartDate2: ");
                    promotion2.StartDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter EndDate2: ");
                    promotion2.EndDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter CountryId2: ");
                    int.TryParse(Console.ReadLine(), out int countryId2);
                    promotion2.CountryId = countryId2;
                    Console.WriteLine("Enter ProductId2: ");
                    int.TryParse(Console.ReadLine(), out int productId2);
                    promotion.ProductId = productId2;

                    try
                    {
                        db.mailingRepository.AddPromotion(promotion, promotion2);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 24)
                {
                    List<Promotion> promotions = null;

                    Console.WriteLine("All promotion: ");

                    try
                    {
                        promotions = db.mailingRepository.GetPromotions();
                        for (int i = 0; i < promotions.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}) " + " " + promotions[i].Percent + " " + promotions[i].StartDate + " " + " " + promotions[i].EndDate + " "
                                        + promotions[i].CountryId + " " + promotions[i].ProductId);
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }

                    Console.Write("Enter index for change: ");
                    int.TryParse(Console.ReadLine(), out int index);
                    promotion = new Promotion { Id = promotions[--index].Id };
                    Console.WriteLine(promotion.Id);
                    Console.WriteLine("Enter Percent: ");
                    int.TryParse(Console.ReadLine(), out int percent);
                    promotion.Percent = percent;
                    Console.WriteLine("Enter StartDate: ");
                    promotion.StartDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter EndDate: ");
                    promotion.EndDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter CountryId: ");
                    int.TryParse(Console.ReadLine(), out int countryId);
                    promotion.CountryId = countryId;
                    Console.WriteLine("Enter ProductId: ");
                    int.TryParse(Console.ReadLine(), out int productId);
                    promotion.ProductId = productId;

                    try
                    {
                        db.mailingRepository.UpdatePromotion(promotion);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 25)
                {
                    Console.WriteLine("All promotion: ");

                    try
                    {
                        var promotions = db.mailingRepository.GetPromotions();
                        for (int i = 0; i < promotions.Count; i++)
                        {
                            Console.WriteLine($"{promotions[i].Id}) " + " " + promotions[i].Percent + " " + promotions[i].StartDate + " " + " " + promotions[i].EndDate + " "
                                        + promotions[i].CountryId + " " + promotions[i].ProductId);
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }

                    Console.Write("Enter index for delete: ");
                    int.TryParse(Console.ReadLine(), out int index);

                    try
                    {
                        db.mailingRepository.DeletePromotion(index);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 26)
                {
                    Console.WriteLine("Enter FullName Client: ");
                    var clientForCat = Console.ReadLine();
                    Console.WriteLine("All categories for client: ");

                    try
                    {
                        var categories = db.mailingRepository.GetCategoriesByClient(clientForCat);
                        for (int i = 0; i < categories.Count; i++)
                        {
                            Console.WriteLine(categories[i].Name);
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 27)
                {
                    Console.Write("Enter Country Name: ");
                    var countryForCities = Console.ReadLine();
                    Console.WriteLine("All cities for country: ");

                    try
                    {
                        var cities = db.mailingRepository.GetCitiesByCountry(countryForCities);
                        for (int i = 0; i < cities.Count; i++)
                        {
                            Console.WriteLine(cities[i].Name);
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 28)
                {
                    Console.Write("Enter City Name: ");
                    var cityForCl = Console.ReadLine();
                    Console.WriteLine("All clients for city: ");

                    try
                    {
                        var clients = db.mailingRepository.GetClientsByCity(cityForCl);
                        for (int i = 0; i < clients.Count; i++)
                        {
                            Console.WriteLine(clients[i].FullName);
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 29)
                {
                    Console.Write("Enter Country Name: ");
                    var countryForCl = Console.ReadLine();
                    Console.WriteLine("All clients for country: ");

                    try
                    {
                        var clients = db.mailingRepository.GetClientsByCountry(countryForCl);
                        for (int i = 0; i < clients.Count; i++)
                        {
                            Console.WriteLine(clients[i].FullName);
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 30)
                {
                    Console.Write("Enter Category Name: ");
                    var categoryForPr = Console.ReadLine();
                    Console.WriteLine("All promotions for categories: ");

                    try
                    {
                        var promotions = db.mailingRepository.GetPromotionsByCategory(categoryForPr);
                        for (int i = 0; i < promotions.Count; i++)
                        {
                            Console.WriteLine("Percent: " + promotions[i].Percent + " " + "StartDate: " + promotions[i].StartDate + " "
                                + "EndDate: " + promotions[i].EndDate);
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 31)
                {
                    Console.Write("Enter Country Name: ");
                    var countryForPr = Console.ReadLine();
                    Console.WriteLine("All promotions for country: ");

                    try
                    {
                        var promotions = db.mailingRepository.GetPromotionsByCountry(countryForPr);
                        for (int i = 0; i < promotions.Count; i++)
                        {
                            Console.WriteLine($"{promotions[i].Id}) " + " " + "Percent: " + promotions[i].Percent + " " + "StartDate: " + promotions[i].StartDate + " "
                                + "EndDate: " + promotions[i].EndDate);
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (select == 32)
                {
                    Console.Write("Enter Product Name: ");
                    var productForPr = Console.ReadLine();
                    Console.WriteLine("All promotions for product: ");

                    try
                    {
                        var promotions = db.mailingRepository.GetPromotionsProducts(productForPr);
                        for (int i = 0; i < promotions.Count; i++)
                        {
                            Console.WriteLine($"{promotions[i].Id}) " + " " + "Percent: " + promotions[i].Percent + " " + "StartDate: " + promotions[i].StartDate + " "
                                + "EndDate: " + promotions[i].EndDate);
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                Console.WriteLine();
            } while (true);
        }
    }
}
