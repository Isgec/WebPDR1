Partial Class AF_pdrCreate
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpdrCreate_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpdrCreate.Init
    DataClassName = "ApdrCreate"
    SetFormView = FVpdrCreate
  End Sub
  Protected Sub TBLpdrCreate_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpdrCreate.Init
    SetToolBar = TBLpdrCreate
  End Sub
  Protected Sub FVpdrCreate_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpdrCreate.DataBound
    SIS.PDR.pdrCreate.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpdrCreate_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpdrCreate.PreRender
    Dim oF_SeverityOfDefectID As LC_pdrSeverity = FVpdrCreate.FindControl("F_SeverityOfDefectID")
    oF_SeverityOfDefectID.Enabled = True
    oF_SeverityOfDefectID.SelectedValue = String.Empty
    If Not Session("F_SeverityOfDefectID") Is Nothing Then
      If Session("F_SeverityOfDefectID") <> String.Empty Then
        oF_SeverityOfDefectID.SelectedValue = Session("F_SeverityOfDefectID")
      End If
    End If
    Dim oF_CategoryOfDefectID As LC_pdrCategory = FVpdrCreate.FindControl("F_CategoryOfDefectID")
    oF_CategoryOfDefectID.Enabled = True
    oF_CategoryOfDefectID.SelectedValue = String.Empty
    If Not Session("F_CategoryOfDefectID") Is Nothing Then
      If Session("F_CategoryOfDefectID") <> String.Empty Then
        oF_CategoryOfDefectID.SelectedValue = Session("F_CategoryOfDefectID")
      End If
    End If
    Dim oF_ProjectID_Display As Label  = FVpdrCreate.FindControl("F_ProjectID_Display")
    oF_ProjectID_Display.Text = String.Empty
    If Not Session("F_ProjectID_Display") Is Nothing Then
      If Session("F_ProjectID_Display") <> String.Empty Then
        oF_ProjectID_Display.Text = Session("F_ProjectID_Display")
      End If
    End If
    Dim oF_ProjectID As TextBox  = FVpdrCreate.FindControl("F_ProjectID")
    oF_ProjectID.Enabled = True
    oF_ProjectID.Text = String.Empty
    If Not Session("F_ProjectID") Is Nothing Then
      If Session("F_ProjectID") <> String.Empty Then
        oF_ProjectID.Text = Session("F_ProjectID")
      End If
    End If
    Dim oF_ElementID_Display As Label  = FVpdrCreate.FindControl("F_ElementID_Display")
    oF_ElementID_Display.Text = String.Empty
    If Not Session("F_ElementID_Display") Is Nothing Then
      If Session("F_ElementID_Display") <> String.Empty Then
        oF_ElementID_Display.Text = Session("F_ElementID_Display")
      End If
    End If
    Dim oF_ElementID As TextBox  = FVpdrCreate.FindControl("F_ElementID")
    oF_ElementID.Enabled = True
    oF_ElementID.Text = String.Empty
    If Not Session("F_ElementID") Is Nothing Then
      If Session("F_ElementID") <> String.Empty Then
        oF_ElementID.Text = Session("F_ElementID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PDR_Main/App_Create") & "/AF_pdrCreate.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpdrCreate") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpdrCreate", mStr)
    End If
    If Request.QueryString("PDRNo") IsNot Nothing Then
      CType(FVpdrCreate.FindControl("F_PDRNo"), TextBox).Text = Request.QueryString("PDRNo")
      CType(FVpdrCreate.FindControl("F_PDRNo"), TextBox).Enabled = False
    End If
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
