Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PDR
  Partial Public Class pdrActionPlan
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Select Case StatusID
        Case enumAction.Freezed
          mRet = Drawing.Color.Green
        Case enumAction.Responded
          mRet = Drawing.Color.DarkGoldenrod
        Case enumAction.Completed
          mRet = Drawing.Color.Purple
      End Select
      Return mRet
    End Function
    Public ReadOnly Property StatusName As String
      Get
        Return System.Enum.GetName(GetType(enumAction), StatusID)
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
      Select Case StatusID
        Case enumAction.Free
          mRet = True
      End Select
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      Select Case StatusID
        Case enumAction.Free
          mRet = True
      End Select
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
        Select Case StatusID
          Case enumAction.Free
            mRet = True
        End Select
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
    Public Shared Function DeleteWF(ByVal PDRNo As Int32, ByVal ActionNo As Int32) As SIS.PDR.pdrActionPlan
      Dim Results As SIS.PDR.pdrActionPlan = pdrActionPlanGetByID(PDRNo, ActionNo)
      SIS.PDR.pdrActionPlan.pdrActionPlanDelete(Results)
      Return Results
    End Function
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Select Case StatusID
          Case enumAction.Free
            mRet = True
        End Select
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
    Public Shared Function InitiateWF(ByVal PDRNo As Int32, ByVal ActionNo As Int32) As SIS.PDR.pdrActionPlan
      Dim Results As SIS.PDR.pdrActionPlan = pdrActionPlanGetByID(PDRNo, ActionNo)
      Results.StatusID = enumAction.Freezed
      SIS.PDR.pdrActionPlan.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_PDRNo"), TextBox).Text = ""
        CType(.FindControl("F_PDRNo_Display"), Label).Text = ""
        CType(.FindControl("F_ActionNo"), TextBox).Text = ""
        CType(.FindControl("F_ActionDescription"), TextBox).Text = ""
        CType(.FindControl("F_Responsible"), TextBox).Text = ""
        CType(.FindControl("F_ResponsibleUsers"), TextBox).Text = ""
        CType(.FindControl("F_Remarks"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
