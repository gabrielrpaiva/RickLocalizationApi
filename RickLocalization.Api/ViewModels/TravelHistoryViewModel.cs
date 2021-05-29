using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RickLocalization.Api.ViewModels
{
    public class TravelHistoryViewModel
    {
        #region "Properties"
        public int IdHumansByDimensions { get; set; }

        public int IdTargetDimension { get; set; }

        public DateTime TravelDate { get; set; }

        public string DimensionName { get; set; }

        #endregion
    }
}
