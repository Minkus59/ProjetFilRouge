using MySql.Data.MySqlClient;

namespace Leptitbelgique_Admin.Data
{
    public class Bdd
    {
        static string chaine = @"Database=leptitbelgique; Data Source=185.22.217.170; User Id=root; Password=Cqdfx301";
        public static MySqlConnection Cnx = new MySqlConnection(chaine);
    }
}
