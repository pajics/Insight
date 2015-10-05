using System;
using System.Collections.Generic;

namespace Insight.Core.Entities
{
    


    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName => $"{FirstName} {LastName}";
        public string ProfileImageUrl { get; set; }
        public string Role { get; set; }
        public List<Skill> Skills { get; set; } = new List<Skill>();
        public List<EmployeeRole> AdditionalRoles { get; set; } = new List<EmployeeRole>();

        public Gender Gender { get; set; }

        public string Company { get; set; }
        public string Username { get; set; }
        public DateTime? TimestampCreated { get; set; }
        public string Mail { get; set; }
        public byte[] Thumbnail { get; set; }
        public int LogonCount { get; set; }
        public string Department { get; set; }
        public string Description { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }

    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class EmployeeRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}