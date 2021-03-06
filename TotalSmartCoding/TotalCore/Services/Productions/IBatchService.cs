﻿using TotalBase;
using TotalModel.Models;

using TotalDTO.Productions;

namespace TotalCore.Services.Productions
{
    public interface IBatchService : IGenericService<Batch, BatchDTO, BatchPrimitiveDTO>
    {
        bool CommonUpdate(int batchID, string nextPackNo, string nextCartonNo, string nextPalletNo);
        bool RepackDelete(int batchID);
        bool RepackUpdate(int batchID, int repackID);
        bool RepackReprint(int repackID);
        bool AddLot(int batchID);
    }
}
