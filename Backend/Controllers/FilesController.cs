using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication6.BL.Interfaces;
using WebApplication6.DAL.Entities;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFiles files;

        public FilesController(IFiles files)
        {
            this.files = files;
        }

        [HttpPost]
        public ActionResult PostData([FromForm]FilesVM f)
        {
            files.Add(f);
            return Ok();
        }
    }
}
