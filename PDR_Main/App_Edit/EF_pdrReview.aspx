<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pdrReview.aspx.vb" Inherits="EF_pdrReview" title="Edit: Review and Action Plan" %>
<asp:Content ID="CPHpdrReview" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpdrReview" runat="server" Text="&nbsp;Edit: Review and Action Plan"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpdrReview" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpdrReview"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    EnablePrint = "False"
    PrintUrl = "../App_Print/RP_pdrReview.aspx?pk="
    ValidationGroup = "pdrReview"
    runat = "server" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        url = o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
<asp:FormView ID="FVpdrReview"
  runat = "server"
  DataKeyNames = "PDRNo"
  DataSourceID = "ODSpdrReview"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_PDRNo" runat="server" ForeColor="#CC6633" Text="PDR No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_PDRNo"
            Text='<%# Bind("PDRNo") %>'
            ToolTip="Value of PDR No."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PDRDate" runat="server" Text="PDR Date :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_PDRDate"
            Text='<%# Bind("PDRDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pdrReview"
            runat="server" />
          <asp:Image ID="ImageButtonPDRDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEPDRDate"
            TargetControlID="F_PDRDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonPDRDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEPDRDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_PDRDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVPDRDate"
            runat = "server"
            ControlToValidate = "F_PDRDate"
            ControlExtender = "MEEPDRDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pdrReview"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SeverityOfDefectID" runat="server" Text="Severity Of Defect :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_pdrSeverity
            ID="F_SeverityOfDefectID"
            SelectedValue='<%# Bind("SeverityOfDefectID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "pdrReview"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_CategoryOfDefectID" runat="server" Text="Category Of Defect :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_pdrCategory
            ID="F_CategoryOfDefectID"
            SelectedValue='<%# Bind("CategoryOfDefectID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "pdrReview"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectID" runat="server" Text="Project :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            CssClass = "myfktxt"
            Text='<%# Bind("ProjectID") %>'
            AutoCompleteType = "None"
            Width="56px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Project."
            ValidationGroup = "pdrReview"
            onblur= "script_pdrReview.validate_ProjectID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVProjectID"
            runat = "server"
            ControlToValidate = "F_ProjectID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pdrReview"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects2_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEProjectID"
            BehaviorID="B_ACEProjectID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ProjectIDCompletionList"
            TargetControlID="F_ProjectID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pdrReview.ACEProjectID_Selected"
            OnClientPopulating="script_pdrReview.ACEProjectID_Populating"
            OnClientPopulated="script_pdrReview.ACEProjectID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ElementID" runat="server" Text="Element :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ElementID"
            CssClass = "myfktxt"
            Text='<%# Bind("ElementID") %>'
            AutoCompleteType = "None"
            Width="72px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Element."
            ValidationGroup = "pdrReview"
            onblur= "script_pdrReview.validate_ElementID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVElementID"
            runat = "server"
            ControlToValidate = "F_ElementID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pdrReview"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ElementID_Display"
            Text='<%# Eval("IDM_WBS3_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEElementID"
            BehaviorID="B_ACEElementID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ElementIDCompletionList"
            TargetControlID="F_ElementID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pdrReview.ACEElementID_Selected"
            OnClientPopulating="script_pdrReview.ACEElementID_Populating"
            OnClientPopulated="script_pdrReview.ACEElementID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DocumentID" runat="server" Text="Document ID :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_DocumentID"
            Text='<%# Bind("DocumentID") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pdrReview"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Document ID."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDocumentID"
            runat = "server"
            ControlToValidate = "F_DocumentID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pdrReview"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DocumentRev" runat="server" Text="Document Rev :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_DocumentRev"
            Text='<%# Bind("DocumentRev") %>'
            Width="88px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pdrReview"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Document Rev."
            MaxLength="10"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDocumentRev"
            runat = "server"
            ControlToValidate = "F_DocumentRev"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pdrReview"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DefectDescription" runat="server" Text="Defect Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_DefectDescription"
            Text='<%# Bind("DefectDescription") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pdrReview"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Defect Description."
            MaxLength="1000"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDefectDescription"
            runat = "server"
            ControlToValidate = "F_DefectDescription"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pdrReview"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AnnexurePath" runat="server" Text="Annexure Path :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_AnnexurePath"
            Text='<%# Bind("AnnexurePath") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pdrReview"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Annexure Path."
            MaxLength="100"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVAnnexurePath"
            runat = "server"
            ControlToValidate = "F_AnnexurePath"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pdrReview"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CostImpact" runat="server" Text="Cost Impact [Rs.] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CostImpact"
            Text='<%# Bind("CostImpact") %>'
            style="text-align: right"
            Width="136px"
            CssClass = "mytxt"
            MaxLength="16"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEECostImpact"
            runat = "server"
            mask = "99999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_CostImpact" />
          <AJX:MaskedEditValidator 
            ID = "MEVCostImpact"
            runat = "server"
            ControlToValidate = "F_CostImpact"
            ControlExtender = "MEECostImpact"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CostImpactDebitableTo" runat="server" Text="Cost Impact Debitable To :" />&nbsp;
        </td>
        <td>
          <LGM:LC_pdrParties
            ID="F_CostImpactDebitableTo"
            SelectedValue='<%# Bind("CostImpactDebitableTo") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TimeImpact" runat="server" Text="Time Impact [Hrs.] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TimeImpact"
            Text='<%# Bind("TimeImpact") %>'
            style="text-align: right"
            Width="136px"
            CssClass = "mytxt"
            MaxLength="16"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEETimeImpact"
            runat = "server"
            mask = "99999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_TimeImpact" />
          <AJX:MaskedEditValidator 
            ID = "MEVTimeImpact"
            runat = "server"
            ControlToValidate = "F_TimeImpact"
            ControlExtender = "MEETimeImpact"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SolutionToBeGivenBy" runat="server" Text="Solution to be given by :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SolutionToBeGivenBy"
            Text='<%# Bind("SolutionToBeGivenBy") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Solution to be given by."
            MaxLength="250"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SolutionToBeGivenByUsers" runat="server" Text="Solution to be given by user list :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SolutionToBeGivenByUsers"
            Text='<%# Bind("SolutionToBeGivenByUsers") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Solution to be given by user list."
            MaxLength="250"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProposedSolution" runat="server" Text="Proposed Solution :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ProposedSolution"
            Text='<%# Bind("ProposedSolution") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Proposed Solution."
            MaxLength="1000"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SolutionGivenOn" runat="server" Text="Solution Given On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SolutionGivenOn"
            Text='<%# Bind("SolutionGivenOn") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonSolutionGivenOn" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CESolutionGivenOn"
            TargetControlID="F_SolutionGivenOn"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonSolutionGivenOn" />
          <AJX:MaskedEditExtender 
            ID = "MEESolutionGivenOn"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_SolutionGivenOn" />
          <AJX:MaskedEditValidator 
            ID = "MEVSolutionGivenOn"
            runat = "server"
            ControlToValidate = "F_SolutionGivenOn"
            ControlExtender = "MEESolutionGivenOn"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CreatedBy" runat="server" Text="Created By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_CreatedBy"
            Width="72px"
            Text='<%# Bind("CreatedBy") %>'
            Enabled = "False"
            ToolTip="Value of Created By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CreatedBy_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CreatedOn" runat="server" Text="Created On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CreatedOn"
            Text='<%# Bind("CreatedOn") %>'
            ToolTip="Value of Created On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_StatusID" runat="server" Text="Status :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:DropDownList
            ID="F_StatusID"
            SelectedValue='<%# Bind("StatusID") %>'
            Width="200px"
            Enabled = "False"
            CssClass = "dmyddl"
            Runat="Server" >
            <asp:ListItem Value="0">---ALL---</asp:ListItem>
            <asp:ListItem Value="1">Free</asp:ListItem>
            <asp:ListItem Value="2">Submitted</asp:ListItem>
            <asp:ListItem Value="3">Action Assigned</asp:ListItem>
            <asp:ListItem Value="4">Response Received</asp:ListItem>
            <asp:ListItem Value="5">Closed</asp:ListItem>
            <asp:ListItem Value="6">Returned</asp:ListItem>
          </asp:DropDownList>
         </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelpdrActionPlan" runat="server" Text="&nbsp;List: Action Plan"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpdrActionPlan" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpdrActionPlan"
      ToolType = "lgNMGrid"
      EditUrl = "~/PDR_Main/App_Edit/EF_pdrActionPlan.aspx"
      AddUrl = "~/PDR_Main/App_Create/AF_pdrActionPlan.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      ValidationGroup = "pdrActionPlan"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpdrActionPlan" runat="server" AssociatedUpdatePanelID="UPNLpdrActionPlan" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
    <asp:GridView ID="GVpdrActionPlan" SkinID="gv_silver" runat="server" DataSourceID="ODSpdrActionPlan" DataKeyNames="PDRNo,ActionNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
<%--        <asp:TemplateField HeaderText="PRINT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>--%>
        <asp:TemplateField HeaderText="Action No" SortExpression="[PDR_Actions].[ActionNo]">
          <ItemTemplate>
            <asp:Label ID="LabelActionNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ActionNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Action Description" SortExpression="[PDR_Actions].[ActionDescription]">
          <ItemTemplate>
            <asp:Label ID="LabelActionDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ActionDescription") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Responsible" SortExpression="[aspnet_users2].[UserFullName]">
          <ItemTemplate>
             <asp:Label ID="L_Responsible" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("Responsible") %>' Text='<%# Eval("aspnet_users2_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" SortExpression="[PDR_Actions].[StatusID]">
          <ItemTemplate>
            <asp:Label ID="LabelStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# EVal("StatusName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Freeze">
          <ItemTemplate>
            <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Freeze" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Freeze Action ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpdrActionPlan"
      runat = "server"
      DataObjectTypeName = "SIS.PDR.pdrActionPlan"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "pdrActionPlanSelectList"
      TypeName = "SIS.PDR.pdrActionPlan"
      SelectCountMethod = "pdrActionPlanSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_PDRNo" PropertyName="Text" Name="PDRNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpdrActionPlan" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpdrReview"
  DataObjectTypeName = "SIS.PDR.pdrReview"
  SelectMethod = "pdrReviewGetByID"
  UpdateMethod="UZ_pdrReviewUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PDR.pdrReview"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="PDRNo" Name="PDRNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
