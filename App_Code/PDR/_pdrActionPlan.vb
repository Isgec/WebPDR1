Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PDR
  <DataObject()> _
  Partial Public Class pdrActionPlan
    Private Shared _RecordCount As Integer
    Public Property PDRNo As Int32 = 0
    Public Property ActionNo As Int32 = 0
    Public Property ActionDescription As String = ""
    Public Property Responsible As String = ""
    Public Property ResponsibleUsers As String = ""
    Public Property Remarks As String = ""
    Public Property StatusID As Int32 = 0
    Public Property PDR_Defects1_AnnexurePath As String = ""
    Public Property aspnet_Users2_UserFullName As String = ""
    Private _FK_PDR_Actions_PDRNo As SIS.PDR.pdrCreate = Nothing
    Private _FK_PDR_Actions_Responsible As SIS.QCM.qcmUsers = Nothing
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
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _Responsible.ToString.PadRight(8, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _PDRNo & "|" & _ActionNo
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
    Public Class PKpdrActionPlan
      Private _PDRNo As Int32 = 0
      Private _ActionNo As Int32 = 0
      Public Property PDRNo() As Int32
        Get
          Return _PDRNo
        End Get
        Set(ByVal value As Int32)
          _PDRNo = value
        End Set
      End Property
      Public Property ActionNo() As Int32
        Get
          Return _ActionNo
        End Get
        Set(ByVal value As Int32)
          _ActionNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PDR_Actions_PDRNo() As SIS.PDR.pdrCreate
      Get
        If _FK_PDR_Actions_PDRNo Is Nothing Then
          _FK_PDR_Actions_PDRNo = SIS.PDR.pdrCreate.pdrCreateGetByID(_PDRNo)
        End If
        Return _FK_PDR_Actions_PDRNo
      End Get
    End Property
    Public ReadOnly Property FK_PDR_Actions_Responsible() As SIS.QCM.qcmUsers
      Get
        If _FK_PDR_Actions_Responsible Is Nothing Then
          _FK_PDR_Actions_Responsible = SIS.QCM.qcmUsers.qcmUsersGetByID(_Responsible)
        End If
        Return _FK_PDR_Actions_Responsible
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pdrActionPlanSelectList(ByVal OrderBy As String) As List(Of SIS.PDR.pdrActionPlan)
      Dim Results As List(Of SIS.PDR.pdrActionPlan) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ActionNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppdrActionPlanSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PDR.pdrActionPlan)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PDR.pdrActionPlan(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pdrActionPlanGetNewRecord() As SIS.PDR.pdrActionPlan
      Return New SIS.PDR.pdrActionPlan()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pdrActionPlanGetByID(ByVal PDRNo As Int32, ByVal ActionNo As Int32) As SIS.PDR.pdrActionPlan
      Dim Results As SIS.PDR.pdrActionPlan = Nothing
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
            Results = New SIS.PDR.pdrActionPlan(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pdrActionPlanSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PDRNo As Int32) As List(Of SIS.PDR.pdrActionPlan)
      Dim Results As List(Of SIS.PDR.pdrActionPlan) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ActionNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppdrActionPlanSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppdrActionPlanSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PDRNo",SqlDbType.Int,10, IIf(PDRNo = Nothing, 0,PDRNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PDR.pdrActionPlan)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PDR.pdrActionPlan(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pdrActionPlanSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PDRNo As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pdrActionPlanGetByID(ByVal PDRNo As Int32, ByVal ActionNo As Int32, ByVal Filter_PDRNo As Int32) As SIS.PDR.pdrActionPlan
      Return pdrActionPlanGetByID(PDRNo, ActionNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pdrActionPlanInsert(ByVal Record As SIS.PDR.pdrActionPlan) As SIS.PDR.pdrActionPlan
      Dim _Rec As SIS.PDR.pdrActionPlan = SIS.PDR.pdrActionPlan.pdrActionPlanGetNewRecord()
      With _Rec
        .PDRNo = Record.PDRNo
        .ActionDescription = Record.ActionDescription
        .Responsible = Record.Responsible
        .ResponsibleUsers = Record.ResponsibleUsers
        .Remarks = Record.Remarks
        .StatusID = enumPdr.Free
      End With
      Return SIS.PDR.pdrActionPlan.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PDR.pdrActionPlan) As SIS.PDR.pdrActionPlan
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppdrActionPlanInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PDRNo",SqlDbType.Int,11, Record.PDRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActionDescription",SqlDbType.NVarChar,1001, Iif(Record.ActionDescription= "" ,Convert.DBNull, Record.ActionDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Responsible",SqlDbType.NVarChar,9, Iif(Record.Responsible= "" ,Convert.DBNull, Record.Responsible))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ResponsibleUsers",SqlDbType.NVarChar,251, Iif(Record.ResponsibleUsers= "" ,Convert.DBNull, Record.ResponsibleUsers))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,501, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Record.StatusID)
          Cmd.Parameters.Add("@Return_PDRNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_PDRNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_ActionNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ActionNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.PDRNo = Cmd.Parameters("@Return_PDRNo").Value
          Record.ActionNo = Cmd.Parameters("@Return_ActionNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pdrActionPlanUpdate(ByVal Record As SIS.PDR.pdrActionPlan) As SIS.PDR.pdrActionPlan
      Dim _Rec As SIS.PDR.pdrActionPlan = SIS.PDR.pdrActionPlan.pdrActionPlanGetByID(Record.PDRNo, Record.ActionNo)
      With _Rec
        .ActionDescription = Record.ActionDescription
        .Responsible = Record.Responsible
        .ResponsibleUsers = Record.ResponsibleUsers
        .Remarks = Record.Remarks
        .StatusID = Record.StatusID
      End With
      Return SIS.PDR.pdrActionPlan.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PDR.pdrActionPlan) As SIS.PDR.pdrActionPlan
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppdrActionPlanUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_PDRNo",SqlDbType.Int,11, Record.PDRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ActionNo",SqlDbType.Int,11, Record.ActionNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PDRNo",SqlDbType.Int,11, Record.PDRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActionDescription",SqlDbType.NVarChar,1001, Iif(Record.ActionDescription= "" ,Convert.DBNull, Record.ActionDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Responsible",SqlDbType.NVarChar,9, Iif(Record.Responsible= "" ,Convert.DBNull, Record.Responsible))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ResponsibleUsers",SqlDbType.NVarChar,251, Iif(Record.ResponsibleUsers= "" ,Convert.DBNull, Record.ResponsibleUsers))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,501, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Record.StatusID)
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
    Public Shared Function pdrActionPlanDelete(ByVal Record As SIS.PDR.pdrActionPlan) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppdrActionPlanDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_PDRNo",SqlDbType.Int,Record.PDRNo.ToString.Length, Record.PDRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ActionNo",SqlDbType.Int,Record.ActionNo.ToString.Length, Record.ActionNo)
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
    Public Shared Function SelectpdrActionPlanAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppdrActionPlanAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(8, " "),"" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.PDR.pdrActionPlan = New SIS.PDR.pdrActionPlan(Reader)
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
