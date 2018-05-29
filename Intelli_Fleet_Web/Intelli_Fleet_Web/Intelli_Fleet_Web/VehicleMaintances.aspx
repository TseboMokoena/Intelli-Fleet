<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="VehicleMaintances.aspx.vb" Inherits="Intelli_Fleet_Web.VehicleMaintances" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="page">
        <div id="wrapper">
            <div class="content-wrapper container">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="page-title">
                            <h1>Vehicles for maintances<small></small></h1>
                        </div>
                    </div>
                </div>
                  <h2>Vehicles to be sent for service</h2>
                 <div class="table-responsive">
                <div id="CarService" runat="server">
                    <br />
                </div>
                <hr />
           <asp:DropDownList ID="ddlDrivers" runat="server" Width="200px">
                <asp:ListItem Text="Select vehicle to reactivate" Value="0"></asp:ListItem>          
            </asp:DropDownList>
                     <asp:Button ID="Button1" runat="server" Text="Reactivate" />
                     <br />
                <br />
                <h2>Problematic vehicles</h2>
                   <div class="table-responsive">
                <div id="Reported" runat="server">
                   
                      </div>
                       <br />
                       <br />
     
                    
                  </div>

            </div>
                  <div class="panel panel-default margin-b-30 ">
                                <!-- Start .panel -->
                                <div class="panel-heading">
                                    <h4 class="panel-title"> REPLACEMENT VEHICLE AND DRIVER</h4>
                                    <div class="panel-actions">
                                        <a href="#" class="panel-action panel-action-toggle" data-panel-toggle></a>
                                       
                                    </div>
                                </div>
                                <div class="panel-body">
                                 
                                     <div id ="catalog" runat="server"></div>
                        </div>
              </div>
        </div>
    </section>
</asp:Content>
