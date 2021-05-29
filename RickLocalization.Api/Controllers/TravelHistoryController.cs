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
    public class TravelHistoryController : Controller
    {

        private readonly ITravelHistoryService _service;
        private readonly IMapper _mapper;

        public TravelHistoryController(ITravelHistoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Save")]
        public virtual async Task<IActionResult> Save([FromBody] TravelHistoryViewModel travelHistoryViewModel)
        {
            Boolean result;

            try
            {
                TravelHistoryEntity entity = this._mapper.Map<TravelHistoryEntity>(travelHistoryViewModel);
                 result = await Task.Run(() => _service.Save(entity));               
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


            return Ok(result);
        }
    }
}
