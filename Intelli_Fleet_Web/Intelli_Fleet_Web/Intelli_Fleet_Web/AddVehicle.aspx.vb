Public Class AddVehicle
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim VReg As String
        Dim type As String
        Dim Volume As Double
        Dim weight As Double
        Dim kilo As Double
        Dim ExDate As DateTime
        Dim Active As String

        Dim avilable As String = "True"
        Dim status As String = "Active"
        VReg = txtVehicleReg.Text
        type = txtType.Text
        Volume = txtVolume.Text
        weight = txtSize.Text
        kilo = TxtMaintance.Text
        ExDate = txtExDate.Text + " 00:00:00.000"
        Active = "True"

        Dim Service As IntelliFleetServiceReference.Service1Client
        Service = New IntelliFleetServiceReference.Service1Client

        Service.AddVehicle(VReg, type, Volume, weight, kilo, ExDate, avilable, status)

        Response.Redirect("ViewVehicles.aspx")
    End Sub

End Class