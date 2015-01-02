using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using NerdDinner.Models;

namespace NerdDinner.Controllers
{
    public class DinnersController : Controller
    {
        private DinnerRepository dinnerRepository = new DinnerRepository();

        // GET: /Dinners/
        public ActionResult Index()
        {
            List<Dinner> dinners = dinnerRepository.FindUpcomingDinners().ToList();

            return View("Index", dinners);
        }
        //
        // GET: /Dinners/Details/2
        public ActionResult Details(int id)
        {
            Dinner dinner = dinnerRepository.GetDinner(id);

            if (dinner == null)
            {
                return View("NotFound");
            }

            return View(dinner);
        }

        public ActionResult Edit(int id)
        {
            Dinner dinner = dinnerRepository.GetDinner(id);

            if (dinner == null)
            {
                return View("NotFound");
            }

            return View(dinner);
        }

        [HttpPost]
        public ActionResult Edit(int id, Dinner dinnerToUpdate)
        {
            Dinner dinner = dinnerRepository.GetDinner(id);
            try
            {
                

                if (ModelState.IsValid)
                {
                    dinnerRepository.Update(dinnerToUpdate);
                    dinnerRepository.Save();
                    return RedirectToAction("Details", new { id = dinner.DinnerId });
                }
            }
            catch (Exception)
            {
                foreach (var issue in dinner.GetRuleViolations())
                {
                    ModelState.AddModelError(issue.PropertyName, issue.ErrorMessage);
                }
            }

            return View();

        }
    }
}