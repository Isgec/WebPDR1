<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pdrSeverity.aspx.vb" Inherits="EF_pdrSeverity" title="Edit: Severities Of Defect" %>
<asp:Content ID="CPHpdrSeverity" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpdrSeverity" runat="server" Text="&nbsp;Edit: Severities Of Defect"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpdrSeverity" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpdrSeverity"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "pdrSeverity"
    runat = "server" />
<asp:FormView ID="FVpdrSeverity"
  runat = "server"
  DataKeyNames = "SeverityID"
  DataSourceID = "ODSpdrSeverity"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SeverityID" runat="server" ForeColor="#CC6633" Text="Severity ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SeverityID"
            Text='<%# Bind("SeverityID") %>'
            ToolTip="Value of Severity ID."
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
          <asp:Label ID="L_SeverityDescription" runat="server" Text="Severity Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SeverityDescription"
            Text='<%# Bind("SeverityDescription") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pdrSeverity"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Severity Description."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVSeverityDescription"
            runat = "server"
            ControlToValidate = "F_SeverityDescription"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pdrSeverity"
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
  ID = "ODSpdrSeverity"
  DataObjectTypeName = "SIS.PDR.pdrSeverity"
  SelectMethod = "pdrSeverityGetByID"
  UpdateMethod="pdrSeverityUpdate"
  DeleteMethod="pdrSeverityDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PDR.pdrSeverity"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SeverityID" Name="SeverityID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
