using ExemploMongoDB.Requests;
using Microsoft.AspNetCore.Mvc;
using ExemploMongoDB.Domain.Entities;
using ExemploMongoDB.Domain.Contracts.Services;

namespace ExemploMongoDB.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ClienteController : ControllerBase
	{
		private readonly IClienteService _clienteService;

		public ClienteController(IClienteService clienteService)
		{
			_clienteService = clienteService;
		}

		[HttpPost]
		public IActionResult Incluir([FromBody] ClienteRequest cliente)
		{
			_clienteService.Incluir(ClienteRequest.ConvertToCliente(cliente));
			return Created($"api/cliente/{cliente.Id}", cliente);
		}

		[HttpPatch]
		public IActionResult Alterar([FromBody] ClienteRequest cliente)
		{
			_clienteService.Alterar(ClienteRequest.ConvertToCliente(cliente));
			return Ok(cliente);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(400)]
		public IActionResult Pesquisar(string id, [FromQuery] PesquisarClienteRequest cliente)
		{
			var clienteResponse = _clienteService.Pesquisar(PesquisarClienteRequest.ConvertToCliente(id, cliente));

			if (clienteResponse == null)
				return BadRequest();

			return Ok(clienteResponse);
		}

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(List<Cliente>))]
		[ProducesResponseType(400)]
		public IActionResult Pesquisar()
		{
			var clienteResponse = _clienteService.ListarTodos();

			return Ok(clienteResponse);
		}

		[HttpDelete("{id}")]
		public IActionResult Excluir(string id)
		{
			_clienteService.Excluir(id);

			return NoContent();
		}
	}
}
