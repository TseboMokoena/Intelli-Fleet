<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AssignOrder.aspx.vb" Inherits="Intelli_Fleet_Web.AssignOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <section class="page">           
            <div id="wrapper">
                <div class="content-wrapper container">
					<div class="row">
						<div class="col-sm-12">
							<div class="page-title">
								<h1>Assign task to drivers<small></small></h1>
						        
							</div>
						</div>
					</div>
                    					
                     <asp:GridView ID="ViewOrder" class="table table-striped" runat="server" HorizontalAlign="Center" Width="730px">
                        <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <SortedDescendingCellStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:GridView>
                    <br />
                     <asp:GridView ID="ViewDriver" class="table table-striped" runat="server" HorizontalAlign="Center" Width="730px">
                        <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <SortedDescendingCellStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:GridView>
                    <br />
                   &nbsp;&nbsp;
                     <asp:Button ID="btnAssign" Text="Assign to driver" CssClass="btn btn-primary btn-block" runat="server" Width="594px"/>
                    <table style="width:75%;height:60% ;color:black;background-color:transparent;border:thin;margin:auto">

                         <tr style="color:black;resize:vertical;border:solid">
                              <td>
                             <p>Driver Name:</p>
                             </td>
                              <asp:Label ID="DriverName" runat="server" ></asp:Label>
                         </tr>
                         <tr style="color:black;resize:vertical;border:solid">
                              <td>
                             <p> Assigned to book Number :</p>
                             </td>
                              <asp:Label ID="BookNumber" runat="server" ></asp:Label>
                         </tr>
                         <tr style="color:black;resize:vertical;border:solid">
                              <td>
                             <p>Client's name Order :</p>
                             </td>
                              <asp:Label ID="ClientName" runat="server" ></asp:Label>
                         </tr>
                         
                        </table>
                   
                 </div>
             </div>
     </section>


</asp:Content>
