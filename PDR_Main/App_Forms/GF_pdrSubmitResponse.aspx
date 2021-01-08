<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_pdrSubmitResponse.aspx.vb" Inherits="GF_pdrSubmitResponse" title="Maintain List: Submit Response" %>
<asp:Content ID="CPHpdrSubmitResponse" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpdrSubmitResponse" runat="server" Text="&nbsp;List: Submit Response"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpdrSubmitResponse" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpdrSubmitResponse"
      ToolType = "lgNMGrid"
      EditUrl = "~/PDR_Main/App_Edit/EF_pdrSubmitResponse.aspx"
      EnableAdd = "False"
      ValidationGroup = "pdrSubmitResponse"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpdrSubmitResponse" runat="server" AssociatedUpdatePanelID="UPNLpdrSubmitResponse" DisplayAfter="100">
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
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVpdrSubmitResponse" SkinID="gv_silver" runat="server" DataSourceID="ODSpdrSubmitResponse" DataKeyNames="PDRNo,ActionNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
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
          <ItemStyle CssClass="alignleft" />
        <HeaderStyle CssClass="alignleft" Width="300px" />
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
        <asp:TemplateField HeaderText="Task Completed">
          <ItemTemplate>
            <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Comploete the task" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Complete the Task ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
      ID = "ODSpdrSubmitResponse"
      runat = "server"
      DataObjectTypeName = "SIS.PDR.pdrSubmitResponse"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_pdrSubmitResponseSelectList"
      TypeName = "SIS.PDR.pdrSubmitResponse"
      SelectCountMethod = "pdrSubmitResponseSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVpdrSubmitResponse" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_PDRNo" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
