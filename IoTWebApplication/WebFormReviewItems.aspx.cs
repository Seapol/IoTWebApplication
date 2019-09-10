using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IoTWebApplication
{
    public partial class WebFormReviewItems : System.Web.UI.Page
    {
        string UnID;

        protected void Page_Load(object sender, EventArgs e)
        {
            var ID_number = Request.QueryString["ID"];
            var uID_number = Request.QueryString["UnID"];

            //UnID = uID_number.ToString();

            var Approver = Session["Approver"];
            var mode = Session["WorkMode"];
            

            SqlDataSource1.FilterExpression = String.Format("[ProjectStatus] like 'Pending%' OR [ProjectStatus] like 'Rejected%' OR [ProjectStatus] like 'Approved%'");
            //SqlDataSource1.FilterExpression = String.Format("[Approver] like '%{0}%'", Approver);

            SqlDataSource2.FilterExpression = String.Format("[ProjectStatus] like 'Completed%' OR [ProjectStatus] like 'Approved%' OR [ProjectStatus] like 'Working%'");
            //SqlDataSource2.FilterExpression = String.Format("[Approver] like '%{0}%'", Approver);

            SqlDataSource3.FilterExpression = String.Format("[ProjectStatus] like 'Completed%' OR [ProjectStatus] like 'Approved%' OR [ProjectStatus] like 'Working%' OR [ProjectStatus] like 'Pending%'");

        }

        int indexOfID = 0;
        int indexOfProjectStatus = 5;
        int indexOfIsApproved = 8;

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GridView1.SelectedRow;



            if (gr.Cells[indexOfIsApproved].Text == "True")
            {
                SqlDataSource1.UpdateCommand = String.Format(@"UPDATE [dbo].[Items1] SET [IsApproved] = 0
                WHERE [ID] = {0} ", int.Parse(gr.Cells[indexOfID].Text));
                SqlDataSource1.Update();

                //SqlDataSource1.UpdateCommand = String.Format(@"UPDATE [dbo].[Items1] SET [ProjectStatus] = 'Rejected'
                //WHERE [ID] = {0} ", int.Parse(gr.Cells[indexOfID].Text));
                //SqlDataSource1.Update();

            }
            else
            {
                SqlDataSource1.UpdateCommand = String.Format(@"UPDATE [dbo].[Items1] SET [IsApproved] = 1
                WHERE [ID] = {0} ", int.Parse(gr.Cells[indexOfID].Text));
                SqlDataSource1.Update();


                //SqlDataSource1.UpdateCommand = String.Format(@"UPDATE [dbo].[Items1] SET [ProjectStatus] = 'Completed'
                //WHERE [ID] = {0} ", int.Parse(gr.Cells[indexOfID].Text));
                //SqlDataSource1.Update();

            }

        }

        int indexOfIsCompleted = 10;
        int indexOfRemarks = 8;
        //protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GridViewRow gr = GridView2.SelectedRow;


        //    if (gr.Cells[indexOfIsCompleted].Text == "True")
        //    {

        //        SqlDataSource2.UpdateCommand = String.Format(@"UPDATE [dbo].[Items1] SET [IsCompleted] = 0
        //        WHERE [ID] = {0} ", int.Parse(gr.Cells[indexOfID].Text));
        //        SqlDataSource2.Update();

        //    }
        //    else
        //    {

        //        SqlDataSource2.UpdateCommand = String.Format(@"UPDATE [dbo].[Items1] SET [IsCompleted] = 1
        //        WHERE [ID] = {0} ", int.Parse(gr.Cells[indexOfID].Text));
        //        SqlDataSource2.Update();


        //    }


        //}

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GridView2.SelectedRow;

            indexOfRemarks = 9;
            int indexOfFootPrint = 5;
            int indexOfLogicalSymbol = 6;
            int indexOfCYPN = 7;
            int indexOfIsdoublecheck = 8;
            int indexOfUnID = 1;
            int indexOfProjectStatus = 5;

            if (!gr.Cells[indexOfProjectStatus].Text.Contains("Completed"))
            {
                SqlDataSource2.UpdateCommand = String.Format(@"UPDATE [dbo].[Items1] SET [ProjectStatus] = 'Working'
            WHERE [ID] = {0} ", int.Parse(gr.Cells[indexOfID].Text));
                SqlDataSource2.Update();
            }



            //if (gr.Cells[indexOfIsdoublecheck].Text.Contains("1"))
            //{

            //    Session["WorkMode"] = WorkMode.Modify.ToString();
            //    Session["UnID"] = gr.Cells[indexOfID];
            //    Session["UnID"] = gr.Cells[indexOfUnID].Text.Trim();

            //    //if (gr.Cells[indexOfFootPrint].Text.Replace("&nbsp;","").Length > 0 && gr.Cells[indexOfLogicalSymbol].Text.Replace("&nbsp;", "").Length > 0 && gr.Cells[indexOfCYPN].Text.Replace("&nbsp;", "").Length > 0 && gr.Cells[indexOfRemarks].Text.Replace("&nbsp;", "").Length > 0)
            //    //{ 
            //    ////    SqlDataSource2.UpdateCommand = String.Format(@"UPDATE [dbo].[Items1] SET [IsCompleted] = 1, [ProjectStatus] = 'Completed'
            //    ////WHERE [ID] = {0} ", int.Parse(gr.Cells[indexOfID].Text));
            //    ////    SqlDataSource2.Update();
            //    ////    this.Response.Write("<script>alert('This item has been completed successfully')</script>");



            //    //}
            //    //else
            //    //{
            //    ////    SqlDataSource2.UpdateCommand = String.Format(@"UPDATE [dbo].[Items1] SET [IsCompleted] = 1, [ProjectStatus] = 'Working'
            //    ////WHERE [ID] = {0} ", int.Parse(gr.Cells[indexOfID].Text));
            //    ////    SqlDataSource2.Update();
            //    ////    this.Response.Write("<script>alert('This item cannot be completed because it require double confirmation by initiator')</script>");
            //    //}

            //}
            //else
            //{
            //    Session["WorkMode"] = WorkMode.Review.ToString();
            //    Session["UnID"] = gr.Cells[indexOfID];
            //    Session["UnID"] = gr.Cells[indexOfUnID].Text.Trim();
            //    //SqlDataSource2.UpdateCommand = String.Format(@"UPDATE [dbo].[Items1] SET [IsCompleted] = 1, [ProjectStatus] = 'Completed'
            //    //WHERE [ID] = {0} ", int.Parse(gr.Cells[indexOfID].Text));
            //    //SqlDataSource2.Update();
            //}

            Session["WorkMode"] = WorkMode.Review.ToString();
            Session["ID"] = gr.Cells[indexOfID];
            Session["UnID"] = gr.Cells[indexOfUnID].Text.Trim();

            this.Response.Write("<script>window.location='WebFormMyWork.aspx'</script>");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            GridViewRowCollection grows = GridView1.Rows;

            for (int i = 0; i < grows.Count; i++)
            {
                if (grows[i].Cells[indexOfProjectStatus].Text.Contains("Approved"))
                {
                    SqlDataSource1.UpdateCommand = String.Format(@"UPDATE [dbo].[Items1] SET [IsApproved] = 1
                    WHERE [ID] = {0} ", int.Parse(grows[i].Cells[indexOfID].Text));
                    SqlDataSource1.Update();
                }
                else 
                {
                    SqlDataSource1.UpdateCommand = String.Format(@"UPDATE [dbo].[Items1] SET [IsApproved] = 0
                    WHERE [ID] = {0} ", int.Parse(grows[i].Cells[indexOfID].Text));
                    SqlDataSource1.Update();
                }


            }
            this.Response.Write("<script>window.location='Default.aspx'</script>");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            GridViewRowCollection grows1 = GridView1.Rows;
            

            for (int i = 0; i < grows1.Count; i++)
            {
                if (grows1[i].Cells[indexOfIsApproved].Text == "True")
                {
                    SqlDataSource1.UpdateCommand = String.Format(@"UPDATE [dbo].[Items1] SET [ProjectStatus] = 'Approved'
                    WHERE [ID] = {0} ", int.Parse(grows1[i].Cells[indexOfID].Text));
                    SqlDataSource1.Update();
                }
                else if (grows1[i].Cells[indexOfIsApproved].Text == "False")
                {
                    SqlDataSource1.UpdateCommand = String.Format(@"UPDATE [dbo].[Items1] SET [ProjectStatus] = 'Rejected'
                    WHERE [ID] = {0} ", int.Parse(grows1[i].Cells[indexOfID].Text));
                    int cnt = SqlDataSource1.Update();
                }
                else
                {
                    SqlDataSource1.UpdateCommand = String.Format(@"UPDATE [dbo].[Items1] SET [ProjectStatus] = 'Pending'
                    WHERE [ID] = {0} ", int.Parse(grows1[i].Cells[indexOfID].Text));
                    SqlDataSource1.Update();
                }

            }

            this.Response.Write("<script>window.location='Default.aspx'</script>");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {



            this.Response.Write("<script>window.location='Default.aspx'</script>");

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            GridViewRowCollection grows2 = GridView2.Rows;
            string alertIDs = "";

            for (int i = 0; i < grows2.Count; i++)
            {
                if (grows2[i].Cells[indexOfIsCompleted].Text == "True")
                {
                    SqlDataSource2.UpdateCommand = String.Format(@"UPDATE [dbo].[Items1] SET [ProjectStatus] = 'Completed'
                    WHERE [ID] = {0} ", int.Parse(grows2[i].Cells[indexOfID].Text));
                    SqlDataSource2.Update();
                }
                else if (grows2[i].Cells[indexOfIsCompleted].Text == "False")
                {
                    SqlDataSource2.UpdateCommand = String.Format(@"UPDATE [dbo].[Items1] SET [ProjectStatus] = 'Approved'
                    WHERE [ID] = {0} ", int.Parse(grows2[i].Cells[indexOfID].Text));
                    SqlDataSource2.Update();
                }

                if (grows2[i].Cells[indexOfRemarks].Text.Trim().Replace("&nbsp;", "") == "" && grows2[i].Cells[indexOfIsCompleted].Text == "True")
                {
                    alertIDs += "#" + int.Parse(grows2[i].Cells[indexOfID].Text);

                    if (grows2[i].Cells[indexOfProjectStatus].Text.Contains("Completed"))
                    {
                        SqlDataSource2.UpdateCommand = String.Format(@"UPDATE [dbo].[Items1] SET [ProjectStatus] = 'Approved', [IsCompleted] = 0
                    WHERE [ID] = {0} ", int.Parse(grows2[i].Cells[indexOfID].Text));
                        SqlDataSource2.Update();
                    }

                }
            }

            if (alertIDs.Length > 0)
            {
                string AlertMsg = String.Format("<script>alert('Warning: Project ID {0} is (are) attempted to be completed without requestor remarks so the request action is denied. Please check it.')</script>", alertIDs);
                this.Response.Write(AlertMsg);
            }

            this.Response.Write("<script>window.location='Default.aspx'</script>");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            GridViewRowCollection grows = GridView1.Rows;

            for (int i = 0; i < grows.Count; i++)
            {
                if (grows[i].Cells[indexOfProjectStatus].Text.Contains("Approved"))
                {
                    SqlDataSource1.UpdateCommand = String.Format(@"UPDATE [dbo].[Items1] SET [IsCompleted] = 1
                    WHERE [ID] = {0} ", int.Parse(grows[i].Cells[indexOfID].Text));
                    SqlDataSource2.Update();
                }
                else
                {
                    SqlDataSource1.UpdateCommand = String.Format(@"UPDATE [dbo].[Items1] SET [IsCompleted] = 0
                    WHERE [ID] = {0} ", int.Parse(grows[i].Cells[indexOfID].Text));
                    SqlDataSource2.Update();
                }


            }

            this.Response.Write("<script>window.location='Default.aspx'</script>");
        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexOfUnID = 1;

            GridViewRow gr = GridView3.SelectedRow;

            UnID = gr.Cells[indexOfUnID].Text;

            Session["UnID"] = UnID;


            this.Response.Write("<script>window.location='WebFormMyWork.aspx'</script>");


        }
    }
}