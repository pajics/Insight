using System;
using System.Collections.Generic;
using Insight.Core.Entities;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using Insight.Core.Identity;
using Microsoft.Data.Entity;

namespace Insight.Core
{
    public class EmployeeQueries
    {
        private readonly InsightContext _context;

        public EmployeeQueries(InsightContext context)
        {
            _context = context;
        }


        public List<Employee> GetAll()
        {
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
                    Skills = skills,
                    ProfileImageUrl = "img2.jpg"
                });
            employees.Add(
                new Employee
                {
                    FirstName = "Carlos",
                    LastName = "Pascual",
                    Role = "Software Developer",
                    Skills = skills,
                    ProfileImageUrl = "img2.jpg"
                });
            employees.Add(
                new Employee
                {
                    FirstName = "Janko",
                    LastName = "Medjugorac",
                    Role = "Software Developer",
                    Skills = skills,
                    ProfileImageUrl = "img2.jpg"

                });
            employees.Add(
                new Employee
                {
                    FirstName = "Dmitry",
                    LastName = "Popov",
                    Role = "Software Developer",
                    Skills = skills,
                    ProfileImageUrl = "img2.jpg"

                });
            employees.Add(
                new Employee
                {
                    FirstName = "Georg",
                    LastName = "Pfeiffer",
                    Role = "Software Developer",
                    Skills = skills,
                    ProfileImageUrl = "img2.jpg"

                });
            employees.Add(
                new Employee
                {
                    FirstName = "Josef",
                    LastName = "Heidegger",
                    Role = "Software Developer",
                    Skills = skills,
                    ProfileImageUrl = "img2.jpg"

                });
            employees.Add(
                new Employee
                {
                    FirstName = "Erika",
                    LastName = "Kuskova",
                    Role = "Software Developer",
                    Skills = skills,
                    ProfileImageUrl = "img3.jpg"
                });
            employees.Add(
                new Employee
                {
                    FirstName = "Jelena",
                    LastName = "Stankov",
                    Role = "Software Developer",
                    Skills = skills,
                    ProfileImageUrl = "img1.jpg"

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

        public List<Employee> GetEmployees()
        {
            var employees = _context.Employees.AsNoTracking().ToList();
            foreach (var employee in employees)
            {
                if (string.IsNullOrEmpty(employee.ProfileImageUrl))
                {
                    employee.ProfileImageUrl = employee.Gender == Gender.Female ? "female.jpg" : "male.png";
                }
            }
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