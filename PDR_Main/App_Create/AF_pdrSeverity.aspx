<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_pdrSeverity.aspx.vb" Inherits="AF_pdrSeverity" title="Add: Severities Of Defect" %>
<asp:Content ID="CPHpdrSeverity" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpdrSeverity" runat="server" Text="&nbsp;Add: Severities Of Defect"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpdrSeverity" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpdrSeverity"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "pdrSeverity"
    runat = "server" />
<asp:FormView ID="FVpdrSeverity"
  runat = "server"
  DataKeyNames = "SeverityID"
  DataSourceID = "ODSpdrSeverity"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpdrSeverity" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SeverityID" ForeColor="#CC6633" runat="server" Text="Severity ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SeverityID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SeverityDescription" runat="server" Text="Severity Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SeverityDescription"
            Text='<%# Bind("SeverityDescription") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pdrSeverity"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Severity Description."
            MaxLength="50"
            Width="408px"
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpdrSeverity"
  DataObjectTypeName = "SIS.PDR.pdrSeverity"
  InsertMethod="pdrSeverityInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PDR.pdrSeverity"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
