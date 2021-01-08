<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pdrReview.ascx.vb" Inherits="LC_pdrReview" %>
<asp:DropDownList 
  ID = "DDLpdrReview"
  DataSourceID = "OdsDdlpdrReview"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpdrReview"
  Runat = "server" 
  ControlToValidate = "DDLpdrReview"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpdrReview"
  TypeName = "SIS.PDR.pdrReview"
  SortParameterName = "OrderBy"
  SelectMethod = "pdrReviewSelectList"
  Runat="server" />
