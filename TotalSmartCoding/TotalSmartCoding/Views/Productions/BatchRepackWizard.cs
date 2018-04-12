using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using BrightIdeasSoftware;

using Ninject;

using TotalModel.Models;
using TotalCore.Repositories.Inventories;
using TotalDTO.Inventories;
using TotalSmartCoding.Libraries;
using TotalSmartCoding.Controllers.APIs.Inventories;
using TotalSmartCoding.Libraries.Helpers;
using TotalSmartCoding.ViewModels.Inventories;
using TotalBase;
using System.Collections;
using TotalBase.Enums;
using TotalDTO.Productions;
using AutoMapper;
using TotalSmartCoding.ViewModels.Productions;
using TotalSmartCoding.Controllers.Productions;
using TotalCore.Services.Productions;


namespace TotalSmartCoding.Views.Productions
{
    public partial class BatchRepackWizard : Form
    {
        private CustomTabControl customTabBatch;
        public virtual ToolStrip toolstripChild { get; protected set; }

        private string fileName;

        private FillingData fillingData;
        private RepackViewModel repackViewModel;
        private RepackController repackController;

        /// <summary>
        /// GoodsIssueViewModel goodsIssueViewModel: CURRENT DETAILS OF GOODSISSUE
        /// List<IPendingPrimaryDetail> pendingPrimaryDetails: COLLECTION OF PENDING ITEMS REQUESTED FOR DELIVERY (HERE WE USE IPendingPrimaryDetail FOR TWO CASE: PendingDeliveryAdviceDetail AND PendingTransferOrderDetail WHICH ARE IMPLEMENTED interface IPendingPrimaryDetail
        /// IPendingPrimaryDetail pendingPrimaryDetail: CURRENT SELECTED PENDING ITEM (CURRENT SELECTED OF PendingDeliveryAdviceDetail OR PendingTransferOrderDetail). THIS PARAMETER IS REQUIRED BY TABLET MODE: MEANS: WHEN USING BY THE FORFLIFT DRIVER TO MANUAL SELECT BY BARCODE OR BIN LOCATION
        /// string fileName: WHEN IMPORTED FORM TEXT FILE
        /// </summary>
        /// <param name="goodsIssueViewModel"></param>
        /// <param name="pendingPrimaryDetails"></param>
        /// <param name="pendingPrimaryDetail"></param>
        /// <param name="fileName"></param>
        public BatchRepackWizard(FillingData fillingData, string fileName)
        {
            InitializeComponent();

            this.toolstripChild = this.toolStripBottom;
            this.customTabBatch = new CustomTabControl();

            this.customTabBatch.Font = this.fastAvailablePallets.Font;
            this.customTabBatch.DisplayStyle = TabStyle.VisualStudio;
            this.customTabBatch.DisplayStyleProvider.ImageAlign = ContentAlignment.MiddleLeft;

            this.customTabBatch.TabPages.Add("tabAvailablePallets", "Available pallets");
            this.customTabBatch.TabPages[0].Controls.Add(this.fastAvailablePallets);


            this.customTabBatch.Dock = DockStyle.Fill;
            this.fastAvailablePallets.Dock = DockStyle.Fill;
            this.panelMaster.Controls.Add(this.customTabBatch);

            if (GlobalVariables.ConfigID == (int)GlobalVariables.FillingLine.GoodsIssue) ViewHelpers.SetFont(this, new Font("Calibri", 11), new Font("Calibri", 11), new Font("Calibri", 11));


            this.fillingData = fillingData;
            this.repackViewModel = CommonNinject.Kernel.Get<RepackViewModel>();
            this.repackController = new RepackController(CommonNinject.Kernel.Get<IRepackService>(), this.repackViewModel);
            this.fileName = fileName;


            this.toolStripBottom.Visible = true;
            this.fastMismatchedBarcodes.Visible = true;
            this.customTabBatch.TabPages.Add("tabMismatchedBarcodes", "Mismatched Barcodes");
            this.customTabBatch.TabPages[this.customTabBatch.TabPages.Count - 1].Controls.Add(this.fastMismatchedBarcodes);
            this.fastMismatchedBarcodes.Dock = DockStyle.Fill;
        }

        private void BatchRepackWizard_Load(object sender, EventArgs e)
        {
            try
            {
                List<BatchRepackDTO> batchRepacks = new List<BatchRepackDTO>();
                List<MismatchedBarcode> mismatchedBarcodes = new List<MismatchedBarcode>();

                string[] barcodes = System.IO.File.ReadAllLines(fileName);
                if (barcodes.Count() > 0)
                {
                    foreach (string barcode in barcodes)
                    {
                        IList<LookupPack> lookupPacks = this.repackController.repackService.LookupPacks(barcode);
                        if (lookupPacks != null && lookupPacks.Count > 0)
                        {
                            LookupPack lookupPack = lookupPacks.Where(w => w.CommodityID == this.fillingData.CommodityID).First();
                            if (lookupPack != null)
                            {
                                BatchRepackDTO batchRepackDTO = Mapper.Map<LookupPack, BatchRepackDTO>(lookupPack);
                                batchRepacks.Add(batchRepackDTO);
                            }
                            else
                                mismatchedBarcodes.Add(new MismatchedBarcode() { Barcode = barcode + " [" + lookupPacks.First().APICode + "] " + lookupPacks.First().CommodityName, Description = "Không cùng mã sản phẩm." });
                        }
                        else
                            mismatchedBarcodes.Add(new MismatchedBarcode() { Barcode = barcode, Description = "Không tìm thấy mã vạch." });
                    }
                }

                this.fastAvailablePallets.SetObjects(batchRepacks);
                if (this.fileName != null) this.fastMismatchedBarcodes.SetObjects(mismatchedBarcodes);

                this.customTabBatch.TabPages[0].Text = "Available " + this.fastAvailablePallets.GetItemCount().ToString("N0") + " pallet" + (this.fastAvailablePallets.GetItemCount() > 1 ? "s      " : "      ");
                this.customTabBatch.TabPages[this.customTabBatch.TabPages.Count - 1].Text = this.fastMismatchedBarcodes.GetItemCount().ToString("N0") + " Mismatched Barcode" + (this.fastMismatchedBarcodes.GetItemCount() > 1 ? "s      " : "      ");
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }



        private void buttonAddESC_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (sender.Equals(this.buttonAddExit))
            //    {
            //        FastObjectListView fastAvailableGoodsReceiptDetails = this.fastAvailablePallets;

            //        if (fastAvailableGoodsReceiptDetails != null)
            //        {
            //            if (fastAvailableGoodsReceiptDetails.CheckedObjects.Count > 0)
            //            {
            //                this.goodsIssueViewModel.ViewDetails.RaiseListChangedEvents = false;
            //                foreach (var checkedObjects in fastAvailableGoodsReceiptDetails.CheckedObjects)
            //                {
            //                    GoodsReceiptDetailAvailable goodsReceiptDetailAvailable = (GoodsReceiptDetailAvailable)checkedObjects;
            //                    GoodsIssueDetailDTO goodsIssueDetailDTO = new GoodsIssueDetailDTO()
            //                    {
            //                        GoodsIssueID = this.goodsIssueViewModel.GoodsIssueID,

            //                        DeliveryAdviceID = goodsReceiptDetailAvailable.DeliveryAdviceID > 0 ? goodsReceiptDetailAvailable.DeliveryAdviceID : (int?)null,
            //                        DeliveryAdviceDetailID = goodsReceiptDetailAvailable.DeliveryAdviceDetailID > 0 ? goodsReceiptDetailAvailable.DeliveryAdviceDetailID : (int?)null,
            //                        DeliveryAdviceReference = goodsReceiptDetailAvailable.PrimaryReference,
            //                        DeliveryAdviceEntryDate = goodsReceiptDetailAvailable.PrimaryEntryDate,

            //                        TransferOrderID = goodsReceiptDetailAvailable.TransferOrderID > 0 ? goodsReceiptDetailAvailable.TransferOrderID : (int?)null,
            //                        TransferOrderDetailID = goodsReceiptDetailAvailable.TransferOrderDetailID > 0 ? goodsReceiptDetailAvailable.TransferOrderDetailID : (int?)null,
            //                        TransferOrderReference = goodsReceiptDetailAvailable.PrimaryReference,
            //                        TransferOrderEntryDate = goodsReceiptDetailAvailable.PrimaryEntryDate,

            //                        CommodityID = goodsReceiptDetailAvailable.CommodityID,
            //                        CommodityCode = goodsReceiptDetailAvailable.CommodityCode,
            //                        CommodityName = goodsReceiptDetailAvailable.CommodityName,

            //                        PackageSize = goodsReceiptDetailAvailable.PackageSize,

            //                        Volume = goodsReceiptDetailAvailable.Volume,
            //                        PackageVolume = goodsReceiptDetailAvailable.PackageVolume,

            //                        GoodsReceiptID = goodsReceiptDetailAvailable.GoodsReceiptID,
            //                        GoodsReceiptDetailID = goodsReceiptDetailAvailable.GoodsReceiptDetailID,

            //                        GoodsReceiptReference = goodsReceiptDetailAvailable.GoodsReceiptReference,
            //                        GoodsReceiptEntryDate = goodsReceiptDetailAvailable.GoodsReceiptEntryDate,

            //                        BatchID = goodsReceiptDetailAvailable.BatchID,
            //                        BatchEntryDate = goodsReceiptDetailAvailable.BatchEntryDate,

            //                        BinLocationID = goodsReceiptDetailAvailable.BinLocationID,
            //                        BinLocationCode = goodsReceiptDetailAvailable.BinLocationCode,

            //                        WarehouseID = goodsReceiptDetailAvailable.WarehouseID,
            //                        WarehouseCode = goodsReceiptDetailAvailable.WarehouseCode,

            //                        PackID = goodsReceiptDetailAvailable.PackID,
            //                        PackCode = goodsReceiptDetailAvailable.PackCode,
            //                        CartonID = goodsReceiptDetailAvailable.CartonID,
            //                        CartonCode = goodsReceiptDetailAvailable.CartonCode,
            //                        PalletID = goodsReceiptDetailAvailable.PalletID,
            //                        PalletCode = goodsReceiptDetailAvailable.PalletCode,

            //                        PackCounts = goodsReceiptDetailAvailable.PackCounts,
            //                        CartonCounts = goodsReceiptDetailAvailable.CartonCounts,
            //                        PalletCounts = goodsReceiptDetailAvailable.PalletCounts,

            //                        QuantityAvailable = (decimal)goodsReceiptDetailAvailable.QuantityAvailable,
            //                        LineVolumeAvailable = (decimal)goodsReceiptDetailAvailable.LineVolumeAvailable,

            //                        QuantityRemains = goodsReceiptDetailAvailable.QuantityRemains,
            //                        LineVolumeRemains = goodsReceiptDetailAvailable.LineVolumeRemains,

            //                        Quantity = (decimal)goodsReceiptDetailAvailable.QuantityAvailable, //SHOULD: Quantity = QuantityAvailable (ALSO: LineVolume = LineVolumeAvailable): BECAUSE: WE ISSUE BY WHOLE UNIT OF PALLET/ OR CARTON/ OR PACK
            //                        LineVolume = (decimal)goodsReceiptDetailAvailable.LineVolumeAvailable //IF Quantity > QuantityRemains (OR LineVolume > LineVolumeRemains) => THE GoodsIssueDetailDTO WILL BREAK THE ValidationRule => CAN NOT SAVE => USER MUST SELECT OTHER APPROPRIATE UNIT OF PALLET/ OR CARTON/ OR PACK WHICH MATCH THE Quantity/ LineVolume                                
            //                    };
            //                    this.goodsIssueViewModel.ViewDetails.Insert(0, goodsIssueDetailDTO);
            //                }
            //            }
            //        }

            //        if (this.MdiParent != null) this.MdiParent.DialogResult = DialogResult.OK; else this.DialogResult = DialogResult.OK;
            //    }

            //    if (sender.Equals(this.buttonESC))
            //        if (this.MdiParent != null) this.MdiParent.DialogResult = DialogResult.Cancel; else this.DialogResult = DialogResult.Cancel;

            //}
            //catch (Exception exception)
            //{
            //    ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            //}
            //finally
            //{
            //    if (!this.goodsIssueViewModel.ViewDetails.RaiseListChangedEvents)
            //    {
            //        this.goodsIssueViewModel.ViewDetails.RaiseListChangedEvents = true;
            //        this.goodsIssueViewModel.ViewDetails.ResetBindings();
            //    }
            //}
        }

    }

    public class MismatchedBarcode
    {
        public string Barcode { get; set; }
        public string Description { get; set; }
    }
}
