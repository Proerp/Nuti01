using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using TotalBase.Enums;
using TotalModel.Models;
using TotalCore.Repositories.Productions;
using System.Data.Entity.Core.Objects;
using TotalBase;

namespace TotalDAL.Repositories.Productions
{
    public class BatchRepository : GenericRepository<Batch>, IBatchRepository
    {
        public BatchRepository(TotalSmartCodingEntities totalSmartCodingEntities)
            : base(totalSmartCodingEntities, "BatchEditable")
        {
        }

        public void CommonUpdate(int batchID, string nextPackNo, string nextCartonNo, string nextPalletNo)
        {
            this.TotalSmartCodingEntities.BatchCommonUpdate(batchID, nextPackNo, nextCartonNo, nextPalletNo);
        }

        public void AddLot(int batchID)
        {
            this.TotalSmartCodingEntities.BatchAddLot(batchID);
        }        
    }








    public class BatchAPIRepository : GenericAPIRepository, IBatchAPIRepository
    {
        public BatchAPIRepository(TotalSmartCodingEntities totalSmartCodingEntities)
            : base(totalSmartCodingEntities, "GetBatchIndexes")
        {
        }

        protected override ObjectParameter[] GetEntityIndexParameters(int userID, DateTime fromDate, DateTime toDate)
        {
            ObjectParameter[] baseParameters = base.GetEntityIndexParameters(userID, fromDate, toDate);

            return new ObjectParameter[] { baseParameters[0], baseParameters[1], baseParameters[2], new ObjectParameter("FillingLineID", (int)GlobalVariables.FillingLineID), new ObjectParameter("ShowCummulativePacks", (int)(this.RepositoryBag["ShowCummulativePacks"] != null ? this.RepositoryBag["ShowCummulativePacks"] : 0)), new ObjectParameter("ActiveOption", (int)(this.RepositoryBag["ActiveOption"] != null ? this.RepositoryBag["ActiveOption"] : GlobalEnums.ActiveOption.Both)), new ObjectParameter("DefaultOnly", (int)(this.RepositoryBag["DefaultOnly"] != null ? this.RepositoryBag["DefaultOnly"] : 0)) };
        }


        public List<PendingLot> GetPendingLots(int? locationID)
        {
            return base.TotalSmartCodingEntities.GetPendingLots(locationID).ToList();
        }

        public List<BatchRepack> GetBatchRepacks(int? batchID)
        {
            return base.TotalSmartCodingEntities.GetBatchRepacks(batchID).ToList();
        }        

        public List<BatchAvailable> GetBatchAvailables(int? locationID, int? deliveryAdviceID, int? transferOrderID, int? commodityID, bool withNullRow)
        {
            List<BatchAvailable> batchAvailables = base.TotalSmartCodingEntities.GetBatchAvailables(locationID, deliveryAdviceID, transferOrderID, commodityID).ToList();
            if (withNullRow) batchAvailables.Add(new BatchAvailable() { QuantityAvailable = 0, LineVolumeAvailable = 0 });
            return batchAvailables;
        }

    }


}
