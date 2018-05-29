<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="newDriver.aspx.vb" Inherits="Intelli_Fleet_Web.newDriver" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <section class="page">
        <div id="wrapper">
            <div class="content-wrapper container">
                <div class="row">
                </div>
                <div class="account-col text-center">
                    <h1>Add Driver</h1>
                    <h3>Driver details</h3>

                                <div class="form-group">
                            <asp:TextBox ID="txtUName" placeholder="Name" CssClass="form-control" runat="server" CausesValidation="true" AutoCompleteType="FirstName" required=""></asp:TextBox>
                        </div>
                    <div class="form-group">
                            <asp:TextBox ID="txtUSurname" placeholder="Surname" CssClass="form-control" runat="server" CausesValidation="true" AutoCompleteType="LastName" required=""></asp:TextBox>
                        </div>
                        <div class="form-group">
                        <asp:TextBox ID="txtUUsername" CssClass="form-control" placeholder="Username" runat="server" CausesValidation="true" AutoCompleteType="FirstName" required=""></asp:TextBox>
                         </div>
                            <div class="form-group">
                             <asp:TextBox ID="txtUEmail" placeholder="Email Address" CssClass="form-control" runat="server" CausesValidation="true"  AutoCompleteType="Email" required=""></asp:TextBox>
                        </div>
                      
                      <div class="form-group">
                             <asp:TextBox ID="txtLicence" placeholder="Licence Number" CssClass="form-control" runat="server" CausesValidation="true"  AutoCompleteType="FirstName" required=""></asp:TextBox>
                        </div>
                      <div class="form-group">
                             <asp:TextBox ID="txtPDP" placeholder="PDP Number" CssClass="form-control" runat="server" CausesValidation="true"  AutoCompleteType="FirstName" required=""></asp:TextBox>
                        </div>
                      <div class="form-group">
                          <label class="control-label">Are all required documents up to date?</label>
                             <asp:DropDownList ID="drpRequirements" placeholder="Licensing Requirements up to Date" CssClass="form-control" runat="server" CausesValidation="true"  required="">
                                 <asp:ListItem Text="Yes"></asp:ListItem>
                                 <asp:ListItem Text="No"></asp:ListItem>
                             </asp:DropDownList>  
                      </div>
                        
                            <div class="form-group">
                                <label class="control-label">Does the driver have a day off?</label>
                             <asp:DropDownList ID="drpDayOff" placeholder="Day Off" CssClass="form-control" runat="server" CausesValidation="true"  required="">
                                 <asp:ListItem Text="Yes" ></asp:ListItem>
                                 <asp:ListItem Text="No"></asp:ListItem>
                             </asp:DropDownList>
                        </div>
                        <div class="form-group">
                             <label class="control-label">Start of shift </label>
                             <asp:TextBox ID="txtShifts" placeholder="Start Shift" CssClass="form-control" runat="server" CausesValidation="true" TextMode="Time"  required=""></asp:TextBox>
                        </div>
                    <div class="form-group">
                         <label class="control-label">End of shift </label>
                             <asp:TextBox ID="txtEnd" placeholder="End Shift" CssClass="form-control" runat="server" CausesValidation="true" textmode="Time" required=""></asp:TextBox>
                        </div>
                    <div class="form-group">
                         <label class="control-label">License Expiry Date </label>
                             <asp:TextBox ID="txtExpiry" placeholder="License Expiry Date" CssClass="form-control" runat="server" CausesValidation="true" TextMode="Date"  required=""></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox  TextMode="Password" ID ="txtUPassword" placeholder="Password" CssClass="form-control" runat="server" CausesValidation="true" required=""></asp:TextBox>
                        </div>  
                        <div class="form-group">
                            <asp:TextBox   TextMode="Password" ID="txtUConfirm" placeholder="Confirm Password" CssClass="form-control" runat="server" CausesValidation="true" required=""></asp:TextBox>
                        </div>
                        <asp:Button ID="btnSubmit" Text="Submit" CssClass="btn btn-primary btn-block" runat="server"/>
                       
                <p>Intelli-Fleet &copy; 2016</p>

                    </div>
                </div>
            </div>
    </section>

</asp:Content>
