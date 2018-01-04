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
            : base(batchMasterRepository, "BatchMasterPostSaveValidate", null, null, "BatchMasterToggleVoid")
        {
            this.batchMasterRepository = batchMasterRepository;
        }
    }
}
