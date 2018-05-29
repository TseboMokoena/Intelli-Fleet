<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AssignOrder.aspx.vb" Inherits="Intelli_Fleet_Web.AssignOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="page">
        <div id="wrapper">
            <div class="content-wrapper container">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="page-title">
                            <h1>Assign Bookings<small></small></h1>

                        </div>
                    </div>
                </div>

                <div class="row">
                    <h2>Pending Bookings</h2>

                    <div id="HtmlCode" runat="server">
                        <table style="grid-row-align: center; grid-column-align: center; text-align: center;"></table>
                    </div>

                    <div class="row">
                        <h2>Available Drivers</h2>


                        <div id="HtmlCode1" runat="server">
                            <table style="grid-row-align: center; grid-column-align: center; text-align: center;"></table>
                        </div>

                        <div class="account-col text-center">
                            <div class="form-group">
                                <asp:TextBox ID="txtBooking_Id" CssClass="form-control" placeholder="Booking ID" runat="server" CausesValidation="true" TextMode="Number" required=""></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtDriver_Id" CssClass="form-control" placeholder="Driver ID" runat="server" CausesValidation="true" TextMode="Number" required=""></asp:TextBox>
                            </div>
                            <asp:Button ID="btnAssign" Text="Assign to driver" CssClass="btn btn-primary btn-block" runat="server" Width="300px" />
                        </div>

                    </div>
                </div>
    </section>


</asp:Content>
