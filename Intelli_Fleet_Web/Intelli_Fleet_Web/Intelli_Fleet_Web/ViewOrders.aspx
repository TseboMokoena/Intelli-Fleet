<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ViewOrders.aspx.vb" Inherits="Intelli_Fleet_Web.ViewOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="page">
        <div id="wrapper">
            <div class="content-wrapper container">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="page-title">
                            <h1>Bookings<small></small></h1>

                        </div>
                    </div>
                </div>

                 <div class="table-responsive">
                <div id="HtmlCode" runat="server">
                    <table style="grid-row-align: center; grid-column-align: center; text-align: center;"></table>
                </div>
                     </div>


            </div>
        </div>
    </section>
</asp:Content>
