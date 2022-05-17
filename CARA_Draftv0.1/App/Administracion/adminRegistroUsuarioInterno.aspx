﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="adminRegistroUsuarioInterno.aspx.cs" Inherits="CARA_Draftv0._1.App.Administracion.adminRegistroUsuarioInterno" %>
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
                                    <i class="fas fa-fw fa-user-plus"></i><span> Agregar Nuevo Usuario Interno (ASSMCA)</span>
                                </div>
                            </h3>
                        </div>
                        <div class="col-auto">
                            <div class="btn-group mr-2">
                                <a class="btn btn-sm btn-light text-primary" href="<%=ResolveClientUrl("~/App/Administracion/registradoListaUsuarios")%>">
                    <i class="fas fa-fw fa-user-plus"></i>Volver a lista de Usuarios
                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </header>

    <div class="row justify-content-lg-center">
        <!-- Basic Card Example -->
        <div class="col-xl-6 col-lg-5">
            <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Detalles de mi Perfil</h6>
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="form-group col-6">
                        <label class="control-label">Correo Electrónico</label>
                        <asp:TextBox runat="server" ID="Email" CssClass="form-control form-control-user" TextMode="Email" Placeholder="Ej. admin@assmca.pr.gov" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="text-danger" ErrorMessage="El correo electrónico es requerido" />
                    </div>
                    <div class="form-group col-6">
                        <label class="control-label">Teléfono</label>
                        <asp:TextBox runat="server" ID="Telefono" CssClass="form-control form-control-user" Placeholder="Ej. 7875555555"/>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Telefono" CssClass="text-danger" ErrorMessage="Su telefono es requerido" />
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-6">
                        <label class="control-label">Primer Nombre</label>
                        <asp:TextBox runat="server" ID="NB_Primero" CssClass="form-control form-control-user" Placeholder="Ej. Joe"/>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="NB_Primero" CssClass="text-danger" ErrorMessage="Su primer nombre es requerido" />
                    </div>
                    <div class="form-group col-6">
                        <label class="control-label">Segundo Nombre</label>
                        <asp:TextBox runat="server" ID="NB_Segundo" CssClass="form-control form-control-user" Placeholder="Ej. Frank"/>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="NB_Segundo" CssClass="text-danger" ErrorMessage="Su segundo nombre es requerido" />
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-6">
                        <label class="control-label">Primer Apellido</label>
                        <asp:TextBox runat="server" ID="AP_Primero" CssClass="form-control form-control-user" Placeholder="Ej. Doe"/>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="AP_Primero" CssClass="text-danger" ErrorMessage="Su primer apellido es requerido" />
                    </div>
                    <div class="form-group col-6">
                        <label class="control-label">Segundo Apellido</label>
                        <asp:TextBox runat="server" ID="AP_Segundo" CssClass="form-control form-control-user" Placeholder="Ej. Perez"/>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="AP_Segundo" CssClass="text-danger" ErrorMessage="Su segundo nombre es requerido" />
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-6">
                        <label class="control-label">Rol</label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlRol"></asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlRol" InitialValue="0"
                            CssClass="text-danger" ToolTip="Seleccione un valor de la lista. Este campo es requerido." ErrorMessage="Rol de Usuario." />
                        
                    </div>
                    <div class="form-group col-6">
                        <label class="control-label">Modulos Accesbiles</label>
                        <asp:CheckBoxList ID="chkModulos" runat="server" CssClass="form-check form-switch">
                            <asp:ListItem Value="RegistroPerfiles" Text="Registrar Perfiles" />
                            <asp:ListItem Value="AccesoExpedientes" Text="Ver Expedientes y Perfiles" />
                            <asp:ListItem Value="AccesoTableros" Text="Ver Tableros Analiticos" />
                        </asp:CheckBoxList>
                    </div>
                </div>

                <asp:Button runat="server" Text="Agregar Usuario" OnClick="BtnRegistrar_Click"  CssClass="btn btn-primary" />

            </div>
            </div>
        </div>
    </div>

</main>

<script type="text/javascript">
    if (window.history.replaceState) {
        window.history.replaceState(null, null, window.location.href);
    }

    function sweetAlertRef(titulo, texto, icono, ref) {
        var baseUrl = "<%=ResolveClientUrl("~/")%>" + ref;

        swal({
            title: titulo,
            text: texto,
            icon: icono
        }).then((value) => { window.location.href = baseUrl; });
    }

    function sweetAlert(titulo, texto, icono) {
        swal({
            title: titulo,
            text: texto,
            icon: icono
        })
    }
</script>
</asp:Content>