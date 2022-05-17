<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="frmadmision.aspx.cs" Inherits="CARA_Draftv0._1.App.Perfiles.frmadmision" %>

<%@ Register Src="~/App/Perfiles/wucdatospersonales.ascx" TagPrefix="uc1" TagName="wucdatospersonales" %>
<%@ Register Src="~/App/Perfiles/wucperfiladmision.ascx" TagPrefix="uc1" TagName="wucperfiladmision" %>
<%@ Register Src="~/App/Perfiles/wucdrogasadmision.ascx" TagPrefix="uc1" TagName="wucdrogasadmision" %>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <main id="divPerfil">

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
                                    <i class="fas fa-fw fa-file"></i><span> Registro de Admisión</span>
                                </div>
                            </h3>
                        </div>
                        <div class="col-auto">
                            <div class="btn-group mr-2">
                                <button type="button" class="btn btn-sm btn-outline-secondary" onclick="PrintDiv();">Imprimir</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </header>

    <div id="AdmisionBox" runat="server" class="container-xl px-4">
        
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

        function PrintDiv() {
            var divContents = document.getElementById("divPerfil").innerHTML;

            var printWindow = window.open();
            printWindow.document.write('<html><head>');
            printWindow.document.write('<link href="~/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">');
            printWindow.document.write('<link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">');
            printWindow.document.write('<link href="<%=ResolveClientUrl("~/Content/css/sb-admin-2.min.css")%>" type="text/css" rel="stylesheet" />');
            printWindow.document.write('<link href="<%=ResolveClientUrl("~/vendor/datatables/dataTables.bootstrap4.min.css")%>" type="text/css" rel="stylesheet" />');
            printWindow.document.write('</head><body >');
            printWindow.document.write(divContents);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            printWindow.print();
        }
        function printPartOfPage(strid) {
            var printContent = strid;

            var windowUrl = "about:blank";
            var uniqueName = new Date();
            var windowName = 'Print' + uniqueName.getTime();
            var printWindow = window.open(windowUrl, windowName, 'left=50000,top=50000,width=0,height=0');

            printWindow.document.write(printContent.innerHTML);
            printWindow.document.close();
            printWindow.focus();
            printWindow.print();
            printWindow.close();
        }
    </script>

    
</asp:Content>
