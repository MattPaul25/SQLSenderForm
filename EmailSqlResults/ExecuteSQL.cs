using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EmailSqlResults
{
    class ExecuteSQL
    {
        public ExecuteSQL(Form1 form)
        {
            foreach (Control cntrl in form.Controls)
            {
                string cntrlName = "sqlbox";

                if (cntrl.Name.Substring(0, cntrlName.Length) == cntrlName)
                {
                    string mySql = cntrl.Text;
                }
            }
        }

    }
}
