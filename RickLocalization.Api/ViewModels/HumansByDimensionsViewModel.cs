using RickLocalization.Api.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RickLocalization.Api.ViewModels
{
    public class HumansByDimensionsViewModel
    {
        #region "Properties"    

        public int Id { get; set; }
        public int IdHuman { get; set; }

        public int IdDimension { get; set; }

        public int? IdResponsibleForWhichHuman { get; set; }

        public int? IdHumanResponsibleForMe { get; set; }

        public string Name { get; set; }

        public string DimentionName { get; set; }

        public string PartnerName { get; set; }

        #endregion

        #region "Virtual Properties"        

        public virtual HumansViweModel Human { get; set; }
        public virtual IList<TravelHistoryViewModel> TravelHistories { get; set; }

        #endregion
    }
}
