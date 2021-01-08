<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_pdrCategory.aspx.vb" Inherits="GF_pdrCategory" title="Maintain List: Categories of Defect" %>
<asp:Content ID="CPHpdrCategory" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpdrCategory" runat="server" Text="&nbsp;List: Categories of Defect"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpdrCategory" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpdrCategory"
      ToolType = "lgNMGrid"
      EditUrl = "~/PDR_Main/App_Edit/EF_pdrCategory.aspx"
      AddUrl = "~/PDR_Main/App_Create/AF_pdrCategory.aspx"
      ValidationGroup = "pdrCategory"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpdrCategory" runat="server" AssociatedUpdatePanelID="UPNLpdrCategory" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpdrCategory" SkinID="gv_silver" runat="server" DataSourceID="ODSpdrCategory" DataKeyNames="CategoryID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Category ID" SortExpression="[PDR_Category].[CategoryID]">
          <ItemTemplate>
            <asp:Label ID="LabelCategoryID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CategoryID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Category Description" SortExpression="[PDR_Category].[CategoryDescription]">
          <ItemTemplate>
            <asp:Label ID="LabelCategoryDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CategoryDescription") %>'></asp:Label>
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
      ID = "ODSpdrCategory"
      runat = "server"
      DataObjectTypeName = "SIS.PDR.pdrCategory"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "pdrCategorySelectList"
      TypeName = "SIS.PDR.pdrCategory"
      SelectCountMethod = "pdrCategorySelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVpdrCategory" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
