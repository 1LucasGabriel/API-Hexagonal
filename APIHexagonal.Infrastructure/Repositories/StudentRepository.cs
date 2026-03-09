using APIHexagonal.Domain.Entities;
using APIHexagonal.Domain.Interfaces.Repositories;
using APIHexagonal.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHexagonal.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public readonly AppDbContext _dataBase;

        public StudentRepository(AppDbContext dataBase)
        {
            _dataBase = dataBase;
        }
        public void Create(Student student)
        {
            try
            {
                _dataBase.Aluno.Add(student);
                _dataBase.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                var student = GetById(id);
                _dataBase.Aluno.Remove(student);
                _dataBase.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Enroll(Enrollment enrollment)
        {
            try
            {
                _dataBase.Matricula.Add(enrollment);
                _dataBase.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Student> GetAll()
        {
            return _dataBase.Aluno.ToList();
        }

        public Student GetById(Guid id)
        {
            return _dataBase.Aluno.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Student student)
        {
            _dataBase.Aluno.Update(student);
            _dataBase.SaveChanges();
        }
    }
}
