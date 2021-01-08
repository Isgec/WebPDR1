Partial Class AF_pdrSeverity
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpdrSeverity_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpdrSeverity.Init
    DataClassName = "ApdrSeverity"
    SetFormView = FVpdrSeverity
  End Sub
  Protected Sub TBLpdrSeverity_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpdrSeverity.Init
    SetToolBar = TBLpdrSeverity
  End Sub
  Protected Sub FVpdrSeverity_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpdrSeverity.DataBound
    SIS.PDR.pdrSeverity.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpdrSeverity_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpdrSeverity.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PDR_Main/App_Create") & "/AF_pdrSeverity.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpdrSeverity") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpdrSeverity", mStr)
    End If
    If Request.QueryString("SeverityID") IsNot Nothing Then
      CType(FVpdrSeverity.FindControl("F_SeverityID"), TextBox).Text = Request.QueryString("SeverityID")
      CType(FVpdrSeverity.FindControl("F_SeverityID"), TextBox).Enabled = False
    End If
  End Sub

End Class
