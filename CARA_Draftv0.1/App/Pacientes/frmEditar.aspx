<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="frmEditar.aspx.cs" Inherits="CARA_Draftv0._1.App.Pacientes.frmEditar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
        <header class="page-header page-header-compact page-header-light border-bottom mb-4">
            <div class="container-fluid px-4">
                <div class="page-header-content">
                    <div class="row justify-content-center">
                        <div class="col-xl-6 align-self-center">
                            <h5 style="text-align:center"><b>Centro: </b><i><asp:Label Text="" runat="server" Id="lblCentro"/></i> <b>Licencia: </b><i><asp:Label Text="" runat="server" Id="lblLicencia"/></i></h5>
                        </div>
                    </div>
                    <div class="row align-items-center justify-content-between pt-3">
                        <div class="col-auto mb-3">
                            <h3 class="page-header-title">
                                <div class="page-header-icon">
                                    <i class="fas fa-fw fa-plus"></i><i class="fas fa-fw fa-user-md"></i><span><asp:Label ID="lblTipoAccion" Text="" runat="server" /></span>
                                </div>
                            </h3>
                        </div>
                    </div>
                </div>
            </div>
        </header>

        <div id="PacienteBox" runat="server" class="container-xl px-4 mt-4">
            <div class="row justify-content-center">
                <div class="col-xl-6 align-self-center">
                    <div class="card">
                        <div class="card-header">
                            <h5 class="card-title">Información de Paciente</h5>
                        </div>
                        <div class="card-body text-center">
                                <asp:Image ID="profileImg" ImageUrl="~/Content/images/Avatar.png" runat="server" CssClass="img-account-profile rounded-circle mb-2" />
                                <div class="small font-italic text-muted mb-4"><span>Nuevo Paciente</span></div>
                        </div>
                        <hr />
                        <div class="card-body">
                            <div class="row">
                                <div class="form-group col-6">
                                    <span class="SEPSLabelConsulta" title='Identificador Único de Paciente bajo el centro seleccionado. Código único para cada persona registrada en el sistema. Toda paciente tiene un número global diferente que lo identifica univocamente dentro del sistema, y lo diferencia de todos los otros pacientes registrados. Este código se obiene luego de registrar el paciente.'>IUP:</span>
                                    <asp:Label ID="lblIUP" runat="server" ForeColor="MediumSeaGreen" ToolTip="Usted esta creando un nuevo paciente, el sistema le otorgará uun identificador único una vez usted haya guardado el registro."/>
                                </div>
                                <div class="form-group col-6">
                                    <span class="SEPSLabelConsulta" title="Número entero que identifica una paciente para un centro particular.">Expediente:</span>
                                    <asp:RequiredFieldValidator ID="rfvExpediente" runat="server" CssClass="rightFloatAsterisk" Display="Dynamic" ToolTip="Este campo requerido." ErrorMessage="Expediente" ControlToValidate="txtExpediente" Text="*"/>
                                    <div class="expandibleDiv">
                                        <asp:TextBox ID="txtExpediente" runat="server"  CssClass="form-control" ToolTip="Escriba un número de expediente para el centro en que esta usted registrado. Este atributo es requerido para crear un nuevo registro de paciente."/>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-6">
                                    <span class="SEPSLabelConsulta">Fecha de Nacimiento:</span>
                                    <asp:RequiredFieldValidator ID="rfvNacimiento" runat="server" CssClass="rightFloatAsterisk" Display="Dynamic" ToolTip="Este campo requerido." ErrorMessage="Fecha de Nacimiento" ControlToValidate="txtNacimiento" Text="*"/>
                                    <div class="expandibleDiv">
                                        <asp:TextBox ID="txtNacimiento" runat="server"  CssClass="form-control" TextMode="Date"/>
                                    </div>
                                </div>
                                <div class="form-group col-6">
                                    <span class="SEPSLabelConsulta">Género:</span>
                                    <asp:RequiredFieldValidator ID="rfvGenero" runat="server" CssClass="rightFloatAsterisk" Display="Dynamic" ToolTip="Seleccione un valor de la lista. Este campo es requerido." ErrorMessage="Género" ControlToValidate="ddlGenero" InitialValue="0" Text="*"/>
                                    <div class="expandibleDiv">
                                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlGenero"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-6">
                                    <span class="SEPSLabelConsulta">Grupo Étnico:</span>
                                    <asp:RequiredFieldValidator ID="rfvGrupoEtnico" runat="server" CssClass="rightFloatAsterisk" Display="Dynamic" ToolTip="Seleccione un valor de la lista. Este campo es requerido." ErrorMessage="Grupo Étnico" ControlToValidate="ddlGrupoEtnico" InitialValue="0" Text="*"/>
                                    <div class="expandibleDiv">
                                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlGrupoEtnico"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group col-6">
                                     <span class="SEPSLabelConsulta">Raza:</span>
                                    <div>
                                        <asp:ListBox runat="server" ID="lbxRaza" SelectionMode="Multiple" CssClass="form-control"></asp:ListBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="btn-group px-md-3 pt-3" role="group">
                                    <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-outline-info" Text="Registrar paciente" OnClick="btnRegistrar_Click"/>
                                    <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-outline-info" Text="Modificar paciente" OnClick="btnEditar_Click"/>
                                </div>
                            </div>
                        </div>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" HeaderText="Se han encontrado algunos errores en el formulario que debe revisar antes de registrar el expediente del paciente. Los siguientes campos son requeridos o contienen valores incorrectos:" ShowMessageBox="True" />
                    </div>
                </div>
            </div>
        </div>

</main>

<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-multiselect/0.9.15/css/bootstrap-multiselect.css" type="text/css" />

<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-multiselect/0.9.15/js/bootstrap-multiselect.js"></script>

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

    $(function () {
        $(<%=lbxRaza.ClientID%>).multiselect({
            enableCaseInsensitiveFiltering: true,
            buttonClass: 'form-control',
            buttonWidth: '100%'
        });
    });

</script>
</asp:Content>
