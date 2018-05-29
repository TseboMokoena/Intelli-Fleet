Imports System.Text
Public Class Bookings
    Inherits System.Web.UI.Page
    Private Service As IntelliFleetServiceReference.Service1Client
    Private dist As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.Contents("UserName") = Nothing Then
            Response.Redirect("SignIn.aspx")
        End If

        Service = New IntelliFleetServiceReference.Service1Client
     
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        ' Dim User_Name As String = "Client1"
        Dim User_Name As String = Session.Contents("UserName")
        '  Dim Adress1 As String = "txtCollection.Text"
        '  Dim Adress2 As String = txtDestination.Text
        Dim DDate As String = txtDelivery_date.Text
        Dim DTime As String = txtDelivery_time.Text
        Dim Delivery_DateNTime As DateTime = DDate + " " + DTime
        Dim Package_Type As String = txtPackage_Type.Text
        Dim Package_Weight As Double = txtPackage_Weight.Text
        Dim volume As Double = txtVolume.Text
        Dim Requirment As String = ""
        Dim Delivery_stat As String = "In Progress"
        Dim dateDelivered As String = "Not Delivered"
        Dim dateCollected As String = "Not Collected"

        If boxRefrig.Checked = True Then
            Requirment = "Refrigiration"

        ElseIf boxHeater.Checked = True Then
            Requirment = "Heater"

        ElseIf boxCannopy.Checked = True Then
            Requirment = "Open Canopy "
        ElseIf boxNone.Checked = True Then
            Requirment = "None "
        End If

        ' get value from the javascript

        Dim collection As String = CollectionAddress.Value
        Dim distination As String = DestinationAddress.Value
        Dim distance As Double = 0
     
        
  
        Service.Book(User_Name, collection, distination, Package_Type, Package_Weight, volume, Delivery_DateNTime, Requirment, Delivery_stat, dateCollected, dateDelivered)


        Response.Redirect("PendingDeliveries.aspx")

        'End If

    End Sub


    
End Class