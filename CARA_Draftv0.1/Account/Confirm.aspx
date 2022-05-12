<%@ Page Title=" | Confirme Cuenta" Language="C#" MasterPageFile="~/NoLogin.Master" AutoEventWireup="true" CodeBehind="Confirm.aspx.cs" Inherits="CARA_Draftv0._1.Account.Confirm" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1">
    
<main>
    <div class="container-xl px-4">
        <div class="row justify-content-center">
            <div class="col-lg-8">
                <div class="text-center">
                    <asp:PlaceHolder runat="server" ID="successPanel" ViewStateMode="Disabled" Visible="true">
                         <%--<div class="error mx-auto"  data-text="Nueva Cuenta Confirmada">
                           Nueva Cuenta Confirmada
                        </div>--%>
                        <asp:Image ID="logoASSMCA" ImageUrl="~/Content/images/ASSMCA_Logo2021.png" runat="server" CssClass="img-fluid mt-4" style="max-height:250px;"/>
                        <h3>SEATSS</h3>
                        <p class="lead text-gray-800 mb-5">Gracias por confirmar su cuenta. Solo falta registrar su nueva contraseña en la parte de abajo.</p>
                        <!-- Basic Card Example -->
                        <div class="row justify-content-sm-center">
                        <div class="col-xl-6 col-lg-5">
                            <div class="card shadow mb-4">
                                <div class="card-header py-3">
                                    <h6 class="m-0 font-weight-bold text-primary">Registrar Nueva Contraseña</h6>
                                </div>
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
                                        <asp:Button runat="server" Text="Registrar mi Contraseña" ValidationGroup="ChangePassword" OnClick="Reset_Click" CssClass="btn btn-primary btn-user btn-block" />
                                </div>
                            </div>
                        </div>
                        </div>
                        <%--<p>
                            Gracias por confirmar su cuenta. Presione <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login">aqui</asp:HyperLink>  para acceder al Sistema CARA            
                        </p>--%>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder runat="server" ID="errorPanel" ViewStateMode="Disabled" Visible="false">
                        <asp:Image ID="Image1" ImageUrl="~/Content/images/ASSMCA_Logo2021.png" runat="server" CssClass="img-fluid mt-4" style="max-height:250px;"/>
                        <h3>SEATSS</h3>
                        <p class="lead text-gray-800 mb-5">¡Ocurrió un Error!</p>
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="ErrorMessage" />
                        </p>
                        <a href="<%=ResolveClientUrl("~/Account/Login")%>">← Acceder a Iniciar Sesión</a>
                    </asp:PlaceHolder>
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
