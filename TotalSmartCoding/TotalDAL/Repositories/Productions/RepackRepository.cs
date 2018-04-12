using System.Linq;
using System.Collections.Generic;

using TotalBase;
using TotalModel.Models;
using TotalCore.Repositories.Productions;

namespace TotalDAL.Repositories.Productions
{
    public class RepackRepository : GenericRepository<Repack>, IRepackRepository
    {
        public RepackRepository(TotalSmartCodingEntities totalSmartCodingEntities)
            : base(totalSmartCodingEntities)
        {
        }

        public IList<LookupPack> LookupPacks(string barcode)
        {
            return this.TotalSmartCodingEntities.LookupPacks(barcode).ToList();
        }
    }
}
