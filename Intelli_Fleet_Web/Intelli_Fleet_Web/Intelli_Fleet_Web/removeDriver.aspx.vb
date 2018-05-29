Public Class removeDriver
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.Contents("UserName") = Nothing Then
            Response.Redirect("SignIn.aspx")
        End If

    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim Name As String
        Dim Surname As String
        Dim Username As String
      


        Name = txtUName.Text
        Surname = txtUSurname.Text
        Username = txtUUsername.Text

        Dim Service As IntelliFleetServiceReference.Service1Client
        Service = New IntelliFleetServiceReference.Service1Client

        If (Service.getDrivername(Username) = Name) Then
            If (Service.getDriverSurname(Username) = Surname) Then

                Service.removeDriver(Username)

            End If
        End If



        Response.Redirect("ViewDrivers.aspx")

    End Sub
End Class