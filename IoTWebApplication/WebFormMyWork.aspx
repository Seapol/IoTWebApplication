<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormMyWork.aspx.cs" Inherits="IoTWebApplication.WebFormMyWork" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: auto;
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
        .auto-style10 {
            color: #3333FF;
        }
        .auto-style11 {
            text-align: center;
        }
        .auto-style13 {
            color: #0000FF;
        }
        .auto-style14 {
            text-align: left;
        }
        .auto-style15 {
            text-align: center;
            font-family: Arial;
            font-weight: 600;
            font-size: xx-large;
            color: #FFFFFF;
            text-transform: uppercase;
        }
        .auto-style16 {
            font-style: normal;
        }
        </style>
</head>
<body style="height: auto">
    <form id="form1" runat="server" class="auto-style1" enctype="multipart/form-data">
        <div style="border: thick solid #C0C0C0; position: relative; width: auto; height: 3%; background-color: #0000FF; font-variant: normal; " class="auto-style15">
            My working space</div>
        <div style="border: thin solid #C0C0C0; position: relative; width: auto; top: auto; left: auto; height: auto;" class="auto-style3">
            <asp:Label ID="Label_User" runat="server"></asp:Label>
            : <em><strong>
            <asp:Label ID="Label_Initiator" runat="server" CssClass="auto-style13"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong></em>UTC Date&amp;Time: <em><strong>
            <asp:Label ID="Label_DateTime" runat="server" CssClass="auto-style10"></asp:Label>
            </strong></em>
            <br />
            <br />
            ID#: <em><strong>
            <asp:Label ID="Label_ID" runat="server" CssClass="auto-style13"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </strong>&nbsp;&nbsp;&nbsp; <span class="auto-style16">Project Status: </span><strong>
            <asp:Label ID="Label_ProjectStatus" runat="server" CssClass="auto-style13"></asp:Label>
            </strong></em>
            <br />
            <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:IoTConnectionString8 %>" SelectCommand="SELECT top(1) *  FROM [Items1] ORDER BY [DateTimeUTC] DESC"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:IoTConnectionString9 %>" SelectCommand="SELECT * FROM [Items1] ORDER BY [DateTimeUTC] DESC"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSourceAll" runat="server" ConnectionString="<%$ ConnectionStrings:IoTConnectionString17 %>" SelectCommand="SELECT * FROM [Items1] ORDER BY [DateTimeUTC] DESC"></asp:SqlDataSource>
            <br />
        </div>
        <div style="border: thin solid #C0C0C0; position: relative; width: auto; top: auto; left: auto; height: auto;" class="auto-style3">
            <div class="auto-style11">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="auto-style3" DataSourceID="SqlDataSource1" HorizontalAlign="Center" Width="100%" Visible="False">
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
            <div class="auto-style11">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" Width="100%" Visible="False">
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
            [Design Name]:
            <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style4" Width="95%" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            <br />
            <br />
            [Main Part Vendor Name*]:
            <asp:TextBox ID="TextBox4" runat="server" CssClass="auto-style4" Width="95%" OnTextChanged="TextBox4_TextChanged"></asp:TextBox>
            <br />
            <br />
            [Main Part Vendor PN*]:
            <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style4" Width="95%" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
            <br />
            <br />
        </div>
        <div style="border: thin solid #C0C0C0; position: relative; width: auto; top: auto; left: auto; height: auto;" class="auto-style3">
            <div title="Alternative Source Information">
                <div class="auto-style11">
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" Width="100%" Visible="False">
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
            [Main Part Description*]:<br />
            <asp:TextBox ID="TextBox3" runat="server" CssClass="auto-style4" Height="200px" TextMode="MultiLine" Width="90%" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
            :<br />
                <div class="auto-style14">
                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource4" Width="100%" Visible="False">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                            <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" SortExpression="ProjectName" />
                            <asp:BoundField DataField="ProjectMainPartFootPrintName" HeaderText="ProjectMainPartFootPrintName" SortExpression="ProjectMainPartFootPrintName" />
                            <asp:BoundField DataField="ProjectMainPartLogicalSymbolName" HeaderText="ProjectMainPartLogicalSymbolName" SortExpression="ProjectMainPartLogicalSymbolName" />
                        </Columns>
                    </asp:GridView>
                    <br />
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Checked if Part is Critical" CssClass="auto-style3" OnCheckedChanged="CheckBox1_CheckedChanged" />
                    <br />
            <asp:CheckBox ID="CheckBox2" runat="server" Text="Checked if Footprint and LogicalSymbol requires double confirmation by requestor" CssClass="auto-style3" OnCheckedChanged="CheckBox2_CheckedChanged" />
                    <br />
                </div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;<br />
                <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource6" Width="100%" Visible="False">
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
                [Alternative Part Vendor Name]:
                <span class="auto-style8">
            <asp:TextBox ID="TextBox8" runat="server" CssClass="auto-style4" Width="90%" OnTextChanged="TextBox8_TextChanged"></asp:TextBox>
            <br />
                </span>[Alternative Part Vendor PN]:<span class="auto-style8">
            <asp:TextBox ID="TextBox9" runat="server" CssClass="auto-style4" Width="90%" OnTextChanged="TextBox9_TextChanged"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="Button8" runat="server" CssClass="auto-style3" OnClick="Button8_Click" Text="Add" Width="160px" />
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button9" runat="server" CssClass="auto-style3" OnClick="Button9_Click" Text="Clean all" Width="160px" />
                <br />
                </span><br />
            </div>
            <asp:TextBox ID="TextBoxAlternativeSourceInfo" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" Height="150px" Width="90%" TextMode="MultiLine" OnTextChanged="TextBoxAlternativeSourceInfo_TextChanged" CssClass="auto-style4"></asp:TextBox>
            <br />
            <br />
                <asp:Label ID="LabelDataSheet" runat="server" Text="DataSheet"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="auto-style4" Width="50%" />
                &nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButtonDataSheet" runat="server" OnClick="LinkButtonDataSheetUrl_Click" Visible="False">Review</asp:LinkButton>
            <br />
                <asp:Label ID="LabelFootPrint" runat="server" Text="Reference FootPrint"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload2" runat="server" CssClass="auto-style4" Width="50%" />
&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButtonRefFootPrint" runat="server" OnClick="LinkButtonRefFootPrint_Click" Visible="False">Review</asp:LinkButton>
&nbsp;&nbsp;&nbsp;
                <br />
                <asp:Label ID="LabelLogicalSymbol" runat="server" Text="Reference LogicalSymbol"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload3" runat="server" CssClass="auto-style4" Width="50%" />
&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButtonRefLogicalSymbol" runat="server" OnClick="LinkButtonRefLogicalSymbol_Click" Visible="False">Review</asp:LinkButton>
&nbsp;&nbsp;&nbsp;<br />
            <asp:Label ID="LabelMisc" runat="server" Text="Misc"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload4" runat="server" CssClass="auto-style4" Width="50%" Visible="False" />
&nbsp;&nbsp;&nbsp;
<asp:LinkButton ID="LinkButtonMisc" runat="server" OnClick="LinkButtonMisc_Click" Visible="False">Review</asp:LinkButton>
            <br />
                <asp:Label ID="LabelFootPrintFinal" runat="server" Text="Final FootPrint" Visible="False"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload5" runat="server" CssClass="auto-style4" Width="50%" Visible="False" />
&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButtonFinalFootPrint" runat="server" OnClick="LinkButtonFinalFootPrint_Click" Visible="False">Review</asp:LinkButton>
            <br />
                <asp:Label ID="LabelLogicalSymbolFinal" runat="server" Text="Final LogicalSymbol" Visible="False"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload6" runat="server" CssClass="auto-style4" Width="50%" Visible="False" />
&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButtonFinalLogicalSymbol" runat="server" OnClick="LinkButtonFinalLogicalSymbol_Click" Visible="False">Review</asp:LinkButton>
&nbsp;&nbsp;<div class="auto-style14">
                    <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource5" Width="100%" Visible="False">
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
                    <asp:Button ID="Button7" runat="server" CssClass="auto-style4" Height="30px" Text="Files Upload" Width="160px" OnClick="Button7_Click" />
                    <br />
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:IoTConnectionString4attached %>" SelectCommand="SELECT TOP (1) [ID]
      ,[ProjectName]


      ,[ProjectMainPartFootPrintName]

      ,[ProjectMainPartLogicalSymbolName]



  FROM [IoT].[dbo].[Items1]
  order by [DateTimeUTC] DESC"></asp:SqlDataSource>
                    <asp:Label ID="LabelSpecialRequirements" runat="server" Text="[Special Requirements]"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBoxSpecialRequirements" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" CssClass="auto-style3" Height="200px" TextMode="MultiLine" Width="90%" OnTextChanged="TextBoxSpecialRequirements_TextChanged"></asp:TextBox>
                    <br />
                </div>
                    <div class="auto-style14">
                        <br />
                        <asp:Label ID="LabelCYPN" runat="server" Text="[CY PN*]:" Visible="False"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBoxCYPN" runat="server" CssClass="auto-style3" Width="50%" OnTextChanged="TextBoxCYPN_TextChanged" ReadOnly="True" Visible="False" BorderColor="Black" BorderStyle="Solid"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelFootPrintName" runat="server" Text="[Main Part FootPrint Name*]:" Visible="False"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox6" runat="server" CssClass="auto-style3" Width="50%" OnTextChanged="TextBox6_TextChanged" ReadOnly="True" Visible="False" BorderColor="Black" BorderStyle="Solid"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelLogicalSymbolName" runat="server" Text="[Main Part LogicalSymbol Name*]:" Visible="False"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox7" runat="server" CssClass="auto-style3" Width="50%" OnTextChanged="TextBox7_TextChanged" ReadOnly="True" Visible="False" BorderColor="Black" BorderStyle="Solid"></asp:TextBox>
                        <br />
                        <br />
                        <div class="auto-style11">
            <asp:Label ID="LabelSummary" runat="server" CssClass="auto-style8" Text="Summary"></asp:Label>
                            <br />
            <asp:TextBox ID="TextBox5" runat="server" Height="400px" Width="90%" BorderStyle="Solid" BorderWidth="2px" TextMode="MultiLine" BorderColor="Black" CssClass="auto-style4" Font-Size="Large" OnTextChanged="TextBox5_TextChanged" ReadOnly="True"></asp:TextBox>
                            <br />
            <asp:Label ID="LabelComments" runat="server" CssClass="auto-style8" Text="Comments"></asp:Label>
                            <br />
            <asp:TextBox ID="TextBox10" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" Height="250px" OnTextChanged="TextBox10_TextChanged" ReadOnly="True" TextMode="MultiLine" Width="90%"></asp:TextBox>
                            <br />
            <asp:Label ID="LabelRemarks" runat="server" CssClass="auto-style8" Text="Remarks"></asp:Label>
                            <br />
            <asp:TextBox ID="TextBox11" runat="server" Height="200px" OnTextChanged="TextBox11_TextChanged" ReadOnly="True" Width="90%" TextMode="MultiLine" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px"></asp:TextBox>
                            <br />
                            <br />
                            <br />
            <asp:Button ID="Button2" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" CssClass="auto-style3" Height="40px" Text="Save" Width="160px" OnClick="Button2_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" CssClass="auto-style3" Height="40px" Text="Submit" Width="160px" OnClick="Button3_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button5" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" CssClass="auto-style3" Height="40px" Text="Cancel" Width="160px" OnClick="Button5_Click" />
                        </div>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </div>
            <br />
            <br />
        </div>
        <br />
    </form>
</body>
</html>
