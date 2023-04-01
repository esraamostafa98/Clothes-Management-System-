using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication6.BL.Interfaces;
using WebApplication6.DAL.Entities;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment department;

        public DepartmentController(IDepartment Department)
        {
            department = Department;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var data = department.Get();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var data = department.GetById(id);
            return Ok(data);
        }
        [HttpPost("Post")]
        public ActionResult PostData(DepartmentVM dept)
        {
            department.Add(dept);
            return Ok();
        }
        [HttpPut]
        public ActionResult UpdateData(DepartmentVM dept)
        {
            department.Edit(dept);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteData(int id)
        {
            department.Delete(id);
            return Ok();
        }

    }
}
