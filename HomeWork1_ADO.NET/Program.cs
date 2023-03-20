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

            Console.WriteLine("1-Вставка страны;\n2-Вставка города;\n3-Вставка инф-и о новом разделе;\n4-Вставка нового аукционного товара;\n"
                + "5-Вставка нового клиента;\n6-Обновление информации о покупателях;\n7-Обновление информации о странах;\n8-Обновление информации о городах;\n9-Обновление информации о разделах;\n"
                + "10-Обновление информации об акционных товарах;\n11-Удаление информации о покупателях;\n12-Удаление информации о странах;\n13-Удаление информации о городах;\n"
                + "14-Удаление информации о разделах;\n15-Удаление информации об акционных товарах.");

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

                case 6:
                    // Обновление информации о покупателях
                    Console.WriteLine("Введите Id для обновления: ");
                    int.TryParse(Console.ReadLine(), out int ClientId);
                    Console.WriteLine("Введите имя и фамилию клиента: ");
                    var fullNameNew = Console.ReadLine();
                    if (string.IsNullOrEmpty(fullNameNew)) fullNameNew = "NoName";
                    Console.WriteLine(fullNameNew);
                    Console.WriteLine("Введите дату рождения: ");
                    var dateOfBithNew = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine(dateOfBithNew);
                    Console.WriteLine("Введите пол: ");
                    var genderNew = Console.ReadLine();
                    if (string.IsNullOrEmpty(genderNew)) genderNew = "NoName";
                    Console.WriteLine(genderNew);
                    Console.WriteLine("Введите Email: ");
                    var emailNew = Console.ReadLine();
                    if (string.IsNullOrEmpty(emailNew)) emailNew = "NoName";
                    Console.WriteLine(emailNew);
                    Console.WriteLine("Введите Id Country: ");
                    int.TryParse(Console.ReadLine(), out int countryIdNew);
                    Console.WriteLine(countryIdNew);
                    Console.WriteLine("Введите Id City: ");
                    int.TryParse(Console.ReadLine(), out int cityIdNew);
                    Console.WriteLine(cityIdNew);
                    var queryClientUpdate = @"UPDATE Clients 
                                            SET FullName = @fullNameNew , DateOfBith = @dateOfBithNew, Gender = @genderNew, Email = @emailNew, CountryId = @countryIdNew, CityId = @cityIdNew
                                             WHERE Id = @ClientId";
                    var commandClientUpdate = new SqlCommand(queryClientUpdate, connection);
                    var paramClientId = new SqlParameter("@ClientId", ClientId);
                    var paramNameFullNameNew = new SqlParameter("@fullNameNew", fullNameNew);
                    var paramNameDateOfBithNew = new SqlParameter("@dateOfBithNew", dateOfBithNew);
                    var paramGenderNew = new SqlParameter("@genderNew", genderNew);
                    var paramEmailNew = new SqlParameter("@emailNew", emailNew);
                    var paramCountryIdNew = new SqlParameter("@countryIdNew", countryIdNew);
                    var paramCityIdNew = new SqlParameter("@cityIdNew", cityIdNew);
                    commandClientUpdate.Parameters.Add(paramClientId);
                    commandClientUpdate.Parameters.Add(paramNameFullNameNew);
                    commandClientUpdate.Parameters.Add(paramNameDateOfBithNew);
                    commandClientUpdate.Parameters.Add(paramGenderNew);
                    commandClientUpdate.Parameters.Add(paramEmailNew);
                    commandClientUpdate.Parameters.Add(paramCountryIdNew);
                    commandClientUpdate.Parameters.Add(paramCityIdNew);
                    var resultClientNew = commandClientUpdate.ExecuteNonQuery();
                    if (resultClientNew > 0) Console.WriteLine($"Добавленно строк: {resultClientNew}");
                    else Console.WriteLine("Данные не добавлены!");
                    break;

                case 7:
                    // Обновление информации о странах
                    Console.WriteLine("Введите Id для обновления: ");
                    int.TryParse(Console.ReadLine(), out int CountryIdUpdate);
                    Console.WriteLine("Введите название страны: ");
                    var CountryNameNew = Console.ReadLine();
                    if (string.IsNullOrEmpty(CountryNameNew)) CountryNameNew = "NoName";
                    Console.WriteLine(CountryNameNew);
                    var queryCountryUpdate = @"UPDATE Countries SET Name = @CountryNameNew WHERE Id = @CountryIdUpdate";
                    var commandCountryUpdate = new SqlCommand(queryCountryUpdate, connection);
                    var paramCountryIdUpdate = new SqlParameter("@CountryIdUpdate", CountryIdUpdate);
                    var paramNameCountryNew = new SqlParameter("@CountryNameNew", CountryNameNew);
                    commandCountryUpdate.Parameters.Add(paramCountryIdUpdate);
                    commandCountryUpdate.Parameters.Add(paramNameCountryNew);
                    var resultCountryNew = (int)commandCountryUpdate.ExecuteNonQuery();
                    if (resultCountryNew > 0) Console.WriteLine($"Добавленно строк: {resultCountryNew}");
                    else Console.WriteLine("Данные не добавлены!");
                    break;

                case 8:
                    // Обновление информации о городах
                    Console.WriteLine("Введите Id для обновления: ");
                    int.TryParse(Console.ReadLine(), out int CityIdUpdate);
                    Console.WriteLine("Введите название города: ");
                    var CityNameNew = Console.ReadLine();
                    if (string.IsNullOrEmpty(CityNameNew)) CityNameNew = "NoName";
                    Console.WriteLine(CityNameNew);
                    var queryCityUpdate = "UPDATE Cities SET Name = @CityNameNew WHERE Id = @CityIdUpdate";
                    var commandCityUpdate = new SqlCommand(queryCityUpdate, connection);
                    var paramCityIdUpdate = new SqlParameter("@CityIdUpdate", CityIdUpdate);
                    var paramNameCityNew = new SqlParameter("@CityNameNew", CityNameNew);
                    commandCityUpdate.Parameters.Add(paramCityIdUpdate);
                    commandCityUpdate.Parameters.Add(paramNameCityNew);
                    var resultCityNew = (int)commandCityUpdate.ExecuteNonQuery();
                    if (resultCityNew > 0) Console.WriteLine($"Добавленно строк: {resultCityNew}");
                    else Console.WriteLine("Данные не добавлены!");
                    break;

                case 9:
                    // Обновление информации о разделах
                    Console.WriteLine("Введите Id для обновления: ");
                    int.TryParse(Console.ReadLine(), out int CategoryIdUpdate);
                    Console.WriteLine("Введите название категоии: ");
                    var CategoriesNameNew = Console.ReadLine();
                    if (string.IsNullOrEmpty(CategoriesNameNew)) CategoriesNameNew = "NoName";
                    Console.WriteLine(CategoriesNameNew);
                    var queryCategoriesUpdate = @"UPDATE Categories SET Name = @CategoriesNameNew WHERE Id = @CategoryIdUpdate";
                    var commandCategoriesUpdate = new SqlCommand(queryCategoriesUpdate, connection);
                    var paramCategoryIdUpdate = new SqlParameter("@CategoryIdUpdate", CategoryIdUpdate);
                    var paramNameCategoriesNew = new SqlParameter("@CategoriesNameNew", CategoriesNameNew);
                    commandCategoriesUpdate.Parameters.Add(paramCategoryIdUpdate);
                    commandCategoriesUpdate.Parameters.Add(paramNameCategoriesNew);
                    var resultCategoriesNew = (int)commandCategoriesUpdate.ExecuteNonQuery();
                    if (resultCategoriesNew > 0) Console.WriteLine($"Добавленно строк: {resultCategoriesNew}");
                    else Console.WriteLine("Данные не добавлены!");
                    break;

                case 10:
                    // Обновление информации об акционных товарах
                    Console.WriteLine("Введите Id для обновления: ");
                    int.TryParse(Console.ReadLine(), out int ProductIdUpdate);
                    Console.WriteLine("Введите названия товара: ");
                    var ProductNameNew = Console.ReadLine();
                    if (string.IsNullOrEmpty(ProductNameNew)) ProductNameNew = "NoName";
                    Console.WriteLine(ProductNameNew);
                    Console.WriteLine("Введите Id категории: ");
                    int.TryParse(Console.ReadLine(), out int categoryIdNew);
                    Console.WriteLine(categoryIdNew);
                    var queryProductUpdate = @"UPDATE Products SET Name = @ProductNameNew, CategoryId = @categoryIdNew WHERE Id = @ProductIdUpdate";
                    var commandProductUpdate = new SqlCommand(queryProductUpdate, connection);
                    var paramProductIdUpdate = new SqlParameter("@ProductIdUpdate", ProductIdUpdate);
                    var paramNameProductNew = new SqlParameter("@ProductNameNew", ProductNameNew);
                    var paramNameCategoryIdNew = new SqlParameter("@categoryIdNew", categoryIdNew);
                    commandProductUpdate.Parameters.Add(paramProductIdUpdate);
                    commandProductUpdate.Parameters.Add(paramNameProductNew);
                    commandProductUpdate.Parameters.Add(paramNameCategoryIdNew);
                    var resultProductNew = commandProductUpdate.ExecuteNonQuery();
                    if (resultProductNew > 0) Console.WriteLine($"Добавленно строк: {resultProductNew}");
                    else Console.WriteLine("Данные не добавлены!");
                    break;

                case 11:
                    // Удаление информации о покупателях
                    Console.WriteLine("Введите Id для удаления: ");
                    int.TryParse(Console.ReadLine(), out int ClientIdDelete);
                    var queryClientDelete = @"DELETE FROM Clients WHERE Id = @ClientIdDelete";
                    var commandClientDelete = new SqlCommand(queryClientDelete, connection);
                    var paramClientDelete = new SqlParameter("@ClientIdDelete", ClientIdDelete);
                    commandClientDelete.Parameters.Add(paramClientDelete);
                    var resultClientDelete = commandClientDelete.ExecuteNonQuery();
                    if (resultClientDelete > 0) Console.WriteLine($"Удалена строка: {resultClientDelete}");
                    else Console.WriteLine("Данные не удалены!");
                    break;

                case 12:
                    // Удаление информации о странах
                    Console.WriteLine("Введите Id для удаления: ");
                    int.TryParse(Console.ReadLine(), out int CountryIdDelete);
                    var queryCountryDelete = @"DELETE FROM Countries WHERE Id = @CountryIdDelete";
                    var commandCountryDelete = new SqlCommand(queryCountryDelete, connection);
                    var paramCountryDelete = new SqlParameter("@CountryIdDelete", CountryIdDelete);
                    commandCountryDelete.Parameters.Add(paramCountryDelete);
                    var resultCountryDelete = commandCountryDelete.ExecuteNonQuery();
                    if (resultCountryDelete > 0) Console.WriteLine($"Удалена строка: {resultCountryDelete}");
                    else Console.WriteLine("Данные не удалены!");
                    break;

                case 13:
                    // Удаление информации о городах
                    Console.WriteLine("Введите Id для удаления: ");
                    int.TryParse(Console.ReadLine(), out int CityIdDelete);
                    var queryCityDelete = @"DELETE FROM Cities WHERE Id = @CityIdDelete";
                    var commandCityDelete = new SqlCommand(queryCityDelete, connection);
                    var paramCityDelete = new SqlParameter("@CityIdDelete", CityIdDelete);
                    commandCityDelete.Parameters.Add(paramCityDelete);
                    var resultCityDelete = commandCityDelete.ExecuteNonQuery();
                    if (resultCityDelete > 0) Console.WriteLine($"Удалена строка: {resultCityDelete}");
                    else Console.WriteLine("Данные не удалены!");
                    break;

                case 14:
                    // Удаление информации о разделах 
                    Console.WriteLine("Введите Id для удаления: ");
                    int.TryParse(Console.ReadLine(), out int CategoryIdDelete);
                    var queryCategoryDelete = @"DELETE FROM Categories WHERE Id = @CategoryIdDelete";
                    var commandCategoryDelete = new SqlCommand(queryCategoryDelete, connection);
                    var paramCategoryDelete = new SqlParameter("@CategoryIdDelete", CategoryIdDelete);
                    commandCategoryDelete.Parameters.Add(paramCategoryDelete);
                    var resultCategoryDelete = commandCategoryDelete.ExecuteNonQuery();
                    if (resultCategoryDelete > 0) Console.WriteLine($"Удалена строка: {resultCategoryDelete}");
                    else Console.WriteLine("Данные не удалены!");
                    break;

                case 15:
                    // Удаление информации об акционных товарах
                    Console.WriteLine("Введите Id для удаления: ");
                    int.TryParse(Console.ReadLine(), out int ProductIdDelete);
                    var queryProductDelete = @"DELETE FROM Products WHERE Id = @ProductIdDelete";
                    var commandProductDelete = new SqlCommand(queryProductDelete, connection);
                    var paramProductDelete = new SqlParameter("@ProductIdDelete", ProductIdDelete);
                    commandProductDelete.Parameters.Add(paramProductDelete);
                    var resultProductDelete = commandProductDelete.ExecuteNonQuery();
                    if (resultProductDelete > 0) Console.WriteLine($"Удалена строка: {resultProductDelete}");
                    else Console.WriteLine("Данные не удалены!");
                    break;

                default:
                    Console.WriteLine("Неправельна набрана цифра!");
                    break;
            }
        }
    }
}
