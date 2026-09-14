using Microsoft.AspNetCore.Mvc;
using PrimeiraApi.Data;
using PrimeiraApi.DTOs.ProdutoDto;
using PrimeiraApi.Models;
using PrimeiraApi.Service.ProdutoService;

namespace PrimeiraApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProdutoController : ControllerBase
	{
		private readonly IProdutoService _service;

        public ProdutoController(IProdutoService service)
        {
			_service = service;

		}
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok(await _service.GetAll());
		}
	   

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
			=> Ok(await _service.GetById(id));

		[HttpPost]
		public async Task<IActionResult> Post([FromBody]ProdutoCreateDto dto)
		{
			try 
			{
				await _service.Create(dto);
				return Created("", null);
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError     , "Ocorreu um erro interno no servidor.");
			}
			
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put([FromRoute] int id,[FromBody] ProdutoCreateDto dto)
		{
			await _service.Update(id, dto);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _service.Delete(id);
			return NoContent();
		}


	}
}
