namespace TotalSmartCoding.Views.Productions
{
    partial class BatchWizard
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonESC = new System.Windows.Forms.ToolStripButton();
            this.buttonOK = new System.Windows.Forms.ToolStripButton();
            this.errorProviderMaster = new System.Windows.Forms.ErrorProvider(this.components);
            this.layoutTop = new System.Windows.Forms.TableLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.combexBatchTypeID = new CustomControls.CombexBox();
            this.textexLotNumber = new CustomControls.TextexBox();
            this.numericPackQuantity = new CustomControls.NumericBox();
            this.numericPlannedQuantity = new CustomControls.NumericBox();
            this.numericVolume = new CustomControls.NumericBox();
            this.textexBatchStatusCode = new CustomControls.TextexBox();
            this.textexCommodityName = new CustomControls.TextexBox();
            this.combexBatchMasterID = new CustomControls.CombexBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textexCommodityCartonCode = new CustomControls.TextexBox();
            this.textexRemarks = new CustomControls.TextexBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textexCommodityCode = new CustomControls.TextexBox();
            this.textexCommodityAPICode = new CustomControls.TextexBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dateTimexEntryDate = new CustomControls.DateTimexPicker();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMaster)).BeginInit();
            this.layoutTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPackQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPlannedQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonESC,
            this.buttonOK});
            this.toolStrip1.Location = new System.Drawing.Point(0, 431);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(955, 55);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // buttonESC
            // 
            this.buttonESC.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonESC.Image = global::TotalSmartCoding.Properties.Resources.signout_icon_24;
            this.buttonESC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonESC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonESC.Name = "buttonESC";
            this.buttonESC.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonESC.Size = new System.Drawing.Size(83, 52);
            this.buttonESC.Text = "Cancel";
            this.buttonESC.Click += new System.EventHandler(this.buttonOKESC_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Enabled = false;
            this.buttonOK.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.Image = global::TotalSmartCoding.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_go_next_view;
            this.buttonOK.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonOK.Size = new System.Drawing.Size(94, 52);
            this.buttonOK.Text = "Next";
            this.buttonOK.Click += new System.EventHandler(this.buttonOKESC_Click);
            // 
            // errorProviderMaster
            // 
            this.errorProviderMaster.ContainerControl = this;
            // 
            // layoutTop
            // 
            this.layoutTop.AutoSize = true;
            this.layoutTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutTop.ColumnCount = 5;
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.layoutTop.Controls.Add(this.dateTimexEntryDate, 3, 4);
            this.layoutTop.Controls.Add(this.label13, 2, 3);
            this.layoutTop.Controls.Add(this.label12, 2, 2);
            this.layoutTop.Controls.Add(this.combexBatchTypeID, 3, 3);
            this.layoutTop.Controls.Add(this.textexLotNumber, 3, 2);
            this.layoutTop.Controls.Add(this.numericPackQuantity, 3, 11);
            this.layoutTop.Controls.Add(this.numericPlannedQuantity, 3, 10);
            this.layoutTop.Controls.Add(this.numericVolume, 3, 9);
            this.layoutTop.Controls.Add(this.textexBatchStatusCode, 3, 12);
            this.layoutTop.Controls.Add(this.textexCommodityName, 3, 6);
            this.layoutTop.Controls.Add(this.combexBatchMasterID, 3, 1);
            this.layoutTop.Controls.Add(this.label4, 2, 8);
            this.layoutTop.Controls.Add(this.label5, 2, 4);
            this.layoutTop.Controls.Add(this.textexCommodityCartonCode, 3, 8);
            this.layoutTop.Controls.Add(this.textexRemarks, 3, 13);
            this.layoutTop.Controls.Add(this.label1, 2, 9);
            this.layoutTop.Controls.Add(this.label2, 2, 12);
            this.layoutTop.Controls.Add(this.label3, 2, 13);
            this.layoutTop.Controls.Add(this.label6, 2, 11);
            this.layoutTop.Controls.Add(this.label7, 2, 10);
            this.layoutTop.Controls.Add(this.label8, 2, 1);
            this.layoutTop.Controls.Add(this.pictureBox2, 1, 1);
            this.layoutTop.Controls.Add(this.label9, 2, 6);
            this.layoutTop.Controls.Add(this.textexCommodityCode, 3, 5);
            this.layoutTop.Controls.Add(this.textexCommodityAPICode, 3, 7);
            this.layoutTop.Controls.Add(this.label10, 2, 5);
            this.layoutTop.Controls.Add(this.label11, 2, 7);
            this.layoutTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutTop.Location = new System.Drawing.Point(0, 0);
            this.layoutTop.Margin = new System.Windows.Forms.Padding(0);
            this.layoutTop.Name = "layoutTop";
            this.layoutTop.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.layoutTop.RowCount = 15;
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.layoutTop.Size = new System.Drawing.Size(955, 431);
            this.layoutTop.TabIndex = 98;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(87, 88);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(206, 31);
            this.label13.TabIndex = 107;
            this.label13.Text = "Type: N, R, T";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(87, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(206, 30);
            this.label12.TabIndex = 106;
            this.label12.Text = "New Lot";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // combexBatchTypeID
            // 
            this.combexBatchTypeID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combexBatchTypeID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combexBatchTypeID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combexBatchTypeID.Editable = true;
            this.combexBatchTypeID.Font = new System.Drawing.Font("Calibri Light", 10.2F);
            this.combexBatchTypeID.FormattingEnabled = true;
            this.combexBatchTypeID.Location = new System.Drawing.Point(297, 89);
            this.combexBatchTypeID.Margin = new System.Windows.Forms.Padding(1);
            this.combexBatchTypeID.Name = "combexBatchTypeID";
            this.combexBatchTypeID.ReadOnly = false;
            this.combexBatchTypeID.Size = new System.Drawing.Size(634, 29);
            this.combexBatchTypeID.TabIndex = 2;
            // 
            // textexLotNumber
            // 
            this.textexLotNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexLotNumber.Editable = true;
            this.textexLotNumber.Font = new System.Drawing.Font("Calibri Light", 10.2F);
            this.textexLotNumber.Location = new System.Drawing.Point(297, 59);
            this.textexLotNumber.Margin = new System.Windows.Forms.Padding(1);
            this.textexLotNumber.Name = "textexLotNumber";
            this.textexLotNumber.Size = new System.Drawing.Size(634, 28);
            this.textexLotNumber.TabIndex = 1;
            // 
            // numericPackQuantity
            // 
            this.numericPackQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericPackQuantity.Editable = true;
            this.numericPackQuantity.Font = new System.Drawing.Font("Calibri Light", 10.2F);
            this.numericPackQuantity.Location = new System.Drawing.Point(297, 330);
            this.numericPackQuantity.Margin = new System.Windows.Forms.Padding(1);
            this.numericPackQuantity.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.numericPackQuantity.Name = "numericPackQuantity";
            this.numericPackQuantity.ReadOnly = true;
            this.numericPackQuantity.Size = new System.Drawing.Size(634, 28);
            this.numericPackQuantity.TabIndex = 10;
            this.numericPackQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericPackQuantity.ThousandsSeparator = true;
            // 
            // numericPlannedQuantity
            // 
            this.numericPlannedQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericPlannedQuantity.Editable = true;
            this.numericPlannedQuantity.Font = new System.Drawing.Font("Calibri Light", 10.2F);
            this.numericPlannedQuantity.Location = new System.Drawing.Point(297, 300);
            this.numericPlannedQuantity.Margin = new System.Windows.Forms.Padding(1);
            this.numericPlannedQuantity.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.numericPlannedQuantity.Name = "numericPlannedQuantity";
            this.numericPlannedQuantity.ReadOnly = true;
            this.numericPlannedQuantity.Size = new System.Drawing.Size(634, 28);
            this.numericPlannedQuantity.TabIndex = 9;
            this.numericPlannedQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericPlannedQuantity.ThousandsSeparator = true;
            // 
            // numericVolume
            // 
            this.numericVolume.DecimalPlaces = 2;
            this.numericVolume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericVolume.Editable = true;
            this.numericVolume.Font = new System.Drawing.Font("Calibri Light", 10.2F);
            this.numericVolume.Location = new System.Drawing.Point(297, 270);
            this.numericVolume.Margin = new System.Windows.Forms.Padding(1);
            this.numericVolume.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.numericVolume.Name = "numericVolume";
            this.numericVolume.ReadOnly = true;
            this.numericVolume.Size = new System.Drawing.Size(634, 28);
            this.numericVolume.TabIndex = 8;
            this.numericVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericVolume.ThousandsSeparator = true;
            // 
            // textexBatchStatusCode
            // 
            this.textexBatchStatusCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexBatchStatusCode.Editable = true;
            this.textexBatchStatusCode.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textexBatchStatusCode.Location = new System.Drawing.Point(297, 360);
            this.textexBatchStatusCode.Margin = new System.Windows.Forms.Padding(1);
            this.textexBatchStatusCode.Name = "textexBatchStatusCode";
            this.textexBatchStatusCode.ReadOnly = true;
            this.textexBatchStatusCode.Size = new System.Drawing.Size(634, 28);
            this.textexBatchStatusCode.TabIndex = 11;
            // 
            // textexCommodityName
            // 
            this.textexCommodityName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexCommodityName.Editable = true;
            this.textexCommodityName.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textexCommodityName.Location = new System.Drawing.Point(297, 180);
            this.textexCommodityName.Margin = new System.Windows.Forms.Padding(1);
            this.textexCommodityName.Name = "textexCommodityName";
            this.textexCommodityName.ReadOnly = true;
            this.textexCommodityName.Size = new System.Drawing.Size(634, 28);
            this.textexCommodityName.TabIndex = 5;
            // 
            // combexBatchMasterID
            // 
            this.combexBatchMasterID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combexBatchMasterID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combexBatchMasterID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combexBatchMasterID.Editable = true;
            this.combexBatchMasterID.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combexBatchMasterID.FormattingEnabled = true;
            this.combexBatchMasterID.Location = new System.Drawing.Point(297, 28);
            this.combexBatchMasterID.Margin = new System.Windows.Forms.Padding(1);
            this.combexBatchMasterID.Name = "combexBatchMasterID";
            this.combexBatchMasterID.ReadOnly = false;
            this.combexBatchMasterID.Size = new System.Drawing.Size(634, 29);
            this.combexBatchMasterID.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(87, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 30);
            this.label4.TabIndex = 77;
            this.label4.Text = "Contact Info";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(87, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(206, 30);
            this.label5.TabIndex = 78;
            this.label5.Text = "Customer";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textexCommodityCartonCode
            // 
            this.textexCommodityCartonCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexCommodityCartonCode.Editable = false;
            this.textexCommodityCartonCode.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textexCommodityCartonCode.Location = new System.Drawing.Point(297, 240);
            this.textexCommodityCartonCode.Margin = new System.Windows.Forms.Padding(1);
            this.textexCommodityCartonCode.Name = "textexCommodityCartonCode";
            this.textexCommodityCartonCode.ReadOnly = true;
            this.textexCommodityCartonCode.Size = new System.Drawing.Size(634, 28);
            this.textexCommodityCartonCode.TabIndex = 7;
            // 
            // textexRemarks
            // 
            this.textexRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexRemarks.Editable = true;
            this.textexRemarks.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textexRemarks.Location = new System.Drawing.Point(297, 390);
            this.textexRemarks.Margin = new System.Windows.Forms.Padding(1);
            this.textexRemarks.Name = "textexRemarks";
            this.textexRemarks.ReadOnly = true;
            this.textexRemarks.Size = new System.Drawing.Size(634, 28);
            this.textexRemarks.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(87, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 30);
            this.label1.TabIndex = 82;
            this.label1.Text = "Shipping Address";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(87, 359);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 30);
            this.label2.TabIndex = 83;
            this.label2.Text = "Salesperson";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(87, 389);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 30);
            this.label3.TabIndex = 84;
            this.label3.Text = "Remarks";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(87, 329);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(206, 30);
            this.label6.TabIndex = 86;
            this.label6.Text = "Delivery Lead Time";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(87, 299);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(206, 30);
            this.label7.TabIndex = 88;
            this.label7.Text = "Voucher #";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(87, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(206, 31);
            this.label8.TabIndex = 89;
            this.label8.Text = "Batch";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TotalSmartCoding.Properties.Resources.Sign_Order_48;
            this.pictureBox2.Location = new System.Drawing.Point(33, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.layoutTop.SetRowSpan(this.pictureBox2, 8);
            this.pictureBox2.Size = new System.Drawing.Size(48, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 75;
            this.pictureBox2.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(87, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(206, 30);
            this.label9.TabIndex = 92;
            this.label9.Text = "Receiver";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textexCommodityCode
            // 
            this.textexCommodityCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexCommodityCode.Editable = true;
            this.textexCommodityCode.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textexCommodityCode.Location = new System.Drawing.Point(297, 150);
            this.textexCommodityCode.Margin = new System.Windows.Forms.Padding(1);
            this.textexCommodityCode.Name = "textexCommodityCode";
            this.textexCommodityCode.ReadOnly = true;
            this.textexCommodityCode.Size = new System.Drawing.Size(634, 28);
            this.textexCommodityCode.TabIndex = 4;
            // 
            // textexCommodityAPICode
            // 
            this.textexCommodityAPICode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexCommodityAPICode.Editable = true;
            this.textexCommodityAPICode.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textexCommodityAPICode.Location = new System.Drawing.Point(297, 210);
            this.textexCommodityAPICode.Margin = new System.Windows.Forms.Padding(1);
            this.textexCommodityAPICode.Name = "textexCommodityAPICode";
            this.textexCommodityAPICode.ReadOnly = true;
            this.textexCommodityAPICode.Size = new System.Drawing.Size(634, 28);
            this.textexCommodityAPICode.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(87, 149);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(206, 30);
            this.label10.TabIndex = 95;
            this.label10.Text = "Customer Name";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(87, 209);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(206, 30);
            this.label11.TabIndex = 96;
            this.label11.Text = "Receiver Name";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateTimexEntryDate
            // 
            this.dateTimexEntryDate.CustomFormat = "dd/MMM/yyyy";
            this.dateTimexEntryDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimexEntryDate.Editable = true;
            this.dateTimexEntryDate.Font = new System.Drawing.Font("Calibri Light", 10.2F);
            this.dateTimexEntryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimexEntryDate.Location = new System.Drawing.Point(297, 120);
            this.dateTimexEntryDate.Margin = new System.Windows.Forms.Padding(1);
            this.dateTimexEntryDate.Name = "dateTimexEntryDate";
            this.dateTimexEntryDate.ReadOnly = false;
            this.dateTimexEntryDate.Size = new System.Drawing.Size(634, 28);
            this.dateTimexEntryDate.TabIndex = 108;
            // 
            // BatchWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 486);
            this.Controls.Add(this.layoutTop);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BatchWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Wizard [New LOT]";
            this.Load += new System.EventHandler(this.WizardMaster_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMaster)).EndInit();
            this.layoutTop.ResumeLayout(false);
            this.layoutTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPackQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPlannedQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonESC;
        private System.Windows.Forms.ToolStripButton buttonOK;
        private System.Windows.Forms.ErrorProvider errorProviderMaster;
        private System.Windows.Forms.TableLayoutPanel layoutTop;
        private CustomControls.CombexBox combexBatchMasterID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private CustomControls.TextexBox textexCommodityCartonCode;
        private CustomControls.TextexBox textexRemarks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private CustomControls.TextexBox textexCommodityCode;
        private CustomControls.TextexBox textexCommodityAPICode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private CustomControls.TextexBox textexBatchStatusCode;
        private CustomControls.TextexBox textexCommodityName;
        private CustomControls.NumericBox numericPackQuantity;
        private CustomControls.NumericBox numericPlannedQuantity;
        private CustomControls.NumericBox numericVolume;
        private CustomControls.TextexBox textexLotNumber;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private CustomControls.CombexBox combexBatchTypeID;
        private CustomControls.DateTimexPicker dateTimexEntryDate;
    }
}