<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Bookings.aspx.vb" Inherits="Intelli_Fleet_Web.Bookings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  
  
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">



<style>
.alert {
    padding: 20px;
    background-color: #f44336;
    color: white;
    opacity: 1;
    transition: opacity 0.6s;
    margin-bottom: 15px;
}

.alert.success {background-color: #4CAF50;}
.alert.info {background-color: #2196F3;}
.alert.warning {background-color: #ff9800;}

.closebtn {
    margin-left: 15px;
    color: white;
    font-weight: bold;
    float: right;
    font-size: 22px;
    line-height: 20px;
    cursor: pointer;
    transition: 0.3s;
}

.closebtn:hover {
    color: black;
}
</style>
    <section class="page">
        <div id="wrapper">
            <div class="content-wrapper container">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="page-title">
                            <h1>Make a booking<small></small></h1>
                            <h3 style="color: #317bba">Enter delivery and package details</h3>
                        </div>
                    </div>
                </div>

                  <div class="row">
                    <div class="col-md-6">
                        <div class="panel panel-default margin-b-30">

                            <div class="panel-heading">
                                <h4 class="panel-title">Package Information</h4>
                               <%-- <div class="panel-actions">
                                    <a href="#" class="panel-action panel-action-toggle" data-panel-toggle></a>
                                    <a href="#" class="panel-action panel-action-dismiss" data-panel-dismiss></a>
                                </div>--%>
                            </div>

                            <div class="panel-body">

                                <form role="form" class="form-inline">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtPackage_Type" placeholder="Package Description (Equipment, perishable goods etc.)" class="form-control" runat="server" CausesValidation="true" required=""></asp:TextBox></div>

                                    <div class="form-group">
                                        <asp:TextBox ID="txtPackage_Weight" TextMode="number" placeholder="Package Weight(kg)" class="form-control" runat="server" CausesValidation="true" required=""></asp:TextBox>
                                    </div>
                                       <div class="form-group">
                                        <asp:TextBox ID="txtVolume" TextMode="number" placeholder="Volume(m^3) " class="form-control" runat="server" CausesValidation="true" required=""></asp:TextBox>
                                    </div>

               
                                    <div class="form-group">
                                        <label class="col-sm-8 control-label">Special vehicle requirements</label>
                                        <div class="col-sm-10">
                                            <div>
                                                <asp:CheckBox ID="boxRefrig" runat="server" />Refrigiration</div>
                                            <div>
                                                <asp:CheckBox ID="boxHeater" runat="server" />Heater</div>
                                            <div>
                                                <asp:CheckBox ID="boxCannopy" runat="server" />Open Canopy</div>
                                             <div>
                                                <asp:CheckBox ID="boxNone" runat="server" />None</div>
                                          <!--  <div class="col-sm-8"><input type="text" placeholder="Other" class="form-control"></div>-->
                                        </div>
                                    </div>
                                </form>

                            </div>
                        </div>
                    </div>
                 </div>

                  <div class="row">
                    <div class="col-md-12">
                        <div class="panel panel-default margin-b-30">

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="panel panel-default recent-activites">
                                        <!-- Start .panel -->
                                        <div class="panel-heading">
                                            <h4 class="panel-title">Date and Time </h4>
                                          <%--  <div class="panel-actions">
                                                <a href="#" class="panel-action panel-action-toggle" data-panel-toggle=""></a>
                                                <a href="#" class="panel-action panel-action-dismiss" data-panel-dismiss=""></a>
                                            </div>--%>
                                        </div>

                                        <div class="panel-body">
                                            <div class="row">

                                                <div class="col-sm-6">
                                                    <label class="control-label">Delivery date</label>
                                                    <asp:TextBox ID="txtDelivery_date" TextMode="Date" class="form-control" runat="server" required=""></asp:TextBox>
                                                    <span class="help-block">Date example: '2016-01-01'</span>
                                                </div>

                                                <div class="col-sm-6">
                                                    <label class="control-label">Delivery time</label>
                                                    <asp:TextBox ID="txtDelivery_time" TextMode="Time" class="form-control" runat="server" required=""></asp:TextBox>
                                                    <span class="help-block">Date example: '01:00 PM'</span>
                                                </div>

                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>

                             
                        </div>
                    </div>
                </div>

                  <div class="row">
                                <div class="col-md-12">
                                    <div class="panel panel-default margin-b-30">

                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="panel panel-default recent-activites">
                                                    <!-- Start .panel -->
                                                    <div class="panel-heading">
                                                        <h4 class="panel-title">Addresses </h4>
                                                      <%--  <div class="panel-actions">
                                                            <a href="#" class="panel-action panel-action-toggle" data-panel-toggle></a>
                                                            <a href="#" class="panel-action panel-action-dismiss" data-panel-dismiss></a>
                                                        </div>--%>
                                                    </div>

                                                    <div class="panel-body">
                                                        <div class="row">
                                                           <%--  <link href="https://fonts.googleapis.com/css?family=Baloo+Paaji" rel="stylesheet">--%>
                                                                    <%-- <link rel="stylesheet" href="Content/Site.css" />--%>

                                                                <input style="width:300px" id="pac-input" class="controls" type="text" 
                                                                    placeholder="Collection address">
                                                                <input style="width:300px" id="destination" class="controls" type="text" 
                                                                   placeholder="Destination adress">
                                                                <input style="width:100px" value="View route" id="submit" type="button" class="controls" >
                                                         
                                                                <div id="map" style="width: 1000px; height: 467px;"></div>
                                                              <asp:HiddenField ID="CollectionAddress" runat="server" />    
                                                             <asp:HiddenField ID="DestinationAddress" runat="server" />
                                                            <asp:HiddenField ID="RouteDistance" runat="server" />
                                                              <div id="directions-panel"></div>
                                                                 <script src="js/Scripts/Routing.js"></script>                     

                                                                <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAnE8qcNXp2QrkvrjBax4Jg5N5cLPlIqvQ&libraries=places&callback=initMap"
                                                                    async defer></script>
                                                                  </div>
                                                               </div>


                                        <div class="form-group">
                                            <div class="col-sm-4 col-sm-offset-0">
                                               
                                               <%-- <button  id="a" class="btn btn-primary" type="submit"  onClick ="CallFunction()" runat="server">JS Sumbit</button>--%>
                                                
                                                <asp:Button ID="btnSubmit"   runat="server" Text="Submit" Class="btn btn-primary" />
                                              
                                             
                                            </div>
                                                
                                        </div>

                                    </div>
                                </div>
                            </div>
           
                 </div>
        </div>
    </section>

      <script>
          function CallFunction() {

              if (confirm("Are you sure all booking details are correct?") == true) {

                  document.getElementById("btnSubmit").click();
                  
              }
              else { }
          }
      </script>

</asp:Content>
