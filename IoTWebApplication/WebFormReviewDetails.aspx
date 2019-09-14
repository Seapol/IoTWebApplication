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
            font-size: medium;
            margin-left: 80px;
        }
        .auto-style8 {
            font-size: medium;
        }
        .auto-style9 {
            font-size: x-large;
            width: 843px;
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
            <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style4" Height="300px" ReadOnly="True" TextMode="MultiLine" Width="90%" Visible="False" Rows="100"></asp:TextBox>
            <br />
            <div class="auto-style3">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" HorizontalAlign="Center" Width="90%" Caption="Project Information">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                        <asp:BoundField DataField="DateTimeUTC" HeaderText="DateTimeUTC" SortExpression="DateTimeUTC" />
                        <asp:BoundField DataField="Initiator" HeaderText="Initiator" SortExpression="Initiator" />
                        <asp:BoundField DataField="ProjectCritical" HeaderText="ProjectCritical" SortExpression="ProjectCritical" />
                        <asp:BoundField DataField="ProjectStatus" HeaderText="ProjectStatus" SortExpression="ProjectStatus" />
                        <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" SortExpression="ProjectName" />
                        <asp:CheckBoxField DataField="IsDoubleCheck" HeaderText="IsDoubleCheck" SortExpression="IsDoubleCheck" />
                        <asp:BoundField DataField="SpecialRequirements" HeaderText="SpecialRequirements" SortExpression="SpecialRequirements" />
                    </Columns>
                </asp:GridView>
            </div>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:IoTConnectionString19 %>" SelectCommand="SELECT [ID], [DateTimeUTC], [Initiator], [ProjectCritical], [ProjectStatus], [ProjectName], [IsDoubleCheck], [SpecialRequirements] FROM [Items1] WHERE ([ID] = @ID)">
                <SelectParameters>
                    <asp:SessionParameter Name="ID" SessionField="ID" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource4" HorizontalAlign="Center" Width="90%" Caption="Part Information">
                <Columns>
                    <asp:BoundField DataField="ProjectMainPartVendorName" HeaderText="ProjectMainPartVendorName" SortExpression="ProjectMainPartVendorName" />
                    <asp:BoundField DataField="ProjectMainPartVendorPN" HeaderText="ProjectMainPartVendorPN" SortExpression="ProjectMainPartVendorPN" />
                    <asp:BoundField DataField="ProjectMainPartDescription" HeaderText="ProjectMainPartDescription" SortExpression="ProjectMainPartDescription" />
                    <asp:BoundField DataField="ProjectAlternativeSourceInfo" HeaderText="ProjectAlternativeSourceInfo" SortExpression="ProjectAlternativeSourceInfo" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:IoTConnectionString20 %>" SelectCommand="SELECT [ProjectMainPartVendorName], [ProjectMainPartVendorPN], [ProjectMainPartDescription], [ProjectAlternativeSourceInfo] FROM [Items1] WHERE ([ID] = @ID)">
                <SelectParameters>
                    <asp:SessionParameter Name="ID" SessionField="ID" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" Caption="Uploaded Files" DataSourceID="SqlDataSource5" HorizontalAlign="Center" Width="90%">
                <Columns>
                    <asp:BoundField DataField="ProjectMainPartStoredFileDataSheet" HeaderText="ProjectMainPartStoredFileDataSheet" SortExpression="ProjectMainPartStoredFileDataSheet" />
                    <asp:BoundField DataField="ProjectMainPartStoredFileFootPrint" HeaderText="ProjectMainPartStoredFileFootPrint" SortExpression="ProjectMainPartStoredFileFootPrint" />
                    <asp:BoundField DataField="ProjectMainPartStoredFileLogicalSymbol" HeaderText="ProjectMainPartStoredFileLogicalSymbol" SortExpression="ProjectMainPartStoredFileLogicalSymbol" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:IoTConnectionString21 %>" SelectCommand="SELECT [ProjectMainPartStoredFileDataSheet], [ProjectMainPartStoredFileFootPrint], [ProjectMainPartStoredFileLogicalSymbol] FROM [Items1] WHERE ([ID] = @ID)">
                <SelectParameters>
                    <asp:SessionParameter Name="ID" SessionField="ID" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <span class="auto-style5">
            <div class="auto-style6">
                <br />
                <br />
                <div class="auto-style9">
                <asp:Label ID="Label1" runat="server" Text="[Part DataSheet File&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ]:" CssClass="auto-style8"></asp:Label>
                    <span class="auto-style8">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButtonDataSheet" runat="server" OnClick="LinkButtonDataSheet_Click">Review</asp:LinkButton>
                <br />
                <asp:Label ID="Label2" runat="server" Text="[Reference FootPrint File&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ]:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButtonFootPrint" runat="server" OnClick="LinkButtonFootPrint_Click">Review</asp:LinkButton>
                <br />
                <asp:Label ID="Label3" runat="server" Text="[Reference Logical Symbol File&nbsp; ]:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButtonLogicalSymbol" runat="server" OnClick="LinkButtonLogicalSymbol_Click">Review</asp:LinkButton>
                <br />
                <asp:LinkButton ID="LinkButtonFinalFootPrint" runat="server" OnClick="LinkButtonFinalFootPrint_Click" Visible="False">Review Final FootPrint File</asp:LinkButton>
                <br />
                <asp:LinkButton ID="LinkButtonFinalLogicalSymbol" runat="server" OnClick="LinkButtonFinalLogicalSymbol_Click" Visible="False">Review Final LogicalSymbol File</asp:LinkButton>
                <br />
                <asp:LinkButton ID="LinkButtonMisc" runat="server" OnClick="LinkButtonMisc_Click" Visible="False">Review Misc File</asp:LinkButton>
                    </span>
                </div>
                <br />
&nbsp;&nbsp;&nbsp; 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </div>
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
