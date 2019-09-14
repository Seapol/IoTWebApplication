using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace IoTWebApplication
{
    public partial class WebFormReviewDetails : System.Web.UI.Page
    {
        int id = -1;
        string UnID;


        string Approver;
        bool isApproved;
        string comments;
        string summary;
        string ProjectMainPartStoredFileDataSheet;
        string ProjectMainPartStoredFileFootPrint;
        string ProjectMainPartStoredFileLogicalSymbol;
        string MiscStoredFile;
        string ProjectMainPartStoredFileFootPrintFinal;
        string ProjectMainPartStoredFileLogicalSymbolFinal;


        protected void Page_Load(object sender, EventArgs e)
        {
            var id_number = Request.QueryString["ID"];
            var UniqueID = Request.QueryString["UnID"];

            

            id = int.Parse(id_number.ToString());
            UnID = UniqueID.ToString();

            Session["ID"] = id;
            Session["UnID"] = UnID;

            Approver = Context.User.Identity.Name.Substring(Context.User.Identity.Name.IndexOf('\\') + 1);


            //SqlDataSource3.FilterExpression = String.Format("[ID] = {0}", id);
            //SqlDataSource4.FilterExpression = String.Format("[ID] = {0}", id);
            //SqlDataSource5.FilterExpression = String.Format("[ID] = {0}", id);


            AcquireExistingItem(UnID);
            TextBox1.Text = summary;
            //if (!IsPostBack)
            //{

            //}

            TextBox1.ReadOnly = true;
            //Update2Database(nameof(Approver).ToString(), Approver);

        }

        private void AcquireExistingItem(string unID)
        {
            SqlDataSource1.FilterExpression = String.Format("[ID] = {0}", id);

            IEnumerable rows = SqlDataSource1.Select(DataSourceSelectArguments.Empty);

            foreach (DataRowView row in rows)
            {
                summary = row[20].ToString();
                comments = row[18].ToString();
                ProjectMainPartStoredFileDataSheet = row[10].ToString();
                ProjectMainPartStoredFileFootPrint = row[12].ToString();
                ProjectMainPartStoredFileLogicalSymbol = row[14].ToString();
                MiscStoredFile = row[21].ToString();
                ProjectMainPartStoredFileFootPrintFinal = row[24].ToString();
                ProjectMainPartStoredFileLogicalSymbolFinal = row[25].ToString();
            }
        }

        private int Update2Database(string item_name, string value)
        {
            int Cnt = -1;


                        

            if (id != -1)
            {
                try
                {
                    SqlDataSource1.UpdateCommand = String.Format(@"

UPDATE [dbo].[Items1]
   SET 
      [{0}] = '{1}'

 WHERE [ID] = {2}

", item_name, value, id);

                    Cnt = SqlDataSource1.Update();

                }
                catch (Exception)
                {

                    this.Response.Write("<script>alert('Fail to Update data to SQL Server when Save()')</script>");
                }



            }
            return Cnt;
        }

        protected void Button_Approve_Click(object sender, EventArgs e)
        {
            comments = TextBox2.Text;

            isApproved = true;
            comments += "\n\nApproved by " + Approver + "\t\t" + DateTime.UtcNow.ToShortDateString() + " " + DateTime.UtcNow.ToShortTimeString() + "\n";

            if (id != -1)
            {
                SqlDataSource2.UpdateCommand = String.Format(@"

UPDATE [dbo].[Items1]
   SET
      [Approver] = '{0}'
      ,[IsApproved] = 1
      ,[Comments] = '{1}'
    ,[ProjectStatus] = '{2}'


 WHERE [ID] = {3}

", Approver, comments, "Approved", id);


                int Cnt = SqlDataSource2.Update();
            }

            this.Response.Write("<script>window.location='WebFormReviewItems.aspx'</script>");

        }

        protected void Button_Reject_Click(object sender, EventArgs e)
        {
            comments = TextBox2.Text;

            isApproved = false;
            comments += "\n\nRejected by " + Approver + "\t\t" + DateTime.UtcNow.ToShortDateString() + " " + DateTime.UtcNow.ToShortTimeString() + "\n";

            if (id != -1)
            {
                SqlDataSource2.UpdateCommand = String.Format(@"

UPDATE [dbo].[Items1]
   SET
      [Approver] = '{0}'
      ,[IsApproved] = 1
      ,[Comments] = '{1}'
    ,[ProjectStatus] = '{2}'


 WHERE [ID] = {3}

", Approver, comments, "Rejected", id);

                int Cnt = SqlDataSource2.Update();
            }

            this.Response.Write("<script>window.location='WebFormReviewItems.aspx'</script>");
        }

        protected void LinkButtonFootPrint_Click(object sender, EventArgs e)
        {

            AcquireExistingItem(UnID);
            if (File.Exists(ProjectMainPartStoredFileFootPrint))
            {

                var filefullpath = ProjectMainPartStoredFileFootPrint.Trim();
                var path = filefullpath.Substring(0, filefullpath.LastIndexOf('\\') + 1);
                string fileName = filefullpath.Substring(filefullpath.LastIndexOf('\\') + 1);
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
                Response.ContentType = "application/unknow";
                //Response.ContentType = "text/plain";
                Response.TransmitFile(filefullpath);
                Response.End();
            }
        }

        protected void LinkButtonLogicalSymbol_Click(object sender, EventArgs e)
        {
            AcquireExistingItem(UnID);
            if (File.Exists(ProjectMainPartStoredFileLogicalSymbol))
            {
                var filefullpath = ProjectMainPartStoredFileLogicalSymbol.Trim();
                var path = filefullpath.Substring(0, filefullpath.LastIndexOf('\\') + 1);
                string fileName = filefullpath.Substring(filefullpath.LastIndexOf('\\') + 1);
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
                Response.ContentType = "application/unknow";
                //Response.ContentType = "text/plain";
                Response.TransmitFile(filefullpath);
                Response.End();
            }
        }

        protected void LinkButtonDataSheet_Click(object sender, EventArgs e)
        {
            AcquireExistingItem(UnID);
            if (File.Exists(ProjectMainPartStoredFileDataSheet))
            {

                var filefullpath = ProjectMainPartStoredFileDataSheet.Trim();
                var path = filefullpath.Substring(0, filefullpath.LastIndexOf('\\') + 1);
                string fileName = filefullpath.Substring(filefullpath.LastIndexOf('\\') + 1);
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
                Response.ContentType = "application/unknow";
                //Response.ContentType = "text/plain";
                Response.TransmitFile(filefullpath);
                Response.End();
            }
        }

        protected void LinkButtonMisc_Click(object sender, EventArgs e)
        {
                AcquireExistingItem(UnID);
                if (File.Exists(MiscStoredFile))
                {

                    var filefullpath = MiscStoredFile.Trim();
                    var path = filefullpath.Substring(0, filefullpath.LastIndexOf('\\') + 1);
                    string fileName = filefullpath.Substring(filefullpath.LastIndexOf('\\') + 1);
                    Response.Clear();
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
                    Response.ContentType = "application/unknow";
                    //Response.ContentType = "text/plain";
                    Response.TransmitFile(filefullpath);
                    Response.End();
                }
        }

        protected void LinkButtonFinalFootPrint_Click(object sender, EventArgs e)
        {
                AcquireExistingItem(UnID);
                if (File.Exists(ProjectMainPartStoredFileFootPrintFinal))
                {
                var filefullpath = ProjectMainPartStoredFileFootPrintFinal.Trim();
                var path = filefullpath.Substring(0, filefullpath.LastIndexOf('\\') + 1);
                string fileName = filefullpath.Substring(filefullpath.LastIndexOf('\\') + 1);
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
                Response.ContentType = "application/unknow";
                //Response.ContentType = "text/plain";
                Response.TransmitFile(filefullpath);
                Response.End();
            }
        }

        protected void LinkButtonFinalLogicalSymbol_Click(object sender, EventArgs e)
        {
                AcquireExistingItem(UnID);
                if (File.Exists(ProjectMainPartStoredFileLogicalSymbolFinal))
                {

                var filefullpath = ProjectMainPartStoredFileLogicalSymbolFinal.Trim();
                var path = filefullpath.Substring(0, filefullpath.LastIndexOf('\\') + 1);
                string fileName = filefullpath.Substring(filefullpath.LastIndexOf('\\') + 1);
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
                Response.ContentType = "application/unknow";
                //Response.ContentType = "text/plain";
                Response.TransmitFile(filefullpath);
                Response.End();
            }
        }
    }
}