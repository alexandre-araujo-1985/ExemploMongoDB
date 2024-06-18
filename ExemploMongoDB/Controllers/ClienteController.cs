using ExemploMongoDB.Requests;
using Microsoft.AspNetCore.Mvc;
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
			return Created("", cliente);
		}

		[HttpPatch]
		public IActionResult Alterar([FromBody] ClienteRequest cliente)
		{
			_clienteService.Alterar(ClienteRequest.ConvertToCliente(cliente));
			return Created("", cliente);
		}

		[HttpGet("{id}")]
		public IActionResult Pesquisar(string id, [FromQuery] string nome, [FromQuery] bool status)
		{
			var cliente = new ClienteRequest { Id = id, Nome = nome, Status = status };
			var clienteResponse = _clienteService.Pesquisar(ClienteRequest.ConvertToCliente(cliente));
			return Ok(clienteResponse);
		}
	}
}
