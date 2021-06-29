﻿using Leptitbelgique_Admin.DAO;
using System;
using System.Collections.Generic;

namespace Leptitbelgique_Admin.Models
{
    class Utilisateur
    {
        private int id;
        private string nom;
        private string email;
        private DateTime dateCreation;
        private string motDePasse;
        private int actif; 
        private int administrateur;
        private bool administrateurIsOui;
        private bool administrateurIsNon;
        private bool actifIsOui;
        private bool actifIsNon;

        public Utilisateur()
        {
            DateCreation = DateTime.Now;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Email { get => email; set => email = value; }
        public DateTime DateCreation { get => dateCreation; set => dateCreation = value; }
        public string MotDePasse { get => motDePasse; set => motDePasse = value; }
        public int Actif { get => actif; set => actif = value; }
        public int Administrateur { get => administrateur; set => administrateur = value; }
        public bool AdministrateurIsOui { get => administrateurIsOui; set => administrateurIsOui = value; }
        public bool AdministrateurIsNon { get => administrateurIsNon; set => administrateurIsNon = value; }
        public bool ActifIsOui { get => actifIsOui; set => actifIsOui = value; }
        public bool ActifIsNon { get => actifIsNon; set => actifIsNon = value; }

        public bool Add()
        {
            AbstractDAO<Utilisateur> dao = new UtilisateurDAO();
            return dao.Create(this);
        }

        public bool Update()
        {
            AbstractDAO<Utilisateur> dao = new UtilisateurDAO();
            return dao.Update(this);
        }
        public bool Delete()
        {
            AbstractDAO<Utilisateur> dao = new UtilisateurDAO();
            return dao.Delete(this);
        }

        public static List<Utilisateur> GetAll()
        {
            AbstractDAO<Utilisateur> dao = new UtilisateurDAO();
            return dao.FindAll();
        }
    }
}
