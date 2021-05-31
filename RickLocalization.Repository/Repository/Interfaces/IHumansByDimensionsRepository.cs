using RickLocalization.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RickLocalization.Repository.Repository.Interfaces
{
    public interface IHumansByDimensionsRepository
    {
        HumansByDimensionsEntity GetHumanOriginalDimensionWithTravels(int idHuman);
        IQueryable<HumansByDimensionsEntity> GetResponsableHumanOriginalDimension(int IdDimension);
    }
}
