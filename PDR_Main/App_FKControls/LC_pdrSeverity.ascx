<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pdrSeverity.ascx.vb" Inherits="LC_pdrSeverity" %>
<asp:DropDownList 
  ID = "DDLpdrSeverity"
  DataSourceID = "OdsDdlpdrSeverity"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpdrSeverity"
  Runat = "server" 
  ControlToValidate = "DDLpdrSeverity"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpdrSeverity"
  TypeName = "SIS.PDR.pdrSeverity"
  SortParameterName = "OrderBy"
  SelectMethod = "pdrSeveritySelectList"
  Runat="server" />
