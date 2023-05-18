namespace CarsDataBase
{
    partial class frmSearch
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
            this.frmDataGrid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ValueTextbox = new System.Windows.Forms.TextBox();
            this.cboOperator = new System.Windows.Forms.ComboBox();
            this.cboField = new System.Windows.Forms.ComboBox();
            this.frmValueLabel = new System.Windows.Forms.Label();
            this.frmOperatorLabel = new System.Windows.Forms.Label();
            this.frmFieldLabel = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.frmDataGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmDataGrid
            // 
            this.frmDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.frmDataGrid.Location = new System.Drawing.Point(24, 180);
            this.frmDataGrid.Name = "frmDataGrid";
            this.frmDataGrid.RowHeadersWidth = 62;
            this.frmDataGrid.RowTemplate.Height = 28;
            this.frmDataGrid.Size = new System.Drawing.Size(729, 157);
            this.frmDataGrid.TabIndex = 0;
            this.frmDataGrid.Click += new System.EventHandler(this.frmDataGrid_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ValueTextbox);
            this.panel1.Controls.Add(this.cboOperator);
            this.panel1.Controls.Add(this.cboField);
            this.panel1.Controls.Add(this.frmValueLabel);
            this.panel1.Controls.Add(this.frmOperatorLabel);
            this.panel1.Controls.Add(this.frmFieldLabel);
            this.panel1.Location = new System.Drawing.Point(24, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(595, 149);
            this.panel1.TabIndex = 1;
            // 
            // ValueTextbox
            // 
            this.ValueTextbox.Location = new System.Drawing.Point(396, 83);
            this.ValueTextbox.Name = "ValueTextbox";
            this.ValueTextbox.Size = new System.Drawing.Size(100, 26);
            this.ValueTextbox.TabIndex = 5;
            // 
            // cboOperator
            // 
            this.cboOperator.FormattingEnabled = true;
            this.cboOperator.Location = new System.Drawing.Point(220, 81);
            this.cboOperator.Name = "cboOperator";
            this.cboOperator.Size = new System.Drawing.Size(121, 28);
            this.cboOperator.TabIndex = 4;
            this.cboOperator.Click += new System.EventHandler(this.cboOperator_SelectedIndexChanged);
            // 
            // cboField
            // 
            this.cboField.FormattingEnabled = true;
            this.cboField.Location = new System.Drawing.Point(38, 82);
            this.cboField.Name = "cboField";
            this.cboField.Size = new System.Drawing.Size(121, 28);
            this.cboField.TabIndex = 3;
            this.cboField.Click += new System.EventHandler(this.cboField_SelectedIndexChanged);
            // 
            // frmValueLabel
            // 
            this.frmValueLabel.AutoSize = true;
            this.frmValueLabel.Location = new System.Drawing.Point(392, 34);
            this.frmValueLabel.Name = "frmValueLabel";
            this.frmValueLabel.Size = new System.Drawing.Size(50, 20);
            this.frmValueLabel.TabIndex = 2;
            this.frmValueLabel.Text = "Value";
            // 
            // frmOperatorLabel
            // 
            this.frmOperatorLabel.AutoSize = true;
            this.frmOperatorLabel.Location = new System.Drawing.Point(216, 34);
            this.frmOperatorLabel.Name = "frmOperatorLabel";
            this.frmOperatorLabel.Size = new System.Drawing.Size(72, 20);
            this.frmOperatorLabel.TabIndex = 1;
            this.frmOperatorLabel.Text = "Operator";
            // 
            // frmFieldLabel
            // 
            this.frmFieldLabel.AutoSize = true;
            this.frmFieldLabel.Location = new System.Drawing.Point(34, 34);
            this.frmFieldLabel.Name = "frmFieldLabel";
            this.frmFieldLabel.Size = new System.Drawing.Size(43, 20);
            this.frmFieldLabel.TabIndex = 0;
            this.frmFieldLabel.Text = "Field";
            // 
            // btnRun
            // 
            this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.Location = new System.Drawing.Point(625, 12);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(130, 74);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(625, 87);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(130, 74);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 362);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.frmDataGrid);
            this.Name = "frmSearch";
            this.Text = "Task A Search";
            this.Click += new System.EventHandler(this.frmSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.frmDataGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView frmDataGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label frmOperatorLabel;
        private System.Windows.Forms.Label frmFieldLabel;
        private System.Windows.Forms.Label frmValueLabel;
        private System.Windows.Forms.ComboBox cboField;
        private System.Windows.Forms.ComboBox cboOperator;
        private System.Windows.Forms.TextBox ValueTextbox;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnClose;
    }
}