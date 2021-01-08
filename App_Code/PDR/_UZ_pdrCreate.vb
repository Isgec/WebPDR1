Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PDR
  Partial Public Class pdrCreate
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Select Case StatusID
        Case enumPdr.Submitted
          mRet = Drawing.Color.Green
        Case enumPdr.ActionAssigned
          mRet = Drawing.Color.DarkGoldenrod
        Case enumPdr.ResponsesReceived
          mRet = Drawing.Color.Purple
        Case enumPdr.Closed
          mRet = Drawing.Color.CadetBlue
        Case enumPdr.Returned
          mRet = Drawing.Color.Red
      End Select
      Return mRet
    End Function
    Public ReadOnly Property StatusName As String
      Get
        Return System.Enum.GetName(GetType(enumPdr), StatusID)
      End Get
    End Property
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      Select Case StatusID
        Case enumPdr.Free, enumPdr.Returned
          mRet = True
      End Select
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      Select Case StatusID
        Case enumPdr.Free, enumPdr.Returned
          mRet = True
      End Select
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DeleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Select Case StatusID
          Case enumPdr.Free, enumPdr.Returned
            mRet = True
        End Select
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DeleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function DeleteWF(ByVal PDRNo As Int32) As SIS.PDR.pdrCreate
      Dim Results As SIS.PDR.pdrCreate = pdrCreateGetByID(PDRNo)
      SIS.PDR.pdrCreate.pdrCreateDelete(Results)
      Return Results
    End Function
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Select Case StatusID
          Case enumPdr.Free, enumPdr.Returned
            mRet = True
        End Select
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function InitiateWF(ByVal PDRNo As Int32) As SIS.PDR.pdrCreate
      Dim Results As SIS.PDR.pdrCreate = pdrCreateGetByID(PDRNo)
      With Results
        .StatusID = enumPdr.Submitted
        .CreatedBy = HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
      End With
      SIS.PDR.pdrCreate.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function UZ_pdrCreateSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PDRNo As Int32, ByVal SeverityOfDefectID As Int32, ByVal CategoryOfDefectID As Int32, ByVal ProjectID As String, ByVal ElementID As String, ByVal DocumentID As String, ByVal CreatedBy As String, ByVal StatusID As Int32) As List(Of SIS.PDR.pdrCreate)
      Dim Results As List(Of SIS.PDR.pdrCreate) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "PDRNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppdr_LG_CreateSelectListSearch"
            Cmd.CommandText = "sppdrCreateSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppdr_LG_CreateSelectListFilteres"
            Cmd.CommandText = "sppdrCreateSelectListFilteres"
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
          _RecordCount = -1
          Results = New List(Of SIS.PDR.pdrCreate)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PDR.pdrCreate(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_PDRNo"), TextBox).Text = ""
        CType(.FindControl("F_PDRDate"), TextBox).Text = ""
        CType(.FindControl("F_SeverityOfDefectID"),Object).SelectedValue = ""
        CType(.FindControl("F_CategoryOfDefectID"),Object).SelectedValue = ""
        CType(.FindControl("F_ProjectID"), TextBox).Text = ""
        CType(.FindControl("F_ProjectID_Display"), Label).Text = ""
        CType(.FindControl("F_ElementID"), TextBox).Text = ""
        CType(.FindControl("F_ElementID_Display"), Label).Text = ""
        CType(.FindControl("F_DocumentID"), TextBox).Text = ""
        CType(.FindControl("F_DocumentRev"), TextBox).Text = ""
        CType(.FindControl("F_DefectDescription"), TextBox).Text = ""
        CType(.FindControl("F_AnnexurePath"), TextBox).Text = ""
        CType(.FindControl("F_CostImpact"), TextBox).Text = 0
        CType(.FindControl("F_CostImpactDebitableTo"),Object).SelectedValue = ""
        CType(.FindControl("F_TimeImpact"), TextBox).Text = 0
        CType(.FindControl("F_SolutionToBeGivenBy"), TextBox).Text = ""
        CType(.FindControl("F_SolutionToBeGivenByUsers"), TextBox).Text = ""
        CType(.FindControl("F_ProposedSolution"), TextBox).Text = ""
        CType(.FindControl("F_SolutionGivenOn"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
