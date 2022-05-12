<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="registradoListaUsuarios.aspx.cs" Inherits="CARA_Draftv0._1.App.Administracion.registradoListaUsuarios" %>

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
                                <i class="fas fa-fw fa-file-export"></i>
                                Lista de Usuarios
                            </div>

                        </h3>
                    </div>
                </div>
            </div>
        </div>
    </header>

    <div class="container-fluid px-4">
        <div class="card">
            <div class="card-header">
                 <div class="btn-toolbar justify-content-between" role="toolbar">
                    <div>
                        <h4>Sub-Cuentas de Usuarios</h4>
                    </div>
                    <div>
                    <a class="btn btn-sm btn-light text-primary"  runat="server" href="~/App/Administracion/registradoRegistroUsuario">
                        <i class="fas fa-fw fa-file-export"></i>
                        Registrar Nuevo Usuario
                    </a>
                    </div>
                </div>
             </div>
            <div class="card-body">
                <div class="table-responsive">

                    <asp:GridView runat="server" ID="gvUsuariosRegistradosList" CssClass="table table-bordered usuariosRegistradosListTable" Width="100%" AutoGenerateColumns="false" DataKeyNames="Nombre">
                        <Columns>
                           <asp:TemplateField HeaderText="Usuario">
                                <ItemTemplate>
                                    <div class="row d-flex align-items-center">
                                        <div class="avatar me-2">
                                            &nbsp
                                            <asp:Image ID="profileImg" ImageUrl='<%# Eval("Imagen_Perfil") %>' runat="server" CssClass="avatar-img img-fluid" />
                                        </div>
                                         
                                        &nbsp
                                        <%# Eval("Nombre") %></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Email" HeaderText="CorreoElectrónico" />
                            <asp:BoundField DataField="Rol" HeaderText="Rol" />
                            <asp:TemplateField HeaderText="Módulos Accesibles">
                                <ItemTemplate>
                                    <div class="row">&nbsp <%# Eval("Accesos") %></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Confirmado">
                                <ItemTemplate>
                                    <div class="row">&nbsp <%# Eval("Confirmado") %></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Estatus">
                                <ItemTemplate>
                                    <div class="row">&nbsp <%# Eval("Estatus") %></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Acciones"> 
                                <ItemTemplate>
                                    <asp:Label ID="Edit" runat="server" Enabled="true"></asp:Label>
                                    <a href='<%=ResolveClientUrl("~/Account/EditUser.aspx?pk_usuario=")%><%#Eval("PK_Usuario")%>' ><i class='fas fa-fw fa-edit'></i></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            No existen perfiles con los filtros escogidos.
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

</main>
</asp:Content>
