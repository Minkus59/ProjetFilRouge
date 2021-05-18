using ProjetFileRouge.Models;
using ProjetFileRouge.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjetFileRouge.DAO
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

        public override List<Publication> Find(Publication element)
        {
            throw new NotImplementedException();
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
            request = "UPDATE Publication SET Actif = @actif WHERE id=@id";
            connection = Bdd.Cnx;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@actif", element.PublicationActif));
            command.Parameters.Add(new SqlParameter("@id", element.PublicationId));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }
    }
}
