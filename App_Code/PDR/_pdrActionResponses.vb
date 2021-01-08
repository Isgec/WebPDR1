Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PDR
  <DataObject()> _
  Partial Public Class pdrActionResponses
    Private Shared _RecordCount As Integer
    Public Property PDRNo As Int32 = 0
    Public Property ActionNo As Int32 = 0
    Public Property ResponseNo As Int32 = 0
    Public Property ResponseDescription As String = ""
    Public Property RespondedBy As String = ""
    Private _RespondedOn As String = ""
    Public Property StatusID As Int32 = 0
    Public Property aspnet_Users1_UserFullName As String = ""
    Public Property PDR_Actions2_Responsible As String = ""
    Public Property PDR_Defects3_AnnexurePath As String = ""
    Private _FK_PDR_ActionResponses_RespondedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_PDR_ActionResponses_ActionNo As SIS.PDR.pdrActionPlan = Nothing
    Private _FK_PDR_ActionResponses_PDRNo As SIS.PDR.pdrCreate = Nothing
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
    Public Property RespondedOn() As String
      Get
        If Not _RespondedOn = String.Empty Then
          Return Convert.ToDateTime(_RespondedOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _RespondedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _RespondedOn = ""
         Else
           _RespondedOn = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _PDRNo & "|" & _ActionNo & "|" & _ResponseNo
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
    Public Class PKpdrActionResponses
      Private _PDRNo As Int32 = 0
      Private _ActionNo As Int32 = 0
      Private _ResponseNo As Int32 = 0
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
      Public Property ResponseNo() As Int32
        Get
          Return _ResponseNo
        End Get
        Set(ByVal value As Int32)
          _ResponseNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PDR_ActionResponses_RespondedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_PDR_ActionResponses_RespondedBy Is Nothing Then
          _FK_PDR_ActionResponses_RespondedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_RespondedBy)
        End If
        Return _FK_PDR_ActionResponses_RespondedBy
      End Get
    End Property
    Public ReadOnly Property FK_PDR_ActionResponses_ActionNo() As SIS.PDR.pdrActionPlan
      Get
        If _FK_PDR_ActionResponses_ActionNo Is Nothing Then
          _FK_PDR_ActionResponses_ActionNo = SIS.PDR.pdrActionPlan.pdrActionPlanGetByID(_PDRNo, _ActionNo)
        End If
        Return _FK_PDR_ActionResponses_ActionNo
      End Get
    End Property
    Public ReadOnly Property FK_PDR_ActionResponses_PDRNo() As SIS.PDR.pdrCreate
      Get
        If _FK_PDR_ActionResponses_PDRNo Is Nothing Then
          _FK_PDR_ActionResponses_PDRNo = SIS.PDR.pdrCreate.pdrCreateGetByID(_PDRNo)
        End If
        Return _FK_PDR_ActionResponses_PDRNo
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pdrActionResponsesGetNewRecord() As SIS.PDR.pdrActionResponses
      Return New SIS.PDR.pdrActionResponses()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pdrActionResponsesGetByID(ByVal PDRNo As Int32, ByVal ActionNo As Int32, ByVal ResponseNo As Int32) As SIS.PDR.pdrActionResponses
      Dim Results As SIS.PDR.pdrActionResponses = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppdrActionResponsesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PDRNo",SqlDbType.Int,PDRNo.ToString.Length, PDRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActionNo",SqlDbType.Int,ActionNo.ToString.Length, ActionNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ResponseNo",SqlDbType.Int,ResponseNo.ToString.Length, ResponseNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PDR.pdrActionResponses(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pdrActionResponsesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PDRNo As Int32, ByVal ActionNo As Int32) As List(Of SIS.PDR.pdrActionResponses)
      Dim Results As List(Of SIS.PDR.pdrActionResponses) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ResponseNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppdrActionResponsesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppdrActionResponsesSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PDRNo",SqlDbType.Int,10, IIf(PDRNo = Nothing, 0,PDRNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ActionNo",SqlDbType.Int,10, IIf(ActionNo = Nothing, 0,ActionNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PDR.pdrActionResponses)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PDR.pdrActionResponses(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pdrActionResponsesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PDRNo As Int32, ByVal ActionNo As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pdrActionResponsesGetByID(ByVal PDRNo As Int32, ByVal ActionNo As Int32, ByVal ResponseNo As Int32, ByVal Filter_PDRNo As Int32, ByVal Filter_ActionNo As Int32) As SIS.PDR.pdrActionResponses
      Return pdrActionResponsesGetByID(PDRNo, ActionNo, ResponseNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pdrActionResponsesInsert(ByVal Record As SIS.PDR.pdrActionResponses) As SIS.PDR.pdrActionResponses
      Dim _Rec As SIS.PDR.pdrActionResponses = SIS.PDR.pdrActionResponses.pdrActionResponsesGetNewRecord()
      With _Rec
        .PDRNo = Record.PDRNo
        .ActionNo = Record.ActionNo
        .ResponseDescription = Record.ResponseDescription
        .RespondedBy =  Global.System.Web.HttpContext.Current.Session("LoginID")
        .RespondedOn = Now
        .StatusID = enumResponse.Free
      End With
      Return SIS.PDR.pdrActionResponses.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PDR.pdrActionResponses) As SIS.PDR.pdrActionResponses
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppdrActionResponsesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PDRNo",SqlDbType.Int,11, Record.PDRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActionNo",SqlDbType.Int,11, Record.ActionNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ResponseDescription",SqlDbType.NVarChar,1001, Iif(Record.ResponseDescription= "" ,Convert.DBNull, Record.ResponseDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RespondedBy",SqlDbType.NVarChar,9, Iif(Record.RespondedBy= "" ,Convert.DBNull, Record.RespondedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RespondedOn",SqlDbType.DateTime,21, Iif(Record.RespondedOn= "" ,Convert.DBNull, Record.RespondedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Record.StatusID)
          Cmd.Parameters.Add("@Return_PDRNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_PDRNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_ActionNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ActionNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_ResponseNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ResponseNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.PDRNo = Cmd.Parameters("@Return_PDRNo").Value
          Record.ActionNo = Cmd.Parameters("@Return_ActionNo").Value
          Record.ResponseNo = Cmd.Parameters("@Return_ResponseNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pdrActionResponsesUpdate(ByVal Record As SIS.PDR.pdrActionResponses) As SIS.PDR.pdrActionResponses
      Dim _Rec As SIS.PDR.pdrActionResponses = SIS.PDR.pdrActionResponses.pdrActionResponsesGetByID(Record.PDRNo, Record.ActionNo, Record.ResponseNo)
      With _Rec
        .ResponseDescription = Record.ResponseDescription
        .RespondedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .RespondedOn = Now
        .StatusID = Record.StatusID
      End With
      Return SIS.PDR.pdrActionResponses.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PDR.pdrActionResponses) As SIS.PDR.pdrActionResponses
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppdrActionResponsesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_PDRNo",SqlDbType.Int,11, Record.PDRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ActionNo",SqlDbType.Int,11, Record.ActionNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ResponseNo",SqlDbType.Int,11, Record.ResponseNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PDRNo",SqlDbType.Int,11, Record.PDRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActionNo",SqlDbType.Int,11, Record.ActionNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ResponseDescription",SqlDbType.NVarChar,1001, Iif(Record.ResponseDescription= "" ,Convert.DBNull, Record.ResponseDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RespondedBy",SqlDbType.NVarChar,9, Iif(Record.RespondedBy= "" ,Convert.DBNull, Record.RespondedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RespondedOn",SqlDbType.DateTime,21, Iif(Record.RespondedOn= "" ,Convert.DBNull, Record.RespondedOn))
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
    Public Shared Function pdrActionResponsesDelete(ByVal Record As SIS.PDR.pdrActionResponses) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppdrActionResponsesDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_PDRNo",SqlDbType.Int,Record.PDRNo.ToString.Length, Record.PDRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ActionNo",SqlDbType.Int,Record.ActionNo.ToString.Length, Record.ActionNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ResponseNo",SqlDbType.Int,Record.ResponseNo.ToString.Length, Record.ResponseNo)
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
    Public Sub New(ByVal Reader As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
