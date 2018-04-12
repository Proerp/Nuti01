using System.Text;

using TotalBase;
using TotalModel.Models;
using TotalDTO.Productions;
using TotalCore.Repositories.Productions;
using TotalCore.Services.Productions;
using System;
using System.Collections.Generic;

namespace TotalService.Productions
{
    public class RepackService : GenericService<Repack, RepackDTO, RepackPrimitiveDTO>, IRepackService
    {
        private IRepackRepository repackRepository;
        public RepackService(IRepackRepository repackRepository)
            : base(repackRepository, "RepackPostSaveValidate")
        {
            this.repackRepository = repackRepository;
        }

        public IList<LookupPack> LookupPacks(string barcode)
        {
            return this.repackRepository.LookupPacks(barcode);
        }



        protected override bool TryValidateModel(RepackDTO dto, ref StringBuilder invalidMessage)
        {
            if (!base.TryValidateModel(dto, ref invalidMessage)) return false;
            // cần phải ktra DTO here in order to save: có nên kết hợp IsValid của DTO để ktra ngay trong GenericService cho tất cả DTO object??? if (dto.EntryDate < new DateTime(2015, 7, 1) || dto.EntryDate > DateTime.Today.AddDays(2)) invalidMessage.Append(" Ngày không hợp lệ;");
            return true;
        }
    }
}
