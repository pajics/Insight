using System;
using System.Collections.Generic;
using Insight.Core.Entities;
using System.Linq;

namespace Insight.Core
{
    public class EmployeeQueries
    {
        public List<Employee> GetAll()
        {
            var devRole = new EmployeeRole { Name = "Software developer" };
            var specRole = new EmployeeRole { Name = "Head of .NET Female Department" };
            //var skills = new List<Skill>()
            //{
            //    [0] = new Skill { Name = "C#" },
            //    [1] = new Skill { Name = "MVC" },
            //    [2] = new Skill { Name = "Azure" },
            //    [3] = new Skill { Name = "AngularJS" },
            //};
            var skills = new List<Skill>();
            skills.Add(new Skill { Name = "C#" });
            skills.Add(new Skill { Name = "MVC" });
            skills.Add(new Skill { Name = "Azure" });
            skills.Add(new Skill { Name = "AngularJS" });

            var employees = new List<Employee>();
            employees.Add(
                new Employee
                {
                    FirstName = "Srdjan",
                    LastName = "Pajic",
                    Role = "Software Developer",
                    Skills = skills
                });
            employees.Add(
                new Employee
                {
                    FirstName = "Carlos",
                    LastName = "Pascual",
                    Role = "Software Developer",
                    Skills = skills
                });
            employees.Add(
                new Employee
                {
                    FirstName = "Janko",
                    LastName = "Medjugorac",
                    Role = "Software Developer",
                    Skills = skills

                });
            employees.Add(
                new Employee
                {
                    FirstName = "Dmitry",
                    LastName = "Popov",
                    Role = "Software Developer",
                    Skills = skills

                });
            employees.Add(
                new Employee
                {
                    FirstName = "Georg",
                    LastName = "Pfeiffer",
                    Role = "Software Developer",
                    Skills = skills

                });
            employees.Add(
                new Employee
                {
                    FirstName = "Josef",
                    LastName = "Heidegger",
                    Role = "Software Developer",
                    Skills = skills

                });
            employees.Add(
                new Employee
                {
                    FirstName = "Erika",
                    LastName = "Kuskova",
                    Role = "Software Developer",
                    Skills = skills,
                    AdditionalRoles = new List<EmployeeRole> { specRole }

                });
            employees.Add(
                new Employee
                {
                    FirstName = "Jelena",
                    LastName = "Stankov",
                    Role = "Software Developer",
                    Skills = skills

                });
            employees.Add(
                new Employee
                {
                    FirstName = "Michael Riedel",
                    Role = "PM"

                });
            employees.Add(
                new Employee
                {
                    FirstName = "Marc Rathai",
                    Role = "PM"

                });
            
            return employees;
        }

        public List<string> GetAllSkills()
        {
            return GetAll().SelectMany(e => e.Skills).Select(s => s.Name).ToList();
        }

        public Dictionary<char, List<Employee>>GetEmployeesGrouppedByInitial()
        {
            return GetAll().GroupBy(e => e.FirstName.First()).ToDictionary(k => k.Key, v => v.ToList());
        }

        public List<Employee> GetEmployeesBy(Func<List<Employee>,List<Employee>> filter)
        {
            return filter(GetAll());
        }
    }
}