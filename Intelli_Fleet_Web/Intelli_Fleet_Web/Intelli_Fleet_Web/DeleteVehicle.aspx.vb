Public Class DeleteVehicle
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim Service As IntelliFleetServiceReference.Service1Client
        Service = New IntelliFleetServiceReference.Service1Client

        Dim deleted As Boolean

        deleted = Service.RemoveVehicle(txtReg.Text.ToString)

        If deleted = True Then
            Response.Redirect("ViewVehicles.aspx")
        End If

    End Sub
End Class