<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormModifyMyWork.aspx.cs" Inherits="IoTWebApplication.WebFormModifyMyWork" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            font-size: x-large;
            text-align: center;
        }
        .auto-style3 {
            font-size: xx-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="border: thick solid #C0C0C0; position: relative; width: auto; height: 3%; background-color: #66CCFF; font-variant: normal; font-family: Arial; font-size: xx-large; text-transform: uppercase;" class="auto-style1">
            My working projects</div>
        <div class="auto-style2">
            My Working Projects Overview<br />
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" HorizontalAlign="Center" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" Width="90%">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="UnID" HeaderText="UnID" SortExpression="UnID" />
                    <asp:BoundField DataField="DateTimeUTC" HeaderText="DateTimeUTC" SortExpression="DateTimeUTC" />
                    <asp:BoundField DataField="Initiator" HeaderText="Initiator" SortExpression="Initiator" />
                    <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" SortExpression="ProjectName" />
                    <asp:BoundField DataField="ProjectStatus" HeaderText="ProjectStatus" SortExpression="ProjectStatus" >
                    <ItemStyle Font-Bold="True" ForeColor="#009900" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ProjectCritical" HeaderText="ProjectCritical" SortExpression="ProjectCritical" />
                    <asp:CommandField ButtonType="Button" HeaderText="Details" SelectText="Modify" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:IoTConnectionString6 %>" SelectCommand="SELECT [ID], [UnID], [DateTimeUTC], [Initiator], [ProjectStatus], [ProjectName], [ProjectCritical] FROM [Items1] ORDER BY [DateTimeUTC] DESC"></asp:SqlDataSource>
        </div>
         <div class="auto-style1">
             <br />
             <br />
             <asp:Button ID="Button1" runat="server" CssClass="auto-style3" OnClick="Button1_Click" Text="Exit" Width="200px" />
        </div>
    </form>
</body>
</html>
