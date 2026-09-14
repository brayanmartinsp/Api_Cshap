using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeiraApi.DTOs.CategoriaDto;
using PrimeiraApi.Models;
using PrimeiraApi.Service.CategoriaService;

namespace PrimeiraApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _service;

        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var categorias = await _service.GetAll();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var categoria = await _service.GetById(id);
            if (categoria == null) return NotFound();
            return Ok(categoria);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Categoria), StatusCodes.Status201Created)]
        public async Task<IActionResult> RegistrarCategoria([FromBody] CategoriaCreateDto request)
        {
            try
            {
                var categoria = await _service.Create(request);
                return Created($"/api/categoria/{categoria.Cat_Id}", categoria);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno no servidor.");
            }
            
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCategoria([FromRoute] int id, [FromBody] CategoriaUpdateDto request)
        {
            try
            {
                var categoria = await _service.Update(id, request);
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
