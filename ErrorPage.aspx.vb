Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Public Class ErrorPage
    Inherits System.Web.UI.Page

    Public ReadOnly Property ErrorMessage() As String
        Get
            Return DirectCast(Session(SessionKeys.ERROR_MESSAGE), String)
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not [String].IsNullOrEmpty(ErrorMessage) Then
            message.Text = ErrorMessage
        Else
            message.Text = "Internal Error Ocurred"
        End If
    End Sub

    'Protected Sub goToTopButton_Click(sender As Object, e As EventArgs) Handles goToTopButton.Click
    '    Session.RemoveAll()
    '    Server.Transfer("Index.aspx")
    'End Sub

    Protected Sub btnOK_Click(sender As Object, e As ImageClickEventArgs) Handles btnOK.Click
        'Session.RemoveAll()
        Server.Transfer("Index.aspx")
    End Sub
End Class