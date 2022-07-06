<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucExportarPlanificacion.ascx.cs" Inherits="CARA_Draftv0._1.App.wucExportarPlanificacion" %>

<div class="card">
    <div class="card-header">
        <div class="row">
            <h2>Filtros de Búsqueda</h2>
        </div>
        <div class="row">
            <div class="col-lg-1">

            </div>
            <div class="col-lg-10">
                <ul class="list-group list-group-horizontal">
                    <li class="list-group-item flex-fill">
                        <div class="row">
                            <h6 class="list-item">Fecha de Admisión</h6>
                        </div>
                        <div class="form-inline">
                            <span class="list-item">Desde:</span>
                            <asp:textbox runat="server" ID="txtFechaDesde" CssClass="form-control" TextMode="Date" />
                            <span class="list-item">Hasta:</span>
                            <asp:textbox runat="server" ID="txtFechaHasta" CssClass="form-control" TextMode="Date" />
                        </div>
                    </li>
                    <li class="list-group-item flex-fill">
                        <div class="row">
                            <span class="list-item">Centro de Servicio</span>
                        </div>
                        <div class="row">
                            <asp:ListBox runat="server" ID="lbxCentro" SelectionMode="Multiple" CssClass="form-control"></asp:ListBox>
                        </div>
                        <div class="row">
                            <br />
                        </div>
                        <div class="row">
                            <span class="list-item">Categoria de Episodio</span>
                        </div>
                        <div class="row">
                            <asp:ListBox runat="server" ID="lbxCategoria" SelectionMode="Multiple" CssClass="form-control">
                                <asp:ListItem Value="Salud Mental">Salud Mental</asp:ListItem>
                                <asp:ListItem Value="Sustancia">Sustancia</asp:ListItem>
                            </asp:ListBox>
                        </div>
                    </li>
                    <li class="list-group-item flex-fill">
                        <div class="row">
                            <span class="list-item">Fuente de Referido</span>
                        </div>
                        <div class="row">
                            <asp:ListBox runat="server" ID="lbxReferido" SelectionMode="Multiple" CssClass="form-control"></asp:ListBox>
                        </div>
                    </li>
                    <li class="list-group-item flex-fill">
                        <div class="row">
                            <span class="list-item">Municipios</span>
                        </div>
                        <div class="row">
                            <asp:ListBox runat="server" ID="lbxMunicipios" SelectionMode="Multiple" CssClass="form-control"></asp:ListBox>
                        </div>
                    </li>
                </ul>
            </div>
            <div class="col-lg-1">
                        
            </div>
        </div>
                


    </div>
    <div class="card-header">
        <div class="btn-toolbar justify-content-between" role="toolbar">
            <div class="btn-group" role="group" aria-label="Basic outlined example" >
                <asp:Button runat="server" Text="Actualizar Perfiles" OnClick="UpdatePerfiles" CssClass="btn btn-outline-primary" />
                </div>
            <div class="btn-group" role="group" aria-label="Basic outlined example" >
                <asp:Button runat="server" Text="EXCEL" OnClick="ExportToExcel" CssClass="btn btn-outline-secondary" />
                <asp:Button runat="server" Text="CSV" OnClick="ExportToExcel" CssClass="btn btn-outline-secondary" />
                <asp:Button runat="server" Text="PDF" OnClientClick="PrintDiv()" CssClass="btn btn-outline-secondary" />
                </div>
        </div>
                
        </div>
    <div class="card-body">
        <div class="table-responsive table-striped table-hover table-sm" id="divPerfilesDetailList">
                <asp:GridView runat="server" ID="gvPerfilesDetailList" CssClass="table table-bordered perfilesDetailListTable" Width="100%" AutoGenerateColumns="false" DataKeyNames="PK_Perfil">
                    <Columns>
                        <asp:BoundField DataField="PK_Perfil" HeaderText="ID Perfil" />
                        <asp:BoundField DataField="Centro" HeaderText="Nombre de Centro" />
                        <asp:BoundField DataField="Nombre_Licencia" HeaderText="Nombre de Licencia" />
                        <asp:BoundField DataField="Categoria" HeaderText="Categoria de Episodio" />
                        <asp:BoundField DataField="Fecha_Admisión" HeaderText="Fecha Admisión" />
                        <asp:BoundField DataField="ID_Paciente" HeaderText="ID Paciente" />
                        <asp:BoundField DataField="Dias_en_Espera" HeaderText="Dias en Espera" />
                        <asp:BoundField DataField="Arrestos_30_Dias" HeaderText="Arrestos 30 Dias" />
                        <asp:BoundField DataField="Fuente_Referido" HeaderText="Fuente Referido" />
                        <asp:BoundField DataField="Episodios_Previos" HeaderText="Episodios Previos" />
                        <asp:BoundField DataField="Grupo_de_Apoyo" HeaderText="Grupo de Apoyo" />
                        <asp:BoundField DataField="Genero" HeaderText="Genero" />
                        <asp:BoundField DataField="Estado_Marital" HeaderText="Estado Marital" />
                        <asp:BoundField DataField="Residencia" HeaderText="Residencia" />
                        <asp:BoundField DataField="Municipio" HeaderText="Municipio" />
                        <asp:BoundField DataField="Hijos_Menores" HeaderText="Hijos Menores" />
                        <asp:BoundField DataField="Embarazada" HeaderText="Embarazada" />
                        <asp:BoundField DataField="Veterano" HeaderText="Veterano" />
                        <asp:BoundField DataField="Escolaridad" HeaderText="Escolaridad" />
                        <asp:BoundField DataField="Condicion_Laboral" HeaderText="Condicion Laboral" />
                        <asp:BoundField DataField="Estudios" HeaderText="Estudios" />
                        <asp:BoundField DataField="Fuente_Ingreso" HeaderText="Fuente Ingreso" />
                        <asp:BoundField DataField="Droga_Primaria" HeaderText="Droga Primaria" />
                        <asp:BoundField DataField="Toxicologia_Primaria" HeaderText="Toxicologia Primaria" />
                        <asp:BoundField DataField="Via_Primaria" HeaderText="Via Primaria" />
                        <asp:BoundField DataField="Frecuencia_Primaria" HeaderText="Frecuencia Primaria" />
                        <asp:BoundField DataField="Edad_Primaria" HeaderText="Edad Primaria" />
                        <asp:BoundField DataField="Droga_Secundaria" HeaderText="Droga Secundaria" />
                        <asp:BoundField DataField="Toxicologia_Secundaria" HeaderText="Toxicologia Secundaria" />
                        <asp:BoundField DataField="Via_Secundaria" HeaderText="Via Secundaria" />
                        <asp:BoundField DataField="Frecuencia_Secundaria" HeaderText="Frecuencia Secundaria" />
                        <asp:BoundField DataField="Edad_Secundaria" HeaderText="Edad Secundaria" />
                        <asp:BoundField DataField="Droga_Terciaria" HeaderText="Droga Terciaria" />
                        <asp:BoundField DataField="Toxicologia_Secundaria" HeaderText="Toxicologia Terciaria" />
                        <asp:BoundField DataField="Via_Terciaria" HeaderText="Via Terciaria" />
                        <asp:BoundField DataField="Frecuencia_Terciaria" HeaderText="Frecuencia Terciaria" />
                        <asp:BoundField DataField="Edad_Terciaria" HeaderText="Edad Terciaria" />
                        <asp:BoundField DataField="Droga_Cuarta" HeaderText="Droga Cuarta" />
                        <asp:BoundField DataField="Toxicologia_Cuarta" HeaderText="Toxicologia Cuarta" />
                        <asp:BoundField DataField="Via_Cuarta" HeaderText="Via Terciaria" />
                        <asp:BoundField DataField="Frecuencia_Cuarta" HeaderText="Frecuencia Cuarta" />
                        <asp:BoundField DataField="Edad_Cuarta" HeaderText="Edad Cuarta" />
                        <asp:BoundField DataField="Droga_Quinta" HeaderText="Droga Quinta" />
                        <asp:BoundField DataField="Toxicologia_Quinta" HeaderText="Toxicologia Quinta" />
                        <asp:BoundField DataField="Via_Quinta" HeaderText="Via Quinta" />
                        <asp:BoundField DataField="Frecuencia_Quinta" HeaderText="Frecuencia Quinta" />
                        <asp:BoundField DataField="Edad_Quinta" HeaderText="Edad Quinta" />
                        <asp:BoundField DataField="Evento_Sobredosis" HeaderText="Evento Sobredosis" />
                        <asp:BoundField DataField="Sobredosis_Primaria" HeaderText="Sobredosis Primaria" />
                        <asp:BoundField DataField="Sobredosis_Secundaria" HeaderText="Sobredosis Secundaria" />
                        <asp:BoundField DataField="Sobredosis_Terciaria" HeaderText="Sobredosis Terciaria" />
                        <asp:BoundField DataField="Sobredosis_Cuarta" HeaderText="Sobredosis Cuarta" />
                        <asp:BoundField DataField="ICDX_Primaria" HeaderText="ICDX Primaria" />
                        <asp:BoundField DataField="ICDX_Secundaria" HeaderText="ICDX Secundaria" />
                        <asp:BoundField DataField="ICDX_Terciaria" HeaderText="ICDX Terciaria" />
                        <asp:BoundField DataField="ICDX_Cuarta" HeaderText="ICDX Cuarta" />
                        <asp:BoundField DataField="DSMV_Primaria" HeaderText="DSMV Primaria" />
                        <asp:BoundField DataField="DSMV_Secundaria" HeaderText="DSMV Secundaria" />
                        <asp:BoundField DataField="DSMV_Terciaria" HeaderText="DSMV Terciaria" />
                        <asp:BoundField DataField="DSMV_Cuarta" HeaderText="DSMV Cuarta" />
                        <asp:BoundField DataField="Condicion_Primaria" HeaderText="Condicion Primaria" />
                        <asp:BoundField DataField="Condicion_Secundaria" HeaderText="Condicion Secundaria" />
                        <asp:BoundField DataField="Condicion_Terciaria" HeaderText="Condicion Terciaria" />
                        <asp:BoundField DataField="Condicion_Cuarta" HeaderText="Condicion Cuarta" />
                        <asp:BoundField DataField="Nivel_Cuidado" HeaderText="Nivel Cuidado" />
                        <asp:BoundField DataField="Seguro_Salud" HeaderText="Seguro Salud" />
                    </Columns>
                    <EmptyDataTemplate>
                        No existen perfiles con los filtros escogidos.
                    </EmptyDataTemplate>
                    <%--<i class='fas fa-fw fa-trash-alt'></i>--%>
                </asp:GridView>
            </div>
        </div>
    </div>

<script>

    function PrintDiv() {
        var d = new Date();
        var divContents = document.getElementById("divPerfilesDetailList").innerHTML;

        var printWindow = window.open();
        printWindow.document.write('<html><head>');
        printWindow.document.write('</head><body style="font-family:courier;"><style>h2 {text-align: center;} a {text-decoration:none; color:black;}  table { font-size: 12px; width:100%; border-collapse:collapse; } table, td, th { border: 1px solid black;}</style>');
        printWindow.document.write('<h2>Extracción de mi Perfiles</h2>');
        printWindow.document.write('<p>Fecha: ' + '' + '</p>');
        printWindow.document.write('</br>');
        printWindow.document.write(divContents);
        printWindow.document.write('</body></html>');
        printWindow.document.close();
        printWindow.print();
    }  
</script>