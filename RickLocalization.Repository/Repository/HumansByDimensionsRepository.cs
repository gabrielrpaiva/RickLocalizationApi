using RickLocalization.Domain.Entities;
using RickLocalization.Repository.Context;
using RickLocalization.Repository.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RickLocalization.Repository.Repository
{
    public class HumansByDimensionsRepository : IHumansByDimensionsRepository
    {
        private RickLocalizationContext _context;

        public HumansByDimensionsRepository(RickLocalizationContext context)
        {
            _context = context;
        }

        public HumansByDimensionsEntity GetHumanOriginalDimensionWithTravels(int idHuman)
        {
            try
            {
                return _context.HumansByDimensionsEntity
               .Include(x => x.Human)
               .Include(x => x.Dimensions)
               .Include(x => x.TravelHistories)
               .Include("TravelHistories.Dimensions")
               .FirstOrDefault(x => x.Id == idHuman);
            }
            catch (Exception ex)
            {

                throw ex;
            }  
        }

        public IQueryable<HumansByDimensionsEntity> GetResponsableHumanOriginalDimension(int IdDimension)
        {
            try
            {
                var query = _context.HumansByDimensionsEntity
              .Include(x => x.Human)
              .Include(x => x.Dimensions)
              .Include(x => x.HumanResponsibleForMe)
              .Include(x => x.ResponsibleForWhichHuman).AsQueryable();

                query = query.Where(x => x.IdHumanResponsibleForMe == null);

                if (IdDimension != 0)
                {
                    query = query.Where(x => x.IdDimension == IdDimension);
                }
                

                return query;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
