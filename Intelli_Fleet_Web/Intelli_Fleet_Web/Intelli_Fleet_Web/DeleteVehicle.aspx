<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DeleteVehicle.aspx.vb" Inherits="Intelli_Fleet_Web.DeleteVehicle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <section class="page">
        <div id="wrapper">
            <div class="content-wrapper container">
                <div class="row">
                </div>
                <div class="account-col text-center">
                    <h1>Remove Vehicle</h1>
                    <h3>Enter vehicle registration number to remove</h3>

                      <div class="form-group">
                             <asp:TextBox ID="txtReg" placeholder="Vehicle Registration" CssClass="form-control" runat="server" CausesValidation="true"  required=""></asp:TextBox>
                        </div>
                        
                        <asp:Button ID="btnSubmit" Text="Submit" CssClass="btn btn-primary btn-block" runat="server"/>
                       
                <p>Intelli-Fleet &copy; 2016</p>

                    </div>
                </div>
            </div>
    </section>
</asp:Content>
