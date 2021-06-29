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
        private List<Canal> listCanal;

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

        public static bool Create(Publication element)
        {
            string request = "INSERT INTO Publication (Contenu, DateCreation, idCanal) OUTPUT INSERTED.ID VALUES (@Contenu, @DateCreation, @idCanal)";
            SqlConnection connection = Bdd.Cnx;
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@Contenu", element.Contenu));
            command.Parameters.Add(new SqlParameter("@DateCreation", element.publicationDateCreation));
            command.Parameters.Add(new SqlParameter("@idCanal", element.idCanal));
            connection.Open();
            int Id = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            if (Id > 0)
                return true;
            else
                return false;
        }

        public static List<Publication> Find(int idCanal)
        {
            List<Publication> listPublication = new List<Publication>();
            string Request = "SELECT p.id, p.contenu, p.DateCreation, c.idUtilisateur FROM Publication AS p INNER JOIN Canal AS c ON c.id = p.idCanal WHERE p.IdCanal = @IdCanal AND c.actif = 1";
            SqlConnection Connection = Bdd.Cnx;
            SqlCommand Command = new SqlCommand(Request, Connection);
            Command.Parameters.Add(new SqlParameter("@IdCanal", idCanal));
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                Publication p = new Publication
                {
                    PublicationId = reader.GetInt32(0),
                    Contenu = reader.GetString(1),
                    publicationDateCreation = reader.GetDateTime(2),
                    idUtilisateur = reader.GetInt32(3)
                };
                listPublication.Add(p);
            }
            Command.Dispose();
            Connection.Close();

            return listPublication;
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
