using System;
using System.Collections.Generic;
using Insight.Core.Entities;
using System.DirectoryServices;
using System.Linq;

namespace Insight.Core
{
    public class EmployeeQueries
    {
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
            var employees = new List<Employee>();

            string path = "LDAP://LAN";
            DirectoryEntry dEntry = new DirectoryEntry(path);
            DirectorySearcher dSearcher = new DirectorySearcher(dEntry);

            //This line applies a filter to the search specifying a username to search for
            //modify this line to specify a user name. if you want to search for all
            //users who start with k - set SearchString to "k"
            dSearcher.Filter = "(&(objectClass=user)(objectcategory=Person))";

            //perform search on active directory
            SearchResultCollection domainUsers = dSearcher.FindAll();
            foreach (SearchResult domainUser in domainUsers)
            {
                var employee = new Employee()
                {
                    FirstName = GetPropertyValue(domainUser, "givenname"),
                    LastName = GetPropertyValue(domainUser, "sn"),
                    Username = GetPropertyValue(domainUser, "samaccountname"),
                    //LogonCount = int.Parse(GetPropertyValue(domainUser, "logoncount")),
                    TimestampCreated = (DateTime?)GetPropertyObject(domainUser, "whencreated"),
                    //Thumbnail = (byte[])GetPropertyObject(domainUser, "thumbnailphoto"),
                    Company = GetPropertyValue(domainUser, "company"),
                    Mail = GetPropertyValue(domainUser, "mail"),
                    Department = GetPropertyValue(domainUser, "department"),
                    Description = GetPropertyValue(domainUser, "description"),
                };

                employees.Add(employee);
            }
            return employees;
        }

        private string GetPropertyValue(SearchResult result, string propertyName)
        {
            var props = result.Properties[propertyName];
            if (props.Count > 0)
            {
                return props[0].ToString();
            }
            return string.Empty;
        }

        private object GetPropertyObject(SearchResult result, string propertyName)
        {
            var props = result.Properties[propertyName];
            if (props.Count > 0)
            {
                return props[0];
            }
            return null;
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