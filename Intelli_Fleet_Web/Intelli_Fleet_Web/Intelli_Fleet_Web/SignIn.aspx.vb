Public Class SignIn
    Inherits System.Web.UI.Page
    Private Service As IntelliFleetServiceReference.Service1Client
    Shared Username As String
    Private password As String
    Private Alert As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Service = New IntelliFleetServiceReference.Service1Client
    End Sub


    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim state As Integer

        Username = txtUsername.Text
        password = txtPassword.Text

        ' Username = "client2"
        'Username = "Admin"
        'password = "12345"

        state = Service.Usertype(Username, password)


        If (state = -1) Then
            '  MsgBox("Inactive user! Contact admin to reactivate account")
            Alert = "<div class=""alert""><span class=""closebtn"">&times;</span>" +
                    " <strong>Inactive user!</strong> Contact admin to reactivate account.</div>"

            AlertCode.InnerHtml = Alert

        ElseIf (state = 0) Then
            '   MsgBox("Invalid login details! Check details and try again ")
            Alert = "<div class=""alert""><span class=""closebtn"">&times;</span>" +
                    " <strong>Invalid login details</strong> Check details and try again.</div>"

            AlertCode.InnerHtml = Alert

        ElseIf (state = 1) Then

            Session("UserType") = 1
            Session("Username") = Service.GetName(Username, password)
            Response.Redirect("HomePage.aspx")

        ElseIf (state = 2) Then
            Session("UserType") = 2
            Session("Username") = Service.GetName(Username, password)
            Response.Redirect("HomePage.aspx")

        ElseIf (state = 3) Then
            Session("UserType") = 3
            Session("Username") = Service.GetName(Username, password)
            Response.Redirect("HomePage.aspx")
        End If
    End Sub
End Class