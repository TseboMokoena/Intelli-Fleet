<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ManageVehicles.aspx.vb" Inherits="Intelli_Fleet_Web.ManageVehicles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
     <section class="page">           
            <div id="wrapper">
                <div class="content-wrapper container">
					<div class="row">
						<div class="col-sm-12">
							<div class="page-title">
								<h1 style="color: #317bba" >Manage Vehicles <small></small></h1>
               
							</div>
						</div>
					</div>
					
						<table style="border-style: hidden; border-width: 0px; width:80%; height:60%;color:#C0C0C0; background-color:rgba(0, 0, 0, 0.00); margin:auto; vertical-align: middle; text-align: center; font-style: normal; font-weight: bold;">
               
             
                <tr>
                    <td>
                        <a href ="addVehicle.aspx"><img src="../Images/ADDNEWVEHICLES.png" alt="" style="width:100px; height:100px" /><p>ADD NEW VEHICLE</p></a></td>
                   
                    <td>                         
                        <a href ="EditVehicle.aspx"><img src="../Images/EDITVEHICLES.png" alt="" style="width:100px; height:100px" /><p>EDIT VEHICLES</p></a>
                    </td>
                             
                    <td>                           
                          <a href ="DeleteVehicle.aspx"><img src="../Images/DELETEVEHICLE.png" alt=""style="width:100px; height:100px"  /> <p>DELETE VEHICLE</p></a>
                    </td>
                    
                </tr>
                <tr>
                    <td>
                        <a href ="VehicleMaintances.aspx"><img src="../Images/maintance.png" alt="" style="width:100px; height:100px"  /><p>VEHICLES FOR MAINTAINANCE</p></a></td>
                   
                    <td>                         
                        <a href ="ViewVehicles.aspx"><img src="../Images/view.png" alt="" style="width:100px; height:100px"  /><p>VIEW ALL VEHICLES</p></a>
                    </td>
                   <td>                         
                        <a href ="ForceAssign.aspx"><img src="../Images/vehicleReport.png" alt=""style="width:100px; height:100px"  /><p>FORCE ASSIGN VEHICLES</p></a>
                    </td>
                             
                     
                    
                </tr>
             
             
                     </table>
					
					
                 </div>
             </div>
         <section />

</asp:Content>
