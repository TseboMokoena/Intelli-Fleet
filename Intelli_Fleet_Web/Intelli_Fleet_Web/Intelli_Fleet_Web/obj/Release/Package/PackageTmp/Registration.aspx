<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Registration.aspx.vb" Inherits="Intelli_Fleet_Web.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
         <section class="page">           
            <div id="wrapper">
                <div class="content-wrapper container">
            <div class="row">
                <div class="account-col text-center">
                    <h1>Register</h1>
                    <h3>Create New account</h3>
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
                            <asp:TextBox  TextMode="Password" ID ="txtUPassword" placeholder="Password" CssClass="form-control" runat="server" CausesValidation="true" required=""></asp:TextBox>
                        </div>  
                        <div class="form-group">
                            <asp:TextBox   TextMode="Password" ID="txtUConfirm" placeholder="Confirm Password" CssClass="form-control" runat="server" CausesValidation="true" required=""></asp:TextBox>
                        </div>
                        <asp:Button ID="btnSubmit" Text="Submit" CssClass="btn btn-primary btn-block" runat="server"/>
                         <p class=" text-center"><small>Already have an account?</small></p>
                <a id="A1" class="btn  btn-default btn-block" runat="server" href="Signin.aspx">Log into account</a>
                <p>Intelli-Fleet &copy; 2016</p>
                   
                </div>
            </div>
        </div>
      
<%--   <script type="text/javascript" src="bootstrap/js/bootstrap.min.js"></script>
        <script src="js/pace.min.js"></script>--%>
    </div>
  </section>
    
</asp:Content>
