using AutoMapper;
using Fiap.Api.Energy.Models;
using Fiap.Api.Energy.Services;
using Fiap.Api.Energy.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Energy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] //aplicando autorizacao
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<ClienteViewModel>> Get()
        //{
        //    var clientes = _service.ListarClientes();
        //    var viewModelList = _mapper.Map<IEnumerable<ClienteViewModel>>(clientes);
        //    return Ok(viewModelList);
        //}


        [HttpGet]
        public ActionResult<IEnumerable<ClientePaginacaoViewModel>> Get([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            var clientes = _service.ListarClientes(pagina, tamanho);
            var viewModelList = _mapper.Map<IEnumerable<ClienteViewModel>>(clientes);
            var viewModel = new ClientePaginacaoViewModel
            {
                Clientes = viewModelList,
                CurrentPage = pagina,
                PageSize = tamanho
            };
            return Ok(viewModel);
        }
        //[HttpGet]
        //public ActionResult<IEnumerable<ClientePaginacaoReferenciaViewModel>> Get([FromQuery] int referencia = 0, [FromQuery] int tamanho = 10)
        //{
        //    var clientes = _service.ListarClientesUltimaReferencia(referencia, tamanho);
        //    var viewModelList = _mapper.Map<IEnumerable<ClienteViewModel>>(clientes);
        //    var viewModel = new ClientePaginacaoReferenciaViewModel
        //    {
        //        Clientes = viewModelList,
        //        PageSize = tamanho,
        //        Ref = referencia,
        //        NextRef = viewModelList.Last().ClienteId
        //    };
        //    return Ok(viewModel);
        //}

        [HttpGet("{id}")]
        public ActionResult<ClienteViewModel> Get(int id)
        {
            var cliente = _service.ObterClientePorId(id);
            if (cliente == null)
                return NotFound();

            var viewModel = _mapper.Map<ClienteViewModel>(cliente);
            return Ok(viewModel);
        }

        [HttpPost]
        public ActionResult Post([FromBody] ClienteCreateViewModel viewModel)
        {
            var cliente = _mapper.Map<ClienteModel>(viewModel);
            

            _service.CriarCliente(cliente);
            return CreatedAtAction(nameof(Get), new { id = cliente.ClienteId }, cliente);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ClienteViewModel viewModel)
        {
            var clienteExistente = _service.ObterClientePorId(id);
            if (clienteExistente == null)
                return NotFound();

            _mapper.Map(viewModel, clienteExistente);
            _service.AtualizarCliente(clienteExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _service.DeletarCliente(id);
            return NoContent();
        }
    }
}
