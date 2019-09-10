<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IoTApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>
            IoT Web Homepage</h1>
        <p class="lead">The world around you is powered by the Internet of Things and we’re enabling it. Smart homes, offices, and warehouses around the world are integrating IoT technology wherever they can, and we&#39;re helping developers get the job done.</p>
        <p><a href="https://www.cypress.com/solutions/internet-things-iot" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label_SW_ver" runat="server"></asp:Label>
        </p>
    </div>

    <div>
            <div class="text-center" style="border: thick solid #CCCCCC; position: relative; width: auto; height: 300px; top: -2147483648%; left: 0px; visibility: visible; display: block;">
                    <span style="font-size: xx-large">My Work</span><br />
                    <span style="font-size: x-large">Hello,
                    <em><strong>
                    <asp:LoginName ID="LoginName1" runat="server" />
                    </strong></em></span><span style="font-size: large">!<br />
                    <br />
                    </span><span style="font-size: x-large">Please click Create button to add a new item in the database.&nbsp;<br />
                    </span>&nbsp;<asp:Button ID="Button1" runat="server" BackColor="#C2CDD6" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" Font-Bold="True" Font-Size="X-Large" ForeColor="White" Text="Create   &gt;&gt;" OnClick="Button1_Click" />
                    <br />
                    <br />
                    <span style="font-size: x-large">Please click Review button to review the items in the database via your account.<br />
                    </span><asp:Button ID="Button2" runat="server" BackColor="#C2CDD6" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" Font-Bold="True" Font-Size="X-Large" ForeColor="White" Text="Modify  &gt;&gt;" OnClick="Button2_Click" />
                </div>
                <div style="border: thick solid #CCCCCC; position: relative; width: auto; height: 300px; top: -2147483648%; left: 0px; visibility: visible; display: block; font-size: xx-large;" class="text-center">
                    Review &amp; Approval<br />
                    <br />
                    <span style="font-size: x-large">Please click Review button to review the items in the database<br />
                    <asp:Button ID="Button3" runat="server" BackColor="#C2CDD6" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" Font-Bold="True" Font-Size="X-Large" ForeColor="White" Text="Review  &gt;&gt;" OnClick="Button3_Click" />
                    </span>
        </div>
    </div>

</asp:Content>
