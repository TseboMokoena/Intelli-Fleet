<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="editDriver.aspx.vb" Inherits="Intelli_Fleet_Web.editDriver" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <section class="page">
        <div id="wrapper">
            <div class="content-wrapper container">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="page-title">
                            <h1>Edit driver<small></small></h1>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <asp:TextBox ID="txtUsername" placeholder="Driver USername" CssClass="form-control" runat="server" CausesValidation="true" AutoCompleteType="FirstName" required=""></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Button ID="btnDetails" Text="Retirieve Details" CssClass="btn btn-primary btn-block" runat="server" />
                </div>

                <div class="form-group">
                    <asp:TextBox ID="txtUName" placeholder="Name" CssClass="form-control" runat="server" CausesValidation="true" AutoCompleteType="FirstName"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtUSurname" placeholder="Surname" CssClass="form-control" runat="server" CausesValidation="true" AutoCompleteType="LastName"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtUUsername" CssClass="form-control" placeholder="Username" runat="server" CausesValidation="true" AutoCompleteType="FirstName"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtUEmail" placeholder="Email Address" CssClass="form-control" runat="server" CausesValidation="true" AutoCompleteType="Email"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:TextBox ID="txtLicence" placeholder="Licence Number" CssClass="form-control" runat="server" CausesValidation="true" AutoCompleteType="FirstName"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtPDP" placeholder="PDP Number" CssClass="form-control" runat="server" CausesValidation="true" AutoCompleteType="FirstName"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label class="control-label">Are all required documents up to date?</label>
                    <asp:DropDownList ID="drpRequirements" placeholder="Licensing Requirements up to Date" CssClass="form-control" runat="server" CausesValidation="true">
                        <asp:ListItem Text="True"></asp:ListItem>
                        <asp:ListItem Text="False"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="form-group">
                    <label class="control-label">Does the driver have a day off?</label>
                    <asp:DropDownList ID="drpDayOff" placeholder="Day Off" CssClass="form-control" runat="server" CausesValidation="true">
                        <asp:ListItem Text="True"></asp:ListItem>
                        <asp:ListItem Text="False"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label class="control-label">Start of shift </label>
                    <asp:TextBox ID="txtShifts" placeholder="Start Shift" CssClass="form-control" runat="server" CausesValidation="true" ></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label">End of shift </label>
                    <asp:TextBox ID="txtEnd" placeholder="End Shift" CssClass="form-control" runat="server" CausesValidation="true" ></asp:TextBox>
                </div>
                
                <div class="form-group">
                    <asp:TextBox ID="txtExpiry" placeholder="License Expiry Date" CssClass="form-control" runat="server" CausesValidation="true"></asp:TextBox>
                </div>
               
                <asp:Button ID="btnSubmit" Text="Edit Driver" CssClass="btn btn-primary btn-block" runat="server" />

                <p>Intelli-Fleet &copy; 2016</p>

            </div>
        </div>

    </section>
</asp:Content>
