<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="SignIn.aspx.vb" Inherits="Intelli_Fleet_Web.SignIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<style>
.alert {
    padding: 20px;
    background-color: #f44336;
    color: white;
    opacity: 1;
    transition: opacity 0.6s;
    margin-bottom: 15px;
}

.alert.success {background-color: #4CAF50;}
.alert.info {background-color: #2196F3;}
.alert.warning {background-color: #ff9800;}

.closebtn {
    margin-left: 15px;
    color: white;
    font-weight: bold;
    float: right;
    font-size: 22px;
    line-height: 20px;
    cursor: pointer;
    transition: 0.3s;
}

.closebtn:hover {
    color: black;
}
</style>
    
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
                                        
                        <p><a href="ForgotSercurity.aspx"><small>Forgot password?</small></a></p>
                         <p class=" text-center"><small>Do not have an account?</small></p>
                         <a class="btn  btn-default btn-block" href="Registration.aspx">Create an account</a> 
                           <p>Intelli-Fleet &copy; 2016</p>    
                    
                        <div id ="AlertCode" runat ="server" ></div>


                </div>
            </div>
        </div>
    </div>         
  </section> 

    <script>
        var close = document.getElementsByClassName("closebtn");
        var i;

        for (i = 0; i < close.length; i++) {
            close[i].onclick = function () {
                var div = this.parentElement;
                div.style.opacity = "0";
                setTimeout(function () { div.style.display = "none"; }, 600);
            }
        }
</script>

</asp:Content>
