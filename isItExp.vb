
Imports System.Web.Configuration

Public Class isItExp
    Dim configurations As Configuration
    Dim appSettingsSection As AppSettingsSection
    Dim settingz As KeyValueConfigurationCollection
    Dim clsrgenc As New clsRGEncrypt
    Dim expDate As Date
    Public Function loadExpDate()
        Dim res As String = ""
        Dim path As String
        path = "~"
        configurations = WebConfigurationManager.OpenWebConfiguration(path)
        appSettingsSection = CType(configurations.GetSection("appSettings"), AppSettingsSection)
        settingz = appSettingsSection.Settings

        Try
            Dim decryptStr As String
            decryptStr = clsrgenc.RGDecrypt(settingz("Trial").Value)
            If decryptStr = "" Then
                res = "Kosong"
            Else
                expDate = decryptStr
                If expDate < Date.Now Then
                    res = "Expired"
                End If
            End If
        Catch ex As Exception
            expDate = Nothing
        End Try
        Return res
    End Function
End Class
