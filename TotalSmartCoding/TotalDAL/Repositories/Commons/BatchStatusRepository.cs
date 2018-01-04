using System.Linq;
using System.Collections.Generic;

using TotalModel.Models;
using TotalCore.Repositories.Commons;


namespace TotalDAL.Repositories.Commons
{
    public class BatchStatusRepository : GenericRepository<BatchStatus>, IBatchStatusRepository
    {
        public BatchStatusRepository(TotalSmartCodingEntities totalSmartCodingEntities)
            : base(totalSmartCodingEntities, "BatchStatusEditable")
        {
        }
    }





    public class BatchStatusAPIRepository : GenericAPIRepository, IBatchStatusAPIRepository
    {
        public BatchStatusAPIRepository(TotalSmartCodingEntities totalSmartCodingEntities)
            : base(totalSmartCodingEntities, "GetBatchStatusIndexes")
        {
        }

        public IList<BatchStatusBase> GetBatchStatusBases()
        {
            return this.TotalSmartCodingEntities.GetBatchStatusBases().ToList();
        }
    }
}
