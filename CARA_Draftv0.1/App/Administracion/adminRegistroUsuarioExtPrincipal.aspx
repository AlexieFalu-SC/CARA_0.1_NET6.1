<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="adminRegistroUsuarioExtPrincipal.aspx.cs" Inherits="CARA_Draftv0._1.App.Administracion.adminRegistroUsuarioExtPrincipal" %>
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
                                    <i class="fas fa-fw fa-user-plus"></i><span> Agregar Nuevo Usuario Externo (Cuenta Principal)</span>
                                </div>
                            </h3>
                        </div>
                        <div class="col-auto">
                            <div class="btn-group mr-2">
                                <a class="btn btn-sm btn-light text-primary" href="<%=ResolveClientUrl("~/App/Administracion/adminListaUsuarios")%>">
                    <i class="fas fa-fw fa-user-plus"></i>Volver a lista de Usuarios
                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </header>
                    <!-- Main page content-->
                    <div class="container-xl px-4 mt-n10">
                        <!-- Wizard card example with navigation-->
                        <div class="card">
                            <div class="card-header border-bottom">
                                <ul class="nav nav-pills nav-justified flex-column flex-xl-row nav-wizard" id="cardTab" role="tablist">
                                    <li class="nav-item" role="presentation">
                                        <a class="nav-link active" id="wizard1-tab" data-toggle="tab" href="#wizard1" role="tab" aria-controls="wizard1" aria-selected="true">
                                            <div class="wizard-step-icon">1</div>
                                            <div class="wizard-step-text">
                                                <div class="wizard-step-text-name">Registro de Cuenta Principal</div>
                                                <div class="wizard-step-text-details">Información del nuevo usuario</div>
                                            </div>
                                        </a>
                                    </li>
                                    <li class="nav-item" role="presentation">
                                        <a class="nav-link" id="wizard2-tab" data-toggle="tab" href="#wizard2" role="tab" aria-controls="wizard2" aria-selected="false">
                                            <div class="wizard-step-icon">2</div>
                                            <div class="wizard-step-text">
                                                <div class="wizard-step-text-name">Registro de Facilidad</div>
                                                <div class="wizard-step-text-details">Información de facilidad atada</div>
                                            </div>
                                        </a>
                                    </li>
                                    <li class="nav-item" role="presentation">
                                        <a class="nav-link" id="wizard3-tab" data-toggle="tab" href="#wizard3" role="tab" aria-controls="wizard3" aria-selected="false">
                                            <div class="wizard-step-icon">3</div>
                                            <div class="wizard-step-text">
                                                <div class="wizard-step-text-name">Licencia de Facilidad</div>
                                                <div class="wizard-step-text-details">Información de licencia de facilidad</div>
                                            </div>
                                        </a>
                                    </li>
                                    <li class="nav-item" role="presentation">
                                        <a class="nav-link" id="wizard4-tab" data-toggle="tab" href="#wizard4" role="tab" aria-controls="wizard4" aria-selected="false">
                                            <div class="wizard-step-icon">4</div>
                                            <div class="wizard-step-text">
                                                <div class="wizard-step-text-name">Resumen</div>
                                                <div class="wizard-step-text-details">Resumen de la Información Ingresada</div>
                                            </div>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                            <div class="card-body">
                                <div class="tab-content" id="cardTabContent">
                                    <!-- Wizard tab pane item 1-->
                                    <div class="tab-pane py-5 py-xl-10 fade show active" id="wizard1" role="tabpanel" aria-labelledby="wizard1-tab">
                                        <div class="row justify-content-center">
                                            <div class="col-xxl-6 col-xl-8">
                                                <h3 class="text-primary">Paso 1</h3>
                                                <h5 class="card-title mb-4">Incluir información de nuevo usuario</h5>
                                                <form>
                                                    <div class="row gx-3">
                                                        <div class="mb-3 col-md-6">
                                                            <label class="small mb-1" for="inputUsername">Correo Electrónico (debe ser el mismo al utilizado en el sistema SLYC)</label>
                                                            <asp:TextBox runat="server" ID="Email" CssClass="form-control form-control-user" TextMode="Email" Placeholder="Ej. admin@assmca.pr.gov" />
                                                            <asp:RequiredFieldValidator ID="rvEmail" runat="server" ControlToValidate="Email" EnableClientScript="true" CssClass="text-danger" ErrorMessage="El correo electrónico es requerido" />
                                                        </div>
                                                        <div class="mb-3 col-md-6">
                                                            <label class="small mb-1">Teléfono</label>
                                                            <asp:TextBox runat="server" ID="Telefono" CssClass="form-control form-control-user" TextMode="Number" Placeholder="Ej. 7875555555"/>
                                                            <asp:RequiredFieldValidator ID="rvTelefono" runat="server" ControlToValidate="Telefono" CssClass="text-danger" ErrorMessage="Su telefono es requerido" />
                                                        </div>
                                                    </div>
                                                    <div class="row gx-3">
                                                        <div class="mb-3 col-md-6">
                                                            <label class="small mb-1" for="inputFirstName">Primer Nombre</label>
                                                            <asp:TextBox runat="server" ID="NB_Primero" CssClass="form-control form-control-user" Placeholder="Ej. Joe"/>
                                                            <asp:RequiredFieldValidator ID="rvPNB" runat="server" ControlToValidate="NB_Primero" CssClass="text-danger" ErrorMessage="Su primer nombre es requerido" />
                                                        </div>
                                                        <div class="mb-3 col-md-6">
                                                            <label class="small mb-1" for="inputLastName">Segundo Nombre</label>
                                                            <asp:TextBox runat="server" ID="NB_Segundo" CssClass="form-control form-control-user" Placeholder="Ej. Frank"/>
                                                            <asp:RequiredFieldValidator ID="rvSNB" runat="server" ControlToValidate="NB_Segundo" CssClass="text-danger" ErrorMessage="Su segundo nombre es requerido" />
                                                        </div>
                                                    </div>
                                                    <div class="row gx-3">
                                                        <div class="mb-3 col-md-6">
                                                            <label class="small mb-1" for="inputOrgName">Primer Apellido</label>
                                                            <asp:TextBox runat="server" ID="AP_Primero" CssClass="form-control form-control-user" Placeholder="Ej. Doe"/>
                                                            <asp:RequiredFieldValidator ID="rvPAP" runat="server" ControlToValidate="AP_Primero" CssClass="text-danger" ErrorMessage="Su primer apellido es requerido" />
                                                        </div>
                                                        <div class="mb-3 col-md-6">
                                                            <label class="small mb-1" for="inputLocation">Segundo Apellido</label>
                                                            <asp:TextBox runat="server" ID="AP_Segundo" CssClass="form-control form-control-user" Placeholder="Ej. Perez"/>
                                                            <asp:RequiredFieldValidator ID="rvSAP" runat="server" ControlToValidate="AP_Segundo" CssClass="text-danger" ErrorMessage="Su segundo nombre es requerido" />
                                                        </div>
                                                    </div>
                                                    <hr class="my-4">
                                                    <div class="d-flex justify-content-between">
                                                        
                                                        <button class="btn btn-light disabled" type="button" disabled="">Previous</button>
                                                        <%--<asp:Button ID="btnS" Text="Siguiente" CssClass="btn btn-primary" runat="server" OnClientClick="wizard1to2();"/>--%>
                                                        <button class="btn btn-primary" type="button" onclick="wizard1to2()">Siguiente</button>
                                                        <%--<a class="btn btn-primary"  onclick="wizard1to2();">Siguiente</a>--%>
                                                    </div>
                                                </form>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- Wizard tab pane item 2-->
                                    <div class="tab-pane py-5 py-xl-10 fade" id="wizard2" role="tabpanel" aria-labelledby="wizard2-tab">
                                        <div class="row justify-content-center">
                                            <div class="col-xxl-6 col-xl-8">
                                                <h3 class="text-primary">Paso 2</h3>
                                                <h5 class="card-title mb-4">Incluir información de nueva facilidad</h5>
                                                <form>
                                                    <div class="row gx-3">
                                                        <div class="mb-3 col-md-6">
                                                            <label class="small mb-1" for="inputBillingName">Nombre de Centro</label>
                                                            <asp:TextBox runat="server" ID="txtCentro" CssClass="form-control form-control-user" Placeholder="Ej. Hogar del Cristo"/>
                                                            <asp:RequiredFieldValidator ID="rvCentro" runat="server" ControlToValidate="txtCentro" CssClass="text-danger" ErrorMessage="Nombre de Centro/Facilidad" />
                                                        </div>
                                                        <div class="mb-3 col-md-6">
                                                            <label class="small mb-1" for="inputBillingCCNumber">ID en el SLYC</label>
                                                            <asp:TextBox runat="server" ID="txtIdSlyc" CssClass="form-control form-control-user" Placeholder="Ej. 817F362B-1D1E-4D76-8B63-D6BEF8BC0067"/>
                                                            <%--<asp:RequiredFieldValidator  runat="server" ControlToValidate="txtIdSlyc" CssClass="text-danger" ErrorMessage="Código Identificador en el SLYC" />--%>
                                                        </div>
                                                    </div>
                                                    <%--<div class="row gx-3">
                                                        <div class="col-md-4 mb-4 mb-md-0">
                                                            <label class="small mb-1" for="inputOrgName">Card expiry month</label>
                                                            <input class="form-control" id="inputOrgNamea" type="text" placeholder="Enter expiry month" value="06">
                                                        </div>
                                                        <div class="col-md-4 mb-4 mb-md-0">
                                                            <label class="small mb-1" for="inputLocation">Card expiry year</label>
                                                            <input class="form-control" id="inputLocations" type="text" placeholder="Enter expiry year" value="2024">
                                                        </div>
                                                        <div class="col-md-4 mb-0">
                                                            <label class="small mb-1" for="inputLocation">CVV Number</label>
                                                            <input class="form-control" id="inputLocationd" type="password" placeholder="Enter CVV number" value="111">
                                                        </div>
                                                    </div>--%>
                                                    <hr class="my-4">
                                                    <div class="d-flex justify-content-between">
                                                        <button class="btn btn-primary" type="button" onclick="wizard2to1()">Anterior</button>
                                                        <button class="btn btn-primary" type="button" onclick="wizard2to3()">Siguiente</button>
                                                    </div>
                                                </form>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- Wizard tab pane item 3-->
                                    <div class="tab-pane py-5 py-xl-10 fade" id="wizard3" role="tabpanel" aria-labelledby="wizard3-tab">
                                        <div class="row justify-content-center">
                                            <div class="col-xxl-6 col-xl-8">
                                                <h3 class="text-primary">Paso 3</h3>
                                                <h5 class="card-title mb-4">Seleccionar licencia atada a facilidad</h5>
                                                <form>
                                                    <div class="row gx-3">
                                                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlLicencia"></asp:DropDownList>
                                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlLicencia" InitialValue="0"
                                                        CssClass="text-danger" ToolTip="Seleccione un valor de la lista. Este campo es requerido." ErrorMessage="Licencia" />
                                                    </div>
                                                    <div class="row gx-3">
                                                        <div class="mb-3 col-md-6">
                                                            <label class="small mb-1" for="inputBillingName">Número de Licencia</label>
                                                            <asp:TextBox runat="server" ID="txtNumLicencia" CssClass="form-control form-control-user" Placeholder="Ej. 1245634"/>
                                                            <asp:RequiredFieldValidator ID="rvNumLicencia" runat="server" ControlToValidate="txtNumLicencia" CssClass="text-danger" ErrorMessage="Número de licencia otorgada" />
                                                        </div>
                                                        <div class="mb-3 col-md-6">
                                                            <label class="small mb-1" for="inputBillingCCNumber">Fecha de Expiración</label>
                                                            <asp:TextBox runat="server" ID="txtFechaExp" CssClass="form-control form-control-user" TextMode="Date" Placeholder="Ej. Perez"/>
                                                            <asp:RequiredFieldValidator ID="rvFechaExp" runat="server" ControlToValidate="txtFechaExp" CssClass="text-danger" ErrorMessage="Fecha de expiración de licencia" />
                                                        </div>
                                                    </div>
                                                    <hr class="my-4">
                                                    <div class="d-flex justify-content-between">
                                                        <button class="btn btn-primary" type="button" onclick="wizard3to2()">Anterior</button>
                                                       <%-- <a class="btn btn-light" data-toggle="tab" href="#wizard2" role="tab" aria-controls="wizard2" onclick="wizard3to2();" type="button">Anterior</a>--%>
                                                        <button class="btn btn-primary" type="button" onclick="wizard3to4()">Siguiente</button>
                                                    </div>
                                                </form>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- Wizard tab pane item 4-->
                                    <div class="tab-pane py-5 py-xl-10 fade" id="wizard4" role="tabpanel" aria-labelledby="wizard4-tab">
                                        <div class="row justify-content-center">
                                            <div class="col-xxl-6 col-xl-8">
                                                <h3 class="text-primary">Paso 4</h3>
                                                <h5 class="card-title mb-4">Favor de revisar la información ingresada y luego presione el botón de Registrar</h5>
                                                <div class="row small text-muted">
                                                    <div class="col-sm-3 text-truncate"><em>Correo Electrónico:</em></div>
                                                    <div class="col"><asp:Label ID="lblEmail" Text="" runat="server" ClientIDMode="Static" /></div>
                                                </div>
                                                <div class="row small text-muted">
                                                    <div class="col-sm-3 text-truncate"><em>Teléfono:</em></div>
                                                    <div class="col"><asp:Label ID="lblTelefono" Text="" runat="server" ClientIDMode="Static"/></div>
                                                </div>
                                                <div class="row small text-muted">
                                                    <div class="col-sm-3 text-truncate"><em>Primer Nombre:</em></div>
                                                    <div class="col"><asp:Label ID="lblNB_Primero" Text="" runat="server" ClientIDMode="Static"/></div>
                                                </div>
                                                <div class="row small text-muted">
                                                    <div class="col-sm-3 text-truncate"><em>Segundo Nombre:</em></div>
                                                    <div class="col"><asp:Label ID="lblNB_Segundo" Text="" runat="server" ClientIDMode="Static"/></div>
                                                </div>
                                                <div class="row small text-muted">
                                                    <div class="col-sm-3 text-truncate"><em>Primer Apellido:</em></div>
                                                    <div class="col"><asp:Label ID="lblAP_Primero" Text="" runat="server" ClientIDMode="Static"/></div>
                                                </div>
                                                <div class="row small text-muted">
                                                    <div class="col-sm-3 text-truncate"><em>Segundo Apellido:</em></div>
                                                    <div class="col"><asp:Label ID="lblAP_Segundo" Text="" runat="server" ClientIDMode="Static"/></div>
                                                </div>
                                                <div class="row small text-muted">
                                                    <div class="col-sm-3 text-truncate"><em>Nombre de Facilidad:</em></div>
                                                    <div class="col"><asp:Label ID="lblCentro" Text="" runat="server" ClientIDMode="Static"/></div>
                                                </div>
                                                <div class="row small text-muted">
                                                    <div class="col-sm-3 text-truncate"><em>ID en el SLYC:</em></div>
                                                    <div class="col"><asp:Label ID="lblSlyc" Text="" runat="server" ClientIDMode="Static"/></div>
                                                </div>
                                                <div class="row small text-muted">
                                                    <div class="col-sm-3 text-truncate"><em>Licencia de Facilidad:</em></div>
                                                    <div class="col"><asp:Label ID="lblLicencia" Text="" runat="server" ClientIDMode="Static"/></div>
                                                </div>
                                                <div class="row small text-muted">
                                                    <div class="col-sm-3 text-truncate"><em>Fecha de Expiración:</em></div>
                                                    <div class="col"><asp:Label ID="lblFechaExp" Text="" runat="server" ClientIDMode="Static"/></div>
                                                </div>
                                                <hr class="my-4">
                                                <div class="d-flex justify-content-between">
                                                    <button class="btn btn-primary" type="button" onclick="wizard4to3()">Anterior</button>
                                                    <button class="btn btn-primary" type="button">Registrar</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </main>

<script type="text/javascript">
    <%-- $(document).ready(function () {

        /*Información de Paso 1*/
        var Email = document.getElementById("<%=Email.ClientID%>");
        var Telefono = document.getElementById("<%=Telefono.ClientID%>");
        var NB_Primero = document.getElementById("<%=NB_Primero.ClientID%>");
        var NB_Segundo = document.getElementById("<%=NB_Segundo.ClientID%>");
        var AP_Primero = document.getElementById("<%=AP_Primero.ClientID%>");
        var AP_Segundo = document.getElementById("<%=AP_Segundo.ClientID%>");

        /*Información de Paso 2*/
        var txtCentro = document.getElementById("<%=txtCentro.ClientID%>");
        var txtIdSlyc = document.getElementById("<%=txtIdSlyc.ClientID%>");

        /*Información de Paso 3*/
        var txtNumLicencia = document.getElementById("<%=txtNumLicencia.ClientID%>");
        var txtFechaExp = document.getElementById("<%=txtFechaExp.ClientID%>");

        /*Asignación de valores en Resumen*/
        document.getElementById("<%=lblEmail.ClientID%>").textContent = Email;
        document.getElementById("<%=lblTelefono.ClientID%>").textContent = Telefono;
        document.getElementById("<%=lblNB_Primero.ClientID%>").textContent = NB_Primero;
        document.getElementById("<%=lblNB_Segundo.ClientID%>").textContent = NB_Segundo;
        document.getElementById("<%=lblAP_Primero.ClientID%>").textContent = AP_Primero;
        document.getElementById("<%=lblAP_Segundo.ClientID%>").textContent = AP_Segundo;
        document.getElementById("<%=lblCentro.ClientID%>").textContent = txtCentro;
        document.getElementById("<%=lblSlyc.ClientID%>").textContent = txtIdSlyc;
        document.getElementById("<%=lblLicencia.ClientID%>").textContent = txtNumLicencia;
        document.getElementById("<%=lblFechaExp.ClientID%>").textContent = txtFechaExp;

    });--%>

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

    function wizard1to2() {

        var v = document.getElementById("<%=rvEmail.ClientID%>");
        var t = document.getElementById("<%=rvTelefono.ClientID%>");
        var pnb = document.getElementById("<%=rvPNB.ClientID%>");
        var snb = document.getElementById("<%=rvSNB.ClientID%>");
        var pap = document.getElementById("<%=rvPAP.ClientID%>");
        var sap = document.getElementById("<%=rvSAP.ClientID%>");

        ValidatorValidate(v);
        ValidatorValidate(t);
        ValidatorValidate(pnb);
        ValidatorValidate(snb);
        ValidatorValidate(pap);
        ValidatorValidate(sap);

        if (v.isvalid && t.isvalid && pnb.isvalid && snb.isvalid && pap.isvalid && sap.isvalid)
            document.getElementById("wizard2-tab").click();
        else
            return
    }

    function wizard2to3() {
        var v = document.getElementById("<%=rvCentro.ClientID%>");

        ValidatorValidate(v);
        if (v.isvalid)
            document.getElementById("wizard3-tab").click();
        else
            return
    }

    function wizard3to4() {
        var v = document.getElementById("<%=rvNumLicencia.ClientID%>");
        var f = document.getElementById("<%=rvFechaExp.ClientID%>");

        ValidatorValidate(v);
        ValidatorValidate(f);
        if (v.isvalid && f.isvalid) {
            /*Información de Paso 1*/
            var Email = document.getElementById("<%=Email.ClientID%>");
            var Telefono = document.getElementById("<%=Telefono.ClientID%>");
            var NB_Primero = document.getElementById("<%=NB_Primero.ClientID%>");
            var NB_Segundo = document.getElementById("<%=NB_Segundo.ClientID%>");
            var AP_Primero = document.getElementById("<%=AP_Primero.ClientID%>");
            var AP_Segundo = document.getElementById("<%=AP_Segundo.ClientID%>");

            /*Información de Paso 2*/
            var txtCentro = document.getElementById("<%=txtCentro.ClientID%>");
            var txtIdSlyc = document.getElementById("<%=txtIdSlyc.ClientID%>");

            /*Información de Paso 3*/
            var txtNumLicencia = document.getElementById("<%=txtNumLicencia.ClientID%>");
            var txtFechaExp = document.getElementById("<%=txtFechaExp.ClientID%>");

            /*Asignación de valores en Resumen*/
            document.getElementById("<%=lblEmail.ClientID%>").innerText = Email.value;
            document.getElementById("<%=lblTelefono.ClientID%>").innerText = Telefono.value;
            document.getElementById("<%=lblNB_Primero.ClientID%>").innerText = NB_Primero.value;
            document.getElementById("<%=lblNB_Segundo.ClientID%>").innerText = NB_Segundo.value;
            document.getElementById("<%=lblAP_Primero.ClientID%>").innerText = AP_Primero.value;
            document.getElementById("<%=lblAP_Segundo.ClientID%>").innerText = AP_Segundo.value;
            document.getElementById("<%=lblCentro.ClientID%>").innerText = txtCentro.value;
            document.getElementById("<%=lblSlyc.ClientID%>").innerText = txtIdSlyc.value;
            document.getElementById("<%=lblLicencia.ClientID%>").innerText = txtNumLicencia.value;
            document.getElementById("<%=lblFechaExp.ClientID%>").innerText = txtFechaExp.value;

            document.getElementById("wizard4-tab").click();
        }
        else
            return
    }

    function wizard2to1() {

        document.getElementById("wizard1-tab").click();
    }

    function wizard3to2() {

        document.getElementById("wizard2-tab").click();
    }

    function wizard4to3() {

        document.getElementById("wizard3-tab").click();
    }

</script>
</asp:Content>
