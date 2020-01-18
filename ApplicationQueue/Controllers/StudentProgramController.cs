using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationQueue.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationQueue.Controllers
{
    public class StudentProgramController : Controller
    {
        static Queue<StudentProgram> studentPrograms = new Queue<StudentProgram>();
        // GET: StudentProgram
        public ActionResult Index()
        {
            return View(studentPrograms);
        }

        // GET: StudentProgram/Details/5
        public ActionResult Details(int id)
        {
            return View(studentPrograms);
        }

        // GET: StudentProgram/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentProgram/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(uint id, string teamName, string src)
        {
            try
            {
                // TODO: Add insert logic here
                studentPrograms.Enqueue(new StudentProgram(id, teamName, src));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(studentPrograms);
            }
        }

        // GET: StudentProgram/Edit/5
        public ActionResult Edit(int id)
        {
            return View(studentPrograms.ToList().Find(sP => sP.Id == id));
        }

        // POST: StudentProgram/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string teamName, string Src)
        {
            try
            {
                // TODO: Add update logic here
                var student = studentPrograms.ToList().Find(s => s.Id == id);
                student.TeamName = teamName;
                student.Src = Src;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(studentPrograms);
            }
        }

        // GET: StudentProgram/Delete/5
        public ActionResult Delete(int id)
        {
            return View(studentPrograms.ToList().Find(sP => sP.Id == id));
        }

        // POST: StudentProgram/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete()
        {
            try
            {
                // TODO: Add delete logic here
                studentPrograms.Dequeue();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(studentPrograms);
            }
        }
    }
}