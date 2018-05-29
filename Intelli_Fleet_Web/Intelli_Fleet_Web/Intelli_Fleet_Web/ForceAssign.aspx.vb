Public Class ForceAssign
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim Service As IntelliFleetServiceReference.Service1Client
        Service = New IntelliFleetServiceReference.Service1Client

        Service.GetAssignedVehicle()

        Response.Redirect("ViewDrivers.aspx")
    End Sub

End Class