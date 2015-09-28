using System.Collections.Generic;

namespace DAL.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<string> Skills { get; set; } = new List<string>();

        public string Role { get; set; }

        public List<string> AdditionalRoles { get; set; } = new List<string>();
    }
}
