using RickLocalization.Domain.Entities;
using RickLocalization.Repository.Repository.Interfaces;
using RickLocalization.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RickLocalization.Service
{
    public class TravelHistoryService : ITravelHistoryService
    {

        private readonly ITravelHistoryRepository _repository;

        public TravelHistoryService(ITravelHistoryRepository repository)
        {
            _repository = repository;
        }

        public bool Save(TravelHistoryEntity travelHistoryEntity)
        {
            return _repository.Save(travelHistoryEntity);
        }
    }
}
