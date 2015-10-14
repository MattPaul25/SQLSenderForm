using System;
using System.Collections.Generic;
using System.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;


namespace EmailSqlResults
{
    class EmailObject
    {
        public string To { get; set; }
        public string CC { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }

    class GenerateEmail
    {
        private List<string> qryNames;
        private string AttachmentLocation;
        public bool isSuccessful { get; set; }

        public GenerateEmail(EmailObject EmlObj, List<string> QryNames, string DownloadDestination)
        {
            qryNames = QryNames;
            AttachmentLocation = DownloadDestination;
            sendEmail(EmlObj);
        }

        public GenerateEmail(EmailObject EmlObj)
        {
            sendEmail(EmlObj, true);
        }

        private void sendEmail(EmailObject eml, bool errEmail = false)
        {
            string myDate = DateTime.Today.ToString("MMMM dd, yyyy");
            Outlook._Application _app = new Outlook.Application();  
            Outlook._NameSpace _ns = _app.GetNamespace("MAPI");
            System.Threading.Thread.Sleep(5000); //wait for app to start
            Outlook.MailItem _mail = (Outlook.MailItem)_app.CreateItem(Outlook.OlItemType.olMailItem);
            try
            {                
                int fileCount = 0;
                if (qryNames != null)
                {
                    foreach (var qryName in qryNames)
                    {
                        if (System.IO.File.Exists(AttachmentLocation + qryName))
                        {
                            _mail.Attachments.Add(AttachmentLocation + qryName);
                            fileCount++;
                        }
                    }
                }               
                _mail.Subject = myDate + " " + eml.Subject;
                _mail.To = eml.To;
                _mail.CC = eml.CC;
                _mail.Body = eml.Body;
                _mail.Importance = Outlook.OlImportance.olImportanceNormal;                    
                System.Threading.Thread.Sleep(5000); //wait for application to catch up with mail object
                ((Outlook.MailItem)_mail).Send();
                _ns.SendAndReceive(true); //send and receive
                _mail.Close(Outlook.OlInspectorClose.olDiscard);
                System.Threading.Thread.Sleep(5000); //wait for application to catch up with mail object
                _app.Quit();
                isSuccessful = true;                
            }
            catch (COMException cEx)
            {
                if (cEx.Message != "The item has been moved or deleted.")
                {
                    ErrorHandler.Handle(cEx);
                    isSuccessful = false;
                }
            }
            catch (Exception x)
            {
                ErrorHandler.Handle(x);
                isSuccessful = false;
            }           
        }
    }
}

        

   

