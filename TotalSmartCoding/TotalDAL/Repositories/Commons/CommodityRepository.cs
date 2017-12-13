﻿using System.Linq;
using System.Collections.Generic;

using TotalModel.Models;
using TotalCore.Repositories.Commons;


namespace TotalDAL.Repositories.Commons
{
    public class CommodityRepository : GenericRepository<Commodity>, ICommodityRepository
    {
        public CommodityRepository(TotalSmartCodingEntities totalSmartCodingEntities)
            : base(totalSmartCodingEntities, "CommodityEditable")
        {
        }
    }





    public class CommodityAPIRepository : GenericAPIRepository, ICommodityAPIRepository
    {
        public CommodityAPIRepository(TotalSmartCodingEntities totalSmartCodingEntities)
            : base(totalSmartCodingEntities, "GetCommodityIndexes")
        {
        }

        public IList<CommodityBase> GetCommodityBases(bool withNullRow)
        {
            IList<CommodityBase> commodityBases = this.TotalSmartCodingEntities.GetCommodityBases().ToList();
            if (withNullRow) commodityBases.Add(new CommodityBase() { CommodityID = 0 });
            return commodityBases;
        }

        public IList<SearchCommodity> SearchCommodities(int? commodityID, int? locationID, int? batchID, int? deliveryAdviceID, int? transferOrderID)
        {
            return this.TotalSmartCodingEntities.SearchCommodities(commodityID, locationID, batchID, deliveryAdviceID, transferOrderID).ToList();
        }
    }
}
