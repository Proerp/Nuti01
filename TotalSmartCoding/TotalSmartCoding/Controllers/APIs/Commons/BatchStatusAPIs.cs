using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;


using TotalBase.Enums;
using TotalModel.Models;

using TotalDTO.Inventories;

using TotalCore.Repositories.Commons;
using TotalBase;

namespace TotalSmartCoding.Controllers.APIs.Commons
{
    public class BatchStatusAPIs
    {
        private readonly IBatchStatusAPIRepository batchStatusAPIRepository;

        public BatchStatusAPIs(IBatchStatusAPIRepository batchStatusAPIRepository)
        {
            this.batchStatusAPIRepository = batchStatusAPIRepository;
        }


        public ICollection<BatchStatusIndex> GetBatchStatusIndexes()
        {
            return this.batchStatusAPIRepository.GetEntityIndexes<BatchStatusIndex>(ContextAttributes.User.UserID, ContextAttributes.FromDate, ContextAttributes.ToDate).ToList();
        }

        public IList<BatchStatusBase> GetBatchStatusBases()
        {
            return this.batchStatusAPIRepository.GetBatchStatusBases();
        }

    }
}
