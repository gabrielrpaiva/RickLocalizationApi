using RickLocalization.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RickLocalization.Service.Interfaces
{
    public interface IHumansByDimensionsService
    {
        HumansByDimensionsEntity GetHumanOriginalDimensionWithTravels(int idHuman);
        HumansByDimensionsEntity GetResponsableHumanOriginalDimension(int idHuman);
    }
}
