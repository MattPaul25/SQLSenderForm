using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace EmailSqlResults
{
    class PushData
    {
        public bool isSuccessful { get; set; }
        public System.Data.DataTable dT { get; set; }
        public string location { get; set; }

        public PushData(System.Data.DataTable Dt, string Location)
        {
            this.dT = Dt;
            this.location = Location;
            if (File.Exists(Location)) { File.Delete(Location); }
        }

        public void WriteToCsv(string sepString)        
        {
            //exports Datatable as csv
            var sb = new StringBuilder();
            // create columns
            for (int i = 0; i < dT.Columns.Count; i++)
            {
                sb.Append(dT.Columns[i].ColumnName);
                sb.Append(i == dT.Columns.Count - 1 ? "" : sepString);
            }            
            sb.Append("\n");
            for (int currentRow = 0; currentRow < dT.Rows.Count; currentRow++)
            {
                for (int j = 0; j < dT.Columns.Count; j++)
                {
                    sb.Append(dT.Rows[currentRow][j].ToString());
                    sb.Append(j == dT.Columns.Count - 1 ? "" : sepString);
                }
                if (currentRow < dT.Rows.Count - 1) { sb.Append("\n"); }
            }
            File.AppendAllText(location + ".csv", sb.ToString());
        }

        public void WriteToExcel()
        {
            //instantiate excel objects (application, workbook, worksheets)
            excel.Application XlObj = new excel.Application();
            XlObj.Visible = false;
            excel._Workbook WbObj = (excel.Workbook)(XlObj.Workbooks.Add(""));
            excel._Worksheet WsObj = (excel.Worksheet)WbObj.ActiveSheet;
          
            //run through datatable and assign cells to values of datatable
            try
            {
                int row = 1; int col = 1;
                foreach (System.Data.DataColumn column in dT.Columns)
                {
                    //adding columns
                    WsObj.Cells[row, col] = column.ColumnName;
                    col++;
                }
                //reset column and row variables
                col = 1;
                row++;
                for (int i = 0; i < dT.Rows.Count; i++)
                {
                    //adding data
                    foreach (var cell in dT.Rows[i].ItemArray)
                    {
                        WsObj.Cells[row, col] = cell;
                        col++;
                    }
                    col = 1;
                    row++;
                }
                WbObj.SaveAs(location + ".xlsx");
                isSuccessful = true;
            }
            catch (COMException cEx)
            {
                isSuccessful = false;
                ErrorHandler.Handle(cEx);
            }
            catch (Exception ex)
            {
                isSuccessful = false;
                ErrorHandler.Handle(ex);
            }
            finally
            {
                WbObj.Close();
                XlObj.Quit();                
            }
        }




    }


}

