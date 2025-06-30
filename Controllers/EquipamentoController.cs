using AutoMapper;
using Fiap.Api.Energy.Models;
using Fiap.Api.Energy.Services;
using Fiap.Api.Energy.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Energy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentoController : ControllerBase
    {
        private readonly IEquipamentoService _equipamentoService;
        private readonly IMapper mapper;

        public EquipamentoController(IEquipamentoService equipamentoService, IMapper mapper)
        {
            _equipamentoService = equipamentoService;
            this.mapper = mapper;
        }

        [HttpPost]
        public ActionResult Post([FromBody] EquipamentoCreateViewModel equipamentoCreateViewModel)
        {
            

            _equipamentoService.CriarEquipamento(equipamentoCreateViewModel);
            //return CreatedAtAction(nameof(Get), new { id = equipamento.EquipamentoId}, equipamento);
            return StatusCode(201, equipamentoCreateViewModel);
        }

        //get paginado

        [HttpGet]
        public ActionResult<IEnumerable<EquipamentoPaginacaoViewModel>> Get([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            var equipamentos = _equipamentoService.ListarEquipamentos(pagina, tamanho);
            var viewModelList = mapper.Map<IEnumerable<EquipamentoViewModel>>(equipamentos);
            var viewModel = new EquipamentoPaginacaoViewModel
            {
                Equipamentos = viewModelList,
                CurrentPage = pagina,
                PageSize = tamanho
            };
            return Ok(viewModel);
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] EquipamentoViewModel equipamentoViewModel)
        {
            var equipamentoExistente = _equipamentoService.ObterEquipamentoPorId(id);
            if (equipamentoExistente == null)
                return NotFound();

            mapper.Map(equipamentoViewModel, equipamentoExistente);
            _equipamentoService.AtualizarEquipamento(equipamentoExistente);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _equipamentoService.DeletarEquipamento(id);
            return NoContent();
        }
    }
}
