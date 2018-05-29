<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Reports.aspx.vb" Inherits="Intelli_Fleet_Web.Reports1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="page">
    <div id="wrapper">
                <div class="content-wrapper container">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="page-title">
                                <h1>Financial Report<small></small></h1>
                               
                            </div>
                        </div>
                    </div><!-- end .page title-->

                    
                    
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="panel panel-default recent-activites">
                                <!-- Start .panel -->
                                <div class="panel-heading">
                                    <h4 class="panel-title">Yearly report</h4>
                                    <div class="panel-actions">
                                        <asp:TextBox ID="txtBranch" Visible="false" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="panel-body text-center">
                                   <div id="morris-one-line-chart" ></div>

                                </div>
                                <button type="button" class="btn btn-default" data-container="body" data-toggle="popover" data-placement="top" data-content="This report displays the financial income for the year in terms of Rands. Pink represent the current year and gray represents the previous years.">
                                     Report Guide
                               </button>
                            </div><!-- End .panel --> 
                            

                            <div class="panel panel-default recent-activites">
                                <!-- Start .panel -->
                                <div class="panel-heading">
                                    <h4 class="panel-title"> Savings Estimations </h4>
                                    <div class="panel-actions">
                                        
                                    </div>
                                </div>
                                <div class="panel-body text-center">
                                  <div id="morris-line-chart"></div>

                                </div>
                                <button type="button" class="btn btn-default" data-container="body" data-toggle="popover" data-placement="top" data-content="This report displays the amount of money saved for the year in terms of Rands. Pink represent the current year and blue represents the previous years.">
                                     Report Guide
                               </button>
                            </div><!-- End .panel --> 

                            <div class="panel panel-default recent-activites">
                            <!-- Start .panel -->
                                <div class="panel-heading">
                                    <h4 class="panel-title"> Total Value of Bookings Created </h4>
                                    <div class="panel-actions">
                                        
                                    </div>
                                </div>
                                <div class="panel-body text-center">
                                <div id="morris-bar-chart"></div>
                                </div>
                                <button type="button" class="btn btn-default" data-container="body" data-toggle="popover" data-placement="top" data-content="This report displays the amount of money made in rands in terms of bookings made for the year. Pink represent the current year and gray represents the previous years.">
                                     Report Guide
                               </button>
                            </div><!-- End .panel -->
                             
                            </div>
                 </div>
             </div>
           
                
     </section>
        <script type="text/javascript" src="js/jquery.min.js"></script>
        <script type="text/javascript" src="bootstrap/js/bootstrap.min.js"></script>
        <script src="js/metisMenu.min.js"></script>
        <script src="js/jquery-jvectormap-1.2.2.min.js"></script>
        <script src="js/jquery.flot.min.js"></script>
        <script src="js/jquery.flot.resize.min.js"></script>
        <script src="js/jquery.flot.time.min.js"></script>
        <script src="js/jquery.flot.threshold.js"></script>
        <script src="js/jquery.flot.axislabels.js"></script>
        <script src="js/pace.min.js"></script>
        <script src="js/waves.min.js"></script>
         <script src="js/morris_chart/raphael-2.1.0.min.js"></script>
            <script src="js/morris_chart/morris.js"></script>
        <script src="js/jquery-jvectormap-world-mill-en.js"></script>
        <!--        <script src="js/jquery.nanoscroller.min.js"></script>-->
        <script type="text/javascript" src="js/custom.js"></script>
         <script src="js/morris-custom.js"></script>
</asp:Content>