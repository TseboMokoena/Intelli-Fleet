<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FinancialStatements.aspx.vb" Inherits="Intelli_Fleet_Web.FinancialStatements" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <header>
           <meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />
        
	</header>


    <section class ="page ">
        <div id="wrapper">
                <div class="content-wrapper container">
                      <div id="page-wrap">

	                     <div class="container">
    <div class="row">
        <div class="col-xs-12">
    		<div class="invoice-title" style="width:750px">
    			<h1 style="color: #317bba">Invoice Statement</h1><h3 class="pull-right">Invoice No. <asp:Label ID="InvoiceNo" runat="server" Text="Label"></asp:Label> </h3>
    		</div>
    		<hr style ="width:800px">
    		<div class="row" style ="width:800px">
    			<div class="col-xs-6">
    				<address>
    				<strong>Client Name:</strong><br>
    					<asp:Label ID="Name" runat="server" Text="Label"></asp:Label><br>
    				
    				</address>
    			</div>
                </div>
            <div class="row" style ="width:800px">
                <div class="col-xs-6">
    				<address>
    				<strong>Collected From :</strong><br>
    				<asp:Label ID="CollectionAddress" runat="server" Text="Label"></asp:Label>
    				</address>
    			</div>
    			<div class="col-xs-6 text-right">
    				<address>
        			<strong>delivered To:</strong><br>
    					<asp:Label ID="distinationAddress" runat="server" Text="Label"></asp:Label>
    				</address>
    			</div>
    		</div>
    		<div class="row">
    			<div class="col-xs-6">
    				<address>
    					<strong>Payment Method:</strong><br>
    					Visa ending **** 4242<br>
    					<asp:Label ID="Email" runat="server" Text="Label"></asp:Label>
    				</address>
    			</div>
    			<div class="col-xs-2 text-right" >
    				<address>
    					<strong>Booking Due Date:</strong><br>
    				<asp:Label ID="dateDue" runat="server" Text="Label"></asp:Label><br><br>
    				</address>
    			</div>
    		</div>
    	</div>
    </div>
    
    <div class="row">
    	<div class="col-md-12">
    		<div class="panel panel-default">
    			<div class="panel-heading" style ="width:800px">
    				<h3 class="panel-title"><strong>Order summary</strong></h3>
    			</div>
    			<div class="panel-body">
    				<div class="table-responsive">
    					<table class="table table-condensed" style="width:800px">
    						<thead>
                                <tr>
        							<td><strong>Booking number </strong></td>
                                    	<td class="text-center"><strong>Distance in km</strong></td>
        							<td class="text-center"><strong>Requirement</strong></td>
                                 <%--   <td class="text-center"><strong>Price</strong></td>--%>
        						<%--	<td class="text-right"><strong>Vehicle Type</strong></td>--%>
                                </tr>
    						</thead>
    						<tbody>
    							<tr>
    								<td><asp:Label ID="bookingNum" runat="server" Text=""></asp:Label></td>
                                    <td class="text-center"><asp:Label ID="distance" runat="server" Text=""></asp:Label></td>
                                    <td class="text-center"><asp:Label ID="req" runat="server" Text=""></asp:Label></td>
    								<%--<td class="text-center"><asp:Label ID="price" runat="server" Text=""></asp:Label></td>--%>
    								
    							<%--	<td class="text-right"><asp:Label ID="VehicleType" runat="server" Text=""></asp:Label></td>--%>
    							</tr>
                                <tr>
        						
    							</tr>
                                <tr>
        						
    							</tr>
                                <tr>
            					  
    							</tr>
                              
                                <tr>
                                     <td></td>
    								<td ></td>
    								<td ></td>
    								<td ></td>
    								<td ></td>
                                </tr>
    							<tr>
                                      <td></td>
    								<td class="thick-line"></td>
    								<td class="thick-line"></td>
    								<td class="thick-line text-center"><strong>Subtotal R:</strong></td>
    								<td class="thick-line text-right"><asp:Label ID="subtotal" runat="server" Text=""></asp:Label></td>
    							</tr>
    							<tr>
                                      <td></td>
    								<td class="no-line"></td>
    								<td class="no-line"></td>
    								<td class="no-line text-center"><strong>VAT (Tax)</strong></td>
    								<td class="no-line text-right">14%</td>
    							</tr>
    							<tr>
                                      <td></td>
    								<td class="no-line"></td>
    								<td class="no-line"></td>
    								<td class="no-line text-center"><strong>Total R:</strong></td>
    								<td class="no-line text-right"><asp:Label ID="total" runat="server" Text=""></asp:Label></td>
    							</tr>
    						</tbody>
    					</table>
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
