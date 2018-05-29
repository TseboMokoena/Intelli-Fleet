<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="SignIn.aspx.vb" Inherits="Intelli_Fleet_Web.SignIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <section class="page">           
            <div id="wrapper">
                <div class="content-wrapper container">

                 <div class="row">
                <div class="account-col text-center">

                     <h1>Login</h1>
                    <h3>Log into your account</h3>
                    <div class="form-group">
                            <asp:TextBox ID="txtUsername" CssClass="form-control" placeholder="Username" runat="server" CausesValidation="true" required=""></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox TextMode="password" ID="txtPassword" CssClass="form-control" placeholder="Password" runat="server" CausesValidation="true" required=""></asp:TextBox>
                        </div>
                         <asp:Button ID="btnSubmit" runat="server" Text="Submit" Class="btn btn-primary btn-block" />
                     <%--   <asp:LinkButton id="Temp" Text="Temporary Login button" OnClick="Temp_Click" runat="server"/>   --%>
                                        
                        <p><a href="Security.aspx"><small>Forgot password?</small></a></p>
                         <p class=" text-center"><small>Do not have an account?</small></p>
                         <a class="btn  btn-default btn-block" href="Registration.aspx">Create an account</a> 
                           <p>Intelli-Fleet &copy; 2016</p>        

                </div>
            </div>
        </div>
    </div>         
  </section> 
   
      <%--  <script type="text/javascript" src="js/jquery.min.js"></script>--%>
       <%-- <script type="text/javascript" src="bootstrap/js/bootstrap.min.js"></script>
        <script src="js/pace.min.js"></script>--%>
</asp:Content>
