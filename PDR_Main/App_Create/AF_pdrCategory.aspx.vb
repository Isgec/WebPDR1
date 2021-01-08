Partial Class AF_pdrCategory
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpdrCategory_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpdrCategory.Init
    DataClassName = "ApdrCategory"
    SetFormView = FVpdrCategory
  End Sub
  Protected Sub TBLpdrCategory_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpdrCategory.Init
    SetToolBar = TBLpdrCategory
  End Sub
  Protected Sub FVpdrCategory_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpdrCategory.DataBound
    SIS.PDR.pdrCategory.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpdrCategory_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpdrCategory.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PDR_Main/App_Create") & "/AF_pdrCategory.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpdrCategory") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpdrCategory", mStr)
    End If
    If Request.QueryString("CategoryID") IsNot Nothing Then
      CType(FVpdrCategory.FindControl("F_CategoryID"), TextBox).Text = Request.QueryString("CategoryID")
      CType(FVpdrCategory.FindControl("F_CategoryID"), TextBox).Enabled = False
    End If
  End Sub

End Class
