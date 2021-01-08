Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PDR
  Partial Public Class pdrActionResponses
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      If StatusID = enumResponse.Submitted Then
        mRet = Drawing.Color.Green
      End If
      Return mRet
    End Function
    Public ReadOnly Property StatusName As String
      Get
        Return System.Enum.GetName(GetType(enumResponse), StatusID)
      End Get
    End Property
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      If StatusID = enumResponse.Free Then
        mRet = True
      End If
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      If StatusID = enumResponse.Free Then
        mRet = True
      End If
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DeleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        If StatusID = enumResponse.Free Then
          mRet = True
        End If
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DeleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function DeleteWF(ByVal PDRNo As Int32, ByVal ActionNo As Int32, ByVal ResponseNo As Int32) As SIS.PDR.pdrActionResponses
      Dim Results As SIS.PDR.pdrActionResponses = pdrActionResponsesGetByID(PDRNo, ActionNo, ResponseNo)
      SIS.PDR.pdrActionResponses.pdrActionResponsesDelete(Results)
      Return Results
    End Function
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        If StatusID = enumResponse.Free Then
          mRet = True
        End If
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function InitiateWF(ByVal PDRNo As Int32, ByVal ActionNo As Int32, ByVal ResponseNo As Int32) As SIS.PDR.pdrActionResponses
      Dim Results As SIS.PDR.pdrActionResponses = pdrActionResponsesGetByID(PDRNo, ActionNo, ResponseNo)
      Results.StatusID = enumResponse.Submitted
      Results.RespondedBy = HttpContext.Current.Session("LoginID")
      Results.RespondedOn = Now
      SIS.PDR.pdrActionResponses.UpdateData(Results)
      Dim tmp As SIS.PDR.pdrActionPlan = SIS.PDR.pdrActionPlan.pdrActionPlanGetByID(PDRNo, ActionNo)
      tmp.StatusID = enumAction.Responded
      SIS.PDR.pdrActionPlan.UpdateData(tmp)
      Dim tmp1 As SIS.PDR.pdrCreate = SIS.PDR.pdrCreate.pdrCreateGetByID(PDRNo)
      tmp1.StatusID = enumPdr.ResponsesReceived
      SIS.PDR.pdrCreate.UpdateData(tmp1)
      Return Results
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_PDRNo"), TextBox).Text = ""
        CType(.FindControl("F_PDRNo_Display"), Label).Text = ""
        CType(.FindControl("F_ActionNo"), TextBox).Text = ""
        CType(.FindControl("F_ActionNo_Display"), Label).Text = ""
        CType(.FindControl("F_ResponseNo"), TextBox).Text = ""
        CType(.FindControl("F_ResponseDescription"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
