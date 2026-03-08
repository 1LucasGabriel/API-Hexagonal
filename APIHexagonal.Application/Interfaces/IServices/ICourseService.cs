using APIHexagonal.Application.DTOs;
using APIHexagonal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHexagonal.Application.Interfaces.IServices
{
    public interface ICourseService
    {
        public void Create(CreateCourseDTO course);
        public Course GetById(Guid id);
        public List<Course> GetAll();
        public bool Update(Guid id, CreateCourseDTO course);
        public bool Delete(Guid id);
    }
}
