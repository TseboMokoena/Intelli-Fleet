Public Class newDriver
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.Contents("UserName") = Nothing Then
            Response.Redirect("SignIn.aspx")
        End If

    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim Name As String
        Dim Surname As String
        Dim Username As String
        Dim Email As String
        Dim Password As String
        Dim ConfirmPassword As String
        Dim UType As Integer
        Dim Active As String
        Dim Sucess As Boolean
        Dim exist As Boolean
        Dim exist1 As Boolean
        Dim Vehicle_Reg As String
        Dim Licence_Number As String
        Dim PDP_Number As String
        Dim Match As Boolean
        Dim startShift As DateTime
        Dim endShift As DateTime
        Dim expiry As DateTime
        Dim requirements As String
        Dim dayOff As String

        Name = txtUName.Text
        Surname = txtUSurname.Text
        Email = txtUEmail.Text
        Username = txtUUsername.Text
        Password = txtUPassword.Text
        ConfirmPassword = txtUConfirm.Text



        UType = 2
        Active = "true"
        Licence_Number = txtLicence.Text
        PDP_Number = txtPDP.Text
        startShift = txtShifts.Text
        endShift = txtEnd.Text
        expiry = txtExpiry.Text
        'Dim shifts As DateTime = startShift + " " + endShift

        Dim Service As IntelliFleetServiceReference.Service1Client
        Service = New IntelliFleetServiceReference.Service1Client

        exist = Service.CheckExisting(Name, Surname, Username)
        exist1 = Service.CheckExistingUsername(Name, Surname, Username)

        If (drpRequirements.Attributes.Equals("Yes")) Then
            requirements = "Up to date"
        Else
            requirements = "Obsolete"
        End If

        If (drpDayOff.Attributes.Equals("Yes")) Then
            dayOff = "Yes"
        Else
            dayOff = "No"
        End If


        If (Password = ConfirmPassword) Then
            Match = True
        End If

        If (Match = False) Then
            '    MsgBox("Entered passwords dont mactch.")

        ElseIf (exist = True) Then
            '       MsgBox("You are an existing inctive user, contact admin to activate account.")

        ElseIf (exist1 = True) Then
            '     MsgBox("Username taken, enter different username.")

        ElseIf (Match = True) Then
            Sucess = Service.AddDriver(Name, Surname, Username, Email, Password, ConfirmPassword, UType, Active, Licence_Number, PDP_Number, requirements, startShift, endShift, expiry, dayOff)
            '      MsgBox("You have registered a driver successfully.")
            Response.Redirect("ManageDrivers.aspx")
        End If

    End Sub
End Class