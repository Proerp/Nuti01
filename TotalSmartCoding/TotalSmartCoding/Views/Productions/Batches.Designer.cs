﻿namespace TotalSmartCoding.Views.Productions
{
    partial class Batches
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Batches));
            this.layoutMaster = new System.Windows.Forms.TableLayoutPanel();
            this.combexWarehouseID = new CustomControls.CombexBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelNextCartonNo = new System.Windows.Forms.Label();
            this.labelNextPackNo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimexEntryDate = new CustomControls.DateTimexPicker();
            this.textexCode = new CustomControls.TextexBox();
            this.combexCommodityID = new CustomControls.CombexBox();
            this.textexCommodityName = new CustomControls.TextexBox();
            this.textexNextPackNo = new CustomControls.TextexBox();
            this.textexNextCartonNo = new CustomControls.TextexBox();
            this.textexNextPalletNo = new CustomControls.TextexBox();
            this.textexRemarks = new CustomControls.TextexBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textexLotNumber = new CustomControls.TextexBox();
            this.label5 = new System.Windows.Forms.Label();
            this.toolStripChildForm = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonNewLOT = new System.Windows.Forms.ToolStripButton();
            this.buttonApply = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonDiscontinued = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.comboDiscontinued = new System.Windows.Forms.ToolStripComboBox();
            this.buttonItems = new System.Windows.Forms.ToolStripButton();
            this.naviBarMaster = new Guifreaks.Navisuite.NaviBar(this.components);
            this.naviBand1 = new Guifreaks.Navisuite.NaviBand(this.components);
            this.fastBatchIndex = new BrightIdeasSoftware.FastObjectListView();
            this.olvID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvEntryDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvBatchCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvLotNumber = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCommodityCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCommodityAPICode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCommodityName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvWarehouseAPICode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvPackQuantity = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvPackLineVolume = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCartonQuantity = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCartonLineVolume = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvNextPackNo = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvNextCartonNo = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvNextPalletNo = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvIsDefault = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imageList32 = new System.Windows.Forms.ImageList(this.components);
            this.layoutMaster.SuspendLayout();
            this.toolStripChildForm.SuspendLayout();
            this.naviBarMaster.SuspendLayout();
            this.naviBand1.ClientArea.SuspendLayout();
            this.naviBand1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastBatchIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutMaster
            // 
            this.layoutMaster.AutoSize = true;
            this.layoutMaster.BackColor = System.Drawing.Color.Transparent;
            this.layoutMaster.ColumnCount = 3;
            this.layoutMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.layoutMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.layoutMaster.Controls.Add(this.combexWarehouseID, 1, 12);
            this.layoutMaster.Controls.Add(this.label1, 1, 19);
            this.layoutMaster.Controls.Add(this.label6, 1, 1);
            this.layoutMaster.Controls.Add(this.label2, 1, 3);
            this.layoutMaster.Controls.Add(this.label14, 1, 7);
            this.layoutMaster.Controls.Add(this.label4, 1, 17);
            this.layoutMaster.Controls.Add(this.labelNextCartonNo, 1, 15);
            this.layoutMaster.Controls.Add(this.labelNextPackNo, 1, 13);
            this.layoutMaster.Controls.Add(this.label8, 1, 11);
            this.layoutMaster.Controls.Add(this.dateTimexEntryDate, 1, 2);
            this.layoutMaster.Controls.Add(this.textexCode, 1, 4);
            this.layoutMaster.Controls.Add(this.combexCommodityID, 1, 8);
            this.layoutMaster.Controls.Add(this.textexCommodityName, 1, 10);
            this.layoutMaster.Controls.Add(this.textexNextPackNo, 1, 14);
            this.layoutMaster.Controls.Add(this.textexNextCartonNo, 1, 16);
            this.layoutMaster.Controls.Add(this.textexNextPalletNo, 1, 18);
            this.layoutMaster.Controls.Add(this.textexRemarks, 1, 20);
            this.layoutMaster.Controls.Add(this.label3, 1, 9);
            this.layoutMaster.Controls.Add(this.textexLotNumber, 1, 6);
            this.layoutMaster.Controls.Add(this.label5, 1, 5);
            this.layoutMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutMaster.Location = new System.Drawing.Point(0, 0);
            this.layoutMaster.Margin = new System.Windows.Forms.Padding(0);
            this.layoutMaster.Name = "layoutMaster";
            this.layoutMaster.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.layoutMaster.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.layoutMaster.RowCount = 21;
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.Size = new System.Drawing.Size(378, 637);
            this.layoutMaster.TabIndex = 62;
            // 
            // combexWarehouseID
            // 
            this.combexWarehouseID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combexWarehouseID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combexWarehouseID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combexWarehouseID.Editable = true;
            this.combexWarehouseID.FormattingEnabled = true;
            this.combexWarehouseID.Location = new System.Drawing.Point(33, 350);
            this.combexWarehouseID.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.combexWarehouseID.Name = "combexWarehouseID";
            this.combexWarehouseID.ReadOnly = false;
            this.combexWarehouseID.Size = new System.Drawing.Size(319, 28);
            this.combexWarehouseID.TabIndex = 74;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 569);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 10, 1, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 20);
            this.label1.TabIndex = 57;
            this.label1.Text = "Remarks";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(30, 27);
            this.label6.Margin = new System.Windows.Forms.Padding(0, 10, 1, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(322, 20);
            this.label6.TabIndex = 30;
            this.label6.Text = "Date";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 10, 1, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(322, 20);
            this.label2.TabIndex = 58;
            this.label2.Text = "Batch";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(30, 207);
            this.label14.Margin = new System.Windows.Forms.Padding(0, 10, 1, 1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(322, 20);
            this.label14.TabIndex = 51;
            this.label14.Text = "Item Code";
            this.label14.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 509);
            this.label4.Margin = new System.Windows.Forms.Padding(0, 10, 1, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(322, 20);
            this.label4.TabIndex = 65;
            this.label4.Text = "Next Pallet";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // labelNextCartonNo
            // 
            this.labelNextCartonNo.AutoSize = true;
            this.labelNextCartonNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNextCartonNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNextCartonNo.Location = new System.Drawing.Point(30, 449);
            this.labelNextCartonNo.Margin = new System.Windows.Forms.Padding(0, 10, 1, 1);
            this.labelNextCartonNo.Name = "labelNextCartonNo";
            this.labelNextCartonNo.Size = new System.Drawing.Size(322, 20);
            this.labelNextCartonNo.TabIndex = 66;
            this.labelNextCartonNo.Text = "Next Carton";
            this.labelNextCartonNo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // labelNextPackNo
            // 
            this.labelNextPackNo.AutoSize = true;
            this.labelNextPackNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNextPackNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNextPackNo.Location = new System.Drawing.Point(30, 389);
            this.labelNextPackNo.Margin = new System.Windows.Forms.Padding(0, 10, 1, 1);
            this.labelNextPackNo.Name = "labelNextPackNo";
            this.labelNextPackNo.Size = new System.Drawing.Size(322, 20);
            this.labelNextPackNo.TabIndex = 67;
            this.labelNextPackNo.Text = "Next Bottle";
            this.labelNextPackNo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(30, 328);
            this.label8.Margin = new System.Windows.Forms.Padding(0, 10, 1, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(322, 20);
            this.label8.TabIndex = 68;
            this.label8.Text = "Item Name";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dateTimexEntryDate
            // 
            this.dateTimexEntryDate.CustomFormat = "dd/MMM/yyyy";
            this.dateTimexEntryDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimexEntryDate.Editable = true;
            this.dateTimexEntryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimexEntryDate.Location = new System.Drawing.Point(33, 49);
            this.dateTimexEntryDate.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.dateTimexEntryDate.Name = "dateTimexEntryDate";
            this.dateTimexEntryDate.ReadOnly = false;
            this.dateTimexEntryDate.Size = new System.Drawing.Size(319, 27);
            this.dateTimexEntryDate.TabIndex = 69;
            // 
            // textexCode
            // 
            this.textexCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexCode.Editable = true;
            this.textexCode.Location = new System.Drawing.Point(33, 109);
            this.textexCode.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.textexCode.Name = "textexCode";
            this.textexCode.Size = new System.Drawing.Size(319, 27);
            this.textexCode.TabIndex = 70;
            // 
            // combexCommodityID
            // 
            this.combexCommodityID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combexCommodityID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combexCommodityID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combexCommodityID.Editable = true;
            this.combexCommodityID.FormattingEnabled = true;
            this.combexCommodityID.Location = new System.Drawing.Point(33, 229);
            this.combexCommodityID.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.combexCommodityID.Name = "combexCommodityID";
            this.combexCommodityID.ReadOnly = false;
            this.combexCommodityID.Size = new System.Drawing.Size(319, 28);
            this.combexCommodityID.TabIndex = 72;
            // 
            // textexCommodityName
            // 
            this.textexCommodityName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexCommodityName.Editable = false;
            this.textexCommodityName.Location = new System.Drawing.Point(33, 290);
            this.textexCommodityName.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.textexCommodityName.Name = "textexCommodityName";
            this.textexCommodityName.Size = new System.Drawing.Size(319, 27);
            this.textexCommodityName.TabIndex = 73;
            // 
            // textexNextPackNo
            // 
            this.textexNextPackNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexNextPackNo.Editable = true;
            this.textexNextPackNo.Location = new System.Drawing.Point(33, 411);
            this.textexNextPackNo.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.textexNextPackNo.Name = "textexNextPackNo";
            this.textexNextPackNo.Size = new System.Drawing.Size(319, 27);
            this.textexNextPackNo.TabIndex = 75;
            // 
            // textexNextCartonNo
            // 
            this.textexNextCartonNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexNextCartonNo.Editable = true;
            this.textexNextCartonNo.Location = new System.Drawing.Point(33, 471);
            this.textexNextCartonNo.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.textexNextCartonNo.Name = "textexNextCartonNo";
            this.textexNextCartonNo.Size = new System.Drawing.Size(319, 27);
            this.textexNextCartonNo.TabIndex = 76;
            // 
            // textexNextPalletNo
            // 
            this.textexNextPalletNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexNextPalletNo.Editable = true;
            this.textexNextPalletNo.Location = new System.Drawing.Point(33, 531);
            this.textexNextPalletNo.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.textexNextPalletNo.Name = "textexNextPalletNo";
            this.textexNextPalletNo.Size = new System.Drawing.Size(319, 27);
            this.textexNextPalletNo.TabIndex = 77;
            // 
            // textexRemarks
            // 
            this.textexRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexRemarks.Editable = true;
            this.textexRemarks.Location = new System.Drawing.Point(33, 591);
            this.textexRemarks.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.textexRemarks.Name = "textexRemarks";
            this.textexRemarks.Size = new System.Drawing.Size(319, 27);
            this.textexRemarks.TabIndex = 78;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 268);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 10, 1, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(322, 20);
            this.label3.TabIndex = 77;
            this.label3.Text = "API Code";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // textexLotNumber
            // 
            this.textexLotNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexLotNumber.Editable = true;
            this.textexLotNumber.Location = new System.Drawing.Point(33, 169);
            this.textexLotNumber.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.textexLotNumber.Name = "textexLotNumber";
            this.textexLotNumber.Size = new System.Drawing.Size(319, 27);
            this.textexLotNumber.TabIndex = 71;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 147);
            this.label5.Margin = new System.Windows.Forms.Padding(0, 10, 1, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(322, 20);
            this.label5.TabIndex = 80;
            this.label5.Text = "Lot Number";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // toolStripChildForm
            // 
            this.toolStripChildForm.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripChildForm.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripChildForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.buttonNewLOT,
            this.buttonApply,
            this.toolStripSeparator2,
            this.buttonDiscontinued,
            this.toolStripLabel1,
            this.comboDiscontinued,
            this.buttonItems});
            this.toolStripChildForm.Location = new System.Drawing.Point(0, 0);
            this.toolStripChildForm.Name = "toolStripChildForm";
            this.toolStripChildForm.Size = new System.Drawing.Size(1483, 55);
            this.toolStripChildForm.TabIndex = 29;
            this.toolStripChildForm.Text = "toolStrip1";
            this.toolStripChildForm.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // buttonNewLOT
            // 
            this.buttonNewLOT.Image = global::TotalSmartCoding.Properties.Resources.Add_continue;
            this.buttonNewLOT.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonNewLOT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonNewLOT.Name = "buttonNewLOT";
            this.buttonNewLOT.Size = new System.Drawing.Size(121, 52);
            this.buttonNewLOT.Text = "New LOT";
            this.buttonNewLOT.Click += new System.EventHandler(this.buttonNewLOT_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Image = global::TotalSmartCoding.Properties.Resources.Play_Normal;
            this.buttonApply.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonApply.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(220, 52);
            this.buttonApply.Text = "Applying for Production";
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // buttonDiscontinued
            // 
            this.buttonDiscontinued.Image = global::TotalSmartCoding.Properties.Resources.Stop_Disabled;
            this.buttonDiscontinued.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonDiscontinued.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDiscontinued.Name = "buttonDiscontinued";
            this.buttonDiscontinued.Size = new System.Drawing.Size(148, 52);
            this.buttonDiscontinued.Text = "Discontinued";
            this.buttonDiscontinued.Click += new System.EventHandler(this.buttonDiscontinued_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(33, 52);
            this.toolStripLabel1.Text = "      ";
            // 
            // comboDiscontinued
            // 
            this.comboDiscontinued.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDiscontinued.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.comboDiscontinued.Items.AddRange(new object[] {
            "Don\'t show discontinued batches",
            "Show discontinued batches"});
            this.comboDiscontinued.Name = "comboDiscontinued";
            this.comboDiscontinued.Size = new System.Drawing.Size(270, 55);
            this.comboDiscontinued.SelectedIndexChanged += new System.EventHandler(this.comboDiscontinued_SelectedIndexChanged);
            // 
            // buttonItems
            // 
            this.buttonItems.Image = global::TotalSmartCoding.Properties.Resources.Bookmark_add;
            this.buttonItems.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonItems.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonItems.Name = "buttonItems";
            this.buttonItems.Size = new System.Drawing.Size(97, 52);
            this.buttonItems.Text = "Items";
            this.buttonItems.Click += new System.EventHandler(this.buttonItems_Click);
            // 
            // naviBarMaster
            // 
            this.naviBarMaster.ActiveBand = this.naviBand1;
            this.naviBarMaster.Controls.Add(this.naviBand1);
            this.naviBarMaster.Dock = System.Windows.Forms.DockStyle.Right;
            this.naviBarMaster.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.naviBarMaster.HeaderHeight = 10;
            this.naviBarMaster.LayoutStyle = Guifreaks.Navisuite.NaviLayoutStyle.Office2010Blue;
            this.naviBarMaster.Location = new System.Drawing.Point(1103, 0);
            this.naviBarMaster.Name = "naviBarMaster";
            this.naviBarMaster.PopupMinWidth = 10;
            this.naviBarMaster.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.naviBarMaster.ShowCollapseButton = false;
            this.naviBarMaster.ShowMoreOptionsButton = false;
            this.naviBarMaster.Size = new System.Drawing.Size(380, 685);
            this.naviBarMaster.TabIndex = 66;
            // 
            // naviBand1
            // 
            // 
            // naviBand1.ClientArea
            // 
            this.naviBand1.ClientArea.Controls.Add(this.layoutMaster);
            this.naviBand1.ClientArea.LayoutStyle = Guifreaks.Navisuite.NaviLayoutStyle.StyleFromOwner;
            this.naviBand1.ClientArea.Location = new System.Drawing.Point(0, 0);
            this.naviBand1.ClientArea.Name = "ClientArea";
            this.naviBand1.ClientArea.Size = new System.Drawing.Size(378, 637);
            this.naviBand1.ClientArea.TabIndex = 0;
            this.naviBand1.LargeImageIndex = 0;
            this.naviBand1.LayoutStyle = Guifreaks.Navisuite.NaviLayoutStyle.StyleFromOwner;
            this.naviBand1.Location = new System.Drawing.Point(1, 10);
            this.naviBand1.Name = "naviBand1";
            this.naviBand1.Size = new System.Drawing.Size(378, 637);
            this.naviBand1.SmallImageIndex = 0;
            this.naviBand1.TabIndex = 70;
            // 
            // fastBatchIndex
            // 
            this.fastBatchIndex.AllColumns.Add(this.olvID);
            this.fastBatchIndex.AllColumns.Add(this.olvEntryDate);
            this.fastBatchIndex.AllColumns.Add(this.olvBatchCode);
            this.fastBatchIndex.AllColumns.Add(this.olvLotNumber);
            this.fastBatchIndex.AllColumns.Add(this.olvCommodityCode);
            this.fastBatchIndex.AllColumns.Add(this.olvCommodityAPICode);
            this.fastBatchIndex.AllColumns.Add(this.olvCommodityName);
            this.fastBatchIndex.AllColumns.Add(this.olvWarehouseAPICode);
            this.fastBatchIndex.AllColumns.Add(this.olvPackQuantity);
            this.fastBatchIndex.AllColumns.Add(this.olvPackLineVolume);
            this.fastBatchIndex.AllColumns.Add(this.olvCartonQuantity);
            this.fastBatchIndex.AllColumns.Add(this.olvCartonLineVolume);
            this.fastBatchIndex.AllColumns.Add(this.olvNextPackNo);
            this.fastBatchIndex.AllColumns.Add(this.olvNextCartonNo);
            this.fastBatchIndex.AllColumns.Add(this.olvNextPalletNo);
            this.fastBatchIndex.AllColumns.Add(this.olvIsDefault);
            this.fastBatchIndex.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvID,
            this.olvEntryDate,
            this.olvBatchCode,
            this.olvLotNumber,
            this.olvCommodityCode,
            this.olvCommodityAPICode,
            this.olvCommodityName,
            this.olvWarehouseAPICode,
            this.olvPackQuantity,
            this.olvPackLineVolume,
            this.olvCartonQuantity,
            this.olvCartonLineVolume,
            this.olvNextPackNo,
            this.olvNextCartonNo,
            this.olvNextPalletNo,
            this.olvIsDefault});
            this.fastBatchIndex.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastBatchIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastBatchIndex.FullRowSelect = true;
            this.fastBatchIndex.GroupImageList = this.imageList32;
            this.fastBatchIndex.HideSelection = false;
            this.fastBatchIndex.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastBatchIndex.Location = new System.Drawing.Point(0, 0);
            this.fastBatchIndex.Name = "fastBatchIndex";
            this.fastBatchIndex.OwnerDraw = true;
            this.fastBatchIndex.ShowGroups = false;
            this.fastBatchIndex.Size = new System.Drawing.Size(1103, 685);
            this.fastBatchIndex.TabIndex = 67;
            this.fastBatchIndex.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastBatchIndex.UseCompatibleStateImageBehavior = false;
            this.fastBatchIndex.UseFiltering = true;
            this.fastBatchIndex.View = System.Windows.Forms.View.Details;
            this.fastBatchIndex.VirtualMode = true;
            this.fastBatchIndex.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.fastBatchIndex_FormatRow);
            // 
            // olvID
            // 
            this.olvID.Text = "";
            this.olvID.Width = 0;
            // 
            // olvEntryDate
            // 
            this.olvEntryDate.AspectName = "EntryDate";
            this.olvEntryDate.AspectToStringFormat = "{0:d}";
            this.olvEntryDate.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvEntryDate.Text = "Date";
            this.olvEntryDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvEntryDate.Width = 86;
            // 
            // olvBatchCode
            // 
            this.olvBatchCode.AspectName = "BatchCode";
            this.olvBatchCode.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvBatchCode.Text = "Batch";
            this.olvBatchCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvLotNumber
            // 
            this.olvLotNumber.AspectName = "LotNumber";
            this.olvLotNumber.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvLotNumber.Text = "Lot";
            this.olvLotNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvLotNumber.Width = 30;
            // 
            // olvCommodityCode
            // 
            this.olvCommodityCode.AspectName = "CommodityCode";
            this.olvCommodityCode.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvCommodityCode.Text = "Item Code";
            this.olvCommodityCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvCommodityAPICode
            // 
            this.olvCommodityAPICode.AspectName = "CommodityAPICode";
            this.olvCommodityAPICode.Text = "Code";
            this.olvCommodityAPICode.Width = 50;
            // 
            // olvCommodityName
            // 
            this.olvCommodityName.AspectName = "CommodityName";
            this.olvCommodityName.Text = "Desccription";
            this.olvCommodityName.Width = 188;
            // 
            // olvWarehouseAPICode
            // 
            this.olvWarehouseAPICode.AspectName = "WarehouseAPICode";
            this.olvWarehouseAPICode.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvWarehouseAPICode.Text = "WH";
            this.olvWarehouseAPICode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvWarehouseAPICode.Width = 40;
            // 
            // olvPackQuantity
            // 
            this.olvPackQuantity.AspectName = "PackQuantity";
            this.olvPackQuantity.AspectToStringFormat = "{0:#,#}";
            this.olvPackQuantity.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvPackQuantity.Text = "Unpacked Qty";
            this.olvPackQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvPackQuantity.Width = 90;
            // 
            // olvPackLineVolume
            // 
            this.olvPackLineVolume.AspectName = "PackLineVolume";
            this.olvPackLineVolume.AspectToStringFormat = "{0:#,##0.00}";
            this.olvPackLineVolume.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvPackLineVolume.Text = "Unpacked Volume";
            this.olvPackLineVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvPackLineVolume.Width = 100;
            // 
            // olvCartonQuantity
            // 
            this.olvCartonQuantity.AspectName = "CartonQuantity";
            this.olvCartonQuantity.AspectToStringFormat = "{0:#,#}";
            this.olvCartonQuantity.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvCartonQuantity.Text = "Qty";
            this.olvCartonQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvCartonQuantity.Width = 45;
            // 
            // olvCartonLineVolume
            // 
            this.olvCartonLineVolume.AspectName = "CartonLineVolume";
            this.olvCartonLineVolume.AspectToStringFormat = "{0:#,##0.00}";
            this.olvCartonLineVolume.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvCartonLineVolume.Text = "Volume";
            this.olvCartonLineVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // olvNextPackNo
            // 
            this.olvNextPackNo.AspectName = "NextPackNo";
            this.olvNextPackNo.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvNextPackNo.Text = "Next Pack";
            this.olvNextPackNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvNextPackNo.Width = 70;
            // 
            // olvNextCartonNo
            // 
            this.olvNextCartonNo.AspectName = "NextCartonNo";
            this.olvNextCartonNo.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvNextCartonNo.Text = "Next Carton";
            this.olvNextCartonNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvNextCartonNo.Width = 70;
            // 
            // olvNextPalletNo
            // 
            this.olvNextPalletNo.AspectName = "NextPalletNo";
            this.olvNextPalletNo.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvNextPalletNo.Text = "Next Pallet";
            this.olvNextPalletNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvNextPalletNo.Width = 70;
            // 
            // olvIsDefault
            // 
            this.olvIsDefault.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvIsDefault.Text = "";
            this.olvIsDefault.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvIsDefault.Width = 24;
            // 
            // imageList32
            // 
            this.imageList32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList32.ImageStream")));
            this.imageList32.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList32.Images.SetKeyName(0, "Forklift");
            this.imageList32.Images.SetKeyName(1, "ForkliftYellow");
            this.imageList32.Images.SetKeyName(2, "ForkliftOrange");
            this.imageList32.Images.SetKeyName(3, "ForkliftJapan");
            this.imageList32.Images.SetKeyName(4, "Placeholder32");
            this.imageList32.Images.SetKeyName(5, "Storage32");
            this.imageList32.Images.SetKeyName(6, "Sales-Order-32");
            this.imageList32.Images.SetKeyName(7, "Sign_Order_32");
            this.imageList32.Images.SetKeyName(8, "CustomerRed");
            // 
            // Batches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1483, 685);
            this.Controls.Add(this.fastBatchIndex);
            this.Controls.Add(this.naviBarMaster);
            this.Controls.Add(this.toolStripChildForm);
            this.Name = "Batches";
            this.Text = "Batches";
            this.Controls.SetChildIndex(this.toolStripChildForm, 0);
            this.Controls.SetChildIndex(this.naviBarMaster, 0);
            this.Controls.SetChildIndex(this.fastBatchIndex, 0);
            this.layoutMaster.ResumeLayout(false);
            this.layoutMaster.PerformLayout();
            this.toolStripChildForm.ResumeLayout(false);
            this.toolStripChildForm.PerformLayout();
            this.naviBarMaster.ResumeLayout(false);
            this.naviBand1.ClientArea.ResumeLayout(false);
            this.naviBand1.ClientArea.PerformLayout();
            this.naviBand1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastBatchIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutMaster;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ToolStrip toolStripChildForm;
        private System.Windows.Forms.ToolStripButton buttonDiscontinued;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buttonApply;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelNextCartonNo;
        private System.Windows.Forms.Label labelNextPackNo;
        private Guifreaks.Navisuite.NaviBar naviBarMaster;
        private System.Windows.Forms.Label label8;
        private Guifreaks.Navisuite.NaviBand naviBand1;
        private BrightIdeasSoftware.FastObjectListView fastBatchIndex;
        private BrightIdeasSoftware.OLVColumn olvBatchCode;
        private BrightIdeasSoftware.OLVColumn olvCommodityCode;
        private BrightIdeasSoftware.OLVColumn olvCommodityName;
        private BrightIdeasSoftware.OLVColumn olvNextPackNo;
        private BrightIdeasSoftware.OLVColumn olvNextCartonNo;
        private BrightIdeasSoftware.OLVColumn olvNextPalletNo;
        private BrightIdeasSoftware.OLVColumn olvID;
        private BrightIdeasSoftware.OLVColumn olvEntryDate;
        private BrightIdeasSoftware.OLVColumn olvIsDefault;
        private System.Windows.Forms.ToolStripComboBox comboDiscontinued;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private CustomControls.DateTimexPicker dateTimexEntryDate;
        private CustomControls.TextexBox textexCode;
        private CustomControls.CombexBox combexCommodityID;
        private CustomControls.TextexBox textexCommodityName;
        private CustomControls.TextexBox textexNextPackNo;
        private CustomControls.TextexBox textexNextCartonNo;
        private CustomControls.TextexBox textexNextPalletNo;
        private CustomControls.TextexBox textexRemarks;
        private System.Windows.Forms.Label label3;
        private CustomControls.TextexBox textexLotNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripButton buttonNewLOT;
        private BrightIdeasSoftware.OLVColumn olvLotNumber;
        private BrightIdeasSoftware.OLVColumn olvCommodityAPICode;
        private System.Windows.Forms.ImageList imageList32;
        private BrightIdeasSoftware.OLVColumn olvPackQuantity;
        private BrightIdeasSoftware.OLVColumn olvPackLineVolume;
        private BrightIdeasSoftware.OLVColumn olvCartonQuantity;
        private BrightIdeasSoftware.OLVColumn olvCartonLineVolume;
        private System.Windows.Forms.ToolStripButton buttonItems;
        private CustomControls.CombexBox combexWarehouseID;
        private BrightIdeasSoftware.OLVColumn olvWarehouseAPICode;

    }
}