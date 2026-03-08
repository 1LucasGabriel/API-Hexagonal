using APIHexagonal.Application.DTOs;
using APIHexagonal.Application.Interfaces.IServices;
using APIHexagonal.Domain.Entities;
using APIHexagonal.Domain.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHexagonal.Application.Services
{
    public class CourseService : ICourseService
    {
        protected readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository service)
        {
            _courseRepository = service;
        }
        public void Create(CreateCourseDTO course)
        {
            try
            {
                if (course == null)
                {
                    throw new Exception("Course cannot be null.");
                }

                var existingCourse = _courseRepository.GetAll().FirstOrDefault(c => c.Name == course.Name);

                if (existingCourse != null)
                {
                    throw new Exception("A course with the same name already exists.");
                }

                Course newCourse = new Course
                {
                    Id = Guid.NewGuid(),
                    Name = course.Name,
                    Description = course.Description,
                    YearsDuration = course.YearsDuration
                };

                _courseRepository.Create(newCourse);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                var existingCourse = _courseRepository.GetById(id);

                if (existingCourse == null)
                {
                    throw new Exception("Course not found.");
                }

                _courseRepository.Delete(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Course> GetAll()
        {
            try
            {
                var courses = _courseRepository.GetAll();
                return courses;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Course GetById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new Exception("Invalid course ID.");
                }

                var course = _courseRepository.GetById(id);

                if (course == null)
                {
                    throw new Exception("Course not found.");
                }

                return course;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(Guid id, CreateCourseDTO course)
        {
            try
            {
                if (course == null)
                {
                    throw new Exception("Course cannot be null.");
                }

                var existingCourse = _courseRepository.GetAll().FirstOrDefault(c => c.Name == course.Name);

                if (existingCourse == null)
                {
                    throw new Exception("Course not found.");
                }

                Course attCourse = new Course
                {
                    Name = course.Name,
                    Description = course.Description,
                    YearsDuration = course.YearsDuration
                };

                _courseRepository.Update(attCourse);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
