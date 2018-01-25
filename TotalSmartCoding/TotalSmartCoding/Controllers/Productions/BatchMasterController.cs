using TotalModel.Models;
using TotalDTO.Productions;

using TotalCore.Services.Productions;
using TotalSmartCoding.ViewModels.Productions;

namespace TotalSmartCoding.Controllers.Productions
{
    public class BatchMasterController : GenericSimpleController<BatchMaster, BatchMasterDTO, BatchMasterPrimitiveDTO, BatchMasterViewModel>
    {
        IBatchMasterService batchMasterService;
        public BatchMasterController(IBatchMasterService batchMasterService, BatchMasterViewModel batchMasterViewModel)
            : base(batchMasterService, batchMasterViewModel)
        {
            this.batchMasterService = batchMasterService;
        }

        public bool AddLot(int batchMasterID)
        {
            return this.batchMasterService.AddLot(batchMasterID);
        }
    }
}

