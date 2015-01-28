using PlayerManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AchievementManagement.Controllers
{
    public class AchievementController : Controller
    {
        // GET: Achievement
        private IAchievementRepository _repository;
        

        public AchievementController(): this(new AchievementRepository())
        {
        }

        public AchievementController(IAchievementRepository repository)
        {
            _repository = repository;
        }


        public ActionResult Index()
        {
            return View(_repository.GetAchievements());
        }


        public ActionResult Details(String name)
        {
            Achievement achievement = _repository.GetAchievementByName(name);
            if (achievement == null)
                return RedirectToAction("Index");

            return View(achievement);
        }


        public ActionResult Create()
        {
            
            return View();
        }


        [HttpPost]
        public ActionResult Create(Achievement achievement)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.InsertAchievement(achievement);
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    //error msg for failed insert in XML file
                    ModelState.AddModelError("", "Error creating record. " + ex.Message);
                }
            }

            return View(achievement);
        }


        public ActionResult Edit(String name)
        {
            Achievement achievement = _repository.GetAchievementByName(name);
            if (achievement == null)
                return RedirectToAction("Index");
            
            return View(achievement);
        }


        [HttpPost]
        public ActionResult Edit(Achievement achievement)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.EditAchievement(achievement);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //error msg for failed edit in XML file
                    ModelState.AddModelError("", "Error editing record. " + ex.Message);
                }
            }

            return View(achievement);
        }


        public ActionResult Delete(String name)
        {
            Achievement achievement = _repository.GetAchievementByName(name);
            if (achievement == null)
                return RedirectToAction("Index");
            return View(achievement);
        }


        [HttpPost]
        public ActionResult Delete(String name, FormCollection collection)
        {
            try
            {
                _repository.DeleteAchievement(name);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                //error msg for failed delete in XML file
                ViewBag.ErrorMsg = "Error deleting record. " + ex.Message;
                return View(_repository.GetAchievementByName(name));
            }
        }
    }
}