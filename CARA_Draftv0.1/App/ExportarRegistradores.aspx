<%@ Page Title=" | Exportar Mis Perfiles" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="ExportarRegistradores.aspx.cs" Inherits="CARA_Draftv0._1.App.ExportarRegistradores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <main>

    <header class="page-header page-header-compact page-header-light border-bottom bg-white mb-4">
        <div class="container-fluid px-4">
            <div class="page-header-content">
                <div class="row align-items-center justify-content-between pt-3">
                    <div class="col-auto mb-3">
                        <h3 class="page-header-title">
                            <div class="page-header-icon">
                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-user">
                                    <path d="M20 21v-2a4 4 0 0 0-4-4H8a4 4 0 0 0-4 4v2"></path><circle cx="12" cy="7" r="4"></circle></svg>
                                Mis Perfiles
                            </div>

                        </h3>
                    </div>
                </div>
            </div>
        </div>
    </header>

    <div class="container-fluid px-4">
        <div class="card">
            <div class="card-header" style="text-align:right">
                <div class="btn-group" role="group" aria-label="Basic outlined example" >
                    <asp:Button runat="server" Text="EXCEL" OnClick="ExportToExcel" CssClass="btn btn-outline-secondary" />
                    <asp:Button runat="server" Text="CSV" OnClick="ExportToExcel" CssClass="btn btn-outline-secondary" />
                    <asp:Button runat="server" Text="PDF" OnClick="ExportToExcel" CssClass="btn btn-outline-secondary" />
                 </div>
             </div>
            <div class="card-body">
                <div class="table-responsive">

                    <asp:GridView runat="server" ID="gvPerfilesList" CssClass="table table-bordered perfilesListTable" Width="100%" AutoGenerateColumns="false" DataKeyNames="PK_Perfil">
                        <Columns>
                            <asp:BoundField DataField="PK_Perfil" HeaderText="ID Perfil" />
                            <asp:BoundField DataField="Centro" HeaderText="Nombre de Centro" />
                           <%-- <asp:TemplateField HeaderText="Fecha Admisión">
                                <ItemTemplate>
                                    <div class="row">&nbsp <%# Eval("Fecha Admisión") %></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ID Paciente">
                                <ItemTemplate>
                                    <div class="row">&nbsp <%# Eval("ID Paciente") %></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tipo Admisión">
                                <ItemTemplate>
                                    <div class="row">&nbsp <%# Eval("Tipo Admisión") %></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Dias en Espera">
                                <ItemTemplate>
                                    <div class="row">&nbsp <%# Eval("Dias en Espera") %></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Arrestos 30 Dias">
                                <ItemTemplate>
                                    <div class="row">&nbsp <%# Eval("Arrestos 30 Dias") %></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fuente Referido">
                                <ItemTemplate>
                                    <div class="row">&nbsp <%# Eval("Fuente Referido") %></div>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                        <EmptyDataTemplate>
                            No existen usuarios adicionales al de usted
                        </EmptyDataTemplate>
                        <%--<i class='fas fa-fw fa-trash-alt'></i>--%>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>



</main>



</asp:Content>
