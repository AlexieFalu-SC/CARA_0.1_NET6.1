<%@ Page Title="" Language="C#" MasterPageFile="~/NoLogin.Master" AutoEventWireup="true" CodeBehind="OtrosError.aspx.cs" Inherits="CARA_Draftv0._1.App.Errores.OtrosError" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-md-4">

    <h2> Ocurrio un error en el sistema</h2>

    <div>
        <p>
            <asp:Label runat="server" id="lblError"/>             
        </p>
    </div>

    </main>
</asp:Content>
