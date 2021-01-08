<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_pdrActionPlan.aspx.vb" Inherits="AF_pdrActionPlan" title="Add: Action Plan" %>
<asp:Content ID="CPHpdrActionPlan" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpdrActionPlan" runat="server" Text="&nbsp;Add: Action Plan"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpdrActionPlan" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpdrActionPlan"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "pdrActionPlan"
    runat = "server" />
<asp:FormView ID="FVpdrActionPlan"
  runat = "server"
  DataKeyNames = "PDRNo,ActionNo"
  DataSourceID = "ODSpdrActionPlan"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpdrActionPlan" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_PDRNo" ForeColor="#CC6633" runat="server" Text="PDR No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_PDRNo"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("PDRNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for PDR No."
            ValidationGroup = "pdrActionPlan"
            onblur= "script_pdrActionPlan.validate_PDRNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVPDRNo"
            runat = "server"
            ControlToValidate = "F_PDRNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pdrActionPlan"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_PDRNo_Display"
            Text='<%# Eval("PDR_Defects1_AnnexurePath") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEPDRNo"
            BehaviorID="B_ACEPDRNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="PDRNoCompletionList"
            TargetControlID="F_PDRNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pdrActionPlan.ACEPDRNo_Selected"
            OnClientPopulating="script_pdrActionPlan.ACEPDRNo_Populating"
            OnClientPopulated="script_pdrActionPlan.ACEPDRNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ActionNo" ForeColor="#CC6633" runat="server" Text="Action No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ActionNo" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ActionDescription" runat="server" Text="Action Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ActionDescription"
            Text='<%# Bind("ActionDescription") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pdrActionPlan"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Action Description."
            MaxLength="1000"
            Width="350px"
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
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Responsible" runat="server" Text="Responsible :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_Responsible"
            CssClass = "myfktxt"
            Width="72px"
            Text='<%# Bind("Responsible") %>'
            AutoCompleteType = "None"
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
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ResponsibleUsers" runat="server" Text="ResponsibleUsers :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ResponsibleUsers"
            Text='<%# Bind("ResponsibleUsers") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for ResponsibleUsers."
            MaxLength="250"
            Width="350px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Remarks" runat="server" Text="Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Remarks"
            Text='<%# Bind("Remarks") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
            MaxLength="500"
            Width="350px"
            runat="server" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpdrActionPlan"
  DataObjectTypeName = "SIS.PDR.pdrActionPlan"
  InsertMethod="pdrActionPlanInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PDR.pdrActionPlan"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
