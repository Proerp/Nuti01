using System.Collections.Generic;
using System.Data;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalCore.Repositories.Generals
{
    public interface IOleDbAPIRepository : IGenericAPIRepository
    {
        GlobalEnums.MappingTaskID MappingTaskID { get; set; }

        DataTable OpenExcelSheet(string excelFile, string querySelect);

        IList<ColumnMapping> GetColumnMappings();
        void SaveColumnMapping(int columnMappingID, string columnMappingName);
    }
}
