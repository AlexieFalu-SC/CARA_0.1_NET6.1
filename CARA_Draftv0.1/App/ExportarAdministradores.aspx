<%@ Page Title=" | Exportar Perfiles" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="ExportarAdministradores.aspx.cs" Inherits="CARA_Draftv0._1.App.ExportarAdministradores" %>

<%@ Register Src="~/App/wucExportarPlanificacion.ascx" TagPrefix="uc1" TagName="wucExportarPlanificacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>

    <header class="page-header page-header-compact page-header-light border-bottom bg-white mb-4">
            <div class="container-fluid px-4">
                <div class="page-header-content">
                    <div class="row align-items-center justify-content-between pt-3">
                        <div class="col-auto mb-3">
                            <h3 class="page-header-title">
                                <div class="page-header-icon">
                                    <i class="fas fa-fw fa-chart-pie"></i>
                                    Exportar Perfiles
                                </div>

                            </h3>
                        </div>
                        <div class="col-auto">
                            <ul class="nav nav-tabs" id="myTab" role="tablist">
                                <li class="nav-item" role="presentation">
                                <a class="nav-link active" id="ssrs-tab" data-toggle="tab" href="#ssrs" role="tab" aria-controls="ssrs" aria-selected="false">PERFILES</a>
                                </li>
                                <li class="nav-item" role="presentation">
                                <a class="nav-link" id="ssrs-plan-tab" data-toggle="tab" href="#ssrs-plan" role="tab" aria-controls="ssrs-plan" aria-selected="false">DETALLES DE PERFILES</a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </header>

     <div class="container-xl px-4 mt-4">
        

                <div class="tab-content" id="myTabContent">
                    <div class="tab-pane fade show active" id="ssrs" role="tabpanel" aria-labelledby="plan-tab">
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
                                    <div class="table-responsive table-striped table-hover table-sm" id="divPerfilesList">
                                            <asp:GridView runat="server" ID="gvPerfilesList" CssClass="table table-bordered perfilesListTable" Width="100%" AutoGenerateColumns="false" DataKeyNames="PK_Perfil">
                                                <Columns>
                                                    <asp:BoundField DataField="PK_Perfil" HeaderText="ID Perfil" />
                                                    <asp:BoundField DataField="Centro" HeaderText="Nombre de Centro" />
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
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    No existen perfiles con los filtros escogidos.
                                                </EmptyDataTemplate>
                                                <%--<i class='fas fa-fw fa-trash-alt'></i>--%>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                    </div>

                    <div class="tab-pane fade" id="ssrs-plan" role="tabpanel" aria-labelledby="plan-tab">
                            <uc1:wucExportarPlanificacion runat="server" id="wucExportarPlanificacion" />
                    </div>
                </div>

            
     </div>

    </main>

    <script>

    function PrintDiv() {
        var d = new Date();
        var divContents = document.getElementById("divPerfilesList").innerHTML;

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
</asp:Content>
