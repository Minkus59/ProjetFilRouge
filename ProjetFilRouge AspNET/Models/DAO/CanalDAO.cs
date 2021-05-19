using ProjetFilRouge_AspNET.Data;
using ProjetFilRouge_AspNET.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjetFilRouge_AspNET.DAO
{
    class CanalDAO : AbstractDAO<Canal>
    {
        public override bool Delete(Canal element)
        {
            throw new NotImplementedException();
        }

        public override List<Canal> Find(Func<Canal, bool> criteria)
        {
            throw new NotImplementedException();
        }

        public override List<Canal> Find(int id)
        {
            List<Canal> canal = new List<Canal>();
            request = "SELECT theme, description, dateCreation, Actif, idUtilisateur FROM Canal WHERE id = @idCanal";
            connection = Bdd.Cnx;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idCanal", id));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Canal c = new Canal
                {
                    CanalId = id,
                    Theme = reader.GetString(0),
                    Description = reader.GetString(1),
                    CanalDateCreation = reader.GetDateTime(2),
                    CanalActif = reader.GetInt32(3),
                    CanalIdUtilisateur = reader.GetInt32(4)
                };
                canal.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return canal;
        }

        public override List<Canal> FindAll()
        {
            List<Canal> canal = new List<Canal>();
            request = "SELECT id, theme, description, DateCreation, IdUtilisateur FROM Canal WHERE actif = 1 ORDER BY id DESC";
            connection = Bdd.Cnx;
            command = new SqlCommand(request, connection);
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
                    CanalIdUtilisateur = reader.GetInt32(4)
                };
                canal.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return canal;
        }

        public override bool Update(Canal element)
        {
            request = "UPDATE Canal SET actif = @actif WHERE id=@idCanal";
            connection = Bdd.Cnx;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@actif", element.CanalActif));
            command.Parameters.Add(new SqlParameter("@idCanal", element.CanalId));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

        public override bool Create(Canal element)
        {
            throw new NotImplementedException();
        }
    }
}
