Public Class editDriver
    Inherits System.Web.UI.Page
    Private Service As IntelliFleetServiceReference.Service1Client

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.Contents("UserName") = Nothing Then
            Response.Redirect("SignIn.aspx")
        End If

        Service = New IntelliFleetServiceReference.Service1Client

     
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim Name As String
        Dim Surname As String
        Dim Username As String
        Dim Email As String
        Dim UType As Integer
        Dim Active As String
        Dim Sucess As Boolean
        Dim Licence_Number As String
        Dim PDP_Number As String
        Dim startShift As DateTime
        Dim endShift As DateTime
        Dim expiry As DateTime

        Dim RequirmentDoc As String
        Dim DayOff As String

        Name = txtUName.Text
        Surname = txtUSurname.Text
        Email = txtUEmail.Text
        Username = txtUUsername.Text

        UType = 2
        Active = "True"
        Licence_Number = txtLicence.Text
        PDP_Number = txtPDP.Text
        startShift = txtShifts.Text
        endShift = txtEnd.Text
        expiry = txtExpiry.Text


        If (drpRequirements.Attributes.Equals("True")) Then
            RequirmentDoc = "True"
        Else
            RequirmentDoc = "False"
        End If

        If (drpDayOff.Attributes.Equals("True")) Then
            DayOff = "True"
        Else
            DayOff = "False"
        End If



        Sucess = Service.editDriver(Name, Surname, Username, Email, Licence_Number, PDP_Number, RequirmentDoc, startShift, endShift, expiry, DayOff)

        Response.Redirect("ViewDrivers.aspx")

    End Sub

    Protected Sub btnDetails_Click(sender As Object, e As EventArgs) Handles btnDetails.Click
        Dim Uname As String = txtUsername.Text

        Dim details() As String

        details = Service.RetrieveDriverDetails(Uname)


        txtUName.Text = details(0)
        txtUSurname.Text = details(1)
        txtUUsername.Text = details(3)
        txtUEmail.Text = details(2)
        txtLicence.Text = details(4)
        txtPDP.Text = details(5)
        drpRequirements.SelectedValue = details(6)
        txtShifts.Text = details(7)
        txtEnd.Text = details(8)
        txtExpiry.Text = details(9)
        drpDayOff.SelectedValue = details(10)

    End Sub
End Class