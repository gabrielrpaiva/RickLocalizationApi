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
        [Route("GetHumanOriginalDimensionWithTravels/{idHuman}")]
        public virtual async Task<IActionResult> GetHumanOriginalDimensionWithTravels([FromRoute] int IdHuman)
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
        [Route("GetResponsableHumanOriginalDimension/{idDimension}")]
        public virtual async Task<IActionResult> GetResponsableHumanOriginalDimension([FromRoute] int IdDimension)
        {
            List<HumansByDimensionsViewModel> entidade = new List<HumansByDimensionsViewModel>();

            try
            {
                await Task.Run(() =>
                {
                    IList<HumansByDimensionsEntity> entity = _service.GetResponsableHumanOriginalDimension(IdDimension);
                    entidade = _mapper.Map<List<HumansByDimensionsViewModel>>(entity);

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
