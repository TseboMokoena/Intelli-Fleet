Public Class PendingDeliveries
    Inherits System.Web.UI.Page
    Private Service As IntelliFleetServiceReference.Service1Client


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.Contents("UserName") = Nothing Then
            Response.Redirect("SignIn.aspx")
        End If


        Service = New IntelliFleetServiceReference.Service1Client



        Dim User_Name As String = Session.Contents("UserName")


        Dim html As String = Service.ViewPendingOrderS(User_Name)

        HtmlCode.InnerHtml = html



    End Sub

End Class