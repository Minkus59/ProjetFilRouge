using ProjetFilRouge_AspNET.DAO;
using ProjetFilRouge_AspNET.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ProjetFilRouge_AspNET.Models
{
    public class Canal
    {
        private int canalId;
        private string theme;
        private string description;
        private DateTime canalDateCreation;
        private int canalActif;
        private int canalIdUtilisateur;
        private List<Publication> listPublication;

        public Canal()
        {
            CanalDateCreation = DateTime.Now;
        }

        public int CanalId { get => canalId; set => canalId = value; }
        public string Theme { get => theme; set => theme = value; }
        public string Description { get => description; set => description = value; }
        public DateTime CanalDateCreation { get => canalDateCreation; set => canalDateCreation = value; }
        public int CanalActif { get => canalActif; set => canalActif = value; }
        public int CanalIdUtilisateur { get => canalIdUtilisateur; set => canalIdUtilisateur = value; }
        public List<Publication> ListPublication { get => listPublication; set => listPublication = value; }

        public static List<Canal> Recherche(string search)
        {
            List<Canal> canaux = new List<Canal>();
            SqlConnection connection = Bdd.Cnx;
            SqlCommand command = new SqlCommand("SELECT id, theme, description, dateCreation, IdUtilisateur FROM Canal WHERE theme LIKE @search AND actif = 1 OR description LIKE @search AND actif = 1", connection);
            command.Parameters.Add(new SqlParameter("@search", search));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Canal c = new Canal
                {
                    CanalId = reader.GetInt32(0),
                    Theme = reader.GetString(1),
                    Description = reader.GetString(2),
                    CanalDateCreation = reader.GetDateTime(3),
                    canalIdUtilisateur = reader.GetInt32(4)
                };
                canaux.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return canaux;
        }

        public bool Create(Canal element)
        {
            string request = "INSERT INTO Canal (Theme, Description, DateCreation, idUtilisateur) OUTPUT INSERTED.ID VALUES (@Theme, @Description, @DateCreation, @idUtilisateur)";
            SqlConnection connection = Bdd.Cnx;
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@Theme", element.Theme));
            command.Parameters.Add(new SqlParameter("@Description", element.Description));
            command.Parameters.Add(new SqlParameter("@DateCreation", element.CanalDateCreation));
            command.Parameters.Add(new SqlParameter("@idUtilisateur", element.CanalIdUtilisateur));
            connection.Open();
            int Id = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            if (Id > 0)
                return true;
            else
                return false;
        }

        public bool Update()
        {
            string request = "UPDATE Canal SET Theme = @Theme, Description = @Description WHERE id = @idCanal";
            SqlConnection connection = Bdd.Cnx;
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@Theme", Theme));
            command.Parameters.Add(new SqlParameter("@Description", Description));
            command.Parameters.Add(new SqlParameter("@idCanal", CanalId));
            connection.Open();
            int Id = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            if (Id > 0)
                return true;
            else
                return false;
        }

        public static bool Supprimer(int id)
        {
            SqlConnection connection = Bdd.Cnx;
            SqlCommand command = new SqlCommand("DELETE FROM canal WHERE id = @Id", connection);
            command.Parameters.Add(new SqlParameter("@Id", id));
            connection.Open();
            int nbLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            if (nbLigne > 0)
            {
                connection = Bdd.Cnx;
                command = new SqlCommand("DELETE FROM publication WHERE idCanal = @Id", connection);
                command.Parameters.Add(new SqlParameter("@Id", id));
                connection.Open();
                int nbL = command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();

                if (nbL > 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        public static Canal Find(int id)
        {
            Canal canal = null;
            string request = "SELECT theme, description, dateCreation, Actif, idUtilisateur FROM Canal WHERE id = @idCanal";
            SqlConnection connection = Bdd.Cnx;
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idCanal", id));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                canal = new Canal()
                {
                    CanalId = id,
                    Theme = reader.GetString(0),
                    Description = reader.GetString(1),
                    CanalDateCreation = reader.GetDateTime(2),
                    CanalActif = reader.GetInt32(3),
                    CanalIdUtilisateur = reader.GetInt32(4)
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();

            canal.listPublication = Publication.Find(id);

            return canal;
        }

        public bool Delete()
        {
            AbstractDAO<Canal> dao = new CanalDAO();
            return dao.Delete(this);
        }
        public static List<Canal> GetAll()
        {
            AbstractDAO<Canal> dao = new CanalDAO();
            return dao.FindAll();
        }
        public bool Add()
        {
            AbstractDAO<Canal> dao = new CanalDAO();
            return dao.Create(this);
        }
    }
}
