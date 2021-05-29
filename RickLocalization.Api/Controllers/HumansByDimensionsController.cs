using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RickLocalization.Api.Response;
using RickLocalization.Api.ViewModels;
using RickLocalization.Domain.Entities;
using RickLocalization.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RickLocalization.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class HumansByDimensionsController : BaseController
    {

        private readonly IHumansByDimensionsService _service;
        private readonly IMapper _mapper;

        public HumansByDimensionsController(IHumansByDimensionsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetHumanOriginalDimensionWithTravels")]
        public virtual async Task<IActionResult> GetHumanOriginalDimensionWithTravels([FromQuery] int IdHuman)
        {
            HumansByDimensionsViewModel entidade = new HumansByDimensionsViewModel();

            try
            {
                await Task.Run(() =>
                {
                    HumansByDimensionsEntity entity = _service.GetHumanOriginalDimensionWithTravels(IdHuman);
                    entidade = _mapper.Map<HumansByDimensionsViewModel>(entity);

                });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
            
            return Ok(entidade);
        }


        [HttpGet]
        [Route("GetResponsableHumanOriginalDimension")]
        public virtual async Task<IActionResult> GetResponsableHumanOriginalDimension([FromQuery] int IdHuman)
        {
            HumansByDimensionsViewModel entidade = new HumansByDimensionsViewModel();

            try
            {
                await Task.Run(() =>
                {
                    HumansByDimensionsEntity entity = _service.GetResponsableHumanOriginalDimension(IdHuman);
                    entidade = _mapper.Map<HumansByDimensionsViewModel>(entity);

                });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


            return Ok(entidade);
        }
    }
}
