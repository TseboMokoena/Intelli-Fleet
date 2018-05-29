<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ManageBookings.aspx.vb" Inherits="Intelli_Fleet_Web.ManageBookings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

         <section class="page">           
            <div id="wrapper">
                <div class="content-wrapper container">
					<div class="row">
						<div class="col-sm-12">
							<div class="page-title">
								<h1>Manage bookings<small></small></h1>
               
							</div>
						</div>
					</div>
					
						<table style="width:75%;height:60% ;color:black;background-color:#FFE93F80;border:thin;margin:auto">
               
             
                <tr style="color:black;resize:vertical;border:solid">
                    <td style="border:solid">
                        <p>ADD NEW DRIVER</p>
                        <a href ="newDriver.aspx"><img src="../Images/a.png" alt="" style="width:20%"</a></td>
                    <td style="border:solid">
                        <p>ADD NEW MANAGER</p>
                        <a href ="newManager.aspx"><img src="../Images/a.png" alt="" style="width:20%"</a>
                    </td>
                    <td style="border:solid">
                         <p>VIEW DRIVERS</p>
                        <a href ="ViewDrivers.aspx"><img src="../Images/a.png" alt="" style="width:20%"</a>
                    </td>
                </tr>
                
                
                   <tr style="color:black;resize:vertical;border:solid">
                    <td style="border:solid">
                        <p>ASSIGN ORDER</p>
                        <a href ="AssignOrder.aspx"><img src="../Images/assign.png" alt="" style="width:20%"</a>
                        
                    </td>
                    <td style="border:solid" >
                            <p>TRACK DRIVER</p>
                          <a href ="#"><img src="../Images/track.jpg" alt="" style="width:20%"</a>
                    </td>
                    <td  style="border:solid" >
                           <p>"CHECK REPORT"</p>
                          <a href ="#"><img src="../Images/report.png" alt="" style="width:20%"</a>
                    </td>
                </tr>
                <tr>
                    <td style="border:solid"  >  <p>VIEW ALL ORDERS</p><a href ="ViewOrders.aspx"><img src="../Images/CheckOrder.png" alt="" style="width:20%"</a></td>
                    <td  style="border:solid" > <p>VIEW PENDING ORDERS</p><a href ="ViewPendingDelveries.aspx"><img src="../Images/checkOnline.png" alt="" style="width:20%"</a></td>
                    <td  style="border:solid"  > <p>CHECK NOTIFICATION</p><a href ="#"><img src="../Images/notification.png" alt="" style="width:20%"</a></td>
                </tr>
                
              </table>
					
					
                 </div>
             </div>
     </section>
		 





</asp:Content>
