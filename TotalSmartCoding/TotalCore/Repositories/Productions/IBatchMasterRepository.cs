using System.Collections.Generic;

using TotalBase;
using TotalModel.Models;

namespace TotalCore.Repositories.Productions
{
    public interface IBatchMasterRepository : IGenericRepository<BatchMaster>
    {
        void AddLot(int batchMasterID);
    }

    public interface IBatchMasterAPIRepository : IGenericAPIRepository
    {
        IList<BatchMasterBase> GetBatchMasterBases();
    }
}
