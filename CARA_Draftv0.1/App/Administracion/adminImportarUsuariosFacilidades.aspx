<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="adminImportarUsuariosFacilidades.aspx.cs" Inherits="CARA_Draftv0._1.App.Administracion.adminImportarUsuariosFacilidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<main>
    <header class="page-header page-header-compact page-header-light border-bottom mb-4">
        <div class="container-fluid px-4">
            <div class="page-header-content">
                <div class="row align-items-center justify-content-between pt-3">
                    <div class="col-auto mb-3">
                        <h3 class="page-header-title">
                            <div class="page-header-icon">
                                <i class="fas fa-fw fa-user-edit"></i><span> Importar Cuentas Principales y Facilidades (REGISTRADOS)</span>
                            </div>
                        </h3>
                    </div>
                    <div class="col-auto">
                        <div class="btn-group mr-2">
                            <asp:Button runat="server" Text="PDF" OnClientClick="PrintDiv()" CssClass="btn btn-sm btn-outline-secondary" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </header>

    <div class="container-fluid px-4">
        <div class="row">
            
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button Text="Upload" OnClick="btnImportar" runat="server" />

        </div>
        <div class="row">

        </div>
    </div>
</main>
</asp:Content>
