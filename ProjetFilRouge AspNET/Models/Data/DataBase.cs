using System.Data.SqlClient;

namespace ProjetFilRouge_AspNET.Data
{
    public class Bdd
    {
        static string chaine = @"Data Source=(Localdb)\ProjetFileRouge;Integrated Security=True; Connect Timeout=30";
        public static SqlConnection Cnx { get => new SqlConnection(chaine); }

    }
}
