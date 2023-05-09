<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="dppm.aspx.vb" Inherits="AG_SCAN.dppm" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Form Scan</title>
    <meta http-equiv="Content-Language" content="en" />
    <style type="text/css">
        .auto-style1 {
            width: 1600px;
            height: 322px;
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
            text-align: right;
            height: 22px;
        }
        .auto-style8 {
            text-align: center;
            height: 17px;
        }
        .txtIsian 
        {
            width   :   350px;
        }
        .txtTanggal 
        {
            width   :   50px;
        }
        .txtTahun 
        {
            width   :   150px;
        }
        .icon_logout {
            width   :   80px;
        }
        .auto-style12 {
            height: 60px;
        }
        .auto-style13 {
            height: 356px;
        }
        .auto-style18 {
            text-align: left;
            width: 159px;
            height: 33px;
            font-weight: bold;
        }
        .auto-style19 {
            text-align: center;
            height: 44px;
        }
        .auto-style27 {
            text-align: left;
            width: 159px;
            height: 30px;
        }
        .auto-style28 {
            text-align: left;
            height: 30px;
        }
        .auto-style29 {
            text-align: left;
            width: 159px;
            height: 31px;
            font-weight: bold;
        }
        .auto-style30 {
            text-align: left;
            height: 31px;
        }
        .auto-style31 {
            text-align: left;
            width: 159px;
            height: 35px;
        }
        .auto-style32 {
            text-align: left;
            height: 35px;
        }
        .auto-style33 {
            text-align: left;
            height: 33px;
        }
        .auto-style34 {
            text-align: left;
            width: 159px;
            height: 32px;
        }
        .auto-style35 {
            text-align: left;
            height: 32px;
        }
        .auto-style36 {
            text-align: left;
            width: 159px;
            height: 33px;
        }
        .auto-style37 {
            text-align: left;
            width: 159px;
            height: 17px;
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
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/judul_dppm.png" Width="50%" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style31">
                                <asp:Label ID="Label5" runat="server" Text="Tahun" Font-Bold="True"></asp:Label>
                            </td>
                            <td class="auto-style32">
                                <asp:DropDownList ID="ddlTahun" runat="server" CssClass="txtTahun">
                                    <asp:ListItem>Pilih Tahun</asp:ListItem>
                                    <asp:ListItem>Dibawah 2018</asp:ListItem>
                                    <asp:ListItem>2018</asp:ListItem>
                                    <asp:ListItem>2019</asp:ListItem>
                                    <asp:ListItem>2020</asp:ListItem>
                                    <asp:ListItem>2021</asp:ListItem>
                                    <asp:ListItem>2022</asp:ListItem>
                                    <asp:ListItem>2023</asp:ListItem>
                                    <asp:ListItem>2024</asp:ListItem>
                                    <asp:ListItem>2025</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="lblerr1" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            </td>
                            <td class="auto-style32">
                                </td>
                        </tr>
                        <tr>
                            <td class="auto-style18">
                                Bulan</td>
                            <td class="auto-style33">
                                <asp:DropDownList ID="ddlBulan" runat="server" CssClass="ddlBulan">
                                    <asp:ListItem>Pilih Bulan</asp:ListItem>
                                    <asp:ListItem Value="01-Januari">Januari</asp:ListItem>
                                    <asp:ListItem Value="02-Februari">Februari</asp:ListItem>
                                    <asp:ListItem Value="03-Maret">Maret</asp:ListItem>
                                    <asp:ListItem Value="04-April">April</asp:ListItem>
                                    <asp:ListItem Value="05-Mei">Mei</asp:ListItem>
                                    <asp:ListItem Value="06-Juni">Juni</asp:ListItem>
                                    <asp:ListItem Value="07-Juli">Juli</asp:ListItem>
                                    <asp:ListItem Value="08-Agustus">Agustus</asp:ListItem>
                                    <asp:ListItem Value="09-september">September</asp:ListItem>
                                    <asp:ListItem Value="10-Oktober">Oktober</asp:ListItem>
                                    <asp:ListItem Value="11-November">November</asp:ListItem>
                                    <asp:ListItem Value="12-Desember">Desember</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="lblerr2" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            </td>
                            <td class="auto-style33">
                                </td>
                        </tr>
                        <tr>
                            <td class="auto-style29">
                                Tanggal</td>
                            <td class="auto-style30">
                                <asp:TextBox ID="txtTgl" runat="server" CssClass="txtTanggal" MaxLength="2" TextMode="Number" Width="50px"></asp:TextBox>
                                <asp:Label ID="lblerr6" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            </td>
                            <td class="auto-style30">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style34">
                                <asp:Label ID="Label6" runat="server" Text="Nomor DPPM" Font-Bold="True"></asp:Label>
                            </td>
                            <td class="auto-style35">
                                <asp:TextBox ID="txtDPPM" runat="server" CssClass="txtIsian" MaxLength="200"></asp:TextBox>
                            </td>
                            <td class="auto-style35">
                                <asp:Label ID="lblerr3" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style36">
                                <asp:Label ID="Label1" runat="server" Text="Nama Pelanggan" Font-Bold="True"></asp:Label>
                            </td>
                            <td class="auto-style33">
                                <asp:TextBox ID="txtPelanggan" runat="server" CssClass="txtIsian" MaxLength="200"></asp:TextBox>
                            </td>
                            <td class="auto-style33">
                                <asp:Label ID="lblerr4" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style27">
                                <asp:Label ID="Label2" runat="server" Text="Nomor EQ" Font-Bold="True"></asp:Label>
                            </td>
                            <td class="auto-style28">
                                <asp:TextBox ID="txtEQ" runat="server" CssClass="txtIsian" MaxLength="200"></asp:TextBox>
                            </td>
                            <td class="auto-style28">
                                <asp:Label ID="lblerr5" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style37">
                            </td>
                            <td class="auto-style8">
                            </td>
                            <td class="auto-style8">
                                </td>
                        </tr>
                        <tr>
                            <td class="auto-style5">
                                <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/images/BACK.png" />
                            </td>
                            <td class="auto-style6">
                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/scan_next.png" />
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

