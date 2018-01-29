namespace TotalSmartCoding.Views.Mains
{
    partial class MapExcelColumn
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
            this.dataGridColumnAvailable = new System.Windows.Forms.DataGridView();
            this.ColumnAvailableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMappingName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridColumnMapping = new System.Windows.Forms.DataGridView();
            this.buttonMapColumn = new System.Windows.Forms.Button();
            this.buttonUnMapColumn = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonEscape = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonNext = new System.Windows.Forms.ToolStripButton();
            this.checkBoxResetPlanned = new System.Windows.Forms.CheckBox();
            this.checkBoxDeleteAll = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ColumnDisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridColumnAvailable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridColumnMapping)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridColumnAvailable
            // 
            this.dataGridColumnAvailable.AllowUserToAddRows = false;
            this.dataGridColumnAvailable.AllowUserToDeleteRows = false;
            this.dataGridColumnAvailable.AllowUserToOrderColumns = true;
            this.dataGridColumnAvailable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridColumnAvailable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridColumnAvailable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridColumnAvailable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridColumnAvailable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnAvailableName,
            this.ColumnMappingName});
            this.dataGridColumnAvailable.Location = new System.Drawing.Point(16, 144);
            this.dataGridColumnAvailable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridColumnAvailable.Name = "dataGridColumnAvailable";
            this.dataGridColumnAvailable.ReadOnly = true;
            this.dataGridColumnAvailable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridColumnAvailable.Size = new System.Drawing.Size(468, 164);
            this.dataGridColumnAvailable.TabIndex = 11;
            // 
            // ColumnAvailableName
            // 
            this.ColumnAvailableName.DataPropertyName = "ColumnAvailableName";
            this.ColumnAvailableName.HeaderText = "File excel";
            this.ColumnAvailableName.Name = "ColumnAvailableName";
            this.ColumnAvailableName.ReadOnly = true;
            // 
            // ColumnMappingName
            // 
            this.ColumnMappingName.DataPropertyName = "ColumnMappingName";
            this.ColumnMappingName.HeaderText = "Phần mềm";
            this.ColumnMappingName.Name = "ColumnMappingName";
            this.ColumnMappingName.ReadOnly = true;
            // 
            // dataGridColumnMapping
            // 
            this.dataGridColumnMapping.AllowUserToAddRows = false;
            this.dataGridColumnMapping.AllowUserToDeleteRows = false;
            this.dataGridColumnMapping.AllowUserToOrderColumns = true;
            this.dataGridColumnMapping.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridColumnMapping.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridColumnMapping.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridColumnMapping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridColumnMapping.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDisplayName,
            this.dataGridViewTextBoxColumn1});
            this.dataGridColumnMapping.Location = new System.Drawing.Point(547, 143);
            this.dataGridColumnMapping.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridColumnMapping.Name = "dataGridColumnMapping";
            this.dataGridColumnMapping.ReadOnly = true;
            this.dataGridColumnMapping.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridColumnMapping.Size = new System.Drawing.Size(468, 165);
            this.dataGridColumnMapping.TabIndex = 12;
            // 
            // buttonMapColumn
            // 
            this.buttonMapColumn.Location = new System.Drawing.Point(492, 202);
            this.buttonMapColumn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonMapColumn.Name = "buttonMapColumn";
            this.buttonMapColumn.Size = new System.Drawing.Size(45, 42);
            this.buttonMapColumn.TabIndex = 13;
            this.buttonMapColumn.UseVisualStyleBackColor = true;
            this.buttonMapColumn.Click += new System.EventHandler(this.MappingColumn);
            // 
            // buttonUnMapColumn
            // 
            this.buttonUnMapColumn.Location = new System.Drawing.Point(492, 245);
            this.buttonUnMapColumn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonUnMapColumn.Name = "buttonUnMapColumn";
            this.buttonUnMapColumn.Size = new System.Drawing.Size(45, 42);
            this.buttonUnMapColumn.TabIndex = 14;
            this.buttonUnMapColumn.UseVisualStyleBackColor = true;
            this.buttonUnMapColumn.Click += new System.EventHandler(this.MappingColumn);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonEscape,
            this.toolStripButtonNext});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1029, 27);
            this.toolStrip1.TabIndex = 69;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonEscape
            // 
            this.toolStripButtonEscape.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEscape.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonEscape.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEscape.Name = "toolStripButtonEscape";
            this.toolStripButtonEscape.Size = new System.Drawing.Size(23, 24);
            this.toolStripButtonEscape.Text = "toolStripButton1";
            this.toolStripButtonEscape.Click += new System.EventHandler(this.NextCancel_Click);
            // 
            // toolStripButtonNext
            // 
            this.toolStripButtonNext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNext.Name = "toolStripButtonNext";
            this.toolStripButtonNext.Size = new System.Drawing.Size(58, 24);
            this.toolStripButtonNext.Text = "Import";
            this.toolStripButtonNext.Click += new System.EventHandler(this.NextCancel_Click);
            // 
            // checkBoxResetPlanned
            // 
            this.checkBoxResetPlanned.AutoSize = true;
            this.checkBoxResetPlanned.Checked = true;
            this.checkBoxResetPlanned.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxResetPlanned.Location = new System.Drawing.Point(57, 71);
            this.checkBoxResetPlanned.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxResetPlanned.Name = "checkBoxResetPlanned";
            this.checkBoxResetPlanned.Size = new System.Drawing.Size(224, 21);
            this.checkBoxResetPlanned.TabIndex = 70;
            this.checkBoxResetPlanned.Text = "Xóa kế hoạch sản xuất hiện tại";
            this.checkBoxResetPlanned.UseVisualStyleBackColor = true;
            // 
            // checkBoxDeleteAll
            // 
            this.checkBoxDeleteAll.AutoSize = true;
            this.checkBoxDeleteAll.Location = new System.Drawing.Point(57, 100);
            this.checkBoxDeleteAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxDeleteAll.Name = "checkBoxDeleteAll";
            this.checkBoxDeleteAll.Size = new System.Drawing.Size(314, 21);
            this.checkBoxDeleteAll.TabIndex = 71;
            this.checkBoxDeleteAll.Text = "Xóa tất cả mặt hàng hiện có trong phần mềm";
            this.checkBoxDeleteAll.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(12, 345);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(798, 17);
            this.label1.TabIndex = 72;
            this.label1.Text = "Lưu ý: Vui lòng kiểm tra các cột dữ liệu tương ứng giữa file excel và phần mềm. N" +
    "hấn Import để bắt đầu import vào phần mềm.";
            // 
            // ColumnDisplayName
            // 
            this.ColumnDisplayName.DataPropertyName = "ColumnDisplayName";
            this.ColumnDisplayName.HeaderText = "Phần mềm";
            this.ColumnDisplayName.Name = "ColumnDisplayName";
            this.ColumnDisplayName.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ColumnMappingName";
            this.dataGridViewTextBoxColumn1.HeaderText = "File excel";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // MapExcelColumn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 383);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxDeleteAll);
            this.Controls.Add(this.checkBoxResetPlanned);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.buttonUnMapColumn);
            this.Controls.Add(this.buttonMapColumn);
            this.Controls.Add(this.dataGridColumnMapping);
            this.Controls.Add(this.dataGridColumnAvailable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MapExcelColumn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import danh mục sản phẩm";
            this.Load += new System.EventHandler(this.DialogMapExcelColumn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridColumnAvailable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridColumnMapping)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridColumnAvailable;
        private System.Windows.Forms.DataGridView dataGridColumnMapping;
        private System.Windows.Forms.Button buttonMapColumn;
        private System.Windows.Forms.Button buttonUnMapColumn;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonEscape;
        private System.Windows.Forms.ToolStripButton toolStripButtonNext;
        private System.Windows.Forms.CheckBox checkBoxResetPlanned;
        private System.Windows.Forms.CheckBox checkBoxDeleteAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAvailableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMappingName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDisplayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}