Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PDR
  <DataObject()> _
  Partial Public Class pdrSubmitResponse
    Inherits SIS.PDR.pdrActionPlan
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pdrSubmitResponseGetNewRecord() As SIS.PDR.pdrSubmitResponse
      Return New SIS.PDR.pdrSubmitResponse()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pdrSubmitResponseSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PDRNo As Int32) As List(Of SIS.PDR.pdrSubmitResponse)
      Dim Results As List(Of SIS.PDR.pdrSubmitResponse) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ActionNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppdrSubmitResponseSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppdrSubmitResponseSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PDRNo",SqlDbType.Int,10, IIf(PDRNo = Nothing, 0,PDRNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PDR.pdrSubmitResponse)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PDR.pdrSubmitResponse(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pdrSubmitResponseSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PDRNo As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pdrSubmitResponseGetByID(ByVal PDRNo As Int32, ByVal ActionNo As Int32) As SIS.PDR.pdrSubmitResponse
      Dim Results As SIS.PDR.pdrSubmitResponse = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppdrActionPlanSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PDRNo",SqlDbType.Int,PDRNo.ToString.Length, PDRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActionNo",SqlDbType.Int,ActionNo.ToString.Length, ActionNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PDR.pdrSubmitResponse(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pdrSubmitResponseGetByID(ByVal PDRNo As Int32, ByVal ActionNo As Int32, ByVal Filter_PDRNo As Int32) As SIS.PDR.pdrSubmitResponse
      Dim Results As SIS.PDR.pdrSubmitResponse = SIS.PDR.pdrSubmitResponse.pdrSubmitResponseGetByID(PDRNo, ActionNo)
      Return Results
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
