using ProjetFilRouge_AspNET.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjetFilRouge_AspNET.DAO
{
    abstract class AbstractDAO<T>
    {
        protected static SqlCommand command;
        protected static SqlConnection connection;
        protected static SqlDataReader reader;
        protected static string request;

        public abstract bool Create(T element);

        public abstract bool Delete(T element);

        public abstract bool Update(T element); 

        public abstract List<T> Find(T element);
        public abstract List<T> Find(Func<T, bool> criteria);

        public abstract List<T> FindAll();
    }
}
