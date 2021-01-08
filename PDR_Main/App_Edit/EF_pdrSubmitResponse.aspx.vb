Imports System.Web.Script.Serialization
Partial Class EF_pdrSubmitResponse
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
  Protected Sub ODSpdrSubmitResponse_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpdrSubmitResponse.Selected
    Dim tmp As SIS.PDR.pdrSubmitResponse = CType(e.ReturnValue, SIS.PDR.pdrSubmitResponse)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpdrSubmitResponse_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpdrSubmitResponse.Init
    DataClassName = "EpdrSubmitResponse"
    SetFormView = FVpdrSubmitResponse
  End Sub
  Protected Sub TBLpdrSubmitResponse_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpdrSubmitResponse.Init
    SetToolBar = TBLpdrSubmitResponse
  End Sub
  Protected Sub FVpdrSubmitResponse_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpdrSubmitResponse.PreRender
    TBLpdrSubmitResponse.EnableSave = Editable
    TBLpdrSubmitResponse.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PDR_Main/App_Edit") & "/EF_pdrSubmitResponse.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpdrSubmitResponse") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpdrSubmitResponse", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpdrActionResponsesCC As New gvBase
  Protected Sub GVpdrActionResponses_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpdrActionResponses.Init
    gvpdrActionResponsesCC.DataClassName = "GpdrActionResponses"
    gvpdrActionResponsesCC.SetGridView = GVpdrActionResponses
  End Sub
  Protected Sub TBLpdrActionResponses_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpdrActionResponses.Init
    gvpdrActionResponsesCC.SetToolBar = TBLpdrActionResponses
  End Sub
  Protected Sub GVpdrActionResponses_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpdrActionResponses.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim PDRNo As Int32 = GVpdrActionResponses.DataKeys(e.CommandArgument).Values("PDRNo")  
        Dim ActionNo As Int32 = GVpdrActionResponses.DataKeys(e.CommandArgument).Values("ActionNo")  
        Dim ResponseNo As Int32 = GVpdrActionResponses.DataKeys(e.CommandArgument).Values("ResponseNo")  
        Dim RedirectUrl As String = TBLpdrActionResponses.EditUrl & "?PDRNo=" & PDRNo & "&ActionNo=" & ActionNo & "&ResponseNo=" & ResponseNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim PDRNo As Int32 = GVpdrActionResponses.DataKeys(e.CommandArgument).Values("PDRNo")  
        Dim ActionNo As Int32 = GVpdrActionResponses.DataKeys(e.CommandArgument).Values("ActionNo")  
        Dim ResponseNo As Int32 = GVpdrActionResponses.DataKeys(e.CommandArgument).Values("ResponseNo")  
        SIS.PDR.pdrActionResponses.DeleteWF(PDRNo, ActionNo, ResponseNo)
        GVpdrActionResponses.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim PDRNo As Int32 = GVpdrActionResponses.DataKeys(e.CommandArgument).Values("PDRNo")  
        Dim ActionNo As Int32 = GVpdrActionResponses.DataKeys(e.CommandArgument).Values("ActionNo")  
        Dim ResponseNo As Int32 = GVpdrActionResponses.DataKeys(e.CommandArgument).Values("ResponseNo")  
        SIS.PDR.pdrActionResponses.InitiateWF(PDRNo, ActionNo, ResponseNo)
        GVpdrActionResponses.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub TBLpdrActionResponses_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLpdrActionResponses.AddClicked
    Dim PDRNo As Int32 = CType(FVpdrSubmitResponse.FindControl("F_PDRNo"),TextBox).Text
    Dim ActionNo As Int32 = CType(FVpdrSubmitResponse.FindControl("F_ActionNo"),TextBox).Text
    TBLpdrActionResponses.AddUrl &= "?PDRNo=" & PDRNo
    TBLpdrActionResponses.AddUrl &= "&ActionNo=" & ActionNo
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ResponsibleCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PDR_Actions_Responsible(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim Responsible As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(Responsible)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
