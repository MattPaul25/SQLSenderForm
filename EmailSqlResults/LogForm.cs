using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EmailSqlResults
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
            WriteToLog();
        }
        private void WriteToLog()
        {
            StreamReader r = new StreamReader("History.txt");
            txtLogFile.Text = r.ReadToEnd();
        }
    }
}
