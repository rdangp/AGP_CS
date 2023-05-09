Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Text

Public Class CheckCharCode
    ' Folder path that can be targeted for checking
    Public checkFolderName As String

    ' Error Message
    Private Const notUseCharCodeMessage As String = "The specified folder path includes invalid characters that are unsupported by Apeos JF SCLIPT."

    ''' <summary>
    ''' Constructor
    ''' </summary>
    ''' <param name="folderName"></param>
    Public Sub New(folderName As String)
        checkFolderName = folderName
    End Sub


    ''' <summary>
    ''' Check character codes that are not supported by Apeos JF SCLIPT
    ''' </summary>
    Public Sub CheckCode()
        Dim sjisEnc As Encoding = Encoding.GetEncoding("shift-jis")
        Dim byts As Byte() = New Byte(sjisEnc.GetByteCount(checkFolderName) - 1) {}
        byts = sjisEnc.GetBytes(checkFolderName)
        Dim len As Integer = byts.Length

        For i As Integer = 0 To len - 2
            Dim b1 As Byte = byts(i)
            Dim b2 As Byte = byts(i + 1)


            If (b1 >= &H88 AndAlso b1 <= &H97) AndAlso (b2 >= &H40 AndAlso b2 <= &HFC) Then
                ' JIS X 0208 Level-1 Kanji
                i += 1
            ElseIf (b1 = &H98) AndAlso (b2 >= &H40 AndAlso b2 <= &H72) Then
                ' JIS X 0208 Level-1 Kanji
                i += 1
                ' ASCII
            ElseIf (b1 >= &H20 AndAlso b1 <= &H7E) Then
            Else
                Throw New Exception(notUseCharCodeMessage)

            End If
        Next

    End Sub
End Class
