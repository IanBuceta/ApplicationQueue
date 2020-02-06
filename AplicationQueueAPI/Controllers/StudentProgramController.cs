using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationQueue;
using ApplicationQueue.Models;
using System.Diagnostics;
using System.Threading;

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
        public ActionResult<IEnumerable<StudentProgram>> Get()
        {
            return studentPrograms;
        }

        // GET: api/StudentProgram/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<StudentProgram> Get(uint id)
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
        public void Patch(uint id, [FromBody] StudentProgram studentProgram)
        {
            var toModify = GetStudentProgram(id);
            toModify.TeamName = studentProgram.TeamName;
            toModify.Src = studentProgram.Src;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete()]
        public ActionResult<StudentProgram> Delete(uint id)
        {
            return studentPrograms.Dequeue();
        }
        public StudentProgram GetStudentProgram(uint id)
        {
            return studentPrograms.ToList().Find(s => s.Id == id);
        }

        [HttpPost("Select")]
        public ActionResult<StudentProgram> selectTopProgram()
        {
            if(0 == Interlocked.CompareExchange(ref Locked, 1, 0))
            {

                StudentProgram studentProgram = studentPrograms.First();
                var strCmdText = $"trash.txt {studentProgram.Id} {studentProgram.TeamName} {studentProgram.Src}";
                var process = Process.Start(@"C:\Users\Ian\source\repos\Async String\Async String\bin\Debug\netcoreapp3.1\Async String.exe", strCmdText);
                process.WaitForExit();

                Locked = 0;
                return Delete(studentProgram.Id);
            }
            HttpContext.Response.StatusCode = 423;
            return null;
        }
        private static int Locked = 0;
    }
}
