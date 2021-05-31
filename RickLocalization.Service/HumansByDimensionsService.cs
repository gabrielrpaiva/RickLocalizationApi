using RickLocalization.Domain.Entities;
using RickLocalization.Repository.Repository.Interfaces;
using RickLocalization.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

        public IList<HumansByDimensionsEntity> GetResponsableHumanOriginalDimension(int IdDimension)
        {
            try
            {
                return _repository.GetResponsableHumanOriginalDimension(IdDimension).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
