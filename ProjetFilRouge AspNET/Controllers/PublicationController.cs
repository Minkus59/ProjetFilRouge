using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge_AspNET.Controllers
{
    public class PublicationController : Controller
    {
        // GET: PublicationController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PublicationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PublicationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PublicationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PublicationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PublicationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PublicationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PublicationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
