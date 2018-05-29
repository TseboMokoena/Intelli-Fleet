Public Class Registration
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    'Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    'End Sub

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
        Dim match As Boolean = False

        Name = txtUName.Text
        Surname = txtUSurname.Text
        Email = txtUEmail.Text
        Username = txtUUsername.Text
        Password = txtUPassword.Text
        ConfirmPassword = txtUConfirm.Text
        ' Dim question As String = sel1.TagName
        Dim Question As String = ddlQuestions.SelectedValue
        Dim ans As String = txtAns.Text
        UType = 1
        Active = "True"

        Dim Service As IntelliFleetServiceReference.Service1Client
        Service = New IntelliFleetServiceReference.Service1Client

        exist = Service.CheckExisting(Name, Surname, Username)
        exist1 = Service.CheckExistingUsername(Name, Surname, Username)

        If (Password = ConfirmPassword) Then
            match = True
        End If

        If (match = False) Then

            Dim Alert As String = "<div class=""alert""><span class=""closebtn"">&times;</span>" +
                    " <strong>Error!</strong> Entered passwords dont mactch..</div>"
            AlertCode.InnerHtml = Alert

        ElseIf (exist = True) Then

            Dim Alert As String = "<div class=""alert""><span class=""closebtn"">&times;</span>" +
                 " <strong>You are an existing inctive user!</strong> Contact admin to reactivate account.</div>"

            AlertCode.InnerHtml = Alert

        ElseIf (exist1 = True) Then

            Dim Alert As String = "<div class=""alert""><span class=""closebtn"">&times;</span>" +
                " <strong>Username taken!</strong> Enter different username.</div>"



        ElseIf (match = True) Then

            Sucess = Service.Register(Name, Surname, Username, Email, Password, ConfirmPassword, UType, Active, Question, ans)
            Dim Alert As String = " <script type=""text/javascript"">alert(""You have registered successfully"")</script>"
            AlertScript.InnerHtml = Alert

            Response.Redirect("SignIn.aspx")
        End If
    End Sub

End Class