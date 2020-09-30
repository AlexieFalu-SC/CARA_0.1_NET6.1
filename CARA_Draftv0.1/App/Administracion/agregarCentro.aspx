<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="agregarCentro.aspx.cs" Inherits="CARA_Draftv0._1.App.Administracion.agregarCentro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-md-4">
    <div id="RegistroCentroBox" runat="server">

        <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-5 border-bottom">
            <h1 class="h2">Agregar Centro</h1>
            <div class="btn-toolbar mb-2 mb-md-0">
              <div class="btn-group mr-2">
                <button type="button" class="btn btn-sm btn-outline-secondary">Compartir</button>
                <button type="button" class="btn btn-sm btn-outline-secondary" onclick="javascript:window.print();">Imprimir</button>
               </div>
             </div>
        </div>

        <div class="d-flex justify-content-center mb-4">
            <p class="text-danger"><asp:Literal runat="server" ID="ErrorMessage" /></p>

            <div class="card">
                <div class="card-header text-center">Nuevo Centro</div>
                
                <div class="card-body">
                    <div class="form">
                        <asp:ValidationSummary runat="server" CssClass="text-danger" />
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label runat="server" AssociatedControlID="txtNB_Centro" CssClass="col-md-12 control-label">Nombre de Centro</asp:Label>
                                <div class="col-md-12">
                                    <asp:TextBox runat="server" ID="txtNB_Centro" CssClass="form-control" MaxLength="99" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNB_Centro" CssClass="text-danger" ErrorMessage="El campo de nombre es requerido." />
                                </div>
                            </div>
                            <div class="form-group col-md-6">
                                <asp:Label runat="server" AssociatedControlID="txtSLYC" CssClass="col-md-12 control-label">ID SLYC</asp:Label>
                                <div class="col-md-12">
                                    <asp:TextBox runat="server" ID="txtSLYC" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtSLYC" CssClass="text-danger" ErrorMessage="El campo de ID SLYC es requerido." />
                                </div>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label runat="server" AssociatedControlID="txtProveedor" CssClass="col-md-12 control-label">ID Proveedor</asp:Label>
                                <div class="col-md-12">
                                    <asp:TextBox runat="server" ID="txtProveedor" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtProveedor" CssClass="text-danger" ErrorMessage="El identificador de proveedor es requerido." />
                                </div>
                            </div>
                            <div class="form-group col-md-6">
                                <asp:Label runat="server" AssociatedControlID="ddlEmail" CssClass="col-md-12 control-label">Email de Registrado</asp:Label>
                                <div class="col-md-12">
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEmail"></asp:DropDownList>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlEmail" InitialValue="0" CssClass="text-danger" ToolTip="Seleccione un valor de la lista. Este campo es requerido." ErrorMessage="Email de Registrado." />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button runat="server" Text="Registar Centro" OnClick="BtnRegistrar_Click" CssClass="btn btn-outline-secondary" />
                            </div>
                        </div>

                    </div>

          </div>
          <div class="card-footer text-muted text-center">
        Registro de Nuevo Centro
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
