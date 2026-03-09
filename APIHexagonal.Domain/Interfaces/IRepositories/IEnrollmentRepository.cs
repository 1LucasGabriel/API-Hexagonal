using APIHexagonal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHexagonal.Domain.Interfaces.IRepositories
{
    public interface IEnrollmentRepository
    {
        public List<Enrollment> GetAll();
    }
}
