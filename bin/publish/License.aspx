<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="License.aspx.vb" Inherits="AG_SCAN.License" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Form Scan</title>
    <meta http-equiv="Content-Language" content="en" />
    <style type="text/css">
        .auto-style1 {
            width: 1600px;
            height: 349px;
        }
        .auto-style2 {
            width: 571px;
            height: 235px;
        }
        .lbl_prn
        {
            width: 300px;
            font-family: calibri;
            font-size: 35px;
        }
        .lbl_ket
        {
            width: 300px;
            font-family: calibri;
            font-size: 15px;
        }
        .auto-style5 {
            text-align: left;
            width: 159px;
            height: 22px;
        }
        .auto-style6 {
            text-align: center;
            height: 22px;
        }
        .auto-style7 {
            text-align: left;
            width: 159px;
            height: 26px;
        }
        .auto-style8 {
            text-align: center;
            height: 26px;
        }
        .txtIsian 
        {
            width   :   350px;
        }
        .txtTahun 
        {
            width   :   150px;
        }
        .icon_logout {
            width   :   80px;
        }
        .auto-style12 {
            height: 50px;
        }
        .auto-style13 {
            height: 356px;
        }
        .auto-style14 {
            text-align: left;
            width: 159px;
            height: 37px;
            font-weight: bold;
        }
        .auto-style19 {
            text-align: center;
            height: 25px;
        }
        .auto-style20 {
            text-align: left;
            height: 37px;
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
        style="background-image: url('images/bg.jpg')" class="auto-style13">
            <tr>
                <td align="center" valign="middle" class="auto-style1">
                    <table class="auto-style2">
                        <tr>
                            <td class="auto-style19" colspan="3">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/judul_kontrak.png" Width="60%" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style7">
                            </td>
                            <td class="auto-style8">
                                &nbsp;</td>
                            <td class="auto-style8">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style14">
                                License Key</td>
                            <td class="auto-style20">
                                <asp:TextBox ID="txtLicense" runat="server" CssClass="txtIsian" MaxLength="200"></asp:TextBox>
                                <asp:Label ID="lblerr1" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            </td>
                            <td class="auto-style20">
                                </td>
                        </tr>
                        <tr>
                            <td class="auto-style14">
                                License Key</td>
                            <td class="auto-style20">
                                <asp:TextBox ID="txt" runat="server" CssClass="txtIsian" MaxLength="200"></asp:TextBox>
                                <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            </td>
                            <td class="auto-style20">
                                </td>
                        </tr>
                        <tr>
                            <td class="auto-style7">
                            </td>
                            <td class="auto-style8">
                                &nbsp;</td>
                            <td class="auto-style8">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style7">
                            </td>
                            <td class="auto-style8">
                                &nbsp;</td>
                            <td class="auto-style8">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style5">
                                &nbsp;</td>
                            <td class="auto-style6">
                                <asp:ImageButton ID="imgButtonCheck" runat="server" ImageUrl="~/images/scan_next.png" />
                            </td>
                            <td class="auto-style6">
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td width="800" class="auto-style12">
                </td>
            </tr>
    </table>
    </form>
</body>
</html>