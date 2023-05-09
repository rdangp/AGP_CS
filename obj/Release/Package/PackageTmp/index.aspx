<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="index.aspx.vb" Inherits="AG_SCAN.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Custom Scan</title>
    <meta http-equiv="Content-Language" content="en" />
    <style type="text/css">
        .auto-style5 {
            width: 250px;
        }
        .auto-style6 {
            width: 563px;
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
        style="background-image: url('images/bg.jpg')">
            <tr>
                <td height="357" align="center" valign="middle">
                    <table align="center" class="auto-style6">
                        <tr>
                            <td>
                                <asp:ImageButton ID="btnKotrak" runat="server" ImageUrl="~/images/icon_kontrak.png"/>
                            </td>
                            <td class="auto-style5">
                                <asp:ImageButton ID="btnDPPM" runat="server" ImageUrl="~/images/icon_dppm.png"/>
                            </td>
                            <td class="auto-style5">
                                <asp:ImageButton ID="btnSekre" runat="server" ImageUrl="~/images/icon_sekretaris.png"/>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Label ID="lbltest" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="800" height="40">
                </td>
            </tr>
    </table>
    </form>
</body>
</html>