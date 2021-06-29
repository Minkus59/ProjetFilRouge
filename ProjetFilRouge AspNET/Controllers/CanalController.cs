using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetFilRouge_AspNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge_AspNET.Controllers
{
    public class CanalController : Controller
    {
        public ActionResult Index()
        {
            string chaineSession = HttpContext.Session.GetString("IdUtilisateur");
            if (chaineSession != null)
            {
                int iD = Convert.ToInt32(chaineSession);
                ViewBag.connectionId = iD;
                ViewBag.connection = true;
            }
            else
            {
                return RedirectToAction("Index", "Home", new { messageError = "Vous devez être connecté pour accéder à cette page" });
            }

            List<Canal> liste = Canal.GetAll();

            return View(liste);
        }

        public ActionResult CanalPublication(int id)
        {
            string chaineSession = HttpContext.Session.GetString("IdUtilisateur");
            if (chaineSession != null)
            {
                int iD = Convert.ToInt32(chaineSession);
                ViewBag.connectionId = iD;
                ViewBag.connection = true;
            }
            else
            {
                return RedirectToAction("Index", "Home", new { messageError = "Vous devez être connecté pour accéder à cette page" });
            }

            Canal canal = Canal.Find(id);

            return View(canal);
        }

        public ActionResult AjouterCanal(Canal canal, string message, string messageError, int id)
        {
            string chaineSession = HttpContext.Session.GetString("IdUtilisateur");
            if (chaineSession != null)
            {
                int iD = Convert.ToInt32(chaineSession);
                ViewBag.connectionId = iD;
                ViewBag.connection = true;
            }
            else
            {
                return RedirectToAction("Index", "Home", new { messageError = "Vous devez être connecté pour accéder à cette page" });
            }

            ViewBag.messageError = messageError;
            ViewBag.message = message;

            Canal c = new Canal();

            if (id != 0) {
                c= Canal.Find(id);
            }
            return View(c);
        }

        public ActionResult SubmitCanal(Canal canal)
        {
            if (canal.Create(canal))
            {
                return RedirectToAction("AjouterCanal", "Canal", new { message = "Canal créé" });
            }
            else
            {
                return RedirectToAction("AjouterCanal", "Canal", new { messageError = "Echec de la création du canal" });
            }
        }

        public ActionResult ModifierCanal(Canal canal)
        {
            if (canal.Update())
            {
                return RedirectToAction("Index", "Canal", new { message = "Canal modifier" });
            }
            else
            {
                return RedirectToAction("AjouterCanal", "Canal", new { messageError = "Echec de la modification du canal" });
            }
        }

        public IActionResult SubmitRecherche(string Search)
        {
            string chaineSession = HttpContext.Session.GetString("IdUtilisateur");
            if (chaineSession != null)
            {
                int iD = Convert.ToInt32(chaineSession);
                ViewBag.connectionId = iD;
                ViewBag.connection = true;
            }
            else
            {
                return RedirectToAction("Index", "Home", new { messageError = "Vous devez être connecté pour accéder à cette page" });
            }

            List<Canal> p = new List<Canal>();
            if (Search != null)
            {
                p = Canal.Recherche(Search);
                ViewBag.recherche = p;
            }
            return View("Index");
        }

        public IActionResult Confirmation(int Id)
        {
            Canal c = Canal.Find(Id);
            return View("Confirmation", c);
        }
        public IActionResult Supprimer(int Id)
        {
            if(Canal.Supprimer(Id))
            {
                return RedirectToAction("Index", "Canal", new { message = "Canal supprimer" });
            }
            else
            {
                return RedirectToAction("Index", "Canal", new { messageError = @"Erreur de suppresion du canal : {Id}" });
            }
        }
    }
}
