using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;


using TotalBase.Enums;
using TotalModel.Models;

using TotalDTO.Inventories;

using TotalCore.Repositories.Generals;
using TotalBase;
using System.Data;
using TotalDTO.Generals;
using AutoMapper;
using System.ComponentModel;

namespace TotalSmartCoding.Controllers.APIs.Generals
{
    public class OleDbAPIs
    {
        private readonly IOleDbAPIRepository oleDbAPIRepository;

        public OleDbAPIs(IOleDbAPIRepository oleDbAPIRepository, GlobalEnums.MappingTaskID mappingTaskID)
        {
            this.oleDbAPIRepository = oleDbAPIRepository;
            this.oleDbAPIRepository.MappingTaskID = mappingTaskID;
        }

        public BindingList<ColumnMappingDTO> GetColumnMappings()
        {
            return Mapper.Map<IList<ColumnMapping>, BindingList<ColumnMappingDTO>>(this.oleDbAPIRepository.GetColumnMappings().ToList());
        }

        public void SaveColumnMapping(int columnMappingID, string columnMappingName)
        {
            this.oleDbAPIRepository.SaveColumnMapping(columnMappingID, columnMappingName);
        }

        public DataTable OpenExcelSheet(string excelFile, string querySelect)
        {
            return this.oleDbAPIRepository.OpenExcelSheet(excelFile, querySelect);
        }

    }
}