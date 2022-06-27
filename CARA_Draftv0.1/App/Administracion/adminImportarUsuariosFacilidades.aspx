<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="adminImportarUsuariosFacilidades.aspx.cs" Inherits="CARA_Draftv0._1.App.Administracion.adminImportarUsuariosFacilidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .file-drop-area {
  position: relative;
  display: flex;
  align-items: center;
  width: 450px;
  max-width: 100%;
  padding: 25px;
  border: 1px dashed red;
  border-radius: 3px;
  transition: 0.2s;
 
}

.choose-file-button {
  flex-shrink: 0;
  background-color: rgba(255, 255, 255, 0.04);
  border: 1px solid rgba(255, 255, 255, 0.1);
  border-radius: 3px;
  padding: 8px 15px;
  margin-right: 10px;
  font-size: 12px;
  text-transform: uppercase;
}

.file-message {
  font-size: small;
  font-weight: 300;
  line-height: 1.4;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}

.file-input {
  position: absolute;
  left: 0;
  top: 0;
  height: 100%;
  width: 100%;
  cursor: pointer;
  opacity: 0;
  
}

.mt-100{
    margin-top:100px;
}
    </style>
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
                                <i class="fas fa-fw fa-user-edit"></i><span> Importar Cuentas Principales y Facilidades (REGISTRADOS)</span>
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

    <div class="container-fluid px-4">
        <div class="row justify-content-center">
            <div class="col-xl-6 align-self-center">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <div class="text-center">
                                    <h3 class="page-header-title">
                                        <div class="page-header-icon">
                                        </div>
                                    </h3>
                                    <div style="text-align:center" class="small font-italic text-muted mb-4"><span>Aqui puede importar nuevas cuentas principales de registrados y su primera facilidad atada, utilizando un documento EXCEL (.xslx). Puede <a href="<%=ResolveClientUrl("~/Documents/ImportarUsuarios_Ejemplo.xlsx")%>"><span>descargar este ejemplo</span></a> , el cual indica el formato del documento el cual debe contener dies (10) columnas con exactamente el formato indicado el ejemplo.</span></div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="text-center">
                                    <h3 class="page-header-title">
                                        <div class="page-header-icon">
                                        <i id="upIcon" class="fas fa-fw fa-upload"></i>
                                        </div>
                                    </h3>
                                    <div style="text-align:center" class="small font-italic text-muted mb-4"><span id="docName">Importar Documento Excel</span></div>
                                    <input type="button" class="file-input"  onclick="uploadFile()"/>
                                </div>
                            </div>
                        </div>
                        <div class="row" runat="server" ID="btnUpload" style="display:none">
                            <div class="col">
                                <div class="text-center">
                                    <asp:Button Text="Pre-Agregar Transacciones"  CssClass="btn btn-link" OnClick="Upload" OnClientClick="divShow();" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row" runat="server" ID="btnRegistrar" visible="false">
                            <div class="col">
                                <div class="text-center">
                                    <asp:Button Text="Confirmar Registro"  CssClass="btn btn-link" OnClick="btnRegistrar_Click" OnClientClick="divShow();" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <asp:FileUpload ID="FileUpload1" style="display: none" OnChange="uploadChange()" runat="server" />

        </div>
        
        <br />

        <div class="row" runat="server" id="divExcel" visible="false">
            <div class="card">
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered usuariosExternosListTable" Width="100%">
                        </asp:GridView>
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

    function uploadFile() {
        document.getElementById("<%=FileUpload1.ClientID%>").click();
    }

    function uploadChange() {
        document.getElementById("docName").textContent = document.getElementById("<%=FileUpload1.ClientID%>").value;
        document.getElementById("<%=btnUpload.ClientID%>").style.display = "contents";
        document.getElementById("upIcon").className = "fas fa-fw fa-file-excel";
    }
</script>
</asp:Content>
