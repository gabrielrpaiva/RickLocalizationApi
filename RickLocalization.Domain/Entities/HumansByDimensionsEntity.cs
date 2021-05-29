using System;
using System.Collections.Generic;
using System.Text;

namespace RickLocalization.Domain.Entities
{
    public class HumansByDimensionsEntity : BaseEntity
    {

        #region "Properties"
        public int IdHuman { get; set; }

        public int IdDimension { get; set; }

        public int? IdResponsibleForWhichHuman { get; set; }

        public int? IdHumanResponsibleForMe { get; set; }

        #endregion

        #region "Virtual Properties"        

        public virtual HumansEntity Human { get; set; }
        public virtual DimensionsEntity Dimensions { get; set; }

        public virtual HumansEntity ResponsibleForWhichHuman { get; set; }

        public virtual HumansEntity HumanResponsibleForMe { get; set; }

        public virtual IList<TravelHistoryEntity> TravelHistories { get; set; }

        #endregion

    }
}
