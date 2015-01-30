using PlayerManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayerManagement_QuyetNV.Controllers
{
    public class PlayerAchievementController : Controller
    {
        // GET: PlayerAchievement
        private IPlayerAchievementRepository _repository;        

        public PlayerAchievementController(): this(new PlayerAchievementRepository())
        {
        }

        public PlayerAchievementController(IPlayerAchievementRepository repository)
        {
            _repository = repository;
        }


        public ActionResult ShowAchievementsList(String id)
        {
            return View(_repository.GetPlayerAchievementsByPlayerID(id));
        }
    

        public ActionResult Create()
        {            
            return View();
        }


        [HttpPost]
        public ActionResult Create(PlayerAchievement playerAchievement)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.InsertPlayerAchievement(playerAchievement);
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    //error msg for failed insert in XML file
                    ModelState.AddModelError("", "Error creating record. " + ex.Message);
                }
            }

            return View(playerAchievement);
        }


        public ActionResult Edit(String playerID, String achievementName)
        {
            PlayerAchievement playerAchievement = _repository.GetPlayerAchievementByAchievementName(playerID, achievementName);
            if (playerAchievement == null)
                return RedirectToAction("Index");
            
            return View(playerAchievement);
        }


        [HttpPost]
        public ActionResult Edit(PlayerAchievement playerAchievement)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.EditPlayerAchievement(playerAchievement);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //error msg for failed edit in XML file
                    ModelState.AddModelError("", "Error editing record. " + ex.Message);
                }
            }

            return View(playerAchievement);
        }


        public ActionResult Delete(String playerID, String achievementName)
        {
            PlayerAchievement playerAchievement = _repository.GetPlayerAchievementByAchievementName(playerID, achievementName);
            if (playerAchievement == null)
                return RedirectToAction("Index");
            return View(playerAchievement);
        }


        [HttpPost]
        public ActionResult Delete(String playerID, String achievementName, FormCollection collection)
        {
            try
            {
                _repository.DeletePlayerAchievement(playerID, achievementName);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                //error msg for failed delete in XML file
                ViewBag.ErrorMsg = "Error deleting record. " + ex.Message;
                return View(_repository.GetPlayerAchievementByAchievementName(playerID, achievementName));
            }
        }
    }
}