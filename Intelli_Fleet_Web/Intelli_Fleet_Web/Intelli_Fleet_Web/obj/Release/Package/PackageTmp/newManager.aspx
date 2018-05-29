<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="newManager.aspx.vb" Inherits="Intelli_Fleet_Web.newManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

         <section class="page">           
            <div id="wrapper">
                <div class="content-wrapper container">
					<div class="row">
						<div class="col-sm-12">
							<div class="page-title">
								<h1>Sign Up new Manager<small></small></h1>
						
							</div>
						</div>
					</div>
					
			                      <div class="form-group">
                            <asp:TextBox ID="txtUName" placeholder="Name" CssClass="form-control" runat="server" CausesValidation="true" AutoCompleteType="FirstName" required=""></asp:TextBox>
                        </div>
                    <div class="form-group">
                            <asp:TextBox ID="txtUSurname" placeholder="Surname" CssClass="form-control" runat="server" CausesValidation="true" AutoCompleteType="LastName" required=""></asp:TextBox>
                        </div>
                        <div class="form-group">
                        <asp:TextBox ID="txtUUsername" CssClass="form-control" placeholder="Username" runat="server" CausesValidation="true" AutoCompleteType="FirstName" required=""></asp:TextBox>
                         </div>
                            <div class="form-group">
                             <asp:TextBox ID="txtUEmail" placeholder="Email Address" CssClass="form-control" runat="server" CausesValidation="true"  AutoCompleteType="Email" required=""></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox  TextMode="Password" ID ="txtUPassword" placeholder="Password" CssClass="form-control" runat="server" CausesValidation="true" required=""></asp:TextBox>
                        </div>  
                        <div class="form-group">
                            <asp:TextBox   TextMode="Password" ID="txtUConfirm" placeholder="Confirm Password" CssClass="form-control" runat="server" CausesValidation="true" required=""></asp:TextBox>
                        </div>
                        <asp:Button ID="btnSubmit" Text="Submit" CssClass="btn btn-primary btn-block" runat="server"/>
                       
                <p>Intelli-Fleet &copy; 2016</p>
					
					
                 </div>
             </div>
     </section>







</asp:Content>
