<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pdrSubmitResponse.aspx.vb" Inherits="EF_pdrSubmitResponse" title="Edit: Submit Response" %>
<asp:Content ID="CPHpdrSubmitResponse" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpdrSubmitResponse" runat="server" Text="&nbsp;Edit: Submit Response"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpdrSubmitResponse" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpdrSubmitResponse"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "pdrSubmitResponse"
    runat = "server" />
<asp:FormView ID="FVpdrSubmitResponse"
  runat = "server"
  DataKeyNames = "PDRNo,ActionNo"
  DataSourceID = "ODSpdrSubmitResponse"
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
            ValidationGroup="pdrSubmitResponse"
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
            ValidationGroup = "pdrSubmitResponse"
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
            ValidationGroup = "pdrSubmitResponse"
            onblur= "script_pdrSubmitResponse.validate_Responsible(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVResponsible"
            runat = "server"
            ControlToValidate = "F_Responsible"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pdrSubmitResponse"
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
            OnClientItemSelected="script_pdrSubmitResponse.ACEResponsible_Selected"
            OnClientPopulating="script_pdrSubmitResponse.ACEResponsible_Populating"
            OnClientPopulated="script_pdrSubmitResponse.ACEResponsible_Populated"
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
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelpdrActionResponses" runat="server" Text="&nbsp;List: Action Responses"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpdrActionResponses" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpdrActionResponses"
      ToolType = "lgNMGrid"
      EditUrl = "~/PDR_Main/App_Edit/EF_pdrActionResponses.aspx"
      AddUrl = "~/PDR_Main/App_Create/AF_pdrActionResponses.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      ValidationGroup = "pdrActionResponses"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpdrActionResponses" runat="server" AssociatedUpdatePanelID="UPNLpdrActionResponses" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpdrActionResponses" SkinID="gv_silver" runat="server" DataSourceID="ODSpdrActionResponses" DataKeyNames="PDRNo,ActionNo,ResponseNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Response No" SortExpression="[PDR_ActionResponses].[ResponseNo]">
          <ItemTemplate>
            <asp:Label ID="LabelResponseNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ResponseNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Response Description" SortExpression="[PDR_ActionResponses].[ResponseDescription]">
          <ItemTemplate>
            <asp:Label ID="LabelResponseDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ResponseDescription") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Responded By" SortExpression="[aspnet_users1].[UserFullName]">
          <ItemTemplate>
             <asp:Label ID="L_RespondedBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("RespondedBy") %>' Text='<%# Eval("aspnet_users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Responded On" SortExpression="[PDR_ActionResponses].[RespondedOn]">
          <ItemTemplate>
            <asp:Label ID="LabelRespondedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RespondedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" SortExpression="[PDR_ActionResponses].[StatusID]">
          <ItemTemplate>
            <asp:Label ID="LabelStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Eval("StatusName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Submit">
          <ItemTemplate>
            <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Submit Response" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Submit Response ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpdrActionResponses"
      runat = "server"
      DataObjectTypeName = "SIS.PDR.pdrActionResponses"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "pdrActionResponsesSelectList"
      TypeName = "SIS.PDR.pdrActionResponses"
      SelectCountMethod = "pdrActionResponsesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ActionNo" PropertyName="Text" Name="ActionNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_PDRNo" PropertyName="Text" Name="PDRNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpdrActionResponses" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpdrSubmitResponse"
  DataObjectTypeName = "SIS.PDR.pdrSubmitResponse"
  SelectMethod = "pdrSubmitResponseGetByID"
  UpdateMethod="pdrSubmitResponseUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PDR.pdrSubmitResponse"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="PDRNo" Name="PDRNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ActionNo" Name="ActionNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
