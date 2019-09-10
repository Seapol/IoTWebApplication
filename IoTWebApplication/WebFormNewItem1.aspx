<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormNewItem1.aspx.cs" Inherits="IoTApplication.WebFormNewItem1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 2011px;
        }
        .auto-style3 {
            font-size: x-large;
        }
        .auto-style4 {
            font-size: large;
        }
        .auto-style8 {
            font-size: xx-large;
        }
        .auto-style9 {
            font-size: x-large;
            text-align: center;
        }
        .auto-style10 {
            color: #3333FF;
        }
        .auto-style11 {
            text-align: center;
        }
        .auto-style12 {
            text-align: justify;
        }
        .auto-style13 {
            color: #0000FF;
        }
    </style>
</head>
<body style="height: 2029px">
    <form id="form1" runat="server" class="auto-style1" enctype="multipart/form-data">
        <div style="border: thick solid #C0C0C0; position: relative; width: auto; height: 3%; background-color: #0000FF; font-family: Arial; font-size: xx-large; font-weight: 600; font-style: normal; font-variant: normal; text-transform: uppercase; color: #FFFFFF;" class="auto-style11">
            CREATe new item</div>
        <div style="border: thin solid #C0C0C0; position: relative; width: auto; top: auto; left: auto; height: auto;" class="auto-style3">
            Initiator
            <asp:LoginName ID="LoginName2" runat="server" />
            <br />
            <br />
            UTC Date&amp;Time: <em><strong>
            <asp:Label ID="Label_DateTime" runat="server" CssClass="auto-style10"></asp:Label>
            </strong></em>
            <br />
            <br />
            Attempt ID#: <em><strong>
            <asp:Label ID="Label_ID" runat="server" CssClass="auto-style13"></asp:Label>
            </strong></em>
            <br />
            <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:IoTConnectionString4 %>" SelectCommand="SELECT TOP (1) [ID]
      ,[UnID]
      ,[DateTimeUTC]

  FROM [IoT].[dbo].[Items1]
  order by [DateTimeUTC] DESC"></asp:SqlDataSource>
            <br />
        </div>
        <div style="border: thin solid #C0C0C0; position: relative; width: auto; top: auto; left: auto; height: auto;" class="auto-style3">
            Project Info:<br />
            <br />
            <div class="auto-style11">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="auto-style3" DataSourceID="SqlDataSource1" HorizontalAlign="Center" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                        <asp:BoundField DataField="UnID" HeaderText="UnID" SortExpression="UnID" />
                        <asp:BoundField DataField="DateTimeUTC" HeaderText="DateTimeUTC" SortExpression="DateTimeUTC" />
                        <asp:BoundField DataField="Initiator" HeaderText="Initiator" SortExpression="Initiator" />
                        <asp:BoundField DataField="ProjectCritical" HeaderText="ProjectCritical" SortExpression="ProjectCritical" />
                        <asp:BoundField DataField="ProjectStatus" HeaderText="ProjectStatus" SortExpression="ProjectStatus" />
                    </Columns>
                </asp:GridView>
            </div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:IoTConnectionString4ProjectInfoInput %>" SelectCommand="SELECT TOP (1) [ID]
      ,[UnID]
      ,[DateTimeUTC]
      ,[Initiator]
      ,[ProjectCritical]
      ,[ProjectStatus]

  FROM [IoT].[dbo].[Items1]
  order by [DateTimeUTC] DESC"></asp:SqlDataSource>
            <br />
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Critical" />
            <br />
            <br />
            <div class="auto-style11">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                        <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" SortExpression="ProjectName" />
                        <asp:BoundField DataField="ProjectMainPartVendorName" HeaderText="ProjectMainPartVendorName" SortExpression="ProjectMainPartVendorName" />
                        <asp:BoundField DataField="ProjectMainPartVendorPN" HeaderText="ProjectMainPartVendorPN" SortExpression="ProjectMainPartVendorPN" />
                    </Columns>
                </asp:GridView>
            </div>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:IoTConnectionString4ProjectInfo1 %>" SelectCommand="SELECT TOP (1) [ID]
      ,[ProjectName]
      ,[ProjectMainPartVendorName]
      ,[ProjectMainPartVendorPN]

  FROM [IoT].[dbo].[Items1]
  order by [DateTimeUTC] DESC"></asp:SqlDataSource>
            <br />
            <br />
            [Name *]:
            <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style4" Width="95%"></asp:TextBox>
            <br />
            <br />
            [Main Part Vendor Name*]:
            <asp:TextBox ID="TextBox4" runat="server" CssClass="auto-style4" Width="95%"></asp:TextBox>
            <br />
            <br />
            [Main Part Vendor PN*]:
            <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style4" Width="95%"></asp:TextBox>
            <br />
            <br />
            <div class="auto-style11">
                <asp:Button ID="Button9" runat="server" CssClass="auto-style4" Height="30px" Text="Update" Width="160px" />
            </div>
            <br />
            <br />
        </div>
        <div style="border: thin solid #C0C0C0; position: relative; width: auto; top: auto; left: auto; height: auto;" class="auto-style3">
            <div>
                <div class="auto-style11">
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                            <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" SortExpression="ProjectName" />
                            <asp:BoundField DataField="ProjectMainPartDescription" HeaderText="ProjectMainPartDescription" SortExpression="ProjectMainPartDescription" />
                        </Columns>
                    </asp:GridView>
                </div>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:IoTConnectionString4ProjectInfoDesc %>" SelectCommand="SELECT TOP (1) [ID]
      ,[ProjectName]
      ,[ProjectMainPartDescription]

  FROM [IoT].[dbo].[Items1]
  order by [DateTimeUTC] DESC"></asp:SqlDataSource>
                <br />
            [Main Part Description]:<br />
            <asp:TextBox ID="TextBox3" runat="server" CssClass="auto-style4" Height="300px" TextMode="MultiLine" Width="90%" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px"></asp:TextBox>
            :<br />
                <br />
                <div class="auto-style11">
                    <asp:Button ID="Button8" runat="server" CssClass="auto-style4" Height="30px" Text="Update" Width="160px" />
                </div>
                <br />
                <br />
                DataSheet<br />
            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="auto-style4" Width="90%" />
                &nbsp;&nbsp;<br />
                FootPrint<br />
            <asp:FileUpload ID="FileUpload2" runat="server" CssClass="auto-style4" Width="90%" />
&nbsp;&nbsp;
                <br />
                LogicalSymbol<br />
            <asp:FileUpload ID="FileUpload3" runat="server" CssClass="auto-style4" Width="90%" />
&nbsp;<br />
                <br />
            &nbsp;<div class="auto-style11">
                    <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource5" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                            <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" SortExpression="ProjectName" />
                            <asp:BoundField DataField="MainPartStoredFileDataSheet" HeaderText="MainPartStoredFileDataSheet" ReadOnly="True" SortExpression="MainPartStoredFileDataSheet" />
                            <asp:BoundField DataField="MainPartStoredFileFootPrint" HeaderText="MainPartStoredFileFootPrint" ReadOnly="True" SortExpression="MainPartStoredFileFootPrint" />
                            <asp:BoundField DataField="MainPartStoredFileLogicalSymbol" HeaderText="MainPartStoredFileLogicalSymbol" ReadOnly="True" SortExpression="MainPartStoredFileLogicalSymbol" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:IoTConnectionString2 %>" SelectCommand="SELECT TOP (1) [ID]
      ,[ProjectName]
      ,CONVERT(nvarchar(MAX), [ProjectMainPartStoredFileDataSheet]) AS MainPartStoredFileDataSheet
	  ,CONVERT(nvarchar(MAX), [ProjectMainPartStoredFileFootPrint]) AS MainPartStoredFileFootPrint
	  ,CONVERT(nvarchar(MAX), [ProjectMainPartStoredFileLogicalSymbol]) AS MainPartStoredFileLogicalSymbol

  FROM [IoT].[dbo].[Items1]"></asp:SqlDataSource>
                    <br />
                    <asp:Button ID="Button7" runat="server" CssClass="auto-style4" Height="30px" Text="Files Upload" Width="160px" />
                    <br />
                    <br />
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:IoTConnectionString4attached %>" SelectCommand="SELECT TOP (1) [ID]
      ,[ProjectName]


      ,[ProjectMainPartFootPrintName]

      ,[ProjectMainPartLogicalSymbolName]



  FROM [IoT].[dbo].[Items1]
  order by [DateTimeUTC] DESC"></asp:SqlDataSource>
                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource4" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                            <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" SortExpression="ProjectName" />
                            <asp:BoundField DataField="ProjectMainPartFootPrintName" HeaderText="ProjectMainPartFootPrintName" SortExpression="ProjectMainPartFootPrintName" />
                            <asp:BoundField DataField="ProjectMainPartLogicalSymbolName" HeaderText="ProjectMainPartLogicalSymbolName" SortExpression="ProjectMainPartLogicalSymbolName" />
                        </Columns>
                    </asp:GridView>
                    <br />
                    <div class="auto-style12">
            [Main Part FootPrint Name]:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TextBox6" runat="server" CssClass="auto-style3" Width="50%"></asp:TextBox>
                        <br />
                        <br />
            [Main Part LogicalSymbol Name]:&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TextBox7" runat="server" CssClass="auto-style3" Width="50%"></asp:TextBox>
                    </div>
                </div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;<br />
                <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource6" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                        <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" SortExpression="ProjectName" />
                        <asp:BoundField DataField="ProjectAlternativeSourceInfo" HeaderText="ProjectAlternativeSourceInfo" SortExpression="ProjectAlternativeSourceInfo" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:IoTConnectionString3 %>" SelectCommand="SELECT TOP (1) [ID]
      ,[ProjectName]
      ,[ProjectAlternativeSourceInfo]
  FROM [IoT].[dbo].[Items1]
  order by [DateTimeUTC] DESC"></asp:SqlDataSource>
                <br />
                <span class="auto-style8">Alternative Source Information</span><br />
            <br />
            </div>
            <asp:TextBox ID="TextBoxAlternativeSourceInfo" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" Height="300px" Width="100%"></asp:TextBox>
            <br />
            <br />
            <div class="auto-style11">
                <asp:Button ID="Button10" runat="server" CssClass="auto-style4" Height="30px" Text="Update" Width="160px" />
            </div>
            <br />
            <br />
        </div>
        <div style="border: thin solid #C0C0C0; position: relative; width: auto; top: auto; left: auto; height: auto;" class="auto-style9">
            <span class="auto-style8">Summary</span><br />
            <asp:TextBox ID="TextBox5" runat="server" Height="300px" Width="90%" BorderStyle="Solid" BorderWidth="2px" OnTextChanged="TextBox5_TextChanged" TextMode="MultiLine" BorderColor="Black" CssClass="auto-style4" Font-Size="Large"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" CssClass="auto-style3" Height="40px" Text="Review" Width="160px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" CssClass="auto-style3" Height="40px" Text="Submit" Width="160px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button5" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" CssClass="auto-style3" Height="40px" Text="Cancel&amp;Exit" Width="160px" />
            <br />
            <br />
            <br />
        </div>
        <br />
    </form>
</body>
</html>
