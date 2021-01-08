<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pdrCategory.aspx.vb" Inherits="EF_pdrCategory" title="Edit: Categories of Defect" %>
<asp:Content ID="CPHpdrCategory" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpdrCategory" runat="server" Text="&nbsp;Edit: Categories of Defect"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpdrCategory" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpdrCategory"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "pdrCategory"
    runat = "server" />
<asp:FormView ID="FVpdrCategory"
  runat = "server"
  DataKeyNames = "CategoryID"
  DataSourceID = "ODSpdrCategory"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CategoryID" runat="server" ForeColor="#CC6633" Text="Category ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CategoryID"
            Text='<%# Bind("CategoryID") %>'
            ToolTip="Value of Category ID."
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
          <asp:Label ID="L_CategoryDescription" runat="server" Text="Category Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CategoryDescription"
            Text='<%# Bind("CategoryDescription") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pdrCategory"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Category Description."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCategoryDescription"
            runat = "server"
            ControlToValidate = "F_CategoryDescription"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pdrCategory"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpdrCategory"
  DataObjectTypeName = "SIS.PDR.pdrCategory"
  SelectMethod = "pdrCategoryGetByID"
  UpdateMethod="pdrCategoryUpdate"
  DeleteMethod="pdrCategoryDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PDR.pdrCategory"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CategoryID" Name="CategoryID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
