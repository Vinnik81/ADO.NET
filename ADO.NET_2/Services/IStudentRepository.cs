using ADO.NET_2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.NET_2
{
    // CRUD (Create , Read , Update , Delete)
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        void Delete(int id);
        void Update(Student student);
        int Create(Student student);
    }
}
