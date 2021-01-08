<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_pdrSeverity.aspx.vb" Inherits="GF_pdrSeverity" title="Maintain List: Severities Of Defect" %>
<asp:Content ID="CPHpdrSeverity" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpdrSeverity" runat="server" Text="&nbsp;List: Severities Of Defect"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpdrSeverity" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpdrSeverity"
      ToolType = "lgNMGrid"
      EditUrl = "~/PDR_Main/App_Edit/EF_pdrSeverity.aspx"
      AddUrl = "~/PDR_Main/App_Create/AF_pdrSeverity.aspx"
      ValidationGroup = "pdrSeverity"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpdrSeverity" runat="server" AssociatedUpdatePanelID="UPNLpdrSeverity" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpdrSeverity" SkinID="gv_silver" runat="server" DataSourceID="ODSpdrSeverity" DataKeyNames="SeverityID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Severity ID" SortExpression="[PDR_severity].[SeverityID]">
          <ItemTemplate>
            <asp:Label ID="LabelSeverityID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SeverityID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Severity Description" SortExpression="[PDR_severity].[SeverityDescription]">
          <ItemTemplate>
            <asp:Label ID="LabelSeverityDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SeverityDescription") %>'></asp:Label>
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
      ID = "ODSpdrSeverity"
      runat = "server"
      DataObjectTypeName = "SIS.PDR.pdrSeverity"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "pdrSeveritySelectList"
      TypeName = "SIS.PDR.pdrSeverity"
      SelectCountMethod = "pdrSeveritySelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVpdrSeverity" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
