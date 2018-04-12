using System.Collections.Generic;

using TotalBase;
using TotalModel.Models;

namespace TotalCore.Repositories.Productions
{
    public interface IRepackRepository : IGenericRepository<Repack>
    {
        IList<LookupPack> LookupPacks(string barcode);
    }
}
