<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="track.aspx.vb" Inherits="Intelli_Fleet_Web.track" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
 
<%--  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>--%>
    
    
     <section class="page">
        <div id="wrapper">
            <div class="content-wrapper container">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="page-title">
                            <h1>Track a driver<small></small></h1>
                        </div>
                    </div>
                </div>



             <label>Vehicle driver:</label><br />
             <asp:DropDownList ID="ddlDrivers" runat="server" Width="200px">
                <asp:ListItem Text="Select Driver" Value="0"></asp:ListItem>
                
            </asp:DropDownList>

            
            <div>
                          <div id="DropDownCode" runat="server"></div>
                   
               </div>

                <div class="form-group">
                    <asp:Button ID="btnDetails" Text="Retirieve Details" CssClass="btn btn-primary btn-block" runat="server" />
                </div> 
  
                                                         
     
                <asp:HiddenField ID="latd" runat="server" />
                <asp:HiddenField ID="lngd" runat="server" />

                   <asp:HiddenField ID="DriverCollec" runat="server" />
                <asp:HiddenField ID="DriverDistin" runat="server" />


             <%-- <div class="dropdown">
                    <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown">Drivers
                         <span class="caret"></span></button>
                         <ul class="dropdown-menu">
                             <li><asp:Button ID="Button1" runat="server" Text="driv" /></li>
                             <li><a href="#">fayt</a></li>
                             <li><a href="#">filly</a></li>
                          </ul>
                    </div>--%>
                <asp:HiddenField ID="AddressCollection0" Value=""  runat="server" />
                 <asp:HiddenField ID="AddressDistina0" Value ="" runat="server" />       
                 <asp:HiddenField ID="AddressCollection1" Value="" runat="server" />
                 <asp:HiddenField ID="AddressDistina1" Value="" runat="server" />
                 <asp:HiddenField ID="AddressCollection2" Value="" runat="server" />
                <asp:HiddenField ID="AddressDistina2" Value="" runat="server" />
                  <div class="panel-body">
                           <div class="row">
                       <input style="width:100px" id="submit"value="Find driver" type="button" class="controls" >
                           <div id="map" style="width: 1000px; height: 467px;"></div>
                                <div id="directions-panel"></div>
                           <script src="js/Scripts/Routing1.js"></script>

                           <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAnE8qcNXp2QrkvrjBax4Jg5N5cLPlIqvQ&libraries=places&callback=initMap"
                              async defer></script>
                           </div>
                     </div>
                    <div class="panel panel-default margin-b-30 ">
                                <!-- Start .panel -->
                                <div class="panel-heading">
                                    <h4 class="panel-title"> Driver Job information</h4>
                                    <div class="panel-actions">
                                        <a href="#" class="panel-action panel-action-toggle" data-panel-toggle></a>
                                       
                                    </div>
                                </div>
                                <div class="panel-body">
                                    <table class="table table-bordered">
                                        <thead>
                                            <tr>
                                                  <th>Username</th>
                                                 <th>First Name</th>
                                                 <th>Surname</th>
                                                 <th>Vehicele Assigned to</th>
                                                 <th>Number of Deliveries</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                   <td><asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
                                                   <td><asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                                                   <td><asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
                                                   <td><asp:Label ID="Label4" runat="server" Text=""></asp:Label></td>
                                                   <td> <asp:Label ID="Label5" runat="server" Text=""></asp:Label></td>             
                                            
                                            </tr>
                                           
                                       </tbody>
                                    </table>
                                </div>
                            </div>
                   <div class="panel panel-default margin-b-30 ">
                                <!-- Start .panel -->
                                <div class="panel-heading">
                                    <h4 class="panel-title"> LIST OF DRIVER JOBS</h4>
                                    <div class="panel-actions">
                                        <a href="#" class="panel-action panel-action-toggle" data-panel-toggle></a>
                                       
                                    </div>
                                </div>
                                <div class="panel-body">
                                 
                                     <div id ="catalog" runat="server"></div>
                                </div>
                            </div>
                
        

           </div>
        </div>

    </section>
</asp:Content>
