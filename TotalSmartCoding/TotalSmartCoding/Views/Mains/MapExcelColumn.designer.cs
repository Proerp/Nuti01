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
            this.ColumnDisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.buttonCancel = new System.Windows.Forms.ToolStripButton();
            this.buttonOK = new System.Windows.Forms.ToolStripButton();
            this.buttonUnMapColumn = new System.Windows.Forms.Button();
            this.buttonMapColumn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridColumnAvailable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridColumnMapping)).BeginInit();
            this.toolStrip2.SuspendLayout();
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
            this.dataGridColumnAvailable.Location = new System.Drawing.Point(18, 17);
            this.dataGridColumnAvailable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridColumnAvailable.Name = "dataGridColumnAvailable";
            this.dataGridColumnAvailable.ReadOnly = true;
            this.dataGridColumnAvailable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridColumnAvailable.Size = new System.Drawing.Size(457, 360);
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
            this.dataGridColumnMapping.Location = new System.Drawing.Point(542, 17);
            this.dataGridColumnMapping.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridColumnMapping.Name = "dataGridColumnMapping";
            this.dataGridColumnMapping.ReadOnly = true;
            this.dataGridColumnMapping.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridColumnMapping.Size = new System.Drawing.Size(457, 360);
            this.dataGridColumnMapping.TabIndex = 12;
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
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonCancel,
            this.buttonOK});
            this.toolStrip2.Location = new System.Drawing.Point(0, 381);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip2.Size = new System.Drawing.Size(1012, 55);
            this.toolStrip2.TabIndex = 70;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Image = global::TotalSmartCoding.Properties.Resources.signout_icon_24;
            this.buttonCancel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonCancel.Size = new System.Drawing.Size(81, 52);
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.OKCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Image = global::TotalSmartCoding.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_go_next_view;
            this.buttonOK.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonOK.Size = new System.Drawing.Size(92, 52);
            this.buttonOK.Text = "Next";
            this.buttonOK.Click += new System.EventHandler(this.OKCancel_Click);
            // 
            // buttonUnMapColumn
            // 
            this.buttonUnMapColumn.Image = global::TotalSmartCoding.Properties.Resources.Navigate_left;
            this.buttonUnMapColumn.Location = new System.Drawing.Point(483, 216);
            this.buttonUnMapColumn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonUnMapColumn.Name = "buttonUnMapColumn";
            this.buttonUnMapColumn.Size = new System.Drawing.Size(51, 55);
            this.buttonUnMapColumn.TabIndex = 14;
            this.buttonUnMapColumn.UseVisualStyleBackColor = true;
            this.buttonUnMapColumn.Click += new System.EventHandler(this.MappingColumn);
            // 
            // buttonMapColumn
            // 
            this.buttonMapColumn.Image = global::TotalSmartCoding.Properties.Resources.Navigate_right;
            this.buttonMapColumn.Location = new System.Drawing.Point(483, 159);
            this.buttonMapColumn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonMapColumn.Name = "buttonMapColumn";
            this.buttonMapColumn.Size = new System.Drawing.Size(51, 55);
            this.buttonMapColumn.TabIndex = 13;
            this.buttonMapColumn.UseVisualStyleBackColor = true;
            this.buttonMapColumn.Click += new System.EventHandler(this.MappingColumn);
            // 
            // MapExcelColumn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 436);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.buttonUnMapColumn);
            this.Controls.Add(this.buttonMapColumn);
            this.Controls.Add(this.dataGridColumnMapping);
            this.Controls.Add(this.dataGridColumnAvailable);
            this.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MapExcelColumn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import";
            this.Load += new System.EventHandler(this.DialogMapExcelColumn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridColumnAvailable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridColumnMapping)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridColumnAvailable;
        private System.Windows.Forms.DataGridView dataGridColumnMapping;
        private System.Windows.Forms.Button buttonMapColumn;
        private System.Windows.Forms.Button buttonUnMapColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAvailableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMappingName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDisplayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton buttonCancel;
        private System.Windows.Forms.ToolStripButton buttonOK;
    }
}