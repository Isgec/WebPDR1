Imports System.Web.Script.Serialization
Partial Class GF_pdrParties
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PDR_Main/App_Display/DF_pdrParties.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?PartyID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpdrParties_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpdrParties.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim PartyID As Int32 = GVpdrParties.DataKeys(e.CommandArgument).Values("PartyID")  
        Dim RedirectUrl As String = TBLpdrParties.EditUrl & "?PartyID=" & PartyID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpdrParties_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpdrParties.Init
    DataClassName = "GpdrParties"
    SetGridView = GVpdrParties
  End Sub
  Protected Sub TBLpdrParties_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpdrParties.Init
    SetToolBar = TBLpdrParties
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
