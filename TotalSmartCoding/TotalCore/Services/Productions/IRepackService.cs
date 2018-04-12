using System.Collections.Generic;

using TotalBase;
using TotalModel.Models;

using TotalDTO.Productions;

namespace TotalCore.Services.Productions
{
    public interface IRepackService : IGenericService<Repack, RepackDTO, RepackPrimitiveDTO>
    {
        IList<BatchRepack> LookupRepacks(string barcode);

        bool RepackRollback(int batchID, int repackID);
    }
}
