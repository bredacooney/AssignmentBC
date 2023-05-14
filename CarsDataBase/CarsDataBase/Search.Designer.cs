namespace CarsDataBase
{
    partial class Search
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
            this.frmOperatorLabel = new System.Windows.Forms.Label();
            this.frmFieldLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.frmOperatorLabel);
            this.panel1.Controls.Add(this.frmFieldLabel);
            this.panel1.Location = new System.Drawing.Point(24, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(595, 149);
            this.panel1.TabIndex = 1;
            // 
            // frmOperatorLabel
            // 
            this.frmOperatorLabel.AutoSize = true;
            this.frmOperatorLabel.Location = new System.Drawing.Point(142, 34);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(283, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 362);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.frmDataGrid);
            this.Name = "Search";
            this.Text = "Task A Search";
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
        private System.Windows.Forms.Label label1;
    }
}