<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ErrorPage.aspx.vb" Inherits="AG_SCAN.ErrorPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>ERROR PAGE</title>
    <meta http-equiv="Content-Language" content="en" />
    <style type="text/css">
        .auto-style2 {
            height: 185px;
        }
        .auto-style3 {
            height: 9px;
        }
        .auto-style4 {
            height: 90px;
        }
        .auto-style5 {
            height: 400px;
        }
        .auto-style6 {
            height: 11px;
        }
        .auto-style7 {
            height: 48px;
        }
    </style>
</head>
<body bgColor="#d0e0e0">
    <form id="form1" runat="server">
    <table align="center" width="800" bgcolor="#d0e0e0" >
	        <tr>
	            <td vAlign="middle" align="left"><IMG src="images/header.jpg"></td>
	        </tr>
    </table>
    <table align="center" width="800" bgcolor="#d0e0e0" 
        style="background-image: url('images/bg.jpg')" class="auto-style5">
            <tr>
                <td width="800" align="center" valign="middle" class="auto-style3">
                </td>
            </tr>
            <tr>
                <td width="800" align="center" valign="middle" bgcolor="#FFA448" class="auto-style7">
                    <font size="5"><asp:Label ID="ErrorTitleLabel" runat="server" Text="An error occurred." Visible="False"></asp:Label> &nbsp;<asp:Image ID="Image1" runat="server" ImageUrl="~/images/icon_warning.png" />
                    </font>                                       
                </td>
            </tr>
            <tr>
                <td width="800" height="40" align="center" valign="middle">
                    <hr />
                </td>
            </tr>
            <tr>
                <td width="800" align="center" valign="middle" class="auto-style2">
                    <font size="3">
                    <asp:Label ID="message" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#CC0000"></asp:Label>
                    <br />
                    </font>
                </td>
            </tr>
            <tr>
                <td width="800" align="left" valign="middle" class="auto-style6">
                    <hr />
                </td>
            </tr>
            <tr>
                <td width="800" align="center" valign="top" class="auto-style4">
                                <asp:ImageButton ID="btnOK" runat="server" ImageUrl="~/images/OK.png" />
                </td>
            </tr>
    </table>
    </form>
</body>
</html>

