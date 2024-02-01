using Livraria.Service.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Service.Services
{
    public class AutoresService : IAutoresService
    {
        private readonly DbLivraria _dbLivraria;

        public AutoresService(DbLivraria dbLivraria)
        {
            _dbLivraria = dbLivraria;
        }

        public int Add(Autores autor)
        {
            _dbLivraria.Autores.Add(autor);
            _dbLivraria.SaveChanges();
            return autor.Id;
        }

        public bool Delete(int id)
        {
            var autor = GetById(id);
            if (autor is null)
                return false;

            _dbLivraria.Autores.Remove(autor);
            _dbLivraria.SaveChanges();
            return true;
        }

        public IEnumerable<Autores> GetAll()
        =>_dbLivraria.Autores;
        

        public Autores? GetById(int id)
        => _dbLivraria.Autores.Where(autor => autor.Id == id).FirstOrDefault();

        public bool Update(int id, string? nome)
        {
            var autor = GetById(id);
            if (autor == null)
                return false;

            autor.Nome = nome;

            _dbLivraria.SaveChanges();
            return true;
        }
    }
}
