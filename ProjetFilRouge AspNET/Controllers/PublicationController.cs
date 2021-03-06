using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetFilRouge_AspNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge_AspNET.Controllers
{
    public class PublicationController : Controller
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

            return View();
        }

        // GET: CanalController/Details/5
        public ActionResult Publier(int id)
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

            return View();
        }

        // GET: PublicationController/Create
        public ActionResult AjouterPublication()
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

            return View();
        }

        public ActionResult SubmitPublication(Publication publication)
        {
            if (Publication.Create(publication))
            {
                return RedirectToAction("CanalPublication", "Canal", new { id = publication.IdCanal, message = "Publication ajoutée" });
            }
            else
            {
                return RedirectToAction("CanalPublication", "Canal", new { id = publication.IdCanal, messageError = "Echec de la création de la publication" });
            }
        }
    }
}
