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
        public ActionResult Post([FromBody] EquipamentoViewModel equipamentoViewModel)
        {
            var equipamento = mapper.Map<EquipamentoModel>(equipamentoViewModel);

            _equipamentoService.CriarEquipamento(equipamento);
            //return CreatedAtAction(nameof(Get), new { id = equipamento.EquipamentoId}, equipamento);
            return StatusCode(201, equipamento);
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
