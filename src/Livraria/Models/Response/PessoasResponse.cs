using Livraria.Service.Models;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Models.Response
{
    public class PessoasResponse
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        
        public CepResponse Endereco { get; set; }

        public string Telefone { get; set; }
    }
}
