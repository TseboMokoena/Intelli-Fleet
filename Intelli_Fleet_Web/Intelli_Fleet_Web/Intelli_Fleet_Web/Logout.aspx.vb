Public Class Logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.Contents("UserType") > 0 Then

            Session.Contents("UserType") = Nothing
            Session.Contents("Username") = Nothing
            Response.Redirect("HomePage.aspx")
        End If

    End Sub

End Class