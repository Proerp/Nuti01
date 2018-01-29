using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Ninject;

using TotalBase.Enums;
using TotalDTO.Generals;
using TotalCore.Repositories.Generals;
using TotalSmartCoding.Libraries;
using TotalSmartCoding.Libraries.Helpers;
using TotalSmartCoding.Controllers.APIs.Generals;


namespace TotalSmartCoding.Views.Mains
{
    public partial class MapExcelColumn : Form
    {
        private string excelFile;
        private GlobalEnums.MappingTaskID mappingTaskID;

        private OleDbAPIs oleDbAPIs { get; set; }

        BindingList<ColumnAvailableDTO> ColumnAvailableDTOs;
        BindingList<ColumnMappingDTO> ColumnMappingDTOs;

        public MapExcelColumn(GlobalEnums.MappingTaskID mappingTaskID, string excelFile)
        {
            InitializeComponent();
            try
            {
                this.oleDbAPIs = new OleDbAPIs(CommonNinject.Kernel.Get<IOleDbAPIRepository>(), mappingTaskID);

                this.excelFile = excelFile;
                this.mappingTaskID = mappingTaskID;

                //StackedHeaderDecorator stackedHeaderDecoratorAvailable = new StackedHeaderDecorator(this.dataGridColumnAvailable);
                //StackedHeaderDecorator stackedHeaderDecoratorMapping = new StackedHeaderDecorator(this.dataGridColumnMapping);
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void DialogMapExcelColumn_Load(object sender, EventArgs e)
        {
            try
            {
                this.ColumnAvailableDTOs = new BindingList<ColumnAvailableDTO>();

                DataTable excelDataTable = this.oleDbAPIs.OpenExcelSheet(this.excelFile, "*");
                if (excelDataTable != null && excelDataTable.Columns.Count > 0)
                {//Get available column from current file
                    foreach (DataColumn dataColumn in excelDataTable.Columns)
                    {
                        this.ColumnAvailableDTOs.Add(new ColumnAvailableDTO() { ColumnAvailableName = dataColumn.ColumnName });
                    }
                }


                ColumnMappingDTOs = this.oleDbAPIs.GetColumnMappings();//Get required column (and saved mapping data)

                foreach (ColumnMappingDTO columnMappingDTO in this.ColumnMappingDTOs)
                    if (columnMappingDTO.ColumnMappingName != "")
                    {//Remove un-matching from current file to saved mapping data before continue
                        ColumnAvailableDTO columnAvailableDTO = this.ColumnAvailableDTOs.Where(w => w.ColumnAvailableName == columnMappingDTO.ColumnMappingName).FirstOrDefault();
                        if (columnAvailableDTO != null)
                            columnAvailableDTO.ColumnMappingName = columnMappingDTO.ColumnDisplayName;
                        else
                            columnMappingDTO.ColumnMappingName = "";
                    }


                this.dataGridColumnAvailable.AutoGenerateColumns = false;
                this.dataGridColumnMapping.AutoGenerateColumns = false;
                this.dataGridColumnAvailable.DataSource = this.ColumnAvailableDTOs;
                this.dataGridColumnMapping.DataSource = this.ColumnMappingDTOs;
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void MappingColumn(object sender, EventArgs e)
        {
            try
            {
                bool doMapping = sender.Equals(this.buttonMapColumn) ? true : false;

                if (this.dataGridColumnMapping.CurrentRow != null)
                {
                    ColumnMappingDTO columnMappingDTO = this.dataGridColumnMapping.CurrentRow.DataBoundItem as ColumnMappingDTO;
                    if (columnMappingDTO != null)//Check for a valid selected row
                    {
                        ColumnAvailableDTO columnAvailableDTO = null;
                        if (doMapping)
                        {
                            if (this.dataGridColumnAvailable.CurrentRow == null) return;
                            columnAvailableDTO = this.dataGridColumnAvailable.CurrentRow.DataBoundItem as ColumnAvailableDTO;
                            if (columnAvailableDTO == null) return; //Check for a valid selected row

                            List<ColumnMappingDTO> foundColumnMappingDTOs = this.ColumnMappingDTOs.Where(w => w.ColumnMappingName == columnAvailableDTO.ColumnAvailableName).ToList();
                            foreach (ColumnMappingDTO foundColumnMappingDTO in foundColumnMappingDTOs) //Clear current mapping foundColumnMappingDTOs
                                foundColumnMappingDTO.ColumnMappingName = "";
                        }

                        List<ColumnAvailableDTO> foundColumnAvailableDTOs = this.ColumnAvailableDTOs.Where(w => w.ColumnMappingName == columnMappingDTO.ColumnDisplayName).ToList();
                        foreach (ColumnAvailableDTO foundColumnAvailableDTO in foundColumnAvailableDTOs)//Clear current mapping foundColumnAvailableDTOs
                            foundColumnAvailableDTO.ColumnMappingName = "";

                        if (doMapping)
                        {//Make a collumn mapping: columnMappingDTO => columnAvailableDTO
                            columnMappingDTO.ColumnMappingName = columnAvailableDTO.ColumnAvailableName;
                            columnAvailableDTO.ColumnMappingName = columnMappingDTO.ColumnDisplayName;
                        }
                        else//Clear current mapping columnMappingDTO
                            columnMappingDTO.ColumnMappingName = "";
                    }
                }
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void NextCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(this.toolStripButtonNext))
                {
                    if (this.ColumnMappingDTOs.Where(w => w.ColumnMappingName == "").FirstOrDefault() != null) throw new System.ArgumentException("All required columns must be mapped in order to continue.");

                    foreach (ColumnMappingDTO columnMappingDTO in this.ColumnMappingDTOs)
                    {
                        this.oleDbAPIs.SaveColumnMapping(columnMappingDTO.ColumnMappingID, columnMappingDTO.ColumnMappingName);
                    }
                }
                this.DialogResult = sender.Equals(this.toolStripButtonNext) ? DialogResult.OK : DialogResult.Cancel;
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }
    }
}
