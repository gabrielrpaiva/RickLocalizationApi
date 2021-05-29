using RickLocalization.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RickLocalization.Repository.Repository.Interfaces
{
    public interface ITravelHistoryRepository
    {
        Boolean VerifyIfHumanIsOnHisOriginalDimension(int IdHumansByDimensions);
        Boolean Save(TravelHistoryEntity travelHistoryEntity);
    }
}
