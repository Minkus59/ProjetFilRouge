using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProjetFilRouge_AspNET.Classes;
using ProjetFilRouge_AspNET.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge_AspNET.Controllers
{
    public class CompteController : Controller
    {
        private readonly ILogger<CompteController> _logger;

        public CompteController(ILogger<CompteController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Connexion(Utilisateur utilisateur)
        {
            return View("Index");
        }
        public IActionResult Inscription(Utilisateur utilisateur, string Password1, string Password2)
        {
            string messageError;

            //Verifier les doublons Email
            if (utilisateur.VerifCompteEmail(utilisateur))
            {
                messageError = "Cette adresse Email existe déjà !";
            }
            //Verifier le pseudonyme
            else if (utilisateur.VerifComptePseudo(utilisateur))
            {
                messageError = "Ce pseudonyme existe déjà, veuillez en choisir un autre !";
            }
            //Verifier que le mot de passe correspond au critères
            else if (Password1 != Password2)
            {
                messageError = "Les mots de passe ne correspondent pas !";
            }
            else if (Tools.IsMdp(Password1)==false)
            {
                messageError = "Le mot de passe doit commencer par une Majuscule et terminer par des chiffres et doit comporter 8 caractères minimium !";
            }
            else
            {
                utilisateur.MotDePasse = Password1;
                if (utilisateur.Add())
                {
                    HttpContext.Session.SetString("IdUtilisateur", JsonConvert.SerializeObject(utilisateur.Id));

                    return RedirectToAction("Index", "Home", new
                    {
                        message = $"Votre compte à bien été créé, veuillez patienter qu'un administrateur active votre compte"

                    });
                }
                else
                {
                    messageError = "Erreur de création du compte";
                }
            }
            ViewBag.messageError = messageError;
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
