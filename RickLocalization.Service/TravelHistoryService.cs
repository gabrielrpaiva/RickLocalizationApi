using RickLocalization.Domain.Entities;
using RickLocalization.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RickLocalization.Service
{
    public class TravelHistoryService : ITravelHistoryService
    {

        private readonly ITravelHistoryService _repository;

        public TravelHistoryService(ITravelHistoryService repository)
        {
            _repository = repository;
        }

        public bool Save(TravelHistoryEntity travelHistoryEntity)
        {
            return _repository.Save(travelHistoryEntity);
        }
    }
}
