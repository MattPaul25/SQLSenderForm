using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EmailSqlResults
{
    class ExecuteSQL
    {
        private Form1 form;
        public string filepath { get; set; }

        public ExecuteSQL(Form1 Form, string FilePath)
        {
            filepath = FilePath;
            form = Form;
            findSqlControl();
        }

        private void findSqlControl()
        {
            foreach (Control cntrl1 in form.Controls)
            {
                string cntrl1Name = "sqlbox";
                if (cntrl1.Name.Length >= cntrl1Name.Length + 1)
                {
                    bool isControlType = cntrl1.Name.Substring(0, cntrl1Name.Length) == cntrl1Name;
                    if (isControlType)
                    {
                        findQueryNameControl(cntrl1);
                    }
                }
            }
        }

        private void findQueryNameControl(Control cntrl1)
        {
            string cntrlNum = cntrl1.Name.Substring(cntrl1.Name.Length -1, 1);
            foreach (Control cntrl2 in form.Controls)
            {
                string cntrl2Name = "qryName";
                if (cntrl2.Name.Length >= cntrl2Name.Length + 1)
                {
                    bool isControlType = cntrl2.Name.Substring(0, cntrl2.Name.Length - 1) == cntrl2Name;
                    bool isControlNum = cntrl2.Name.Substring(cntrl2.Name.Length - 1, 1) == cntrlNum;
                    bool isCorrectControl = isControlType && isControlNum;
                    if (isCorrectControl)
                    {
                        var dmpQryResults = new GenerateQueryResults(cntrl1.Text, cntrl2.Text, filepath);
                    }
                }
            }
        }

    }
}
