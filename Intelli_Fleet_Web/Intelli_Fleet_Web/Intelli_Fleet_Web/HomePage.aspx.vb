Imports System.Data.SqlClient

Public Class _Default
    Inherits Page
    Private Service As IntelliFleetServiceReference.Service1Client

    Private HtmlCode As String
    Private HtmlCode2 As String
    Private connection As SqlConnection
    Private command As SqlCommand
    Private reader As SqlDataReader


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Service = New IntelliFleetServiceReference.Service1Client

        HtmlCode = "<p>This website gives the client a platform to book deliveries and gives them " _
                & "easy access to more information about the status and safety of their package.Our system is designed " _
                & "with the purpose of providing efficient and cost saving fleet management and the transportation" _
                & " of goods by minimising the costs involved in the transportation of goods." _
                & "<a href =""Registration.aspx"">Sign up here </a> and be a part of Intelli-Fleet</a></p>"

        
        HtmlCode2 = "<div class=""col-md-4"">" _
                    & "<span class=""fa-stack fa-4x"">" _
                        & "<i class=""fa fa-circle fa-stack-2x text-primary""></i>" _
                        & "<i class=""fa fa-laptop fa-stack-1x fa-inverse""></i>" _
                    & "</span>" _
                    & "<h4>Client Dashboard</h4>" _
                    & "<p>Clients can request for packages to be collected and delivered. Check Collection and delivery status. View Financial statements.</p>" _
                & "</div>" _
                & "<div class=""col-md-4"">" _
                    & "<span class=""fa-stack fa-4x"">" _
                        & "<i class=""fa fa-circle fa-stack-2x text-primary""></i>" _
                        & "<i class=""fa fa-location-arrow fa-stack-1x fa-inverse""></i>" _
                    & "</span>" _
                    & "<h4 class=""service-heading"">Optimsed Routing</h4>" _
                    & "<p>Provides truck drivers with optimised routes to travel while collecting and delivering packages.</p>" _
                & "</div>" _
                & "<div class=""col-md-4"">" _
                    & "<span class=""fa-stack fa-4x"">" _
                        & "<i class=""fa fa-circle fa-stack-2x text-primary""></i>" _
                        & "<i class=""fa fa-line-chart fa-stack-1x fa-inverse""></i>" _
                    & "</span>" _
                    & "<h4 class=""service-heading"">Fleet Management Dashboard</h4>" _
                    & "<p>Provides information about current vehicles on the system and their status," _
                    & "vehicle tracking capabilities and management of drivers. " _
                    & "<View business status as well as past and current perfomance comparisons. </p>" _
                & "</div>"

        If Session.Contents("Usertype") = 1 Then

            HtmlCode = " <h2 style=""font-size: 35px;"">Get Started<small></small></h2>" _
                        & "<p>Make a <a href=Bookings.aspx>booking</a> to get started. "

            HtmlCode2 = ""


        ElseIf Session.Contents("Usertype") = 3 Then

            HtmlCode = "<header><h2 style=""color: #317bba"">Manager Username: " + Session("Username") + " </h2 ></header> "
            HtmlCode2 = "<table style=""border-style: hidden; border-width: 0px; width:75%; height:60%; background-color:rgba(0, 0, 0, 0.00); " _
                        & "margin:auto; vertical-align: middle; text-align: center; font-style: normal; font-weight: bold;"">" _
                        & "<tr><td>" _
                        & "<a href =""ManageBookings.aspx""><img src=""../Images/SHOPINGCART.png"" alt="""" style=""width:100px; height:100px"" /> <p>MANAGE BOOKINGS</p></a></td>" _
                        & "<td><td>" _
                        & "<a href =""ManageDrivers.aspx""><img src=""../Images/add.png"" alt="""" style=""width:100px; height:100px"" /> <p>MANAGE DRIVERS</p></a>" _
                        & "</td>" _
                        & "<td>" _
                        & "<a href =""ManageVehicles.aspx""><img src=""../Images/view.png"" alt="""" style=""width:100px; height:100px"" /> <p>MANAGE VEHICLES</p></a>" _
                        & "</td>" _
                        & "<td>" _
                        & "<a href =""Manager.aspx""><img src=""../Images/systemReport.png"" alt="""" style=""width:120px; height:120px"" /><p>MANAGEMENT REPORTS</p></a>" _
                        & "</td>" _
                        & "</tr>" _
                        & "</table>"

        End If

        code.InnerHtml = HtmlCode
        code2.InnerHtml = HtmlCode2
    End Sub
End Class