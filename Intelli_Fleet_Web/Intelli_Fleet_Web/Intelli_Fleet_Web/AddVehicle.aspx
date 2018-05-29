<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AddVehicle.aspx.vb" Inherits="Intelli_Fleet_Web.AddVehicle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <section class="page">
        <div id="wrapper">
            <div class="content-wrapper container">
                <div class="row">
                </div>
                <div class="account-col text-center">
                    <h1>Add Vehicle</h1>
                    <h3>Vehicle details</h3>
                    <div class="form-group">
                        <asp:TextBox ID="txtVehicleReg" placeholder="Vehicle Registration" CssClass="form-control" runat="server" CausesValidation="true" AutoCompleteType="FirstName" required=""></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtType" placeholder="Vehicle Type" CssClass="form-control" runat="server" CausesValidation="true" AutoCompleteType="LastName" required=""></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtVolume" CssClass="form-control" placeholder="Vehicle Volume" runat="server" CausesValidation="true" TextMode="number" required=""></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtSize" placeholder="Vehicle Weight (i.e 1000 (kg))" CssClass="form-control" runat="server" CausesValidation="true" TextMode="number" required=""></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="TxtMaintance" placeholder="Kilometers Traveled" CssClass="form-control" runat="server" CausesValidation="true" TextMode="number" required=""></asp:TextBox>
                        </div>

                      <div class="form-group">
                            <label class="control-label">Licence Disk expiry date</label>
                            <asp:TextBox ID="txtExDate" TextMode="Date" class="form-control" runat="server" required=""></asp:TextBox>
                            
                        </div>

                        <asp:Button ID="btnSubmit" Text="Add Vehicle" CssClass="btn btn-primary btn-block" runat="server" />


                    </div>
                </div>
            </div>
    </section>
</asp:Content>
