using Microsoft.Data.SqlClient;
using System;

namespace HomeWork1_ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MailingsDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Connection...");

            Console.WriteLine("1-Вставка страны; 2-Вставка города; 3-Вставка инф-и о новом разделе; 4-Вставка нового аукционного товара;"
                + "5-Вставка нового клиента;");

            int.TryParse(Console.ReadLine(), out int num);
            switch (num)
            {
                case 1:
                    // Вставка новых стран
                    Console.WriteLine("Введите название страны: ");
                    var CountryName = Console.ReadLine();
                    if (string.IsNullOrEmpty(CountryName)) CountryName = "NoName";
                    Console.WriteLine(CountryName);
                    var queryCountry = "INSERT INTO Countries(Name)" + $"VALUES(@CountryName)";
                    var commandCountry = new SqlCommand(queryCountry, connection);
                    var paramNameCountry = new SqlParameter("@CountryName", CountryName);
                    commandCountry.Parameters.Add(paramNameCountry);
                    var resultCountry = (int)commandCountry.ExecuteNonQuery();
                    if (resultCountry > 0) Console.WriteLine($"Добавленно строк: {resultCountry}");
                    else Console.WriteLine("Данные не добавлены!");
                    break;

                case 2:
                    // Вставка новых городов
                    Console.WriteLine("Введите название города: ");
                    var CityName = Console.ReadLine();
                    if (string.IsNullOrEmpty(CityName)) CityName = "NoName";
                    Console.WriteLine(CityName);
                    var queryCity = "INSERT INTO Cities(Name)" + $"VALUES(@CityName)";
                    var commandCity = new SqlCommand(queryCity, connection);
                    var paramNameCity = new SqlParameter("@CityName", CityName);
                    commandCity.Parameters.Add(paramNameCity);
                    var resultCity = (int)commandCity.ExecuteNonQuery();
                    if (resultCity > 0) Console.WriteLine($"Добавленно строк: {resultCity}");
                    else Console.WriteLine("Данные не добавлены!");
                    break;

                case 3:
                    // Вставка инф-и о новом разделе
                    Console.WriteLine("Введите название категоии: ");
                    var CategoriesName = Console.ReadLine();
                    if (string.IsNullOrEmpty(CategoriesName)) CategoriesName = "NoName";
                    Console.WriteLine(CategoriesName);
                    var queryCategories = "INSERT INTO Categories(Name)" + $"VALUES(@CategoriesName)";
                    var commandCategories = new SqlCommand(queryCategories, connection);
                    var paramNameCategories = new SqlParameter("@CategoriesName", CategoriesName);
                    commandCategories.Parameters.Add(paramNameCategories);
                    var resultCategories = (int)commandCategories.ExecuteNonQuery();
                    if (resultCategories > 0) Console.WriteLine($"Добавленно строк: {resultCategories}");
                    else Console.WriteLine("Данные не добавлены!");
                    break;

                case 4:
                    // Вставка нового аукционного товара
                    Console.WriteLine("Введите названия товара: ");
                    var ProductName = Console.ReadLine();
                    if (string.IsNullOrEmpty(ProductName)) ProductName = "NoName";
                    Console.WriteLine(ProductName);
                    Console.WriteLine("Введите Id категории: ");
                    int.TryParse(Console.ReadLine(), out int categoryId);
                    Console.WriteLine(categoryId);
                    var queryProduct = "INSERT INTO Products(Name, CategoryId)" + $"VALUES(@ProductName, @categoryId)";
                    var commandProduct = new SqlCommand(queryProduct, connection);
                    var paramNameProduct = new SqlParameter("@ProductName", ProductName);
                    var paramNameCategoryId = new SqlParameter("@categoryId", categoryId);
                    commandProduct.Parameters.Add(paramNameProduct);
                    commandProduct.Parameters.Add(paramNameCategoryId);
                    var resultProduct = commandProduct.ExecuteNonQuery();
                    if (resultProduct > 0) Console.WriteLine($"Добавленно строк: {resultProduct}");
                    else Console.WriteLine("Данные не добавлены!");
                    break;

                case 5:
                    // Вставка нового клиента
                    Console.WriteLine("Введите имя и фамилию клиента: ");
                    var fullName = Console.ReadLine();
                    if (string.IsNullOrEmpty(fullName)) fullName = "NoName";
                    Console.WriteLine(fullName);
                    Console.WriteLine("Введите дату рождения: ");
                    var dateOfBith = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine(dateOfBith);
                    Console.WriteLine("Введите пол: ");
                    var gender = Console.ReadLine();
                    if (string.IsNullOrEmpty(gender)) gender = "NoName";
                    Console.WriteLine(gender);
                    Console.WriteLine("Введите Email: ");
                    var email = Console.ReadLine();
                    if (string.IsNullOrEmpty(email)) email = "NoName";
                    Console.WriteLine(email);
                    Console.WriteLine("Введите Id Country: ");
                    int.TryParse(Console.ReadLine(), out int countryId);
                    Console.WriteLine(countryId);
                    Console.WriteLine("Введите Id City: ");
                    int.TryParse(Console.ReadLine(), out int cityId);
                    Console.WriteLine(cityId);
                    var queryClient = "INSERT INTO Clients(FullName, DateOfBith, Gender, Email, CountryId, CityId)" + 
                        $"VALUES(@fullName, @dateOfBith, @gender, @email, @countryId, @cityId)";
                    var commandClient = new SqlCommand(queryClient, connection);
                    var paramNameFullName = new SqlParameter("@fullName", fullName);
                    var paramNameDateOfBith = new SqlParameter("@dateOfBith", dateOfBith);
                    var paramGender = new SqlParameter("@gender", gender);
                    var paramEmail = new SqlParameter("@email", email);
                    var paramCountryId = new SqlParameter("@countryId", countryId);
                    var paramCityId = new SqlParameter("@cityId", cityId);
                    commandClient.Parameters.Add(paramNameFullName);
                    commandClient.Parameters.Add(paramNameDateOfBith);
                    commandClient.Parameters.Add(paramGender);
                    commandClient.Parameters.Add(paramEmail);
                    commandClient.Parameters.Add(paramCountryId);
                    commandClient.Parameters.Add(paramCityId);
                    var resultClient = commandClient.ExecuteNonQuery();
                    if (resultClient > 0) Console.WriteLine($"Добавленно строк: {resultClient}");
                    else Console.WriteLine("Данные не добавлены!");
                    break;

                default:
                    Console.WriteLine("Неправельна набрана цифра!");
                    break;
            }
        }
    }
}
