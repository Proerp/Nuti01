using System.Collections.Generic;

using TotalBase;
using TotalModel.Models;

namespace TotalCore.Repositories.Productions
{
    public interface IBatchRepository : IGenericRepository<Batch>
    {
        void CommonUpdate(int batchID, string nextPackNo, string nextCartonNo, string nextPalletNo);
        void AddLot(int batchID);
    }

    public interface IBatchAPIRepository : IGenericAPIRepository
    {
        List<PendingLot> GetPendingLots(int? locationID);

        List<BatchAvailable> GetBatchAvailables(int? locationID, int? deliveryAdviceID, int? transferOrderID, int? commodityID, bool withNullRow);
    }
}
