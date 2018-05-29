<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Bookings.aspx.vb" Inherits="Intelli_Fleet_Web.Bookings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <section class="page">
        <div id="wrapper">
            <div class="content-wrapper container">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="page-title">
                            <h1>Make a booking<small></small></h1>
                            <h3>Enter delivery and package details</h3>
                        </div>
                    </div>
                </div>

                  <div class="row">
                    <div class="col-md-6">
                        <div class="panel panel-default margin-b-30">

                            <div class="panel-heading">
                                <h4 class="panel-title">Package Information</h4>
                                <div class="panel-actions">
                                    <a href="#" class="panel-action panel-action-toggle" data-panel-toggle></a>
                                    <a href="#" class="panel-action panel-action-dismiss" data-panel-dismiss></a>
                                </div>
                            </div>

                            <div class="panel-body">

                                <form role="form" class="form-inline">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtPackage_Type" placeholder="Package Type (Equipment, perishable goods etc.)" class="form-control" runat="server" CausesValidation="true" required=""></asp:TextBox></div>

                                    <div class="form-group">
                                        <asp:TextBox ID="txtPackage_Weight" TextMode="number" placeholder="Package Weight(kg)" class="form-control" runat="server" CausesValidation="true" required=""></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <asp:TextBox ID="txtPackage_Height" TextMode="number" placeholder="Packaging Height(cm)" class="form-control" runat="server" CausesValidation="true" required=""></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <asp:TextBox ID="txtPackage_Length" TextMode="number" placeholder="Packaging Lengh(cm)" class="form-control" runat="server" CausesValidation="true" required=""></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <asp:TextBox ID="txtPackage_Breath" TextMode="number" placeholder="Packaging Breath(cm)" class="form-control" runat="server" CausesValidation="true" required=""></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <asp:TextBox ID="txtPackage_Quantity" TextMode="number" placeholder="Quantity of items" class="form-control" runat="server" CausesValidation="true" required=""></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-8 control-label">Special vehicle requirements</label>
                                        <div class="col-sm-10">
                                            <div>
                                                <asp:CheckBox ID="boxRefrig" runat="server" />Refrigiration</label></div>
                                            <div>
                                                <asp:CheckBox ID="boxHeater" runat="server" />Heater</label></div>
                                            <div>
                                                <asp:CheckBox ID="boxCannopy" runat="server" />Open Canopy</label></div>
                                            <%--  <div class="col-sm-8"><input type="text" placeholder="Other" class="form-control"></div>--%>
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
                                            <div class="panel-actions">
                                                <a href="#" class="panel-action panel-action-toggle" data-panel-toggle=""></a>
                                                <a href="#" class="panel-action panel-action-dismiss" data-panel-dismiss=""></a>
                                            </div>
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
                                                        <div class="panel-actions">
                                                            <a href="#" class="panel-action panel-action-toggle" data-panel-toggle></a>
                                                            <a href="#" class="panel-action panel-action-dismiss" data-panel-dismiss></a>
                                                        </div>
                                                    </div>

                                                    <div class="panel-body">
                                                        <div class="row">

                                                            <div class="col-sm-6">
                                                                <label class="control-label">Collection Adress</label>
                                                                <asp:TextBox ID="txtCollection" class="form-control" runat="server"></asp:TextBox>

                                                            </div>

                                                            <div class="col-sm-6">
                                                                <label class="control-label">Destination adress</label>
                                                                <asp:TextBox ID="txtDestination" class="form-control" runat="server"></asp:TextBox>

                                                            </div>

                                                        </div>
                                                        <div class="hr-line-dashed"></div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>



                                        <div class="form-group">
                                            <div class="col-sm-4 col-sm-offset-0">
                                                <%--<button class="btn btn-white" type="submit">Cancel</button>--%>
                                                <%--<button class="btn btn-primary" type="submit">Sumbit</button>--%>
                                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" Class="btn btn-primary" />
                                                <%-- <asp:LinkButton ID="temp" Text="Temporary submit button" OnClick="Temp_Click" runat="server" />--%>
                                            </div>

                                        </div>

                                    </div>
                                </div>
                            </div>
           
                 </div>
        </div>
    </section>
</asp:Content>
