using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHexagonal.Application.DTOs
{
    public class CreateEnrollDTO
    {
        public Guid IdStudent { get; set; }
        public Guid IdCourse { get; set; }
    }
}
