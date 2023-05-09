Imports System.Xml.Serialization

Public Class Config
    ''' <summary>
    ''' Name space for Web application
    ''' </summary>
    Public Const WebUiSampleNamespace As String = "StudentPrint2015"

    ''' <summary>
    ''' Key (Session ID) for storing configuration
    ''' </summary>
    Public Const ConfigKey As String = WebUiSampleNamespace + "/config"

    ''' <summary>
    ''' Key (Session ID) for storing folder path
    ''' </summary>
    Public Const FolderKey As String = WebUiSampleNamespace + "/FolderPath"

    ''' <summary>
    ''' Key (Session ID) for storing check status
    ''' </summary>
    Public Const CheckedKey As String = WebUiSampleNamespace + "/currentChecked"

    ''' <summary>
    ''' Key (Session ID) for storing the filename to be printed
    ''' </summary>
    Public Const PrintTargetFilesKey As String = WebUiSampleNamespace + "/PrintTargetFiles"


    ''' <summary>
    ''' Key (Session ID) for storing error message
    ''' </summary>
    Public Const ErrorMessageKey As String = WebUiSampleNamespace + "/ErrorMessage"

    ''' <summary>
    ''' Key (Session ID) for storing error title
    ''' </summary>
    Public Const ErrorTitleKey As String = WebUiSampleNamespace + "/ErrorTitle"



    ''' <summary>
    ''' Waiting time after the print process starts
    ''' </summary>
    <XmlElement("PrintWaitTime", GetType(Integer))> _
    Public PrintWaitTime As Integer


    ''' <summary>
    ''' Multifunction device's IP address to be used for printing while debugging
    ''' </summary>
    <XmlElement("DeviceIPForDebug")> _
    Public DeviceIPForDebug As String


    ''' <summary>
    ''' Document Registration Web Service URL
    ''' </summary>
    <XmlElement("IndexDocServiceURL")> _
    Public IndexDocServiceURL As String


    ''' <summary>
    ''' Folder for Apeos JF SCLIPT template
    ''' </summary>
    <XmlElement("JFTemplatePath")> _
    Public JFTemplatePath As String


    ''' <summary>
    ''' Folder used for storing error logs and Apeos JF SCLIPT
    ''' </summary>
    <XmlElement("LogFolderForDebug")> _
    Public LogFolderForDebug As String


    ''' <summary>
    ''' Stored flag for Apeos JF SCLIPT
    ''' </summary>
    <XmlElement("SaveJFScliptFile", GetType(Boolean))> _
    Public SaveJFScliptFile As Boolean


    ''' <summary>
    ''' Root folder path for referring to the document
    ''' </summary>
    <XmlElement("RootDirectoryPath")> _
    Public RootDirectoryPath As String

    ''' <summary>
    ''' Flag indicating whether DocuWorks document supports direct printing
    ''' </summary>
    <XmlElement("XdwSupport", GetType(Boolean))> _
    Public XdwSupport As Boolean
End Class
