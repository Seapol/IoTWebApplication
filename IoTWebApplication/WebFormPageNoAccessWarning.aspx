<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormPageNoAccessWarning.aspx.cs" Inherits="IoTWebApplication.WebFormPageNoAccessWarning" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            font-size: xx-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1" style="background-color: #FF6600">
            <span class="auto-style2">Hello, </span>
            <asp:LoginName ID="LoginName1" runat="server" CssClass="auto-style2" />
            <br class="auto-style2" />
            <br class="auto-style2" />
            <span class="auto-style2">You&#39;re not allow to enter this page. <br />
            Please contract with the website administrator for support!\<br />
            <br />
            <br />
            </span>
        </div>
    </form>
</body>
</html>
