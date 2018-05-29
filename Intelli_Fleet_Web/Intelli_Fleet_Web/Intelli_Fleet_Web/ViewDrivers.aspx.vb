Public Class ViewDrivers1
    Inherits System.Web.UI.Page

    Private Service As IntelliFleetServiceReference.Service1Client

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.Contents("UserName") = Nothing Then
            Response.Redirect("SignIn.aspx")
        End If


        Service = New IntelliFleetServiceReference.Service1Client


        Dim html As String = Service.ViewDrivers()

        HtmlCode.InnerHtml = html


        Dim html1 As String = Service.ViewAllDrivers()

        HtmlCode1.InnerHtml = html1

    End Sub

End Class