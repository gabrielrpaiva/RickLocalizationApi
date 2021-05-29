using System;
using System.Collections.Generic;
using System.Text;

namespace RickLocalization.Domain.Entities
{
    public class TravelHistoryEntity : BaseEntity
    {
        #region "Properties"
        public int IdHumansByDimensions { get; set; }

        public int IdTargetDimension { get; set; }

        public DateTime TravelDate { get; set; }

        #endregion

        #region "Virtual Properties"

        public virtual HumansByDimensionsEntity HumansByDimensions { get; set; }

        public virtual DimensionsEntity Dimensions { get; set; }

        #endregion
    }
}
