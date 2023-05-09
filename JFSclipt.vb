Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

Public Class JFSclipt
    ' Apeos JF SCLIPT Language Name Space
    Protected Const JobTemplateNamespace As String = "http://www.fujixerox.co.jp/2003/12/ssm/jobTemplate"

    ' Apeos JF SCLIPT Template Filename
    ' JF SCLIPT template without authorization when calling an external service
    Private Const jfSciprtTemplateName_UnAuth As String = "Sample_UnAuth.xml"
    Private Const jfSciprtTemplateName_UnAuth_OCR As String = "Sample_UnAuth_OCR.xml"
    ' JF SCLIPT template with authorization when calling an external service
    ' (Write the authorization information from the Web application)
    Private Const jfSciprtTemplateName_BasicAuth As String = "Sample_AuthInfofromWebApp.xml"
    ' JF SCLIPT template with authorization when calling an external service
    ' (Get the authorization information from MFP)
    Private Const jfScriptTemplateName_DigestAuth As String = "Sample_AuthInfofromMFP.xml"


    ' Path of Apeos JF SCLIPT
    Public JobTemplatePath As String

    ' Error Message
    Private Const notSetParameters As String = "Parameter is invalid."
    Private Const notSetUserNamePassword As String = "Parameters for User name and password are invalid."
    Private Const notCreateJFMessage As String = "An abnormal error occurred while creating Apeos JF SCLIPT."


    ' Parameter for Apeos JF SCLIPT
    ' Document Information
    Public Foldername As String
    Public Documentname As String
    ' Scan Parameter
    Public ColorMode As String
    Public ImageMode As String
    Public Duplex As String
    ' Document Registration Web Service URL
    Public IndexDocServiceURL As String
    ' Authorization Information
    Public OperatorName As String
    Public Password As String
    Public AuthInfo As String

    Public StatusScanOcr As Boolean

    ''' <summary>
    ''' Constructor(public)
    ''' Initialize each parameter
    ''' </summary>
    ''' <param name="jobTemplatePath"></param>
    Public Sub New(jobTemplatePath__1 As String)
        JobTemplatePath = jobTemplatePath__1
        Foldername = String.Empty
        Documentname = String.Empty
        ColorMode = String.Empty
        ImageMode = String.Empty
        Duplex = String.Empty
        IndexDocServiceURL = String.Empty
        OperatorName = String.Empty
        Password = String.Empty
    End Sub

    ''' <summary>
    ''' Create Apeos JF SCLIPT
    ''' </summary>
    ''' <returns></returns>
    Public Function CreateJobTemplate() As String
        Dim innerXmlString As String = String.Empty

        Try
            If [String].IsNullOrEmpty(JobTemplatePath) OrElse [String].IsNullOrEmpty(Foldername) OrElse [String].IsNullOrEmpty(Documentname) OrElse [String].IsNullOrEmpty(IndexDocServiceURL) OrElse [String].IsNullOrEmpty(ColorMode) OrElse [String].IsNullOrEmpty(ImageMode) OrElse [String].IsNullOrEmpty(Duplex) Then
                Throw New Exception(notSetParameters)
            End If

            Dim JFScliptTemplatePath As String


            If AuthInfo = "Basic " Then
                ' When using HTTP Standard Authorization to call an external service, 
                ' use JF SCLIPT template with authorization 
                ' (Write the authorization information from the Web application)
                If Not [String].IsNullOrEmpty(OperatorName) AndAlso Not [String].IsNullOrEmpty(Password) Then
                    JFScliptTemplatePath = Path.Combine(JobTemplatePath, jfSciprtTemplateName_BasicAuth)
                Else
                    Throw New Exception(notSetUserNamePassword)
                End If
            ElseIf AuthInfo = "Digest " OrElse AuthInfo = "NTLM " Then
                ' When using HTTP Digest Authorization to call an external service, 
                ' use JF SCLIPT template with authorization (Get the authorization information from MFP)
                JFScliptTemplatePath = Path.Combine(JobTemplatePath, jfScriptTemplateName_DigestAuth)
            Else
                ' When using Anonymous Authorization to call an external service, 
                ' use JF SCLIPT template without authorization (Get the authorization information from MFP)
                If StatusScanOcr = True Then
                    JFScliptTemplatePath = Path.Combine(JobTemplatePath, jfSciprtTemplateName_UnAuth_OCR)
                Else
                    JFScliptTemplatePath = Path.Combine(JobTemplatePath, jfSciprtTemplateName_UnAuth)
                End If
            End If


            ' Read the Apeos JF SCLIPT
            Dim dom As New XmlDocument()
            dom.Load(JFScliptTemplatePath)
            ' Management of name space used in Apeos JF SCLIPT 
            Dim nsmgr As New XmlNamespaceManager(dom.NameTable)
            nsmgr.AddNamespace("jt", JobTemplateNamespace)


            ' Document Parameter
            ' jt:Input[documentname]
            Dim inputdocumentnameNodeName As String = "//jt:Group[@jt:name='DocParam']/jt:Input[@jt:name='DocumentName']"
            Dim inputdocumentnameNode As XmlNode = dom.SelectSingleNode(inputdocumentnameNodeName, nsmgr)
            inputdocumentnameNode.InnerXml = (Convert.ToString("<jt:Value>") & Documentname) + "</jt:Value>"
            ' jt:Input[foldername]
            Dim inputfoldernameNodeName As String = "//jt:Group[@jt:name='DocParam']/jt:Input[@jt:name='FolderName']"
            Dim inputfoldernameNode As XmlNode = dom.SelectSingleNode(inputfoldernameNodeName, nsmgr)
            inputfoldernameNode.InnerXml = (Convert.ToString("<jt:Value>") & Foldername) + "</jt:Value>"


            ' Scan Parameter
            ' jt:Input[ColorMode]
            Dim inputColorModeNodeName As String = "//jt:Group[@jt:name='ScanParam']/jt:Input[@jt:name='ColorMode']"
            Dim inputColorModeNode As XmlNode = dom.SelectSingleNode(inputColorModeNodeName, nsmgr)
            If ColorMode = "FullColor" Then
                inputColorModeNode.InnerXml = (Convert.ToString("<jt:Choice jt:label=""Auto"">Auto</jt:Choice><jt:Choice jt:label=""Monochrome"">BlackAndWhite</jt:Choice><jt:Choice jt:label=""Gray scale"">Grayscale</jt:Choice><jt:Choice jt:label=""Full color"" jt:defaultValue=""true"">FullColor</jt:Choice><jt:Value>") & ColorMode) + "</jt:Value>"
            ElseIf ColorMode = "BlackAndWhite" Then
                inputColorModeNode.InnerXml = (Convert.ToString("<jt:Choice jt:label=""Auto"">Auto</jt:Choice><jt:Choice jt:label=""Monochrome"" jt:defaultValue=""true"">BlackAndWhite</jt:Choice><jt:Choice jt:label=""Gray scale"">Grayscale</jt:Choice><jt:Choice jt:label=""Full color"">FullColor</jt:Choice><jt:Value>") & ColorMode) + "</jt:Value>"
            ElseIf ColorMode = "Grayscale" Then
                inputColorModeNode.InnerXml = (Convert.ToString("<jt:Choice jt:label=""Auto"">Auto</jt:Choice><jt:Choice jt:label=""Monochrome"">BlackAndWhite</jt:Choice><jt:Choice jt:label=""Gray scale"" jt:defaultValue=""true"">Grayscale</jt:Choice><jt:Choice jt:label=""Full color"">FullColor</jt:Choice><jt:Value>") & ColorMode) + "</jt:Value>"
            Else
                inputColorModeNode.InnerXml = (Convert.ToString("<jt:Choice jt:label=""Auto"" jt:defaultValue=""true"">Auto</jt:Choice><jt:Choice jt:label=""Monochrome"">BlackAndWhite</jt:Choice><jt:Choice jt:label=""Gray scale"">Grayscale</jt:Choice><jt:Choice jt:label=""Full color"">FullColor</jt:Choice><jt:Value>") & ColorMode) + "</jt:Value>"
            End If

            ' jt:Input[Duplex]
            Dim inputDuplexNodeName As String = "//jt:Group[@jt:name='ScanParam']/jt:Input[@jt:name='Duplex']"
            Dim inputDuplexNode As XmlNode = dom.SelectSingleNode(inputDuplexNodeName, nsmgr)
            If Duplex = "Duplex" Then
                inputDuplexNode.InnerXml = (Convert.ToString("<jt:Choice jt:label=""1-sided Print"">Simplex</jt:Choice><jt:Choice jt:label=""2-sided Print (Flip on long edge)"" jt:defaultValue=""true"">Duplex</jt:Choice><jt:Choice jt:label=""2-sided Print (Flip on short edge)"">Tumble</jt:Choice><jt:Value>") & Duplex) + "</jt:Value>"
            ElseIf Duplex = "Tumble" Then
                inputDuplexNode.InnerXml = (Convert.ToString("<jt:Choice jt:label=""1-sided Print"">Simplex</jt:Choice><jt:Choice jt:label=""2-sided Print (Flip on long edge)"">Duplex</jt:Choice><jt:Choice jt:label=""2-sided Print (Flip on short edge)"" jt:defaultValue=""true"">Tumble</jt:Choice><jt:Value>") & Duplex) + "</jt:Value>"
            Else
                inputDuplexNode.InnerXml = (Convert.ToString("<jt:Choice jt:label=""1-sided Print"" jt:defaultValue=""true"">Simplex</jt:Choice><jt:Choice jt:label=""2-sided Print (Flip on long edge)"">Duplex</jt:Choice><jt:Choice jt:label=""2-sided Print (Flip on short edge)"">Tumble</jt:Choice><jt:Value>") & Duplex) + "</jt:Value>"
            End If


            ' jt:Input[ImageMode]
            Dim inputImageModeNodeName As String = "//jt:Group[@jt:name='ScanParam']/jt:Input[@jt:name='ImageMode']"
            Dim inputImageModeNode As XmlNode = dom.SelectSingleNode(inputImageModeNodeName, nsmgr)
            If ImageMode = "Halftone" Then
                inputImageModeNode.InnerXml = (Convert.ToString("<jt:Choice jt:label=""Text"">Text</jt:Choice><jt:Choice jt:label=""Photo"" jt:defaultValue=""true"">Halftone</jt:Choice><jt:Choice jt:label=""Text + Photo"">Mixed</jt:Choice><jt:Value>") & ImageMode) + "</jt:Value>"
            ElseIf ImageMode = "Mixed" Then
                inputImageModeNode.InnerXml = (Convert.ToString("<jt:Choice jt:label=""Text"">Text</jt:Choice><jt:Choice jt:label=""Photo"">Halftone</jt:Choice><jt:Choice jt:label=""Text + Photo"" jt:defaultValue=""true"">Mixed</jt:Choice><jt:Value>") & ImageMode) + "</jt:Value>"
            Else
                inputImageModeNode.InnerXml = (Convert.ToString("<jt:Choice jt:label=""Text"" jt:defaultValue=""true"">Text</jt:Choice><jt:Choice jt:label=""Photo"">Halftone</jt:Choice><jt:Choice jt:label=""Text + Photo"">Mixed</jt:Choice><jt:Value>") & ImageMode) + "</jt:Value>"
            End If




            ' Parameter for external service call
            'invoke Parameter
            Dim TargetUrlNodeName As String = "//jt:DocumentProcess/jt:Invoke/jt:Profile/jt:Target"
            Dim TargetUrlNode As XmlNode = dom.SelectSingleNode(TargetUrlNodeName, nsmgr)
            TargetUrlNode.InnerXml = IndexDocServiceURL

            Dim LocationUrlNodeName As String = "//jt:DocumentProcess/jt:Invoke/jt:Profile/jt:Schema/jt:Location"
            Dim LocationUrlNode As XmlNode = dom.SelectSingleNode(LocationUrlNodeName, nsmgr)
            LocationUrlNode.InnerXml = IndexDocServiceURL & Convert.ToString("?WSDL")


            ' Assign a value to OperatorName and Password only when HTTP Standard Authorization is used.
            If AuthInfo = "Basic " Then
                Dim SchemaOperatorNodeName As String = "//jt:DocumentProcess/jt:Invoke/jt:Request/jt:AuthInfo/jt:OperatorName"
                Dim SchemaOperatorNode As XmlNode = dom.SelectSingleNode(SchemaOperatorNodeName, nsmgr)
                SchemaOperatorNode.InnerXml = OperatorName

                Dim SchemaPasswordNodeName As String = "//jt:DocumentProcess/jt:Invoke/jt:Request/jt:AuthInfo/jt:Password"
                Dim SchemaPasswordNode As XmlNode = dom.SelectSingleNode(SchemaPasswordNodeName, nsmgr)
                SchemaPasswordNode.InnerXml = Password
            End If

            ' Save the created Apeos JF SCLIPT

            innerXmlString = dom.InnerXml

        Catch err As Exception
            ' Error: Creation of Apeos JF SCLIPT failed.
            Throw New ApplicationException(notCreateJFMessage, err)
        End Try

        Return innerXmlString

    End Function
End Class
