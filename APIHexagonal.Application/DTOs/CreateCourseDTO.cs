using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHexagonal.Application.DTOs
{
    public class CreateCourseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int YearsDuration { get; set; }
    }
}
