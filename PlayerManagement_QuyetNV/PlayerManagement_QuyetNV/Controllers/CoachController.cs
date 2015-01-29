using CoachManagement_QuyetNV.Models;
using PlayerManagement_QuyetNV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoachManagement_QuyetNV.Controllers
{
    public class CoachController : Controller
    {
        // GET: Coach
        private ICoachRepository _repository;        

        public CoachController(): this(new CoachRepository())
        {
        }

        public CoachController(ICoachRepository repository)
        {
            _repository = repository;
        }


        public ActionResult Index()
        {
            return View(_repository.GetCoachs());
        }


        public ActionResult Details(String id)
        {
            Coach coach = _repository.GetCoachByID(id);
            if (coach == null)
                return RedirectToAction("Index");

            return View(coach);
        }


        public ActionResult Create()
        {            
            return View();
        }


        [HttpPost]
        public ActionResult Create(Coach coach)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.InsertCoach(coach);
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    //error msg for failed insert in XML file
                    ModelState.AddModelError("", "Error creating record. " + ex.Message);
                }
            }

            return View(coach);
        }


        public ActionResult Edit(String id)
        {
            Coach coach = _repository.GetCoachByID(id);
            if (coach == null)
                return RedirectToAction("Index");
            
            return View(coach);
        }


        [HttpPost]
        public ActionResult Edit(Coach coach)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.EditCoach(coach);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //error msg for failed edit in XML file
                    ModelState.AddModelError("", "Error editing record. " + ex.Message);
                }
            }

            return View(coach);
        }


        public ActionResult Delete(String id)
        {
            Coach coach = _repository.GetCoachByID(id);
            if (coach == null)
                return RedirectToAction("Index");
            return View(coach);
        }


        [HttpPost]
        public ActionResult Delete(String id, FormCollection collection)
        {
            try
            {
                _repository.DeleteCoach(id);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                //error msg for failed delete in XML file
                ViewBag.ErrorMsg = "Error deleting record. " + ex.Message;
                return View(_repository.GetCoachByID(id));
            }
        }
    }
}