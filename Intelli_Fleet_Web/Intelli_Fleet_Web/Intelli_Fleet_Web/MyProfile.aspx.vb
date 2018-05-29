Public Class MyProfile
    Inherits System.Web.UI.Page
    Private Service As IntelliFleetServiceReference.Service1Client
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.Contents("UserName") = Nothing Then
            Response.Redirect("SignIn.aspx")
        End If
        Dim username As String = Session.Contents("UserName")
        Service = New IntelliFleetServiceReference.Service1Client
        lblName.Text = Service.GetNames(username)
        lblSurname.Text = Service.GetSurname(username)
        lblEmail.Text = Service.GetEmail(username)

     


    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        Dim username As String = Session.Contents("UserName")
        Dim Name As String = txtUName.Text
        Dim surname As String = TxtSurname.Text
        Dim Uname As String = txtUName.Text
        Dim email As String = TxtEmail.Text
        Dim pass As String = txtCPassword.Text
        Dim Cpass As String = txtCPassword.Text

        If pass = Cpass Then

            Service.editInfo(username, Name, surname, Uname, email, pass)


        Else

        End If
    End Sub
End Class