<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_pdrCreate.aspx.vb" Inherits="AF_pdrCreate" title="Add: Create and Submit PDR" %>
<asp:Content ID="CPHpdrCreate" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpdrCreate" runat="server" Text="&nbsp;Add: Create and Submit PDR"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpdrCreate" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpdrCreate"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "pdrCreate"
    runat = "server" />
<asp:FormView ID="FVpdrCreate"
  runat = "server"
  DataKeyNames = "PDRNo"
  DataSourceID = "ODSpdrCreate"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpdrCreate" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_PDRNo" ForeColor="#CC6633" runat="server" Text="PDR No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_PDRNo" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PDRDate" runat="server" Text="PDR Date :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_PDRDate"
            Text='<%# Bind("PDRDate") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="pdrCreate"
            onfocus = "return this.select();"
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
            ValidationGroup = "pdrCreate"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
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
            ValidationGroup = "pdrCreate"
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
            ValidationGroup = "pdrCreate"
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
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Project."
            ValidationGroup = "pdrCreate"
            onblur= "script_pdrCreate.validate_ProjectID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVProjectID"
            runat = "server"
            ControlToValidate = "F_ProjectID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pdrCreate"
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
            OnClientItemSelected="script_pdrCreate.ACEProjectID_Selected"
            OnClientPopulating="script_pdrCreate.ACEProjectID_Populating"
            OnClientPopulated="script_pdrCreate.ACEProjectID_Populated"
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
            Width="72px"
            Text='<%# Bind("ElementID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Element."
            ValidationGroup = "pdrCreate"
            onblur= "script_pdrCreate.validate_ElementID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVElementID"
            runat = "server"
            ControlToValidate = "F_ElementID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pdrCreate"
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
            OnClientItemSelected="script_pdrCreate.ACEElementID_Selected"
            OnClientPopulating="script_pdrCreate.ACEElementID_Populating"
            OnClientPopulated="script_pdrCreate.ACEElementID_Populated"
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
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pdrCreate"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Document ID."
            MaxLength="50"
            Width="408px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDocumentID"
            runat = "server"
            ControlToValidate = "F_DocumentID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pdrCreate"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DocumentRev" runat="server" Text="Document Rev :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_DocumentRev"
            Text='<%# Bind("DocumentRev") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pdrCreate"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Document Rev."
            MaxLength="10"
            Width="88px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDocumentRev"
            runat = "server"
            ControlToValidate = "F_DocumentRev"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pdrCreate"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DefectDescription" runat="server" Text="Defect Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_DefectDescription"
            Text='<%# Bind("DefectDescription") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pdrCreate"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Defect Description."
            MaxLength="1000"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDefectDescription"
            runat = "server"
            ControlToValidate = "F_DefectDescription"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pdrCreate"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AnnexurePath" runat="server" Text="Annexure Path :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_AnnexurePath"
            Text='<%# Bind("AnnexurePath") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pdrCreate"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Annexure Path."
            MaxLength="100"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVAnnexurePath"
            runat = "server"
            ControlToValidate = "F_AnnexurePath"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pdrCreate"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CostImpact" runat="server" Text="Cost Impact [Rs.] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CostImpact"
            Text='<%# Bind("CostImpact") %>'
            Width="136px"
            CssClass = "mytxt"
            style="text-align: Right"
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
            Width="136px"
            CssClass = "mytxt"
            style="text-align: Right"
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
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Solution to be given by."
            MaxLength="250"
            Width="350px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SolutionToBeGivenByUsers" runat="server" Text="Solution to be given by user list :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SolutionToBeGivenByUsers"
            Text='<%# Bind("SolutionToBeGivenByUsers") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Solution to be given by user list."
            MaxLength="250"
            Width="350px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProposedSolution" runat="server" Text="Proposed Solution :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ProposedSolution"
            Text='<%# Bind("ProposedSolution") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Proposed Solution."
            MaxLength="1000"
            Width="350px"
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpdrCreate"
  DataObjectTypeName = "SIS.PDR.pdrCreate"
  InsertMethod="pdrCreateInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PDR.pdrCreate"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
