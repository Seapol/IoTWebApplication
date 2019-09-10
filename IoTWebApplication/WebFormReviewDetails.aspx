<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormReviewDetails.aspx.cs" Inherits="IoTWebApplication.WebFormReviewDetails" %>

<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: xx-large;
        }
        .auto-style2 {
            font-size: xx-large;
            text-align: center;
        }
        .auto-style3 {
            text-align: center;
        }
        .auto-style4 {
            font-size: large;
        }
        .auto-style5 {
            font-size: x-large;
        }
        .auto-style6 {
            text-align: left;
        }
    </style>
</head>
<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <form id="form1" runat="server">
        <div class="auto-style2" style="border: thick solid #C0C0C0; position: relative; height: 5%; background-color: #66FF66;" title="Review Board">
            <strong style="position: relative"><span class="auto-style1">Review</span> &amp; Approval Detailed Information</strong></div>
        <div class="auto-style3">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:IoTConnectionString10 %>" SelectCommand="SELECT * FROM [Items1] ORDER BY [DateTimeUTC] DESC"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:IoTConnectionString11 %>" SelectCommand="SELECT * FROM [Items1]" UpdateCommand="UPDATE Items1 SET Approver = N'', IsApproved = 1, Comments = '', Summary = ''"></asp:SqlDataSource>
            <span class="auto-style5">Summary</span><br />
            <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style4" Height="300px" ReadOnly="True" TextMode="MultiLine" Width="90%"></asp:TextBox>
            <br />
            <span class="auto-style5">
            <div class="auto-style6">
            <span class="auto-style5">
                <br />
                <asp:LinkButton ID="LinkButtonDataSheet" runat="server" OnClick="LinkButtonDataSheet_Click">Review DataSheet File</asp:LinkButton>
            </span>
                <br />
                <asp:LinkButton ID="LinkButtonFootPrint" runat="server" OnClick="LinkButtonFootPrint_Click">Review Referernce FootPrint File</asp:LinkButton>
                <br />
                <asp:LinkButton ID="LinkButtonLogicalSymbol" runat="server" OnClick="LinkButtonLogicalSymbol_Click">Review Reference LogicalSymbol File</asp:LinkButton>
                <br />
                <asp:LinkButton ID="LinkButtonFinalFootPrint" runat="server" OnClick="LinkButtonFinalFootPrint_Click" Visible="False">Review Final FootPrint File</asp:LinkButton>
                <br />
                <asp:LinkButton ID="LinkButtonFinalLogicalSymbol" runat="server" OnClick="LinkButtonFinalLogicalSymbol_Click" Visible="False">Review Final LogicalSymbol File</asp:LinkButton>
                <br />
                <asp:LinkButton ID="LinkButtonMisc" runat="server" OnClick="LinkButtonMisc_Click" Visible="False">Review Misc File</asp:LinkButton>
                <br />
                <br />
&nbsp;&nbsp;&nbsp; <span class="auto-style5">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span>
            </div>
            <br />
            Comments<br />
            <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style4" Height="200px" Width="90%" TextMode="MultiLine"></asp:TextBox>
            </span>
        </div>
        <div class="auto-style3">
            <br />
            <asp:Button ID="Button_Approve" runat="server" CssClass="auto-style5" OnClick="Button_Approve_Click" Text="Approve" Width="200px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button_Reject" runat="server" CssClass="auto-style5" OnClick="Button_Reject_Click" Text="Reject" Width="200px" />
&nbsp;&nbsp;&nbsp;
        </div>
    </form>
</body>
</html>
