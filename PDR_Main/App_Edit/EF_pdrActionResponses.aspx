<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pdrActionResponses.aspx.vb" Inherits="EF_pdrActionResponses" title="Edit: Action Responses" %>
<asp:Content ID="CPHpdrActionResponses" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpdrActionResponses" runat="server" Text="&nbsp;Edit: Action Responses"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpdrActionResponses" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpdrActionResponses"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "pdrActionResponses"
    runat = "server" />
<asp:FormView ID="FVpdrActionResponses"
  runat = "server"
  DataKeyNames = "PDRNo,ActionNo,ResponseNo"
  DataSourceID = "ODSpdrActionResponses"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_PDRNo" runat="server" ForeColor="#CC6633" Text="PDR No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_PDRNo"
            Width="88px"
            Text='<%# Bind("PDRNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of PDR No."
            Runat="Server" />
          <asp:Label
            ID = "F_PDRNo_Display"
            Text='<%# Eval("PDR_Defects3_AnnexurePath") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ActionNo" runat="server" ForeColor="#CC6633" Text="Action No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ActionNo"
            Width="88px"
            Text='<%# Bind("ActionNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Action No."
            Runat="Server" />
          <asp:Label
            ID = "F_ActionNo_Display"
            Text='<%# Eval("PDR_Actions2_Responsible") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ResponseNo" runat="server" ForeColor="#CC6633" Text="Response No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ResponseNo"
            Text='<%# Bind("ResponseNo") %>'
            ToolTip="Value of Response No."
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
          <asp:Label ID="L_ResponseDescription" runat="server" Text="Response Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ResponseDescription"
            Text='<%# Bind("ResponseDescription") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pdrActionResponses"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Response Description."
            MaxLength="1000"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVResponseDescription"
            runat = "server"
            ControlToValidate = "F_ResponseDescription"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pdrActionResponses"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_RespondedBy" runat="server" Text="Responded By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_RespondedBy"
            Width="72px"
            Text='<%# Bind("RespondedBy") %>'
            Enabled = "False"
            ToolTip="Value of Responded By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_RespondedBy_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_RespondedOn" runat="server" Text="Responded On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_RespondedOn"
            Text='<%# Bind("RespondedOn") %>'
            ToolTip="Value of Responded On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_StatusID" runat="server" Text="Status :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:DropDownList
            ID="F_StatusID"
            SelectedValue='<%# Bind("StatusID") %>'
            Width="200px"
            Enabled = "False"
            CssClass = "dmyddl"
            Runat="Server" >
            <asp:ListItem Value="0">---ALL---</asp:ListItem>
            <asp:ListItem Value="1">Free</asp:ListItem>
            <asp:ListItem Value="2">Submitted</asp:ListItem>
          </asp:DropDownList>
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
  ID = "ODSpdrActionResponses"
  DataObjectTypeName = "SIS.PDR.pdrActionResponses"
  SelectMethod = "pdrActionResponsesGetByID"
  UpdateMethod="pdrActionResponsesUpdate"
  DeleteMethod="pdrActionResponsesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PDR.pdrActionResponses"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="PDRNo" Name="PDRNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ActionNo" Name="ActionNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ResponseNo" Name="ResponseNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
