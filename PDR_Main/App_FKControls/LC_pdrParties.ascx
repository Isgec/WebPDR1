<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pdrParties.ascx.vb" Inherits="LC_pdrParties" %>
<asp:DropDownList 
  ID = "DDLpdrParties"
  DataSourceID = "OdsDdlpdrParties"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpdrParties"
  Runat = "server" 
  ControlToValidate = "DDLpdrParties"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpdrParties"
  TypeName = "SIS.PDR.pdrParties"
  SortParameterName = "OrderBy"
  SelectMethod = "pdrPartiesSelectList"
  Runat="server" />
