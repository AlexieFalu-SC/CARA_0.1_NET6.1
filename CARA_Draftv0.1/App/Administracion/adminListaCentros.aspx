<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="adminListaCentros.aspx.cs" Inherits="CARA_Draftv0._1.App.Administracion.adminListaCentros" %>
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
                                    <i class="fas fa-fw fa-hospital"></i><span> Lista de Facilidades</span>
                                </div>
                            </h3>
                        </div>
                      <%--  <div class="col-auto">
                            <div class="btn-group mr-2">
                                <a class="btn btn-sm btn-light text-primary" href="<%=ResolveClientUrl("~/App/Administracion/registradoListaUsuarios")%>">
                                    <i class="fas fa-fw fa-user-plus"></i>Volver a lista de Usuarios
                                </a>
                            </div>
                        </div>--%>
                    </div>
                </div>
            </div>
        </header>

        <div class="container-fluid px-4">
            <div class="card">
                    <div class="card-header">
                        <div class="btn-toolbar justify-content-between" role="toolbar">
                            <div>
                                <h4>Facilidades</h4>
                            </div>
                            <div>
                            <a class="btn btn-sm btn-light text-primary"  runat="server" href="~/App/Administracion/adminRegistroFacilidad">
                                <i class="fas fa-fw fa-hospital"></i>
                                Registrar Nueva Facilidad
                            </a>
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">

                            <asp:GridView runat="server" ID="gvCentrosList" CssClass="table table-bordered usuariosASSMCAListTable" Width="100%" AutoGenerateColumns="false" DataKeyNames="PK_Centro">
                                <Columns>
                                    <asp:BoundField DataField="Centro" HeaderText="Centro" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="ID_Proveedor" HeaderText="ID Proveedor" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Registrado" HeaderText="Registrado" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="Email" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                    <asp:TemplateField HeaderText="Estatus">
                                        <ItemTemplate>
                                            <div class="row">&nbsp <%# Eval("Estatus") %></div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Acciones"> 
                                        <ItemTemplate>
                                            <asp:Label ID="Edit" runat="server" Enabled="true"></asp:Label>
                                            <a href='<%=ResolveClientUrl("~/App/Administracion/adminEdicionFacilidad.aspx?pk_centro=")%><%#Eval("PK_Centro")%>' ><i class='fas fa-fw fa-edit'></i></a>
                                            <%--<asp:Label ID="Delete" runat="server" Enabled="true"></asp:Label>
                                            <a class="btn btn-datatable btn-icon btn-transparent-dark me-2"  href='~/Account/DeleteUser.aspx?pk_usuario=<%#Eval("PK_Usuario")%>'><i class='fas fa-fw fa-trash-alt'></i></a>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                            
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
