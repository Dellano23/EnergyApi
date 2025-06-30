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
    [Authorize]
    public class CustoEquipamentoController : ControllerBase
    {
        private readonly ICustoEquipamentoService _custoEquipamentoService;
        private readonly IEquipamentoService _equipamentoService;
        private readonly IMapper mapper;

        public CustoEquipamentoController(ICustoEquipamentoService custoEquipamentoService, IMapper mapper)
        {
            _custoEquipamentoService = custoEquipamentoService;
            this.mapper = mapper;
        }

        [HttpPost]
        public ActionResult Post([FromBody] CustoEquipamentoViewModel custoEquipamentoViewModel)
        {

            try
            {
                var custo = _custoEquipamentoService.AdicionarCustoEquipamento(custoEquipamentoViewModel);
                return Created("", custo); // ou retornar a rota correta depois
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro interno ao processar a requisição.");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<CustoEquipamentoModel>> Get()
        {
            var custos = _custoEquipamentoService.ObterTodosEquipementos();
            
            return Ok(custos);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "gerente")]
        public ActionResult Put(int id, [FromBody] CustoEquipamentoUpdateViewModel custoEquipamentoUpdateViewModel)
        {
            var custoExistente = _custoEquipamentoService.ObterCustoEquipamentoPorId(id);
            if (custoExistente == null)
                return NotFound();

            mapper.Map(custoEquipamentoUpdateViewModel, custoExistente);
            _custoEquipamentoService.AtualizarCustoEquipamento(custoExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "gerente")]
        public ActionResult Delete(int id)
        {
            _custoEquipamentoService.DeletarCustoEquipamento(id);
            return NoContent();
        }





    }
}
