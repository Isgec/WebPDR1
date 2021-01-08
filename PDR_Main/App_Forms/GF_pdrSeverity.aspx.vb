Imports System.Web.Script.Serialization
Partial Class GF_pdrSeverity
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PDR_Main/App_Display/DF_pdrSeverity.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SeverityID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpdrSeverity_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpdrSeverity.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SeverityID As Int32 = GVpdrSeverity.DataKeys(e.CommandArgument).Values("SeverityID")  
        Dim RedirectUrl As String = TBLpdrSeverity.EditUrl & "?SeverityID=" & SeverityID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpdrSeverity_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpdrSeverity.Init
    DataClassName = "GpdrSeverity"
    SetGridView = GVpdrSeverity
  End Sub
  Protected Sub TBLpdrSeverity_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpdrSeverity.Init
    SetToolBar = TBLpdrSeverity
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
