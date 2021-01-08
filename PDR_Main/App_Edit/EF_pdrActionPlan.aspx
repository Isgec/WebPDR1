<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pdrActionPlan.aspx.vb" Inherits="EF_pdrActionPlan" title="Edit: Action Plan" %>
<asp:Content ID="CPHpdrActionPlan" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpdrActionPlan" runat="server" Text="&nbsp;Edit: Action Plan"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpdrActionPlan" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpdrActionPlan"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnablePrint = "False"
    PrintUrl = "../App_Print/RP_pdrActionPlan.aspx?pk="
    ValidationGroup = "pdrActionPlan"
    runat = "server" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        url = o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
<asp:FormView ID="FVpdrActionPlan"
  runat = "server"
  DataKeyNames = "PDRNo,ActionNo"
  DataSourceID = "ODSpdrActionPlan"
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
            Text='<%# Eval("PDR_Defects1_AnnexurePath") %>'
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
          <asp:TextBox ID="F_ActionNo"
            Text='<%# Bind("ActionNo") %>'
            ToolTip="Value of Action No."
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
          <asp:Label ID="L_ActionDescription" runat="server" Text="Action Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ActionDescription"
            Text='<%# Bind("ActionDescription") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pdrActionPlan"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Action Description."
            MaxLength="1000"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVActionDescription"
            runat = "server"
            ControlToValidate = "F_ActionDescription"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pdrActionPlan"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Responsible" runat="server" Text="Responsible :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_Responsible"
            CssClass = "myfktxt"
            Text='<%# Bind("Responsible") %>'
            AutoCompleteType = "None"
            Width="72px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Responsible."
            ValidationGroup = "pdrActionPlan"
            onblur= "script_pdrActionPlan.validate_Responsible(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVResponsible"
            runat = "server"
            ControlToValidate = "F_Responsible"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pdrActionPlan"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_Responsible_Display"
            Text='<%# Eval("aspnet_users2_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEResponsible"
            BehaviorID="B_ACEResponsible"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ResponsibleCompletionList"
            TargetControlID="F_Responsible"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pdrActionPlan.ACEResponsible_Selected"
            OnClientPopulating="script_pdrActionPlan.ACEResponsible_Populating"
            OnClientPopulated="script_pdrActionPlan.ACEResponsible_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ResponsibleUsers" runat="server" Text="ResponsibleUsers :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ResponsibleUsers"
            Text='<%# Bind("ResponsibleUsers") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for ResponsibleUsers."
            MaxLength="250"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Remarks" runat="server" Text="Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Remarks"
            Text='<%# Bind("Remarks") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
            MaxLength="500"
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
            <asp:ListItem Value="2">Freezed</asp:ListItem>
            <asp:ListItem Value="3">Responded</asp:ListItem>
            <asp:ListItem Value="4">Completed</asp:ListItem>
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
  ID = "ODSpdrActionPlan"
  DataObjectTypeName = "SIS.PDR.pdrActionPlan"
  SelectMethod = "pdrActionPlanGetByID"
  UpdateMethod="pdrActionPlanUpdate"
  DeleteMethod="pdrActionPlanDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PDR.pdrActionPlan"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="PDRNo" Name="PDRNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ActionNo" Name="ActionNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
