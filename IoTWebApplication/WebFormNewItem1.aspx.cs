using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
using System.Collections;
using System.Data;

namespace IoTApplication
{
    public partial class WebFormNewItem1 : System.Web.UI.Page
    {
        int id;
        object UnID;
        DateTime DateTimeUTC;
        string Initiator;
        string ProjectCritical;
        string ProjectStatus;
        string ProjectName;
        string ProjectMainPartVendorName;
        string ProjectMainPartVendorPN;
        string ProjectMainPartDescription;
        object ProjectMainPartStoredFileDataSheet;
        string ProjectMainPartFootPrintName;
        object ProjectMainPartStoredFileFootPrint;
        string ProjectMainPartLogicalSymbolName;
        object ProjectMainPartStoredFileLogicalSymbol;
        string ProjectAlternativeSourceInfo;



        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Context.User.Identity.Name.Contains('@'))
            //{
            //    int CharIndex = Context.User.Identity.Name.IndexOf('@');
            //    //Get current login user name as initiator
            //    Label_Initiator.Text = Context.User.Identity.Name.Substring(0, CharIndex).ToUpper();
            //}
            //else
            //{
            //    Label_Initiator.Text = Context.User.Identity.Name;
            //}

            


            Initiator = Context.User.Identity.Name.Substring(Context.User.Identity.Name.IndexOf('\\')+1);

            IEnumerable rows = SqlDataSource7.Select(DataSourceSelectArguments.Empty);

            foreach (DataRowView row in rows)
            {
                Label_ID.Text = row[0].ToString();
                DateTimeUTC = (DateTime)row[2];
            }

            Label_DateTime.Text = DateTimeUTC.ToShortDateString() + " " + DateTimeUTC.ToShortTimeString();

            try
            {

                AcquireNewItem();
            }
            catch (Exception ex)
            {

                this.Response.Write(String.Format("<script>alert('{0}')</script>", ex.ToString()));
            }
        }

        private void AcquireNewItem()
        {


            SqlDataSource1.InsertCommand = String.Format(@"INSERT INTO [dbo].[Items1]
           (
           [DateTimeUTC]
           ,[Initiator]
           ,[ProjectCritical]
           ,[ProjectStatus]
)
     VALUES
           (
           SYSUTCDATETIME()
           ,'{0}'
           ,'False'
           ,'Pending')", Initiator);

            SqlDataSource1.Insert();




            

        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {
            
        }


    }
}