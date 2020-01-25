using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWRSyllabusAPI.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}
