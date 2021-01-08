Imports System.Web.Script.Serialization
Partial Class EF_pdrCategory
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
  Protected Sub ODSpdrCategory_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpdrCategory.Selected
    Dim tmp As SIS.PDR.pdrCategory = CType(e.ReturnValue, SIS.PDR.pdrCategory)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpdrCategory_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpdrCategory.Init
    DataClassName = "EpdrCategory"
    SetFormView = FVpdrCategory
  End Sub
  Protected Sub TBLpdrCategory_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpdrCategory.Init
    SetToolBar = TBLpdrCategory
  End Sub
  Protected Sub FVpdrCategory_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpdrCategory.PreRender
    TBLpdrCategory.EnableSave = Editable
    TBLpdrCategory.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PDR_Main/App_Edit") & "/EF_pdrCategory.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpdrCategory") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpdrCategory", mStr)
    End If
  End Sub

End Class
