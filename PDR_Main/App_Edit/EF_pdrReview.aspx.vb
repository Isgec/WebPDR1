Imports System.Web.Script.Serialization
Partial Class EF_pdrReview
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
  Protected Sub ODSpdrReview_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpdrReview.Selected
    Dim tmp As SIS.PDR.pdrReview = CType(e.ReturnValue, SIS.PDR.pdrReview)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpdrReview_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpdrReview.Init
    DataClassName = "EpdrReview"
    SetFormView = FVpdrReview
  End Sub
  Protected Sub TBLpdrReview_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpdrReview.Init
    SetToolBar = TBLpdrReview
  End Sub
  Protected Sub FVpdrReview_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpdrReview.PreRender
    TBLpdrReview.EnableSave = Editable
    TBLpdrReview.EnableDelete = Deleteable
    TBLpdrReview.PrintUrl &= Request.QueryString("PDRNo") & "|"
    TBLpdrActionPlan.EnableAdd = Editable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PDR_Main/App_Edit") & "/EF_pdrReview.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpdrReview") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpdrReview", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpdrActionPlanCC As New gvBase
  Protected Sub GVpdrActionPlan_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpdrActionPlan.Init
    gvpdrActionPlanCC.DataClassName = "GpdrActionPlan"
    gvpdrActionPlanCC.SetGridView = GVpdrActionPlan
  End Sub
  Protected Sub TBLpdrActionPlan_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpdrActionPlan.Init
    gvpdrActionPlanCC.SetToolBar = TBLpdrActionPlan
  End Sub
  Protected Sub GVpdrActionPlan_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpdrActionPlan.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim PDRNo As Int32 = GVpdrActionPlan.DataKeys(e.CommandArgument).Values("PDRNo")  
        Dim ActionNo As Int32 = GVpdrActionPlan.DataKeys(e.CommandArgument).Values("ActionNo")  
        Dim RedirectUrl As String = TBLpdrActionPlan.EditUrl & "?PDRNo=" & PDRNo & "&ActionNo=" & ActionNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim PDRNo As Int32 = GVpdrActionPlan.DataKeys(e.CommandArgument).Values("PDRNo")  
        Dim ActionNo As Int32 = GVpdrActionPlan.DataKeys(e.CommandArgument).Values("ActionNo")  
        SIS.PDR.pdrActionPlan.DeleteWF(PDRNo, ActionNo)
        GVpdrActionPlan.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim PDRNo As Int32 = GVpdrActionPlan.DataKeys(e.CommandArgument).Values("PDRNo")  
        Dim ActionNo As Int32 = GVpdrActionPlan.DataKeys(e.CommandArgument).Values("ActionNo")  
        SIS.PDR.pdrActionPlan.InitiateWF(PDRNo, ActionNo)
        GVpdrActionPlan.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub TBLpdrActionPlan_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLpdrActionPlan.AddClicked
    Dim PDRNo As Int32 = CType(FVpdrReview.FindControl("F_PDRNo"), TextBox).Text
    TBLpdrActionPlan.AddUrl &= "?PDRNo=" & PDRNo
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ElementIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakWBS.SelectpakWBSAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PDR_Defects_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PDR_Defects_ElementID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ElementID As String = CType(aVal(1),String)
    Dim oVar As SIS.PAK.pakWBS = SIS.PAK.pakWBS.pakWBSGetByID(ElementID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
