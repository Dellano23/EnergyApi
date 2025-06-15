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
    public class RepresentanteController : ControllerBase
    {
        private readonly IRepresentanteService _representanteService; //acesso aos dados
        private readonly IMapper _mapper;

        public RepresentanteController(IRepresentanteService representanteService, IMapper mapper)
        {
            _representanteService = representanteService;
            _mapper = mapper;  
        }

        [HttpGet]
        public ActionResult<IEnumerable<RepresentanteViewModel>> Get()
        {
            var lista = _representanteService.ListarRepresentantes();
            var viewModelList = _mapper.Map<IEnumerable<RepresentanteViewModel>>(lista);

            if (viewModelList == null)
            {
                return NoContent();
            } else
            {
                return Ok(viewModelList);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "operador, analista, gerente")]
        public ActionResult<RepresentanteViewModel> Get([FromRoute] int id)
        {
            var model = _representanteService.ObterRepresentantePorId(id);


            if (model == null)
            {
                return NotFound();
            }
            else
            {
                var viewModel = _mapper.Map<RepresentanteViewModel>(model);
                return Ok(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] RepresentanteViewModel viewModel)
        {
            var model = _mapper.Map<RepresentanteModel>(viewModel);
            _representanteService.CriarRepresentante(model); //o create pede um model, transformo a view em model com o map
            
            return CreatedAtAction(nameof(Get), new { id = model.RepresentanteId}, model);
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromRoute]int id, [FromBody] RepresentanteViewModel viewModel)
        {
            if (viewModel.RepresentanteId == id)
            {
                var model = _mapper.Map<RepresentanteModel>(viewModel);
                _representanteService.AtualizarRepresentante(model);

                return NoContent();
            } else
            {
                return BadRequest();
            }

            
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _representanteService.DeletarRepresentante(id);
            return NoContent();
        }



    }
}
