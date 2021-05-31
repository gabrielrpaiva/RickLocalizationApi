using RickLocalization.Domain.Entities;
using RickLocalization.Repository.Repository.Interfaces;
using RickLocalization.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RickLocalization.Service
{
    public class DimentionService : IDimentionService
    {
        private readonly IDimentionRepository _repository;

        public DimentionService(IDimentionRepository repository)
        {
            _repository = repository;
        }
        public IList<DimensionsEntity> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
