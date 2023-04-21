using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Xml;

namespace JME_Price_Update;

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
        /* If the combo box is enabled, it means that the user selected the wrong sheet and is 
         * selecting a different one. This check fixes a bug where it stacked up columns from
         * multiple sheets.*/
        if (cmbPriceColumn.Enabled == true)
        {
            ClearComboBox();
        }

        if (ofdUpdateBook.ShowDialog() == DialogResult.OK)
        {
            // Display the file path in the text box
            txtUpdateBook.Text = ofdUpdateBook.FileName;

            // Assign the file to a variable
            string UpdateBook = ofdUpdateBook.FileName;

            try
            {
                oXL = new Excel.Application();
                oWB = oXL.Workbooks.Open(UpdateBook);
                oSheet = oWB.Worksheets[1];
                oRng = oSheet.UsedRange;
                string foundPriceCol = "";

                // Get column headers and stick them in the combo box
                // I don't know why, but this only works if the condition is "i < whatevs", so that's why I'm adding 1
                for (int i = 1; i < oRng.Columns.Count + 1; i++)
                {
                    string oAddress = oRng.Cells[1, i].Address[false, false, Excel.XlReferenceStyle.xlA1];
                    string PriceColumnOption = oAddress + ": " + oRng.Cells[1, i].Value;

                    // Check to see if this is a price column. If so, set it as our found price column
                    if (PriceColumnOption.ToLower().IndexOf(": price") != -1)
                    {
                        foundPriceCol = PriceColumnOption;
                    }

                    cmbPriceColumn.Items.Add(PriceColumnOption);
                }

                // Activate the combobox
                cmbPriceColumn.Enabled = true;

                // Automagically set the price column if we found one.
                if (foundPriceCol != "")
                {
                    // Check if the option for Price
                    cmbPriceColumn.SelectedItem = foundPriceCol;
                }
                else
                {
                    cmbPriceColumn.Text = "Select Price Column...";
                }

                // Close our spreadsheet                
                GC.Collect();
                GC.WaitForPendingFinalizers();

                Marshal.ReleaseComObject(oRng);
                Marshal.ReleaseComObject(oSheet);

                oWB.Close();
                Marshal.ReleaseComObject(oWB);
                oXL.Quit();
                Marshal.ReleaseComObject(oXL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                MessageBox.Show("You may need to kill Excel from Windows Task Manager to unlock the workbooks");
            }

        }
    }

    private void btnSelectExportBook_Click(object sender, EventArgs e)
    {
        if (ofdExportBook.ShowDialog() == DialogResult.OK)
        {
            // Display the file path in the txt box
            txtExportBook.Text = ofdExportBook.FileName;

            // Assign the file to a variable
            string ExportBook = ofdExportBook.FileName;
            chkWarnExcessive.Enabled = true;
        }
    }

    private void btnUpdatePrices_Click(object sender, EventArgs e)
    {
        string errorMessage = null;

        if (txtUpdateBook.Text == "")
        {
            errorMessage = string.Concat(errorMessage, "You must select the workbook with the price updates.\n");
        }

        if (cmbPriceColumn.SelectedIndex == -1)
        {
            errorMessage = string.Concat(errorMessage, "You must select the column with the price.\n");
        }

        if (txtExportBook.Text == "")
        {
            errorMessage = string.Concat(errorMessage, "You must select the exported workbook from BigCommerce. ");
        }
        if (txtExportBook.Text == txtUpdateBook.Text)
        {
            errorMessage = string.Concat(errorMessage, "\n" + "The workbooks cannot be the same. Select a different update or export workbook.");
        }
        if (errorMessage != null)
        {
            MessageBox.Show(errorMessage);
        }
        else
        {
            btnUpdatePrices.Enabled = false;

            UpdatePrice();

            // Clean up
            txtUpdateBook.Text = "";

            ClearComboBox();

            txtExportBook.Text = "";
            prgUpdateSpreadsheet.Visible = false;
            prgUpdateSpreadsheet.Enabled = false;
            btnUpdatePrices.Enabled = true;
            chkWarnExcessive.Enabled = false;
            lblStatus.Visible = false;
        }
    }

    private void UpdatePrice()
    {
        string uwbPath = txtUpdateBook.Text;
        string ewbPath = txtExportBook.Text;

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
            int actualUpdateRows = howManyRows(uSheet, uRng, prgUpdateSpreadsheet, lblStatus, "Counting Update Sheet Rows");
            int actualRows = howManyRows(eSheet, eRng, prgUpdateSpreadsheet, lblStatus, "Counting Export Sheet Rows");

            // Setup progress bar
            prgUpdateSpreadsheet.Enabled = true;
            prgUpdateSpreadsheet.Minimum = 1;
            prgUpdateSpreadsheet.Maximum = actualRows - 1;
            prgUpdateSpreadsheet.Visible = true;
            prgUpdateSpreadsheet.Value = 1;
            prgUpdateSpreadsheet.Step = 1;
            lblStatus.Visible = true;
            lblStatus.Text = "Updating Prices";

            // Get the user-selected price column and add 1 since Excel isn't zero-based
            int priceColumn = cmbPriceColumn.SelectedIndex + 1;

            // Working with the Update workbook
            // Create dictionary of part numbers and prices from the update workbook
            var uPrices = new Dictionary<string, string>();

            for (int i = 1; i < actualUpdateRows + 1; i++)
            {

                string SKU = uRng.Cells[i, 1].Value.ToString();
                string uPrice = "";
                /* Excel errors are for some reason stored as integers, which don't get caught.
                 * We need to account for them, otherwise they pop up as prices */
                if (uRng.Cells[i, priceColumn].Value is Int32)
                {
                    uPrice = "Excel Error - have pricing check their formula";
                }
                else
                {
                    uPrice = uRng.Cells[i, priceColumn].Value.ToString();
                }

                // Adding a SKU that already exists will fail, so we check to ensure it isn't there.
                bool skuExists = uPrices.ContainsKey(SKU);
                if (!skuExists)
                {
                    uPrices.Add(SKU, uPrice);
                }
                else
                {
                    continue;
                }
            }

            // Working with the Exported workbook
            for (int i = 2; i < actualRows + 1; i++)
            {
                string SKU = eRng.Cells[i, 3].Value;
                string currentPrice = "";
                string nPrice = "";
                string nMessage = "";

                if (eRng.Cells[i, 6].Value != null)
                {
                    currentPrice = eRng.Cells[i, 6].Value.ToString();
                }

                // Check if there's anything in the part number column, if not then skip
                if (SKU == null)
                {
                    if (eRng.Cells[i, 1].Value == "Product")
                    {
                        // Create list to hold family member prices
                        List<double> myFamily = new List<double>();

                        // Get children
                        for (int j = i + 1; j < actualRows + 1; j++)
                        {
                            string cellValue = eRng.Cells[j, 1].Value;
                            cellValue = cellValue.Trim();

                            if (cellValue == "SKU")
                            {
                                continue;
                            }
                            else if (cellValue == "Rule")
                            {
                                // grab the price and then add it to a list
                                String childSKU = eRng.Cells[j, 4].Value;
                                if (childSKU != null)
                                {
                                    if (uPrices.ContainsKey(childSKU))
                                    {
                                        // "Call for pricing" and "Not Found" don't count, so we need to go past them                                    
                                        if (canParse(uPrices[childSKU]))
                                        {
                                            // Price comes over as a string, but we need it to be a double
                                            double childPrice = Convert.ToDouble(uPrices[childSKU], CultureInfo.InvariantCulture);
                                            myFamily.Add(childPrice);
                                        }
                                        else
                                        {
                                            if (currentPrice == "")
                                            {
                                                continue;
                                            }
                                            else if (currentPrice.Contains("[FIXED]"))
                                            {
                                                currentPrice = currentPrice.Replace("[FIXED]", "");
                                                double currentChildPrice = Convert.ToDouble(currentPrice, CultureInfo.InvariantCulture);
                                                myFamily.Add(currentChildPrice);
                                            }
                                            else
                                            {
                                                continue;
                                            }
                                        }
                                    }
                                }
                            }
                            else if (cellValue == "Product")
                            {
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }

                        if (myFamily.Count > 0)
                        {
                            double minPrice = myFamily.Min();
                            nPrice = minPrice.ToString();
                        }
                        else
                        {
                            nPrice = currentPrice;
                            nMessage = "No child has new Price";
                            eRng.Cells[i, 18].Value = nMessage;
                            eRng.Cells[i, 18].Interior.Color = Excel.XlRgbColor.rgbYellow;
                        }

                        // Write value to spreadsheet
                        eRng.Cells[i, 17].Value = nPrice;

                        /*PartNums = String.Concat(PartNums, "Parent");
                        PartNums = String.Concat(PartNums, ", " + nPrice);
                        PartNums = String.Concat(PartNums, "\n");*/

                        updateProgressBar();
                        continue;
                    }
                    else
                    {
                        updateProgressBar();
                        continue;
                    }
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
                if (uPrices.ContainsKey(SKU))
                {
                    nPrice = uPrices[SKU];
                }
                else
                {
                    nPrice = currentPrice;
                    nMessage = "Not Found";
                    eRng.Cells[i, 17].Value = nPrice;
                    eRng.Cells[i, 18].Value = nMessage;
                    eRng.Cells[i, 18].Interior.Color = Excel.XlRgbColor.rgbYellow;
                    updateProgressBar();
                    continue;
                }

                // Change background color to red if nPrice isn't a number (if it's CFP or whatevs)
                if (!canParse(nPrice))
                {

                    nMessage = nPrice;
                    eRng.Cells[i, 18].Interior.Color = Excel.XlRgbColor.rgbRed;
                    eRng.Cells[i, 18].Value = nMessage;
                    eRng.Cells[i, 17].Value = currentPrice;
                    continue;
                }
                else
                {
                    // Warn if price difference is greater than 25%
                    if (chkWarnExcessive.Checked)
                    {
                        // Price comes over as a string, but we need it to be a double
                        double nPriceDbl = Convert.ToDouble(nPrice, CultureInfo.InvariantCulture);

                        if (currentPrice.Contains("[FIXED]"))
                        {
                            currentPrice = currentPrice.Replace("[FIXED]", "");
                        }

                        if (canParse(currentPrice))
                        {
                            // Price comes over as a string, but we need it to be a double
                            double currentPriceDbl = Convert.ToDouble(currentPrice, CultureInfo.InvariantCulture);

                            if (Math.Abs((nPriceDbl - currentPriceDbl) / currentPriceDbl) > 0.25)
                            {
                                nMessage = nMessage + "Excessive Change!";
                                eRng.Cells[i, 18].Interior.Color = Excel.XlRgbColor.rgbOrange;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }

                    // Write value to spreadsheet
                    string prodType = eRng.Cells[i, 1].Value;
                    prodType = prodType.Trim();
                    if (prodType == "Rule")
                    {
                        eRng.Cells[i, 17].Value = "[FIXED]" + nPrice;
                    }
                    else
                    {
                        eRng.Cells[i, 17].Value = nPrice;
                    }
                    eRng.Cells[i, 18].Value = nMessage;
                }

                updateProgressBar();
            }

            // Close our spreadsheet                
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Marshal.ReleaseComObject(uRng);
            Marshal.ReleaseComObject(eRng);
            Marshal.ReleaseComObject(uSheet);
            Marshal.ReleaseComObject(eSheet);
            uWB.Save();
            uWB.Close();
            Marshal.ReleaseComObject(uWB);
            eWB.Save();
            eWB.Close();
            Marshal.ReleaseComObject(eWB);
            oXL.Quit();
            Marshal.ReleaseComObject(oXL);

            MessageBox.Show("Spreadsheet updated");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex);
            MessageBox.Show("You may need to kill Excel from Windows Task Manager to unlock the workbooks");
        }
    }

    private void updateProgressBar()
    {
        // Increment progress bar
        prgUpdateSpreadsheet.PerformStep();
    }

    // Get the actual number of rows used (eliminates previously-used-but-now-empty cells)
    public static int howManyRows(Excel._Worksheet Sheet, Excel.Range Rng, ProgressBar prgUpdateSpreadsheet, Label lblStatus, string userMsg)
    {
        int rows = 0;

        // Setup progress bar
        prgUpdateSpreadsheet.Enabled = true;
        prgUpdateSpreadsheet.Minimum = 1;
        prgUpdateSpreadsheet.Maximum = Rng.Columns["A:A", Type.Missing].Rows.Count;
        prgUpdateSpreadsheet.Visible = true;
        prgUpdateSpreadsheet.Value = 1;
        prgUpdateSpreadsheet.Step = 1;
        lblStatus.Visible = true;

        for (int i = 1; i < Rng.Columns["A:A", Type.Missing].Rows.Count + 1; i++)
        {
            lblStatus.Text = userMsg;
            if (Rng.Cells[i, 1].Value == null)
            {
                break;
            }
            rows++;
            prgUpdateSpreadsheet.PerformStep();
        }

        prgUpdateSpreadsheet.Visible = false;
        prgUpdateSpreadsheet.Enabled = false;
        lblStatus.Visible = false;

        return rows;

    }

    private void ClearComboBox()
    {
        cmbPriceColumn.Items.Clear();
        cmbPriceColumn.Text = "";
        cmbPriceColumn.Enabled = false;
    }

    public static bool canParse(string doubleMe)
    {
        Double testDouble = 0;
        bool parsable = double.TryParse(doubleMe, out testDouble);
        return parsable;
    }

    private void CloseWorkbooks(Excel._Workbook uWB, Excel._Workbook eWB)
    {

    }
}