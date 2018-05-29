<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ManageDrivers.aspx.vb" Inherits="Intelli_Fleet_Web.ManageDrivers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <section class="page">           
            <div id="wrapper">
                <div class="content-wrapper container">
					<div class="row">
						<div class="col-sm-12">
							<div class="page-title">
								<h1 style="color: #317bba" >Manage Drivers <small></small></h1>
               
							</div>
						</div>
					</div>
					
						<table style="border-style: hidden; border-width: 0px; width:80%; height:60%;color:#C0C0C0; background-color:rgba(0, 0, 0, 0.00); margin:auto; vertical-align: middle; text-align: center; font-style: normal; font-weight: bold;">
               
             
                <tr ">
                    <td>
                        <a href ="newDriver.aspx"><img src="../Images/add.png" alt="" style="width:100px; height:100px" /><p>ADD NEW DRIVER</p></a></td>
                   
                    <td>                         
                        <a href ="removeDriver.aspx"><img src="../Images/remove.png" alt="" style="width:100px; height:100px"" /><p>REMOVE DRIVERS</p></a>
                    </td>
                             
                    <td>                           
                          <a href ="editDriver.aspx"><img src="../Images/edit.png" alt=""style="width:100px; height:100px"/> <p>EDIT DRIVER DETAILS</p></a>
                    </td>

                    
                </tr>
                <tr>
                                
                    <td>                           
                          <a href ="track.aspx"><img src="../Images/documentation.png" alt="" style="width:100px; height:100px" /> <p>TRACK DRIVER</p></a>
                    </td>
                     <td>                           
                          <a href ="ViewOffDrivers.aspx"><img src="../Images/forms.png" alt="" style="width:100px; height:100px" /> <p>VIEW OFF DRIVERS</p></a>
                    </td>
                      <td>                         
                        <a href ="ViewDrivers.aspx"><img src="../Images/forms.png" alt="" style="width:100px; height:100px" /><p>VIEW DRIVERS</p></a>
                    </td>
                            
              </tr>
              
             
                
              </table>
					
					
                 </div>
             </div>
</asp:Content>
