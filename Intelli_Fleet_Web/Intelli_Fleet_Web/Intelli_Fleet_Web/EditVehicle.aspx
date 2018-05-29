<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="EditVehicle.aspx.vb" Inherits="Intelli_Fleet_Web.EditVehicle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <section class="page">
        <div id="wrapper">
            <div class="content-wrapper container">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="page-title">
                            <h1>Edit Vehicle<small></small></h1>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <asp:TextBox ID="txtVehicleRegistration" placeholder="Vehicle Registration" CssClass="form-control" runat="server" CausesValidation="true" AutoCompleteType="FirstName" required=""></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Button ID="btnDetails" Text="Retirieve Details" CssClass="btn btn-primary btn-block" runat="server" />
                </div>

                <div class="form-group">
                    <asp:TextBox ID="txtVehicleRegistrations" placeholder="Vehicle Registration" CssClass="form-control" runat="server" CausesValidation="true" AutoCompleteType="FirstName"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtVehicleType" placeholder="Vehicle Type" CssClass="form-control" runat="server" CausesValidation="true" AutoCompleteType="LastName"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtVehicleVolume" CssClass="form-control" placeholder="Vehicle Volume" runat="server" CausesValidation="true" AutoCompleteType="FirstName"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtWeightSupported" placeholder="Weight Supported " CssClass="form-control" runat="server" CausesValidation="true" AutoCompleteType="Email"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:TextBox ID="txtKilometersDriven" placeholder="Kilometers Driven" CssClass="form-control" runat="server" CausesValidation="true" AutoCompleteType="FirstName"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtDiscExpiryDate" placeholder="Disc Expiry Date" CssClass="form-control" runat="server" CausesValidation="true" AutoCompleteType="FirstName"></asp:TextBox>
                </div>

                
                <asp:Button ID="btnSubmit" Text="Edit Vehicle" CssClass="btn btn-primary btn-block" runat="server" />

                <p>Intelli-Fleet &copy; 2016</p>

            </div>
        </div>

    </section>
</asp:Content>
