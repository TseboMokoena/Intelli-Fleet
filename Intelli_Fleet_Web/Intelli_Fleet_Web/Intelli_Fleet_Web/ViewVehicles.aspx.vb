Public Class ViewVehicles
    Inherits System.Web.UI.Page

    Private Service As IntelliFleetServiceReference.Service1Client

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Service = New IntelliFleetServiceReference.Service1Client


        Dim html As String = Service.ViewVehicles()

        HtmlCode.InnerHtml = html

    End Sub

End Class