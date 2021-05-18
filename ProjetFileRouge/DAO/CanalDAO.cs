using ProjetFileRouge.Models;
using ProjetFileRouge.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjetFileRouge.DAO
{
    class CanalDAO : AbstractDAO<Canal>
    {
        public override bool Create(Canal element)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Canal element)
        {
            throw new NotImplementedException();
        }

        public override List<Canal> Find(Func<Canal, bool> criteria)
        {
            throw new NotImplementedException();
        }

        public override List<Canal> Find(Canal element)
        {
            throw new NotImplementedException();
        }

        public override List<Canal> FindAll()
        {
            throw new NotImplementedException();
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
    }
}
