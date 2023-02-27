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
            btnSelectUpdateBook.Location = new Point(762, 70);
            btnSelectUpdateBook.Margin = new Padding(3, 4, 3, 4);
            btnSelectUpdateBook.Name = "btnSelectUpdateBook";
            btnSelectUpdateBook.Size = new Size(86, 29);
            btnSelectUpdateBook.TabIndex = 0;
            btnSelectUpdateBook.Text = "Select";
            btnSelectUpdateBook.UseVisualStyleBackColor = true;
            btnSelectUpdateBook.Click += btnSelectUpdateBook_Click;
            // 
            // btnSelectExportBook
            // 
            btnSelectExportBook.Location = new Point(762, 213);
            btnSelectExportBook.Margin = new Padding(3, 4, 3, 4);
            btnSelectExportBook.Name = "btnSelectExportBook";
            btnSelectExportBook.Size = new Size(86, 29);
            btnSelectExportBook.TabIndex = 1;
            btnSelectExportBook.Text = "Select";
            btnSelectExportBook.UseVisualStyleBackColor = true;
            btnSelectExportBook.Click += btnSelectExportBook_Click;
            // 
            // lblSelectUpdateBook
            // 
            lblSelectUpdateBook.AutoSize = true;
            lblSelectUpdateBook.Location = new Point(37, 35);
            lblSelectUpdateBook.Name = "lblSelectUpdateBook";
            lblSelectUpdateBook.Size = new Size(154, 19);
            lblSelectUpdateBook.TabIndex = 2;
            lblSelectUpdateBook.Text = "Price Update Workbook";
            // 
            // txtUpdateBook
            // 
            txtUpdateBook.Enabled = false;
            txtUpdateBook.Location = new Point(89, 70);
            txtUpdateBook.Margin = new Padding(3, 4, 3, 4);
            txtUpdateBook.Name = "txtUpdateBook";
            txtUpdateBook.Size = new Size(652, 26);
            txtUpdateBook.TabIndex = 3;
            // 
            // txtExportBook
            // 
            txtExportBook.Enabled = false;
            txtExportBook.Location = new Point(89, 213);
            txtExportBook.Margin = new Padding(3, 4, 3, 4);
            txtExportBook.Name = "txtExportBook";
            txtExportBook.Size = new Size(652, 26);
            txtExportBook.TabIndex = 4;
            // 
            // lblExportBook
            // 
            lblExportBook.AutoSize = true;
            lblExportBook.Location = new Point(37, 182);
            lblExportBook.Name = "lblExportBook";
            lblExportBook.Size = new Size(219, 19);
            lblExportBook.TabIndex = 5;
            lblExportBook.Text = "BigCommerce Exported Workbook";
            // 
            // btnUpdatePrices
            // 
            btnUpdatePrices.Location = new Point(370, 299);
            btnUpdatePrices.Margin = new Padding(3, 4, 3, 4);
            btnUpdatePrices.Name = "btnUpdatePrices";
            btnUpdatePrices.Size = new Size(143, 44);
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
            cmbPriceColumn.Location = new Point(486, 106);
            cmbPriceColumn.Margin = new Padding(3, 4, 3, 4);
            cmbPriceColumn.Name = "cmbPriceColumn";
            cmbPriceColumn.Size = new Size(255, 27);
            cmbPriceColumn.TabIndex = 7;
            // 
            // lblContact
            // 
            lblContact.AutoSize = true;
            lblContact.Location = new Point(259, 540);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(366, 19);
            lblContact.TabIndex = 9;
            lblContact.Text = "Email Andrew B. with bugs or issues: abullis@jmesales.com";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(816, 540);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(87, 19);
            lblVersion.TabIndex = 12;
            lblVersion.Text = "version 1.2.3";
            // 
            // prgUpdateSpreadsheet
            // 
            prgUpdateSpreadsheet.Enabled = false;
            prgUpdateSpreadsheet.Location = new Point(81, 399);
            prgUpdateSpreadsheet.Margin = new Padding(3, 4, 3, 4);
            prgUpdateSpreadsheet.Name = "prgUpdateSpreadsheet";
            prgUpdateSpreadsheet.Size = new Size(721, 29);
            prgUpdateSpreadsheet.TabIndex = 13;
            prgUpdateSpreadsheet.Visible = false;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.Location = new Point(298, 434);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(286, 19);
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
            chkWarnExcessive.Location = new Point(515, 250);
            chkWarnExcessive.Margin = new Padding(3, 4, 3, 4);
            chkWarnExcessive.Name = "chkWarnExcessive";
            chkWarnExcessive.Size = new Size(229, 23);
            chkWarnExcessive.TabIndex = 15;
            chkWarnExcessive.Text = "Warn on price changes over 25%";
            chkWarnExcessive.UseVisualStyleBackColor = true;
            // 
            // lblPriceCol
            // 
            lblPriceCol.AutoSize = true;
            lblPriceCol.Location = new Point(390, 109);
            lblPriceCol.Name = "lblPriceCol";
            lblPriceCol.Size = new Size(93, 19);
            lblPriceCol.TabIndex = 16;
            lblPriceCol.Text = "Price Column:";
            // 
            // FrmPriceUpdate
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 570);
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
            Margin = new Padding(3, 4, 3, 4);
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