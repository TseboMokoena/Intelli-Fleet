Public Class expiryDate
    Inherits System.Web.UI.Page

    Private Service As IntelliFleetServiceReference.Service1Client
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        Service = New IntelliFleetServiceReference.Service1Client

        Dim html As String = Service.viewVehiclesExpiredPlate()

        expiryDate.InnerHtml = html

    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

    End Sub
End Class