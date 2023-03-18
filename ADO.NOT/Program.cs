using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            // connectionString => data -> source ->sdress server , initial category, database , user id -> login , password,

            //var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PersonDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //var connection = new SqlConnection(connectionString);
            //connection.Open();
            //Console.WriteLine("Connection...");
            //connection.Close();
            //Console.WriteLine("Disconnected!");

            //var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PersonDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //using (var connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    Console.WriteLine("Connection...");
            //}
            //    Console.WriteLine("Disconnected!");

            //var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PersonDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //using var connection = new SqlConnection(connectionString);
            //    connection.Open();
            //    Console.WriteLine("Connection...");

            //Console.WriteLine("Disconnected!");

            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PersonDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; user Id=TestApp; Password=12345678";

            using var connection = new SqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Connection...");

            //var query = "INSERT INTO Students(FirstName, Lastname, Age) VALUES('Vladimir', 'Vinnik', 41)" +
            //    ",('Dima', 'Belkov', 31)" +
            //    ",('Sawa', 'Buzov', 45)" +
            //    ",('Mawa', 'Galkina', 91)" +
            //    ",('Oleq', 'Gazmanov', 13)" +
            //    ",('Regina', 'Pugacheva', 22)" +
            //    ",('Olga', 'Qutsol', 50)";
            //var command = new SqlCommand(query, connection);
            //var result = command.ExecuteNonQuery();
            //Console.WriteLine($"Append rows: {result}");

            //var person = new List<Person>();
            //var query = "SELECT * FROM Students";
            //var command = new SqlCommand(query, connection);
            //var result = command.ExecuteReader();
            //if (result.HasRows)
            //{
            //    Console.WriteLine($"{result.GetName(0).PadRight(8, ' ')}{result.GetName(1).ToString().PadRight(16, ' ')}{result.GetName(2).PadRight(16, ' ')}{result.GetName(3)}");
            //    while (result.Read())
            //    {
            //        var id = result.GetValue(0);
            //        var firstname = result.GetValue(1);
            //        var lastname = result.GetValue(2);
            //        var age = result.GetValue(3);


            //        Console.WriteLine($"{id}\t{firstname}\t\t{lastname.ToString().PadRight(10, '_')}\t{age}");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Data not found!");
            //}

            //var persons = new List<Person>();
            //var query = "SELECT * FROM Students";
            //var command = new SqlCommand(query, connection);
            //var result = command.ExecuteReader();
            //if (result.HasRows)
            //{
            //    Console.WriteLine($"{result.GetName(0).PadRight(8, ' ')}{result.GetName(1).ToString().PadRight(16, ' ')}{result.GetName(2).PadRight(16, ' ')}{result.GetName(3)}");
            //    while (result.Read())
            //    {
            //        Person person = new Person();
            //        //person.Id = (int)result.GetValue(0);
            //        //person.FirstName = (string)result.GetValue(1);
            //        //person.LastName = (string)result.GetValue(2);
            //        //person.Age = (int)result.GetValue(3);
            //        //persons.Add(person);

            //        person.Id = result.GetInt32(0);
            //        person.FirstName = result.GetString(1);
            //        person.LastName = result.GetString(2);
            //        person.Age = result.GetInt32(3);
            //        persons.Add(person);

            //        Console.WriteLine(person);
            //    }

            //    Console.WriteLine("-------------------------------------------------------------");
            //    foreach (var item in persons)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Data not found!");
            //}

            //var persons = new List<Person>();
            //var query = "SELECT COUNT(*) FROM Students";
            //var command = new SqlCommand(query, connection);
            //var result = (int)command.ExecuteScalar();

            //if (result > 0)
            //{
            //    Console.WriteLine($"Count rows: {result}");
            //}
            //else
            //{
            //    Console.WriteLine("Data not found!");
            //}

            //Console.WriteLine("Enter name: ");
            //var name = Console.ReadLine();
            //Console.WriteLine("Enter surname: ");
            //var surname = Console.ReadLine();
            //Console.WriteLine("Enter age: ");
            //var age = int.Parse(Console.ReadLine());
            //var data = DateTime.Now.Ticks;
            //var query = "INSERT INTO Students(FirstName, Lastname, Age)" +
            //    $"VALUES('{name}', '{surname}', {age})";
            //var command = new SqlCommand(query, connection);
            //var result = (int)command.ExecuteNonQuery();

            //if (result > 0)
            //{
            //    Console.WriteLine($"Append rows: {result}");
            //}
            //else
            //{
            //    Console.WriteLine("Data not found!");
            //}

            //Console.WriteLine("Enter name: ");
            //var name = Console.ReadLine();
            //if (string.IsNullOrEmpty(name)) name = "NoName";
            //Console.WriteLine(name);

            //Console.WriteLine("Enter surname: ");
            //var surname = Console.ReadLine();
            //if (string.IsNullOrEmpty(surname)) surname = "NoName";
            //Console.WriteLine(surname);

            //Console.WriteLine("Enter age: ");
            //var age = int.Parse(Console.ReadLine());

            //var query = "INSERT INTO Students(FirstName, Lastname, Age)" +
            //    $"VALUES('{name}', '{surname}', {age})";
            //var command = new SqlCommand(query, connection);
            //var result = (int)command.ExecuteNonQuery();

            //if (result > 0)
            //{
            //    Console.WriteLine($"Append rows: {result}");
            //}
            //else
            //{
            //    Console.WriteLine("Data not found!");
            //}

            //name="Name"
            //age="Age"

            //surname="Abdullayev');DROP Table Students--

            //INSERT INTO Students(FirstName,Age,LastName)VALUES ('{name}',{age},'{surname}')

            //var query = "INSERT INTO Students(FirstName, Lastname, Age) VALUES " +
            //    "('Dima', 'Belkov', 31)" +
            //    ",('Sawa', 'Buzov', 45)" +
            //    ",('Mawa', 'Galkina', 91)" +
            //    ",('Oleq', 'Gazmanov', 13)" +
            //    ",('Regina', 'Pugacheva', 22)" +
            //    ",('Olga', 'Qutsol', 50)";
            //var command = new SqlCommand(query, connection);
            //var result = command.ExecuteNonQuery();
            //Console.WriteLine($"Append rows: {result}");

            Console.WriteLine("Enter name: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name)) name = "NoName";
            Console.WriteLine(name);

            Console.WriteLine("Enter surname: ");
            var surname = Console.ReadLine();
            if (string.IsNullOrEmpty(surname)) surname = "NoName";
            Console.WriteLine(surname);

            Console.WriteLine("Enter age: ");
            //var age = int.Parse(Console.ReadLine());
            int.TryParse(Console.ReadLine(), out int age);

            //Nullable<int> nullable = null;
            //nullable = 10;
            //int? v = null;
            //int? number = v ?? 1;

            var query = "INSERT INTO Students(FirstName, Age, Lastname)" +
                $"VALUES(@name, @age, @surname)";
            var command = new SqlCommand(query, connection);
            var paramName = new SqlParameter("@name", name);
            var paramSurname = new SqlParameter("@surname", surname);
            var paramAge = new SqlParameter("@age", age);

            command.Parameters.Add(paramName);
            command.Parameters.Add(paramSurname);
            command.Parameters.Add(paramAge);

            var result = (int)command.ExecuteNonQuery();

            if (result > 0)
            {
                Console.WriteLine($"Append rows: {result}");
            }
            else
            {
                Console.WriteLine("Data not found!");
            }
        }
    }
}
