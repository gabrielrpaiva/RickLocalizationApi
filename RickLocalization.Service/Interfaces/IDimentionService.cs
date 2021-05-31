using RickLocalization.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RickLocalization.Service.Interfaces
{
    public interface IDimentionService
    {
        IList<DimensionsEntity> GetAll();
    }
}
