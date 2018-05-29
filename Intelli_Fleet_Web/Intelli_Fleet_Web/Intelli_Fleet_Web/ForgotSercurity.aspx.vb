Public Class ForgotSercurity
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim Service As IntelliFleetServiceReference.Service1Client
        Service = New IntelliFleetServiceReference.Service1Client
     
        Dim username As String = txtUUsername.Text
        Service = New IntelliFleetServiceReference.Service1Client
        Dim Question As String = ddlQuestions.SelectedValue
        Dim ans As String = txtAns.Text
        Dim state As Boolean = False
        state = Service.SercurityPur(username, question, ans)

        If state = True Then
            Response.Redirect("Security.aspx")
        Else

        End If
    End Sub
End Class