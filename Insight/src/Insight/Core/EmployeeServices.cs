using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.IO;
using Insight.Core.Entities;
using Insight.Core.Identity;

namespace Insight.Core
{
    public class EmployeeServices
    {
        private readonly InsightContext _context;

        public EmployeeServices(InsightContext context)
        {
            _context = context;
        }

        public void ImportUsersFromActiveDirectory()
        {

            var employees = new List<Employee>();

            string path = "LDAP://LAN";//set your organisation domain
            DirectoryEntry dEntry = new DirectoryEntry(path);
            DirectorySearcher dSearcher = new DirectorySearcher(dEntry);

            //This line applies a filter to the search specifying a username to search for
            //modify this line to specify a user name. if you want to search for all
            //users who start with k - set SearchString to "k"
            dSearcher.Filter = "(&(objectClass=user)(objectcategory=Person))";
            var x = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            var u = AppDomain.CurrentDomain.BaseDirectory;
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
                    TimestampCreated = (DateTime)GetPropertyObject(domainUser, "whencreated"),
                    //Thumbnail = (byte[])GetPropertyObject(domainUser, "thumbnailphoto"),
                    Company = GetPropertyValue(domainUser, "company"),
                    Email = GetPropertyValue(domainUser, "mail"),
                    Department = GetPropertyValue(domainUser, "department"),
                    Description = GetPropertyValue(domainUser, "description"),
                };

                if (employee.Thumbnail != null)
                {
                    var subdir = $@"images\profile\{employee.Username}";
                    employee.ProfileImageUrl = $"profile/{employee.Username}/thumb.jpg";
                    if (!Directory.Exists($@"C:\Projects\Insight\Insight\src\Insight\wwwroot\{subdir}"))
                    {
                        Directory.CreateDirectory($@"C:\Projects\Insight\Insight\src\Insight\wwwroot\{subdir}");
                    }
                    File.WriteAllBytes($@"C:\Projects\Insight\Insight\src\Insight\wwwroot\{employee.ProfileImageUrl}", employee.Thumbnail);
                }
                employees.Add(employee);
                _context.Employees.Add(employee);
            }
            _context.SaveChanges();
            //return employees;
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

    }
}