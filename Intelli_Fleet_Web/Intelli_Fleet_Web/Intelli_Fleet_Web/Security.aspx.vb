Public Class Security
    Inherits System.Web.UI.Page
    Private Service As IntelliFleetServiceReference.Service1Client
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Service = New IntelliFleetServiceReference.Service1Client
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim Username As String = txtUsername.Text
        Dim newpass As String = txtNpass.Text
        Dim cpass As String = txtCpass.Text

        If cpass = newpass Then

            Service.forgotPassword(Username, cpass)

            Response.Redirect("SignIn.aspx")

        Else

        End If



    End Sub
End Class