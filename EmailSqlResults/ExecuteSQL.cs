using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace EmailSqlResults
{
    class FindSQL
    {
        private Form1 form;
        public List<string> SqlStatements { get; set; }
        public List<string> QryNames { get; set; }

        public FindSQL(Form1 Form)
        {
            SqlStatements = new List<string>();
            QryNames = new List<string>();
            form = Form;
            findSqlControl();
        }

        private void findSqlControl()
        {
            //finds the added cntrls with a name of leader string sqlbox
            //these controls refer to inputs that contain 
            foreach (Control cntrl1 in form.Controls)
            {
                string cntrl1Name = "sqlbox";
                if (cntrl1.Name.Length >= cntrl1Name.Length + 1)
                {
                    bool isControlType = cntrl1.Name.Substring(0, cntrl1Name.Length) == cntrl1Name;
                    if (isControlType)
                    {
                        SqlStatements.Add(cntrl1.Text);
                        findQryNameControl(cntrl1);
                    }
                }
            }
        }

        private void findQryNameControl(Control cntrl1)
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
                        QryNames.Add(cntrl2.Text + ".xlsx");                      
                    }
                }
            }
        }

    }
}
