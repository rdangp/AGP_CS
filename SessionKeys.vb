'========================================================================================
'
' Copyright (C) 2007 by Fuji Xerox Co., Ltd. All rights reserved.
'
'========================================================================================
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

''' <summary>
''' This class defines the keys (Session ID) used for storing value to session. 
''' </summary>
Public Class SessionKeys
    ''' <summary>
    ''' Key (SessionID) for storing the full path of the document to be printed
    ''' </summary>
    Public Const PRINT_FILE As String = "PrintFilePathKey"

    ''' <summary>
    ''' Key (Session ID) for storing error message
    ''' </summary>
    Public Const ERROR_MESSAGE As String = "PrintErrorMessageKey"

    ''' <summary>
    ''' Key (SessionID) for storing the multifunction device information
    ''' </summary>
    Public Const DEVICE_INFO As String = "DeviceInfoforPrintKey"

    ''' <summary>
    ''' Key (SessionID) for storing the Standard Print Settings command line 
    ''' </summary>
    Public Const BASIC_COMMANDLINE As String = "BasicCommandLineKey"

    ''' <summary>
    ''' Key (SessionID) for storing the advanced print settings command line
    ''' </summary>
    Public Const OPTION_COMMANDLINE As String = "OptionCommandLineKey"

    ''' <summary>
    ''' Key (SessionID) for storing the state of Page Specification
    ''' </summary>
    Public Const PAGE_SELECT As String = "PageSelectKey"

    ''' <summary>
    ''' Key (SessionID) for storing the Start Page Number of Page Specification
    ''' </summary>
    Public Const START_PAGE As String = "StartPageNumKey"

    ''' <summary>
    ''' Key (SessionID) for storing the End Page Number of Page Specification
    ''' </summary>
    Public Const END_PAGE As String = "EndPageNumKey"

    ''' <summary>
    ''' Key (Session ID) for storing Color Mode
    ''' </summary>
    Public Const COLOR_MODE As String = "ColorModeKey"

    ''' <summary>
    ''' Key (SessionID) for storing the 2-sided Specification
    ''' </summary>
    Public Const DUPLEX_SELECT As String = "DuplexKey"

    ''' <summary>
    ''' Key (Session ID) for storing N-Up
    ''' </summary>
    Public Const N_UP As String = "NupKey"

    ''' <summary>
    ''' Key (SessionID) for storing the Output Size
    ''' </summary>
    Public Const OUTPUT_SIZE As String = "OutputSizeKey"

    ''' <summary>
    ''' Key (SessionID) for storing the number of copies
    ''' </summary>
    Public Const PRINT_COUNT As String = "PrintCountKey"

    ''' <summary>
    ''' Key (Session ID) for storing Sort
    ''' </summary>
    Public Const SORT_ON As String = "SortKey"

    ''' <summary>
    ''' Key (SessionID) for storing Print Mode
    ''' </summary>
    Public Const PRINT_MODE As String = "PrintModeKey"

    ''' <summary>
    ''' Key (Session ID) for storing Annotation
    ''' </summary>
    Public Const ANNOTATION_SELECT As String = "AnnotationKey"

    ''' <summary>
    ''' Key (SessionID) for storing Paper Tray
    ''' </summary>
    Public Const PAPER_BOX As String = "PaperBoxKey"

    ''' <summary>
    ''' Key (SessionID) for storing Paper Type
    ''' </summary>
    Public Const PAPER_KIND As String = "PaperKindKey"

    ''' <summary>
    ''' Key (Session ID) for storing Output Method
    ''' </summary>
    Public Const OUTPUT_PLACE As String = "OutputPlaceKey"

    ''' <summary>
    ''' Key (Session ID) for storing Staple
    ''' </summary>
    Public Const STAPLER_ON As String = "StaplerKey"

    ''' <summary>
    ''' Key (SessionID) for storing Punch
    ''' </summary>
    Public Const PUNCH_ON As String = "PunchKey"
End Class