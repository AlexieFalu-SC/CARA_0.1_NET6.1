<%@ Page Title="Confirme su Cuenta CARA" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="Confirm.aspx.cs" Inherits="CARA_Draftv0._1.Account.Confirm" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1">
    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-md-4">

    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successPanel" ViewStateMode="Disabled" Visible="true">
            <p>
                Gracias por confirmar su cuenta. Presione <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login">aqui</asp:HyperLink>  para acceder al Sistema CARA            
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="errorPanel" ViewStateMode="Disabled" Visible="false">
            <p class="text-danger">
                Ocurrio un error.
            </p>
        </asp:PlaceHolder>
    </div>

    </main>
</asp:Content>
