using System;
using System.Collections.Generic;
using DAL.Interfaces;
using DAL.Model;
using Microsoft.AspNet.Mvc;

namespace Insight.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        [FromServices]
        public IEmployeeRepository EmployeeRepository { get; set; }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            try
            {
                return EmployeeRepository.GetAll();
            }
            catch (Exception e) when (e.Message.Contains("test"))
            {
                throw e;
            }
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
