<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormReviewItems.aspx.cs" Inherits="IoTWebApplication.WebFormReviewItems" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            font-size: xx-large;
        }
        .auto-style2 {
            font-size: xx-large;
        }
        .auto-style3 {
            font-size: x-large;
        }
        .auto-style4 {
            text-align: center;
        }
        .auto-style5 {
            font-size: large;
        }
    </style>
</head>
<body style="height: auto">
    <form id="form1" runat="server" style="height: auto">
        <div class="auto-style1" style="border: thick solid #C0C0C0; position: relative; height: 5%; background-color: #66FF66;" title="Review Board">
            <strong>Review &amp; Approval Board</strong></div>
        <div>
            <span class="auto-style2">Hello, </span>
            <asp:LoginName ID="LoginName1" runat="server" CssClass="auto-style2" />
            <br />
            <br />
            <span class="auto-style3">You&#39;re eligable to review and approval the following items.</span><br />
            <br />
        </div>
        <div>
            <div style="border: thin none #000000; position: relative;" class="auto-style4">
            <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="90%" Caption="Pending -&gt; Approve OR Reject" CssClass="auto-style5" EmptyDataText="&lt;&lt;&lt; Empty Working Item &gt;&gt;&gt;">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="UnID" HeaderText="UnID" SortExpression="UnID" Visible="False" />
                    <asp:BoundField DataField="DateTimeUTC" HeaderText="DateTimeUTC" SortExpression="DateTimeUTC" />
                    <asp:BoundField DataField="Initiator" HeaderText="Initiator" SortExpression="Initiator" />
                    <asp:BoundField DataField="ProjectCritical" HeaderText="ProjectCritical" SortExpression="ProjectCritical" />
                    <asp:BoundField DataField="ProjectStatus" HeaderText="ProjectStatus" SortExpression="ProjectStatus" >
                    <ItemStyle Font-Bold="True" ForeColor="#00CC00" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" SortExpression="ProjectName" />
                    <asp:BoundField DataField="Approver" HeaderText="Approver" SortExpression="Approver" />
                    <asp:BoundField DataField="IsApproved" HeaderText="IsApproved" SortExpression="IsApproved" Visible="False" >
                    <ItemStyle Font-Bold="True" ForeColor="#FF9900" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Comments" HeaderText="Comments" SortExpression="Comments" />
                    
                    <asp:CommandField AccessibleHeaderText="Action" ButtonType="Button" HeaderText="Action" SelectText="Approve/Reject" ShowSelectButton="True" Visible="False">
                    <ControlStyle Width="100%" />
                    </asp:CommandField>
                    
                    <asp:HyperLinkField DataNavigateUrlFields="ID,UnID" DataNavigateUrlFormatString="WebFormReviewDetails?ID={0}&amp;UnID={1}" HeaderText="Review" Text="Approve or Reject &gt;&gt;" />
                    
                </Columns>
            </asp:GridView>
            </div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:IoTConnectionString4Overall %>" SelectCommand="SELECT [ID], [UnID], [DateTimeUTC], [Initiator], [ProjectCritical], [ProjectStatus], [ProjectName], [Approver], [IsApproved], [Comments] FROM [Items1] ORDER BY [DateTimeUTC] DESC"></asp:SqlDataSource>
        </div>
            <div class="auto-style4">
                <strong>
                <br />
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" CssClass="auto-style3" Height="40px" Text="Submit" Width="200px" OnClick="Button1_Click" Visible="False" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" CssClass="auto-style3" Height="40px" Text="Cancel" Width="200px" OnClick="Button2_Click" Visible="False" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <br />
                </strong>
                <div>
                    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" Caption="Approved -&gt; Completion OR Working" CssClass="auto-style5" DataSourceID="SqlDataSource2" HorizontalAlign="Center" Width="90%" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" EmptyDataText="&lt;&lt;&lt; Empty Working Item &gt;&gt;&gt;">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                            <asp:BoundField DataField="DateTimeUTC" HeaderText="DateTimeUTC" SortExpression="DateTimeUTC" />
                            <asp:BoundField DataField="Initiator" HeaderText="Initiator" SortExpression="Initiator" />
                            <asp:BoundField DataField="ProjectStatus" HeaderText="ProjectStatus" SortExpression="ProjectStatus" />
                            <asp:BoundField DataField="DesignName" HeaderText="DesignName" SortExpression="DesignName" />
                            <asp:BoundField DataField="VendorName" HeaderText="VendorName" SortExpression="VendorName" >
                            </asp:BoundField>
                            <asp:BoundField DataField="VendorPN" HeaderText="VendorPN" SortExpression="VendorPN" />
                            <asp:BoundField DataField="FootPrintName" HeaderText="FootPrintName" SortExpression="FootPrintName" />
                            <asp:BoundField DataField="LogicalSymbolName" HeaderText="LogicalSymbolName" SortExpression="LogicalSymbolName" />
                            <asp:BoundField DataField="CYPN" HeaderText="CYPN" SortExpression="CYPN" />
                            <asp:CommandField ButtonType="Button" HeaderText="Action" SelectText="Complete" ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="Label_WarningCompletion" runat="server" CssClass="auto-style5" Font-Bold="True" ForeColor="Red" Text="Note:**Action of Completion is irreversible. Any item cannot be modified further after completed."></asp:Label>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:IoTConnectionString15 %>" SelectCommand="SELECT [ID], [DateTimeUTC], [Initiator], [ProjectStatus], [ProjectName] as DesignName, [ProjectMainPartVendorName] as VendorName, [ProjectMainPartVendorPN] as VendorPN, [ProjectMainPartFootPrintName] as FootPrintName, [ProjectMainPartLogicalSymbolName] as LogicalSymbolName, [CYPN]  FROM [Items1] ORDER BY [DateTimeUTC] DESC"></asp:SqlDataSource>
                <strong>
                    <br />
                    <br />
                    <br />
                <asp:Button ID="Button4" runat="server" CssClass="auto-style3" Height="40px" Text="Submit" Width="200px" OnClick="Button4_Click" Visible="False" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button5" runat="server" CssClass="auto-style3" Height="40px" Text="Cancel" Width="200px" OnClick="Button5_Click" Visible="False" />
                    <br />
                    <br />
                    <br />
                    <div>
                        <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" Caption="Overall Review" CssClass="auto-style5" DataSourceID="SqlDataSource3" HorizontalAlign="Center" Width="90%" EmptyDataText="&lt;&lt;&lt; Empty Working Item &gt;&gt;&gt;" OnSelectedIndexChanged="GridView3_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                                <asp:BoundField DataField="DateTimeUTC" HeaderText="DateTimeUTC" SortExpression="DateTimeUTC" />
                                <asp:BoundField DataField="Initiator" HeaderText="Initiator" SortExpression="Initiator" />
                                <asp:BoundField DataField="ProjectStatus" HeaderText="ProjectStatus" SortExpression="ProjectStatus" />
                                <asp:BoundField DataField="DesignName" HeaderText="DesignName" SortExpression="DesignName" />
                                <asp:BoundField DataField="VendorName" HeaderText="VendorName" SortExpression="VendorName" />
                                <asp:BoundField DataField="VendorPN" HeaderText="VendorPN" SortExpression="VendorPN" >
                                </asp:BoundField>
                                <asp:BoundField DataField="IsCritical" HeaderText="IsCritical" SortExpression="IsCritical" />
                                <asp:BoundField DataField="Approver" HeaderText="Approver" SortExpression="Approver" />
                                <asp:BoundField DataField="FootPrintName" HeaderText="FootPrintName" SortExpression="FootPrintName" />
                                <asp:BoundField DataField="LogicalSymbolName" HeaderText="LogicalSymbolName" SortExpression="LogicalSymbolName" />
                                <asp:BoundField DataField="CYPN" HeaderText="CYPN" SortExpression="CYPN" />
                                <asp:CommandField ButtonType="Button" HeaderText="Action" SelectText="Review" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:IoTConnectionString16 %>" SelectCommand="SELECT [ID], [DateTimeUTC], [Initiator], [ProjectStatus] , [ProjectName] as DesignName, [ProjectMainPartVendorName] as VendorName, [ProjectMainPartVendorPN] as VendorPN, [ProjectCritical] as IsCritical, [Approver], [ProjectMainPartFootPrintName] as FootPrintName, [ProjectMainPartLogicalSymbolName] as LogicalSymbolName, [CYPN] FROM [Items1] ORDER BY [DateTimeUTC] DESC"></asp:SqlDataSource>
                    </div>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                <asp:Button ID="Button3" runat="server" CssClass="auto-style3" Height="40px" Text="Exit" Width="200px" OnClick="Button3_Click" />
                    <br />
                </strong>
                    <br />
                    <strong>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </strong>
                </div>
            </div>
    </form>
</body>
</html>
