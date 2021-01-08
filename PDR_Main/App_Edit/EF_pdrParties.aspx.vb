Imports System.Web.Script.Serialization
Partial Class EF_pdrParties
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
  Protected Sub ODSpdrParties_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpdrParties.Selected
    Dim tmp As SIS.PDR.pdrParties = CType(e.ReturnValue, SIS.PDR.pdrParties)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpdrParties_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpdrParties.Init
    DataClassName = "EpdrParties"
    SetFormView = FVpdrParties
  End Sub
  Protected Sub TBLpdrParties_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpdrParties.Init
    SetToolBar = TBLpdrParties
  End Sub
  Protected Sub FVpdrParties_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpdrParties.PreRender
    TBLpdrParties.EnableSave = Editable
    TBLpdrParties.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PDR_Main/App_Edit") & "/EF_pdrParties.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpdrParties") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpdrParties", mStr)
    End If
  End Sub

End Class
