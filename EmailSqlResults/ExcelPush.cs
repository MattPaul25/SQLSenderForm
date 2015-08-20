using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace EmailSqlResults
{
    class ExcelPush
    {
        public string location { get; set; }
        public System.Data.DataTable dt { get; set; }

        public ExcelPush(System.Data.DataTable Dt, string Location)
        {
            this.dt = Dt;
            this.location = Location;

            if (File.Exists(location))        
                File.Delete(location);
            
            WriteToExcel();

        }

        private void WriteToExcel()
        {
            //instantiate excel objects (application, workbook, worksheets)
            excel.Application oXL = new excel.Application();
            oXL.Visible = false;
            excel._Workbook oWB = (excel.Workbook)(oXL.Workbooks.Add(""));
            excel._Worksheet oSheet = (excel.Worksheet)oWB.ActiveSheet;
          
            //run through datatable and assign cells to values of datatable
            try
            {
                int row = 1; int col = 1;
                foreach (DataColumn column in dt.Columns)
                {
                    //adding columns
                    oSheet.Cells[row, col] = column.ColumnName;
                    col++;
                }
                //reset column and row variables
                col = 1;
                row++;
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    foreach (var cell in dt.Rows[i].ItemArray)
                    {
                        oSheet.Cells[row, col] = cell;
                        col++;
                    }
                    col = 1;
                    row++;
                }
                oWB.SaveAs(location);
            }
            catch (COMException x)
            {
                MessageBox.Show(x.Message);
                ErrorHandler.Handle(x);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ErrorHandler.Handle(ex);
            }
            finally
            {
                oWB.Close();
            }
        }
    }
}

