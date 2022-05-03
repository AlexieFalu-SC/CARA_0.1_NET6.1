<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CARA_Draftv0._1.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1">
 

    <div class="container">

    <!-- Outer Row -->
    <div class="row justify-content-center">

      <div class="col-xl-10 col-lg-12 col-md-9">

        <div class="card o-hidden border-0 shadow-lg my-5">
          <div class="card-body p-0">
            <!-- Nested Row within Card Body -->
            <div class="row">
              <div class="col-lg-6 d-none d-lg-block bg-login-image"></div>
              <div class="col-lg-6">
                <div class="p-5">
                  <div class="text-center">
                    <h1 class="h4 text-gray-900 mb-4">SEATSS</h1>
                        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                            <p class="text-danger">
                                <asp:Literal runat="server" ID="FailureText" />
                            </p>
                        </asp:PlaceHolder>
                  </div>
                  <div class="user">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="control-label">Correo Electrónico</asp:Label>
                        
                        <asp:TextBox runat="server" ID="Email" CssClass="form-control form-control-user" TextMode="Email" Placeholder="Ingrese su correo electrónico" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="text-danger" ErrorMessage="Su correo electrónico es requerido" />
                        
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="control-label">Contraseña</asp:Label>
                       
                        <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control form-control-user" Placeholder="Ingrese su contraseña" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="Su contraseña es rerquerida" />
                        
                    </div>
                    <div class="form-group">
                      <div class="custom-control custom-checkbox small">
                          <asp:CheckBox runat="server" CssClass="custom-control-input" ID="RememberMe" />
                          <asp:Label runat="server" CssClass="custom-control-label" AssociatedControlID="RememberMe">Recordarme</asp:Label>
                      </div>
                    </div>
                    <asp:Button runat="server" OnClick="LogIn" Text="Acceder" CssClass="btn btn-primary btn-user btn-block" />
                    <asp:Button runat="server" ID="ResendConfirm"  OnClick="SendEmailConfirmationToken" Text="Reenviar Confirmación" Visible="false" CssClass="btn btn-primary btn-user btn-block"/>
                  </div>
                  <hr>
                  <div class="text-center">
                    <a class="small" href="<%=ResolveClientUrl("~/Account/Forgot")%>">Olvidé mi contraseña</a>
                  </div>
                  <div class="text-center">
                    
                    <%--<asp:HyperLink runat="server" class="small" ID="RegisterHyperLink" ViewStateMode="Disabled">Register as a new user</asp:HyperLink>--%>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>

      </div>

    </div>

  </div>

</asp:Content>
