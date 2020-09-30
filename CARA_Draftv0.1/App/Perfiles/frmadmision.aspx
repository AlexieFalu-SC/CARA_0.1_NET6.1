<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="frmadmision.aspx.cs" Inherits="CARA_Draftv0._1.App.Perfiles.frmadmision" %>

<%@ Register Src="~/App/Perfiles/wucdatospersonales.ascx" TagPrefix="uc1" TagName="wucdatospersonales" %>
<%@ Register Src="~/App/Perfiles/wucperfiladmision.ascx" TagPrefix="uc1" TagName="wucperfiladmision" %>
<%@ Register Src="~/App/Perfiles/wucdrogasadmision.ascx" TagPrefix="uc1" TagName="wucdrogasadmision" %>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-md-4">
    <div id="AdmisionBox" runat="server">
        <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
            <h1 class="h2">Admisión</h1>
            <div class="btn-toolbar mb-2 mb-md-0">
              <div class="btn-group mr-2">
                <button type="button" class="btn btn-sm btn-outline-secondary">Compartir</button>
            <button type="button" class="btn btn-sm btn-outline-secondary" onclick="javascript:window.print();">Imprimir</button>
              </div>
            </div>
          </div>
        
        <div>
            <uc1:wucdatospersonales runat="server" id="wucdatospersonales" />
            <uc1:wucperfiladmision runat="server" ID="wucperfiladmision" />
            <uc1:wucdrogasadmision runat="server" id="wucdrogasadmision" />
            <div class="btn-group pt-3 mr-2 mb-4" role="group">
                <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-sm btn-outline-secondary" Text="Registrar perfil de admisión" CausesValidation="false" OnClientClick="return validate();" OnClick="btnRegistrar_Click"/>
                <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-sm btn-outline-secondary" Text="Modificar perfil de admisión" CausesValidation="false" OnClientClick="return validate();" OnClick="btnModificar_Click"/>
                <asp:Button ID="btnRegistrarModificar" runat="server" CssClass="btn btn-sm btn-outline-secondary" Text="Registrar modificación de admisión" OnClick="btnRegistrarModificar_Click"/>
            </div>
        </div> 
        
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" HeaderText="Se han encontrado algunos errores en el formulario que debe revisar antes de registrar el expediente del paciente. Los siguientes campos son requeridos o contienen valores incorrectos:" ShowMessageBox="True" />
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
