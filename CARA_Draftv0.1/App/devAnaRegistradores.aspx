<%@ Page Title=" | Tablero Gráfico" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="devAnaRegistradores.aspx.cs" Inherits="CARA_Draftv0._1.App.devAnaRegistradores" %>

<%@ Register Src="~/App/Administracion/wucListaUsuariosExternos.ascx" TagPrefix="uc1" TagName="wucListaUsuariosExternos" %>




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
                                Lista de Usuarios</div>
                        </h3>
                    </div>
                    <div class="col-auto">
                        <ul class="nav nav-tabs" id="myTab" role="tablist">
                            <li class="nav-item" role="presentation">
                            <a class="nav-link active" id="usuarios-assmca-tab" data-toggle="tab" href="#usuarios-assmca" role="tab" aria-controls="ssrs" aria-selected="false">USUARIOS DE ASSMCA</a>
                            </li>
                            <li class="nav-item" role="presentation">
                            <a class="nav-link" id="usuarios-externos-tab" data-toggle="tab" href="#usuarios-externos" role="tab" aria-controls="ssrs-plan" aria-selected="false">USUARIOS EXTERNOS</a>
                            </li>
                        </ul>
                    </div>
                   <%-- <div class="col-12 col-xl-auto mb-3">
                        <a class="btn btn-sm btn-light text-primary"  runat="server" href="~/Account/Register">
                            <i class="fas fa-fw fa-file-export"></i>
                            Registrar Nuevo Usuario
                        </a>
                    </div>--%>
                </div>
            </div>
        </div>
    </header>

    <div class="container-fluid px-4">

        <div class="tab-content" id="myTabContent">
            <div class="tab-pane fade show active" id="usuarios-assmca" role="tabpanel" aria-labelledby="plan-tab">

                <div class="card">
                    <div class="card-header">
                        <div class="btn-toolbar justify-content-between" role="toolbar">
                            <div>
                                <h4>Usuarios de ASSMCA</h4>
                            </div>
                            <div>
                            <a class="btn btn-sm btn-light text-primary"  runat="server" href="~/Account/Register">
                                <i class="fas fa-fw fa-file-export"></i>
                                Registrar Usuario de ASSMCA
                            </a>
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">

                            <asp:GridView runat="server" ID="gvUsuariosASSMCAList" CssClass="table table-bordered usuariosASSMCAListTable" Width="100%" AutoGenerateColumns="false" DataKeyNames="Nombre">
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
                                    <%--<asp:BoundField DataField="Modulos" HeaderText="Modulos" />--%>
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

            <div class="tab-pane fade" id="usuarios-externos" role="tabpanel" aria-labelledby="plan-tab">
                <uc1:wucListaUsuariosExternos runat="server" id="wucListaUsuariosExternos" />
            </div>

        </div>

    </div>


</main>

</asp:Content>
