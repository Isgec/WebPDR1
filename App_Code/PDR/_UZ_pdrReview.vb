Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PDR
  Partial Public Class pdrReview
    Public Shadows Function GetEditable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Shadows Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      Return mRet
    End Function
    Public Shadows ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case StatusID
            Case enumPdr.Submitted
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case StatusID
            Case enumPdr.Submitted
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property RejectWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case StatusID
            Case enumPdr.Submitted
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property RejectWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Shadows Function InitiateWF(ByVal PDRNo As Int32) As SIS.PDR.pdrReview
      Dim Results As SIS.PDR.pdrReview = pdrReviewGetByID(PDRNo)
      Dim actions As List(Of SIS.PDR.pdrActionPlan) = SIS.PDR.pdrActionPlan.pdrActionPlanSelectList(0, 999, "", False, "", PDRNo)
      If actions.Count <= 0 Then
        Throw New Exception("No Action Plan defined, can NOT freeze.")
      Else
        For Each act As SIS.PDR.pdrActionPlan In actions
          If act.StatusID <> enumAction.Freezed Then
            Throw New Exception("Action Plan No.: " & act.ActionNo & " NOT freezed. Pl. Freeze all actions first.")
          End If
        Next
      End If
      Results.StatusID = enumPdr.ActionAssigned
      SIS.PDR.pdrReview.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function RejectWF(ByVal PDRNo As Int32) As SIS.PDR.pdrReview
      Dim Results As SIS.PDR.pdrReview = pdrReviewGetByID(PDRNo)
      Return Results
    End Function
    Public Shared Function UZ_pdrReviewSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PDRNo As Int32, ByVal SeverityOfDefectID As Int32, ByVal CategoryOfDefectID As Int32, ByVal ProjectID As String, ByVal ElementID As String, ByVal DocumentID As String, ByVal CreatedBy As String, ByVal StatusID As Int32) As List(Of SIS.PDR.pdrReview)
      Dim Results As List(Of SIS.PDR.pdrReview) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "PDRNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppdr_LG_ReviewSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppdr_LG_ReviewSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PDRNo", SqlDbType.Int, 10, IIf(PDRNo = Nothing, 0, PDRNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SeverityOfDefectID",SqlDbType.Int,10, IIf(SeverityOfDefectID = Nothing, 0,SeverityOfDefectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CategoryOfDefectID",SqlDbType.Int,10, IIf(CategoryOfDefectID = Nothing, 0,CategoryOfDefectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ElementID",SqlDbType.NVarChar,8, IIf(ElementID Is Nothing, String.Empty,ElementID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DocumentID",SqlDbType.NVarChar,50, IIf(DocumentID Is Nothing, String.Empty,DocumentID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CreatedBy",SqlDbType.NVarChar,8, IIf(CreatedBy Is Nothing, String.Empty,CreatedBy))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusID",SqlDbType.Int,10, IIf(StatusID = Nothing, 0,StatusID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PDR.pdrReview)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PDR.pdrReview(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pdrReviewUpdate(ByVal Record As SIS.PDR.pdrReview) As SIS.PDR.pdrReview
      Dim _Result As SIS.PDR.pdrReview = pdrReviewUpdate(Record)
      Return _Result
    End Function
  End Class
End Namespace
