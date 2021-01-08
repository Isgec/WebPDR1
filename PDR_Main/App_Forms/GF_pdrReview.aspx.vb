Imports System.Web.Script.Serialization
Partial Class GF_pdrReview
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PDR_Main/App_Display/DF_pdrReview.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?PDRNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpdrReview_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpdrReview.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim PDRNo As Int32 = GVpdrReview.DataKeys(e.CommandArgument).Values("PDRNo")  
        Dim RedirectUrl As String = TBLpdrReview.EditUrl & "?PDRNo=" & PDRNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim PDRNo As Int32 = GVpdrReview.DataKeys(e.CommandArgument).Values("PDRNo")  
        SIS.PDR.pdrReview.InitiateWF(PDRNo)
        GVpdrReview.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "rejectwf".ToLower Then
      Try
        Dim PDRNo As Int32 = GVpdrReview.DataKeys(e.CommandArgument).Values("PDRNo")  
        SIS.PDR.pdrReview.RejectWF(PDRNo)
        GVpdrReview.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpdrReview_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpdrReview.Init
    DataClassName = "GpdrReview"
    SetGridView = GVpdrReview
  End Sub
  Protected Sub TBLpdrReview_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpdrReview.Init
    SetToolBar = TBLpdrReview
  End Sub
  Protected Sub F_PDRNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_PDRNo.TextChanged
    Session("F_PDRNo") = F_PDRNo.Text
    InitGridPage()
  End Sub
  Protected Sub F_SeverityOfDefectID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_SeverityOfDefectID.SelectedIndexChanged
    Session("F_SeverityOfDefectID") = F_SeverityOfDefectID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_CategoryOfDefectID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CategoryOfDefectID.SelectedIndexChanged
    Session("F_CategoryOfDefectID") = F_CategoryOfDefectID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_ProjectID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ProjectID.TextChanged
    Session("F_ProjectID") = F_ProjectID.Text
    Session("F_ProjectID_Display") = F_ProjectID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_DocumentID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_DocumentID.TextChanged
    Session("F_DocumentID") = F_DocumentID.Text
    InitGridPage()
  End Sub
  Protected Sub F_CreatedBy_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CreatedBy.TextChanged
    Session("F_CreatedBy") = F_CreatedBy.Text
    Session("F_CreatedBy_Display") = F_CreatedBy_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function CreatedByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_StatusID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_StatusID.TextChanged
    Session("F_StatusID") = F_StatusID.Text
    InitGridPage()
  End Sub
  Protected Sub F_ElementID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ElementID.TextChanged
    Session("F_ElementID") = F_ElementID.Text
    Session("F_ElementID_Display") = F_ElementID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ElementIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakWBS.SelectpakWBSAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_SeverityOfDefectID.SelectedValue = String.Empty
    If Not Session("F_SeverityOfDefectID") Is Nothing Then
      If Session("F_SeverityOfDefectID") <> String.Empty Then
        F_SeverityOfDefectID.SelectedValue = Session("F_SeverityOfDefectID")
      End If
    End If
    F_CategoryOfDefectID.SelectedValue = String.Empty
    If Not Session("F_CategoryOfDefectID") Is Nothing Then
      If Session("F_CategoryOfDefectID") <> String.Empty Then
        F_CategoryOfDefectID.SelectedValue = Session("F_CategoryOfDefectID")
      End If
    End If
    F_ProjectID_Display.Text = String.Empty
    If Not Session("F_ProjectID_Display") Is Nothing Then
      If Session("F_ProjectID_Display") <> String.Empty Then
        F_ProjectID_Display.Text = Session("F_ProjectID_Display")
      End If
    End If
    F_ProjectID.Text = String.Empty
    If Not Session("F_ProjectID") Is Nothing Then
      If Session("F_ProjectID") <> String.Empty Then
        F_ProjectID.Text = Session("F_ProjectID")
      End If
    End If
    Dim strScriptProjectID As String = "<script type=""text/javascript""> " & _
      "function ACEProjectID_Selected(sender, e) {" & _
      "  var F_ProjectID = $get('" & F_ProjectID.ClientID & "');" & _
      "  var F_ProjectID_Display = $get('" & F_ProjectID_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_ProjectID.value = p[0];" & _
      "  F_ProjectID_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ProjectID") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ProjectID", strScriptProjectID)
      End If
    Dim strScriptPopulatingProjectID As String = "<script type=""text/javascript""> " & _
      "function ACEProjectID_Populating(o,e) {" & _
      "  var p = $get('" & F_ProjectID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEProjectID_Populated(o,e) {" & _
      "  var p = $get('" & F_ProjectID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ProjectIDPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ProjectIDPopulating", strScriptPopulatingProjectID)
      End If
    F_CreatedBy_Display.Text = String.Empty
    If Not Session("F_CreatedBy_Display") Is Nothing Then
      If Session("F_CreatedBy_Display") <> String.Empty Then
        F_CreatedBy_Display.Text = Session("F_CreatedBy_Display")
      End If
    End If
    F_CreatedBy.Text = String.Empty
    If Not Session("F_CreatedBy") Is Nothing Then
      If Session("F_CreatedBy") <> String.Empty Then
        F_CreatedBy.Text = Session("F_CreatedBy")
      End If
    End If
    Dim strScriptCreatedBy As String = "<script type=""text/javascript""> " & _
      "function ACECreatedBy_Selected(sender, e) {" & _
      "  var F_CreatedBy = $get('" & F_CreatedBy.ClientID & "');" & _
      "  var F_CreatedBy_Display = $get('" & F_CreatedBy_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_CreatedBy.value = p[0];" & _
      "  F_CreatedBy_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_CreatedBy") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_CreatedBy", strScriptCreatedBy)
      End If
    Dim strScriptPopulatingCreatedBy As String = "<script type=""text/javascript""> " & _
      "function ACECreatedBy_Populating(o,e) {" & _
      "  var p = $get('" & F_CreatedBy.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACECreatedBy_Populated(o,e) {" & _
      "  var p = $get('" & F_CreatedBy.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_CreatedByPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_CreatedByPopulating", strScriptPopulatingCreatedBy)
      End If
    F_ElementID_Display.Text = String.Empty
    If Not Session("F_ElementID_Display") Is Nothing Then
      If Session("F_ElementID_Display") <> String.Empty Then
        F_ElementID_Display.Text = Session("F_ElementID_Display")
      End If
    End If
    F_ElementID.Text = String.Empty
    If Not Session("F_ElementID") Is Nothing Then
      If Session("F_ElementID") <> String.Empty Then
        F_ElementID.Text = Session("F_ElementID")
      End If
    End If
    Dim strScriptElementID As String = "<script type=""text/javascript""> " & _
      "function ACEElementID_Selected(sender, e) {" & _
      "  var F_ElementID = $get('" & F_ElementID.ClientID & "');" & _
      "  var F_ElementID_Display = $get('" & F_ElementID_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_ElementID.value = p[0];" & _
      "  F_ElementID_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ElementID") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ElementID", strScriptElementID)
      End If
    Dim strScriptPopulatingElementID As String = "<script type=""text/javascript""> " & _
      "function ACEElementID_Populating(o,e) {" & _
      "  var p = $get('" & F_ElementID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEElementID_Populated(o,e) {" & _
      "  var p = $get('" & F_ElementID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ElementIDPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ElementIDPopulating", strScriptPopulatingElementID)
      End If
    Dim validateScriptProjectID As String = "<script type=""text/javascript"">" & _
      "  function validate_ProjectID(o) {" & _
      "    validated_FK_PDR_Defects_ProjectID_main = true;" & _
      "    validate_FK_PDR_Defects_ProjectID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateProjectID", validateScriptProjectID)
    End If
    Dim validateScriptCreatedBy As String = "<script type=""text/javascript"">" & _
      "  function validate_CreatedBy(o) {" & _
      "    validated_FK_PDR_Defects_CreatedBy_main = true;" & _
      "    validate_FK_PDR_Defects_CreatedBy(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateCreatedBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateCreatedBy", validateScriptCreatedBy)
    End If
    Dim validateScriptElementID As String = "<script type=""text/javascript"">" & _
      "  function validate_ElementID(o) {" & _
      "    validated_FK_PDR_Defects_ElementID_main = true;" & _
      "    validate_FK_PDR_Defects_ElementID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateElementID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateElementID", validateScriptElementID)
    End If
    Dim validateScriptFK_PDR_Defects_CreatedBy As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PDR_Defects_CreatedBy(o) {" & _
      "    var value = o.id;" & _
      "    var CreatedBy = $get('" & F_CreatedBy.ClientID & "');" & _
      "    try{" & _
      "    if(CreatedBy.value==''){" & _
      "      if(validated_FK_PDR_Defects_CreatedBy.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + CreatedBy.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PDR_Defects_CreatedBy(value, validated_FK_PDR_Defects_CreatedBy);" & _
      "  }" & _
      "  validated_FK_PDR_Defects_CreatedBy_main = false;" & _
      "  function validated_FK_PDR_Defects_CreatedBy(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PDR_Defects_CreatedBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PDR_Defects_CreatedBy", validateScriptFK_PDR_Defects_CreatedBy)
    End If
    Dim validateScriptFK_PDR_Defects_ProjectID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PDR_Defects_ProjectID(o) {" & _
      "    var value = o.id;" & _
      "    var ProjectID = $get('" & F_ProjectID.ClientID & "');" & _
      "    try{" & _
      "    if(ProjectID.value==''){" & _
      "      if(validated_FK_PDR_Defects_ProjectID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + ProjectID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PDR_Defects_ProjectID(value, validated_FK_PDR_Defects_ProjectID);" & _
      "  }" & _
      "  validated_FK_PDR_Defects_ProjectID_main = false;" & _
      "  function validated_FK_PDR_Defects_ProjectID(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PDR_Defects_ProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PDR_Defects_ProjectID", validateScriptFK_PDR_Defects_ProjectID)
    End If
    Dim validateScriptFK_PDR_Defects_ElementID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PDR_Defects_ElementID(o) {" & _
      "    var value = o.id;" & _
      "    var ElementID = $get('" & F_ElementID.ClientID & "');" & _
      "    try{" & _
      "    if(ElementID.value==''){" & _
      "      if(validated_FK_PDR_Defects_ElementID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + ElementID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PDR_Defects_ElementID(value, validated_FK_PDR_Defects_ElementID);" & _
      "  }" & _
      "  validated_FK_PDR_Defects_ElementID_main = false;" & _
      "  function validated_FK_PDR_Defects_ElementID(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PDR_Defects_ElementID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PDR_Defects_ElementID", validateScriptFK_PDR_Defects_ElementID)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PDR_Defects_CreatedBy(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim CreatedBy As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(CreatedBy)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
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
