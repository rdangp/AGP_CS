Imports System.Web.Configuration

Public Class index
    Inherits System.Web.UI.Page
    Dim path As String

    Dim expDate As Date
    Dim resExp As String
    Dim clsExp As New isItExp
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            resExp = clsExp.loadExpDate()

            If resExp = "Kosong" Then
                lbltest.Text = "Belum set trial"
            ElseIf resExp = "Expired" Then
                lbltest.Text = "Expired"
            End If
        End If
    End Sub

    Protected Sub btnKotrak_Click(sender As Object, e As ImageClickEventArgs) Handles btnKotrak.Click
        Response.Redirect("kontrak.aspx")
    End Sub

    Protected Sub btnDPPM_Click(sender As Object, e As ImageClickEventArgs) Handles btnDPPM.Click
        Response.Redirect("dppm.aspx")
    End Sub

    Protected Sub btnSekre_Click(sender As Object, e As ImageClickEventArgs) Handles btnSekre.Click
        Response.Redirect("sekretaris.aspx")
    End Sub

    'Private Sub loadExpDate()
    '    Try
    '        Dim res As String
    '        Dim expDate As Date
    '        Dim decryptValue As String
    '        Dim tglSekarang As Date = Date.Now

    '        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\CustomScan", "ExpDate", Nothing) Is Nothing Then
    '            Response.Redirect("License.aspx", False)
    '            'res = "Belum Aktivasi License"
    '        Else
    '            Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\CustomScan", "ExpDate", Nothing)
    '            decryptValue = clsRGEnc.RGDecrypt(readValue)
    '            Try
    '                expDate = decryptValue

    '                'If tglSekarang > expDate Then
    '                '    Response.Redirect("Index.aspx", False)
    '                'End If
    '            Catch ex As Exception
    '                res = decryptValue
    '            End Try

    '        End If

    '    Catch ex As Exception

    '    End Try
    'End Sub


End Class