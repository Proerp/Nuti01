﻿using System;
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
    public class BatchAPIs
    {
        private readonly IBatchAPIRepository batchAPIRepository;

        public BatchAPIs(IBatchAPIRepository batchAPIRepository)
        {
            this.batchAPIRepository = batchAPIRepository;
        }


        public ICollection<BatchIndex> GetBatchIndexes(bool showCummulativePacks, GlobalEnums.ActiveOption activeOption, bool defaultOnly)
        {
            this.batchAPIRepository.RepositoryBag["ShowCummulativePacks"] = showCummulativePacks ? 1 : 0;
            this.batchAPIRepository.RepositoryBag["ActiveOption"] = (int)activeOption;
            this.batchAPIRepository.RepositoryBag["DefaultOnly"] = defaultOnly ? 1 : 0;
            ICollection<BatchIndex> goodsReceiptIndexes = this.batchAPIRepository.GetEntityIndexes<BatchIndex>(ContextAttributes.User.UserID, ContextAttributes.FromDate, ContextAttributes.ToDate);

            return goodsReceiptIndexes;
        }

        public BatchIndex GetActiveBatchIndex()
        {
            BatchIndex goodsReceiptIndexes = this.GetBatchIndexes(false, GlobalEnums.ActiveOption.Active, true).Where(w => w.IsDefault).FirstOrDefault();

            return goodsReceiptIndexes;
        }

        public List<PendingLot> GetPendingLots(int? locationID)
        {
            return this.batchAPIRepository.GetPendingLots(locationID);
        }

        public List<BatchRepack> GetBatchRepacks(int? batchID)
        {
            return this.batchAPIRepository.GetBatchRepacks(batchID);
        }

        public IList<BatchAvailable> GetBatchAvailables(int? locationID, int? deliveryAdviceID, int? transferOrderID, int? commodityID, bool withNullRow)
        {
            return this.batchAPIRepository.GetBatchAvailables(locationID, deliveryAdviceID, transferOrderID, commodityID, withNullRow);
        }
    }
}
