Public Class License
    Inherits System.Web.UI.Page
    Dim ws_license As New ws_cs_license.ws_license_customscan
    Dim clsRGEnc As New clsRGEncrypt
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub imgButtonCheck_Click(sender As Object, e As ImageClickEventArgs) Handles imgButtonCheck.Click
        If txtLicense.Text = "" Then
        Else
            verifikasiLicense(txtLicense.Text)
            txtLicense.Text = ""
        End If
    End Sub

    Private Function verifikasiLicense(LicenseKey As String)
        Dim expDate As Date
        Dim result As String = ""
        Try
            expDate = ws_license.CS_licensing(LicenseKey)
            result = expDate

            SaveToRegistry(expDate)
        Catch ex As Exception
            result = ws_license.CS_licensing(LicenseKey)
        End Try
        Return result
    End Function

    Private Function SaveToRegistry(tglExpired As Date)
        Dim hasilSimpan As Boolean
        Try
            Dim resEncryptLicense As String
            resEncryptLicense = clsRGEnc.RGEncrypt(tglExpired)
            My.Computer.Registry.CurrentUser.CreateSubKey("CustomScan")
            ' Change MyTestKeyValue to This is a test value. 
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\CustomScan",
            "ExpDate", resEncryptLicense)
            hasilSimpan = True
            lblerr1.Text = hasilSimpan
            lblerr1.Visible = True
        Catch ex As Exception
            hasilSimpan = False
            lblerr1.Text = ex.Message
            lblerr1.Visible = True
        End Try

        Return hasilSimpan


    End Function

End Class