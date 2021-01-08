Imports System.Web.Script.Serialization
Partial Class EF_pdrSeverity
  Inherits SIS.SYS.UpdateBase
  Public Property Editable() As Boolean
    Get
      If ViewState("Editable") IsNot Nothing Then
        Return CType(ViewState("Editable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Editable", value)
    End Set
  End Property
  Public Property Deleteable() As Boolean
    Get
      If ViewState("Deleteable") IsNot Nothing Then
        Return CType(ViewState("Deleteable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Deleteable", value)
    End Set
  End Property
  Public Property PrimaryKey() As String
    Get
      If ViewState("PrimaryKey") IsNot Nothing Then
        Return CType(ViewState("PrimaryKey"), String)
      End If
      Return True
    End Get
    Set(ByVal value As String)
      ViewState.Add("PrimaryKey", value)
    End Set
  End Property
  Protected Sub ODSpdrSeverity_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpdrSeverity.Selected
    Dim tmp As SIS.PDR.pdrSeverity = CType(e.ReturnValue, SIS.PDR.pdrSeverity)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpdrSeverity_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpdrSeverity.Init
    DataClassName = "EpdrSeverity"
    SetFormView = FVpdrSeverity
  End Sub
  Protected Sub TBLpdrSeverity_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpdrSeverity.Init
    SetToolBar = TBLpdrSeverity
  End Sub
  Protected Sub FVpdrSeverity_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpdrSeverity.PreRender
    TBLpdrSeverity.EnableSave = Editable
    TBLpdrSeverity.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PDR_Main/App_Edit") & "/EF_pdrSeverity.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpdrSeverity") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpdrSeverity", mStr)
    End If
  End Sub

End Class
