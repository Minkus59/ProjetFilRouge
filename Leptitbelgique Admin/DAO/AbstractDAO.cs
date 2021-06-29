using Leptitbelgique_Admin.Models;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Leptitbelgique_Admin.DAO
{
    abstract class AbstractDAO<T>
    {
        protected static MySqlCommand command;
        protected static MySqlConnection connection;
        protected static MySqlDataReader reader;
        protected static string request;

        public abstract bool Create(T element);

        public abstract bool Delete(T element);

        public abstract bool Update(T element); 

        public abstract List<T> Find(T element);
        public abstract List<T> Find(Func<T, bool> criteria);

        public abstract List<T> FindAll();
    }
}
