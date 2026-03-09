using APIHexagonal.Domain.Entities;
using APIHexagonal.Domain.Interfaces.IRepositories;
using APIHexagonal.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHexagonal.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        public readonly AppDbContext _dataBase;

        public CourseRepository(AppDbContext dataBase)
        {
            _dataBase = dataBase;
        }

        public void Create(Course course)
        {
            try
            {
                _dataBase.Curso.Add(course);
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
                var course = GetById(id);
                _dataBase.Curso.Remove(course);
                _dataBase.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Course> GetAll()
        {
            return _dataBase.Curso.ToList();
        }

        public Course GetById(Guid id)
        {
            return _dataBase.Curso.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Course course)
        {
            _dataBase.Curso.Update(course);
            _dataBase.SaveChanges();
        }
    }
}
