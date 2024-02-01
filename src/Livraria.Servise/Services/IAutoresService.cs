using Livraria.Service.Data.Entities;

namespace Livraria.Service.Services
{
    public interface IAutoresService
    {
        int Add(Autores autor);
        Autores? GetById(int id);
        bool Update(int id ,string? nome);
        IEnumerable<Autores> GetAll();
        bool Delete(int id);

    }
}