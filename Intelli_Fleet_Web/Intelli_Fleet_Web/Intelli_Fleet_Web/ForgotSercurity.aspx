<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ForgotSercurity.aspx.vb" Inherits="Intelli_Fleet_Web.ForgotSercurity" %>
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
                    <h1>fill the following security question</h1>
           

                     <div id ="AlertCode" runat ="server" ></div>

                
                        <div class="form-group">
                        <asp:TextBox ID="txtUUsername" CssClass="form-control" placeholder="Username" runat="server" CausesValidation="true" AutoCompleteType="FirstName" required=""></asp:TextBox>
                      
                        <div class="form-group">
                           <asp:Label ID="Label1" runat="server" Text="Pick a question and answer (For security reasons)"></asp:Label>
                        
                            <asp:DropDownList ID="ddlQuestions" runat="server" Width="200px">
                            
                               <asp:ListItem Text="Select a question" Value="0"></asp:ListItem>
                                 <asp:ListItem Text="What is your pet name?" Value="What is your pet name?"></asp:ListItem>
                                <asp:ListItem Text="What is your favourite colour?" Value="What is your favourite colour?"></asp:ListItem>
                                <asp:ListItem Text="In which town were you born?" Value="In which town were you born?"></asp:ListItem>
                            </asp:DropDownList>
                        <br>
                    </div>
                 
                        <div class="form-group">
                             <asp:TextBox ID="txtAns" placeholder="Answer the question" CssClass="form-control" runat="server" CausesValidation="true"  AutoCompleteType="Email" required=""></asp:TextBox>
                                  
                        </div>
                    <%--  --%>

                    




                        <asp:Button ID="btnSubmit" Text="Submit" CssClass="btn btn-primary btn-block" runat="server"/>
                    
                   
                    
                </div>
            </div>
        </div>

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

               
                <div id="AlertScript" style="width:600px;height:300px" runat ="server"></div>

<%--   <script type="text/javascript" src="bootstrap/js/bootstrap.min.js"></script>
        <script src="js/pace.min.js"></script>--%>
    </div>
  </section>
    






</asp:Content>
