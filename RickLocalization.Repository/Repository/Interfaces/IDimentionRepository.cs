using RickLocalization.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RickLocalization.Repository.Repository.Interfaces
{
    public interface IDimentionRepository
    {
       IList<DimensionsEntity> GetAll();
    }
}
