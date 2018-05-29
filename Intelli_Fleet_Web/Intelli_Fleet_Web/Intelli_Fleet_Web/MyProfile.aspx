<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="MyProfile.aspx.vb" Inherits="Intelli_Fleet_Web.MyProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
                <div id="wrapper">
                <div class="content-wrapper container">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="page-title">
                                <h1>My Profile <small></small></h1>
                                <ol class="breadcrumb">
                                    <li><a href="#"><i class="fa fa-home"></i></a></li>
                                    <li class="active">User Profile</li>
                                </ol>
                            </div>
                        </div>
                    </div><!-- end .page title-->


                    <div class="col-md-4 margin-b-30">
                        <div class="profile-overview">
                            
                            <table class="table profile-detail table-condensed table-hover">
                                <thead>
                                    <tr>
                                        <th colspan="3">Personal Information</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Name:</td>
                                        <td>
                                           
                                            <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                                        </td>
                                       
                                    </tr>
                                    <tr>
                                        <td>Surname:</td>
                                        <td>
                                             <asp:Label ID="lblSurname" runat="server" Text="Label"></asp:Label>

                                         </td>
                                    </tr>
                                    <tr>
                                        <td>Email:</td>
                                       <td>
                                             <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>

                                         </td>
                                       
                                    </tr>
                                 
                                </tbody>
                            </table>
                            <table class="table profile-detail table-condensed table-hover">
                                <thead>
                                    <tr>
                                        <th colspan="3">General information</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Orders:</td>
                                        <td> blah blah </td>
                                        
                                    </tr>
                                    <tr>
                                        <td>status:</td>
                                        <td>blah blah</td>
                                       
                                    </tr>
                                 
                                  
                                </tbody>
                            </table>

                        </div>
                    </div>
                    <div class="col-md-5 margin-b-30">
                        <div class="profile-edit">
                            <form class="form-horizontal" method="get">
                                <h4 class="mb-xlg">Edit Information</h4>
                                   <h5 class="mb-xlg">Edit the one(s) you want to edit here, those that u dont want to edit re-enter information</h5>

                                    <div class="form-group">
                                            <br />
                                       <asp:TextBox ID="txtUName" placeholder="Name" CssClass="form-control" runat="server" CausesValidation="true" AutoCompleteType="FirstName" required=""></asp:TextBox>
                                    
                                    </div>
                                 <div class="form-group">
                                      
                                         <asp:TextBox ID="TxtSurname" placeholder="Surname" CssClass="form-control" runat="server" CausesValidation="true" AutoCompleteType="LastName" required=""></asp:TextBox>
                                    </div>
                                  
                                    <div class="form-group">
                                      
                                         <asp:TextBox ID="TxtUrname" placeholder="Username" CssClass="form-control" runat="server" CausesValidation="true" AutoCompleteType="LastName" required=""></asp:TextBox>
                                    </div>
                          
                                   <div class="form-group">
                                      
                                         <asp:TextBox ID="TxtEmail" placeholder="Email address" CssClass="form-control" runat="server" CausesValidation="true" AutoCompleteType="LastName" required=""></asp:TextBox>
                                    </div>
                             <th colspan="3">Change Password</th>
                           <div class="form-group">
                            <asp:TextBox TextMode="password" ID="txtCPassword" CssClass="form-control" placeholder="Current Password" runat="server" CausesValidation="true" required=""></asp:TextBox>
                        </div> <div class="form-group">
                            <asp:TextBox TextMode="password" ID="txtPassword" CssClass="form-control" placeholder="Password" runat="server" CausesValidation="true" required=""></asp:TextBox>
                        </div>
                                    <br />


                                <div class="panel-footer">
                                    <div class="row">
                                        
                                        <div class="col-md-9 col-md-offset-3">
                                              <asp:Button ID="btnSubmit"   runat="server" Text="edit information" Class="btn btn-primary" Width="424px" />
                                              
                                        </div>
                                    </div>
                                </div>

                            </form>
                        </div>
                    </div>
                   
                 </div><!--media-->
                   
            </div>
       
    
</asp:Content>
