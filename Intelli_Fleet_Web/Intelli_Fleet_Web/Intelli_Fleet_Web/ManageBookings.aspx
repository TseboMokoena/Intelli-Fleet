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
								<h1 style="color: #317bba">Manage Bookings <small></small></h1>
               
							</div>
						</div>
					</div>
					
             
						<table style="border-style: hidden; border-width: 0px; width:80%; height:60%;color:#C0C0C0; background-color:rgba(0, 0, 0, 0.00); margin:auto; vertical-align: middle; text-align: center; font-style: normal; font-weight: bold;">
               
                     
                   <tr>
                  <%-- <td  ><a href ="Notifications.aspx"><img src="../Images/orders/notification.png" alt="" style="width:100px;height:100px" /><p>CLIENT NOTIFICATION</p></a>

                   </td>--%>
                   <td style="padding-left:3em"><a href ="ViewOrders.aspx"><img src="../Images/SHOPINGCART.png" alt="" style="width:100px;height:100px" /><p>VIEW ALL BOOKINGS</p></a></td>
                   <%--<td><a href ="Manager.aspx"><img src="../Images/orders/financial.png" alt=""  style="width:100px;height:100px" /><p>MANAGEMENT REPORTS</p></a></td>
                    --%>
                </tr>
                
              </table>
					
					
                 </div>
             </div>
     </section>
		 





</asp:Content>
