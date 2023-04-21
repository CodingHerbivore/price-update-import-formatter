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
            btnSelectUpdateBook = new Button();
            btnSelectExportBook = new Button();
            lblSelectUpdateBook = new Label();
            txtUpdateBook = new TextBox();
            txtExportBook = new TextBox();
            lblExportBook = new Label();
            btnUpdatePrices = new Button();
            ofdUpdateBook = new OpenFileDialog();
            ofdExportBook = new OpenFileDialog();
            cmbPriceColumn = new ComboBox();
            lblContact = new Label();
            lblVersion = new Label();
            prgUpdateSpreadsheet = new ProgressBar();
            lblStatus = new Label();
            chkWarnExcessive = new CheckBox();
            lblPriceCol = new Label();
            SuspendLayout();
            // 
            // btnSelectUpdateBook
            // 
            btnSelectUpdateBook.Location = new Point(667, 55);
            btnSelectUpdateBook.Name = "btnSelectUpdateBook";
            btnSelectUpdateBook.Size = new Size(75, 23);
            btnSelectUpdateBook.TabIndex = 0;
            btnSelectUpdateBook.Text = "Select";
            btnSelectUpdateBook.UseVisualStyleBackColor = true;
            btnSelectUpdateBook.Click += btnSelectUpdateBook_Click;
            // 
            // btnSelectExportBook
            // 
            btnSelectExportBook.Location = new Point(667, 168);
            btnSelectExportBook.Name = "btnSelectExportBook";
            btnSelectExportBook.Size = new Size(75, 23);
            btnSelectExportBook.TabIndex = 1;
            btnSelectExportBook.Text = "Select";
            btnSelectExportBook.UseVisualStyleBackColor = true;
            btnSelectExportBook.Click += btnSelectExportBook_Click;
            // 
            // lblSelectUpdateBook
            // 
            lblSelectUpdateBook.AutoSize = true;
            lblSelectUpdateBook.Location = new Point(32, 28);
            lblSelectUpdateBook.Name = "lblSelectUpdateBook";
            lblSelectUpdateBook.Size = new Size(132, 15);
            lblSelectUpdateBook.TabIndex = 2;
            lblSelectUpdateBook.Text = "Price Update Workbook";
            // 
            // txtUpdateBook
            // 
            txtUpdateBook.Enabled = false;
            txtUpdateBook.Location = new Point(78, 55);
            txtUpdateBook.Name = "txtUpdateBook";
            txtUpdateBook.Size = new Size(571, 23);
            txtUpdateBook.TabIndex = 3;
            // 
            // txtExportBook
            // 
            txtExportBook.Enabled = false;
            txtExportBook.Location = new Point(78, 168);
            txtExportBook.Name = "txtExportBook";
            txtExportBook.Size = new Size(571, 23);
            txtExportBook.TabIndex = 4;
            // 
            // lblExportBook
            // 
            lblExportBook.AutoSize = true;
            lblExportBook.Location = new Point(32, 144);
            lblExportBook.Name = "lblExportBook";
            lblExportBook.Size = new Size(191, 15);
            lblExportBook.TabIndex = 5;
            lblExportBook.Text = "BigCommerce Exported Workbook";
            // 
            // btnUpdatePrices
            // 
            btnUpdatePrices.Location = new Point(324, 236);
            btnUpdatePrices.Name = "btnUpdatePrices";
            btnUpdatePrices.Size = new Size(125, 35);
            btnUpdatePrices.TabIndex = 6;
            btnUpdatePrices.Text = "Update Pricing";
            btnUpdatePrices.UseVisualStyleBackColor = true;
            btnUpdatePrices.Click += btnUpdatePrices_Click;
            // 
            // ofdUpdateBook
            // 
            ofdUpdateBook.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm;*.csv;";
            ofdUpdateBook.Title = "Select Price Update Workbook";
            // 
            // ofdExportBook
            // 
            ofdExportBook.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm;*.csv;";
            ofdExportBook.Title = "Select Exported BigCommerce Workbook";
            // 
            // cmbPriceColumn
            // 
            cmbPriceColumn.Enabled = false;
            cmbPriceColumn.FormattingEnabled = true;
            cmbPriceColumn.Location = new Point(425, 84);
            cmbPriceColumn.Name = "cmbPriceColumn";
            cmbPriceColumn.Size = new Size(224, 23);
            cmbPriceColumn.TabIndex = 7;
            // 
            // lblContact
            // 
            lblContact.AutoSize = true;
            lblContact.Location = new Point(227, 426);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(319, 15);
            lblContact.TabIndex = 9;
            lblContact.Text = "Email Andrew B. with bugs or issues: abullis@jmesales.com";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(714, 426);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(72, 15);
            lblVersion.TabIndex = 12;
            lblVersion.Text = "version 1.3.0";
            // 
            // prgUpdateSpreadsheet
            // 
            prgUpdateSpreadsheet.Enabled = false;
            prgUpdateSpreadsheet.Location = new Point(71, 315);
            prgUpdateSpreadsheet.Name = "prgUpdateSpreadsheet";
            prgUpdateSpreadsheet.Size = new Size(631, 23);
            prgUpdateSpreadsheet.TabIndex = 13;
            prgUpdateSpreadsheet.Visible = false;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.Location = new Point(261, 343);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(250, 15);
            lblStatus.TabIndex = 14;
            lblStatus.Text = "Status";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            lblStatus.Visible = false;
            // 
            // chkWarnExcessive
            // 
            chkWarnExcessive.AutoSize = true;
            chkWarnExcessive.Checked = true;
            chkWarnExcessive.CheckState = CheckState.Checked;
            chkWarnExcessive.Enabled = false;
            chkWarnExcessive.Location = new Point(451, 197);
            chkWarnExcessive.Name = "chkWarnExcessive";
            chkWarnExcessive.Size = new Size(198, 19);
            chkWarnExcessive.TabIndex = 15;
            chkWarnExcessive.Text = "Warn on price changes over 25%";
            chkWarnExcessive.UseVisualStyleBackColor = true;
            // 
            // lblPriceCol
            // 
            lblPriceCol.AutoSize = true;
            lblPriceCol.Location = new Point(341, 86);
            lblPriceCol.Name = "lblPriceCol";
            lblPriceCol.Size = new Size(82, 15);
            lblPriceCol.TabIndex = 16;
            lblPriceCol.Text = "Price Column:";
            // 
            // FrmPriceUpdate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblPriceCol);
            Controls.Add(chkWarnExcessive);
            Controls.Add(lblStatus);
            Controls.Add(prgUpdateSpreadsheet);
            Controls.Add(lblVersion);
            Controls.Add(lblContact);
            Controls.Add(cmbPriceColumn);
            Controls.Add(btnUpdatePrices);
            Controls.Add(lblExportBook);
            Controls.Add(txtExportBook);
            Controls.Add(txtUpdateBook);
            Controls.Add(lblSelectUpdateBook);
            Controls.Add(btnSelectExportBook);
            Controls.Add(btnSelectUpdateBook);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmPriceUpdate";
            Text = "JME Price Update Import Generator";
            ResumeLayout(false);
            PerformLayout();
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
        private Label lblContact;
        private Label lblVersion;
        private ProgressBar prgUpdateSpreadsheet;
        private Label lblStatus;
        private CheckBox chkWarnExcessive;
        private Label lblPriceCol;
    }
}