namespace JME_Price_Update
{
    partial class FrmPriceUpdate
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPriceUpdate));
            this.btnSelectUpdateBook = new System.Windows.Forms.Button();
            this.btnSelectExportBook = new System.Windows.Forms.Button();
            this.lblSelectUpdateBook = new System.Windows.Forms.Label();
            this.txtUpdateBook = new System.Windows.Forms.TextBox();
            this.txtExportBook = new System.Windows.Forms.TextBox();
            this.lblExportBook = new System.Windows.Forms.Label();
            this.btnUpdatePrices = new System.Windows.Forms.Button();
            this.ofdUpdateBook = new System.Windows.Forms.OpenFileDialog();
            this.ofdExportBook = new System.Windows.Forms.OpenFileDialog();
            this.cmbPriceColumn = new System.Windows.Forms.ComboBox();
            this.lblWarning = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.prgUpdateSpreadsheet = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSelectUpdateBook
            // 
            this.btnSelectUpdateBook.Location = new System.Drawing.Point(667, 55);
            this.btnSelectUpdateBook.Name = "btnSelectUpdateBook";
            this.btnSelectUpdateBook.Size = new System.Drawing.Size(75, 23);
            this.btnSelectUpdateBook.TabIndex = 0;
            this.btnSelectUpdateBook.Text = "Select";
            this.btnSelectUpdateBook.UseVisualStyleBackColor = true;
            this.btnSelectUpdateBook.Click += new System.EventHandler(this.btnSelectUpdateBook_Click);
            // 
            // btnSelectExportBook
            // 
            this.btnSelectExportBook.Location = new System.Drawing.Point(667, 168);
            this.btnSelectExportBook.Name = "btnSelectExportBook";
            this.btnSelectExportBook.Size = new System.Drawing.Size(75, 20);
            this.btnSelectExportBook.TabIndex = 1;
            this.btnSelectExportBook.Text = "Select";
            this.btnSelectExportBook.UseVisualStyleBackColor = true;
            this.btnSelectExportBook.Click += new System.EventHandler(this.btnSelectExportBook_Click);
            // 
            // lblSelectUpdateBook
            // 
            this.lblSelectUpdateBook.AutoSize = true;
            this.lblSelectUpdateBook.Location = new System.Drawing.Point(32, 28);
            this.lblSelectUpdateBook.Name = "lblSelectUpdateBook";
            this.lblSelectUpdateBook.Size = new System.Drawing.Size(132, 15);
            this.lblSelectUpdateBook.TabIndex = 2;
            this.lblSelectUpdateBook.Text = "Price Update Workbook";
            // 
            // txtUpdateBook
            // 
            this.txtUpdateBook.Enabled = false;
            this.txtUpdateBook.Location = new System.Drawing.Point(78, 55);
            this.txtUpdateBook.Name = "txtUpdateBook";
            this.txtUpdateBook.Size = new System.Drawing.Size(571, 23);
            this.txtUpdateBook.TabIndex = 3;
            // 
            // txtExportBook
            // 
            this.txtExportBook.Enabled = false;
            this.txtExportBook.Location = new System.Drawing.Point(78, 168);
            this.txtExportBook.Name = "txtExportBook";
            this.txtExportBook.Size = new System.Drawing.Size(571, 23);
            this.txtExportBook.TabIndex = 4;
            // 
            // lblExportBook
            // 
            this.lblExportBook.AutoSize = true;
            this.lblExportBook.Location = new System.Drawing.Point(32, 144);
            this.lblExportBook.Name = "lblExportBook";
            this.lblExportBook.Size = new System.Drawing.Size(191, 15);
            this.lblExportBook.TabIndex = 5;
            this.lblExportBook.Text = "BigCommerce Exported Workbook";
            // 
            // btnUpdatePrices
            // 
            this.btnUpdatePrices.Location = new System.Drawing.Point(324, 236);
            this.btnUpdatePrices.Name = "btnUpdatePrices";
            this.btnUpdatePrices.Size = new System.Drawing.Size(125, 35);
            this.btnUpdatePrices.TabIndex = 6;
            this.btnUpdatePrices.Text = "Update Pricing";
            this.btnUpdatePrices.UseVisualStyleBackColor = true;
            this.btnUpdatePrices.Click += new System.EventHandler(this.btnUpdatePrices_Click);
            // 
            // ofdUpdateBook
            // 
            this.ofdUpdateBook.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm;*.csv;";
            this.ofdUpdateBook.Title = "Select Price Update Workbook";
            // 
            // ofdExportBook
            // 
            this.ofdExportBook.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm;*.csv;";
            this.ofdExportBook.Title = "Select Exported BigCommerce Workbook";
            // 
            // cmbPriceColumn
            // 
            this.cmbPriceColumn.Enabled = false;
            this.cmbPriceColumn.FormattingEnabled = true;
            this.cmbPriceColumn.Location = new System.Drawing.Point(425, 84);
            this.cmbPriceColumn.Name = "cmbPriceColumn";
            this.cmbPriceColumn.Size = new System.Drawing.Size(224, 23);
            this.cmbPriceColumn.TabIndex = 7;
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Location = new System.Drawing.Point(94, 394);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(585, 15);
            this.lblWarning.TabIndex = 8;
            this.lblWarning.Text = "TESTING VERSION: This software is pre-release test version. Use at your own risk," +
    " your safety is not guaranteed.";
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Location = new System.Drawing.Point(227, 426);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(319, 15);
            this.lblContact.TabIndex = 9;
            this.lblContact.Text = "Email Andrew B. with bugs or issues: abullis@jmesales.com";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(725, 426);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(63, 15);
            this.lblVersion.TabIndex = 12;
            this.lblVersion.Text = "version 0.4";
            // 
            // prgUpdateSpreadsheet
            // 
            this.prgUpdateSpreadsheet.Enabled = false;
            this.prgUpdateSpreadsheet.Location = new System.Drawing.Point(71, 315);
            this.prgUpdateSpreadsheet.Name = "prgUpdateSpreadsheet";
            this.prgUpdateSpreadsheet.Size = new System.Drawing.Size(631, 23);
            this.prgUpdateSpreadsheet.TabIndex = 13;
            this.prgUpdateSpreadsheet.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.Location = new System.Drawing.Point(261, 343);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(250, 15);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.Visible = false;
            // 
            // FrmPriceUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.prgUpdateSpreadsheet);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.cmbPriceColumn);
            this.Controls.Add(this.btnUpdatePrices);
            this.Controls.Add(this.lblExportBook);
            this.Controls.Add(this.txtExportBook);
            this.Controls.Add(this.txtUpdateBook);
            this.Controls.Add(this.lblSelectUpdateBook);
            this.Controls.Add(this.btnSelectExportBook);
            this.Controls.Add(this.btnSelectUpdateBook);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPriceUpdate";
            this.Text = "JME Price Update Import Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnSelectUpdateBook;
        private Button btnSelectExportBook;
        private Label lblSelectUpdateBook;
        private TextBox txtUpdateBook;
        private TextBox txtExportBook;
        private Label lblExportBook;
        private Button btnUpdatePrices;
        private OpenFileDialog ofdUpdateBook;
        private OpenFileDialog ofdExportBook;
        private ComboBox cmbPriceColumn;
        private Label lblWarning;
        private Label lblContact;
        private Label lblVersion;
        private ProgressBar prgUpdateSpreadsheet;
        private Label lblStatus;
    }
}