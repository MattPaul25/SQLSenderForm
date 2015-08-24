using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSqlResults
{
    static class ErrorHandler
    {
        public static string AllIssues { get; set; }
        public static void Handle(Exception x)
        {
            //writes comment to console and logs it on log
            using (StreamWriter sw = new StreamWriter("History.txt", true))
            {
                sw.WriteLine(x.Message);
                AllIssues += x.Message;
                sw.Close();
            }
        }

        public static void Email()
        {
            if (AllIssues != "")
            {
                var errEmail = new EmailObject()
                {
                    Body = "Here Are the issues:" + AllIssues,
                    To = "Matt.Farguson@dowjones.com",
                    Subject = "Errors Caught"
                };
                var send = new GenerateEmail(errEmail);
            }
        }
    }
}
