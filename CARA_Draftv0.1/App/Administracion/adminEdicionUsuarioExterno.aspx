﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="adminEdicionUsuarioExterno.aspx.cs" Inherits="CARA_Draftv0._1.App.Administracion.adminEdicionUsuarioExterno" %>
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
                                <i class="fas fa-fw fa-user-edit"></i><span> Edición de Usuario Externo (REGISTRADOS)</span>
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

    <div class="container-xl px-4 mt-4">
            <div class=" row">
                <ul class="nav nav-tabs col-xl-12 mb-4" id="myTab" role="tablist">
                    <li class="nav-item" role="presentation">
                        <a class="nav-link active" id="profile-tab" data-toggle="tab" href="#profile" role="tab" aria-controls="profile" aria-selected="true">Información de Usuario Externo</a>
                    </li>
                    <li class="nav-item" role="presentation">
                        <a class="nav-link" id="seguridad-tab" data-toggle="tab" href="#seguridad" role="tab" aria-controls="seguridad" aria-selected="false">Seguridad</a>
                    </li>
                </ul>
            </div>
            <div class="tab-content" id="myTabContent">
                <div class="tab-pane fade show active" id="profile" role="tabpanel" aria-labelledby="profile-tab">
                    <div class="row">
                        <div class="col-xl-4">
                            <div class="card mb-4 mb-xl-0">
                                <div class="card-header">Foto de Perfil</div>
                                <div class="card-body text-center">
                                    <asp:Image ID="profileImg" ImageUrl="~/Content/images/Avatar.png" runat="server" CssClass="img-account-profile rounded-circle mb-2" />
                                    <div class="small font-italic text-muted mb-4"><span><asp:Label ID="lblNombre" Text="" runat="server" /></span></div>
                                    
                                </div>
                            </div>
                        </div>
                        <div class="col-xl-8">
                            <div class="card mb-4">
                                <div class="card-header">Detalles del Perfil</div>
                                <div class="card-body">
                                    <div class="row">
                                        <div class="form-group col-6">
                                            <label class="control-label">Correo Electrónico</label>
                                            <asp:Label ID="lblEmail" CssClass="form-control form-control-user" Text="" runat="server" />
                                        </div>
                                        <div class="form-group col-6">
                                            <label class="control-label">Teléfono</label>
                                            <asp:TextBox runat="server" ID="Telefono" CssClass="form-control form-control-user" />
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Telefono" CssClass="text-danger" ErrorMessage="Su telefono es requerido" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group col-6">
                                            <label class="control-label">Primer Nombre</label>
                                            <asp:TextBox runat="server" ID="NB_Primero" CssClass="form-control form-control-user" />
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="NB_Primero" CssClass="text-danger" ErrorMessage="Su primer nombre es requerido" />
                                        </div>
                                        <div class="form-group col-6">
                                            <label class="control-label">Segundo Nombre</label>
                                            <asp:TextBox runat="server" ID="NB_Segundo" CssClass="form-control form-control-user" />
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="NB_Segundo" CssClass="text-danger" ErrorMessage="Su segundo nombre es requerido" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group col-6">
                                            <label class="control-label">Primer Apellido</label>
                                            <asp:TextBox runat="server" ID="AP_Primero" CssClass="form-control form-control-user" />
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="AP_Primero" CssClass="text-danger" ErrorMessage="Su primer apellido es requerido" />
                                        </div>
                                        <div class="form-group col-6">
                                            <label class="control-label">Segundo Apellido</label>
                                            <asp:TextBox runat="server" ID="AP_Segundo" CssClass="form-control form-control-user" />
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="AP_Segundo" CssClass="text-danger" ErrorMessage="Su segundo nombre es requerido" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group col-6">
                                            <label class="control-label">Rol de Usuario</label>
                                            <asp:Label ID="lblRol" CssClass="form-control form-control-user" Text="" runat="server" />
                                        </div>
                                        <div class="form-group col-6" runat="server" id="divChkModulos" visible="false">
                                            <label class="control-label">Modulos Accesbiles</label>
                                            <asp:CheckBoxList ID="chkModulos" runat="server" >
                                                <asp:ListItem Value="RegistroPerfiles" Text="Registrar Perfiles" />
                                                <asp:ListItem Value="AccesoExpedientes" Text="Ver Expedientes y Perfiles" />
                                                <asp:ListItem Value="AccesoTableros" Text="Ver Tableros Analiticos" />
                                            </asp:CheckBoxList>
                                        </div>
                                    </div>

                                    <asp:Button runat="server" Text="Actualizar Usuario" OnClick="ProfileUpdate_Click" CssClass="btn btn-primary" />

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xl-4">
                            <div class="card mb-4">
                                <div class="card-header">Facilidades</div>
                                <div class="card-body">
                                    <div class="table-responsive">
                                        <asp:GridView runat="server" ID="gvCentrosList" CssClass="table table-bordered usuariosExternosListTable" Width="100%" AutoGenerateColumns="false" DataKeyNames="PK_Centro">
                                            <Columns>
                                                <asp:BoundField DataField="NB_Centro" HeaderText="Centro" HeaderStyle-HorizontalAlign="Center">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </asp:BoundField>
                                                <asp:TemplateField HeaderText="Estatus">
                                                    <ItemTemplate>
                                                        <div class="row">&nbsp <%# Eval("CentroEstatus") %></div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                            
                                            </Columns>
                                            <EmptyDataTemplate>
                                                No existen facilidades atadas a este usuario
                                            </EmptyDataTemplate>
                                            <%--<i class='fas fa-fw fa-trash-alt'></i>--%>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-xl-8" runat="server" id="divPrincipal" visible="false">
                                <div class="card mb-4">
                                    <div class="card-header">Facilidades</div>
                                    <div class="card-body">
                                        <div class="table-responsive">
                                            <asp:GridView runat="server" ID="gvSubCuentasList" CssClass="table table-bordered usuariosASSMCAListTable" Width="100%" AutoGenerateColumns="false" DataKeyNames="PK_Usuario">
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
                                                            <a href='<%=ResolveClientUrl("~/App/Administracion/adminEdicionUsuarioExterno.aspx?pk_usuario=")%><%#Eval("PK_Usuario")%>' ><i class='fas fa-fw fa-edit'></i></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    No existen usuarios bajo esta cuenta principal de registrado
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                        </div>
                    </div>
                </div>
                <div class="tab-pane fade" id="seguridad" role="tabpanel" aria-labelledby="seguridad-tab">
                    <div class="row">
                        <div class="col-xl-6">
                            <div class="card mb-4">
                                <div class="card-header">Actualizar Contraseña</div>
                                <div class="card-body">
                                    <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
                                    <%--<div class="row">
                                        <div class="form-group col-12">
                                            <asp:Label runat="server" ID="CurrentPasswordLabel" AssociatedControlID="CurrentPassword" CssClass="control-label">Contraseña Actual</asp:Label>
                                            <asp:TextBox runat="server" ID="CurrentPassword" TextMode="Password" CssClass="form-control form-control-user" />
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentPassword"
                                                CssClass="text-danger" ErrorMessage="La contraseña actual es requerida"
                                                ValidationGroup="ChangePassword" />
                                        </div>
                                    </div>--%>

                                    <div class="row">
                                        <div class="form-group col-12">
                                            <asp:Label runat="server" ID="NewPasswordLabel" AssociatedControlID="NewPassword" CssClass="control-label">Nueva Contraseña</asp:Label>
                                            <asp:TextBox runat="server" ID="NewPassword" TextMode="Password" CssClass="form-control form-control-user" />
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="NewPassword"
                                                CssClass="text-danger" ErrorMessage="La nueva contraseña es requerida"
                                                ValidationGroup="ChangePassword" />
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="form-group col-12">
                                            <asp:Label runat="server" ID="ConfirmNewPasswordLabel" AssociatedControlID="ConfirmNewPassword" CssClass="control-label">Confirme Nueva Contraseña</asp:Label>
                                            <asp:TextBox runat="server" ID="ConfirmNewPassword" TextMode="Password" CssClass="form-control" />
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmNewPassword"
                                                CssClass="text-danger" Display="Dynamic" ErrorMessage="La confirmación de su nueva contraseña es requerida"
                                                ValidationGroup="ChangePassword" />
                                            <asp:CompareValidator runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                                                CssClass="text-danger" Display="Dynamic" ErrorMessage="La nueva contraseña y la confirmación de contraseña"
                                                ValidationGroup="ChangePassword" />
                                        </div>
                                    </div>
                                    <a class="btn btn-primary btn-user btn-block" href="#" data-toggle="modal" data-target="#newPasswordModal">Actualizar Contraseña
                                    </a>

                                </div>
                            </div>
                        </div>
                        <div class="col-xl-6">
                            <div class="card mb-4 mb-xl-0">
                                <div class="card-header">Two-Factor Authentication</div>
                                <div class="card-body text-center">
                                </div>
                            </div>
                        </div>


                    </div>
                </div>
            </div>



        </div>




       

     <!-- Actualizar Contraseña Modal-->
            <div class="modal fade" id="newPasswordModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">¿Realmente desea actualizar su contraseña?</h5>
                            <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">×</span>
                            </button>
                        </div>
                        <div class="modal-body">Seleccione "Guardar" en la parte de abajo para actualizar su contraseña no son las mismas.</div>
                        <div class="modal-footer">
                            <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancelar</button>
                            <asp:Button runat="server" Text="Guardar" ValidationGroup="ChangePassword" OnClick="ChangePassword_Click" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </div>


    <div id="coverScreen"  class="LockOn">
                        </div>
</main>

<script type="text/javascript">
    if (window.history.replaceState) {
        window.history.replaceState(null, null, window.location.href);
    }

    $(window).on('load', function () {
        $("#coverScreen").hide();
    });

    function divShow() {
        $("#coverScreen").show();
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