using System.Collections.Generic;

using TotalModel.Models;

namespace TotalCore.Repositories.Commons
{
    public interface IBatchStatusRepository
    {

    }

    public interface IBatchStatusAPIRepository : IGenericAPIRepository
    {
        IList<BatchStatusBase> GetBatchStatusBases();
    }
}
