using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;



using TotalBase.Enums;
using TotalModel.Models;

using TotalDTO.Inventories;

using TotalCore.Repositories.Productions;
using TotalBase;

namespace TotalSmartCoding.Controllers.APIs.Productions
{
    public class BatchMasterAPIs
    {
        private readonly IBatchMasterAPIRepository batchMasterAPIRepository;

        public BatchMasterAPIs(IBatchMasterAPIRepository batchMasterAPIRepository)
        {
            this.batchMasterAPIRepository = batchMasterAPIRepository;
        }


        public ICollection<BatchMasterIndex> GetBatchMasterIndexes(GlobalEnums.ActiveOption activeOption)
        {
            this.batchMasterAPIRepository.RepositoryBag["ActiveOption"] = (int)activeOption;
            ICollection<BatchMasterIndex> goodsReceiptIndexes = this.batchMasterAPIRepository.GetEntityIndexes<BatchMasterIndex>(ContextAttributes.User.UserID, ContextAttributes.FromDate, ContextAttributes.ToDate);

            return goodsReceiptIndexes;
        }

        public BatchMasterIndex GetActiveBatchMasterIndex()
        {
            BatchMasterIndex goodsReceiptIndexes = this.GetBatchMasterIndexes(GlobalEnums.ActiveOption.Active).Where(w => w.IsDefault).FirstOrDefault();

            return goodsReceiptIndexes;
        }

        public IList<BatchMasterBase> GetBatchMasterBases()
        {
            return this.batchMasterAPIRepository.GetBatchMasterBases();
        }
    }
}
