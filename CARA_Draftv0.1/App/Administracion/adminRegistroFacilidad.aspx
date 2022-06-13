<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="adminRegistroFacilidad.aspx.cs" Inherits="CARA_Draftv0._1.App.Administracion.adminRegistroFacilidad" %>
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
                                <i class="fas fa-fw fa-hospital"></i><span> Registro de Facilidad</span>
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

    <div class="container-xl px-4">
        <div class="row justify-content-center">
            <div class="col-xl-6 align-self-center">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <div class="text-center">
                                    <img class="img-account-profile mb-2" src="<%=ResolveClientUrl("~/Content/images/undraw_visionary_technology_re_jfp7.svg")%>">
                                    <div style="text-align:center" class="small font-italic text-muted mb-4"><span>Nueva Facilidad</span></div>
                                </div>
                            </div>
                        </div>
                        <h5 class="card-title mb-4">Incluir información de nueva facilidad</h5>
                        <div class="row">
                            <div class="mb-3 col-md-6">
                                <label class="small mb-1" for="inputBillingName">Nombre de Centro</label>
                                <asp:TextBox runat="server" ID="txtCentro" CssClass="form-control form-control-user" Placeholder="Ej. Hogar del Cristo"/>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCentro" CssClass="text-danger" ErrorMessage="Nombre de Centro/Facilidad" />
                            </div>
                            <div class="mb-3 col-md-6">
                                <label class="small mb-1" for="inputBillingCCNumber">ID en el SLYC</label>
                                <asp:TextBox runat="server" ID="txtIdSlyc" CssClass="form-control form-control-user" Placeholder="Ej. 817F362B-1D1E-4D76-8B63-D6BEF8BC0067"/>
                            </div>
                        </div>
                        <hr class="my-4">
                        <h5 class="card-title mb-4">Seleccionar licencia atada a facilidad</h5>
                        <div class="row gx-3">
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlLicencia"></asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlLicencia" InitialValue="0"
                            CssClass="text-danger" ToolTip="Seleccione un valor de la lista. Este campo es requerido." ErrorMessage="Licencia" />
                        </div>
                        <div class="row gx-3">
                            <div class="mb-3 col-md-6">
                                <label class="small mb-1" for="inputBillingName">Número de Licencia</label>
                                <asp:TextBox runat="server" ID="txtNumLicencia" CssClass="form-control form-control-user" Placeholder="Ej. 1245634"/>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNumLicencia" CssClass="text-danger" ErrorMessage="Número de licencia otorgada" />
                            </div>
                            <div class="mb-3 col-md-6">
                                <label class="small mb-1" for="inputBillingCCNumber">Fecha de Expiración</label>
                                <asp:TextBox runat="server" ID="txtFechaExp" CssClass="form-control form-control-user" TextMode="Date" Placeholder="Ej. Perez"/>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFechaExp" CssClass="text-danger" ErrorMessage="Fecha de expiración de licencia" />
                            </div>
                        </div>
                        <hr class="my-4">
                        <h5 class="card-title mb-4">Seleccionar cuenta principal</h5>
                        <div class="row">
                            <div class="table-responsive">
                                <asp:GridView runat="server" ID="gvUsuariosASSMCAList" CssClass="table table-bordered usuariosASSMCAListTable" Width="100%" AutoGenerateColumns="false" DataKeyNames="Nombre">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Seleccionar">
                                            <ItemTemplate>
                                                <div style="text-align:center">
                                                    <asp:CheckBox ID="chkRegistrado" AutoPostBack="true" OnCheckedChanged="chk_Changed" runat="server" />
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Nombre">
                                            <ItemTemplate>
                                                <div class="row">&nbsp <%# Eval("Nombre") %></div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Email" HeaderText="CorreoElectrónico" />
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No existen usuarios adicionales al de usted
                                    </EmptyDataTemplate>
                                    <%--<i class='fas fa-fw fa-trash-alt'></i>--%>
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="row">
                            <asp:Button runat="server" Text="Registrar" OnClick="BtnRegistrar_Click" CssClass="btn btn-primary" />
                        </div>
                    </div>
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
