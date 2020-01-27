using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationQueue;
using ApplicationQueue.Models;

namespace AplicationQueueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentProgramController : ControllerBase
    {
        static Queue<StudentProgram> studentPrograms;

        static StudentProgramController()
        {
            studentPrograms = new Queue<StudentProgram>();
            for (uint i = 0; i < 15; i++)
            {
                studentPrograms.Enqueue(new StudentProgram(i, i.ToString(), i.ToString()));
            }
        }

        // GET: api/StudentProgram
        [HttpGet]
        public ActionResult<Queue<StudentProgram>> Get()
        {
            return studentPrograms;
        }

        // GET: api/StudentProgram/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<StudentProgram> Get(int id)
        {
            return GetStudentProgram(id);
        }

        // POST: api/StudentProgram
        [HttpPost]
        public void Post([FromBody] StudentProgram studentProgram)
        {
            studentPrograms.Enqueue(studentProgram);
        }

        // PUT: api/StudentProgram/5
        [HttpPatch("{id}")]
        public void Patch(int id, [FromBody] StudentProgram studentProgram)
        {
            var toModify = GetStudentProgram(id);
            toModify.TeamName = studentProgram.TeamName;
            toModify.Src = studentProgram.Src;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete()]
        public void Delete(int id)
        {
            studentPrograms.Dequeue();
        }
        public StudentProgram GetStudentProgram(int id)
        {
            return studentPrograms.ToList().Find(s => s.Id == id);
        }
    }
}
