using APIHexagonal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHexagonal.Domain.Interfaces.IRepositories
{
    public interface ICourseRepository
    {
        public void Create(Course course);
        public Course GetById(Guid id);
        public List<Course> GetAll();
        public void Update(Course course);
        public void Delete(Guid id);
    }
}
