using System;
using System.Collections.Generic;
using System.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Text;
using System.IO;

namespace EmailSqlResults
{
    class GenerateEmail
    {
        private List<string> qryNames;
        private string path;
        private string AttachmentLocation;
        public bool isSuccessful { get; set; }

        public GenerateEmail(EmailObject EmlObj, List<string> QryNames, string DownloadDestination)
        {

            qryNames = QryNames;
            AttachmentLocation = DownloadDestination;
            sendEmail(EmlObj);
        }
        private void sendEmail(EmailObject eml)
        {

            string myDate = DateTime.Today.ToString("MMMM dd, yyyy");
            try
            {
                Outlook.Application app = new Outlook.Application();
                Outlook.MailItem mail = app.CreateItem(Outlook.OlItemType.olMailItem);
                int fileCount = 0;
                foreach (var qryName in qryNames)
                {

                    mail.Attachments.Add(AttachmentLocation + qryName);
                    fileCount++;
                }
                if (fileCount > 0)
                {
                    mail.Importance = Outlook.OlImportance.olImportanceHigh;
                    mail.Subject = myDate + " " + eml.Subject;
                    mail.To = eml.To;
                    mail.CC = eml.CC;
                    mail.Body = eml.Body;
                    mail.Send();
                    isSuccessful = true;
                    mail.Close(Outlook.OlInspectorClose.olDiscard);
                }
            }
            catch (Exception x)
            {
                ErrorHandler.Handle(x);
            }
        }
    }
}

        

   

