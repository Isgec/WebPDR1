<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_pdrParties.aspx.vb" Inherits="GF_pdrParties" title="Maintain List: Debitable Parties" %>
<asp:Content ID="CPHpdrParties" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpdrParties" runat="server" Text="&nbsp;List: Debitable Parties"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpdrParties" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpdrParties"
      ToolType = "lgNMGrid"
      EditUrl = "~/PDR_Main/App_Edit/EF_pdrParties.aspx"
      AddUrl = "~/PDR_Main/App_Create/AF_pdrParties.aspx"
      ValidationGroup = "pdrParties"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpdrParties" runat="server" AssociatedUpdatePanelID="UPNLpdrParties" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpdrParties" SkinID="gv_silver" runat="server" DataSourceID="ODSpdrParties" DataKeyNames="PartyID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Party ID" SortExpression="[PDR_Parties].[PartyID]">
          <ItemTemplate>
            <asp:Label ID="LabelPartyID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PartyID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="[PDR_Parties].[Description]">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpdrParties"
      runat = "server"
      DataObjectTypeName = "SIS.PDR.pdrParties"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "pdrPartiesSelectList"
      TypeName = "SIS.PDR.pdrParties"
      SelectCountMethod = "pdrPartiesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpdrParties" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
