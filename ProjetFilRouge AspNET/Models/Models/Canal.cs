using ProjetFilRouge_AspNET.DAO;
using ProjetFilRouge_AspNET.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ProjetFilRouge_AspNET.Models
{
    public class Canal
    {
        private int canalId;
        private string theme;
        private string description;
        private DateTime canalDateCreation;
        private int canalActif;
        private int canalIdUtilisateur;

        public Canal()
        {
            CanalDateCreation = DateTime.Now;
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
        public List<Canal> Find(Canal element)
        {
            AbstractDAO<Canal> dao = new CanalDAO();
            return dao.Find(this);
        }
        public bool Delete()
        {
            AbstractDAO<Canal> dao = new CanalDAO();
            return dao.Delete(this);
        }
        public static List<Canal> GetAll()
        {
            AbstractDAO<Canal> dao = new CanalDAO();
            return dao.FindAll();
        }
        public bool Add()
        {
            AbstractDAO<Canal> dao = new CanalDAO();
            return dao.Create(this);
        }
    }
}
