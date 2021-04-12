<%@ Page Title="Actualizar Contraseña" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="CARA_Draftv0._1.Account.ResetPassword" Async="true" %>

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

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1">
    
   <img class="mb-4" src="<%=ResolveClientUrl("~/Content/images/ASSMCA_LOGO.png")%>" alt="" width="145" height="90">
     <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Ingrese su nueva contraseña</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="sr-only">Email</asp:Label>
           
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" Placeholder="Correo Electrónico"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="El email es requerido." />
           
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="sr-only">Contraseña</asp:Label>
          
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" Placeholder="Nueva Contraseña"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="La contraseña es requerida." />
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="sr-only">Confirme contraseña</asp:Label>
    
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" Placeholder="Confirme contraseña"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="La confirmación de contraseña es requerida." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Las contraseñas no son iguales." />
           
        </div>
        <div class="form-group">
          
                <asp:Button runat="server" OnClick="Reset_Click" Text="Actualizar" CssClass="btn btn-outline-secondary" />
          
        </div>
    </div>

  <p class="mt-5 mb-3 text-muted">&copy; ASSMCA</p>
</asp:Content>
