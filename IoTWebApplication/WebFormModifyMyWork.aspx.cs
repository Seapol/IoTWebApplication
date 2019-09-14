using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IoTWebApplication
{
    public partial class WebFormModifyMyWork : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var Initiator = Session["Initiator"];
            var mode = Session["WorkMode"];

            SqlDataSource1.FilterExpression = String.Format("[ProjectStatus] like 'Unsubmitted%' OR [ProjectStatus] like 'Rejected%'");
            SqlDataSource1.FilterExpression = String.Format("[Initiator] like '%{0}%'", Initiator);

            

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GridView1.SelectedRow;

            int indexOfID = 0;
            //Session["UnID"] = gr.Cells[indexOfUnID].Text;
            Session["ID"] = gr.Cells[indexOfID].Text;
            Session["WorkMode"] = WorkMode.Modify.ToString();
            this.Response.Write("<script>window.location='WebFormMyWork.aspx'</script>");
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {


        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    HiddenField hf = (HiddenField)e.Row.FindControl("ID");
                    e.Row.Attributes.Add("onclick", "window.open('WebFormMyWork.apsx?ID=" + hf.Value + "');");
                }
                catch (Exception)
                {


                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.Response.Write("<script>window.location='Default.aspx'</script>");
        }
    }
}