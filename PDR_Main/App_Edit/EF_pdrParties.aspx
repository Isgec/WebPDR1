<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pdrParties.aspx.vb" Inherits="EF_pdrParties" title="Edit: Debitable Parties" %>
<asp:Content ID="CPHpdrParties" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpdrParties" runat="server" Text="&nbsp;Edit: Debitable Parties"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpdrParties" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpdrParties"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "pdrParties"
    runat = "server" />
<asp:FormView ID="FVpdrParties"
  runat = "server"
  DataKeyNames = "PartyID"
  DataSourceID = "ODSpdrParties"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_PartyID" runat="server" ForeColor="#CC6633" Text="Party ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_PartyID"
            Text='<%# Bind("PartyID") %>'
            ToolTip="Value of Party ID."
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
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pdrParties"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pdrParties"
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
  ID = "ODSpdrParties"
  DataObjectTypeName = "SIS.PDR.pdrParties"
  SelectMethod = "pdrPartiesGetByID"
  UpdateMethod="pdrPartiesUpdate"
  DeleteMethod="pdrPartiesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PDR.pdrParties"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="PartyID" Name="PartyID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
