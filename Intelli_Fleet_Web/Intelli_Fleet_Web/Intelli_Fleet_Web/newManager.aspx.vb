Public Class newManager
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
        Dim Email As String
        Dim Password As String
        Dim ConfirmPassword As String
        Dim UType As Integer
        Dim Active As String
        Dim Sucess As Boolean
        Dim exist As Boolean
        Dim exist1 As Boolean

        Name = txtUName.Text
        Surname = txtUSurname.Text
        Email = txtUEmail.Text
        Username = txtUUsername.Text
        Password = txtUPassword.Text
        ConfirmPassword = txtUConfirm.Text
        UType = 3
        Active = "True"

        Dim Service As IntelliFleetServiceReference.Service1Client
        Service = New IntelliFleetServiceReference.Service1Client
        Sucess = Service.AddManager(Name, Surname, Username, Email, Password, ConfirmPassword, UType, Active)
        exist = Service.CheckExisting(Name, Surname, Username)
        exist1 = Service.CheckExistingUsername(Name, Surname, Username)

        If (Sucess = False) Then
            MsgBox("Entered passwords dont mactch.")

        ElseIf (exist = True) Then
            MsgBox("You are an existing inctive user, contact admin to activate account.")

        ElseIf (exist = True) Then
            MsgBox("Username taken, enter different username.")
        Else
            MsgBox("You have registered a manager successfully.")
            Response.Redirect("Manager.aspx")
        End If
    End Sub
End Class