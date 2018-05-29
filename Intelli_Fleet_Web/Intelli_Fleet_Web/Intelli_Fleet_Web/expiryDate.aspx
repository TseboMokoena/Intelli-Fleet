<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="expiryDate.aspx.vb" Inherits="Intelli_Fleet_Web.expiryDate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <section class="page">
        <div id="wrapper">
            <div class="content-wrapper container">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="page-title">
                            <h1>Vehicles Expired disc plate<small></small></h1>
                        </div>
                    </div>
                </div>
                 <div class="table-responsive">
                <div id="expiryDate" runat="server">
                    <table style="grid-row-align: center; grid-column-align: center; text-align: center;"></table>
                </div>
                 </div>
                <hr />
                <br />
                
               
               
             <div class="panel-body">

                                <form role="form" class="form-inline">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtPackage_Type" placeholder="Enter vehicle type" class="form-control" runat="server" CausesValidation="true" required=""></asp:TextBox></div>

                                   

               
                                  
                                </form>
                                   <div class="row">
                                <div class="col-md-12">
                                    <div class="panel panel-default margin-b-30">

                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="panel panel-default recent-activites">
                                                    <!-- Start .panel -->
                                                    <div class="panel-heading">
                                                     
                                                    </div>

                           <div class="panel-body">
                                       <div class="row">
                                                          

                                        <div class="form-group">
                                            <div class="col-sm-4 col-sm-offset-0">
                                               
                                               <%-- <button  id="a" class="btn btn-primary" style="display: none;" type="submit"  onClick ="CallFunction()" runat="server">Sumbit</button>--%>
                                                
                                                <asp:Button ID="btnSubmit"   runat="server" Text="update the vehicle licence plate" Class="btn btn-primary" Width="743px" />
                                              
                                             
                                            </div>
                                                
                                        </div>

                                    </div>
                                </div>
                            </div>
           
                 </div>
        </div>
          </div>
              </div>

            </div>
        </div>
    </section>





</asp:Content>
