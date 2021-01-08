Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PDR
  <DataObject()> _
  Partial Public Class pdrReview
    Inherits SIS.PDR.pdrCreate
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pdrReviewGetNewRecord() As SIS.PDR.pdrReview
      Return New SIS.PDR.pdrReview()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pdrReviewSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PDRNo As Int32, ByVal SeverityOfDefectID As Int32, ByVal CategoryOfDefectID As Int32, ByVal ProjectID As String, ByVal ElementID As String, ByVal DocumentID As String, ByVal CreatedBy As String, ByVal StatusID As Int32) As List(Of SIS.PDR.pdrReview)
      Dim Results As List(Of SIS.PDR.pdrReview) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "PDRNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppdrReviewSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppdrReviewSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PDRNo",SqlDbType.Int,10, IIf(PDRNo = Nothing, 0,PDRNo))
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
    Public Shared Function pdrReviewSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PDRNo As Int32, ByVal SeverityOfDefectID As Int32, ByVal CategoryOfDefectID As Int32, ByVal ProjectID As String, ByVal ElementID As String, ByVal DocumentID As String, ByVal CreatedBy As String, ByVal StatusID As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pdrReviewGetByID(ByVal PDRNo As Int32) As SIS.PDR.pdrReview
      Dim Results As SIS.PDR.pdrReview = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppdrCreateSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PDRNo",SqlDbType.Int,PDRNo.ToString.Length, PDRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PDR.pdrReview(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pdrReviewGetByID(ByVal PDRNo As Int32, ByVal Filter_PDRNo As Int32, ByVal Filter_SeverityOfDefectID As Int32, ByVal Filter_CategoryOfDefectID As Int32, ByVal Filter_ProjectID As String, ByVal Filter_ElementID As String, ByVal Filter_DocumentID As String, ByVal Filter_CreatedBy As String, ByVal Filter_StatusID As Int32) As SIS.PDR.pdrReview
      Dim Results As SIS.PDR.pdrReview = SIS.PDR.pdrReview.pdrReviewGetByID(PDRNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pdrReviewUpdate(ByVal Record As SIS.PDR.pdrReview) As SIS.PDR.pdrReview
      Dim _Rec As SIS.PDR.pdrReview = SIS.PDR.pdrReview.pdrReviewGetByID(Record.PDRNo)
      With _Rec
        .PDRDate = Record.PDRDate
        .SeverityOfDefectID = Record.SeverityOfDefectID
        .CategoryOfDefectID = Record.CategoryOfDefectID
        .ProjectID = Record.ProjectID
        .ElementID = Record.ElementID
        .DocumentID = Record.DocumentID
        .DocumentRev = Record.DocumentRev
        .DefectDescription = Record.DefectDescription
        .AnnexurePath = Record.AnnexurePath
        .CostImpact = Record.CostImpact
        .CostImpactDebitableTo = Record.CostImpactDebitableTo
        .TimeImpact = Record.TimeImpact
        .SolutionToBeGivenBy = Record.SolutionToBeGivenBy
        .SolutionToBeGivenByUsers = Record.SolutionToBeGivenByUsers
        .ProposedSolution = Record.ProposedSolution
        .SolutionGivenOn = Record.SolutionGivenOn
        .CreatedBy = Record.CreatedBy
        .StatusID = Record.StatusID
        .CreatedOn = Record.CreatedOn
      End With
      Return SIS.PDR.pdrReview.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
