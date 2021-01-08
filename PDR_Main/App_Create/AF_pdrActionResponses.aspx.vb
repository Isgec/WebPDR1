Partial Class AF_pdrActionResponses
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpdrActionResponses_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpdrActionResponses.Init
    DataClassName = "ApdrActionResponses"
    SetFormView = FVpdrActionResponses
  End Sub
  Protected Sub TBLpdrActionResponses_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpdrActionResponses.Init
    SetToolBar = TBLpdrActionResponses
  End Sub
  Protected Sub FVpdrActionResponses_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpdrActionResponses.DataBound
    SIS.PDR.pdrActionResponses.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpdrActionResponses_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpdrActionResponses.PreRender
    Dim oF_PDRNo_Display As Label  = FVpdrActionResponses.FindControl("F_PDRNo_Display")
    oF_PDRNo_Display.Text = String.Empty
    If Not Session("F_PDRNo_Display") Is Nothing Then
      If Session("F_PDRNo_Display") <> String.Empty Then
        oF_PDRNo_Display.Text = Session("F_PDRNo_Display")
      End If
    End If
    Dim oF_PDRNo As TextBox  = FVpdrActionResponses.FindControl("F_PDRNo")
    oF_PDRNo.Enabled = True
    oF_PDRNo.Text = String.Empty
    If Not Session("F_PDRNo") Is Nothing Then
      If Session("F_PDRNo") <> String.Empty Then
        oF_PDRNo.Text = Session("F_PDRNo")
      End If
    End If
    Dim oF_ActionNo_Display As Label  = FVpdrActionResponses.FindControl("F_ActionNo_Display")
    oF_ActionNo_Display.Text = String.Empty
    If Not Session("F_ActionNo_Display") Is Nothing Then
      If Session("F_ActionNo_Display") <> String.Empty Then
        oF_ActionNo_Display.Text = Session("F_ActionNo_Display")
      End If
    End If
    Dim oF_ActionNo As TextBox  = FVpdrActionResponses.FindControl("F_ActionNo")
    oF_ActionNo.Enabled = True
    oF_ActionNo.Text = String.Empty
    If Not Session("F_ActionNo") Is Nothing Then
      If Session("F_ActionNo") <> String.Empty Then
        oF_ActionNo.Text = Session("F_ActionNo")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PDR_Main/App_Create") & "/AF_pdrActionResponses.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpdrActionResponses") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpdrActionResponses", mStr)
    End If
    If Request.QueryString("PDRNo") IsNot Nothing Then
      CType(FVpdrActionResponses.FindControl("F_PDRNo"), TextBox).Text = Request.QueryString("PDRNo")
      CType(FVpdrActionResponses.FindControl("F_PDRNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("ActionNo") IsNot Nothing Then
      CType(FVpdrActionResponses.FindControl("F_ActionNo"), TextBox).Text = Request.QueryString("ActionNo")
      CType(FVpdrActionResponses.FindControl("F_ActionNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("ResponseNo") IsNot Nothing Then
      CType(FVpdrActionResponses.FindControl("F_ResponseNo"), TextBox).Text = Request.QueryString("ResponseNo")
      CType(FVpdrActionResponses.FindControl("F_ResponseNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function PDRNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PDR.pdrCreate.SelectpdrCreateAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ActionNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PDR.pdrActionPlan.SelectpdrActionPlanAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PDR_ActionResponses_ActionNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim PDRNo As Int32 = CType(aVal(1),Int32)
    Dim ActionNo As Int32 = CType(aVal(2),Int32)
    Dim oVar As SIS.PDR.pdrActionPlan = SIS.PDR.pdrActionPlan.pdrActionPlanGetByID(PDRNo,ActionNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PDR_ActionResponses_PDRNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim PDRNo As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PDR.pdrCreate = SIS.PDR.pdrCreate.pdrCreateGetByID(PDRNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
