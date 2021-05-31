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
    public class TravelHistoryRepository : ITravelHistoryRepository
    {

        private RickLocalizationContext _context;

        public TravelHistoryRepository(RickLocalizationContext context)
        {
            _context = context;
        }         

        public bool VerifyIfHumanIsOnHisOriginalDimension(int IdHumansByDimensions)
        {
            try
            {
                TravelHistoryEntity travelHistoryEntity = _context.TravelHistoryEntity
               .FirstOrDefault(x => x.IdHumansByDimensions == IdHumansByDimensions);

                if (travelHistoryEntity != null)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return false;
        }

        public Boolean Save(TravelHistoryEntity travelHistoryEntity)
        {

            try
            {
                travelHistoryEntity.TravelDate = DateTime.Now;
                _context.TravelHistoryEntity.Add(travelHistoryEntity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }     

            return true;
        }
    }
}
