<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pdrCategory.ascx.vb" Inherits="LC_pdrCategory" %>
<asp:DropDownList 
  ID = "DDLpdrCategory"
  DataSourceID = "OdsDdlpdrCategory"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpdrCategory"
  Runat = "server" 
  ControlToValidate = "DDLpdrCategory"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpdrCategory"
  TypeName = "SIS.PDR.pdrCategory"
  SortParameterName = "OrderBy"
  SelectMethod = "pdrCategorySelectList"
  Runat="server" />
