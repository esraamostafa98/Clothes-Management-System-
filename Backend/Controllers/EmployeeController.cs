using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication6.BL.Interfaces;
using WebApplication6.DAL.Entities;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee employee;

        public EmployeeController(IEmployee Employee)
        {
            employee = Employee;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var data = employee.Get();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var data = employee.GetById(id);
            return Ok(data);
        }
        [HttpPost]
        public ActionResult PostData([FromForm]EmployeeVM emp)
        {
             employee.Add(emp);
            return Ok();
        }
        [HttpPut]
        public ActionResult UpdateData(EmployeeVM emp)
        {
             employee.Edit(emp);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteData(int id)
        {
             employee.Delete(id);
            return Ok();
        }

    }

}

