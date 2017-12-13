﻿using System.Collections.Generic;

using TotalBase;
using TotalModel.Models;
using TotalCore.Repositories.Inventories;

namespace TotalSmartCoding.Controllers.APIs.Inventories
{
    public class WarehouseAdjustmentAPIs
    {
        private readonly IWarehouseAdjustmentAPIRepository warehouseAdjustmentAPIRepository;

        public WarehouseAdjustmentAPIs(IWarehouseAdjustmentAPIRepository warehouseAdjustmentAPIRepository)
        {
            this.warehouseAdjustmentAPIRepository = warehouseAdjustmentAPIRepository;
        }


        public ICollection<WarehouseAdjustmentIndex> GetWarehouseAdjustmentIndexes()
        {
            return this.warehouseAdjustmentAPIRepository.GetEntityIndexes<WarehouseAdjustmentIndex>(ContextAttributes.User.UserID, ContextAttributes.FromDate, ContextAttributes.ToDate);
        }
    }
}
