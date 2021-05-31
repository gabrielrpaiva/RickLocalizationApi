using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    public class DimentionController : Controller
    {

        private readonly IDimentionService _service;
        private readonly IMapper _mapper;

        public DimentionController(IDimentionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GelAll")]
        public virtual async Task<IActionResult> GetAll()
        {
            List<DimensionViewModel> entidade = new List<DimensionViewModel>();

            try
            {
                await Task.Run(() =>
                {
                    IList<DimensionsEntity> entity = _service.GetAll();
                    entidade = _mapper.Map<List<DimensionViewModel>>(entity);

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
