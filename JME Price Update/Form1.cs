using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
namespace JME_Price_Update
{
    public partial class FrmPriceUpdate : Form
    {
        Excel.Application oXL;
        Excel._Workbook oWB;
        Excel._Worksheet oSheet;
        Excel.Range oRng;

        public FrmPriceUpdate()
        {
            InitializeComponent();
        }

        private void btnSelectUpdateBook_Click(object sender, EventArgs e)
        {
            if (ofdUpdateBook.ShowDialog() == DialogResult.OK)
            {
                // Display the file path in the text box
                txtUpdateBook.Text = ofdUpdateBook.FileName;

                // Assign the file to a variable
                String UpdateBook = ofdUpdateBook.FileName;

                try
                {
                    oXL = new Excel.Application();
                    oWB = oXL.Workbooks.Open(UpdateBook);
                    oSheet = oWB.Worksheets[1];
                    oRng = oSheet.UsedRange;

                    // Get column headers and stick them in the combo box
                    // I don't know why, but this only works if the condition is "i < whatevs", so that's why I'm adding 1
                    for (int i = 1; i < oRng.Columns.Count + 1; i++)
                    {
                        string oAddress = oRng.Cells[1, i].Address[false, false, Excel.XlReferenceStyle.xlA1];
                        string PriceColumnOption = oAddress + ": " + oRng.Cells[1, i].Value;

                        cmbPriceColumn.Items.Add(PriceColumnOption);
                    }

                    // Activate the combobox
                    cmbPriceColumn.Enabled = true;
                    cmbPriceColumn.Text = "Select Price Column...";

                    // Close our spreadsheet
                    oWB.Close();
                    oXL = null;
                    oWB = null;
                    oSheet = null;
                    oRng = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex );
                }
              
            }
        }

        private void btnSelectExportBook_Click(object sender, EventArgs e)
        {
            if(ofdExportBook.ShowDialog() == DialogResult.OK)
            {
                // Display the file path in the txt box
                txtExportBook.Text = ofdExportBook.FileName;

                // Assign the file to a variable
                String ExportBook = ofdExportBook.FileName;

            }
        }

        private void btnUpdatePrices_Click(object sender, EventArgs e)
        {
            String errorMessage = null;

            if (txtUpdateBook.Text == "")
            {
                errorMessage = String.Concat(errorMessage, "You must select the workbook with the price updates.\n");
            }

            //if (cmbPriceColumn.SelectedValue == null)
            //{
            //    errorMessage = String.Concat(errorMessage, "You must select the column with the price.\n");
            //}

            if (txtExportBook.Text == "" )
            {
                errorMessage = String.Concat(errorMessage, "You must select the exported workbook from BigCommerce. ");
            }

            if (errorMessage != null)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                UpdatePrice();
            }
        }

        private void UpdatePrice()
        {
            String uwbPath = txtUpdateBook.Text;
            String ewbPath = txtExportBook.Text;

            Excel._Workbook uWB;
            Excel._Worksheet uSheet;
            Excel.Range uRng;
            Excel._Workbook eWB;
            Excel._Worksheet eSheet;
            Excel.Range eRng;

            try
            {
                oXL = new Excel.Application();
                uWB = oXL.Workbooks.Open(uwbPath);
                eWB = oXL.Workbooks.Open(ewbPath);
                uSheet = uWB.Worksheets[1];
                eSheet = eWB.Worksheets[1];
                uRng = uSheet.UsedRange;
                eRng = eSheet.UsedRange;


                String PartNums = "";
                for (int i = 1; i < eRng.Columns["D:D", Type.Missing].Rows.Count + 1; i++)
                {
                    String SKU = eRng.Cells[i, 4].Value;

                    // The UsedRange property includes cells that have been used in the past but are now empty, so we don't want to include those
                    if (SKU == null)
                    {
                        break;
                    }
                    
                    // Clean part number
                    // Remove GRID_
                    if (SKU.Contains("GRID_"))
                    {
                        SKU = SKU.Replace("GRID_", "");
                    }
                    
                    // Remove lowercase letter indicating duplicate product
                    char lastLetter = SKU[SKU.Length - 1];

                    if (char.IsLower(lastLetter))
                    {
                        SKU = SKU.Remove(SKU.Length - 1);
                    }



                    // Compare part number with update workbook

                    PartNums = String.Concat(PartNums, SKU);
                    PartNums = String.Concat(PartNums, "\n");
                }
                
                
                
                MessageBox.Show(PartNums);
                CloseWorkbooks(uWB, eWB);

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }

            

            MessageBox.Show("Task failed successfully");
        }

        private void FamilyBuilder()
        {

        }

        private void CloseWorkbooks(Excel._Workbook uWB, Excel._Workbook eWB)
        {
            uWB.Close();
            eWB.Close();
        }
    }
}