﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="VehicleReport.aspx.vb" Inherits="Intelli_Fleet_Web.VehicleReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <section class="page">
        <div id="wrapper">
            <div class="content-wrapper container">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="page-title">
                             <h1>Report<small></small></h1>
                            
                        </div>
                    </div>
                </div>

                <div class="row">
                  
                     <div class="col-sm-6">

                        </div>

                    <div class="panel panel-default">
                         <div class="panel-heading">
                                    <h4 class="panel-title"> Actual income vs Desired income generated by the vehicles </h4>
                                    <div class="panel-actions">
                                        <asp:TextBox ID="txtBranch" Visible="false" runat="server"></asp:TextBox>
                                    </div>
                             </div>
                              <div>
                                <canvas id="lineChart" height="140"></canvas>
                            </div>
                                <button type="button" class="btn btn-default" data-container="body" data-toggle="popover" data-placement="top" data-content="The dialy target is R10 000. Percentage of what has been made dialy. Pink represents the actual performance and gray represents desired performance">
                                     Weekly report guide
                               </button>
                             </div>

                   
                   
                            <div class="panel panel-default ">
                                <!-- Start .panel -->
                                <div class="panel-heading">
                                    <h4 class="panel-title">Vehicles generating the highest income</h4>
                                    <div class="panel-actions">
                                     
                                    </div>
                                </div>
                                <div class="panel-body">
                                    <div>
                                        <canvas id="barChart" height="50" width="120"></canvas>
                                    </div>
                                </div>
                                  <button type="button" class="btn btn-default" data-container="body" data-toggle="popover" data-placement="top" data-content="The dialy target is R10 000. Percentage of what has been made dialy. Pink represent the lastest week and gray last week">
                                     Weekly report guide
                               </button>
                            </div><!-- End .panel -->  
                   
                           <div class="panel panel-default ">
                                <!-- Start .panel -->
                                <div class="panel-heading">
                                    <h4 class="panel-title">Number of Vehicles</h4>
                                    <div class="panel-actions">
                                     
                                    </div>
                                </div>

                               

                                <div class="panel-body">
                                    <div>
                                        <canvas id="doughnutChart" height="90" width="200"></canvas>
                                    </div>
                                </div>
                               <button type="button" class="btn btn-default" data-container="body" data-toggle="popover" data-placement="top" data-content="Pink represent the 1 ton trucks, gray represents 5 ton trucks, grey represents 10 ton trucks and white represents 20 ton trucks.">
                                     Report
                               </button>
                                                       
                           <div class="panel panel-default ">
                            <div class="panel-heading">
                                    <h4 class="panel-title"> Mileage in kilometers Covered</h4>
                                    <div class="panel-actions">

                                    </div>
                                </div>
                                <div class="panel-body text-center">
                                   <div class="text-center">
                                <canvas id="polarChart" height="140"></canvas>
                            </div>
                                </div>
                               <button type="button" class="btn btn-default" data-container="body" data-toggle="popover" data-placement="top" data-content="The dialy target is R10 000. Percentage of what has been made dialy. Pink represent the lastest week and gray last week">
                                     Report Guide
                               </button>
                        </div>  <%--end of panel--%>

                               <div class="panel panel-default">
                         <div class="panel-heading">
                                    <h4 class="panel-title"> Total income based on the number of vehicles</h4>
                                    <div class="panel-actions">
                                    </div>
                             </div>
                              <div>
                                <canvas id="lineChart1" height="140"></canvas>
                            </div>
                                <button type="button" class="btn btn-default" data-container="body" data-toggle="popover" data-placement="top" data-content="Pink represents 10% more vehicles, grey represents current amount and blue represents 10% less vehicles">
                                     Report guide
                               </button>
                             </div>

               </div>
             </div>
            </div>
            </div>
    </section>
       <script type="text/javascript" src="js/jquery.min.js"></script>
        <script type="text/javascript" src="bootstrap/js/bootstrap.min.js"></script>
        <script src="js/metisMenu.min.js"></script>
        <script src="js/jquery-jvectormap-1.2.2.min.js"></script>

        <!-- Flot -->
        <script src="js/flot/jquery.flot.js"></script>
        <script src="js/flot/jquery.flot.tooltip.min.js"></script>
        <script src="js/flot/jquery.flot.resize.js"></script>
        <script src="js/flot/jquery.flot.pie.js"></script>
        <script src="js/chartjs/Chart.min.js"></script>
        <script src="js/pace.min.js"></script>
        <script src="js/waves.min.js"></script>
        <script src="js/morris_chart/raphael-2.1.0.min.js"></script>
        <script src="js/morris_chart/morris.js"></script>

        <script src="js/jquery-jvectormap-world-mill-en.js"></script>

        <!--        <script src="js/jquery.nanoscroller.min.js"></script>-->
        <script type="text/javascript" src="js/custom.js"></script>

        <!-- ChartJS-->
     <asp:HiddenField ID="day1" runat="server" />
     <asp:HiddenField ID="day2" runat="server" />
     <asp:HiddenField ID="day3" runat="server" />
     <asp:HiddenField ID="day4" runat="server" />
     <asp:HiddenField ID="day5" runat="server" />
     <asp:HiddenField ID="day6" runat="server" />
     <asp:HiddenField ID="day7" runat="server" />
        <script src="js/chartjs/Chart.min.js"></script>

      <script type="text/javascript">
          $(function () {


              var day1 = (document.getElementById('MainContent_day1').value);
              var barData = {
                  labels: ["1 Ton van", "5 Ton van", "10 Ton Truck", "20 Ton Truck"],
                  datasets: [
                      {
                          label: "My First dataset",
                          //  fillColor: "rgba(220,220,220,0.5)",
                          fillColor: "rgba(223, 61, 130,0.5)",
                          strokeColor: "rgba(220,220,220,0.8)",
                          highlightFill: "rgba(220,220,220,0.75)",
                          highlightStroke: "rgba(220,220,220,1)",
                          data: [6500, 5900, 8000, 8100]
                      },
                      //{
                      //    label: "My Second dataset",
                      //    fillColor: "rgba(223, 61, 130,0.5)",
                      //    strokeColor: "rgba(223, 61, 130,0.8)",
                      //    highlightFill: "rgba(223, 61, 130,0.75)",
                      //    highlightStroke: "rgba(223, 61, 130,1)",
                      //    data: [0, 0, 0, 0, 0, 0, 0]
                      //}
                  ]
              };

              var barOptions = {
                  scaleBeginAtZero: true,
                  scaleShowGridLines: true,
                  scaleGridLineColor: "rgba(0,0,0,.05)",
                  scaleGridLineWidth: 1,
                  barShowStroke: true,
                  barStrokeWidth: 2,
                  barValueSpacing: 7,
                  barDatasetSpacing: 1,
                  responsive: true
              };


              var ctx = document.getElementById("barChart").getContext("2d");
              var myNewChart = new Chart(ctx).Bar(barData, barOptions);

          });
        </script>
            
      <script>
          $(document).ready(function () {

              var doughnutData = [
              {
                  value: 4,
                  color: "#55b3ee",
                  highlight: "#288ccb",
                  label: "20 Ton"
              },
              {
                  value: 4,
                  color: "#df3d82",
                  highlight: "#288ccb",
                  label: "1 Ton"
              },
              {
                  value: 4,
                  color: "#dedede",
                  highlight: "#288ccb",
                  label: "5 Ton"
              },
              {
                  value: 4,
                  color: "#b5b8cf",
                  highlight: "#288ccb",
                  label: "10 Ton"
              }
              ];

              var doughnutOptions = {
                  segmentShowStroke: true,
                  segmentStrokeColor: "#fff",
                  segmentStrokeWidth: 2,
                  percentageInnerCutout: 45, // This is 0 for Pie charts
                  animationSteps: 100,
                  animationEasing: "easeOutBounce",
                  animateRotate: true,
                  animateScale: false,
                  responsive: true
              };

              var ctx = document.getElementById("doughnutChart").getContext("2d");
              var myNewChart = new Chart(ctx).Doughnut(doughnutData, doughnutOptions);
          });
        </script>  
    
        <script>
            $(document).ready(function () {
                var polarData = [
                   {
                       value: 5600,
                       color: "#df3d82",
                       highlight: "#288ccb",
                       label: "Mileage: 1 Ton"
                   },
                   {
                       value: 1400,
                       color: "#dedede",
                       highlight: "#288ccb",
                       label: "Mileage: 5 Ton"
                   },
                   {
                       value: 2000,
                       color: "#b5b8cf",
                       highlight: "#288ccb",
                       label: "Mileage: 10 Ton"
                   },
                   {
                       value: 3500,
                       color: "#55b3ee",
                       highlight: "#288ccb",
                       label: "Mileage: 20 Ton"
                   }
                ];

                var polarOptions = {
                    scaleShowLabelBackdrop: true,
                    scaleBackdropColor: "rgba(255,255,255,0.75)",
                    scaleBeginAtZero: true,
                    scaleBackdropPaddingY: 1,
                    scaleBackdropPaddingX: 1,
                    scaleShowLine: true,
                    segmentShowStroke: true,
                    segmentStrokeColor: "#fff",
                    segmentStrokeWidth: 2,
                    animationSteps: 100,
                    animationEasing: "easeOutBounce",
                    animateRotate: true,
                    animateScale: false,
                    responsive: true

                };

                var ctx = document.getElementById("polarChart").getContext("2d");
                var myNewChart = new Chart(ctx).PolarArea(polarData, polarOptions);
            });
    </script>

       <script>
           $(function () {
               var rand100Factor = function () { return Math.round(Math.random() * 10000 + 1000) };

               var lineData = {
                   labels: ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"],
                   datasets: [
                       {
                           label: "Example dataset",
                           fillColor: "rgba(220,220,220,0.5)",
                           strokeColor: "rgba(220,220,220,1)",
                           pointColor: "rgba(220,220,220,1)",
                           pointStrokeColor: "#fff",
                           pointHighlightFill: "#fff",
                           pointHighlightStroke: "rgba(220,220,220,1)",
                           data: [rand100Factor(), rand100Factor(), rand100Factor(), rand100Factor(), rand100Factor(), rand100Factor(), rand100Factor(), rand100Factor(), rand100Factor(), rand100Factor(), rand100Factor(), rand100Factor()]
                       },
                       {
                           label: "Example dataset",
                           fillColor: "rgba(223, 61, 130,0.5)",
                           strokeColor: "rgba(223, 61, 130,0.7)",
                           pointColor: "rgba(223, 61, 130,1)",
                           pointStrokeColor: "#fff",
                           pointHighlightFill: "#fff",
                           pointHighlightStroke: "rgba(223, 61, 130,1)",
                           data: [rand100Factor(), rand100Factor(), rand100Factor(), rand100Factor(), rand100Factor(), rand100Factor(), rand100Factor(), rand100Factor(), rand100Factor(), rand100Factor(), rand100Factor(), rand100Factor()]
                       }
                   ]
               };

               var lineOptions = {
                   scaleShowGridLines: true,
                   scaleGridLineColor: "rgba(0,0,0,.05)",
                   scaleGridLineWidth: 1,
                   bezierCurve: true,
                   bezierCurveTension: 0.4,
                   pointDot: true,
                   pointDotRadius: 4,
                   pointDotStrokeWidth: 1,
                   pointHitDetectionRadius: 20,
                   datasetStroke: true,
                   datasetStrokeWidth: 2,
                   datasetFill: true,
                   responsive: true
               };
               var ctx = document.getElementById("lineChart").getContext("2d");
               var myNewChart = new Chart(ctx).Line(lineData, lineOptions);
           });
       </script>

    <script>
        $(function () {
            var rand100Factor = function () { return Math.round(Math.random() * 20000) };
            var rand100Factor1 = function () { return Math.round(Math.random() * 5000) };

            var lineData = {
                labels: [" ", " ", "  "],
                datasets: [
                    {
                        label: "Example dataset",
                        fillColor: "rgba(220,220,220,0.5)",
                        strokeColor: "rgba(220,220,220,1)",
                        pointColor: "rgba(220,220,220,1)",
                        pointStrokeColor: "#fff",
                        pointHighlightFill: "#fff",
                        pointHighlightStroke: "rgba(220,220,220,1)",
                        data: [rand100Factor(), rand100Factor(), rand100Factor()]
                    },
                    {
                        label: "Example dataset",
                        fillColor: "rgba(223, 61, 130,0.5)",
                        strokeColor: "rgba(223, 61, 130,0.7)",
                        pointColor: "rgba(223, 61, 130,1)",
                        pointStrokeColor: "#fff",
                        pointHighlightFill: "#fff",
                        pointHighlightStroke: "rgba(223, 61, 130,1)",
                        data: [7555, 7555, 7555]
                    },
                    {
                        label: "Example dataset",
                        fillColor: "rgba(45, 134, 251, 0.5)",
                        strokeColor: "rgba(45, 134, 251, 0.7)",
                        pointColor: "rgba(45, 134, 251, 1)",
                        pointStrokeColor: "#fff",
                        pointHighlightFill: "#fff",
                        pointHighlightStroke: "rgba(45, 134, 251, 1)",
                        data: [rand100Factor1(), rand100Factor1(), rand100Factor1()]
                    }
                ]
            };

            var lineOptions = {
                scaleShowGridLines: true,
                scaleGridLineColor: "rgba(0,0,0,.05)",
                scaleGridLineWidth: 1,
                bezierCurve: true,
                bezierCurveTension: 0.4,
                pointDot: true,
                pointDotRadius: 4,
                pointDotStrokeWidth: 1,
                pointHitDetectionRadius: 20,
                datasetStroke: true,
                datasetStrokeWidth: 2,
                datasetFill: true,
                responsive: true
            };
            var ctx = document.getElementById("lineChart1").getContext("2d");
            var myNewChart = new Chart(ctx).Line(lineData, lineOptions);
        });
       </script>

</asp:Content>