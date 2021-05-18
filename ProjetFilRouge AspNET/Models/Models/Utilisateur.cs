﻿using ProjetFilRouge_AspNET.DAO;
using ProjetFilRouge_AspNET.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjetFilRouge_AspNET.Models
{
    public class Utilisateur
    {
        private int id;
        private string pseudo;
        private string nom;
        private string prenom;
        private string email;
        private DateTime dateCreation;
        private string motDePasse;
        private string avatar;

        public Utilisateur()
        {
            DateCreation = DateTime.Now;
        }

        public int Id { get => id; set => id = value; }
        public string Pseudo { get => pseudo; set => pseudo = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Email { get => email; set => email = value; }
        public DateTime DateCreation { get => dateCreation; set => dateCreation = value; }
        public string MotDePasse { get => motDePasse; set => motDePasse = value; }
        public string Avatar { get => avatar; set => avatar = value; }

        public bool VerifCompteEmail(Utilisateur element)
        {
            string Request = "SELECT count(*) FROM Utilisateur WHERE Email = @Email";
            SqlConnection Connection = Bdd.Cnx;
            SqlCommand Command = new SqlCommand(Request, Connection);
            Command.Parameters.Add(new SqlParameter("@Email", element.Email));
            Connection.Open();
            int Count = (int)Command.ExecuteScalar();
            Command.Dispose();
            Connection.Close();

            return Count > 0;
        }

        public bool VerifComptePseudo(Utilisateur element)
        {
            string Request = "SELECT count(*) FROM Utilisateur WHERE Pseudo = @Pseudo";
            SqlConnection Connection = Bdd.Cnx;
            SqlCommand Command = new SqlCommand(Request, Connection);
            Command.Parameters.Add(new SqlParameter("@Pseudo", element.Pseudo));
            Connection.Open();
            int Count = (int)Command.ExecuteScalar();
            Command.Dispose();
            Connection.Close();

            return Count > 0;
        }

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
        public List<Utilisateur> Find(Utilisateur element)
        {
            AbstractDAO<Utilisateur> dao = new UtilisateurDAO();
            return dao.Find(this);
        }

        public static List<Utilisateur> GetAll()
        {
            AbstractDAO<Utilisateur> dao = new UtilisateurDAO();
            return dao.FindAll();
        }
    }
}
