using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IoTApplication
{
    public enum WorkMode
        {
            New,
            Modify,
            Review
        }

    public partial class _Default : Page
    {

        string user;

        protected void Page_Load(object sender, EventArgs e)
        {
            Label_SW_ver.Text = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            user = Context.User.Identity.Name.Substring(Context.User.Identity.Name.IndexOf('\\') + 1);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["WorkMode"] = WorkMode.New.ToString();
            Session["Initiator"] = user;
            //this.Response.Write("<script>window.open('WebFormNew.aspx','_blank');</script>");
            this.Response.Write("<script>window.location='WebFormMyWork.aspx'</script>");

            

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["WorkMode"] = WorkMode.Review.ToString();
            Session["Approver"] = user;

            foreach (var signer in IoTWebApplication.Properties.Settings.Default.Signers)
            {
                if (Context.User.Identity.Name.Contains(signer))
                {
                    this.Response.Write("<script>window.location=' WebFormReviewItems.aspx'</script>");
                }
                else
                {
                    
                }
            }

            this.Response.Write("<script>alert('Fail to enter Review&Approval Page due to the role authorization issue.')</script>");




        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["WorkMode"] = WorkMode.Modify.ToString();
            Session["Initiator"] = user;

            this.Response.Write("<script>window.location=' WebFormModifyMyWork.aspx'</script>");
        }
    }
}