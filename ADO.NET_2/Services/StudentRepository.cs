using ADO.NET_2.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ADO.NET_2.Services
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TOPAcademy;";
        public int Create(Student student)
        {
            int id;
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var query = @"INSERT INTO Students (FirstName, LastName, Coins, Username, PasswordHash)" +
                "VALUES (@name, @surname, @coins, @username, @password)" +
                "SET @Id = SCOPE_IDENTITY()";
            var command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@name", student.FirstName));
            command.Parameters.Add(new SqlParameter("@surname", student.LastName));
            command.Parameters.Add(new SqlParameter("@coins", student.Coins));
            command.Parameters.Add(new SqlParameter("@username", student.UserName));
            command.Parameters.Add(new SqlParameter("@password", student.PasswordHash));

            var IdParam = new SqlParameter()
            {
                ParameterName = "@Id",
                DbType = DbType.Int32,
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(IdParam);
            command.ExecuteNonQuery();
            id = (int)IdParam.Value;
            return id;
        }

        public void Delete(int id)
        {
           var query = "DELETE FROM Students WHERE Id = @id";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("id", id));
            command.ExecuteNonQuery();
        }

        public IEnumerable<Student> GetAll()
        {
            List<Student> list = new List<Student>();
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var query = "SELECT * FROM Students";
            var command = new SqlCommand(query, connection);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var student = new Student()
                    {
                        id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Coins = reader.GetInt32(3),
                        UserName = reader.GetString(4),
                        PasswordHash = reader.GetValue(5) as string,
                        Salt = reader.GetValue(6) as string
                    };

                    list.Add(student);
                }
            }
            return list;
        }

        public Student GetById(int id)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            Student student = null;
            var query = "SELECT * FROM Students WHERE Id = @id";
            var command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    student = new Student()
                    {
                        id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Coins = reader.GetInt32(3),
                        UserName = reader.GetString(4),
                        PasswordHash = reader.GetValue(5) as string,
                        Salt = reader.GetValue(6) as string
                    };
                }
            }
            else throw new Exception("Student not found");

            return student;
        }

        public void Update(Student student)
        {
            var query = @"UPDATE Students
                      SET FirstName = @name, LastName = @surname, Coins = @coin
                      where Id = @id";

            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("id", student.id));
            command.Parameters.Add(new SqlParameter("name", student.FirstName));
            command.Parameters.Add(new SqlParameter("surname", student.LastName));
            command.Parameters.Add(new SqlParameter("coin", student.Coins));
            command.ExecuteNonQuery();
        }
    }
}
