using Livraria.Extensions;
using Livraria.Models.Request;
using Livraria.Models.Response;
using Livraria.Service.Data.Entities;
using Livraria.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly DbLivraria _dbLivraria;
        private readonly IAutoresService _autoresService;

        public AutoresController(DbLivraria ctx, IAutoresService autoresService)
        {
            _dbLivraria = ctx;
            _autoresService = autoresService;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            IEnumerable<AutoresResponse> result = _autoresService.GetAll()
                            .Select(autores => autores.Map());

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] AutoresRequest request)
        {
            try
            {

                if (!ModelState.IsValid)
                    return BadRequest(ModelState.CapturaCriticas());

                var id = _autoresService.Add(request.Map());
                return Created(uri: string.Empty, new { id = id.ToString() });
            }
            catch (Exception ex)
            {
                if (ex.GetBaseException().Message.Contains("UK_Autor_Autor.Nome"))
                    return BadRequest(new { Chave = "Autor", Valor = "Autor duplicado" });
                return StatusCode(500, $"Falha na Criação do Autor => {ex.GetBaseException().Message}");
            }

        }

        [HttpGet("{id:int}")]
        public IActionResult ListarId([FromRoute] int id)
        {
            var autor = _autoresService.GetById(id);

            if (autor == null)
                return NotFound("Autor não encontredo");

            var result = autor.Map();
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public IActionResult Edit([FromRoute] int id, [FromBody] AutoresRequest request)
        {

            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.CapturaCriticas());

                if (_autoresService.Update(id, request.Nome))
                    return NoContent();

                return NotFound("Autor não encontrado");

            }
            catch (Exception ex)
            {
                if (ex.GetBaseException().Message.Contains("UK_Autor_Autor.Nome"))
                    return BadRequest(new { Chave = "Autor", Valor = "Autor duplicado" });
                return StatusCode(500, $"Falha na Criação do Autor => {ex.GetBaseException().Message}");
            }


        }


        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (_autoresService.Delete(id))
                return NoContent();

            return NotFound("Autor não encontrado");
        }


    }
}
