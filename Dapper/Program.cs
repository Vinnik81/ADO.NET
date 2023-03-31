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

            var db = new MailingService(new MailingRepository());

            int select = 0;
            do
            {
                Console.WriteLine("1 - Добавить Категорий\n2 - Вывести Категории\n3 - Добавить Город\n4 - Вывести Город\n5 - Добавить Категории\n6 - Добавить Городa\n7 - Добавить Страну\n"
                                  + "8 - Добавить Страны\n9 - Вывести Страны\n10 - Обновить Город\n11 - Обновить Страну\n12 - Удалить Страну\n13 - Удалить Город\n14 - Вывести email всех клиентов\n- 1 - Выход");
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
                Console.WriteLine();
            } while (true);
        }
    }
}
