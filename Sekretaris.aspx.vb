Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Collections.Specialized
Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO
Imports System.Threading
Imports FujiXerox.AIP.Lib.DevCapDB
Imports System.Net
Imports Microsoft.Win32
Imports System.Web.Configuration

Public Class Sekretaris
    Inherits System.Web.UI.Page

    Private Const notJFcreateTitle As String = "Creation of Apeos JF SCLIPT failed"
    Private Const accessErrorTitle As String = "Access denied"
    Private Const accessErrorMessage As String = "Accessing to log folder failed."
    Private Const sessionTimeoutMessage As String = "Session timeout has occurred."
    Private Const pathLengthOverErrMessage As String = "Length of specified folder path is out or range."
    Private Const notSaveJFSclipt As String = "Saving of Apeos JF SCLIPT failed."
    Private Const notCreateJFMessage As String = "An abnormal error occurred while creating Apeos JF SCLIPT."

    Dim FolderPaths As String = My.Settings.DirScanSekretaris
    Dim RootDirectoryPath As String = My.Settings.DirScanSekretaris

    Dim JFTemplatePath As String = My.Settings.JFTemplatePath
    Dim SaveJFScliptFile As String = My.Settings.SaveJFScliptFile
    Dim LogFolderForDebug As String = My.Settings.LogFolderForDebug
    Dim IndexDocServiceURL As String = My.Settings.IndexDocServiceURL

    ' Authorization Information
    Private authModeInfo As String = String.Empty
    Private userPassword As String = String.Empty
    Private userName As String = String.Empty

    Private Const ReturnPath As String = "sekretaris.aspx"

    Dim userLogin As String
    Dim url_docs As String
    Dim resexp As String
    Dim clsExp As New isItExp


    ' Configuration
    Protected ReadOnly Property config() As Config
        Get
            Return DirectCast(Session(Config.ConfigKey), Config)
        End Get
    End Property

    Public WriteOnly Property ErrorMessage() As String
        Set(value As String)
            Session(SessionKeys.ERROR_MESSAGE) = value
        End Set
    End Property

    ' Error title
    Protected WriteOnly Property ErrorTitle() As String
        Set(value As String)
            Session(Config.ErrorTitleKey) = value
        End Set
    End Property

    Protected Property DeviceInfomation() As DeviceInfo
        Get
            Return DirectCast(Session(SessionKeys.DEVICE_INFO), DeviceInfo)
        End Get
        Set(value As DeviceInfo)
            Session(SessionKeys.DEVICE_INFO) = value
        End Set
    End Property

    Private Sub getDeviceInfo()
        Try
            DeviceInfomation = DeviceDataManager.GetDeviceInfo(Me.Request.Headers)
        Catch err As Exception
            ErrorMessage = "Multifunction device information cannot be retrieved." + "<br>" + err.Message + err.StackTrace
            Server.Transfer("ErrorPage.aspx")
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        getDeviceInfo()

        If Not IsPostBack Then
            resexp = clsExp.loadExpDate()
            If resexp = "Kosong" Or resexp = "Expired" Then
                Server.Transfer("Index.aspx")
            End If
            ddlTahun.SelectedValue = Now.Year
        End If
    End Sub

    'Private Sub loadExpDate()
    '    Try
    '        Dim res As String
    '        Dim expDate As Date
    '        Dim decryptValue As String
    '        Dim tglSekarang As Date = Date.Now

    '        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\CustomScan", "ExpDate", Nothing) Is Nothing Then
    '            res = "Belum Aktivasi License"
    '            Response.Redirect("License.aspx")
    '        Else
    '            Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\CustomScan", "ExpDate", Nothing)
    '            decryptValue = clsRGEnc.RGDecrypt(readValue)
    '            Try
    '                expDate = decryptValue

    '                If tglSekarang > expDate Then
    '                    Response.Redirect("Index.aspx")
    '                End If
    '            Catch ex As Exception
    '                res = decryptValue
    '            End Try

    '        End If

    '    Catch ex As Exception

    '    End Try
    'End Sub


    Protected Sub ImageButton2_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton2.Click
        'If ddlCabang.SelectedIndex = 0 Then
        '    lblerr1.Visible = True
        '    lblerr2.Visible = False
        '    lblerr3.Visible = False
        '    lblerr4.Visible = False
        '    lblerr5.Visible = False
        '    lblerr6.Visible = False
        '    Exit Sub
        'ElseIf 
        If ddlJenis.SelectedIndex = 0 Then
            'lblerr1.Visible = False
            lblerr2.Visible = True
            lblerr3.Visible = False
            lblerr4.Visible = False
            lblerr5.Visible = False
            lblerr6.Visible = False
            Exit Sub
        ElseIf ddlTahun.SelectedIndex = 0 Then
            'lblerr1.Visible = False
            lblerr2.Visible = False
            lblerr3.Visible = True
            lblerr4.Visible = False
            lblerr5.Visible = False
            lblerr6.Visible = False
            Exit Sub
        ElseIf ddlBulan.SelectedIndex = 0 Then
            'lblerr1.Visible = False
            lblerr2.Visible = False
            lblerr3.Visible = False
            lblerr4.Visible = True
            lblerr5.Visible = False
            lblerr6.Visible = False
            Exit Sub
        ElseIf txtTanggal.Text = "" Then
            'lblerr1.Visible = False
            lblerr2.Visible = False
            lblerr3.Visible = False
            lblerr4.Visible = False
            lblerr5.Visible = True
            lblerr6.Visible = False
            Exit Sub
        ElseIf txtNamaFile.Text = "" Then
            'lblerr1.Visible = False
            lblerr2.Visible = False
            lblerr3.Visible = False
            lblerr4.Visible = False
            lblerr5.Visible = False
            lblerr6.Visible = True
            Exit Sub
        Else
            'lblerr1.Visible = False
            lblerr2.Visible = False
            lblerr3.Visible = False
            lblerr4.Visible = False
            lblerr5.Visible = False
            lblerr6.Visible = False

            ProcessScan()
        End If
    End Sub

    Private Sub ProcessScan()
        'Dim NamaFolder As String
        Dim Title_scan, ColorMode, ImageMode, Duplex, FilesNames As String

        'FolderPaths = FolderPaths & "\" & ddlCabang.SelectedItem.ToString & "\" & ddlJenis.SelectedItem.ToString & "\" & ddlTahun.SelectedItem.ToString & "\" & ddlBulan.SelectedValue.ToString & "\" & txtTanggal.Text
        FolderPaths = FolderPaths & "\" & ddlTahun.SelectedItem.ToString & "\" & ddlBulan.SelectedValue.ToString & "\" & ddlJenis.SelectedValue.ToString

        Title_scan = txtNamaFile.Text & "_" & txtTanggal.Text

        'If Directory.Exists(FolderPaths) = False Then
        'Directory.CreateDirectory(FolderPaths)
        'End If

        FilesNames = Title_scan
        DocsFullName = Title_scan
        DocsFileName = path.Combine(FolderPaths, Title_scan & ".pdf")
        'DocsFileName = Path.Combine(FolderPaths, Title_scan & ".pdf")

        'If File.Exists(DocsFileName) = True Then
        '    File.Delete(DocsFileName)
        'End If


        'ColorMode = "BlackAndWhite"
        'ColorModes = "BlackAndWhite"
        ColorMode = "Auto"
        ColorModes = "Auto"

        ImageMode = "Mixed"

        Duplex = "Simplex"

        DuplexSet = "None"

        Try
            ' Set the parameter to job flow script creation object
            Dim JFScliptFullPath As String = path.Combine(Server.MapPath(Nothing), JFTemplatePath)
            Dim jfs As New JFSclipt(JFScliptFullPath)


            ' Parameter of registration folder path
            If FolderPaths IsNot Nothing Then
                ' Check character codes of folder path to be written to Apeos JF SCLIPT
                Dim check As New CheckCharCode(FolderPaths)
                check.CheckCode()

                ' Check the length of folder path to be written to Apeos JF SCLIPT
                Dim sjisEnc As Encoding = Encoding.GetEncoding("Shift_JIS")
                Dim pathLength As Integer = sjisEnc.GetByteCount(FolderPaths)
                If pathLength > 199 Then
                    Throw New Exception(pathLengthOverErrMessage)
                End If

                jfs.Foldername = FolderPaths
            Else
                Throw New Exception(sessionTimeoutMessage)
            End If

            ' Registration Document Name parameter
            If Title_scan <> String.Empty Then
                jfs.Documentname = Title_scan
            Else
                Return
            End If

            ' Scan Parameter
            jfs.ColorMode = ColorMode
            jfs.ImageMode = ImageMode
            jfs.Duplex = Duplex

            ' Document Registration Web Service URL
            Dim u As New Uri(HttpContext.Current.Request.Url.AbsoluteUri)
            Dim wsu As New UriBuilder(IndexDocServiceURL)
            wsu.Host = u.Host
            wsu.Port = u.Port
            jfs.IndexDocServiceURL = wsu.ToString()

            'Cek Status Scan OCR
            'jfs.StatusScanOcr = checkScanOcr(DeviceInfomation.IPAddress)


            ' Authentication information parameter
            GetAuthInfo()
            jfs.OperatorName = userName
            jfs.Password = userPassword
            jfs.AuthInfo = authModeInfo


            ' Create the Apeos JF SCLIPT with parameters
            Dim innerXMLstring As String = jfs.CreateJobTemplate()

            ' Save the created Apeos JF SCLIPT (for debugging)
            If SaveJFScliptFile Then
                Try
                    ' Save the Apeos JF SCLIPT
                    SaveJFSclipt(innerXMLstring)
                Catch err As ApplicationException
                    Dim errMessage As String = err.Message

                    If err.InnerException IsNot Nothing Then
                        errMessage = errMessage + err.InnerException.Message
                    End If

                End Try
            End If

            'insertDB()

            ' Send Apeos JF SCLIPT to the multifunction device

            ' Get the total bytes of JF encoded in UTF-8, and then, set to Content-Length 
            Dim enc As Encoding = New UTF8Encoding(False, False)
            Dim body As Byte() = enc.GetBytes(innerXMLstring)
            Dim encJFLength As String = body.Length.ToString()
            Response.AddHeader("Content-Length", encJFLength)

            ' Specify the acquired page after Apeos JF SCLIPT has been executed by the multifunction device
            Response.AddHeader("Return-Path", ReturnPath)
            'Response.AddHeader("Return-Path", ReturnPath & "?docs_file=" & DocsFileName & "&full_name=" & DocsFullName)
            'Response.AddHeader("Return-Path", ReturnPath & "?permenid=" & permen_id)

            'Response.AddHeader("Return-Path", ReturnPath & "?id=" & id_pekerjaan & "&divisi=" & ddlDivisi.SelectedItem.ToString & "&nama=" & txtPekerjaan.Text)
            'Response.AddHeader("Return-Path", ReturnPath & "?nama=" & txtPekerjaan.Text & "&divisi=" & ddlDivisi.SelectedItem.ToString)

            ' Specify the ContentType of Apeos JF SCLIPT to be sent
            Response.ContentType = "application/vnd.fujixerox.jfi+xml"

            ' Write Apeos JF SCLIPT 
            Dim os As Stream = Response.OutputStream
            os.Write(body, 0, body.Length)

            'insertDB()

            ' Send
            Response.Flush()

            ' Suspend page processing

            Response.[End]()

            'Microsoft Document Number: 312629
            'ThreadAbortException occurs when using [PRB] Response.End,
            'Response.Redirect, or Server.Transfer method.
            'This behavior is in the specification. NO need to implement error handling. 
        Catch generatedExceptionName As ThreadAbortException
        Catch err As ApplicationException
            ' Error during Apeos JF SCLIPT creation
            Dim errJFMessage As String = err.Message

            If err.InnerException IsNot Nothing Then
                errJFMessage = errJFMessage + err.InnerException.Message
            End If

            ErrorMessage = notCreateJFMessage
            ErrorTitle = notJFcreateTitle


            Server.Transfer("ErrorPage.aspx")
        Catch err As Exception
            Dim errorMessage__1 As String = err.Message

            If err.InnerException IsNot Nothing Then
                errorMessage__1 = errorMessage__1 + err.InnerException.Message
            End If

            ErrorMessage = errorMessage__1
            ErrorTitle = notJFcreateTitle


            Server.Transfer("ErrorPage.aspx")
        End Try
    End Sub

    ''' <summary>
    ''' Save the created Apeos JF SCLIPT to local folder
    ''' </summary>
    Private Sub SaveJFSclipt(innerXMLstring As String)
        Try
            Dim JFfileNameBody As String = DateTime.Now.ToString("yyyyMMddHHmmss")
            Dim JFfileName As String = JFfileNameBody
            Dim num As Integer = 0
            Dim JFfilesavepath As String = String.Empty
            Dim fs As FileStream = Nothing

            While fs Is Nothing
                Try
                    Dim JFSavePath As String = path.Combine(Server.MapPath(Nothing), config.LogFolderForDebug)
                    JFfilesavepath = path.Combine(JFSavePath, JFfileName & Convert.ToString(".xml"))
                    fs = New FileStream(JFfilesavepath, FileMode.CreateNew)
                Catch generatedExceptionName As IOException
                    JFfileName = (JFfileNameBody & Convert.ToString("-")) + num.ToString()
                    num = num + 1
                End Try
            End While
            ' Save to text file as String
            Dim sw As New StreamWriter(fs)
            sw.Write(innerXMLstring)
            sw.Close()
        Catch err As Exception
            Throw New ApplicationException(notSaveJFSclipt, err)
        End Try

    End Sub

    Private Sub GetAuthInfo()
        ' Get the authentication method 
        Dim auth As String = Context.Request.Headers("Authorization")
        Dim basicString As String = "Basic "
        Dim digestString As String = "Digest "
        Dim unAuthString As String = "UnAuth "
        Dim ntlmString As String = "NTLM "

        If auth IsNot Nothing AndAlso auth.Contains(basicString) Then
            ' For HTTP Standard Authentication (Get user information from application)
            authModeInfo = basicString

            ' Get the password from the Authorization header
            Dim authUserInfo As String = auth.Substring(basicString.Length)
            Dim byteArray As Byte() = Convert.FromBase64String(authUserInfo)
            Dim encAuthUserInfo As String = Encoding.UTF8.GetString(byteArray)
            Dim indexpoint As Integer = encAuthUserInfo.IndexOf(":")
            userPassword = encAuthUserInfo.Substring(indexpoint + 1)

            ' Get the authentication user name
            userName = Context.User.Identity.Name
        ElseIf auth IsNot Nothing AndAlso auth.Contains(digestString) Then
            ' For Digest Authentication
            authModeInfo = digestString
        ElseIf Page.User.Identity.IsAuthenticated Then
            ' For Windows Integrated Authentication
            authModeInfo = ntlmString
        Else
            ' No authentication (For anonymous access)
            authModeInfo = unAuthString
        End If
    End Sub

    Private Function checkScanOcr(ipaddress As String)

        Dim result As String
        Dim check As Boolean = False

        Dim req As Net.HttpWebRequest = WebRequest.Create("http://" & ipaddress & "/ssm/Management/Anonymous/StatusConfig")

        req.ContentType = "text/xml; charset=utf-8"
        req.Headers.Add("SOAPAction", """http://www.fujixerox.co.jp/2003/12/ssm/management/statusConfig#GetAttribute""")
        req.Headers.Add("Authorization: Basic MTExMTE6eC1hZG1pbg==")
        req.Method = "POST"

        'Dim postData As String = "<?xml version=""1.0"" encoding=""utf-8""?>" & Chr(10) &
        '"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">" & Chr(10) &
        '"   <SOAP-ENV:Body>" & Chr(10) &
        '"       <ListCsvFolder xmlns=""http://www.fujixerox.co.jp/2007/07/ssm/management/csv"" />" & Chr(10) &
        '"   </SOAP-ENV:Body>" & Chr(10) &
        '"</SOAP-ENV:Envelope>" & Chr(10)

        Dim postData As String = "<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">" & Chr(10) &
        "<soap:Body>" & Chr(10) &
        "<GetAttribute xmlns=""http://www.fujixerox.co.jp/2003/12/ssm/management/statusConfig"">" & Chr(10) &
        "<Object name=""urn:fujixerox:names:ssm:1.0:management:Option"" identifier=""SCAN_OCR"">" & Chr(10) &
        "<Attribute name=""Name"" />" & Chr(10) &
        "<Attribute name=""Status"" />" & Chr(10) &
        "</Object>" & Chr(10) &
        "</GetAttribute>" & Chr(10) &
        "</soap:Body>" & Chr(10) &
        "</soap:Envelope>" & Chr(10)

        Dim bytesToWrite As Byte() = Encoding.UTF8.GetBytes(postData)
        req.KeepAlive = True
        req.ContentLength = bytesToWrite.Length

        System.Net.ServicePointManager.Expect100Continue = False

        Dim newStream As Stream = req.GetRequestStream()
        newStream.Write(bytesToWrite, 0, bytesToWrite.Length)
        newStream.Close()

        Dim responses As WebResponse = req.GetResponse()

        Dim response As Net.HttpWebResponse = CType(req.GetResponse(), Net.HttpWebResponse)
        Dim dataStream As Stream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)

        Dim responseFromServer As String = reader.ReadToEnd()

        Dim xd As New XmlDocument
        xd.LoadXml(responseFromServer)
        Dim elemList As XmlNodeList = xd.GetElementsByTagName("Attribute")

        result = elemList(1).InnerXml

        If result = "ACTIVE" Then
            check = True
        Else
            check = False
        End If

        Return check
    End Function

    Protected Sub btnBack_Click(sender As Object, e As ImageClickEventArgs) Handles btnBack.Click
        Response.Redirect("index.aspx")
    End Sub
End Class