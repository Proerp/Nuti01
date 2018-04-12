namespace TotalSmartCoding.Views.Productions
{
    partial class BatchRepackWizard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStripBottom = new System.Windows.Forms.ToolStrip();
            this.buttonESC = new System.Windows.Forms.ToolStripButton();
            this.buttonAddExit = new System.Windows.Forms.ToolStripButton();
            this.fastAvailablePallets = new BrightIdeasSoftware.FastObjectListView();
            this.olvIsSelected = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCommodityCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvBinLocationCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvBatchEntryDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvPallet = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvPalletLineVolumeAvailable = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvPalletCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panelMaster = new System.Windows.Forms.Panel();
            this.fastMismatchedBarcodes = new BrightIdeasSoftware.FastObjectListView();
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvScannedBarcode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvBarcodeQuantityAvailable = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvBarcodeLineVolumeAvailable = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvDescription = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStripBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastAvailablePallets)).BeginInit();
            this.panelMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastMismatchedBarcodes)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripBottom
            // 
            this.toolStripBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripBottom.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripBottom.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonESC,
            this.buttonAddExit});
            this.toolStripBottom.Location = new System.Drawing.Point(0, 498);
            this.toolStripBottom.Name = "toolStripBottom";
            this.toolStripBottom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStripBottom.Size = new System.Drawing.Size(1082, 55);
            this.toolStripBottom.TabIndex = 0;
            this.toolStripBottom.Text = "toolStrip1";
            this.toolStripBottom.Visible = false;
            // 
            // buttonESC
            // 
            this.buttonESC.Image = global::TotalSmartCoding.Properties.Resources.signout_icon_24;
            this.buttonESC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonESC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonESC.Name = "buttonESC";
            this.buttonESC.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonESC.Size = new System.Drawing.Size(73, 52);
            this.buttonESC.Text = "Close";
            this.buttonESC.Click += new System.EventHandler(this.buttonAddESC_Click);
            // 
            // buttonAddExit
            // 
            this.buttonAddExit.Image = global::TotalSmartCoding.Properties.Resources.Add_continue;
            this.buttonAddExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonAddExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAddExit.Name = "buttonAddExit";
            this.buttonAddExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonAddExit.Size = new System.Drawing.Size(158, 52);
            this.buttonAddExit.Text = "Add and Close";
            this.buttonAddExit.Click += new System.EventHandler(this.buttonAddESC_Click);
            // 
            // fastAvailablePallets
            // 
            this.fastAvailablePallets.AllColumns.Add(this.olvIsSelected);
            this.fastAvailablePallets.AllColumns.Add(this.olvCommodityCode);
            this.fastAvailablePallets.AllColumns.Add(this.olvBinLocationCode);
            this.fastAvailablePallets.AllColumns.Add(this.olvBatchEntryDate);
            this.fastAvailablePallets.AllColumns.Add(this.olvPallet);
            this.fastAvailablePallets.AllColumns.Add(this.olvPalletLineVolumeAvailable);
            this.fastAvailablePallets.AllColumns.Add(this.olvPalletCode);
            this.fastAvailablePallets.CheckBoxes = true;
            this.fastAvailablePallets.CheckedAspectName = "IsSelected";
            this.fastAvailablePallets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvIsSelected,
            this.olvCommodityCode,
            this.olvBinLocationCode,
            this.olvBatchEntryDate,
            this.olvPallet,
            this.olvPalletLineVolumeAvailable,
            this.olvPalletCode});
            this.fastAvailablePallets.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastAvailablePallets.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastAvailablePallets.FullRowSelect = true;
            this.fastAvailablePallets.HideSelection = false;
            this.fastAvailablePallets.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastAvailablePallets.Location = new System.Drawing.Point(0, 303);
            this.fastAvailablePallets.Name = "fastAvailablePallets";
            this.fastAvailablePallets.OwnerDraw = true;
            this.fastAvailablePallets.ShowGroups = false;
            this.fastAvailablePallets.ShowImagesOnSubItems = true;
            this.fastAvailablePallets.Size = new System.Drawing.Size(1147, 122);
            this.fastAvailablePallets.TabIndex = 69;
            this.fastAvailablePallets.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastAvailablePallets.UseCompatibleStateImageBehavior = false;
            this.fastAvailablePallets.UseFiltering = true;
            this.fastAvailablePallets.View = System.Windows.Forms.View.Details;
            this.fastAvailablePallets.VirtualMode = true;
            // 
            // olvIsSelected
            // 
            this.olvIsSelected.HeaderCheckBox = true;
            this.olvIsSelected.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvIsSelected.Text = "";
            this.olvIsSelected.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvIsSelected.Width = 20;
            // 
            // olvCommodityCode
            // 
            this.olvCommodityCode.AspectName = "CommodityCode";
            this.olvCommodityCode.Sortable = false;
            this.olvCommodityCode.Text = "Item";
            this.olvCommodityCode.Width = 86;
            // 
            // olvBinLocationCode
            // 
            this.olvBinLocationCode.AspectName = "BinLocationCode";
            this.olvBinLocationCode.Sortable = false;
            this.olvBinLocationCode.Text = "Location";
            this.olvBinLocationCode.Width = 96;
            // 
            // olvBatchEntryDate
            // 
            this.olvBatchEntryDate.AspectName = "BatchEntryDate";
            this.olvBatchEntryDate.AspectToStringFormat = "{0:d}";
            this.olvBatchEntryDate.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvBatchEntryDate.Sortable = false;
            this.olvBatchEntryDate.Text = "Date";
            this.olvBatchEntryDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvBatchEntryDate.Width = 80;
            // 
            // olvPallet
            // 
            this.olvPallet.AspectName = "QuantityAvailable";
            this.olvPallet.AspectToStringFormat = "{0:#,#}";
            this.olvPallet.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvPallet.Text = "Quantity";
            this.olvPallet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvPallet.Width = 68;
            // 
            // olvPalletLineVolumeAvailable
            // 
            this.olvPalletLineVolumeAvailable.AspectName = "LineVolumeAvailable";
            this.olvPalletLineVolumeAvailable.AspectToStringFormat = "{0:#,##0.00}";
            this.olvPalletLineVolumeAvailable.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvPalletLineVolumeAvailable.Text = "Volume";
            this.olvPalletLineVolumeAvailable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvPalletLineVolumeAvailable.Width = 68;
            // 
            // olvPalletCode
            // 
            this.olvPalletCode.AspectName = "PalletCode";
            this.olvPalletCode.FillsFreeSpace = true;
            this.olvPalletCode.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvPalletCode.Sortable = false;
            this.olvPalletCode.Text = "Pallet Code";
            this.olvPalletCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvPalletCode.Width = 120;
            // 
            // panelMaster
            // 
            this.panelMaster.Controls.Add(this.fastMismatchedBarcodes);
            this.panelMaster.Controls.Add(this.fastAvailablePallets);
            this.panelMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMaster.Location = new System.Drawing.Point(0, 0);
            this.panelMaster.Name = "panelMaster";
            this.panelMaster.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panelMaster.Size = new System.Drawing.Size(1082, 553);
            this.panelMaster.TabIndex = 71;
            // 
            // fastMismatchedBarcodes
            // 
            this.fastMismatchedBarcodes.AllColumns.Add(this.olvColumn5);
            this.fastMismatchedBarcodes.AllColumns.Add(this.olvScannedBarcode);
            this.fastMismatchedBarcodes.AllColumns.Add(this.olvBarcodeQuantityAvailable);
            this.fastMismatchedBarcodes.AllColumns.Add(this.olvBarcodeLineVolumeAvailable);
            this.fastMismatchedBarcodes.AllColumns.Add(this.olvDescription);
            this.fastMismatchedBarcodes.CheckedAspectName = "";
            this.fastMismatchedBarcodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn5,
            this.olvScannedBarcode,
            this.olvBarcodeQuantityAvailable,
            this.olvBarcodeLineVolumeAvailable,
            this.olvDescription});
            this.fastMismatchedBarcodes.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastMismatchedBarcodes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastMismatchedBarcodes.FullRowSelect = true;
            this.fastMismatchedBarcodes.HideSelection = false;
            this.fastMismatchedBarcodes.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastMismatchedBarcodes.Location = new System.Drawing.Point(-3, 427);
            this.fastMismatchedBarcodes.Name = "fastMismatchedBarcodes";
            this.fastMismatchedBarcodes.OwnerDraw = true;
            this.fastMismatchedBarcodes.ShowGroups = false;
            this.fastMismatchedBarcodes.ShowImagesOnSubItems = true;
            this.fastMismatchedBarcodes.Size = new System.Drawing.Size(1147, 126);
            this.fastMismatchedBarcodes.TabIndex = 72;
            this.fastMismatchedBarcodes.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastMismatchedBarcodes.UseCompatibleStateImageBehavior = false;
            this.fastMismatchedBarcodes.UseFiltering = true;
            this.fastMismatchedBarcodes.View = System.Windows.Forms.View.Details;
            this.fastMismatchedBarcodes.VirtualMode = true;
            this.fastMismatchedBarcodes.Visible = false;
            // 
            // olvColumn5
            // 
            this.olvColumn5.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn5.Text = "";
            this.olvColumn5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn5.Width = 20;
            // 
            // olvScannedBarcode
            // 
            this.olvScannedBarcode.AspectName = "Barcode";
            this.olvScannedBarcode.FillsFreeSpace = true;
            this.olvScannedBarcode.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvScannedBarcode.Sortable = false;
            this.olvScannedBarcode.Text = "Barcode";
            this.olvScannedBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvScannedBarcode.Width = 168;
            // 
            // olvBarcodeQuantityAvailable
            // 
            this.olvBarcodeQuantityAvailable.AspectName = "QuantityAvailable";
            this.olvBarcodeQuantityAvailable.AspectToStringFormat = "{0:#,#}";
            this.olvBarcodeQuantityAvailable.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvBarcodeQuantityAvailable.Text = "Quantity";
            this.olvBarcodeQuantityAvailable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvBarcodeQuantityAvailable.Width = 68;
            // 
            // olvBarcodeLineVolumeAvailable
            // 
            this.olvBarcodeLineVolumeAvailable.AspectName = "LineVolumeAvailable";
            this.olvBarcodeLineVolumeAvailable.AspectToStringFormat = "{0:#,##0.00}";
            this.olvBarcodeLineVolumeAvailable.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvBarcodeLineVolumeAvailable.Text = "Volume";
            this.olvBarcodeLineVolumeAvailable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvBarcodeLineVolumeAvailable.Width = 68;
            // 
            // olvDescription
            // 
            this.olvDescription.AspectName = "Description";
            this.olvDescription.FillsFreeSpace = true;
            this.olvDescription.Text = "Description";
            // 
            // BatchRepackWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 553);
            this.Controls.Add(this.panelMaster);
            this.Controls.Add(this.toolStripBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BatchRepackWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select pallet or carton to issue";
            this.Load += new System.EventHandler(this.BatchRepackWizard_Load);
            this.toolStripBottom.ResumeLayout(false);
            this.toolStripBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastAvailablePallets)).EndInit();
            this.panelMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastMismatchedBarcodes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripBottom;
        private System.Windows.Forms.ToolStripButton buttonESC;
        private System.Windows.Forms.ToolStripButton buttonAddExit;
        private BrightIdeasSoftware.FastObjectListView fastAvailablePallets;
        private System.Windows.Forms.Panel panelMaster;
        private BrightIdeasSoftware.OLVColumn olvCommodityCode;
        private BrightIdeasSoftware.OLVColumn olvPalletCode;
        private BrightIdeasSoftware.OLVColumn olvIsSelected;
        private BrightIdeasSoftware.OLVColumn olvBinLocationCode;
        private BrightIdeasSoftware.OLVColumn olvBatchEntryDate;
        private BrightIdeasSoftware.FastObjectListView fastMismatchedBarcodes;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
        private BrightIdeasSoftware.OLVColumn olvScannedBarcode;
        private BrightIdeasSoftware.OLVColumn olvDescription;
        private BrightIdeasSoftware.OLVColumn olvBarcodeQuantityAvailable;
        private BrightIdeasSoftware.OLVColumn olvBarcodeLineVolumeAvailable;
        private BrightIdeasSoftware.OLVColumn olvPallet;
        private BrightIdeasSoftware.OLVColumn olvPalletLineVolumeAvailable;
    }
}