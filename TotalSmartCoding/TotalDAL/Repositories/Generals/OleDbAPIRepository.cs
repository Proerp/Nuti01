﻿using System;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;

using TotalBase.Enums;
using TotalModel.Models;
using TotalCore.Repositories.Generals;

namespace TotalDAL.Repositories.Generals
{
    public class OleDbAPIRepository : GenericAPIRepository, IOleDbAPIRepository
    {
        public GlobalEnums.MappingTaskID MappingTaskID { get; set; }
        public OleDbAPIRepository(TotalSmartCodingEntities totalSmartCodingEntities)
            : base(totalSmartCodingEntities, "GetUserIndexes")
        {
        }

        public IList<ColumnMapping> GetColumnMappings()
        {
            return this.TotalSmartCodingEntities.GetColumnMappings((int)this.MappingTaskID).ToList();
        }

        public void SaveColumnMapping(int columnMappingID, string columnMappingName)
        {
            this.TotalSmartCodingEntities.SaveColumnMapping(columnMappingID, columnMappingName);
        }

        private string SheetName()
        {
            switch (this.MappingTaskID)
            {
                case GlobalEnums.MappingTaskID.Commodity:
                    return "commodities"; //A_ImportBatch

                case GlobalEnums.MappingTaskID.Default:
                    return "";
                default:
                    return "";
            }
        }

        public DataTable OpenExcelSheet(string excelFile, string querySelect)
        {
            return this.OpenExcelSheet(excelFile, querySelect, "", "");
        }

        public DataTable OpenExcelSheet(string excelFile, string querySelect, string queryWhere, string queryOrderBy)
        {
            try
            {
                //using (TransactionScope suppressScope = new TransactionScope(TransactionScopeOption.Suppress)) //Do non-transactional work here
                //{ NOW. AT EF6: TAM THOI KHONG SU DUNG TRANSACTION HERE. LATER, WE WILL USE IT IF NEEDED!
                OleDbConnection excelConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFile + ";Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1'"); //HDR=NO | HDR=YES ---- Header row -- IMEX=1: Treating all data as text (safer way to retrieve data for mixed data columns) //http://www.connectionstrings.com/excel-2007#ace-oledb-12-0
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(" SELECT " + querySelect + " FROM [" + this.SheetName() + "$] " + (queryWhere != "" ? " WHERE " + queryWhere : "") + (queryOrderBy != "" ? " ORDER BY " + queryOrderBy : ""), excelConnection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                return dataTable;
                //}
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public DataTable OpenExcelSheet(string excelFile)
        {
            try
            {
                string querySelect = " 1 AS NoUseField "; string queryOrderBy = "";

                //DataTable ExcelMapTable = SQLDatabase.GetDataTable("SELECT ColumnName, ColumnMappingName, OrderByID FROM ListColumnMapping WHERE GlobalEnums.MappingTaskID = " + (int)this.MappingTaskID + " ORDER BY OrderByID");

                //if (ExcelMapTable.Rows.Count > 0)
                //{
                //    foreach (DataRow dataRow in ExcelMapTable.Rows)
                //    {
                //        querySelect = querySelect + ", " + "[" + dataRow["ColumnMappingName"] + "] AS " + dataRow["ColumnName"];
                //        if ((int)dataRow["OrderByID"] != 0) queryOrderBy = queryOrderBy + (queryOrderBy == "" ? "" : ", ") + dataRow["ColumnName"];
                //    }
                //}

                return this.OpenExcelSheet(excelFile, querySelect, "", queryOrderBy);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}