using APIHexagonal.Application.DTOs;
using APIHexagonal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHexagonal.Application.Interfaces.IServices
{
    public interface IStudentService
    {
        public void Create(CreateStudentDTO student);
        public Student GetById(Guid id);
        public List<Student> GetAll();
        public bool Update(Guid id, CreateStudentDTO student);
        public bool Delete(Guid id);
        public bool Enroll(Guid idStudent, Guid idCourse);
    }
}
