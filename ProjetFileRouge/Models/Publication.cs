using ProjetFileRouge.DAO;
using ProjetFileRouge.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjetFileRouge.Models
{
    class Publication
    {
        private int publicationId;
        private string contenu;
        private DateTime publicationDateCreation;
        private int idCanal;
        private int idUtilisateur;
        private int publicationActif;

        public Publication()
        {
            Contenu = contenu;
        }

        public int PublicationId { get => publicationId; set => publicationId = value; }
        public DateTime PublicationDateCreation { get => publicationDateCreation; set => publicationDateCreation = value; }
        public int IdCanal { get => idCanal; set => idCanal = value; }
        public int IdUtilisateur { get => idUtilisateur; set => idUtilisateur = value; }
        public int PublicationActif { get => publicationActif; set => publicationActif = value; }
        public string Contenu { get => contenu; set => contenu = value; }



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

        public bool UpdatePublication(Publication element)
        {
            string request = "UPDATE Publication SET Contenu = @Contenu WHERE id=@id";
            SqlConnection connection = Bdd.Cnx;
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@Contenu", element.Contenu));
            command.Parameters.Add(new SqlParameter("@id", element.PublicationId));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

        public List<Publication> Find(Canal element)
        {
            List<Publication> publication = new List<Publication>();
            string request = "SELECT * FROM Publication WHERE idCanal = @idCanal ORDER BY id ASC";
            SqlConnection connection = Bdd.Cnx;
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idCanal", element.CanalId));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Publication pub = new Publication
                {
                    PublicationId = reader.GetInt32(0),
                    Contenu = reader.GetString(1),
                    PublicationDateCreation = reader.GetDateTime(2),
                    PublicationActif = reader.GetInt32(3)
                };
                publication.Add(pub);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return publication;
        }
    }
}
