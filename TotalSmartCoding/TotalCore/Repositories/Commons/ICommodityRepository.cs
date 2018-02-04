using System.Collections.Generic;

using TotalModel.Models;

namespace TotalCore.Repositories.Commons
{
    public interface ICommodityRepository : IGenericRepository<Commodity>
    {
    }

    public interface ICommodityAPIRepository : IGenericAPIRepository
    {
        CommodityBase GetCommodityBase(string code);
        CommodityBase GetCommodityBase(int commodityID);
        IList<CommodityBase> GetCommodityBases(bool withNullRow);
        IList<SearchCommodity> SearchCommodities(int? commodityID, int? locationID, int? batchID, int? deliveryAdviceID, int? transferOrderID);
    }
}
