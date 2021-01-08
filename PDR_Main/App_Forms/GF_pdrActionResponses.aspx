<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_pdrActionResponses.aspx.vb" Inherits="GF_pdrActionResponses" title="Maintain List: Action Responses" %>
<asp:Content ID="CPHpdrActionResponses" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpdrActionResponses" runat="server" Text="&nbsp;List: Action Responses"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpdrActionResponses" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpdrActionResponses"
      ToolType = "lgNMGrid"
      EditUrl = "~/PDR_Main/App_Edit/EF_pdrActionResponses.aspx"
      AddUrl = "~/PDR_Main/App_Create/AF_pdrActionResponses.aspx"
      AddPostBack = "True"
      ValidationGroup = "pdrActionResponses"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpdrActionResponses" runat="server" AssociatedUpdatePanelID="UPNLpdrActionResponses" DisplayAfter="100">
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
          <asp:TextBox
            ID = "F_PDRNo"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_PDRNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_PDRNo_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEPDRNo"
            BehaviorID="B_ACEPDRNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="PDRNoCompletionList"
            TargetControlID="F_PDRNo"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEPDRNo_Selected"
            OnClientPopulating="ACEPDRNo_Populating"
            OnClientPopulated="ACEPDRNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ActionNo" runat="server" Text="Action No :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ActionNo"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_ActionNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ActionNo_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEActionNo"
            BehaviorID="B_ACEActionNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ActionNoCompletionList"
            TargetControlID="F_ActionNo"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEActionNo_Selected"
            OnClientPopulating="ACEActionNo_Populating"
            OnClientPopulated="ACEActionNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVpdrActionResponses" SkinID="gv_silver" runat="server" DataSourceID="ODSpdrActionResponses" DataKeyNames="PDRNo,ActionNo,ResponseNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Response No" SortExpression="[PDR_ActionResponses].[ResponseNo]">
          <ItemTemplate>
            <asp:Label ID="LabelResponseNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ResponseNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Response Description" SortExpression="[PDR_ActionResponses].[ResponseDescription]">
          <ItemTemplate>
            <asp:Label ID="LabelResponseDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ResponseDescription") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Responded By" SortExpression="[aspnet_users1].[UserFullName]">
          <ItemTemplate>
             <asp:Label ID="L_RespondedBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("RespondedBy") %>' Text='<%# Eval("aspnet_users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Responded On" SortExpression="[PDR_ActionResponses].[RespondedOn]">
          <ItemTemplate>
            <asp:Label ID="LabelRespondedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RespondedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" SortExpression="[PDR_ActionResponses].[StatusID]">
          <ItemTemplate>
            <asp:Label ID="LabelStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("StatusID") %>'></asp:Label>
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
      ID = "ODSpdrActionResponses"
      runat = "server"
      DataObjectTypeName = "SIS.PDR.pdrActionResponses"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "pdrActionResponsesSelectList"
      TypeName = "SIS.PDR.pdrActionResponses"
      SelectCountMethod = "pdrActionResponsesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_PDRNo" PropertyName="Text" Name="PDRNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_ActionNo" PropertyName="Text" Name="ActionNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpdrActionResponses" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_PDRNo" />
    <asp:AsyncPostBackTrigger ControlID="F_ActionNo" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
