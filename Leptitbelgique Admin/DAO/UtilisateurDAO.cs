using Leptitbelgique_Admin.Models;
using Leptitbelgique_Admin.Data;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Leptitbelgique_Admin.DAO
{
    class UtilisateurDAO : AbstractDAO<Utilisateur>
    {
        public override bool Create(Utilisateur element)
        {
            request = "INSERT INTO Utilisateur (pseudo, nom, prenom, email, mdp, DateCreation, actif, admin) OUTPUT INSERTED.ID VALUES (@pseudo, @nom, @prenom, @email, @mdp, @dateCreation, @actif, @administrateur)";
            connection = Bdd.Cnx;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@nom", element.Nom));
            command.Parameters.Add(new MySqlParameter("@email", element.Email));
            command.Parameters.Add(new MySqlParameter("@mdp", element.MotDePasse));
            command.Parameters.Add(new MySqlParameter("@dateCreation", element.DateCreation));
            command.Parameters.Add(new MySqlParameter("@actif", element.Actif));
            command.Parameters.Add(new MySqlParameter("@administrateur", element.Administrateur));
            connection.Open();
            element.Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return element.Id > 0;
        }

        public override List<Utilisateur> Find(Utilisateur element)
        {
            throw new NotImplementedException();
        }

        public override List<Utilisateur> Find(Func<Utilisateur, bool> criteria)
        {
            throw new NotImplementedException();
        }

        public override List<Utilisateur> FindAll()
        {
            List<Utilisateur> personnes = new List<Utilisateur>();
            request = "SELECT * FROM Utilisateur ORDER BY id ASC";
            connection = Bdd.Cnx;
            command = new MySqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Utilisateur c = new Utilisateur
                {
                    Id = reader.GetInt32(0),
                    Nom = reader.GetString(2),
                    Email = reader.GetString(4),
                    MotDePasse = reader.GetString(5),
                    DateCreation = reader.GetDateTime(6),
                    Actif = reader.GetInt32(8),
                    Administrateur = reader.GetInt32(9)
                };
                personnes.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return personnes;
        }

        public override bool Update(Utilisateur element)
        {
            request = "UPDATE Utilisateur set Nom = @nom, Email = @email, mdp = @mdp, admin = @administrateur, actif = @actif where id=@id";
            connection = Bdd.Cnx;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@nom", element.Nom));
            command.Parameters.Add(new MySqlParameter("@email", element.Email));
            command.Parameters.Add(new MySqlParameter("@mdp", element.MotDePasse));
            command.Parameters.Add(new MySqlParameter("@actif", element.Actif));
            command.Parameters.Add(new MySqlParameter("@administrateur", element.Administrateur));
            command.Parameters.Add(new MySqlParameter("@id", element.Id));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

        public override bool Delete(Utilisateur element)
        {
            request = "DELETE FROM Utilisateur WHERE id=@id";
            connection = Bdd.Cnx;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@id", element.Id));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }
    }
}
