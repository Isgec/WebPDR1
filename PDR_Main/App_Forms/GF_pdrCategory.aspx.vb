Imports System.Web.Script.Serialization
Partial Class GF_pdrCategory
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PDR_Main/App_Display/DF_pdrCategory.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?CategoryID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpdrCategory_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpdrCategory.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim CategoryID As Int32 = GVpdrCategory.DataKeys(e.CommandArgument).Values("CategoryID")  
        Dim RedirectUrl As String = TBLpdrCategory.EditUrl & "?CategoryID=" & CategoryID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpdrCategory_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpdrCategory.Init
    DataClassName = "GpdrCategory"
    SetGridView = GVpdrCategory
  End Sub
  Protected Sub TBLpdrCategory_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpdrCategory.Init
    SetToolBar = TBLpdrCategory
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
