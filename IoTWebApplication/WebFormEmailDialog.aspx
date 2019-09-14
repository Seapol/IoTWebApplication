<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormEmailDialog.aspx.cs" Inherits="IoTWebApplication.WebFormEmailDialog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            font-size: xx-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="border: thick solid #C0C0C0; position: relative; width: auto; height: 3%; background-color: #808000; font-variant: normal; " class="auto-style1">
            Email
        </div>
        <div>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="UnID" HeaderText="UnID" SortExpression="UnID" />
                    <asp:BoundField DataField="Initiator" HeaderText="Initiator" SortExpression="Initiator" />
                    <asp:CheckBoxField DataField="IsSigner" HeaderText="IsSigner" SortExpression="IsSigner" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:IoTConnectionString18 %>" SelectCommand="SELECT * FROM [Contact]"></asp:SqlDataSource>
            <br />
        </div>
    </form>
    <div>
    </div>
    <div>
    </div>
</body>
</html>
