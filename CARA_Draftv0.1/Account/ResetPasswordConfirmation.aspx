<%@ Page Title="Contraseña Actualizada" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="ResetPasswordConfirmation.aspx.cs" Inherits="CARA_Draftv0._1.Account.ResetPasswordConfirmation" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1">
    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-md-4">
    
    <h2><%: Title %>.</h2>
    <div>
        <p>Su contraseña ha sido actualizada. Presione <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login">aqui</asp:HyperLink> para entrar a su cuenta </p>
    </div>

    </main>
</asp:Content>
