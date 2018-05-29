Public Class AssignOrder
    Inherits System.Web.UI.Page

    Private Service As IntelliFleetServiceReference.Service1Client

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.Contents("UserName") = Nothing Then
            Response.Redirect("SignIn.aspx")
        End If

        

        Service = New IntelliFleetServiceReference.Service1Client


        Dim html As String = Service.ViewAllPendingOrders()

        HtmlCode.InnerHtml = html
       
        Dim html1 As String = Service.ViewAvailableDrivers()

        HtmlCode1.InnerHtml = html1


    End Sub

    Protected Sub btnAssign_Click(sender As Object, e As EventArgs) Handles btnAssign.Click

        Service = New IntelliFleetServiceReference.Service1Client

        '   Service.Assign_Booking(txtBooking_Id.Text, txtDriver_Id.Text)

        Response.Redirect("AssignOrder.aspx")

    End Sub
End Class