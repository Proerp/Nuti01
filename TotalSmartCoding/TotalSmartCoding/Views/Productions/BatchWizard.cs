﻿using System;
using System.Drawing;
using System.Windows.Forms;

using TotalModel.Models;
using TotalSmartCoding.Controllers.APIs.Productions;
using TotalSmartCoding.Libraries.Helpers;
using TotalSmartCoding.ViewModels.Productions;

namespace TotalSmartCoding.Views.Productions
{
    public partial class BatchWizard : Form
    {
        private BatchAPIs batchAPIs;
        private BatchViewModel batchViewModel;
        private CustomTabControl customTabBatch;
        public BatchWizard(BatchAPIs batchAPIs, BatchViewModel batchViewModel)
        {
            InitializeComponent();

            this.customTabBatch = new CustomTabControl();

            this.customTabBatch.Font = this.fastPendingLots.Font;
            this.customTabBatch.DisplayStyle = TabStyle.VisualStudio;
            this.customTabBatch.DisplayStyleProvider.ImageAlign = ContentAlignment.MiddleLeft;

            this.customTabBatch.TabPages.Add("tabPendingLots", "Available Batches    ");
            this.customTabBatch.TabPages[0].Controls.Add(this.fastPendingLots);


            this.customTabBatch.Dock = DockStyle.Fill;
            this.fastPendingLots.Dock = DockStyle.Fill;
            this.panelMaster.Controls.Add(this.customTabBatch);


            this.batchAPIs = batchAPIs;
            this.batchViewModel = batchViewModel;
        }


        private void Wizard_Load(object sender, EventArgs e)
        {
            try
            {
                this.fastPendingLots.SetObjects(this.batchAPIs.GetPendingLots(this.batchViewModel.LocationID));
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }


        private void buttonOKESC_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(this.buttonOK))
                {
                    PendingLot pendingLot = (PendingLot)this.fastPendingLots.SelectedObject;
                    if (pendingLot != null)
                    {
                        this.batchViewModel.LotID = pendingLot.LotID;
                        this.batchViewModel.Code = pendingLot.Code;
                        this.batchViewModel.LotCode = pendingLot.LotCode;
                        this.batchViewModel.EntryDate = pendingLot.EntryDate;

                        this.batchViewModel.BatchMasterID = pendingLot.BatchMasterID;
                        this.batchViewModel.BatchTypeID = 1; // INIT DEFAULT pendingLot.BatchTypeID;
                        this.batchViewModel.CommodityID = pendingLot.CommodityID;
                        this.batchViewModel.CommodityCode = pendingLot.CommodityCode;
                        this.batchViewModel.CommodityName = pendingLot.CommodityName;
                        this.batchViewModel.CommodityAPICode = pendingLot.CommodityAPICode;
                        this.batchViewModel.CommodityCartonCode = pendingLot.CommodityCartonCode;

                        this.batchViewModel.Volume = pendingLot.Volume;
                        this.batchViewModel.PlannedQuantity = pendingLot.PlannedQuantity;
                        this.batchViewModel.BatchStatusCode = pendingLot.BatchStatusCode;
                        this.batchViewModel.Remarks = pendingLot.Remarks;

                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        CustomMsgBox.Show(this, "Vui lòng chọn phiếu giao thành phẩm sau đóng gói, hoặc kho nhận hàng.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                }

                if (sender.Equals(this.buttonESC))
                    this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }
    }
}
