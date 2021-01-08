Partial Class RP_pdrActionPlan
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/PDR_Main/App_Display/DF_pdrActionPlan.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?PDRNo=" & aVal(0) & "&ActionNo=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim PDRNo As Int32 = CType(aVal(0),Int32)
    Dim ActionNo As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PDR.pdrActionPlan = SIS.PDR.pdrActionPlan.pdrActionPlanGetByID(PDRNo,ActionNo)
    Dim oTblpdrActionPlan As New Table
    oTblpdrActionPlan.Width = 1000
    oTblpdrActionPlan.GridLines = GridLines.Both
    oTblpdrActionPlan.Style.Add("margin-top", "15px")
    oTblpdrActionPlan.Style.Add("margin-left", "10px")
    Dim oColpdrActionPlan As TableCell = Nothing
    Dim oRowpdrActionPlan As TableRow = Nothing
    oRowpdrActionPlan = New TableRow
    oColpdrActionPlan = New TableCell
    oColpdrActionPlan.Text = "Action No"
    oColpdrActionPlan.Font.Bold = True
    oRowpdrActionPlan.Cells.Add(oColpdrActionPlan)
    oColpdrActionPlan = New TableCell
    oColpdrActionPlan.Text = oVar.ActionNo
      oColpdrActionPlan.Style.Add("text-align","right")
    oColpdrActionPlan.ColumnSpan = "2"
    oRowpdrActionPlan.Cells.Add(oColpdrActionPlan)
    oColpdrActionPlan = New TableCell
    oColpdrActionPlan.Text = "Action Description"
    oColpdrActionPlan.Font.Bold = True
    oRowpdrActionPlan.Cells.Add(oColpdrActionPlan)
    oColpdrActionPlan = New TableCell
    oColpdrActionPlan.Text = oVar.ActionDescription
      oColpdrActionPlan.Style.Add("text-align","left")
    oColpdrActionPlan.ColumnSpan = "2"
    oRowpdrActionPlan.Cells.Add(oColpdrActionPlan)
    oTblpdrActionPlan.Rows.Add(oRowpdrActionPlan)
    form1.Controls.Add(oTblpdrActionPlan)
  End Sub
End Class
