<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_pdrActionResponses.aspx.vb" Inherits="AF_pdrActionResponses" title="Add: Action Responses" %>
<asp:Content ID="CPHpdrActionResponses" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpdrActionResponses" runat="server" Text="&nbsp;Add: Action Responses"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpdrActionResponses" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpdrActionResponses"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "pdrActionResponses"
    runat = "server" />
<asp:FormView ID="FVpdrActionResponses"
  runat = "server"
  DataKeyNames = "PDRNo,ActionNo,ResponseNo"
  DataSourceID = "ODSpdrActionResponses"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpdrActionResponses" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
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
            ValidationGroup = "pdrActionResponses"
            onblur= "script_pdrActionResponses.validate_PDRNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVPDRNo"
            runat = "server"
            ControlToValidate = "F_PDRNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pdrActionResponses"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_PDRNo_Display"
            Text='<%# Eval("PDR_Defects3_AnnexurePath") %>'
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
            OnClientItemSelected="script_pdrActionResponses.ACEPDRNo_Selected"
            OnClientPopulating="script_pdrActionResponses.ACEPDRNo_Populating"
            OnClientPopulated="script_pdrActionResponses.ACEPDRNo_Populated"
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
          <asp:TextBox
            ID = "F_ActionNo"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("ActionNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Action No."
            ValidationGroup = "pdrActionResponses"
            onblur= "script_pdrActionResponses.validate_ActionNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVActionNo"
            runat = "server"
            ControlToValidate = "F_ActionNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pdrActionResponses"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ActionNo_Display"
            Text='<%# Eval("PDR_Actions2_Responsible") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEActionNo"
            BehaviorID="B_ACEActionNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ActionNoCompletionList"
            TargetControlID="F_ActionNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pdrActionResponses.ACEActionNo_Selected"
            OnClientPopulating="script_pdrActionResponses.ACEActionNo_Populating"
            OnClientPopulated="script_pdrActionResponses.ACEActionNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ResponseNo" ForeColor="#CC6633" runat="server" Text="Response No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ResponseNo" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ResponseDescription" runat="server" Text="Response Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ResponseDescription"
            Text='<%# Bind("ResponseDescription") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pdrActionResponses"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Response Description."
            MaxLength="1000"
            Width="350px"
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpdrActionResponses"
  DataObjectTypeName = "SIS.PDR.pdrActionResponses"
  InsertMethod="pdrActionResponsesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PDR.pdrActionResponses"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
