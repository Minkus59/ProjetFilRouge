using ProjetFilRouge_AspNET.DAO;
using ProjetFilRouge_AspNET.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjetFilRouge_AspNET.Models
{
    public class Publication
    {
        private int publicationId;
        private string contenu;
        private DateTime publicationDateCreation;
        private int idCanal;
        private int idUtilisateur;
        private int publicationActif;

        public Publication()
        {
            PublicationDateCreation = DateTime.Now;
        }

        public int PublicationId { get => publicationId; set => publicationId = value; }
        public DateTime PublicationDateCreation { get => publicationDateCreation; set => publicationDateCreation = value; }
        public int IdCanal { get => idCanal; set => idCanal = value; }
        public int IdUtilisateur { get => idUtilisateur; set => idUtilisateur = value; }
        public int PublicationActif { get => publicationActif; set => publicationActif = value; }
        public string Contenu { get => contenu; set => contenu = value; }

        public List<Publication> Find(Canal element)
        {
            AbstractDAO<Publication> dao = new PublicationDAO();
            return dao.Find(this);
        }

        public bool Update()
        {
            AbstractDAO<Publication> dao = new PublicationDAO();
            return dao.Update(this);
        }

        public bool Delete()
        {
            AbstractDAO<Publication> dao = new PublicationDAO();
            return dao.Delete(this);
        }
        public static List<Publication> GetAll()
        {
            AbstractDAO<Publication> dao = new PublicationDAO();
            return dao.FindAll();
        }
        public bool Add()
        {
            AbstractDAO<Publication> dao = new PublicationDAO();
            return dao.Create(this);
        }
    }
}
