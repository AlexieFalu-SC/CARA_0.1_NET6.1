﻿<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="CARA_Draftv0._1.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

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
                                    Mi Perfil
                                </div>

                            </h3>
                        </div>
                    </div>
                </div>
            </div>
        </header>

        <div class="container-xl px-4 mt-4">
            <div class=" row">
                <ul class="nav nav-tabs col-xl-12 mb-4" id="myTab" role="tablist">
                    <li class="nav-item" role="presentation">
                        <a class="nav-link active" id="profile-tab" data-toggle="tab" href="#profile" role="tab" aria-controls="profile" aria-selected="true">Mi Cuenta</a>
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
                                    <a class="btn btn-sm btn-light text-primary" href="#" data-toggle="modal" data-target="#exampleModalToggle">
                        <i class="fas fa-fw fa-file-export"></i>
                        Atar Nueva Licencia
                    </a>
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
                                                <asp:ListItem Value="TEDS" Text="TEDS" />
                                                <asp:ListItem Value="MonitoreoSEPS" Text="Monitoreo SEPS" />
                                                <asp:ListItem Value="MantenimientoSEPS" Text="Mantenimiento SEPS" />
                                                <asp:ListItem Value="ReportesInformativos" Text="Reportes Informativos" />
                                            </asp:CheckBoxList>
                                        </div>
                                    </div>

                                    <asp:Button runat="server" Text="Actualizar mi información" OnClick="ProfileUpdate_Click" CssClass="btn btn-primary" />

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
                                    <div class="row">
                                        <div class="form-group col-12">
                                            <asp:Label runat="server" ID="CurrentPasswordLabel" AssociatedControlID="CurrentPassword" CssClass="control-label">Contraseña Actual</asp:Label>
                                            <asp:TextBox runat="server" ID="CurrentPassword" TextMode="Password" CssClass="form-control form-control-user" />
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentPassword"
                                                CssClass="text-danger" ErrorMessage="La contraseña actual es requerida"
                                                ValidationGroup="ChangePassword" />
                                        </div>
                                    </div>

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
                                    <a class="btn btn-primary btn-user btn-block" href="#" data-toggle="modal" data-target="#newPasswordModal">Actualizar mi Contraseña
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

        <div class="modal fade" id="exampleModalToggle" aria-hidden="true" aria-labelledby="exampleModalToggleLabel" tabindex="-1">
        <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
            <div class="modal-header">
            <h5 class="modal-title" id="exampleModalToggleLabel">Seleccionar Nueva Licencia</h5>
            <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">×</span>
            </button>
            </div>
            <div class="modal-body">
                <label class="small mb-1" for="inputBillingName">Nombre de Licencia</label>
                <table class="table table-borderless">
                  <tbody>
                    <tr>
                      <td><asp:ImageButton ID="ImageButton1" ImageUrl="~/Content/images/Avatar.png" runat="server" width="64px" height="64px" /></td>
                      <td><asp:ImageButton ID="Image1" ImageUrl="~/Content/images/profile_images/Avatar_1.jpg" runat="server" width="64px" height="64px" /></td>
                      <td><asp:ImageButton ID="ImageButton2" ImageUrl="~/Content/images/profile_images/Avatar_2.jpg" runat="server" width="88px" height="88px" /></td>
                      <td><asp:ImageButton ID="ImageButton3" ImageUrl="~/Content/images/profile_images/Avatar_3.jpg" runat="server" width="88px" height="88px" /></td>
                    </tr>
                    <tr>
                      <td><asp:ImageButton ID="ImageButton4" ImageUrl="~/Content/images/profile_images/Avatar_4.jpg" runat="server" width="88px" height="88px" /></td>
                      <td><asp:ImageButton ID="ImageButton5" ImageUrl="~/Content/images/profile_images/Avatar_5.jpg" runat="server" width="88px" height="88px" /></td>
                      <td><asp:ImageButton ID="ImageButton6" ImageUrl="~/Content/images/profile_images/Avatar_6.jpg" runat="server" width="88px" height="88px" /></td>
                      <td><asp:ImageButton ID="ImageButton7" ImageUrl="~/Content/images/profile_images/Avatar_7.jpg" runat="server" width="88px" height="88px" /></td>
                    </tr>
                    <tr>
                      <td><asp:ImageButton ID="ImageButton8" ImageUrl="~/Content/images/profile_images/Avatar_8.jpg" runat="server" width="88px" height="88px" /></td>
                      <td><asp:ImageButton ID="ImageButton9" ImageUrl="~/Content/images/profile_images/Avatar_9.jpg" runat="server" width="88px" height="88px" /></td>
                      <td><asp:ImageButton ID="ImageButton10" ImageUrl="~/Content/images/profile_images/Avatar_10.jpg" runat="server" width="88px" height="88px" /></td>
                      <td><asp:ImageButton ID="ImageButton11" ImageUrl="~/Content/images/profile_images/Avatar_11.jpg" runat="server" width="88px" height="88px" /></td>
                    </tr>
                  </tbody>
                </table>
            </div>
            <div class="modal-footer">
                <div class="row justify-content-center">
                    <asp:Button runat="server" Text="Atar Licencia" CssClass="btn btn-primary" />
                </div>
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
                    });
                }
    </script>
</asp:Content>
