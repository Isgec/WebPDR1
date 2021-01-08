<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_pdrCreate.aspx.vb" Inherits="GF_pdrCreate" title="Maintain List: Create and Submit PDR" %>
<asp:Content ID="CPHpdrCreate" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpdrCreate" runat="server" Text="&nbsp;List: Create and Submit PDR"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpdrCreate" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpdrCreate"
      ToolType = "lgNMGrid"
      EditUrl = "~/PDR_Main/App_Edit/EF_pdrCreate.aspx"
      AddUrl = "~/PDR_Main/App_Create/AF_pdrCreate.aspx"
      ValidationGroup = "pdrCreate"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpdrCreate" runat="server" AssociatedUpdatePanelID="UPNLpdrCreate" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:Panel ID="pnlH" runat="server" CssClass="cph_filter">
      <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
        <div style="float: left;">Filter Records </div>
        <div style="float: left; margin-left: 20px;">
          <asp:Label ID="lblH" runat="server">(Show Filters...)</asp:Label>
        </div>
        <div style="float: right; vertical-align: middle;">
          <asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Filters...)" />
        </div>
      </div>
    </asp:Panel>
    <asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
    <table>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_PDRNo" runat="server" Text="PDR No :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_PDRNo"
            Text=""
            Width="88px"
            style="text-align: right"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEPDRNo"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_PDRNo" />
          <AJX:MaskedEditValidator 
            ID = "MEVPDRNo"
            runat = "server"
            ControlToValidate = "F_PDRNo"
            ControlExtender = "MEEPDRNo"
            InvalidValueMessage = "*"
            EmptyValueMessage = ""
            EmptyValueBlurredText = ""
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SeverityOfDefectID" runat="server" Text="Severity Of Defect :" /></b>
        </td>
        <td>
          <LGM:LC_pdrSeverity
            ID="F_SeverityOfDefectID"
            OrderBy="SeverityDescription"
            DataTextField="SeverityDescription"
            DataValueField="SeverityID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CategoryOfDefectID" runat="server" Text="Category Of Defect :" /></b>
        </td>
        <td>
          <LGM:LC_pdrCategory
            ID="F_CategoryOfDefectID"
            OrderBy="CategoryDescription"
            DataTextField="CategoryDescription"
            DataValueField="CategoryID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectID" runat="server" Text="Project :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            CssClass = "myfktxt"
            Width="56px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_ProjectID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEProjectID"
            BehaviorID="B_ACEProjectID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ProjectIDCompletionList"
            TargetControlID="F_ProjectID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEProjectID_Selected"
            OnClientPopulating="ACEProjectID_Populating"
            OnClientPopulated="ACEProjectID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ElementID" runat="server" Text="Element :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ElementID"
            CssClass = "myfktxt"
            Width="72px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_ElementID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ElementID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEElementID"
            BehaviorID="B_ACEElementID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ElementIDCompletionList"
            TargetControlID="F_ElementID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEElementID_Selected"
            OnClientPopulating="ACEElementID_Populating"
            OnClientPopulated="ACEElementID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_DocumentID" runat="server" Text="Document ID :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_DocumentID"
            Text=""
            CssClass = "mytxt"
            onfocus = "return this.select();"
            MaxLength="50"
            Width="408px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CreatedBy" runat="server" Text="Created By :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_CreatedBy"
            CssClass = "myfktxt"
            Width="72px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_CreatedBy(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_CreatedBy_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECreatedBy"
            BehaviorID="B_ACECreatedBy"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="CreatedByCompletionList"
            TargetControlID="F_CreatedBy"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACECreatedBy_Selected"
            OnClientPopulating="ACECreatedBy_Populating"
            OnClientPopulated="ACECreatedBy_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_StatusID" runat="server" Text="Status :" /></b>
        </td>
        <td>
          <asp:DropDownList
            ID="F_StatusID"
            Width="200px"
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
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVpdrCreate" SkinID="gv_silver" runat="server" DataSourceID="ODSpdrCreate" DataKeyNames="PDRNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PDR No" SortExpression="[PDR_Defects].[PDRNo]">
          <ItemTemplate>
            <asp:Label ID="LabelPDRNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PDRNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Severity Of Defect" SortExpression="[PDR_severity6].[SeverityDescription]">
          <ItemTemplate>
             <asp:Label ID="L_SeverityOfDefectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("SeverityOfDefectID") %>' Text='<%# Eval("PDR_severity6_SeverityDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Category Of Defect" SortExpression="[PDR_Category4].[CategoryDescription]">
          <ItemTemplate>
             <asp:Label ID="L_CategoryOfDefectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CategoryOfDefectID") %>' Text='<%# Eval("PDR_Category4_CategoryDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project" SortExpression="[IDM_Projects2].[Description]">
          <ItemTemplate>
             <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("IDM_Projects2_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Document ID" SortExpression="[PDR_Defects].[DocumentID]">
          <ItemTemplate>
            <asp:Label ID="LabelDocumentID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocumentID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Created On" SortExpression="[PDR_Defects].[CreatedOn]">
          <ItemTemplate>
            <asp:Label ID="LabelCreatedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CreatedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" SortExpression="[PDR_Defects].[StatusID]">
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
        <asp:TemplateField HeaderText="Forward">
          <ItemTemplate>
            <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Forward" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Forward record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
      ID = "ODSpdrCreate"
      runat = "server"
      DataObjectTypeName = "SIS.PDR.pdrCreate"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_pdrCreateSelectList"
      TypeName = "SIS.PDR.pdrCreate"
      SelectCountMethod = "pdrCreateSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_PDRNo" PropertyName="Text" Name="PDRNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_SeverityOfDefectID" PropertyName="SelectedValue" Name="SeverityOfDefectID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_CategoryOfDefectID" PropertyName="SelectedValue" Name="CategoryOfDefectID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_ProjectID" PropertyName="Text" Name="ProjectID" Type="String" Size="6" />
        <asp:ControlParameter ControlID="F_DocumentID" PropertyName="Text" Name="DocumentID" Type="String" Size="50" />
        <asp:ControlParameter ControlID="F_StatusID" PropertyName="Text" Name="StatusID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_CreatedBy" PropertyName="Text" Name="CreatedBy" Type="String" Size="8" />
        <asp:ControlParameter ControlID="F_ElementID" PropertyName="Text" Name="ElementID" Type="String" Size="8" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpdrCreate" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_PDRNo" />
    <asp:AsyncPostBackTrigger ControlID="F_SeverityOfDefectID" />
    <asp:AsyncPostBackTrigger ControlID="F_CategoryOfDefectID" />
    <asp:AsyncPostBackTrigger ControlID="F_ProjectID" />
    <asp:AsyncPostBackTrigger ControlID="F_DocumentID" />
    <asp:AsyncPostBackTrigger ControlID="F_StatusID" />
    <asp:AsyncPostBackTrigger ControlID="F_CreatedBy" />
    <asp:AsyncPostBackTrigger ControlID="F_ElementID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
