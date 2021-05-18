using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge_AspNET.Controllers
{
    public class CanalController : Controller
    {
        // GET: CanalController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CanalController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CanalController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CanalController/Create
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

        // GET: CanalController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CanalController/Edit/5
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

        // GET: CanalController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CanalController/Delete/5
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
