<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CARA_Draftv0._1.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>
<asp:Content runat="server" ID="HeadContent" ContentPlaceHolderID="head">
    <style>
      .bd-placeholder-img {
        font-size: 1.125rem;
        text-anchor: middle;
        -webkit-user-select: none;
        -moz-user-select: none;
        -ms-user-select: none;
        user-select: none;
      }

      @media (min-width: 768px) {
        .bd-placeholder-img-lg {
          font-size: 3.5rem;
        }
      }
    </style>
    <link href="<%=ResolveClientUrl("~/Content/account/login.css")%>" type="text/css" rel="stylesheet" />
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1">
    <%--<h2><%: Title %>.</h2>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4>Use a local account to log in.</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="The email field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <div class="checkbox">
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="LogIn" Text="Log in" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
                <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register as a new user</asp:HyperLink>
                </p>
                <p>
                    <%-- Enable this once you have account confirmation enabled for password reset functionality
                    <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled">Forgot your password?</asp:HyperLink>
                    --%>
             <%--   </p>
            </section>
        </div>

        <div class="col-md-4">
            <section id="socialLoginForm">
                <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
            </section>
        </div>
    </div>--%>
    
   <img class="mb-4" src="<%=ResolveClientUrl("~/Content/images/ASSMCA_LOGO.png")%>" alt="" width="145" height="90">
  <h1 class="h3 mb-3 font-weight-normal">Acceda a su cuenta</h1>
    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
  <asp:Label runat="server" AssociatedControlID="Email" CssClass="sr-only">Email</asp:Label>

    <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" Placeholder="Correo Electrónico" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="The email field is required." />

    <asp:Label runat="server" AssociatedControlID="Password" CssClass="sr-only">Password</asp:Label>

    <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" Placeholder="Contraseña"/>
    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
      <div class="checkbox mb-3">
     <%--   <label>
          <input type="checkbox" value="remember-me"> Remember me
        </label>--%>
          <asp:CheckBox runat="server" ID="RememberMe" />
          <asp:Label runat="server" AssociatedControlID="RememberMe">Recordarme</asp:Label>
      </div>
    <asp:Button runat="server" OnClick="LogIn" Text="Acceder" CssClass="btn btn-lg btn-primary btn-block" />
    &nbsp;&nbsp;
                      <asp:Button runat="server" ID="ResendConfirm"  OnClick="SendEmailConfirmationToken" Text="Reenviar Confirmación" Visible="false" CssClass="btn btn-default"/>  

    <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled" class="btn btn-link">OLVIDÉ MI CONTRASEÑA</asp:HyperLink>

  <p class="mt-5 mb-3 text-muted">&copy; ASSMCA</p>
</asp:Content>
