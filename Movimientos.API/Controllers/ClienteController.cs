using Microsoft.AspNetCore.Mvc;
using Movimientos.BIZ.Repository.Interfaces;
using Movimientos.COMMON.Models;

namespace Movimientos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCliente()
        {
            return Ok(await _clienteRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> AddCliente([FromBody] Cliente cliente)
        {
            if (cliente == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdCliente = await _clienteRepository.Create(cliente);

            return Created("cliente", createdCliente);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCliente([FromBody] Cliente cliente)
        {
            if (cliente == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var clienteToUpdate = await _clienteRepository.Update(cliente.Id, cliente);

            if (clienteToUpdate == null)
                return NotFound();

            return Ok(clienteToUpdate); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var employeeToDelete = await _clienteRepository.Delete(id);

            if (employeeToDelete is false)
                return NotFound();

            return Ok(employeeToDelete);
        }
    }
}
