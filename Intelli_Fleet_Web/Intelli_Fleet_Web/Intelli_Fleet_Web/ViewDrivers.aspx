<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ViewDrivers.aspx.vb" Inherits="Intelli_Fleet_Web.ViewDrivers1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <section class="page">
        <div id="wrapper">
            <div class="content-wrapper container">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="page-title">
                            <h1>View Drivers<small></small></h1>

                        </div>
                    </div>
                </div>

                <div class="">
                    <h2>Personal details<small></small></h2>


                    <div id="HtmlCode" runat="server">
                        <table style="grid-row-align: center; grid-column-align: center; text-align: center;"></table>
                    </div>

                    <div class="">
                        <h2><small></small></h2>

                    </div>
                    <div class="">
                        <h2>Driving details<small></small></h2>


                        <div id="HtmlCode1" runat="server">
                            <table style="grid-row-align: center; grid-column-align: center; text-align: center;"></table>
                        </div>

                    </div>
                </div>
    </section>
</asp:Content>
