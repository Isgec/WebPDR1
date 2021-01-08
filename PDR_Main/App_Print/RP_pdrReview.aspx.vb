Partial Class RP_pdrReview
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/PDR_Main/App_Display/DF_pdrReview.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?PDRNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim PDRNo As Int32 = CType(aVal(0),Int32)
    Dim oVar As SIS.PDR.pdrReview = SIS.PDR.pdrReview.pdrReviewGetByID(PDRNo)
    Dim oTblpdrReview As New Table
    oTblpdrReview.Width = 1000
    oTblpdrReview.GridLines = GridLines.Both
    oTblpdrReview.Style.Add("margin-top", "15px")
    oTblpdrReview.Style.Add("margin-left", "10px")
    Dim oColpdrReview As TableCell = Nothing
    Dim oRowpdrReview As TableRow = Nothing
    oRowpdrReview = New TableRow
    oColpdrReview = New TableCell
    oColpdrReview.Text = "PDR No"
    oColpdrReview.Font.Bold = True
    oRowpdrReview.Cells.Add(oColpdrReview)
    oColpdrReview = New TableCell
    oColpdrReview.Text = oVar.PDRNo
      oColpdrReview.Style.Add("text-align","right")
    oColpdrReview.ColumnSpan = "2"
    oRowpdrReview.Cells.Add(oColpdrReview)
    oColpdrReview = New TableCell
    oColpdrReview.Text = "PDR Date"
    oColpdrReview.Font.Bold = True
    oRowpdrReview.Cells.Add(oColpdrReview)
    oColpdrReview = New TableCell
    oColpdrReview.Text = oVar.PDRDate
      oColpdrReview.Style.Add("text-align","center")
    oColpdrReview.ColumnSpan = "2"
    oRowpdrReview.Cells.Add(oColpdrReview)
    oTblpdrReview.Rows.Add(oRowpdrReview)
    oRowpdrReview = New TableRow
    oColpdrReview = New TableCell
    oColpdrReview.Text = "Severity Of Defect"
    oColpdrReview.Font.Bold = True
    oRowpdrReview.Cells.Add(oColpdrReview)
    oColpdrReview = New TableCell
    oColpdrReview.Text = oVar.SeverityOfDefectID
      oColpdrReview.Style.Add("text-align","right")
    oRowpdrReview.Cells.Add(oColpdrReview)
    oColpdrReview = New TableCell
    oColpdrReview.Text = oVar.PDR_severity6_SeverityDescription
      oColpdrReview.Style.Add("text-align","right")
    oRowpdrReview.Cells.Add(oColpdrReview)
    oColpdrReview = New TableCell
    oColpdrReview.Text = "Category Of Defect"
    oColpdrReview.Font.Bold = True
    oRowpdrReview.Cells.Add(oColpdrReview)
    oColpdrReview = New TableCell
    oColpdrReview.Text = oVar.CategoryOfDefectID
      oColpdrReview.Style.Add("text-align","right")
    oRowpdrReview.Cells.Add(oColpdrReview)
    oColpdrReview = New TableCell
    oColpdrReview.Text = oVar.PDR_Category4_CategoryDescription
      oColpdrReview.Style.Add("text-align","right")
    oRowpdrReview.Cells.Add(oColpdrReview)
    oTblpdrReview.Rows.Add(oRowpdrReview)
    oRowpdrReview = New TableRow
    oColpdrReview = New TableCell
    oColpdrReview.Text = "Project"
    oColpdrReview.Font.Bold = True
    oRowpdrReview.Cells.Add(oColpdrReview)
    oColpdrReview = New TableCell
    oColpdrReview.Text = oVar.ProjectID
      oColpdrReview.Style.Add("text-align","left")
    oRowpdrReview.Cells.Add(oColpdrReview)
    oColpdrReview = New TableCell
    oColpdrReview.Text = oVar.IDM_Projects2_Description
      oColpdrReview.Style.Add("text-align","left")
    oRowpdrReview.Cells.Add(oColpdrReview)
    oColpdrReview = New TableCell
    oColpdrReview.Text = "Element"
    oColpdrReview.Font.Bold = True
    oRowpdrReview.Cells.Add(oColpdrReview)
    oColpdrReview = New TableCell
    oColpdrReview.Text = oVar.ElementID
      oColpdrReview.Style.Add("text-align","left")
    oRowpdrReview.Cells.Add(oColpdrReview)
    oColpdrReview = New TableCell
    oColpdrReview.Text = oVar.IDM_WBS3_Description
      oColpdrReview.Style.Add("text-align","left")
    oRowpdrReview.Cells.Add(oColpdrReview)
    oTblpdrReview.Rows.Add(oRowpdrReview)
    oRowpdrReview = New TableRow
    oColpdrReview = New TableCell
    oColpdrReview.Text = "Document ID"
    oColpdrReview.Font.Bold = True
    oRowpdrReview.Cells.Add(oColpdrReview)
    oColpdrReview = New TableCell
    oColpdrReview.Text = oVar.DocumentID
      oColpdrReview.Style.Add("text-align","left")
    oColpdrReview.ColumnSpan = "2"
    oRowpdrReview.Cells.Add(oColpdrReview)
    oColpdrReview = New TableCell
    oColpdrReview.Text = "Document Rev"
    oColpdrReview.Font.Bold = True
    oRowpdrReview.Cells.Add(oColpdrReview)
    oColpdrReview = New TableCell
    oColpdrReview.Text = oVar.DocumentRev
      oColpdrReview.Style.Add("text-align","left")
    oColpdrReview.ColumnSpan = "2"
    oRowpdrReview.Cells.Add(oColpdrReview)
    oTblpdrReview.Rows.Add(oRowpdrReview)
    oRowpdrReview = New TableRow
    oColpdrReview = New TableCell
    oColpdrReview.Text = "Defect Description"
    oColpdrReview.Font.Bold = True
    oRowpdrReview.Cells.Add(oColpdrReview)
    oColpdrReview = New TableCell
    oColpdrReview.Text = oVar.DefectDescription
      oColpdrReview.Style.Add("text-align","left")
    oColpdrReview.ColumnSpan = "5"
    oRowpdrReview.Cells.Add(oColpdrReview)
    oTblpdrReview.Rows.Add(oRowpdrReview)
    oRowpdrReview = New TableRow
    oColpdrReview = New TableCell
    oColpdrReview.Text = "Annexure Path"
    oColpdrReview.Font.Bold = True
    oRowpdrReview.Cells.Add(oColpdrReview)
    oColpdrReview = New TableCell
    oColpdrReview.Text = oVar.AnnexurePath
      oColpdrReview.Style.Add("text-align","left")
    oColpdrReview.ColumnSpan = "5"
    oRowpdrReview.Cells.Add(oColpdrReview)
    oTblpdrReview.Rows.Add(oRowpdrReview)
    oRowpdrReview = New TableRow
    oColpdrReview = New TableCell
    oColpdrReview.Text = "Cost Impact [Rs.]"
    oColpdrReview.Font.Bold = True
    oRowpdrReview.Cells.Add(oColpdrReview)
    oColpdrReview = New TableCell
    oColpdrReview.Text = oVar.CostImpact
      oColpdrReview.Style.Add("text-align","right")
    oColpdrReview.ColumnSpan = "2"
    oRowpdrReview.Cells.Add(oColpdrReview)
    oColpdrReview = New TableCell
    oColpdrReview.Text = "Cost Impact Debitable To"
    oColpdrReview.Font.Bold = True
    oRowpdrReview.Cells.Add(oColpdrReview)
    oColpdrReview = New TableCell
    oColpdrReview.Text = oVar.CostImpactDebitableTo
      oColpdrReview.Style.Add("text-align","right")
    oRowpdrReview.Cells.Add(oColpdrReview)
    oColpdrReview = New TableCell
    oColpdrReview.Text = oVar.PDR_Parties5_Description
      oColpdrReview.Style.Add("text-align","right")
    oRowpdrReview.Cells.Add(oColpdrReview)
    oTblpdrReview.Rows.Add(oRowpdrReview)
    oRowpdrReview = New TableRow
    oColpdrReview = New TableCell
    oColpdrReview.Text = "Time Impact [Hrs.]"
    oColpdrReview.Font.Bold = True
    oRowpdrReview.Cells.Add(oColpdrReview)
    oColpdrReview = New TableCell
    oColpdrReview.Text = oVar.TimeImpact
      oColpdrReview.Style.Add("text-align","right")
    oColpdrReview.ColumnSpan = "2"
    oRowpdrReview.Cells.Add(oColpdrReview)
    oColpdrReview = New TableCell
    oColpdrReview.Text = "Solution to be given by"
    oColpdrReview.Font.Bold = True
    oRowpdrReview.Cells.Add(oColpdrReview)
    oColpdrReview = New TableCell
    oColpdrReview.Text = oVar.SolutionToBeGivenBy
      oColpdrReview.Style.Add("text-align","left")
    oColpdrReview.ColumnSpan = "2"
    oRowpdrReview.Cells.Add(oColpdrReview)
    oTblpdrReview.Rows.Add(oRowpdrReview)
    oRowpdrReview = New TableRow
    oColpdrReview = New TableCell
    oColpdrReview.Text = "Created By"
    oColpdrReview.Font.Bold = True
    oRowpdrReview.Cells.Add(oColpdrReview)
    oColpdrReview = New TableCell
    oColpdrReview.Text = oVar.CreatedBy
      oColpdrReview.Style.Add("text-align","left")
    oRowpdrReview.Cells.Add(oColpdrReview)
    oColpdrReview = New TableCell
    oColpdrReview.Text = oVar.aspnet_users1_UserFullName
      oColpdrReview.Style.Add("text-align","left")
    oRowpdrReview.Cells.Add(oColpdrReview)
    oColpdrReview = New TableCell
    oColpdrReview.Text = "Created On"
    oColpdrReview.Font.Bold = True
    oRowpdrReview.Cells.Add(oColpdrReview)
    oColpdrReview = New TableCell
    oColpdrReview.Text = oVar.CreatedOn
      oColpdrReview.Style.Add("text-align","center")
    oColpdrReview.ColumnSpan = "2"
    oRowpdrReview.Cells.Add(oColpdrReview)
    oTblpdrReview.Rows.Add(oRowpdrReview)
    oRowpdrReview = New TableRow
    oColpdrReview = New TableCell
    oColpdrReview.Text = "Status"
    oColpdrReview.Font.Bold = True
    oRowpdrReview.Cells.Add(oColpdrReview)
    oColpdrReview = New TableCell
    oColpdrReview.Text = oVar.StatusID
      oColpdrReview.Style.Add("text-align","right")
    oColpdrReview.ColumnSpan = "5"
    oRowpdrReview.Cells.Add(oColpdrReview)
    oTblpdrReview.Rows.Add(oRowpdrReview)
    form1.Controls.Add(oTblpdrReview)
  End Sub
End Class
