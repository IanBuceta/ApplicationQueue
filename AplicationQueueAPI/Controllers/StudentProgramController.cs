using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AplicationQueueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentProgramController : ControllerBase
    {
        // GET: api/StudentProgram
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/StudentProgram/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/StudentProgram
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/StudentProgram/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
