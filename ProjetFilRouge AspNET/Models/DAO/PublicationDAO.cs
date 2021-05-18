using ProjetFilRouge_AspNET.Models;
using ProjetFilRouge_AspNET.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjetFilRouge_AspNET.DAO
{
    class PublicationDAO : AbstractDAO<Publication>
    {
        public override bool Create(Publication element)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Publication element)
        {
            request = "DELETE FROM Publication WHERE id=@id";
            connection = Bdd.Cnx;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", element.PublicationId));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

        public override List<Publication> Find(Func<Publication, bool> criteria)
        {
            throw new NotImplementedException();
        }

        public override List<Publication> FindAll()
        {
            throw new NotImplementedException();
        }

        public override bool Update(Publication element)
        {
            request = "UPDATE Publication SET Contenu = @Contenu WHERE id=@id";
            connection = Bdd.Cnx;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@Contenu", element.Contenu));
            command.Parameters.Add(new SqlParameter("@id", element.PublicationId));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

        public static List<Publication> Find(Canal element)
        {
            List<Publication> publication = new List<Publication>();
            request = "SELECT * FROM Publication WHERE idCanal = @idCanal ORDER BY id ASC";
            connection = Bdd.Cnx;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idCanal", element.CanalId));
            connection.Open();
            reader = command.ExecuteReader();
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

        public override List<Publication> Find(Publication element)
        {
            throw new NotImplementedException();
        }
    }
}
