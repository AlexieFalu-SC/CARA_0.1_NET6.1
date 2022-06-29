<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="adminEdicionFacilidad.aspx.cs" Inherits="CARA_Draftv0._1.App.Administracion.adminEdicionFacilidad" %>
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
                                <i class="fas fa-fw fa-user-edit"></i><span> Edición de Facilidad</span>
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
                                    <div style="text-align:center" class="small font-italic text-muted mb-4"><span>Información de Facilidad</span></div>
                                </div>
                            </div>
                        </div>
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
                        <div class="row">
                            <div class="mb-3 col-md-6">
                                <label class="small mb-1" for="inputBillingName">Nombre de Cuenta Principal</label>
                                <asp:Label ID="lblNombrePrincipal" CssClass="form-control form-control-user" Text="" runat="server" />
                            </div>
                            <div class="mb-3 col-md-6">
                                <label class="small mb-1" for="inputBillingCCNumber">Email de Cuenta Principal</label>
                                <asp:Label ID="lblEmailPrincipal" CssClass="form-control form-control-user" Text="" runat="server" />
                            </div>
                        </div>
                        <hr />
                        <div class="row justify-content-center">
                            <asp:Button runat="server" Text="Actualizar" OnClick="BtnActualizar_Click" OnClientClick="divShow(); return true;" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <br />

    <div class="container-fluid px-4">
        <div class="card">
            <div class="card-header">
                <div class="btn-toolbar justify-content-between" role="toolbar">
                    <div>
                        Licencias Atadas a la Facilidad
                    </div>
                    <div>
                    <a class="btn btn-sm btn-light text-primary" href="#" data-toggle="modal" data-target="#exampleModalToggle">
                        <i class="fas fa-fw fa-file-export"></i>
                        Atar Nueva Licencia
                    </a>
                    </div>
                </div>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:GridView runat="server" ID="gvUsuariosASSMCAList" CssClass="table table-bordered usuariosASSMCAListTable" Width="100%" AutoGenerateColumns="false" DataKeyNames="PK_Centro_Licencia">
                        <Columns>
                            <asp:BoundField DataField="NB_Licencia" HeaderText="Nombre de Licencia" />
                            <asp:BoundField DataField="NR_Licencia" HeaderText="Número de Licencia" />
                            <asp:BoundField DataField="FE_Expiracion" HeaderText="Expiración de Licencia" DataFormatString = "{0:MM/dd/yyyy}"/>
                            <asp:BoundField DataField="NB_Categoria" HeaderText="Categoria de Licencia" />
                            <asp:BoundField DataField="CentroLicenciaEstatus" HeaderText="Estatus de Licencia" />
                            <asp:TemplateField HeaderText="Acciones"> 
                            <ItemTemplate>
                                <asp:Label ID="Edit" runat="server" Enabled="true"></asp:Label>
                                <a href='<%=ResolveClientUrl("~/App/Administracion/adminEdicionLicencia.aspx?pk_licencia=")%><%#Eval("PK_Centro_Licencia")%>' ><i class='fas fa-fw fa-edit'></i></a>
                                <%--<asp:Label ID="Delete" runat="server" Enabled="true"></asp:Label>
                                <a class="btn btn-datatable btn-icon btn-transparent-dark me-2"  href='~/Account/DeleteUser.aspx?pk_usuario=<%#Eval("PK_Usuario")%>'><i class='fas fa-fw fa-trash-alt'></i></a>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            Esta facilidad no contiene licencias atadas
                        </EmptyDataTemplate>
                        <%--<i class='fas fa-fw fa-trash-alt'></i>--%>
                    </asp:GridView>
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
                <div class="row gx-3">
                    <asp:DropDownList runat="server" CssClass="form-control form-control-user" ID="ddlLicencia"></asp:DropDownList>
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
            </div>
            <div class="modal-footer">
                <div class="row justify-content-center">
                    <asp:Button runat="server" Text="Atar Licencia" OnClick="BtnAtarLicencia_Click" OnClientClick="divShow();" CssClass="btn btn-primary" />
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

    $(window).on('load', function () {
        $("#coverScreen").hide();
    });

    function divShow() {
        $("#coverScreen").show();
    }
</script>
</asp:Content>
