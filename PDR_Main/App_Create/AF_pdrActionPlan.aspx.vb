Partial Class AF_pdrActionPlan
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpdrActionPlan_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpdrActionPlan.Init
    DataClassName = "ApdrActionPlan"
    SetFormView = FVpdrActionPlan
  End Sub
  Protected Sub TBLpdrActionPlan_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpdrActionPlan.Init
    SetToolBar = TBLpdrActionPlan
  End Sub
  Protected Sub FVpdrActionPlan_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpdrActionPlan.DataBound
    SIS.PDR.pdrActionPlan.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpdrActionPlan_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpdrActionPlan.PreRender
    Dim oF_PDRNo_Display As Label  = FVpdrActionPlan.FindControl("F_PDRNo_Display")
    oF_PDRNo_Display.Text = String.Empty
    If Not Session("F_PDRNo_Display") Is Nothing Then
      If Session("F_PDRNo_Display") <> String.Empty Then
        oF_PDRNo_Display.Text = Session("F_PDRNo_Display")
      End If
    End If
    Dim oF_PDRNo As TextBox  = FVpdrActionPlan.FindControl("F_PDRNo")
    oF_PDRNo.Enabled = True
    oF_PDRNo.Text = String.Empty
    If Not Session("F_PDRNo") Is Nothing Then
      If Session("F_PDRNo") <> String.Empty Then
        oF_PDRNo.Text = Session("F_PDRNo")
      End If
    End If
    Dim oF_Responsible_Display As Label  = FVpdrActionPlan.FindControl("F_Responsible_Display")
    Dim oF_Responsible As TextBox  = FVpdrActionPlan.FindControl("F_Responsible")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PDR_Main/App_Create") & "/AF_pdrActionPlan.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpdrActionPlan") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpdrActionPlan", mStr)
    End If
    If Request.QueryString("PDRNo") IsNot Nothing Then
      CType(FVpdrActionPlan.FindControl("F_PDRNo"), TextBox).Text = Request.QueryString("PDRNo")
      CType(FVpdrActionPlan.FindControl("F_PDRNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("ActionNo") IsNot Nothing Then
      CType(FVpdrActionPlan.FindControl("F_ActionNo"), TextBox).Text = Request.QueryString("ActionNo")
      CType(FVpdrActionPlan.FindControl("F_ActionNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function PDRNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PDR.pdrCreate.SelectpdrCreateAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ResponsibleCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PDR_Actions_PDRNo(ByVal value As String) As String
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
