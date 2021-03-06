﻿using System;
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
        readonly static Queue<StudentProgram> studentPrograms = new Queue<StudentProgram>();
        private StudentProgram GetStudentProgram(int id)
        {
            return studentPrograms.ToList().Find(sP => sP.Id == id);
        }
        // GET: StudentProgram
        public ActionResult Index()
        {
            return View(studentPrograms);
        }

        // GET: StudentProgram/Details/5
        public ActionResult Details(int id)
        {
            return View(GetStudentProgram(id));
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
            return View(GetStudentProgram(id));
        }

        // POST: StudentProgram/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string teamName, string Src)
        {
            try
            {
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
            return View(GetStudentProgram(id));
        }

        // POST: StudentProgram/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete()
        {
            try
            {
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