<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pdrActionPlan.ascx.vb" Inherits="LC_pdrActionPlan" %>
<asp:DropDownList 
  ID = "DDLpdrActionPlan"
  DataSourceID = "OdsDdlpdrActionPlan"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpdrActionPlan"
  Runat = "server" 
  ControlToValidate = "DDLpdrActionPlan"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpdrActionPlan"
  TypeName = "SIS.PDR.pdrActionPlan"
  SortParameterName = "OrderBy"
  SelectMethod = "pdrActionPlanSelectList"
  Runat="server" />
