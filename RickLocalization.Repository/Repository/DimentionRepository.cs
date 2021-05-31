using RickLocalization.Domain.Entities;
using RickLocalization.Repository.Context;
using RickLocalization.Repository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RickLocalization.Repository.Repository
{
    public class DimentionRepository : IDimentionRepository
    {
        private RickLocalizationContext _context;

        public DimentionRepository(RickLocalizationContext context)
        {
            _context = context;
        }

        public IList<DimensionsEntity> GetAll()
        {
            try
            {
                return _context.DimensionsEntity.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
