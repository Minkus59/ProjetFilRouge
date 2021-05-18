using ProjetFileRouge.DAO;
using ProjetFileRouge.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ProjetFileRouge.Models
{
    class Canal
    {
        private int canalId;
        private string theme;
        private string description;
        private DateTime canalDateCreation;
        private int canalActif;
        private int canalIdUtilisateur;

        public Canal()
        {
        }

        public int CanalId { get => canalId; set => canalId = value; }
        public string Theme { get => theme; set => theme = value; }
        public string Description { get => description; set => description = value; }
        public DateTime CanalDateCreation { get => canalDateCreation; set => canalDateCreation = value; }
        public int CanalActif { get => canalActif; set => canalActif = value; }
        public int CanalIdUtilisateur { get => canalIdUtilisateur; set => canalIdUtilisateur = value; }

        public bool Update()
        {
            AbstractDAO<Canal> dao = new CanalDAO();
            return dao.Update(this);
        }
        public List<Canal> Find(Utilisateur element)
        {
            List<Canal> canal = new List<Canal>();
            string request = "SELECT * FROM Canal WHERE idUtilisateur = @idUtilisateur ORDER BY id ASC";
            SqlConnection connection = Bdd.Cnx;
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idUtilisateur", element.Id));
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
                    CanalActif = reader.GetInt32(4),
                    CanalIdUtilisateur = element.Id
                };
                canal.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return canal;
        }
    }
}
