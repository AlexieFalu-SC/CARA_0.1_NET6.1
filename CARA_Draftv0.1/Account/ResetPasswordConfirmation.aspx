<%@ Page Title="Contraseña Actualizada" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="ResetPasswordConfirmation.aspx.cs" Inherits="CARA_Draftv0._1.Account.ResetPasswordConfirmation" Async="true" %>

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
   <img class="mb-4" src="<%=ResolveClientUrl("~/Content/images/ASSMCA_LOGO.png")%>" alt="" width="145" height="90">
    
    <h2><%: Title %>.</h2>
    <div>
        <p>Su contraseña ha sido actualizada. Presione <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login">aqui</asp:HyperLink> para entrar a su cuenta </p>
    </div>

    
</asp:Content>
