<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pdrSubmitResponse.ascx.vb" Inherits="LC_pdrSubmitResponse" %>
<asp:DropDownList 
  ID = "DDLpdrSubmitResponse"
  DataSourceID = "OdsDdlpdrSubmitResponse"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpdrSubmitResponse"
  Runat = "server" 
  ControlToValidate = "DDLpdrSubmitResponse"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpdrSubmitResponse"
  TypeName = "SIS.PDR.pdrSubmitResponse"
  SortParameterName = "OrderBy"
  SelectMethod = "pdrSubmitResponseSelectList"
  Runat="server" />
