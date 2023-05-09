Imports System.Web.Configuration

Public Class Trial
    Inherits System.Web.UI.Page
    Dim configurations As Configuration
    Dim settingz As KeyValueConfigurationCollection
    Dim clsrgenc As New clsRGEncrypt
    Dim path As String
    Dim appSettingsSection As AppSettingsSection
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        path = "~"
        configurations = WebConfigurationManager.OpenWebConfiguration(path)
        appSettingsSection = CType(configurations.GetSection("appSettings"), AppSettingsSection)
        settingz = appSettingsSection.Settings
    End Sub

    Private Sub imgButtonSimpan_Click(sender As Object, e As ImageClickEventArgs) Handles imgButtonSimpan.Click
        Dim dateExp As Date
        Dim exp As String


        If ddlRange.SelectedValue = "" Then
            lblerr1.Visible = True
        ElseIf txtLama.Text = "" Then
            lblerr2.Visible = True
        Else
            lblerr1.Visible = False
            lblerr2.Visible = False
            If ddlRange.SelectedValue = "hari" Then
                dateExp = Date.Now.AddDays(txtLama.Text)
                Try
                    exp = clsrgenc.RGEncrypt(dateExp)
                    settingz("Trial").Value = exp
                Catch ex As Exception
                    settingz.Add("Trial", txtLama.Text)
                End Try
            ElseIf ddlRange.SelectedValue = "bulan" Then
                dateExp = Date.Now.AddMonths(txtLama.Text)
                Try
                    exp = clsrgenc.RGEncrypt(dateExp)
                    settingz("Trial").Value = exp
                Catch ex As Exception
                    settingz.Add("Trial", txtLama.Text)
                End Try
            ElseIf ddlRange.SelectedValue = "tahun" Then
                dateExp = Date.Now.AddMonths(txtLama.Text)
                Try
                    exp = clsrgenc.RGEncrypt(dateExp)
                    settingz("Trial").Value = exp
                Catch ex As Exception
                    settingz.Add("Trial", txtLama.Text)
                End Try
            End If
            configurations.Save()
            lblStatus.Text = "Berhasil disimpan"
        End If
    End Sub
End Class