﻿Imports System.Data.SqlClient
Imports System.Data
Imports ejiVault
Namespace SIS.SYS.Utilities
	Public Class ApplicationSpacific
    Public Shared Sub Initialize()
      With HttpContext.Current
        .Session("ApplicationID") = 106
        .Session("ApplicationDefaultPage") = "~/Default.aspx"
        .Session("FinanceCompany") = "200"
      End With
      EJI.DBCommon.BaaNLive = Convert.ToBoolean(ConfigurationManager.AppSettings("BaaNLive"))
      EJI.DBCommon.JoomlaLive = Convert.ToBoolean(ConfigurationManager.AppSettings("JoomlaLive"))
      EJI.DBCommon.ERPCompany = ConfigurationManager.AppSettings("ERPCompany")
      EJI.DBCommon.IsLocalISGECVault = Convert.ToBoolean(ConfigurationManager.AppSettings("IsLocalISGECVault"))
      EJI.DBCommon.ISGECVaultIP = ConfigurationManager.AppSettings("ISGECVaultIP")
    End Sub

    Public Shared Function ContentType(ByVal FileName As String) As String
      Dim mRet As String = "application/octet-stream"
      Dim Extn As String = IO.Path.GetExtension(FileName).ToLower.Replace(".", "")
      Select Case Extn
        Case "pdf", "rtf"
          mRet = "application/" & Extn
        Case "doc", "docx"
          mRet = "application/vnd.ms-works"
        Case "xls", "xlsx"
          mRet = "application/vnd.ms-excel"
        Case "gif", "jpg", "jpeg", "png", "tif", "bmp"
          mRet = "image/" & Extn
        Case "pot", "ppt", "pps", "pptx", "ppsx"
          mRet = "application/vnd.ms-powerpoint"
        Case "htm", "html"
          mRet = "text/HTML"
        Case "txt"
          mRet = "text/plain"
        Case "zip"
          mRet = "application/zip"
        Case "rar", "tar", "tgz"
          mRet = "application/x-compressed"
        Case Else
          mRet = "application/octet-stream"
      End Select
      Return mRet
    End Function
  End Class
End Namespace