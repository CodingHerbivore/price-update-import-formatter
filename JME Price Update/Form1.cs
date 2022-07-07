using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
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
                oXL.Quit();
                oXL = null;
                oWB = null;
                oSheet = null;
                oRng = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex );
                MessageBox.Show("You may need to kill Excel from Windows Task Manager to unlock the workbooks");
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

        if (cmbPriceColumn.SelectedIndex == -1)
        {
            errorMessage = String.Concat(errorMessage, "You must select the column with the price.\n");
        }

        if (txtExportBook.Text == "" )
        {
            errorMessage = String.Concat(errorMessage, "You must select the exported workbook from BigCommerce. ");
        }
        if (txtExportBook.Text == txtUpdateBook.Text)
        {
            errorMessage = String.Concat(errorMessage, "\n" + "The workbooks cannot be the same. Select a different update or export workbook.");
        }
        if (errorMessage != null)
        {
            MessageBox.Show(errorMessage);
        }
        else
        {
            UpdatePrice();

            // Clean up
            txtUpdateBook.Text = "";
            cmbPriceColumn.Items.Clear();
            cmbPriceColumn.Text = "";
            cmbPriceColumn.Enabled = false;
            txtExportBook.Text = "";
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

            // Get the user-selected price column and add 1 since Excel isn't zero-based
            int priceColumn = cmbPriceColumn.SelectedIndex + 1;
            
            // Working with the Update workbook
            // Create dictionary of part numbers and prices from the update workbook
            var uPrices = new Dictionary<String, String>();
            
            for (int i = 1; i < uRng.Columns["A:A", Type.Missing].Rows.Count + 1; i++)
            {
                // The UsedRange property includes cells that have been used in the past but are now empty, so we don't want to include those
                if (uRng.Cells[i, 1].Value == null)
                {
                    break;
                }

                String SKU = uRng.Cells[i, 1].Value.ToString();
                String uPrice = uRng.Cells[i, priceColumn].Value.ToString();

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

            // DEBUG: remove when finished
            /* String updates = "";
            foreach (KeyValuePair<String,String> item in uPrices)
            {
                updates = String.Concat(updates, item);
                updates = String.Concat(updates, "\n");
            }
            MessageBox.Show(updates);*/

            // Working with the Exported workbook
            String PartNums = "";
            for (int i = 2; i < eRng.Columns["D:D", Type.Missing].Rows.Count + 1; i++)
            {
                String SKU = eRng.Cells[i, 4].Value;
                String currentPrice = "";
                String nPrice = "";
                String nMessage = "";

                if (eRng.Cells[i, 7].Value != null)
                {
                    currentPrice = eRng.Cells[i, 7].Value.ToString();
                }
                // The UsedRange property includes cells that have been used in the past but are now empty, so we don't want to include those
                // We check the first column, because that should always include some value (Product, SKU, or Rule)if the row has data.
                if (eRng.Cells[i, 1].Value == null)
                {
                    break;
                }
                
                // Check if there's anything in the part number column, if not then skip
                if (SKU == null)
                {
                    if (eRng.Cells[i, 1].Value == "Product")
                    {
                        // Create list to hold family member prices
                        List<Double> myFamily = new List<Double>();
                        
                        // Get children
                        for (int j = i + 1; j < eRng.Columns["A:A", Type.Missing].Rows.Count + 1; j++)
                        {
                            String cellValue = eRng.Cells[j, 1].Value;
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
                                        Double s = 0;
                                        bool canParse = double.TryParse(uPrices[childSKU], out s);
                                    
                                        if (canParse)
                                        { 
                                            // Price comes over as a string, but we need it to be a double
                                            Double childPrice = Convert.ToDouble(uPrices[childSKU], CultureInfo.InvariantCulture);
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
                                                Double currentChildPrice = Convert.ToDouble(currentPrice, CultureInfo.InvariantCulture);
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
                            eRng.Cells[i, 18].Interior.Color = Excel.XlRgbColor.rgbRed;
                        }

                        // Write value to spreadsheet
                        eRng.Cells[i, 17].Value = nPrice;

                        /*PartNums = String.Concat(PartNums, "Parent");
                        PartNums = String.Concat(PartNums, ", " + nPrice);
                        PartNums = String.Concat(PartNums, "\n");*/

                        continue;
                    }
                    else
                    {
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
                }

                // Change background color to red if nPrice isn't a number (if it's CFP or whatevs)
                Double testDouble = 0;
                bool notCFP = double.TryParse(nPrice, out testDouble);
                if (!notCFP)
                {
                    if (nMessage == "Not Found")
                    {
                        eRng.Cells[i, 18].Interior.Color = Excel.XlRgbColor.rgbRed;
                    }
                    else
                    {
                        eRng.Cells[i, 18].Interior.Color = Excel.XlRgbColor.rgbYellow;
                        nMessage = nPrice;
                    }
                    eRng.Cells[i, 18].Value = nMessage;
                    eRng.Cells[i, 17].Value = currentPrice;
                }
                else
                {
                    // Write value to spreadsheet
                    String prodType = eRng.Cells[i, 1].Value;
                    prodType = prodType.Trim();
                    if (prodType == "Rule")
                    {
                        eRng.Cells[i, 17].Value = "[FIXED]" + nPrice;
                    }
                    else
                    {
                        eRng.Cells[i, 17].Value = nPrice;
                    }
                }
                /*
                 * **** DEBUG: Remove when deployed ****
                 */
                /*PartNums = String.Concat(PartNums, SKU);
                PartNums = String.Concat(PartNums, ", " + nPrice);
                PartNums = String.Concat(PartNums, "\n");*/
                // END DEBUG
            }

            /*
             * **** DEBUG: Remove when deployed ****
             */
            //MessageBox.Show(PartNums);
            // END DEBUG
            uWB.Close();
            eWB.Save();
            eWB.Close();
            oXL.Quit();

        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex);
            MessageBox.Show("You may need to kill Excel from Windows Task Manager to unlock the workbooks");
        }

        MessageBox.Show("Spreadsheet updated");
    }

    private void CloseWorkbooks(Excel._Workbook uWB, Excel._Workbook eWB)
    {
        
    }
}