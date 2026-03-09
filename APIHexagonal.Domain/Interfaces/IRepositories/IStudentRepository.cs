using APIHexagonal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHexagonal.Domain.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        public void Create(Student student);
        public Student GetById(Guid id);
        public List<Student> GetAll();
        public void Update(Student student);
        public void Delete(Guid id);
        public void Enroll(Enrollment enrollment);
    }
}
