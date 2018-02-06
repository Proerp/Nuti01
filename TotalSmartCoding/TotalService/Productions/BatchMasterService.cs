using System;

using TotalModel.Models;
using TotalDTO.Productions;
using TotalCore.Repositories.Productions;
using TotalCore.Services.Productions;

namespace TotalService.Productions
{
    public class BatchMasterService : GenericService<BatchMaster, BatchMasterDTO, BatchMasterPrimitiveDTO>, IBatchMasterService
    {
        private IBatchMasterRepository batchMasterRepository;
        public BatchMasterService(IBatchMasterRepository batchMasterRepository)
            : base(batchMasterRepository, "BatchMasterPostSaveValidate", null, "BatchMasterToggleApproved", "BatchMasterToggleVoid")
        {
            this.batchMasterRepository = batchMasterRepository;
        }

        public bool AddLot(int batchMasterID)
        {
            this.batchMasterRepository.AddLot(batchMasterID);
            return true;
        }

        public bool RemoveLot(int lotID)
        {
            this.batchMasterRepository.RemoveLot(lotID);
            return true;
        }

    }
}
