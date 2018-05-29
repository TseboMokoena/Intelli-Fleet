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
                                            <a href="#">
                                                blah blah   <%-- read from database >--%>
                                            </a></td>
                                        <td><a href="#panel_edit_account" class="show-tab"><i class="fa fa-pencil edit-user-info"></i></a></td>
                                    </tr>
                                    <tr>
                                        <td>Surname:</td>
                                        <td>
                                            <a href="">
                                                 blah blah   <%-- read from database >--%>
                                            </a></td>
                                        <td><a href="#panel_edit_account" class="show-tab"><i class="fa fa-pencil edit-user-info"></i></a></td>
                                    </tr>
                                    <tr>
                                        <td>Email:</td>
                                        <td>blah blah </td>        <%-- read from database >--%>
                                        <td><a href="#panel_edit_account" class="show-tab"><i class="fa fa-pencil edit-user-info"></i></a></td>
                                    </tr>
                                    <tr>
                                        <td>skye</td>
                                        <td>
                                            <a href="">
                                                peterclark82
                                            </a></td>
                                        <td><a href="#panel_edit_account" class="show-tab"><i class="fa fa-pencil edit-user-info"></i></a></td>
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
                                        <td> blah blah </td> <!-->read from database here<-->
                                        <td><a href="#panel_edit_account" class="show-tab"><i class="fa fa-pencil edit-user-info"></i></a></td>
                                    </tr>
                                    <tr>
                                        <td>status:</td>
                                        <td>blah blah</td>
                                        <td><a href="#panel_edit_account" class="show-tab"><i class="fa fa-pencil edit-user-info"></i></a></td>
                                    </tr>
                                 
                                  
                                </tbody>
                            </table>

                        </div>
                    </div>
                    <div class="col-md-5 margin-b-30">
                        <div class="profile-edit">
                            <form class="form-horizontal" method="get">
                                <h4 class="mb-xlg">Edit Information</h4>
                           

                                    <div class="form-group">
                                            <br />
                                       <asp:TextBox ID="txtUName" placeholder="Name" CssClass="form-control" runat="server" CausesValidation="true" AutoCompleteType="FirstName" required=""></asp:TextBox>
                                    
                                    </div>
                                 <div class="form-group">
                                      
                                         <asp:TextBox ID="TxtSurname" placeholder="Surname" CssClass="form-control" runat="server" CausesValidation="true" AutoCompleteType="LastName" required=""></asp:TextBox>
                                    </div>
                                  
                                    <div class="form-group">
                                             <br />
                                        <label class="col-md-3 control-label" for="profileUsername">Username</label>
                                        <div class="col-md-8">
                                            <input type="text" class="form-control" id="Text3">
                                        </div>
                                    </div>
                          
                                    <div class="form-group">
                                             <br />
                                        <label class="col-md-3 control-label" for="profileEmail">EmailAdress</label>
                                        <div class="col-md-8">
                                            <input type="text" class="form-control" id="Text2">
                                        </div>
                                    </div>
                             <th colspan="3">Change Password</th>
                               <div class="form-group">
                                             <br />
                                        <label class="col-md-3 control-label" for="profileCpassword">Current </label>
                                        <div class="col-md-8">
                                            <input type="text" class="form-control" id="Text4">
                                        </div>
                                    </div>
                                <div class="form-group">
                                             <br />
                                        <label class="col-md-3 control-label" for="profileNpassword">Password</label>
                                        <div class="col-md-8">
                                            <input type="text" class="form-control" id="Text5">
                                        </div>
                                    </div>
                                    <br />


                                <div class="panel-footer">
                                    <div class="row">
                                        
                                        <div class="col-md-9 col-md-offset-3">
                                            <button type="submit" class="btn btn-primary">Submit</button>
                                            <button type="reset" class="btn btn-default">Reset</button>
                                        </div>
                                    </div>
                                </div>

                            </form>
                        </div>
                    </div>
                   
                 </div><!--media-->
                   
            </div>
       
    
</asp:Content>
