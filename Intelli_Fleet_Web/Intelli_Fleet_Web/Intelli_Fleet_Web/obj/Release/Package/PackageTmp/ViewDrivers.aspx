<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ViewDrivers.aspx.vb" Inherits="Intelli_Fleet_Web.ViewDrivers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
         <section class="page">           
            <div id="wrapper">
                <div class="content-wrapper container">
					<div class="row">
						<div class="col-sm-12">
							<div class="page-title">
								<h1>View Drivers<small></small></h1>
						        
							</div>
						</div>
					</div>
                    					
                     <asp:GridView ID="GridView1" class="table table-striped" runat="server" HorizontalAlign="Center">
                        <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <SortedDescendingCellStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:GridView>

                 </div>
             </div>
     </section>
</asp:Content>
