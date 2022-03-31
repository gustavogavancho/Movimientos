using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movimientos.API.Models;
using Movimientos.BIZ.Services.Interfaces;
using Movimientos.COMMON.Models;
using Movimientos.DAL.EFCore.Repository.Interfaces;

namespace Movimientos.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteRepository clienteRepository,
            IClienteService clienteService,
            IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCliente()
        {
            return Ok(await _clienteRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> AddCliente([FromBody] ClienteModel cliente)
        {
            if (cliente == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var _mappedCliente = _mapper.Map<Cliente>(cliente);
            var createdCliente = await _clienteService.CreateCliente(_mappedCliente);

            return Created("cliente", createdCliente);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCliente([FromBody] ClienteModel cliente)
        {
            if (cliente == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var _mappedCliente = _mapper.Map<Cliente>(cliente);

            var clienteToUpdate = await _clienteRepository.Update(cliente.Id, _mappedCliente);

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
