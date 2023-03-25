using ADO.NET_2.Models;
using ADO.NET_2.Services;
using System;
using System.Linq;

namespace ADO.NET_2
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentRepository studentRepository = new StudentRepository();

            //var list = studentRepository.GetAll().ToList();
            //Console.WriteLine("FirstName: " + list[0].FirstName);
            //Console.WriteLine("LastName: " + list[0].LastName);
            //Console.WriteLine("UserName: " + list[0].UserName);
            //Console.WriteLine("id: " + list[0].id);
            //Console.WriteLine("Password: " + list[0].PasswordHash);
            //Console.WriteLine("Coins: " + list[0].Coins);

            //Console.WriteLine("Size: " + list.Count());
            //Console.WriteLine("Enter Id Student: ");
            //int.TryParse(Console.ReadLine(), out int id);
            //Student student = studentRepository.GetById(id);
            //Console.WriteLine(student);

            //    Console.WriteLine("Enter your name:  ");
            //    string name = Console.ReadLine();
            //    Console.WriteLine("Enter your lastname:  ");
            //    string lastname = Console.ReadLine();
            //    Console.WriteLine("Enter your login:  ");
            //    string login = Console.ReadLine();
            //    Console.WriteLine("Enter your password:  ");
            //    string password = Console.ReadLine();
            //    int coins = 50;

            //    Student student = new Student
            //    {
            //        Coins = coins,
            //        LastName = lastname,
            //        UserName = login,
            //        FirstName = name,
            //        PasswordHash = password
            //    };

            //    var Id = studentRepository.Create(student);
            //    Student stu = studentRepository.GetById(Id);
            //    Console.WriteLine(stu.ToString());

            //var list = studentRepository.GetAll().ToList();
            //Console.WriteLine("Size: " + list.Count());
            //Console.WriteLine("Enter Id Student: ");
            //int.TryParse(Console.ReadLine(), out int id);
            //studentRepository.Delete(id);
            //list = studentRepository.GetAll().ToList();
            //Console.WriteLine("Size: " + list.Count());

            Student student = studentRepository.GetById(1);
            student.FirstName = "Sawka";
            student.LastName = "Pawka";
            student.Coins = 1000;
            studentRepository.Update(student);
            Console.WriteLine(student);
        }
    }
}
