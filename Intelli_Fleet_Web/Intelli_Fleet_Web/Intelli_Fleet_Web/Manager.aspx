<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Manager.aspx.vb" Inherits="Intelli_Fleet_Web.Manager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <section class="page">           
            <div id="wrapper">
                <div class="content-wrapper container">
					<div class="row">
						<div class="col-sm-12">
							<div class="page-title">
								<h1 style="color: #317bba">Management Reports<small></small></h1>
               
							</div>
						</div>
					</div>
					
			<table style="border-style: hidden; border-width: 0px; width:75%; height:60%;color:#C0C0C0; background-color:rgba(0, 0, 0, 0.00); margin:auto; vertical-align: middle; text-align: center; font-style: normal; font-weight: bold;">
               
                <tr>
                    <td>
                       
                        <a href ="VehicleReport.aspx"><img src="../Images/vehicleMain.png" alt="" style="width:100px; height:100px" /> <p>VEHICLE REPORT</p></a></td>
                 <%--  <td>
                       
                        <a href ="SystemReport.aspx"><img src="../Images/orders/systemReport.png" alt="" style="width:120px; height:120px" /><p>SYSTEM REPORT</p></a>
                    </td>--%>
                    <td>
                        
                        <a href ="Reports.aspx"><img src="../Images/financial.png" alt="" style="width:100px; height:100px" /> <p>FINANCIAL REPORT</p></a>
                    </td>
                </tr>      
              </table>
					
					
                 </div>
             </div>
</asp:Content>
