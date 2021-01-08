Imports System.Web.Script.Serialization
Partial Class EF_pdrActionResponses
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
  Protected Sub ODSpdrActionResponses_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpdrActionResponses.Selected
    Dim tmp As SIS.PDR.pdrActionResponses = CType(e.ReturnValue, SIS.PDR.pdrActionResponses)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpdrActionResponses_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpdrActionResponses.Init
    DataClassName = "EpdrActionResponses"
    SetFormView = FVpdrActionResponses
  End Sub
  Protected Sub TBLpdrActionResponses_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpdrActionResponses.Init
    SetToolBar = TBLpdrActionResponses
  End Sub
  Protected Sub FVpdrActionResponses_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpdrActionResponses.PreRender
    TBLpdrActionResponses.EnableSave = Editable
    TBLpdrActionResponses.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PDR_Main/App_Edit") & "/EF_pdrActionResponses.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpdrActionResponses") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpdrActionResponses", mStr)
    End If
  End Sub

End Class
