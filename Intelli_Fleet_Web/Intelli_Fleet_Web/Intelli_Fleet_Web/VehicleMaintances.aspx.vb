Public Class VehicleMaintances
    Inherits System.Web.UI.Page

    Private Service As IntelliFleetServiceReference.Service1Client
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Service = New IntelliFleetServiceReference.Service1Client
        Dim drivers As Array
        drivers = Service.getMaintanceVehicles()
        For c As Integer = 0 To drivers.Length - 1

            ddlDrivers.Items.Add(drivers(c).ToString)
        Next c
        Dim html As String = Service.viewMaintanceVehicles()
        CarService.InnerHtml = html
        Dim html2 As String = Service.viewReportedVehicles()
        Reported.InnerHtml = html2

        Dim htmlcode As String = ""
        Dim jobs As Integer
        htmlcode += "<table class=""table table-bordered"">"
        htmlcode += "<thead>"
        htmlcode += "<tr>"
        htmlcode += "<th>New Driver </th>  "
        htmlcode += "<th>New Vehicle </th>  "
        htmlcode += "<th>Repoted vehicle </th>  "
        htmlcode += "<th>Reported vehicle location </th>  "
        htmlcode += "<th>Number of packages </th>  "
        htmlcode += " </tr>"
        htmlcode += "</thead>"
        For i As Integer = 0 To 1 - 1

            htmlcode += "<tr>"
            htmlcode += "<td> Tsebo</td>"
            htmlcode += "<td> HDL985GP</td>"
            htmlcode += "<td> AA12CCGP</td>"
            htmlcode += "<td>12 Ditton Avenue ,Johannesburg ,2092   </td>"
            htmlcode += "<td>2</td>"
            htmlcode += "</tr>"
        Next
        htmlcode += "</table>"
        catalog.InnerHtml = htmlcode
    End Sub

   
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim reg As String = ""
        reg = ddlDrivers.SelectedValue
        Service.UpdateVehicleActive(reg)
        Response.Redirect("VehicleMaintances.aspx")
    End Sub


End Class