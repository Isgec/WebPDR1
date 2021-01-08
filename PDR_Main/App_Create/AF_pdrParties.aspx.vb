Partial Class AF_pdrParties
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpdrParties_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpdrParties.Init
    DataClassName = "ApdrParties"
    SetFormView = FVpdrParties
  End Sub
  Protected Sub TBLpdrParties_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpdrParties.Init
    SetToolBar = TBLpdrParties
  End Sub
  Protected Sub FVpdrParties_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpdrParties.DataBound
    SIS.PDR.pdrParties.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpdrParties_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpdrParties.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PDR_Main/App_Create") & "/AF_pdrParties.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpdrParties") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpdrParties", mStr)
    End If
    If Request.QueryString("PartyID") IsNot Nothing Then
      CType(FVpdrParties.FindControl("F_PartyID"), TextBox).Text = Request.QueryString("PartyID")
      CType(FVpdrParties.FindControl("F_PartyID"), TextBox).Enabled = False
    End If
  End Sub

End Class
