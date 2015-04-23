using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Insight.Core.Entities;
using Insight.Core;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Insight.API.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            try
            {
                var query = new EmployeeQueries();
                var m1 = query.GetAll();
                var m2 = query.GetAllSkills();
                var m3 = query.GetEmployeesGrouppedByInitial();
                var m4 = query.GetEmployeesBy(l => l.Where(e => e.DisplayName.Length > 10).ToList());
                return m4;
            }
            catch (Exception e) if (e.Message.Contains("Null"))
            {
                //throw e;
            }
            catch (Exception e)
            {
                //throw e;
            }
            return new List<Employee>();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
