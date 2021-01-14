using AutoMapper;
using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Services;
using DesignPatternSamples.WebAPI.Models;
using DesignPatternSamples.WebAPI.Models.Detran;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.WebAPI.Controllers.Detran
{
    [Route("api/Detran/[controller]")]
    [ApiController]
    public class RestricoesController : ControllerBase
    {
        private readonly IMapper _Mapper;
        private readonly IDetranVerificadorRestricoesService _DetranVerificadorRestricoesServices;

        public RestricoesController(IMapper mapper, IDetranVerificadorRestricoesService detranVerificadorRestricoesServices)
        {
            _Mapper = mapper;
            _DetranVerificadorRestricoesServices = detranVerificadorRestricoesServices;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(SuccessResultModel<IEnumerable<RestricoesVeiculoModel>>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get([FromQuery]VeiculoModel model)
        {
            var restricoes = await _DetranVerificadorRestricoesServices.ConsultarRestricoes(_Mapper.Map<Veiculo>(model));

            var result = new SuccessResultModel<IEnumerable<RestricoesVeiculoModel>>(_Mapper.Map<IEnumerable<RestricoesVeiculoModel>>(restricoes));

            return Ok(result);
        }
    }
}