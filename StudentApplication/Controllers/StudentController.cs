using AutoMapper;
using Domain.Models;
using Domain.Repositories;
using StudentApplication.Helpers;
using StudentApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApplication.Controllers
{
    [Logging]
    public class StudentController : Controller
    {
        private readonly IRepository<Student> _studentRepository = 
            new StudentRepository();

        //
        // GET: /Student/

        public ActionResult Index()
        {
            IList<StudentViewModel> viewModel = new List<StudentViewModel>();
            var students = _studentRepository.GetAll();

            foreach (Student student in students)
                viewModel.Add(AutoMapper.Mapper.Map<StudentViewModel>(student));

            return View(viewModel);
        }

        //
        // GET: /Student/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Student/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Student/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentViewModel model)
        {
            if (ModelState.IsValid){
                //add students here
                /*
                students.Add(new Student(
                    model.Id,
                    model.FullName,
                    model.Age,
                    model.Gender));
                */
                return RedirectToAction("Index");
            }
            return View(model);
        }
        
        //
        // GET: /Student/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View(Mapper.Map<StudentViewModel>(
                _studentRepository.GetAll().First(
                t => t.Id == id)));
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StudentViewModel model)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        //
        // GET: /Student/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Student/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Student/ValidateSchool/schoolName
        public ActionResult ValidateSchool(String school)
        {
            /**
             * This method gets called every time a validation gets triggered from the client.  It will return either a true (school exists in a list) or false (school does
             * not exist in a list)
             */
            IEnumerable<String> schoolList = new List<String>()
            {
                "Travis","Westlake","Round Rock","Austin"
            };


            return Json(schoolList.Contains(school), JsonRequestBehavior.AllowGet);
        }
    }
}
