Imports System.Web.Script.Serialization
Partial Class GF_pdrSubmitResponse
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PDR_Main/App_Display/DF_pdrSubmitResponse.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?PDRNo=" & aVal(0) & "&ActionNo=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpdrSubmitResponse_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpdrSubmitResponse.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim PDRNo As Int32 = GVpdrSubmitResponse.DataKeys(e.CommandArgument).Values("PDRNo")  
        Dim ActionNo As Int32 = GVpdrSubmitResponse.DataKeys(e.CommandArgument).Values("ActionNo")  
        Dim RedirectUrl As String = TBLpdrSubmitResponse.EditUrl & "?PDRNo=" & PDRNo & "&ActionNo=" & ActionNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim PDRNo As Int32 = GVpdrSubmitResponse.DataKeys(e.CommandArgument).Values("PDRNo")  
        Dim ActionNo As Int32 = GVpdrSubmitResponse.DataKeys(e.CommandArgument).Values("ActionNo")  
        SIS.PDR.pdrSubmitResponse.InitiateWF(PDRNo, ActionNo)
        GVpdrSubmitResponse.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpdrSubmitResponse_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpdrSubmitResponse.Init
    DataClassName = "GpdrSubmitResponse"
    SetGridView = GVpdrSubmitResponse
  End Sub
  Protected Sub TBLpdrSubmitResponse_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpdrSubmitResponse.Init
    SetToolBar = TBLpdrSubmitResponse
  End Sub
  Protected Sub F_PDRNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_PDRNo.TextChanged
    Session("F_PDRNo") = F_PDRNo.Text
    Session("F_PDRNo_Display") = F_PDRNo_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function PDRNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PDR.pdrCreate.SelectpdrCreateAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_PDRNo_Display.Text = String.Empty
    If Not Session("F_PDRNo_Display") Is Nothing Then
      If Session("F_PDRNo_Display") <> String.Empty Then
        F_PDRNo_Display.Text = Session("F_PDRNo_Display")
      End If
    End If
    F_PDRNo.Text = String.Empty
    If Not Session("F_PDRNo") Is Nothing Then
      If Session("F_PDRNo") <> String.Empty Then
        F_PDRNo.Text = Session("F_PDRNo")
      End If
    End If
    Dim strScriptPDRNo As String = "<script type=""text/javascript""> " & _
      "function ACEPDRNo_Selected(sender, e) {" & _
      "  var F_PDRNo = $get('" & F_PDRNo.ClientID & "');" & _
      "  var F_PDRNo_Display = $get('" & F_PDRNo_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_PDRNo.value = p[0];" & _
      "  F_PDRNo_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_PDRNo") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_PDRNo", strScriptPDRNo)
      End If
    Dim strScriptPopulatingPDRNo As String = "<script type=""text/javascript""> " & _
      "function ACEPDRNo_Populating(o,e) {" & _
      "  var p = $get('" & F_PDRNo.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEPDRNo_Populated(o,e) {" & _
      "  var p = $get('" & F_PDRNo.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_PDRNoPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_PDRNoPopulating", strScriptPopulatingPDRNo)
      End If
    Dim validateScriptPDRNo As String = "<script type=""text/javascript"">" & _
      "  function validate_PDRNo(o) {" & _
      "    validated_FK_PDR_Actions_PDRNo_main = true;" & _
      "    validate_FK_PDR_Actions_PDRNo(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validatePDRNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validatePDRNo", validateScriptPDRNo)
    End If
    Dim validateScriptFK_PDR_Actions_PDRNo As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PDR_Actions_PDRNo(o) {" & _
      "    var value = o.id;" & _
      "    var PDRNo = $get('" & F_PDRNo.ClientID & "');" & _
      "    try{" & _
      "    if(PDRNo.value==''){" & _
      "      if(validated_FK_PDR_Actions_PDRNo.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + PDRNo.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PDR_Actions_PDRNo(value, validated_FK_PDR_Actions_PDRNo);" & _
      "  }" & _
      "  validated_FK_PDR_Actions_PDRNo_main = false;" & _
      "  function validated_FK_PDR_Actions_PDRNo(result) {" & _
      "    var p = result.split('|');" & _
      "    var o = $get(p[1]);" & _
      "    var o_d = $get(p[1]+'_Display');" & _
      "    try{o_d.innerHTML = p[2];}catch(ex){}" & _
      "    o.style.backgroundImage  = 'none';" & _
      "    if(p[0]=='1'){" & _
      "      o.value='';" & _
      "      try{o_d.innerHTML = '';}catch(ex){}" & _
      "      __doPostBack(o.id, o.value);" & _
      "    }" & _
      "    else" & _
      "      __doPostBack(o.id, o.value);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PDR_Actions_PDRNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PDR_Actions_PDRNo", validateScriptFK_PDR_Actions_PDRNo)
    End If
  End Sub
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
End Class
