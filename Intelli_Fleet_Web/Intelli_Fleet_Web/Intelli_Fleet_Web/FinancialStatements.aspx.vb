Public Class FinancialStatements
    Inherits System.Web.UI.Page
    Private Service As IntelliFleetServiceReference.Service1Client

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.Contents("UserName") = Nothing Then
            Response.Redirect("SignIn.aspx")
        End If


        Service = New IntelliFleetServiceReference.Service1Client


        'Dim User_Name As String = "Client1"
        Dim User_Name As String = Session.Contents("UserName")
        Name.Text = User_Name
        CollectionAddress.Text = Service.getbookingCollection(User_Name)
        distinationAddress.Text = Service.getBookingDistination(User_Name)
        dateDue.Text = Service.getBookingDuedate(User_Name)
        bookingNum.Text = Service.getbookingID(User_Name)
        Email.Text = Service.getBookingEmail(User_Name)
        InvoiceNo.Text = Service.getBookingPricingID(User_Name)
        '    VehicleType.Text = Service.getBookingVehicleType(User_Name)
        distance.Text = Service.getbookingDistance(User_Name)
        req.Text = Service.getRequirement(User_Name)
        Dim fPrice As Double = Service.getBookingPrice(User_Name)
        'price.Text = "R " + fPrice.ToString
        subtotal.Text = fPrice
        Dim totalamount As Double = (14 / 100) * fPrice + fPrice
        total.Text = totalamount



    End Sub

End Class