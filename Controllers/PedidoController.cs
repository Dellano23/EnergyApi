using AutoMapper;
using Fiap.Api.Energy.Services;
using Fiap.Api.Energy.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Energy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        private readonly IMapper _mapper;

        public PedidoController(IPedidoService pedidoService, IMapper mapper)
        {
            _pedidoService = pedidoService;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult Post([FromBody] CreatePedidoViewModel createPedidoViewModel)
        {
            var pedido = _mapper.Map<PedidoModel>(createPedidoViewModel);

            try
            {
                _pedidoService.AdicionarPedido(pedido);
                return CreatedAtAction(nameof(GetPedidoById), new { id = pedido.PedidoId }, createPedidoViewModel);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public ActionResult<PedidoViewModel> GetPedidoById(int id)
        {
            var pedido = _pedidoService.ObterPedidoPorIdComDetalhes(id);
            if (pedido == null)
            {
                return NotFound();
            }

            var pedidoViewModel = _mapper.Map<PedidoViewModel>(pedido);
            pedidoViewModel.Produtos =
                    _mapper.Map<IEnumerable<ProdutoViewModel>>(
                        pedido.PedidoProdutos.Select(p => p.Produto).ToList()
                    );

            return Ok(pedidoViewModel);
        }
    }
}
