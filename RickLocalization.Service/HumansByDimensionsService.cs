using RickLocalization.Domain.Entities;
using RickLocalization.Repository.Repository.Interfaces;
using RickLocalization.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RickLocalization.Service
{
    public class HumansByDimensionsService : IHumansByDimensionsService
    {
        private readonly IHumansByDimensionsRepository _repository;

        public HumansByDimensionsService(IHumansByDimensionsRepository repository)
        {
            _repository = repository;
        }
        public HumansByDimensionsEntity GetHumanOriginalDimensionWithTravels(int idHuman)
        {
            try
            {
                return _repository.GetHumanOriginalDimensionWithTravels(idHuman);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
  
        }
    }
}
