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
    public class EnrollmentRepository : IEnrollmentRepository
    {
        public readonly AppDbContext _dataBase;
        public EnrollmentRepository(AppDbContext dataBase)
        {
            _dataBase = dataBase;
        }

        public List<Enrollment> GetAll()
        {
            var enrollments = _dataBase.Matricula.ToList();
            return enrollments;
        }
    }
}
