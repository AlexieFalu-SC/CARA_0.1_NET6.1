<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="frmcentro.aspx.cs" Inherits="CARA_Draftv0._1.App.Perfiles.frmCentro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-md-4">
    <div id="CentroBox" runat="server">
        
        <div id="divCentro" runat="server" style="padding-top: 5px;">
        <div class="card">
            <div class="card-header">
                <h3 class="card-title">Selección de Centro</h3>
            </div>
            <div class="card-body">
                <span class="SEPSLabel">Centro:</span>
                <div class="expandibleDiv">
                    <asp:DropDownList runat="server" ID="ddlCentro" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                </div>
                <div id="divBotones" style="padding-top: 10px;">
                    <asp:Button ID="btnAutenticarPrograma" runat="server" CssClass="btn btn-outline-secondary" Text="Seleccionar" OnClick="btnAutenticarPrograma_Click" />
                </div>
            </div>
        </div>
    </div>

    </div>

    
    
    </main>


</asp:Content>
