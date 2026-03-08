using APIHexagonal.Application.DTOs;
using APIHexagonal.Application.Interfaces.IServices;
using APIHexagonal.Domain.Entities;
using APIHexagonal.Domain.Interfaces.IRepositories;
using APIHexagonal.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHexagonal.Application.Services
{
    public class StudentService : IStudentService
    {
        protected readonly IStudentRepository _studentRepository;
        protected readonly ICourseRepository _courseRepository;
        protected readonly IEnrollmentRepository _enrollmentRepository;
        public StudentService(IStudentRepository service, ICourseRepository courseRepository, IEnrollmentRepository enrollmentRepository)
        {
            _studentRepository = service;
            _courseRepository = courseRepository;
            _enrollmentRepository = enrollmentRepository;
        }
        public void Create(CreateStudentDTO student)
        {
            try
            {
                if (student == null)
                {
                    throw new Exception("Student cannot be null.");
                }

                var existingStudent = _studentRepository.GetAll().FirstOrDefault(c => c.Email == student.Email);

                if (existingStudent != null)
                {
                    throw new Exception("A Student with the same email already exists.");
                }

                Student newStudent = new Student
                {
                    Id = Guid.NewGuid(),
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Age = student.Age,
                    Email = student.Email
                };

                _studentRepository.Create(newStudent);
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
                var existingStudent = _studentRepository.GetById(id);

                if (existingStudent == null)
                {
                    throw new Exception("Student not found.");
                }

                _studentRepository.Delete(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Enroll(Guid idStudent, Guid idCourse)
        {
            try
            {
                var student = _studentRepository.GetById(idStudent);
                if (student == null) {
                    throw new Exception("Student not found.");
                }

                var course = _courseRepository.GetById(idCourse);
                if (course == null) {
                    throw new Exception("Course not found.");
                }

                if (student.FirstName == "" || student.FirstName == null)
                {
                    throw new Exception("Student must have a valid name to enroll.");
                }

                if (student.FirstName.Length > 50)
                {
                    throw new Exception("Student name cannot exceed 50 characters. Update the student before.");
                }

                if (!student.Email.EndsWith("@faculdade.edu"))
                { 
                     throw new Exception("Student email must end with @faculdade.edu. Update the student before.");
                }

                var enrollmentExists = _enrollmentRepository.GetAll().Any(e => e.StudentId == idStudent);
                if (enrollmentExists)
                {
                        throw new Exception("Student is already enrolled in a course.");
                }

                _studentRepository.Enroll(new Enrollment { Id = Guid.NewGuid(), StudentId = idStudent, CourseId = idCourse, EnrollmentDate = DateTime.UtcNow });
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Student> GetAll()
        {
            try
            {
                var students = _studentRepository.GetAll();
                return students;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Student GetById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new Exception("Invalid student ID.");
                }

                var student = _studentRepository.GetById(id);

                if (student == null)
                {
                    throw new Exception("Student not found.");
                }

                return student;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(Guid id, CreateStudentDTO student)
        {
            try
            {
                if (student == null)
                {
                    throw new Exception("Student cannot be null.");
                }

                var existingStudent = _studentRepository.GetById(id);

                if (existingStudent == null)
                {
                    throw new Exception("Student not found.");
                }

                Student attStudent = new Student
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Age = student.Age,
                    Email = student.Email
                };

                _studentRepository.Update(attStudent);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
