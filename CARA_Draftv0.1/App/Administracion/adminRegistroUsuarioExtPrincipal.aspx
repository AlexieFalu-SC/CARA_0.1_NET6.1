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
                                <a class="btn btn-sm btn-light text-primary" href="<%=ResolveClientUrl("~/App/Administracion/registradoListaUsuarios")%>">
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
                                                    <div class="mb-3">
                                                        <label class="small mb-1" for="inputUsername">Correo Electrónico (debe ser el mismo al utilizado en el sistema SLYC)</label>
                                                        <asp:TextBox runat="server" ID="Email" CssClass="form-control form-control-user" TextMode="Email" Placeholder="Ej. admin@assmca.pr.gov" />
                                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="text-danger" ErrorMessage="El correo electrónico es requerido" />
                                                    </div>
                                                    <div class="row gx-3">
                                                        <div class="mb-3 col-md-6">
                                                            <label class="small mb-1" for="inputFirstName">Primer Nombre</label>
                                                            <asp:TextBox runat="server" ID="NB_Primero" CssClass="form-control form-control-user" Placeholder="Ej. Joe"/>
                                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="NB_Primero" CssClass="text-danger" ErrorMessage="Su primer nombre es requerido" />
                                                        </div>
                                                        <div class="mb-3 col-md-6">
                                                            <label class="small mb-1" for="inputLastName">Segundo Nombre</label>
                                                            <asp:TextBox runat="server" ID="NB_Segundo" CssClass="form-control form-control-user" Placeholder="Ej. Frank"/>
                                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="NB_Segundo" CssClass="text-danger" ErrorMessage="Su segundo nombre es requerido" />
                                                        </div>
                                                    </div>
                                                    <div class="row gx-3">
                                                        <div class="mb-3 col-md-6">
                                                            <label class="small mb-1" for="inputOrgName">Primer Apellido</label>
                                                            <asp:TextBox runat="server" ID="AP_Primero" CssClass="form-control form-control-user" Placeholder="Ej. Doe"/>
                                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="AP_Primero" CssClass="text-danger" ErrorMessage="Su primer apellido es requerido" />
                                                        </div>
                                                        <div class="mb-3 col-md-6">
                                                            <label class="small mb-1" for="inputLocation">Segundo Apellido</label>
                                                            <asp:TextBox runat="server" ID="AP_Segundo" CssClass="form-control form-control-user" Placeholder="Ej. Perez"/>
                                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="AP_Segundo" CssClass="text-danger" ErrorMessage="Su segundo nombre es requerido" />
                                                        </div>
                                                    </div>
                                                    <hr class="my-4">
                                                    <div class="d-flex justify-content-between">
                                                        <button class="btn btn-light disabled" type="button" disabled="">Previous</button>
                                                        <button class="btn btn-primary" type="button">Next</button>
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
                                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCentro" CssClass="text-danger" ErrorMessage="Nombre de Centro/Facilidad" />
                                                        </div>
                                                        <div class="mb-3 col-md-6">
                                                            <label class="small mb-1" for="inputBillingCCNumber">ID en el SLYC</label>
                                                            <asp:TextBox runat="server" ID="txtIdSlyc" CssClass="form-control form-control-user" Placeholder="Ej. 817F362B-1D1E-4D76-8B63-D6BEF8BC0067"/>
                                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtIdSlyc" CssClass="text-danger" ErrorMessage="Código Identificador en el SLYC" />
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
                                                        <button class="btn btn-light" type="button">Previous</button>
                                                        <button class="btn btn-primary" type="button">Next</button>
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
                                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNumLicencia" CssClass="text-danger" ErrorMessage="Número de licencia otorgada" />
                                                        </div>
                                                        <div class="mb-3 col-md-6">
                                                            <label class="small mb-1" for="inputBillingCCNumber">Fecha de Expiración</label>
                                                            <asp:TextBox runat="server" ID="txtFechaExp" CssClass="form-control form-control-user" Placeholder="Ej. Perez"/>
                                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFechaExp" CssClass="text-danger" ErrorMessage="Fecha de expiración de licencia" />
                                                        </div>
                                                    </div>
                                                    <hr class="my-4">
                                                    <div class="d-flex justify-content-between">
                                                        <button class="btn btn-light" type="button">Previous</button>
                                                        <button class="btn btn-primary" type="button">Next</button>
                                                    </div>
                                                </form>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- Wizard tab pane item 4-->
                                    <div class="tab-pane py-5 py-xl-10 fade" id="wizard4" role="tabpanel" aria-labelledby="wizard4-tab">
                                        <div class="row justify-content-center">
                                            <div class="col-xxl-6 col-xl-8">
                                                <h3 class="text-primary">Step 4</h3>
                                                <h5 class="card-title mb-4">Review the following information and submit</h5>
                                                <div class="row small text-muted">
                                                    <div class="col-sm-3 text-truncate"><em>Username:</em></div>
                                                    <div class="col">username</div>
                                                </div>
                                                <div class="row small text-muted">
                                                    <div class="col-sm-3 text-truncate"><em>Name:</em></div>
                                                    <div class="col">Valerie Luna</div>
                                                </div>
                                                <div class="row small text-muted">
                                                    <div class="col-sm-3 text-truncate"><em>Organization Name:</em></div>
                                                    <div class="col">Start Bootstrap</div>
                                                </div>
                                                <div class="row small text-muted">
                                                    <div class="col-sm-3 text-truncate"><em>Location:</em></div>
                                                    <div class="col">San Francisco, CA</div>
                                                </div>
                                                <div class="row small text-muted">
                                                    <div class="col-sm-3 text-truncate"><em>Email Address:</em></div>
                                                    <div class="col">name@example.com</div>
                                                </div>
                                                <div class="row small text-muted">
                                                    <div class="col-sm-3 text-truncate"><em>Phone Number:</em></div>
                                                    <div class="col">555-123-4567</div>
                                                </div>
                                                <div class="row small text-muted">
                                                    <div class="col-sm-3 text-truncate"><em>Birthday:</em></div>
                                                    <div class="col">06/10/1988</div>
                                                </div>
                                                <div class="row small text-muted">
                                                    <div class="col-sm-3 text-truncate"><em>Credit Card Number:</em></div>
                                                    <div class="col">**** **** **** 1111</div>
                                                </div>
                                                <div class="row small text-muted">
                                                    <div class="col-sm-3 text-truncate"><em>Credit Card Expiration:</em></div>
                                                    <div class="col">06/2024</div>
                                                </div>
                                                <hr class="my-4">
                                                <div class="d-flex justify-content-between">
                                                    <button class="btn btn-light" type="button">Previous</button>
                                                    <button class="btn btn-primary" type="button">Submit</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </main>
</asp:Content>
