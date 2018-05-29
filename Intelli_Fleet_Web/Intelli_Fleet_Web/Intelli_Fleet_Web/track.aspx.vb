Public Class track
    Inherits System.Web.UI.Page
    Private Service As IntelliFleetServiceReference.Service1Client
    Private DropDown As New StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Service = New IntelliFleetServiceReference.Service1Client
        Dim drivers As Array
        drivers = Service.GetDriverUsernames()

        For c As Integer = 0 To drivers.Length - 1

            ddlDrivers.Items.Add(drivers(c).ToString)
        Next c
      
    End Sub

    Protected Sub btnDetails_Click(sender As Object, e As EventArgs) Handles btnDetails.Click
        Dim lat As String = ""
        Dim lng As String = ""
        Dim collecForDriver As String = ""
        Dim DistinationDriver As String = ""
        Dim DriverUsername As String = ""

        DriverUsername = ddlDrivers.SelectedValue
     
       
        lat = Service.GetDriversLat(DriverUsername)
        lng = Service.GetDriversLng(DriverUsername)

        latd.Value = lat
        lngd.Value = lng

        Label1.Text = DriverUsername
        Label2.Text = Service.getDrivername(DriverUsername)
        Label3.Text = Service.getDriverSurname(DriverUsername)
        Label4.Text = Service.getDriverVehicle(DriverUsername)
        Label5.Text = CStr(Service.getDriverNumJobs(DriverUsername))


        Dim htmlcode As String = ""
        Dim jobs As Integer
        jobs = Service.getDriverNumJobs(DriverUsername)
        htmlcode += "<table class=""table table-bordered"">"
        htmlcode += "<thead>"
        htmlcode += "<tr>"
        htmlcode += "<th>Booking number </th>  "
        htmlcode += "<th>Booking Description </th>  "
        htmlcode += "<th>Booking collection </th>  "
        htmlcode += "<th>Booking Destination </th>  "
        htmlcode += "<th>Booking Due date </th>  "
        htmlcode += " </tr>"
        htmlcode += "</thead>"
        Dim BookingNum(jobs) As Integer
        BookingNum = Service.getDriverJobs(DriverUsername)
        For i As Integer = 0 To BookingNum.Length - 1
            htmlcode += "<tr>"
            htmlcode += "<td>" & BookingNum(i) & "</td>"
            Dim discription As String = Service.getBookingDescription(BookingNum(i))
            htmlcode += "<td>" & discription & "</td>"
            htmlcode += "<td>" & Service.getDriverCollectionAddres(BookingNum(i)) & "</td>"
            htmlcode += "<td>" & Service.getDriverDistinationAddres(BookingNum(i)) & "</td>"
            htmlcode += "<td>" & Service.getDriverDueDate(BookingNum(i)) & "</td>"
            htmlcode += "</tr>"
           

        Next

        htmlcode += " <asp:HiddenField ID=""TotalTrips"" runat=""server"" value=" & BookingNum.Length - 1 & " />"
        htmlcode += "</table>"
        catalog.InnerHtml = htmlcode

        Dim checkpoint = BookingNum.Length
        If checkpoint = 3 Then
            If BookingNum(0) <> Nothing Then
                AddressCollection0.Value = Service.getDriverCollectionAddres(BookingNum(0))
                AddressDistina0.Value = Service.getDriverDistinationAddres(BookingNum(0))
            End If
            If BookingNum(1) <> Nothing Then
                AddressCollection1.Value = Service.getDriverCollectionAddres(BookingNum(1))
                AddressDistina1.Value = Service.getDriverDistinationAddres(BookingNum(1))
            End If
            If BookingNum(2) <> Nothing Then
                AddressCollection2.Value = Service.getDriverCollectionAddres(BookingNum(2))
                AddressDistina2.Value = Service.getDriverDistinationAddres(BookingNum(2))
            End If

        End If
        If checkpoint = 2 Then
            If BookingNum(0) <> Nothing Then
                AddressCollection0.Value = Service.getDriverCollectionAddres(BookingNum(0))
                AddressDistina0.Value = Service.getDriverDistinationAddres(BookingNum(0))
            End If
            If BookingNum(1) <> Nothing Then
                AddressCollection1.Value = Service.getDriverCollectionAddres(BookingNum(1))
                AddressDistina1.Value = Service.getDriverDistinationAddres(BookingNum(1))
                AddressCollection2.Value = Service.getDriverCollectionAddres(BookingNum(1))
                AddressDistina2.Value = Service.getDriverDistinationAddres(BookingNum(1))
            End If
          
        End If
        If checkpoint = 1 Then
            If BookingNum(0) <> Nothing Then
                AddressCollection0.Value = Service.getDriverCollectionAddres(BookingNum(0))
                AddressDistina0.Value = Service.getDriverDistinationAddres(BookingNum(0))
                AddressCollection1.Value = Service.getDriverCollectionAddres(BookingNum(0))
                AddressDistina1.Value = Service.getDriverDistinationAddres(BookingNum(0))
                AddressCollection2.Value = Service.getDriverCollectionAddres(BookingNum(0))
                AddressDistina2.Value = Service.getDriverDistinationAddres(BookingNum(0))




            End If
        End If
    End Sub
End Class