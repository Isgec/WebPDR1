<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_pdrCategory.aspx.vb" Inherits="AF_pdrCategory" title="Add: Categories of Defect" %>
<asp:Content ID="CPHpdrCategory" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpdrCategory" runat="server" Text="&nbsp;Add: Categories of Defect"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpdrCategory" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpdrCategory"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "pdrCategory"
    runat = "server" />
<asp:FormView ID="FVpdrCategory"
  runat = "server"
  DataKeyNames = "CategoryID"
  DataSourceID = "ODSpdrCategory"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpdrCategory" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CategoryID" ForeColor="#CC6633" runat="server" Text="Category ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CategoryID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CategoryDescription" runat="server" Text="Category Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CategoryDescription"
            Text='<%# Bind("CategoryDescription") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pdrCategory"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Category Description."
            MaxLength="50"
            Width="408px"
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpdrCategory"
  DataObjectTypeName = "SIS.PDR.pdrCategory"
  InsertMethod="pdrCategoryInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PDR.pdrCategory"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
