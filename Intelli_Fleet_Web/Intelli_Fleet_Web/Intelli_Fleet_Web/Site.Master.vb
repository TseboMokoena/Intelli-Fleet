Public Class SiteMaster
    Inherits MasterPage

    Const AntiXsrfTokenKey As String = "__AntiXsrfToken"
    Const AntiXsrfUserNameKey As String = "__AntiXsrfUserName"
    Dim _antiXsrfTokenValue As String
    Dim LoginCodeText As String
    Dim LogoutCodeText As String
    Dim OnlineUserActionsText As String
    Dim OnlineManagerActionsText As String
    Dim client_name As String



    Protected Sub Page_Init(sender As Object, e As System.EventArgs)
        ' The code below helps to protect against XSRF attacks
        Dim requestCookie As HttpCookie = Request.Cookies(AntiXsrfTokenKey)
        Dim requestCookieGuidValue As Guid
        If ((Not requestCookie Is Nothing) AndAlso Guid.TryParse(requestCookie.Value, requestCookieGuidValue)) Then
            ' Use the Anti-XSRF token from the cookie
            _antiXsrfTokenValue = requestCookie.Value
            Page.ViewStateUserKey = _antiXsrfTokenValue
        Else
            ' Generate a new Anti-XSRF token and save to the cookie
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N")
            Page.ViewStateUserKey = _antiXsrfTokenValue

            Dim responseCookie As HttpCookie = New HttpCookie(AntiXsrfTokenKey) With {.HttpOnly = True, .Value = _antiXsrfTokenValue}
            If (FormsAuthentication.RequireSSL And Request.IsSecureConnection) Then
                responseCookie.Secure = True
            End If
            Response.Cookies.Set(responseCookie)
        End If

        AddHandler Page.PreLoad, AddressOf master_Page_PreLoad
    End Sub

    Private Sub master_Page_PreLoad(sender As Object, e As System.EventArgs)
        If (Not IsPostBack) Then
            ' Set Anti-XSRF token
            ViewState(AntiXsrfTokenKey) = Page.ViewStateUserKey
            ViewState(AntiXsrfUserNameKey) = If(Context.User.Identity.Name, String.Empty)
        Else
            ' Validate the Anti-XSRF token
            If (Not DirectCast(ViewState(AntiXsrfTokenKey), String) = _antiXsrfTokenValue _
                Or Not DirectCast(ViewState(AntiXsrfUserNameKey), String) = If(Context.User.Identity.Name, String.Empty)) Then
                Throw New InvalidOperationException("Validation of Anti-XSRF token failed.")
            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        LoginCodeText = " <a href=""#""><i class=""fa fa-th-large""></i> <span class=""nav-label"">Accounts </span><span class=""fa arrow""></span></a>" _
                         & "<ul class=""nav nav-second-level collapse""><li><a href=""Signin.aspx"">Login</a></li>" _
                         & "<li><a href=""Registration.aspx"">Register</a></li></ul>"


        If Session.Contents("UserType") > 0 Then
            client_name = Session.Contents("UserName")
            LogoutCodeText = "<span class=""clear"" style=""display: block;""> <span class=""block m-t-xs""> " _
                               & "<strong class=""font-bold"">" + client_name + "  <b class=""caret""></b></strong> " _
                               & "</span></span> </a><ul  class=""dropdown-menu animated fadeInRight m-t-xs"" runat =""server"">" _
                               & "<li><a href=""MyProfile.aspx""><i class=""fa fa-user""></i>My Profile</a></li>" _
                               & "<li class=""divider""></li><li><a href=""Logout.aspx""><i class=""fa fa-key""></i>Logout</a></li></ul>"

        End If

        If Session.Contents("UserType") = 1 Then
            LoginCodeText = ""

            OnlineUserActionsText = "<a href=""#""><i class=""fa fa-th-large""></i> <span class=""nav-label"">Services </span><span class=""fa arrow"">" _
                                    & "</span></a><ul class=""nav nav-second-level collapse"">" _
                                    & "<li><a href=""Bookings.aspx"">Make Booking</a></li>" _
                                    & " <li><a href=""PendingDeliveries.aspx"">Pending Deliveries</a></li>" _
                                    & " <li><a href=""DeliveryHistory.aspx"">Delivery History</a></li>" _
                                    & " <li><a href=""FinacialRecords.aspx"">Finacial Records</a></li>" _
                                    & " <li><a href=""FinancialStatements.aspx"">Latest Invoice</a></li>"



        ElseIf Session.Contents("UserType") = 3 Then
            LoginCodeText = ""
            OnlineManagerActionsText = "<a href=""Manager.aspx""><i class=""fa fa-th-large""></i> <span class=""nav-label"">Management </span><span class=""fa arrow"">" _
                                & "</span></a><ul class=""nav nav-second-level collapse"">" _
                                & "   <li><a href=""ManageBookings.aspx"">Manage Bookings</a></li>" _
                                & "   <li><a href=""ManageDrivers.aspx"">Manage Drivers</a></li>" _
                                & "   <li><a href=""ManageVehicles.aspx"">Manage Vehicles</a></li>" _
                                & "   <li><a href=""Manager.aspx"">Reports</a></li>" _
                                & "  </ul>"

        End If

        LoginCode.InnerHtml = LoginCodeText
        LogOutCode.InnerHtml = LogoutCodeText
        OnlineUserActions.InnerHtml = OnlineUserActionsText
        OnlineManagerActions.InnerHtml = OnlineManagerActionsText
        Dim Service As IntelliFleetServiceReference.Service1Client
        Service = New IntelliFleetServiceReference.Service1Client


        If System.DateTime.Now.Hour = "06" Then
            ' check driver stuff in the morning
            ' check vehicle stuff in the morning
            ' update vehicles stuff in the morning
            Service.GetAssignedVehicle()

        End If


    End Sub
End Class