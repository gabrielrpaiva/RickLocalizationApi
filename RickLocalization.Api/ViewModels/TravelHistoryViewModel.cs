using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RickLocalization.Api.ViewModels
{
    public class TravelHistoryViewModel
    {
        #region "Properties"
        public int IdHumansByDimensions { get; set; }

        public int IdTargetDimension { get; set; }

        public string TravelDate { get; set; }

        [NotMapped]
        public string DimensionName { get; set; }

        #endregion
    }
}
