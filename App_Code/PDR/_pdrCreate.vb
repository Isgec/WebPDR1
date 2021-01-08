Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PDR
  <DataObject()> _
  Partial Public Class pdrCreate
    Private Shared _RecordCount As Integer
    Public Property PDRNo As Int32 = 0
    Private _PDRDate As String = ""
    Public Property SeverityOfDefectID As Int32 = 0
    Public Property CategoryOfDefectID As Int32 = 0
    Public Property ProjectID As String = ""
    Public Property ElementID As String = ""
    Public Property DocumentID As String = ""
    Public Property DocumentRev As String = ""
    Public Property DefectDescription As String = ""
    Public Property AnnexurePath As String = ""
    Public Property CostImpact As String = "0.00"
    Public Property CostImpactDebitableTo As String = ""
    Public Property TimeImpact As String = "0.00"
    Public Property SolutionToBeGivenBy As String = ""
    Public Property SolutionToBeGivenByUsers As String = ""
    Public Property ProposedSolution As String = ""
    Private _SolutionGivenOn As String = ""
    Public Property CreatedBy As String = ""
    Private _CreatedOn As String = ""
    Public Property StatusID As Int32 = 0
    Public Property aspnet_Users1_UserFullName As String = ""
    Public Property IDM_Projects2_Description As String = ""
    Public Property IDM_WBS3_Description As String = ""
    Public Property PDR_Category4_CategoryDescription As String = ""
    Public Property PDR_Parties5_Description As String = ""
    Public Property PDR_severity6_SeverityDescription As String = ""
    Private _FK_PDR_Defects_CreatedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_PDR_Defects_ProjectID As SIS.QCM.qcmProjects = Nothing
    Private _FK_PDR_Defects_ElementID As SIS.PAK.pakWBS = Nothing
    Private _FK_PDR_Defects_Category As SIS.PDR.pdrCategory = Nothing
    Private _FK_PDR_Defects_DebitableTo As SIS.PDR.pdrParties = Nothing
    Private _FK_PDR_Defects_Severity As SIS.PDR.pdrSeverity = Nothing
    Public ReadOnly Property ForeColor() As System.Drawing.Color
      Get
        Dim mRet As System.Drawing.Color = Drawing.Color.Blue
        Try
          mRet = GetColor()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Visible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Enable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Property PDRDate() As String
      Get
        If Not _PDRDate = String.Empty Then
          Return Convert.ToDateTime(_PDRDate).ToString("dd/MM/yyyy")
        End If
        Return _PDRDate
      End Get
      Set(ByVal value As String)
        _PDRDate = value
      End Set
    End Property
    Public Property SolutionGivenOn() As String
      Get
        If Not _SolutionGivenOn = String.Empty Then
          Return Convert.ToDateTime(_SolutionGivenOn).ToString("dd/MM/yyyy")
        End If
        Return _SolutionGivenOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _SolutionGivenOn = ""
        Else
          _SolutionGivenOn = value
        End If
      End Set
    End Property
    Public Property CreatedOn() As String
      Get
        If Not _CreatedOn = String.Empty Then
          Return Convert.ToDateTime(_CreatedOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _CreatedOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _CreatedOn = ""
        Else
          _CreatedOn = value
        End If
      End Set
    End Property
    Public ReadOnly Property DisplayField() As String
      Get
        Return "" & _AnnexurePath.ToString.PadRight(100, " ")
      End Get
    End Property
    Public ReadOnly Property PrimaryKey() As String
      Get
        Return _PDRNo
      End Get
    End Property
    Public Shared Property RecordCount() As Integer
      Get
        Return _RecordCount
      End Get
      Set(ByVal value As Integer)
        _RecordCount = value
      End Set
    End Property
    Public Class PKpdrCreate
      Private _PDRNo As Int32 = 0
      Public Property PDRNo() As Int32
        Get
          Return _PDRNo
        End Get
        Set(ByVal value As Int32)
          _PDRNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PDR_Defects_CreatedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_PDR_Defects_CreatedBy Is Nothing Then
          _FK_PDR_Defects_CreatedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_CreatedBy)
        End If
        Return _FK_PDR_Defects_CreatedBy
      End Get
    End Property
    Public ReadOnly Property FK_PDR_Defects_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_PDR_Defects_ProjectID Is Nothing Then
          _FK_PDR_Defects_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_PDR_Defects_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_PDR_Defects_ElementID() As SIS.PAK.pakWBS
      Get
        If _FK_PDR_Defects_ElementID Is Nothing Then
          _FK_PDR_Defects_ElementID = SIS.PAK.pakWBS.pakWBSGetByID(_ElementID)
        End If
        Return _FK_PDR_Defects_ElementID
      End Get
    End Property
    Public ReadOnly Property FK_PDR_Defects_Category() As SIS.PDR.pdrCategory
      Get
        If _FK_PDR_Defects_Category Is Nothing Then
          _FK_PDR_Defects_Category = SIS.PDR.pdrCategory.pdrCategoryGetByID(_CategoryOfDefectID)
        End If
        Return _FK_PDR_Defects_Category
      End Get
    End Property
    Public ReadOnly Property FK_PDR_Defects_DebitableTo() As SIS.PDR.pdrParties
      Get
        If _FK_PDR_Defects_DebitableTo Is Nothing Then
          _FK_PDR_Defects_DebitableTo = SIS.PDR.pdrParties.pdrPartiesGetByID(_CostImpactDebitableTo)
        End If
        Return _FK_PDR_Defects_DebitableTo
      End Get
    End Property
    Public ReadOnly Property FK_PDR_Defects_Severity() As SIS.PDR.pdrSeverity
      Get
        If _FK_PDR_Defects_Severity Is Nothing Then
          _FK_PDR_Defects_Severity = SIS.PDR.pdrSeverity.pdrSeverityGetByID(_SeverityOfDefectID)
        End If
        Return _FK_PDR_Defects_Severity
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function pdrCreateSelectList(ByVal OrderBy As String) As List(Of SIS.PDR.pdrCreate)
      Dim Results As List(Of SIS.PDR.pdrCreate) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "PDRNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppdrCreateSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
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
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function pdrCreateGetNewRecord() As SIS.PDR.pdrCreate
      Return New SIS.PDR.pdrCreate()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function pdrCreateGetByID(ByVal PDRNo As Int32) As SIS.PDR.pdrCreate
      Dim Results As SIS.PDR.pdrCreate = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppdrCreateSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PDRNo", SqlDbType.Int, PDRNo.ToString.Length, PDRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PDR.pdrCreate(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function pdrCreateSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PDRNo As Int32, ByVal SeverityOfDefectID As Int32, ByVal CategoryOfDefectID As Int32, ByVal ProjectID As String, ByVal ElementID As String, ByVal DocumentID As String, ByVal CreatedBy As String, ByVal StatusID As Int32) As List(Of SIS.PDR.pdrCreate)
      Dim Results As List(Of SIS.PDR.pdrCreate) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "PDRNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppdrCreateSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppdrCreateSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PDRNo", SqlDbType.Int, 10, IIf(PDRNo = Nothing, 0, PDRNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SeverityOfDefectID", SqlDbType.Int, 10, IIf(SeverityOfDefectID = Nothing, 0, SeverityOfDefectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CategoryOfDefectID", SqlDbType.Int, 10, IIf(CategoryOfDefectID = Nothing, 0, CategoryOfDefectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID", SqlDbType.NVarChar, 6, IIf(ProjectID Is Nothing, String.Empty, ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ElementID", SqlDbType.NVarChar, 8, IIf(ElementID Is Nothing, String.Empty, ElementID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DocumentID", SqlDbType.NVarChar, 50, IIf(DocumentID Is Nothing, String.Empty, DocumentID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CreatedBy", SqlDbType.NVarChar, 8, IIf(CreatedBy Is Nothing, String.Empty, CreatedBy))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusID", SqlDbType.Int, 10, IIf(StatusID = Nothing, 0, StatusID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
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
    Public Shared Function pdrCreateSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PDRNo As Int32, ByVal SeverityOfDefectID As Int32, ByVal CategoryOfDefectID As Int32, ByVal ProjectID As String, ByVal ElementID As String, ByVal DocumentID As String, ByVal CreatedBy As String, ByVal StatusID As Int32) As Integer
      Return _RecordCount
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function pdrCreateGetByID(ByVal PDRNo As Int32, ByVal Filter_PDRNo As Int32, ByVal Filter_SeverityOfDefectID As Int32, ByVal Filter_CategoryOfDefectID As Int32, ByVal Filter_ProjectID As String, ByVal Filter_ElementID As String, ByVal Filter_DocumentID As String, ByVal Filter_CreatedBy As String, ByVal Filter_StatusID As Int32) As SIS.PDR.pdrCreate
      Return pdrCreateGetByID(PDRNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)>
    Public Shared Function pdrCreateInsert(ByVal Record As SIS.PDR.pdrCreate) As SIS.PDR.pdrCreate
      Dim _Rec As SIS.PDR.pdrCreate = SIS.PDR.pdrCreate.pdrCreateGetNewRecord()
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
        .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
        .StatusID = enumPdr.Free
      End With
      Return SIS.PDR.pdrCreate.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PDR.pdrCreate) As SIS.PDR.pdrCreate
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppdrCreateInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PDRDate", SqlDbType.DateTime, 21, Record.PDRDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SeverityOfDefectID", SqlDbType.Int, 11, Record.SeverityOfDefectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryOfDefectID", SqlDbType.Int, 11, Record.CategoryOfDefectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID", SqlDbType.NVarChar, 9, Record.ElementID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentID", SqlDbType.NVarChar, 51, IIf(Record.DocumentID = "", Convert.DBNull, Record.DocumentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentRev", SqlDbType.NVarChar, 11, IIf(Record.DocumentRev = "", Convert.DBNull, Record.DocumentRev))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DefectDescription", SqlDbType.NVarChar, 1001, IIf(Record.DefectDescription = "", Convert.DBNull, Record.DefectDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AnnexurePath", SqlDbType.NVarChar, 101, IIf(Record.AnnexurePath = "", Convert.DBNull, Record.AnnexurePath))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostImpact", SqlDbType.Decimal, 17, Record.CostImpact)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostImpactDebitableTo", SqlDbType.Int, 11, IIf(Record.CostImpactDebitableTo = "", Convert.DBNull, Record.CostImpactDebitableTo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TimeImpact", SqlDbType.Decimal, 17, Record.TimeImpact)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SolutionToBeGivenBy", SqlDbType.NVarChar, 251, IIf(Record.SolutionToBeGivenBy = "", Convert.DBNull, Record.SolutionToBeGivenBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SolutionToBeGivenByUsers", SqlDbType.NVarChar, 251, IIf(Record.SolutionToBeGivenByUsers = "", Convert.DBNull, Record.SolutionToBeGivenByUsers))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProposedSolution", SqlDbType.NVarChar, 1001, IIf(Record.ProposedSolution = "", Convert.DBNull, Record.ProposedSolution))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SolutionGivenOn", SqlDbType.DateTime, 21, IIf(Record.SolutionGivenOn = "", Convert.DBNull, Record.SolutionGivenOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy", SqlDbType.NVarChar, 9, IIf(Record.CreatedBy = "", Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn", SqlDbType.DateTime, 21, IIf(Record.CreatedOn = "", Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID", SqlDbType.Int, 11, Record.StatusID)
          Cmd.Parameters.Add("@Return_PDRNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_PDRNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.PDRNo = Cmd.Parameters("@Return_PDRNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)>
    Public Shared Function pdrCreateUpdate(ByVal Record As SIS.PDR.pdrCreate) As SIS.PDR.pdrCreate
      Dim _Rec As SIS.PDR.pdrCreate = SIS.PDR.pdrCreate.pdrCreateGetByID(Record.PDRNo)
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
        .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
        .StatusID = Record.StatusID
      End With
      Return SIS.PDR.pdrCreate.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PDR.pdrCreate) As SIS.PDR.pdrCreate
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppdrCreateUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_PDRNo", SqlDbType.Int, 11, Record.PDRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PDRDate", SqlDbType.DateTime, 21, Record.PDRDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SeverityOfDefectID", SqlDbType.Int, 11, Record.SeverityOfDefectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryOfDefectID", SqlDbType.Int, 11, Record.CategoryOfDefectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID", SqlDbType.NVarChar, 9, Record.ElementID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentID", SqlDbType.NVarChar, 51, IIf(Record.DocumentID = "", Convert.DBNull, Record.DocumentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentRev", SqlDbType.NVarChar, 11, IIf(Record.DocumentRev = "", Convert.DBNull, Record.DocumentRev))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DefectDescription", SqlDbType.NVarChar, 1001, IIf(Record.DefectDescription = "", Convert.DBNull, Record.DefectDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AnnexurePath", SqlDbType.NVarChar, 101, IIf(Record.AnnexurePath = "", Convert.DBNull, Record.AnnexurePath))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostImpact", SqlDbType.Decimal, 17, Record.CostImpact)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostImpactDebitableTo", SqlDbType.Int, 11, IIf(Record.CostImpactDebitableTo = "", Convert.DBNull, Record.CostImpactDebitableTo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TimeImpact", SqlDbType.Decimal, 17, Record.TimeImpact)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SolutionToBeGivenBy", SqlDbType.NVarChar, 251, IIf(Record.SolutionToBeGivenBy = "", Convert.DBNull, Record.SolutionToBeGivenBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SolutionToBeGivenByUsers", SqlDbType.NVarChar, 251, IIf(Record.SolutionToBeGivenByUsers = "", Convert.DBNull, Record.SolutionToBeGivenByUsers))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProposedSolution", SqlDbType.NVarChar, 1001, IIf(Record.ProposedSolution = "", Convert.DBNull, Record.ProposedSolution))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SolutionGivenOn", SqlDbType.DateTime, 21, IIf(Record.SolutionGivenOn = "", Convert.DBNull, Record.SolutionGivenOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy", SqlDbType.NVarChar, 9, IIf(Record.CreatedBy = "", Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn", SqlDbType.DateTime, 21, IIf(Record.CreatedOn = "", Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID", SqlDbType.Int, 11, Record.StatusID)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Shared Function pdrCreateDelete(ByVal Record As SIS.PDR.pdrCreate) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppdrCreateDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_PDRNo",SqlDbType.Int,Record.PDRNo.ToString.Length, Record.PDRNo)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _RecordCount
    End Function
'    Autocomplete Method
    Public Shared Function SelectpdrCreateAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppdrCreateAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(100, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.PDR.pdrCreate = New SIS.PDR.pdrCreate(Reader)
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results.ToArray
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
