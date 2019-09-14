using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
using System.Collections;
using System.Data;
using System.IO;
using System.Drawing;
using Microsoft.Office.Interop.Outlook;



namespace IoTWebApplication
{
    public partial class WebFormMyWork : System.Web.UI.Page
    {
        int id = -1;
        string UnID;
        DateTime DateTimeUTC;
        string Initiator;
        string ProjectCritical;
        string ProjectStatus;
        string ProjectName;
        string ProjectMainPartVendorName;
        string ProjectMainPartVendorPN;
        string ProjectMainPartDescription;
        string ProjectMainPartStoredFileDataSheet;
        string ProjectMainPartFootPrintName;
        string ProjectMainPartStoredFileFootPrint;
        string ProjectMainPartLogicalSymbolName;
        string ProjectMainPartStoredFileLogicalSymbol;
        string ProjectAlternativeSourceInfo;
        string Approver;
        bool IsApproved;
        string Comments;
        string Remarks;
        string Summary;
        string MiscStoredFile;
        bool IsCompleted;
        bool IsDoubleCheck;
        string ProjectMainPartStoredFileFootPrintFinal;
        string ProjectMainPartStoredFileLogicalSymbolFinal;
        string CYPN;
        string SpecialRequirements;

        string user;

        object mode;


        protected void Page_Load(object sender, EventArgs e)
        {

            mode = Session["WorkMode"];
            var ID_number = Session["ID"];
            //var uID_number = Session["UnID"];

            if (ID_number != null)
            {
                id = int.Parse(ID_number.ToString().Trim());

                UnID = AcquireUnID(id);
            }


            user = Context.User.Identity.Name.Substring(Context.User.Identity.Name.IndexOf('\\') + 1);

            Label_Initiator.Text = Initiator;



            //if (IsPostBack)
            //{
            //    AcquireExistingItem(UnID);
            //    FillcontentIntoQueriedItem();
            //}




            if (mode.ToString() == WorkMode.New.ToString())
            {
                Initiator = user;

                Label_User.Text = user + " (Requestor)";

                FileUpload4.Visible = false;
                TextBox10.ReadOnly = true;

                TextBox6.Visible = false;
                TextBox7.Visible = false;
                TextBox5.Visible = false;
                TextBox10.Visible = false;
                TextBox11.Visible = false;
                TextBoxCYPN.Visible = false;
                LabelCYPN.Visible = false;
                LabelSummary.Visible = false;
                LabelRemarks.Visible = false;
                LabelComments.Visible = false;

                Button2.Text = "Save";
                Button3.Text = "Submit";
                Button5.Text = "Cancel";

                LabelFootPrintName.Visible = false;
                LabelLogicalSymbolName.Visible = false;
                LabelMisc.Visible = false;

                if (!IsPostBack)
                {
                    if (ProjectMainPartStoredFileDataSheet == null)
                    {
                        ProjectMainPartStoredFileDataSheet = @"\\BMOCHINA01\c$\WEB\Attachments\Datasheet\";
                    }
                    if (ProjectMainPartStoredFileFootPrint == null)
                    {
                        ProjectMainPartStoredFileFootPrint = @"\\BMOCHINA01\c$\WEB\Attachments\FootPrint\";
                    }
                    if (ProjectMainPartStoredFileLogicalSymbol == null)
                    {
                        ProjectMainPartStoredFileLogicalSymbol = @"\\BMOCHINA01\c$\WEB\Attachments\LogicalSymbol\";
                    }
                    if (MiscStoredFile == null)
                    {
                        MiscStoredFile = @"\\BMOCHINA01\c$\WEB\Attachments\Misc\";
                    }

                    try
                    {
                        if (AcquireNewItem() == 1)
                        {
                            //this.Response.Write("<script>alert('Acquire New Item Successfully')</script>");
                        }
                        else
                        {
                            this.Response.Write("<script>alert('Acquire New Item Failure')</script>");
                        }
                    }
                    catch (System.Exception ex)
                    {

                        this.Response.Write("<script>alert('Acquire New Item Failure')</script>");
                    }

                    //Get the current working row
                    //order by DateTimeUTC desc and initiator
                    SqlDataSource7.FilterExpression = String.Format("[Initiator] = '{0}'", Initiator);
                    IEnumerable rows = SqlDataSource7.Select(DataSourceSelectArguments.Empty);

                    foreach (DataRowView row in rows)
                    {
                        id = (int)row[0];
                        UnID = row[1].ToString();
                        DateTimeUTC = (DateTime)row[2];
                        ProjectCritical = row[4].ToString();
                        ProjectStatus = row[5].ToString();

                    }

                }
                else
                {

                    //Get the current working row
                    //order by DateTimeUTC desc and initiator
                    SqlDataSource7.FilterExpression = String.Format("[Initiator] = '{0}'", Initiator);
                    IEnumerable rows = SqlDataSource7.Select(DataSourceSelectArguments.Empty);

                    foreach (DataRowView row in rows)
                    {
                        id = (int)row[0];
                        UnID = row[1].ToString();
                        DateTimeUTC = (DateTime)row[2];
                        ProjectCritical = row[4].ToString();
                        ProjectStatus = row[5].ToString();

                    }

                    //id = int.Parse(Label_ID.Text);
                    //ProjectStatus = Label_ProjectStatus.Text;
                    ProjectMainPartVendorName = TextBox4.Text;
                    ProjectMainPartVendorPN = TextBox2.Text;
                    ProjectName = TextBox1.Text;
                    ProjectMainPartDescription = TextBox3.Text;
                    ProjectMainPartFootPrintName = TextBox6.Text;
                    ProjectMainPartLogicalSymbolName = TextBox7.Text;
                    ProjectAlternativeSourceInfo = TextBoxAlternativeSourceInfo.Text;
                    if (CheckBox1.Checked)
                    {
                        ProjectCritical = "True";
                    }
                    else
                    {
                        ProjectCritical = "False";
                    }

                    if (CheckBox2.Checked)
                    {
                        IsDoubleCheck = true;
                    }
                    else
                    {
                        IsDoubleCheck = false;
                    }

                }

                Label_ID.Text = id.ToString();
                Label_DateTime.Text = DateTimeUTC.ToShortDateString() + " " + DateTimeUTC.ToShortTimeString();
                Label_ProjectStatus.Text = ProjectStatus;
                //if (!IsPostBack)
                //{
                //    AcquireExistingItem(UnID);
                //    FillcontentIntoQueriedItem();
                //}
                AcquireExistingItem(UnID);
                FillcontentIntoQueriedItem();

            }
            else if (mode.ToString() == WorkMode.Modify.ToString())
            {
                Initiator = user;

                Label_User.Text = user + " (Requestor)";


                Button2.Enabled = false;
                Button2.ForeColor = Color.Gray;
                Button2.BorderColor = Color.Gray;

                TextBox10.ReadOnly = true;
                TextBox10.BorderColor = Color.Gray;
                TextBox10.ForeColor = Color.Gray;
                TextBox6.ReadOnly = false;
                TextBox7.ReadOnly = false;
                TextBox11.ReadOnly = false;

                //if (uID_number != null)
                //{
                //    UnID = uID_number.ToString();
                //}
                
                


                Button2.Enabled = false;
                Button2.ForeColor = Color.Gray;
                Button2.BorderColor = Color.Gray;

                AcquireExistingItem(UnID);
                FillcontentIntoQueriedItem();
                UpdateSummary();

                if (!IsPostBack)
                {
                    if (ProjectStatus != null)
                    {
                        if (ProjectStatus.Contains("UnSubmitted") || ProjectStatus.Contains("Rejected"))
                        {


                            Button2.Text = "Save";
                            Button3.Text = "Submit";
                            Button5.Text = "Exit";

                            //Button3.Enabled = false;
                            //Button3.ForeColor = Color.Gray;
                            //Button3.BorderColor = Color.Gray;

                            //Button7.Enabled = false;
                            //Button7.ForeColor = Color.Gray;
                            //Button7.BorderColor = Color.Gray;

                            //TextBox1.ReadOnly = true;
                            //TextBox4.ReadOnly = true;
                            //TextBox2.ReadOnly = true;
                            //TextBox3.ReadOnly = true;
                            TextBox6.ReadOnly = true;
                            TextBox7.ReadOnly = true;
                            //TextBox8.ReadOnly = true;
                            //TextBox9.ReadOnly = true;

                            //TextBox1.ForeColor = Color.Gray;
                            //TextBox4.ForeColor = Color.Gray;
                            //TextBox2.ForeColor = Color.Gray;
                            //TextBox3.ForeColor = Color.Gray;
                            TextBox6.ForeColor = Color.Gray;
                            TextBox7.ForeColor = Color.Gray;
                            //TextBox8.ForeColor = Color.Gray;
                            //TextBox9.ForeColor = Color.Gray;

                            //TextBox1.BorderColor = Color.Gray;
                            //TextBox4.BorderColor = Color.Gray;
                            //TextBox2.BorderColor = Color.Gray;
                            //TextBox3.BorderColor = Color.Gray;
                            TextBox6.BorderColor = Color.Gray;
                            TextBox7.BorderColor = Color.Gray;
                            //TextBox8.BorderColor = Color.Gray;
                            //TextBox9.BorderColor = Color.Gray;


                            LabelSummary.Visible = false;
                            TextBox5.Visible = false;
                            LabelComments.Visible = false;
                            TextBox10.Visible = false;
                            LabelRemarks.Visible = false;
                            TextBox11.Visible = false;
                            LabelMisc.Visible = false;




                        }

                        if (ProjectStatus.Contains("Pending") || ProjectStatus.Contains("Approved"))
                        {
                            Button2.Text = "Save";
                            Button3.Text = "Submit";
                            Button5.Text = "Exit";

                            Button3.Enabled = false;
                            Button3.ForeColor = Color.Gray;
                            Button3.BorderColor = Color.Gray;

                            Button7.Enabled = false;
                            Button7.ForeColor = Color.Gray;
                            Button7.BorderColor = Color.Gray;

                            CheckBox1.Enabled = false;
                            CheckBox2.Enabled = false;

                            Button8.Enabled = false;
                            Button9.Enabled = false;

                            LabelMisc.Visible = false;

                            TextBox1.ReadOnly = true;
                            TextBox4.ReadOnly = true;
                            TextBox2.ReadOnly = true;
                            TextBox3.ReadOnly = true;
                            TextBox6.ReadOnly = true;
                            TextBox7.ReadOnly = true;
                            TextBox8.ReadOnly = true;
                            TextBox9.ReadOnly = true;
                            TextBox10.ReadOnly = true;
                            TextBox11.ReadOnly = true;
                            TextBoxSpecialRequirements.ReadOnly = true;
                            TextBoxAlternativeSourceInfo.ReadOnly = true;

                            TextBox1.ForeColor = Color.Gray;
                            TextBox4.ForeColor = Color.Gray;
                            TextBox2.ForeColor = Color.Gray;
                            TextBox3.ForeColor = Color.Gray;
                            TextBox6.ForeColor = Color.Gray;
                            TextBox7.ForeColor = Color.Gray;
                            TextBox8.ForeColor = Color.Gray;
                            TextBox9.ForeColor = Color.Gray;
                            TextBox10.ForeColor = Color.Gray;
                            TextBox11.ForeColor = Color.Gray;
                            TextBoxSpecialRequirements.ForeColor = Color.Gray;
                            TextBoxAlternativeSourceInfo.ForeColor = Color.Gray;

                            TextBox1.BorderColor = Color.Gray;
                            TextBox4.BorderColor = Color.Gray;
                            TextBox2.BorderColor = Color.Gray;
                            TextBox3.BorderColor = Color.Gray;
                            TextBox6.BorderColor = Color.Gray;
                            TextBox7.BorderColor = Color.Gray;
                            TextBox8.BorderColor = Color.Gray;
                            TextBox9.BorderColor = Color.Gray;
                            TextBox10.BorderColor = Color.Gray;
                            TextBox11.BorderColor = Color.Gray;
                            TextBoxSpecialRequirements.BorderColor = Color.Gray;
                            TextBoxAlternativeSourceInfo.BorderColor = Color.Gray;


                            TextBox6.Visible = false;
                            TextBox7.Visible = false;
                            LabelFootPrintName.Visible = false;
                            LabelLogicalSymbolName.Visible = false;

                            FileUpload1.Visible = true;
                            FileUpload1.Enabled = false;
                            FileUpload2.Visible = true;
                            FileUpload2.Enabled = false;
                            FileUpload3.Visible = true;
                            FileUpload3.Enabled = false;
                            FileUpload4.Visible = false;
                            FileUpload4.Enabled = false;
                            FileUpload5.Visible = false;
                            FileUpload5.Enabled = false;
                            FileUpload6.Visible = false;
                            FileUpload6.Enabled = false;

                            LabelSummary.Visible = true;
                            TextBox5.Visible = true;
                            LabelComments.Visible = false;
                            TextBox10.Visible = false;
                            LabelRemarks.Visible = false;
                            TextBox11.Visible = false;


                        }

                        if (ProjectStatus.Contains("Completed"))
                        {
                            Button2.Text = "Save";
                            Button3.Text = "Submit";
                            Button5.Text = "Exit";

                            TextBox6.Visible = true;
                            TextBox7.Visible = true;
                            LabelFootPrintName.Visible = true;
                            LabelLogicalSymbolName.Visible = true;
                            LabelCYPN.Visible = true;
                            TextBoxCYPN.Visible = true;

                            CheckBox1.Enabled = false;
                            CheckBox2.Enabled = false;

                            Button8.Enabled = false;
                            Button9.Enabled = false;
                            Button3.Enabled = false;


                            TextBox1.ReadOnly = true;
                            TextBox4.ReadOnly = true;
                            TextBox2.ReadOnly = true;
                            TextBox3.ReadOnly = true;
                            TextBox6.ReadOnly = true;
                            TextBox7.ReadOnly = true;
                            TextBox8.ReadOnly = true;
                            TextBox9.ReadOnly = true;
                            TextBox11.ReadOnly = true;
                            TextBoxSpecialRequirements.ReadOnly = true;
                            TextBoxCYPN.ReadOnly = true;
                            TextBoxAlternativeSourceInfo.ReadOnly = true;

                            TextBox1.ForeColor = Color.Gray;
                            TextBox4.ForeColor = Color.Gray;
                            TextBox2.ForeColor = Color.Gray;
                            TextBox3.ForeColor = Color.Gray;
                            TextBox6.ForeColor = Color.Gray;
                            TextBox7.ForeColor = Color.Gray;
                            TextBox8.ForeColor = Color.Gray;
                            TextBox9.ForeColor = Color.Gray;
                            TextBox11.ForeColor = Color.Gray;
                            TextBoxSpecialRequirements.ForeColor = Color.Gray;
                            TextBoxCYPN.ForeColor = Color.Gray;
                            TextBoxAlternativeSourceInfo.ForeColor = Color.Gray;

                            TextBox1.BorderColor = Color.Gray;
                            TextBox4.BorderColor = Color.Gray;
                            TextBox2.BorderColor = Color.Gray;
                            TextBox3.BorderColor = Color.Gray;
                            TextBox6.BorderColor = Color.Gray;
                            TextBox7.BorderColor = Color.Gray;
                            TextBox8.BorderColor = Color.Gray;
                            TextBox9.BorderColor = Color.Gray;
                            TextBox11.BorderColor = Color.Gray;
                            TextBoxCYPN.BorderColor = Color.Gray;
                            TextBoxSpecialRequirements.BorderColor = Color.Gray;
                            TextBoxAlternativeSourceInfo.BorderColor = Color.Gray;

                            FileUpload1.Visible = true;
                            FileUpload1.Enabled = false;
                            FileUpload2.Visible = true;
                            FileUpload2.Enabled = false;
                            FileUpload3.Visible = true;
                            FileUpload3.Enabled = false;
                            FileUpload4.Visible = true;
                            FileUpload4.Enabled = false;
                            FileUpload5.Visible = true;
                            FileUpload5.Enabled = false;
                            FileUpload6.Visible = true;
                            FileUpload6.Enabled = false;

                            LabelMisc.Visible = true;
                            LabelFootPrintFinal.Visible = true;
                            LabelLogicalSymbolFinal.Visible = true;
                            LabelDataSheet.Visible = true;
                            LabelFootPrint.Visible = true;
                            LabelLogicalSymbol.Visible = true;


                            LinkButtonDataSheet.Visible = true;
                            LinkButtonRefFootPrint.Visible = true;
                            LinkButtonRefLogicalSymbol.Visible = true;
                            LinkButtonMisc.Visible = true;
                            LinkButtonFinalFootPrint.Visible = true;
                            LinkButtonFinalLogicalSymbol.Visible = true;

                            TextBox6.Visible = true;
                            TextBox7.Visible = true;
                            LabelFootPrintName.Visible = true;
                            LabelLogicalSymbolName.Visible = true;

                            LabelSummary.Visible = true;
                            TextBox5.Visible = true;
                            LabelComments.Visible = true;
                            TextBox10.Visible = true;
                            LabelRemarks.Visible = true;
                            TextBox11.Visible = true;


                        }

                        

                        if (ProjectStatus.Contains("Working"))
                        {
                            Button2.Text = "Save";
                            Button3.Text = "Agree";
                            Button5.Text = "Disagree";

                            TextBox6.Visible = true;
                            TextBox7.Visible = true;
                            LabelFootPrintName.Visible = true;
                            LabelLogicalSymbolName.Visible = true;
                            LabelCYPN.Visible = true;
                            TextBoxCYPN.Visible = true;

                            CheckBox1.Enabled = false;
                            CheckBox2.Enabled = false;

                            Button8.Enabled = false;
                            Button9.Enabled = false;


                            TextBox1.ReadOnly = true;
                            TextBox4.ReadOnly = true;
                            TextBox2.ReadOnly = true;
                            TextBox3.ReadOnly = true;
                            TextBox6.ReadOnly = true;
                            TextBox7.ReadOnly = true;
                            TextBox8.ReadOnly = true;
                            TextBox9.ReadOnly = true;
                            TextBoxCYPN.ReadOnly = true;
                            TextBoxAlternativeSourceInfo.ReadOnly = true;

                            TextBox1.ForeColor = Color.Gray;
                            TextBox4.ForeColor = Color.Gray;
                            TextBox2.ForeColor = Color.Gray;
                            TextBox3.ForeColor = Color.Gray;
                            TextBox6.ForeColor = Color.Gray;
                            TextBox7.ForeColor = Color.Gray;
                            TextBox8.ForeColor = Color.Gray;
                            TextBox9.ForeColor = Color.Gray;
                            TextBoxCYPN.ForeColor = Color.Gray;
                            TextBoxAlternativeSourceInfo.ForeColor = Color.Gray;

                            TextBox1.BorderColor = Color.Gray;
                            TextBox4.BorderColor = Color.Gray;
                            TextBox2.BorderColor = Color.Gray;
                            TextBox3.BorderColor = Color.Gray;
                            TextBox6.BorderColor = Color.Gray;
                            TextBox7.BorderColor = Color.Gray;
                            TextBox8.BorderColor = Color.Gray;
                            TextBox9.BorderColor = Color.Gray;
                            TextBoxCYPN.BorderColor = Color.Gray;
                            TextBoxAlternativeSourceInfo.BorderColor = Color.Gray;

                            FileUpload1.Visible = true;
                            FileUpload1.Enabled = false;
                            FileUpload2.Visible = true;
                            FileUpload2.Enabled = false;
                            FileUpload3.Visible = true;
                            FileUpload3.Enabled = false;
                            FileUpload4.Visible = true;
                            FileUpload4.Enabled = false;
                            FileUpload5.Visible = true;
                            FileUpload5.Enabled = false;
                            FileUpload6.Visible = true;
                            FileUpload6.Enabled = false;

                            LabelMisc.Visible = true;
                            LabelFootPrintFinal.Visible = true;
                            LabelLogicalSymbolFinal.Visible = true;

                            TextBox6.Visible = true;
                            TextBox7.Visible = true;
                            LabelFootPrintName.Visible = true;
                            LabelLogicalSymbolName.Visible = true;

                            LabelSummary.Visible = true;
                            TextBox5.Visible = true;
                            LabelComments.Visible = true;
                            TextBox10.Visible = true;
                            LabelRemarks.Visible = true;
                            TextBox11.Visible = true;



                        }
                    }


                }


            }
            else if (mode.ToString() == WorkMode.Review.ToString())
            {
                Button2.Text = "Save";
                Button3.Text = "Submit";
                Button5.Text = "Exit";

                Approver = user;
                Label_User.Text = user + " (Approver)";

                Button2.Enabled = false;
                Button2.ForeColor = Color.Gray;
                Button2.BorderColor = Color.Gray;

                FileUpload4.Visible = true;
                TextBox10.ReadOnly = false;
                TextBox6.ReadOnly = false;
                TextBox7.ReadOnly = false;
                TextBox11.ReadOnly = true;
                //if (uID_number != null)
                //{
                //    UnID = uID_number.ToString();
                //}


                
                AcquireExistingItem(UnID);
                FillcontentIntoQueriedItem();
                UpdateSummary();

                if (!IsPostBack)
                {


                    if (ProjectStatus != null)
                    {
                        if (ProjectStatus.Contains("UnSubmitted"))
                        {
                            Button2.Text = "Save";
                            Button3.Text = "Submit";
                            Button5.Text = "Exit";

                            TextBox6.Visible = true;
                            TextBox7.Visible = true;
                            LabelFootPrintName.Visible = true;
                            LabelLogicalSymbolName.Visible = true;
                            LabelCYPN.Visible = true;
                            TextBoxCYPN.Visible = true;

                            CheckBox1.Enabled = false;
                            CheckBox2.Enabled = false;

                            Button8.Enabled = false;
                            Button9.Enabled = false;


                            TextBox1.ReadOnly = true;
                            TextBox4.ReadOnly = true;
                            TextBox2.ReadOnly = true;
                            TextBox3.ReadOnly = true;
                            TextBox6.ReadOnly = true;
                            TextBox7.ReadOnly = true;
                            TextBox8.ReadOnly = true;
                            TextBox9.ReadOnly = true;
                            TextBox11.ReadOnly = true;
                            TextBoxSpecialRequirements.ReadOnly = true;
                            TextBoxCYPN.ReadOnly = true;
                            TextBoxAlternativeSourceInfo.ReadOnly = true;

                            TextBox1.ForeColor = Color.Gray;
                            TextBox4.ForeColor = Color.Gray;
                            TextBox2.ForeColor = Color.Gray;
                            TextBox3.ForeColor = Color.Gray;
                            TextBox6.ForeColor = Color.Gray;
                            TextBox7.ForeColor = Color.Gray;
                            TextBox8.ForeColor = Color.Gray;
                            TextBox9.ForeColor = Color.Gray;
                            TextBox11.ForeColor = Color.Gray;
                            TextBoxSpecialRequirements.ForeColor = Color.Gray;
                            TextBoxCYPN.ForeColor = Color.Gray;
                            TextBoxAlternativeSourceInfo.ForeColor = Color.Gray;

                            TextBox1.BorderColor = Color.Gray;
                            TextBox4.BorderColor = Color.Gray;
                            TextBox2.BorderColor = Color.Gray;
                            TextBox3.BorderColor = Color.Gray;
                            TextBox6.BorderColor = Color.Gray;
                            TextBox7.BorderColor = Color.Gray;
                            TextBox8.BorderColor = Color.Gray;
                            TextBox9.BorderColor = Color.Gray;
                            TextBox11.BorderColor = Color.Gray;
                            TextBoxCYPN.BorderColor = Color.Gray;
                            TextBoxSpecialRequirements.BorderColor = Color.Gray;
                            TextBoxAlternativeSourceInfo.BorderColor = Color.Gray;

                            FileUpload1.Visible = true;
                            FileUpload1.Enabled = false;
                            FileUpload2.Visible = true;
                            FileUpload2.Enabled = false;
                            FileUpload3.Visible = true;
                            FileUpload3.Enabled = false;
                            FileUpload4.Visible = true;
                            FileUpload4.Enabled = false;
                            FileUpload5.Visible = true;
                            FileUpload5.Enabled = false;
                            FileUpload6.Visible = true;
                            FileUpload6.Enabled = false;

                            LabelMisc.Visible = true;
                            LabelFootPrintFinal.Visible = true;
                            LabelLogicalSymbolFinal.Visible = true;

                            TextBox6.Visible = true;
                            TextBox7.Visible = true;
                            LabelFootPrintName.Visible = true;
                            LabelLogicalSymbolName.Visible = true;

                            LabelSummary.Visible = true;
                            TextBox5.Visible = true;
                            LabelComments.Visible = true;
                            TextBox10.Visible = true;
                            LabelRemarks.Visible = true;
                            TextBox11.Visible = true;
                        }

                        

                        if (ProjectStatus.Contains("Working"))
                        {
                            Button2.Text = "Save";
                            Button3.Text = "Submit";
                            Button5.Text = "Exit";

                            TextBox6.Visible = true;
                            TextBox7.Visible = true;
                            LabelFootPrintName.Visible = true;
                            LabelLogicalSymbolName.Visible = true;
                            LabelCYPN.Visible = true;
                            TextBoxCYPN.Visible = true;
                            TextBox11.Visible = false;
                            LabelRemarks.Visible = false;

                            CheckBox1.Enabled = false;
                            CheckBox2.Enabled = false;

                            Button8.Enabled = false;
                            Button9.Enabled = false;


                            TextBox1.ReadOnly = true;
                            TextBox4.ReadOnly = true;
                            TextBox2.ReadOnly = true;
                            TextBox3.ReadOnly = true;
                            TextBox6.ReadOnly = false;
                            TextBox7.ReadOnly = false;
                            TextBox8.ReadOnly = true;
                            TextBox9.ReadOnly = true;
                            TextBoxCYPN.ReadOnly = false;
                            TextBoxAlternativeSourceInfo.ReadOnly = true;
                            TextBoxSpecialRequirements.ReadOnly = true;

                            TextBox1.ForeColor = Color.Gray;
                            TextBox4.ForeColor = Color.Gray;
                            TextBox2.ForeColor = Color.Gray;
                            TextBox3.ForeColor = Color.Gray;
                            TextBox6.ForeColor = Color.Black;
                            TextBox7.ForeColor = Color.Black;
                            TextBox8.ForeColor = Color.Gray;
                            TextBox9.ForeColor = Color.Gray;
                            TextBoxCYPN.ForeColor = Color.Black;
                            TextBoxAlternativeSourceInfo.ForeColor = Color.Gray;
                            TextBoxSpecialRequirements.ForeColor = Color.Gray;


                            TextBox1.BorderColor = Color.Gray;
                            TextBox4.BorderColor = Color.Gray;
                            TextBox2.BorderColor = Color.Gray;
                            TextBox3.BorderColor = Color.Gray;
                            TextBox6.BorderColor = Color.Black;
                            TextBox7.BorderColor = Color.Black;
                            TextBox8.BorderColor = Color.Gray;
                            TextBox9.BorderColor = Color.Gray;
                            TextBoxCYPN.BorderColor = Color.Black;
                            TextBoxAlternativeSourceInfo.BorderColor = Color.Gray;
                            TextBoxSpecialRequirements.BorderColor = Color.Gray;


                            FileUpload1.Visible = true;
                            FileUpload1.Enabled = false;
                            FileUpload2.Visible = true;
                            FileUpload2.Enabled = false;
                            FileUpload3.Visible = true;
                            FileUpload3.Enabled = false;
                            FileUpload4.Visible = true;
                            FileUpload4.Enabled = true;
                            FileUpload5.Visible = true;
                            FileUpload5.Enabled = true;
                            FileUpload6.Visible = true;
                            FileUpload6.Enabled = true;

                            LabelMisc.Visible = true;
                            LabelFootPrintFinal.Visible = true;
                            LabelLogicalSymbolFinal.Visible = true;

                            TextBox6.Visible = true;
                            TextBox7.Visible = true;
                            LabelFootPrintName.Visible = true;
                            LabelLogicalSymbolName.Visible = true;

                            LabelSummary.Visible = true;
                            TextBox5.Visible = true;
                            LabelComments.Visible = true;
                            TextBox10.Visible = true;




                        }

                        if (ProjectStatus.Contains("Pending") || ProjectStatus.Contains("Approved") || ProjectStatus.Contains("Rejected"))
                        {
                            Button2.Text = "Save";
                            Button3.Text = "Submit";
                            Button5.Text = "Exit";

                            Button3.Enabled = false;
                            Button3.ForeColor = Color.Gray;
                            Button3.BorderColor = Color.Gray;

                            Button7.Enabled = false;
                            Button7.ForeColor = Color.Gray;
                            Button7.BorderColor = Color.Gray;

                            CheckBox1.Enabled = false;
                            CheckBox2.Enabled = false;

                            Button8.Enabled = false;
                            Button9.Enabled = false;

                            LabelMisc.Visible = false;

                            TextBox1.ReadOnly = true;
                            TextBox4.ReadOnly = true;
                            TextBox2.ReadOnly = true;
                            TextBox3.ReadOnly = true;
                            TextBox6.ReadOnly = true;
                            TextBox7.ReadOnly = true;
                            TextBox8.ReadOnly = true;
                            TextBox9.ReadOnly = true;
                            TextBox10.ReadOnly = true;
                            TextBox11.ReadOnly = true;
                            TextBoxSpecialRequirements.ReadOnly = true;
                            TextBoxAlternativeSourceInfo.ReadOnly = true;

                            TextBox1.ForeColor = Color.Gray;
                            TextBox4.ForeColor = Color.Gray;
                            TextBox2.ForeColor = Color.Gray;
                            TextBox3.ForeColor = Color.Gray;
                            TextBox6.ForeColor = Color.Gray;
                            TextBox7.ForeColor = Color.Gray;
                            TextBox8.ForeColor = Color.Gray;
                            TextBox9.ForeColor = Color.Gray;
                            TextBox10.ForeColor = Color.Gray;
                            TextBox11.ForeColor = Color.Gray;
                            TextBoxSpecialRequirements.ForeColor = Color.Gray;
                            TextBoxAlternativeSourceInfo.ForeColor = Color.Gray;

                            TextBox1.BorderColor = Color.Gray;
                            TextBox4.BorderColor = Color.Gray;
                            TextBox2.BorderColor = Color.Gray;
                            TextBox3.BorderColor = Color.Gray;
                            TextBox6.BorderColor = Color.Gray;
                            TextBox7.BorderColor = Color.Gray;
                            TextBox8.BorderColor = Color.Gray;
                            TextBox9.BorderColor = Color.Gray;
                            TextBox10.BorderColor = Color.Gray;
                            TextBox11.BorderColor = Color.Gray;
                            TextBoxSpecialRequirements.BorderColor = Color.Gray;
                            TextBoxAlternativeSourceInfo.BorderColor = Color.Gray;


                            TextBox6.Visible = false;
                            TextBox7.Visible = false;
                            LabelFootPrintName.Visible = false;
                            LabelLogicalSymbolName.Visible = false;

                            FileUpload1.Visible = true;
                            FileUpload1.Enabled = false;
                            FileUpload2.Visible = true;
                            FileUpload2.Enabled = false;
                            FileUpload3.Visible = true;
                            FileUpload3.Enabled = false;
                            FileUpload4.Visible = false;
                            FileUpload4.Enabled = false;
                            FileUpload5.Visible = false;
                            FileUpload5.Enabled = false;
                            FileUpload6.Visible = false;
                            FileUpload6.Enabled = false;

                            LabelSummary.Visible = true;
                            TextBox5.Visible = true;
                            LabelComments.Visible = false;
                            TextBox10.Visible = false;
                            LabelRemarks.Visible = false;
                            TextBox11.Visible = false;


                        }

                        if (ProjectStatus.Contains("Completed"))
                        {
                            Button2.Text = "Delete";
                            Button2.ForeColor = Color.Red;
                            //Button2.Enabled = true;
                            Button3.Text = "Submit";
                            Button5.Text = "Exit";

                            TextBox6.Visible = true;
                            TextBox7.Visible = true;
                            LabelFootPrintName.Visible = true;
                            LabelLogicalSymbolName.Visible = true;
                            LabelCYPN.Visible = true;
                            TextBoxCYPN.Visible = true;

                            CheckBox1.Enabled = false;
                            CheckBox2.Enabled = false;

                            Button8.Enabled = false;
                            Button9.Enabled = false;
                            Button3.Enabled = false;


                            TextBox1.ReadOnly = true;
                            TextBox4.ReadOnly = true;
                            TextBox2.ReadOnly = true;
                            TextBox3.ReadOnly = true;
                            TextBox6.ReadOnly = true;
                            TextBox7.ReadOnly = true;
                            TextBox8.ReadOnly = true;
                            TextBox9.ReadOnly = true;
                            TextBox11.ReadOnly = true;
                            TextBoxSpecialRequirements.ReadOnly = true;
                            TextBoxCYPN.ReadOnly = true;
                            TextBoxAlternativeSourceInfo.ReadOnly = true;

                            TextBox1.ForeColor = Color.Gray;
                            TextBox4.ForeColor = Color.Gray;
                            TextBox2.ForeColor = Color.Gray;
                            TextBox3.ForeColor = Color.Gray;
                            TextBox6.ForeColor = Color.Gray;
                            TextBox7.ForeColor = Color.Gray;
                            TextBox8.ForeColor = Color.Gray;
                            TextBox9.ForeColor = Color.Gray;
                            TextBox11.ForeColor = Color.Gray;
                            TextBoxSpecialRequirements.ForeColor = Color.Gray;
                            TextBoxCYPN.ForeColor = Color.Gray;
                            TextBoxAlternativeSourceInfo.ForeColor = Color.Gray;

                            TextBox1.BorderColor = Color.Gray;
                            TextBox4.BorderColor = Color.Gray;
                            TextBox2.BorderColor = Color.Gray;
                            TextBox3.BorderColor = Color.Gray;
                            TextBox6.BorderColor = Color.Gray;
                            TextBox7.BorderColor = Color.Gray;
                            TextBox8.BorderColor = Color.Gray;
                            TextBox9.BorderColor = Color.Gray;
                            TextBox11.BorderColor = Color.Gray;
                            TextBoxCYPN.BorderColor = Color.Gray;
                            TextBoxSpecialRequirements.BorderColor = Color.Gray;
                            TextBoxAlternativeSourceInfo.BorderColor = Color.Gray;

                            FileUpload1.Visible = true;
                            FileUpload1.Enabled = false;
                            FileUpload2.Visible = true;
                            FileUpload2.Enabled = false;
                            FileUpload3.Visible = true;
                            FileUpload3.Enabled = false;
                            FileUpload4.Visible = true;
                            FileUpload4.Enabled = false;
                            FileUpload5.Visible = true;
                            FileUpload5.Enabled = false;
                            FileUpload6.Visible = true;
                            FileUpload6.Enabled = false;

                            LabelMisc.Visible = true;
                            LabelFootPrintFinal.Visible = true;
                            LabelLogicalSymbolFinal.Visible = true;
                            LabelDataSheet.Visible = true;
                            LabelFootPrint.Visible = true;
                            LabelLogicalSymbol.Visible = true;


                            LinkButtonDataSheet.Visible = true;
                            LinkButtonRefFootPrint.Visible = true;
                            LinkButtonRefLogicalSymbol.Visible = true;
                            LinkButtonMisc.Visible = true;
                            LinkButtonFinalFootPrint.Visible = true;
                            LinkButtonFinalLogicalSymbol.Visible = true;

                            TextBox6.Visible = true;
                            TextBox7.Visible = true;
                            LabelFootPrintName.Visible = true;
                            LabelLogicalSymbolName.Visible = true;

                            LabelSummary.Visible = true;
                            TextBox5.Visible = true;
                            LabelComments.Visible = true;
                            TextBox10.Visible = true;
                            LabelRemarks.Visible = true;
                            TextBox11.Visible = true;


                        }
                    }


                }

                if (ProjectStatus != null)
                {
                    if (!ProjectStatus.Contains("Completed"))
                    {
                        Button2.Text = "Delete";
                        Button2.ForeColor = Color.Red;
                        Button2.Enabled = true;
                    }
                }



            }


            Button7.Visible = false;





        }

        private string AcquireUnID(int id)
        {
            //SqlDataSourceAll.SelectCommand = String.Format("select [UnID] where [ID] = {0} ",id);
            //IEnumerable rows = SqlDataSourceAll.Select(DataSourceSelectArguments.Empty);

            IEnumerable rows = SqlDataSource9.Select(DataSourceSelectArguments.Empty);

            foreach (DataRowView row in rows)
            {
                
                UnID = row[0].ToString();

            }

            return UnID;
        }

        private void FillcontentIntoQueriedItem()
        {
            Label_ID.Text = id.ToString();
            //UnID;
            Label_DateTime.Text = DateTimeUTC.ToShortDateString() +" "+ DateTimeUTC.ToShortTimeString();
            Label_Initiator.Text = Initiator;
            if (ProjectCritical != null)
            {
                if (ProjectCritical.Contains("True"))
                {
                    CheckBox1.Checked = true;
                }
                else
                {
                    CheckBox1.Checked = false;
                }
                if (IsDoubleCheck)
                {
                    CheckBox2.Checked = true;
                }
                else
                {
                    CheckBox2.Checked = false;
                }

                Label_ProjectStatus.Text = ProjectStatus;
            }

            if (ProjectName != null)
            {
                TextBox1.Text = ProjectName;
            }
            if (ProjectMainPartVendorName != null)
            {
                TextBox4.Text = ProjectMainPartVendorName;

            }
            if (ProjectMainPartVendorPN != null)
            {
                TextBox2.Text = ProjectMainPartVendorPN;

            }
            if (ProjectMainPartDescription != null)
            {
                TextBox3.Text = ProjectMainPartDescription;
            }
            if (TextBoxAlternativeSourceInfo != null)
            {
                TextBoxAlternativeSourceInfo.Text = ProjectAlternativeSourceInfo;

            }
            if (TextBoxSpecialRequirements != null)
            {
                TextBoxSpecialRequirements.Text = SpecialRequirements;

            }

            if (ProjectMainPartStoredFileDataSheet != null)
            {
                if (File.Exists(ProjectMainPartStoredFileDataSheet))
                {
                    LinkButtonDataSheet.Visible = true;

                }
            }
            if (ProjectMainPartStoredFileFootPrint != null)
            {
                if (File.Exists(ProjectMainPartStoredFileFootPrint))
                {
                    LinkButtonRefFootPrint.Visible = true;
                }
            }
            if (ProjectMainPartStoredFileLogicalSymbol != null)
            {
                if (File.Exists(ProjectMainPartStoredFileLogicalSymbol))
                {
                    LinkButtonRefLogicalSymbol.Visible = true;
                }
            }
            if (MiscStoredFile != null)
            {
                if (File.Exists(MiscStoredFile))
                {
                    LinkButtonMisc.Visible = true;
                }
            }
            if (ProjectStatus != null)
            {
                if (ProjectStatus.Contains("Working"))
                {
                    if (CYPN != null && (CYPN.Trim().Replace("&nbsp;", "").Length > 0))
                    {
                        if (!IsPostBack)
                        {
                            TextBoxCYPN.Text = CYPN;
                        }
                        

                    }
                    if (ProjectMainPartFootPrintName != null && (ProjectMainPartFootPrintName.Trim().Replace("&nbsp;", "").Length > 0))
                    {
                        
                        if (!IsPostBack)
                        {
                            TextBox6.Text = ProjectMainPartFootPrintName;
                        }

                    }
                    if (ProjectMainPartLogicalSymbolName != null && (ProjectMainPartLogicalSymbolName.Trim().Replace("&nbsp;", "").Length > 0))
                    {
                        
                        if (!IsPostBack)
                        {
                            TextBox7.Text = ProjectMainPartLogicalSymbolName;
                        }

                    }
                    if (ProjectMainPartStoredFileFootPrintFinal != null)
                    {
                        if (!IsPostBack)
                        {
                            if (File.Exists(ProjectMainPartStoredFileFootPrintFinal))
                            {
                                LinkButtonFinalFootPrint.Visible = true;
                            }
                        }

                    }
                    if (ProjectMainPartStoredFileLogicalSymbolFinal != null)
                    {
                        if (!IsPostBack)
                        {
                            if (File.Exists(ProjectMainPartStoredFileLogicalSymbolFinal))
                            {
                                LinkButtonFinalLogicalSymbol.Visible = true;
                            }
                        }

                    }
                }
            }







            if (mode.ToString() == WorkMode.Modify.ToString())
            {
                //TextBox5.Text = Summary;
                //TextBox10.Text = Comments;

                if (Remarks != null)
                {
                    if (Remarks.Length > 0)
                    {
                        TextBox11.Text = Remarks;
                    }
                }
                if (Summary != null)
                {
                    if (Summary.Length > 0)
                    {
                        TextBox5.Text = Summary;
                    }
                }
                if (Comments != null)
                {
                    if (Comments.Length > 0)
                    {
                        TextBox10.Text = Comments;
                    }
                }


            }


            if (mode.ToString() == WorkMode.Review.ToString())
            {
                TextBox5.Text = Summary;
                TextBox10.Text = Comments;

                if (Remarks != null)
                {
                    if (Remarks.Length > 0)
                    {
                        TextBox11.Text = Remarks;
                    }
                }
                if (Summary != null)
                {
                    if (Summary.Length > 0)
                    {
                        TextBox5.Text = Summary;
                    }
                }
                if (Comments != null)
                {
                    if (Comments.Length > 0)
                    {
                        TextBox10.Text = Comments;
                    }
                }

            }
            

            //Approver;
            //IsApproved;
            //Comments;
        }

        private void AcquireExistingItem(object uID_number)
        {
            //Get the current working by UniqueID
            //order by DateTimeUTC desc and initiator
            SqlDataSource8.FilterExpression = "";
            SqlDataSource8.FilterExpression = String.Format("[UnID] = '{0}'", uID_number);
            IEnumerable rows = SqlDataSource8.Select(DataSourceSelectArguments.Empty);

            foreach (DataRowView row in rows)
            {

                id                                 = (int)row[0];
                UnID                               = row[1].ToString();
                DateTimeUTC                        = (DateTime)row[2];
                Initiator                              = row[3].ToString();
                ProjectCritical                        = row[4].ToString(); 
                ProjectStatus                          = row[5].ToString();
                ProjectName                            = row[6].ToString();
                ProjectMainPartVendorName              = row[7].ToString();
                ProjectMainPartVendorPN                = row[8].ToString();
                ProjectMainPartDescription             = row[9].ToString();
                ProjectMainPartStoredFileDataSheet     = row[10].ToString();
                ProjectMainPartFootPrintName           = row[11].ToString();
                ProjectMainPartStoredFileFootPrint     = row[12].ToString();
                ProjectMainPartLogicalSymbolName       = row[13].ToString();
                ProjectMainPartStoredFileLogicalSymbol = row[14].ToString();
                ProjectAlternativeSourceInfo           = row[15].ToString();
                

                Approver = row[16].ToString();
                IsApproved = (bool)row[17];
                Comments = row[18].ToString();                
                Summary = row[20].ToString();
                MiscStoredFile = row[21].ToString();
                IsCompleted = (bool)row[22];
                IsDoubleCheck = (bool)row[23];
                ProjectMainPartStoredFileFootPrintFinal = row[24].ToString();
                ProjectMainPartStoredFileLogicalSymbolFinal = row[25].ToString();
                CYPN = row[26].ToString();
                SpecialRequirements = row[27].ToString();

                if (!ProjectStatus.Contains("Approved")&& mode.ToString() != WorkMode.New.ToString())
                {
                    Remarks = row[19].ToString();
                }
                else
                {
                    Remarks = TextBox11.Text;
                }
                

            }




        }

        private int AcquireNewItem()
        {
            int Cnt = 0;

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
           ,'UnSubmitted')", Initiator);

            Cnt = SqlDataSource1.Insert();


            return Cnt;



        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            int Cnt = -1;

            if (mode.ToString() == WorkMode.New.ToString())
            {
                SqlDataSource1.DeleteCommand = String.Format(
    @"DELETE FROM [dbo].[Items1]
      WHERE [ID] = '{0}'", id.ToString());

                Cnt = SqlDataSource1.Delete();
            }
            else
            {
                Cnt = 0;
            }



            

            if (Cnt == 0)
            {
                //this.Response.Write("<script>alert('Go back to Homepage ... ')</script>");
            }
            else if (Cnt > 0)
            {
                this.Response.Write("<script>alert('Delete the Unsubmitted item from database successfully!!!')</script>");
            }
            else
            {
                this.Response.Write("<script>alert('Delete the Unsubmitted item from database failure!!!')</script>");
            }

            if (mode.ToString() == WorkMode.Modify.ToString())
            {
                if (ProjectStatus != null)
                {
                    if (ProjectStatus.Contains("Working"))
                    {
                        this.Response.Write("<script>alert('Requestor disagreed the approver's working content and ProjectStatus goes back to Approved!!!')</script>");
                        ProjectStatus = "Approved";
                        Update2Database(nameof(ProjectStatus).ToString(),ProjectStatus);
                        Update2Database(nameof(Remarks).ToString(), Remarks);
                    }
                }
            }



            this.Response.Write("<script>window.location='Default.aspx'</script>");
        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {
            //Summary = TextBox5.Text;
            //Update2Database(nameof(Summary).ToString(),Summary);
            Button3.Focus();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            ProjectName = TextBox1.Text;
            Update2Database(nameof(ProjectName).ToString(),ProjectName);
            //UpdateSummary();
        }



        private void UpdateSummary()
        {

            AcquireExistingItem(UnID);
            FillcontentIntoQueriedItem();

            TrimFieldBeforeUpdate();
            if (ProjectStatus != null)
            {
                TextBox5.Text = "";
                TextBox5.Text += String.Format("Hello, {0}! \n\n", user);
                TextBox5.Text += String.Format("Below information is created on {0}. \n", DateTimeUTC);
                TextBox5.Text += String.Format("<<=========================================================== Work Basic Information ======================================================>> \n");
                TextBox5.Text += String.Format("[ProjectName                            ]:           \t\t\t\t{0} \n", ProjectName);
                TextBox5.Text += String.Format("[ProjectID                              ]:           \t\t\t\t#{0} \n", id.ToString());
                TextBox5.Text += String.Format("[ProjectStatus                          ]:           \t\t\t\t{0} \n", ProjectStatus);
                TextBox5.Text += String.Format("[ProjectCritical                        ]:           \t\t\t\t{0} \n", ProjectCritical);
                TextBox5.Text += String.Format("[IsDoubleCheck                          ]:           \t\t\t\t{0} \n", IsDoubleCheck.ToString());
                TextBox5.Text += String.Format("[ProjectMainPartVendorName              ]:           \t\t\t\t{0} \n", ProjectMainPartVendorName);
                TextBox5.Text += String.Format("[ProjectMainPartVendorPN                ]:           \t\t\t\t{0} \n", ProjectMainPartVendorPN);
                TextBox5.Text += String.Format("[ProjectMainPartStoredFileDataSheet     ]:           \t\t\t\t{0} \n", ProjectMainPartStoredFileDataSheet);
                TextBox5.Text += String.Format("[ProjectMainPartStoredFileFootPrint     ]:           \t\t\t\t{0} \n", ProjectMainPartStoredFileFootPrint);
                TextBox5.Text += String.Format("[ProjectMainPartStoredFileLogicalSymbol ]:           \t\t\t\t{0} \n", ProjectMainPartStoredFileLogicalSymbol);
                TextBox5.Text += String.Format("[ProjectMainPartDescription             ]: \n{0} \n", ProjectMainPartDescription);
                TextBox5.Text += String.Format("[ProjectAlternativeSourceInfo           ]: \n{0} \n", ProjectAlternativeSourceInfo);
                TextBox5.Text += String.Format("[SpecialRequirements                    ]: \n{0} \n", SpecialRequirements);
                TextBox5.Text += String.Format("<<=========================================================== Work Basic Information ======================================================>> \n");

                if (ProjectStatus.Contains("Approved")|| ProjectStatus.Contains("Working")|| ProjectStatus.Contains("Completed"))
                {
                    TextBox5.Text += String.Format("\n\nApprover: \n{0} \n", Approver);
                    TextBox5.Text += String.Format("<<=========================================================== Review Work Result ======================================================>> \n");
                    TextBox5.Text += String.Format("[CYPN                                       ]:      \t\t\t\t{0} \n", CYPN);
                    TextBox5.Text += String.Format("[ProjectMainPartFootPrintName               ]:      \t\t\t\t{0} \n", ProjectMainPartFootPrintName);
                    TextBox5.Text += String.Format("[ProjectMainPartLogicalSymbolName           ]:      \t\t\t\t{0} \n", ProjectMainPartLogicalSymbolName);
                    TextBox5.Text += String.Format("[MiscStoredFile                             ]:      \t\t\t\t{0} \n", MiscStoredFile);
                    TextBox5.Text += String.Format("[ProjectMainPartStoredFileFootPrintFinal    ]:      \t\t\t\t{0} \n", ProjectMainPartStoredFileFootPrintFinal);
                    TextBox5.Text += String.Format("[ProjectMainPartStoredFileLogicalSymbolFinal]:      \t\t\t\t{0} \n", ProjectMainPartStoredFileLogicalSymbolFinal);
                    TextBox5.Text += String.Format("[Comments]:{0} \n", Comments);
                    TextBox5.Text += String.Format("[Remarks]: {0} offer the following remarks \n{1}\n", Initiator, Remarks);
                    TextBox5.Text += String.Format("<<=========================================================== Review Work Result ======================================================>> \n");
                }

            }
            else 
            {

            }


            TextBox5.Text += "\nBest Regards,";
            TextBox5.Text += "\nCypress IoT System (DotNotReply)";

            Summary = TextBox5.Text;

            
            Update2Database(nameof(Summary).ToString(),Summary);
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {
            ProjectMainPartVendorName = TextBox4.Text;
            Update2Database(nameof(ProjectMainPartVendorName).ToString(), ProjectMainPartVendorName);
            //UpdateSummary();
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            ProjectMainPartVendorPN = TextBox2.Text;
            Update2Database(nameof(ProjectMainPartVendorPN).ToString(), ProjectMainPartVendorPN);
            //UpdateSummary();
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {
            ProjectMainPartDescription = TextBox3.Text;
            Update2Database(nameof(ProjectMainPartDescription).ToString(), ProjectMainPartDescription);
            //UpdateSummary();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {

            if (ProjectStatus.Contains("Working"))
            {
                MiscStoredFile = @"\\BMOCHINA01\c$\WEB\Attachments\Misc\" + FileUpload4.FileName;
                ProjectMainPartStoredFileFootPrintFinal = @"\\BMOCHINA01\c$\WEB\Attachments\FootPrint\" + FileUpload5.FileName;
                ProjectMainPartStoredFileLogicalSymbolFinal = @"\\BMOCHINA01\c$\WEB\Attachments\LogicalSymbol\" + FileUpload6.FileName;
            }
            else
            {
                ProjectMainPartStoredFileDataSheet = @"\\BMOCHINA01\c$\WEB\Attachments\Datasheet\" + FileUpload1.FileName;
                ProjectMainPartStoredFileFootPrint = @"\\BMOCHINA01\c$\WEB\Attachments\FootPrint\" + FileUpload2.FileName;
                ProjectMainPartStoredFileLogicalSymbol = @"\\BMOCHINA01\c$\WEB\Attachments\LogicalSymbol\" + FileUpload3.FileName;
            }



            try
            {
                if (FileUpload1.HasFile)
                {
                    FileUpload1.PostedFile.SaveAs(ProjectMainPartStoredFileDataSheet);
                    if (File.Exists(ProjectMainPartStoredFileDataSheet))
                    {
                        LinkButtonDataSheet.Visible = true;

                    }
                }
                else
                {
                    
                }
                  
                if (FileUpload2.HasFile)
                {
                    FileUpload2.PostedFile.SaveAs(ProjectMainPartStoredFileFootPrint);
                    if (File.Exists(ProjectMainPartStoredFileFootPrint))
                    {
                        LinkButtonRefFootPrint.Visible = true;
                    }
                }
                else
                {
                    
                }
                if (FileUpload3.HasFile)
                {
                    FileUpload3.PostedFile.SaveAs(ProjectMainPartStoredFileLogicalSymbol);
                    if (File.Exists(ProjectMainPartStoredFileLogicalSymbol))
                    {
                        LinkButtonRefLogicalSymbol.Visible = true;
                    }
                }
                else
                {
                    
                }
                if (FileUpload4.HasFile)
                {
                    FileUpload4.PostedFile.SaveAs(MiscStoredFile);
                    if (File.Exists(MiscStoredFile))
                    {
                        LinkButtonMisc.Visible = true;
                    }
                }
                else
                {
                    
                }
                if (FileUpload5.HasFile)
                {
                    FileUpload5.PostedFile.SaveAs(ProjectMainPartStoredFileFootPrintFinal);
                    if (File.Exists(ProjectMainPartStoredFileFootPrintFinal))
                    {
                        LinkButtonFinalFootPrint.Visible = true;
                    }
                }
                else
                {

                }
                if (FileUpload6.HasFile)
                {
                    FileUpload6.PostedFile.SaveAs(ProjectMainPartStoredFileLogicalSymbolFinal);
                    if (File.Exists(ProjectMainPartStoredFileLogicalSymbolFinal))
                    {
                        LinkButtonFinalLogicalSymbol.Visible = true;
                    }
                }
                else
                {

                }
            }
            catch (System.Exception ex)
            {
                this.Response.Write(String.Format(@"<script>alert('{0}: {1}')</script>", ex.Source, ex.Message));
            }




            Update2Database(nameof(ProjectMainPartStoredFileDataSheet).ToString(),ProjectMainPartStoredFileDataSheet);
            Update2Database(nameof(ProjectMainPartStoredFileFootPrint).ToString(), ProjectMainPartStoredFileFootPrint);
            Update2Database(nameof(ProjectMainPartStoredFileLogicalSymbol).ToString(), ProjectMainPartStoredFileLogicalSymbol);
            Update2Database(nameof(MiscStoredFile).ToString(), MiscStoredFile);
            Update2Database(nameof(ProjectMainPartStoredFileFootPrintFinal).ToString(), ProjectMainPartStoredFileFootPrintFinal);
            Update2Database(nameof(ProjectMainPartStoredFileLogicalSymbolFinal).ToString(), ProjectMainPartStoredFileLogicalSymbolFinal);

            UpdateSummary();
            TextBox5.Focus();
        }

        protected void TextBoxCYPN_TextChanged(object sender, EventArgs e)
        {
            CYPN = TextBoxCYPN.Text;

            //UpdateSummary();

            Update2Database(nameof(CYPN).ToString(), CYPN);
        }

        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {
            ProjectMainPartFootPrintName = TextBox6.Text;

            //UpdateSummary();

            Update2Database(nameof(ProjectMainPartFootPrintName).ToString(), ProjectMainPartFootPrintName);
        }

        protected void TextBox7_TextChanged(object sender, EventArgs e)
        {
            ProjectMainPartLogicalSymbolName = TextBox7.Text;

            //UpdateSummary();

            Update2Database(nameof(ProjectMainPartLogicalSymbolName).ToString(), ProjectMainPartLogicalSymbolName);
        }

        protected void TextBoxAlternativeSourceInfo_TextChanged(object sender, EventArgs e)
        {
            ProjectAlternativeSourceInfo = TextBoxAlternativeSourceInfo.Text;

            //UpdateSummary();

            Update2Database(nameof(ProjectAlternativeSourceInfo).ToString(), ProjectAlternativeSourceInfo);
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            int bit = -1;

            if (CheckBox1.Checked)
            {
                ProjectCritical = "True";
                bit = 1;
            }
            else
            {
                ProjectCritical = "False";
                bit = 0;
            }


            

            Update2Database(nameof(ProjectCritical).ToString(), ProjectCritical);

            //UpdateSummary();

        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

            int bit = -1;

            if (CheckBox1.Checked)
            {
                IsDoubleCheck = true;
                bit = 1;
            }
            else
            {
                IsDoubleCheck = false;
                bit = 0;
            }


            

            Update2Database(nameof(IsDoubleCheck).ToString(), bit);

            //UpdateSummary();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            int Cnt = -1;

            if (mode.ToString() == WorkMode.Review.ToString())
            {

                SqlDataSource1.DeleteCommand = String.Format(
@"DELETE FROM [dbo].[Items1]
      WHERE [ID] = '{0}'", id.ToString());

                Cnt = SqlDataSource1.Delete();

                if (Cnt == 0)
                {
                    //this.Response.Write("<script>alert('Go back to Homepage ... ')</script>");
                }
                else if (Cnt > 0)
                {
                    this.Response.Write("<script>alert('Delete the Unsubmitted item from database successfully!!!')</script>");
                }
                else
                {
                    this.Response.Write("<script>alert('Delete the Unsubmitted item from database failure!!!')</script>");
                }

            }
            else
            {
                Cnt = 0;
            }

            UpdateSummary();

            if (Update2Database() > 0)
            {

            }
            else
            {
                //this.Response.Write("<script>alert('Fail to Update data to SQL Server when Save()')</script>");
            }

            


            TextBox5.Focus();
            this.Response.Write("<script>window.location='Default.aspx'</script>");
        }

        private int Update2Database(string item_name,string value)
        {
            int Cnt = -1;



            TrimFieldBeforeUpdate();

            if (UnID != null)
            {
                try
                {
                    SqlDataSourceAll.UpdateCommand = String.Format(@"

UPDATE [dbo].[Items1]
   SET 
      [{0}] = '{1}'

 WHERE [UnID] = '{2}'

", item_name,value, UnID);

                    Cnt = SqlDataSourceAll.Update();

                }
                catch (System.Exception ex)
                {
                    string msg = String.Format("<script>alert('Fail to Update data to SQL Server dut that {0}')</script>", ex);
                    this.Response.Write(msg);
                }



            }
            return Cnt;
        }

        private int Update2Database(string item_name, int bitvalue)
        {
            int Cnt = -1;


            TrimFieldBeforeUpdate();

            if (UnID != null)
            {
                try
                {
                    SqlDataSourceAll.UpdateCommand = String.Format(@"

UPDATE [dbo].[Items1]
   SET 
      [{0}] = {1}

 WHERE [UnID] = '{2}'

", item_name, bitvalue, UnID);

                    Cnt = SqlDataSourceAll.Update();

                }
                catch (System.Exception ex)
                {

                    string msg = String.Format("<script>alert('Fail to Update data to SQL Server dut that {0}')</script>", ex);
                    this.Response.Write(msg);
                }



            }
            return Cnt;
        }

        private int Update2Database()
        {
            int Cnt = -1;

            AcquireExistingItem(UnID);
            FillcontentIntoQueriedItem();

            TrimFieldBeforeUpdate();

            if (UnID != null)
            {
                try
                {
                    SqlDataSource1.UpdateCommand = String.Format(@"

UPDATE [dbo].[Items1]
   SET 
      [ProjectCritical] = '{0}'
      ,[ProjectStatus] = '{1}'
      ,[ProjectName] = '{2}'
      ,[ProjectMainPartVendorName] = '{3}'
      ,[ProjectMainPartVendorPN] = '{4}'
      ,[ProjectMainPartDescription] = '{5}'
      ,[ProjectMainPartStoredFileDataSheet] = '{6}'
      ,[ProjectMainPartFootPrintName] = '{7}'
      ,[ProjectMainPartStoredFileFootPrint] = '{8}'
      ,[ProjectMainPartLogicalSymbolName] = '{9}'
      ,[ProjectMainPartStoredFileLogicalSymbol] = '{10}'
      ,[ProjectAlternativeSourceInfo] = '{11}'
      ,[Summary] = '{12}'
        ,[Comments] = '{13}'
        ,[Remarks] = '{14}'
        ,[MiscStoredFile] = '{15}'

      ,[ProjectMainPartStoredFileFootPrintFinal] = '{16}'
      ,[ProjectMainPartStoredFileLogicalSymbolFinal] = '{17}'
      ,[CYPN] = '{18}'
      ,[SpecialRequirements] = '{19}'


 WHERE [UnID] = '{20}'

", ProjectCritical, ProjectStatus, ProjectName, ProjectMainPartVendorName, ProjectMainPartVendorPN, ProjectMainPartDescription, ProjectMainPartStoredFileDataSheet, ProjectMainPartFootPrintName
, ProjectMainPartStoredFileFootPrint, ProjectMainPartLogicalSymbolName, ProjectMainPartStoredFileLogicalSymbol, ProjectAlternativeSourceInfo, Summary, Comments, Remarks, MiscStoredFile,
ProjectMainPartStoredFileFootPrintFinal, ProjectMainPartStoredFileLogicalSymbolFinal, CYPN, SpecialRequirements, UnID);

                    Cnt = SqlDataSource1.Update();

                }
                catch (System.Exception ex)
                {

                    this.Response.Write("<script>alert('Fail to Update data to SQL Server when Save()')</script>");
                }



            }
            return Cnt;  
        }

        private void TrimFieldBeforeUpdate()
        {
            try
            {
                if (Initiator.Length > 0)
                {
                    Initiator = Initiator.Trim();
                }
                if (ProjectCritical.Length > 0)
                {
                    ProjectCritical = ProjectCritical.Trim();
                }
                if (ProjectStatus.Length > 0)
                {
                    ProjectStatus = ProjectStatus.Trim();
                }
                if (ProjectName.Length > 0)
                {
                    ProjectName = ProjectName.Trim();
                }
                if (ProjectMainPartVendorName.Length > 0)
                {
                    ProjectMainPartVendorName = ProjectMainPartVendorName.Trim();
                }
                if (ProjectMainPartVendorPN.Length > 0)
                {
                    ProjectMainPartVendorPN = ProjectMainPartVendorPN.Trim();
                }
                if (ProjectMainPartDescription.Length > 0)
                {
                    ProjectMainPartDescription = ProjectMainPartDescription.Trim();
                }
                if (ProjectMainPartStoredFileDataSheet.Length > 0)
                {
                    ProjectMainPartStoredFileDataSheet = ProjectMainPartStoredFileDataSheet.Trim();
                }
                if (ProjectMainPartFootPrintName.Length > 0)
                {
                    ProjectMainPartFootPrintName = ProjectMainPartFootPrintName.Trim();
                }
                if (ProjectMainPartStoredFileFootPrint.Length > 0)
                {
                    ProjectMainPartStoredFileFootPrint = ProjectMainPartStoredFileFootPrint.Trim();
                }
                if (ProjectMainPartLogicalSymbolName.Length > 0)
                {
                    ProjectMainPartLogicalSymbolName = ProjectMainPartLogicalSymbolName.Trim();
                }
                if (ProjectMainPartStoredFileLogicalSymbol.Length > 0)
                {
                    ProjectMainPartStoredFileLogicalSymbol = ProjectMainPartStoredFileLogicalSymbol.Trim();
                }
                if (ProjectAlternativeSourceInfo.Length > 0)
                {
                    ProjectAlternativeSourceInfo = ProjectAlternativeSourceInfo.Trim();
                }
                if (mode.ToString() == WorkMode.Review.ToString())
                {
                    if (Approver.Length > 0)
                    {
                        Approver = Approver.Trim();
                    }
                    if (Comments.Length > 0)
                    {
                        Comments = Comments.Trim();
                    }
                    if (Remarks.Length > 0)
                    {
                        Remarks = Remarks.Trim();
                    }
                    if (Summary.Length > 0)
                    {
                        Summary = Summary.Trim();
                    }
                    if (MiscStoredFile.Length > 0)
                    {
                        MiscStoredFile = MiscStoredFile.Trim();
                    }
                }
                }
            catch (System.Exception ex)
            {

                
            }

            



        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            
            AcquireExistingItem(UnID);
            FillcontentIntoQueriedItem();

            if (!CheckRequiredItemIsNotNull())
            {
                return;
            }


            Button7_Click(this, EventArgs.Empty);

            if (mode.ToString() == WorkMode.New.ToString())
            {
                ProjectStatus = "Pending";
            }
            else if (mode.ToString() == WorkMode.Modify.ToString() && (ProjectStatus.Contains("UnSubmitted")|| ProjectStatus.Contains("Rejected")))
            {
                ProjectStatus = "Pending";
            }
            else if (mode.ToString() == WorkMode.Modify.ToString() && (ProjectStatus.Contains("Working")))
            {
                Update2Database(nameof(Remarks).ToString(), Remarks);
                ProjectStatus = "Completed";
                //if (Remarks.Length > 0)
                //{
                //    ProjectStatus = "Completed";
                //}
                //else
                //{
                //    ProjectStatus = "Working";
                //    this.Response.Write("<script>alert('This item cannot be completed because it requires remarks by initiator')</script>");
                //    return;
                //}

            }

            if (mode.ToString() == WorkMode.Review.ToString())
            {
                Update2Database(nameof(Comments).ToString(),Comments);
                Update2Database(nameof(CYPN).ToString(), CYPN);
                Update2Database(nameof(ProjectMainPartFootPrintName).ToString(), ProjectMainPartFootPrintName);
                Update2Database(nameof(ProjectMainPartLogicalSymbolName).ToString(), ProjectMainPartFootPrintName);
                Update2Database(nameof(MiscStoredFile).ToString(), MiscStoredFile);
                Update2Database(nameof(ProjectMainPartStoredFileFootPrintFinal).ToString(), ProjectMainPartStoredFileFootPrintFinal);
                Update2Database(nameof(ProjectMainPartStoredFileLogicalSymbolFinal).ToString(), ProjectMainPartStoredFileLogicalSymbolFinal);


                if (ProjectStatus.Contains("Working") && !IsDoubleCheck)
                {
                    ProjectStatus = "Completed";
                }
                else
                {
                    ProjectStatus = "Working";
                    this.Response.Write("<script>alert('This item cannot be completed because it requires double confirmation by initiator')</script>");
                    
                }
            }



            

            //Update2Database(nameof(Summary).ToString(), Summary);

            if (Update2Database(nameof(ProjectStatus).ToString(), ProjectStatus) > 0)
            {

            }
            else
            {
                //this.Response.Write("<script>alert('Fail to Update data to SQL Server when Save()')</script>");
            }

            UpdateSummary();

            if (ProjectStatus != null)
            {
                SendEmail(ProjectStatus);
            }
            


            




            this.Response.Write("<script>window.location='Default.aspx'</script>");

        }

        private void SendEmail(string projectStatus)
        {
            Email email = new Email();

            email.Subject = @"Message Info from bmochina01/iot/";

            email.To_address = user.Trim() + "@cypress.com;";


            if (projectStatus.Contains("Pending"))
            {
                
                
                email.Title = String.Format("IoT Part Request – submitted > Request ID#{0} has been submitted", id);
            }
            else if (projectStatus.Contains("Working"))
            {
                

                if (IsDoubleCheck)
                {
                    email.Title = String.Format("IoT Part Request – approved > Request ID#{0} has been approved.", id);
                }
                else
                {
                    email.Title = String.Format("IoT Part Request – approved > Request ID#{0} has been approved.", id);
                }
                
            }
            else if (projectStatus.Contains("Completed"))
            {
                

                email.Title = String.Format("IoT Part Request – completed > Request ID#{0} has been approved.", id);
            }

            string body = Summary.Replace("\n", "<br />");
            body = body.Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
            string content = String.Format("<HTML><H2>{0}</H2><BODY>{1}</BODY></HTML>", email.Title, body);

            if (projectStatus.Contains("Pending"))
            {
                //email.CC_address = Approver.Trim() + "@cypress.com;";
            }
            else if (projectStatus.Contains("Working"))
            {
                email.To_address = Initiator.Trim() + "@cypress.com;";
                email.CC_address = Approver.Trim() + "@cypress.com;";
            }
            else if (projectStatus.Contains("Completed"))
            {
                email.To_address = Initiator.Trim() + "@cypress.com;";
                email.CC_address = Approver.Trim() + "@cypress.com;";
            }


            Email.Send(email.To_address, email.CC_address,email.Subject, content);
        }

        private bool CheckRequiredItemIsNotNull()
        {
            bool retVal = true;

            AcquireExistingItem(UnID);
            FillcontentIntoQueriedItem();

            if (mode.ToString()== WorkMode.New.ToString())
            {
                if (ProjectMainPartVendorName.Trim().Replace("&nbsp;","") == "")
                {
                    retVal = false;
                }
                if (ProjectMainPartVendorPN.Trim().Replace("&nbsp;", "") == "")
                {
                    retVal = false;
                }
                if (ProjectMainPartDescription.Trim().Replace("&nbsp;", "") == "")
                {
                    retVal = false;
                }

            }

            if (mode.ToString() == WorkMode.Review.ToString())
            {
                

                if (ProjectStatus.Contains("Working"))
                {
                    if (ProjectMainPartVendorName.Trim().Replace("&nbsp;", "") == "")
                    {
                        retVal = false;
                    }
                    if (ProjectMainPartVendorPN.Trim().Replace("&nbsp;", "") == "")
                    {
                        retVal = false;
                    }
                    if (ProjectMainPartDescription.Trim().Replace("&nbsp;", "") == "")
                    {
                        retVal = false;
                    }
                    //if (ProjectMainPartStoredFileDataSheet.Trim().Replace("&nbsp;", "") == "")
                    //{
                    //    retVal = false;
                    //}
                    //if (ProjectMainPartStoredFileFootPrintFinal.Trim().Replace("&nbsp;", "") == "")
                    //{
                    //    retVal = false;
                    //}
                    //if (ProjectMainPartStoredFileLogicalSymbolFinal.Trim().Replace("&nbsp;", "") == "")
                    //{
                    //    retVal = false;
                    //}
                    if (CYPN.Trim().Replace("&nbsp;", "") == "")
                    {
                        retVal = false;
                    }
                    if (ProjectMainPartFootPrintName.Trim().Replace("&nbsp;", "") == "")
                    {
                        retVal = false;
                    }
                    if (ProjectMainPartLogicalSymbolName.Trim().Replace("&nbsp;", "") == "")
                    {
                        retVal = false;
                    }
                }
            }

            if (retVal)
            {

            }
            else
            {
                this.Response.Write("<script>alert('All the required* items must be not null. Please check it.')</script>");
            }

            return retVal;
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            AcquireExistingItem(UnID);
            FillcontentIntoQueriedItem();
            if ((TextBox8.Text.Length>0 && TextBox9.Text.Length>0))
            {
            ProjectAlternativeSourceInfo += "\nAlternative Vendor Name: " + TextBox8.Text + "\t\tVendor Part Number: " + TextBox9.Text;
                ProjectAlternativeSourceInfo = ProjectAlternativeSourceInfo.Trim().Replace("&nbsp;","");
            TextBoxAlternativeSourceInfo.Text = ProjectAlternativeSourceInfo.Trim();
            TextBox8.Text = "";
            TextBox9.Text = "";
                Update2Database(nameof(ProjectAlternativeSourceInfo), ProjectAlternativeSourceInfo);
                TextBoxAlternativeSourceInfo.Focus();
            }
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            AcquireExistingItem(UnID);
            FillcontentIntoQueriedItem();
            ProjectAlternativeSourceInfo = "";
            TextBoxAlternativeSourceInfo.Text = ProjectAlternativeSourceInfo;
            TextBox8.Text = "";
            TextBox9.Text = "";
            Update2Database(nameof(ProjectAlternativeSourceInfo), ProjectAlternativeSourceInfo);
            TextBoxAlternativeSourceInfo.Focus();
        }

        protected void TextBox10_TextChanged(object sender, EventArgs e)
        {
            Comments = TextBox10.Text;

            

            Update2Database(nameof(Comments), Comments);

            //UpdateSummary();
        }

        protected void TextBoxSpecialRequirements_TextChanged(object sender, EventArgs e)
        {
            SpecialRequirements = TextBoxSpecialRequirements.Text;

            

            Update2Database(nameof(SpecialRequirements), SpecialRequirements);
            //UpdateSummary();
        }

        protected void TextBox11_TextChanged(object sender, EventArgs e)
        {
            Remarks = TextBox11.Text;

            

            Update2Database(nameof(Remarks), Remarks);

            //UpdateSummary();
        }

        protected void HyperLinkDataSheet_DataBinding(object sender, EventArgs e)
        {

        }
        protected void LinkButtonDataSheetUrl_Click(object sender, EventArgs e)
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

        protected void LinkButtonRefFootPrint_Click(object sender, EventArgs e)
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

        protected void LinkButtonRefLogicalSymbol_Click(object sender, EventArgs e)
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

        protected void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}