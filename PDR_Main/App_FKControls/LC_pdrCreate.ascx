<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pdrCreate.ascx.vb" Inherits="LC_pdrCreate" %>
<asp:DropDownList 
  ID = "DDLpdrCreate"
  DataSourceID = "OdsDdlpdrCreate"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpdrCreate"
  Runat = "server" 
  ControlToValidate = "DDLpdrCreate"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpdrCreate"
  TypeName = "SIS.PDR.pdrCreate"
  SortParameterName = "OrderBy"
  SelectMethod = "pdrCreateSelectList"
  Runat="server" />
