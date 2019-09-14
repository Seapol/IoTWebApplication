using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IoTWebApplication
{
    public class Email
    {
        /// <summary>
        /// 
        /// </summary>
        List<string> CClist = new List<string>();

        int Cnt = 0;

        public Email()
        {

        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string subject;

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }


        private string from_address;

        public string From_address
        {
            get { return from_address; }
            set { from_address = value; }
        }

        private string to_address;

        public string To_address
        {
            get { return to_address; }
            set { to_address = value; }
        }

        private string cc_address;

        public string CC_address
        {
            get { return cc_address; }
            set { cc_address = value; }
        }


        private string stmpServerAddress;

        public string SmtpServerAddress
        {
            get { return stmpServerAddress; }
            set { stmpServerAddress = value; }
        }

        #region 发送邮件
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="sendusermail"></param>
        /// <param name="mailtitle"></param>
        /// <param name="mailcontent"></param>
        /// <returns></returns>
        public static bool Send(string sendusermail, string ccusermail,string mailtitle, string mailcontent)
        {
            try
            {
                Microsoft.Office.Interop.Outlook.Application olApp = new Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Interop.Outlook.MailItem mailItem = (Microsoft.Office.Interop.Outlook.MailItem)olApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
                mailItem.To = sendusermail;
                mailItem.CC = ccusermail;
                mailItem.Subject = mailtitle;
                mailItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatRichText;
                mailItem.HTMLBody = mailcontent;
                ((Microsoft.Office.Interop.Outlook._MailItem)mailItem).Send();
                mailItem = null;
                olApp = null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return true;
        }
        #endregion    

    }
}