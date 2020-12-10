<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="AnaliticaAdministradores.aspx.cs" Inherits="CARA_Draftv0._1.App.AnaliticaAdministradores" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-md-3">
      <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
        <%--<h1 class="h2">Tablero Principal</h1>
        <div class="btn-toolbar mb-2 mb-md-0">
          <div class="btn-group mr-2">
            <button type="button" class="btn btn-sm btn-outline-secondary">Compartir</button>
            <button type="button" class="btn btn-sm btn-outline-secondary" onclick="javascript:window.print();">Imprimir</button>
          </div>
        </div>--%>

            <h1 class="h2">Tableros Analíticos</h1>
            <ul class="nav nav-tabs" id="myTab" role="tablist">
                <li class="nav-item" role="presentation">
                <a class="nav-link active" id="cara-tab" data-toggle="tab" href="#cara" role="tab" aria-controls="cara" aria-selected="true">CARA</a>
                </li>
                <li class="nav-item" role="presentation">
                <a class="nav-link" id="plan-tab" data-toggle="tab" href="#plan" role="tab" aria-controls="plan" aria-selected="false">PLANIFICACIÓN</a>
                </li>
                <li class="nav-item" role="presentation">
                <a class="nav-link" id="perfiles-tab" data-toggle="tab" href="#perfiles" role="tab" aria-controls="perfiles" aria-selected="false">PERFILES</a>
                </li>
                <li class="nav-item" role="presentation">
                <a class="nav-link" id="ssrs-tab" data-toggle="tab" href="#ssrs" role="tab" aria-controls="ssrs" aria-selected="false">SSRS</a>
                </li>
            </ul>
      </div>

        <div class="container-fluid">
            
                
                

                <div class="tab-content" id="myTabContent">

                    <div class="tab-pane fade show active" id="cara" role="tabpanel" aria-labelledby="cara-tab">
                                <div class="row">
                                    <div class="col-md-3 col-lg-2 px-md-0">
                                        <ul class="list-group">
                                          <li class="list-group-item">
                                              <div class="row">
                                                   <h6 class="list-item">Fecha de Admisión</h6>
                                              </div>
                                              <div class="row">
                                                  <span class="list-item">Desde</span>
                                                  <asp:textbox runat="server" ID="txtFechaDesde" CssClass="form-control" TextMode="Date" onChange="changeFecha();"/>
                                                  <span class="list-item">Hasta</span>
                                                  <asp:textbox runat="server" ID="txtFechaHasta" CssClass="form-control" TextMode="Date" onChange="changeFecha();"/>
                                              </div>
                          
                                          </li>
                                          <li class="list-group-item">
                                              <div class="row">
                                                   <h6 class="list-item">Centro de Servicio</h6>
                                              </div>
                                              <div class="row">
                                                  <asp:ListBox runat="server" ID="lbxCentro" SelectionMode="Multiple" onChange="changeFecha();" CssClass="form-control">
                                              </asp:ListBox>
                                              </div>
                                          </li>
                                          <li class="list-group-item">
                                              <div class="row">
                                                   <h6 class="list-item">Género</h6>
                                              </div>
                                              <div class="row">
                                                  <asp:ListBox runat="server" ID="lbxGenero" SelectionMode="Multiple" CssClass="form-control" onChange="changeFecha();"></asp:ListBox>
                                              </div>
                                          </li>
                                          <li class="list-group-item">
                                              <div class="row">
                                                   <h6 class="list-item">Nivel de Cuidado</h6>
                                              </div>
                                              <div class="row">
                                                  <asp:ListBox ID="lbxNivelSustancia" runat="server" SelectionMode="Multiple" onChange="changeFecha();" CssClass="form-control"></asp:ListBox>
                                              </div>
                                          </li>

                        

                                        </ul>
                                    </div>

                             <div class="col-md-9 ml-sm-auto col-lg-10 px-md-3">

                            <div class="row">

                                <div class="col-xl-3 col-md-6 mb-4">
                                  <div class="card border-left-info shadow h-100 py-2">
                                    <div class="card-body">
                                      <div class="row no-gutters align-items-center">
                                        <div class="col mr-2">
                                          <div class="text-xs font-weight-bold text-info text-uppercase mb-1" style="text-align:center">Total de Perfiles</div>
                                          <div class="h5 mb-0 font-weight-bold text-gray-800" style="text-align:center" id="totalPerfiles"></div>
                                        </div>
                                        <div class="col-auto">
                                          <i class="fas fa-calendar fa-2x text-gray-300"></i>
                                        </div>
                                      </div>
                                    </div>
                                  </div>
                                </div>

                                <div class="col-xl-3 col-md-6 mb-4">
                                    <div class="card border-left-info shadow h-100 py-2">
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col">
                                                    <div class="text-xs font-weight-bold text-info text-uppercase mb-1" style="text-align:center">Total de Referidos CARA</div>
                                                    <div class="h5 mb-0 font-weight-bold text-gray-800" style="text-align:center" id="totalReferidosCara"></div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>

                                <div class="col-xl-3 col-md-6 mb-4">
                                  <div class="card border-left-info shadow h-100 py-2">
                                    <div class="card-body">
                                      <div class="row no-gutters align-items-center">
                                        <div class="col">
                                          <div class="text-xs font-weight-bold text-info text-uppercase mb-1" style="text-align:center">Género</div>
                                          <div class="row no-gutters align-items-center">
                                            <div class="col-auto">
                                              <div class="h6 mb-0 mr-3 font-weight-bold text-gray-800">Masculino</div>
                                            </div>
                                            <div class="col">
                                              <div class="progress progress-sm mr-2">
                                                <div class="progress-bar bg-info" role="progressbar" id="perMasculino" aria-valuemin="0" aria-valuemax="100"></div>
                                              </div>
                                            </div>
                                              <div class="col">
                                                  <div class="font-weight-bold" id="totalMasculino"></div>
                                              </div>
                                          </div>
                                            <div class="row no-gutters align-items-center">
                                            <div class="col-auto">
                                              <div class="h6 mb-0 mr-3 font-weight-bold text-gray-800">Femenino</div>
                                            </div>
                                            <div class="col">
                                              <div class="progress progress-sm mr-2">
                                                <div class="progress-bar bg-info" role="progressbar" id="perFemenino" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                                              </div>
                                            </div>
                                              <div class="col">
                                                  <div class="font-weight-bold" id="totalFemenino"></div>
                                              </div>
                                          </div>
                                        </div>
                                      </div>
                                    </div>
                                  </div>
                                </div>

                                <div class="col-xl-3 col-md-6 mb-4">
                                    <div class="card border-left-info shadow h-100 py-2">
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col">
                                                    <div class="text-xs font-weight-bold text-info text-uppercase mb-1" style="text-align:center">Edad Promedio</div>
                                                    <div class="h5 mb-0 font-weight-bold text-gray-800" style="text-align:center" id="edadPromedioCara"></div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>

                            </div>
                           <%-- <div class="my-4 w-50" id="curve_chart" style="width: 500px; height: 380px; float:left"></div>--%>
                           <%-- <div class="my-4 w-50" id="curve_chart2" style="width: 500px; height: 380px; float:right"></div>--%>
                           <%-- <div class="my-4 w-50" id="curve_chart3" style="width: 500px; height: 380px; float:left"></div>--%>
    
                            <div class="row">

                                <!-- Chart: Fuente de Referidos Principales -->
                                <div class="col-lg-6 mb-2">
                                  <div class="card shadow mb-4">
                                    <!-- Card Header - Dropdown -->
                                    <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                                      <h6 class="m-0 font-weight-bold text-primary">Fuente de Referidos Principales</h6>
                                    </div>
                                    <!-- Card Body -->
                                    <div class="card-body">
                                      <div class="chart-area">
                                         <div id="referido_chart" style="height: 250px"></div>
                                      </div>
                                    </div>
                                  </div>
                                </div>

                                <!-- Chart: Fuente de Referidos Principales -->
                                <div class="col-lg-6 mb-2">
                                  <div class="card shadow mb-4">
                                    <!-- Card Header - Dropdown -->
                                    <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                                      <h6 class="m-0 font-weight-bold text-primary">Drogas de Uso</h6>
                                    </div>
                                    <!-- Card Body -->
                                    <div class="card-body">
                                      <div class="chart-area">
                                         <div id="drogas_chart" style="height: 250px"></div>
                                      </div>
                                    </div>
                                  </div>
                                </div>

                              </div>

                            <div class="row">

                                <!-- Chart: Perfiles por Centro -->
                                <div class="col-lg-6 mb-2">
                                  <div class="card shadow mb-4">
                                    <!-- Card Header - Dropdown -->
                                    <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                                      <h6 class="m-0 font-weight-bold text-primary">Eventos de Sobredosis</h6>
                                    </div>
                                    <!-- Card Body -->
                                    <div class="card-body">
                                      <div class="chart-area" id="dashboard_div">
                                         <div style="height: 250px">
                                             <div class="row">
                                                 <div class="col-md-6">
                                                     <div id="sobredosis_chart"></div>
                                                 </div>
                                                 <div class="col-md-6">
                                                     <div id="drogaSobredosis_chart"></div>
                                                 </div>
                                             </div>
                         
                                         </div>
                                      </div>
                                    </div>
                                  </div>
                                </div>

                                <!-- Chart: Perfiles por Centro -->
                                <div class="col-lg-6 mb-2">
                                  <div class="card shadow mb-4">
                                    <!-- Card Header - Dropdown -->
                                    <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                                      <h6 class="m-0 font-weight-bold text-primary">Niveles de Cuidado</h6>
                                    </div>
                                    <!-- Card Body -->
                                    <div class="card-body">
                                      <div class="chart-area">
                                         <div id="nivelCuidado_div" style="height: 250px"></div>
                                      </div>
                                    </div>
                                  </div>
                                </div>

                              </div>

                            </div>

                        </div>
                    </div>

                    <div class="tab-pane fade" id="plan" role="tabpanel" aria-labelledby="plan-tab">

                    </div>

                    <div class="tab-pane fade" id="perfiles" role="tabpanel" aria-labelledby="perfiles-tab">
                        <div class="row">
                            <div class="col-md-3 col-lg-2 px-md-0">
                                <ul class="list-group">
                                    <li class="list-group-item">
                                        <div class="row">
                                            <h6 class="list-item">Fecha de Admisión</h6>
                                        </div>
                                        <div class="row">
                                            <span class="list-item">Desde</span>
                                            <asp:textbox runat="server" ID="txtPerfilesDesde" CssClass="form-control" onChange="changeFechaPerfiles();" TextMode="Date"/>
                                            <span class="list-item">Hasta</span>
                                            <asp:textbox runat="server" ID="txtPerfilesHasta" CssClass="form-control" onChange="changeFechaPerfiles();" TextMode="Date"/>
                                        </div>
                                    </li>
                                    <li class="list-group-item">
                                        <div class="row">
                                            <h6 class="list-item">Centro de Servicio</h6>
                                        </div>
                                        <div class="row">
                                            <asp:ListBox runat="server" ID="lbxCentroPerfiles" SelectionMode="Multiple" onChange="changeFechaPerfiles();" CssClass="form-control">
                                        </asp:ListBox>
                                        </div>
                                    </li>
                                    <li class="list-group-item">
                                        <div class="row">
                                            <h6 class="list-item">Perfiles para Descargar</h6>
                                        </div>
                                        <div class="row">
                                             <button id="btnDescargar" class="form-control" onclick="descargarPerfil();">Descargar</button>
                                        </div>
                                    </li>
                                </ul>
                            </div>

                            <div class="col-md-9 ml-sm-auto col-lg-10 px-md-3">
                                <div class="col-lg-12 mb-2">
                                    <div class="card shadow mb-4">
                                    <!-- Card Header - Dropdown -->
                                    <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                                        <h6 class="m-0 font-weight-bold text-primary">Perfiles</h6>
                                    </div>
                                    <!-- Card Body -->
                                    <div class="card-body">
                                        <div class="chart-area">
                                            
                                            <div id="perfiles_table"></div>
                                        </div>
                                    </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>

                    <div class="tab-pane fade" id="ssrs" role="tabpanel" aria-labelledby="plan-tab">
                            <div class="card shadow mb-4">
                                <!-- Card Header - Dropdown -->
                                    <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                                        <h6 class="m-0 font-weight-bold text-primary">Perfiles</h6>
                                    </div>
                                    <!-- Card Body -->
                                    <div class="card-body">
                                        <div class="chart-area">
                                          <%--  <rsweb:ReportViewer ID="rvAnaliticaAdministradores" runat ="server" ShowPrintButton="false"  Width="99.9%" Height="100%" AsyncRendering="true" ZoomMode="Percent" KeepSessionAlive="true" SizeToReportContent="false"></rsweb:ReportViewer>--%>
                                        </div>
                                    </div>
                            </div>
                    </div>


                </div>


</div>

</main>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>

    <script type="text/javascript">
        var dtDesde, dtHasta, ajax_data, dtTotalPerfiles, dtTotalReferidosCara, dtTotalMasculino, dtPerMasculino, dtTotalFemenino, dtPerFemenino, dtEdadPromedio, dtFuenteReferido, dtNivelCuidado, dtDrogasUso, dtSobredosis, dtDrogaSobredosis, dtPerfiles;
        var generos = [], niveles = [], centros = [], centroPerfiles = [];
        var perfiles_data, perfiles_desde, perfiles_hasta;

        google.charts.load('current', { 'packages': ['line', 'bar', 'corechart', 'controls', 'table'] });
       
        $(document).ready(function () {
            dtDesde = document.getElementById("<%=txtFechaDesde.ClientID %>").value;
            dtHasta = document.getElementById("<%=txtFechaHasta.ClientID %>").value;

            perfiles_desde = document.getElementById("<%=txtPerfilesDesde.ClientID %>").value;
            perfiles_hasta = document.getElementById("<%=txtPerfilesHasta.ClientID %>").value;

            listGenero();

            listNivelCuidado();

            listCentro();

            listCentroPerfiles();

            ajax_data = '{Desde:"' + dtDesde + '", Hasta:"' + dtHasta + '", gen:' + JSON.stringify(generos) + ', Niveles:' + JSON.stringify(niveles) + ', Centros:' + JSON.stringify(centros) + '}'

            wsTotalPerfiles();

            wsFuenteReferido();

            wsNivelCuidado();

            wsSobredosis();

            wsDrogaSobredosis();

            wsDrogaUso();

            perfiles_data = '{Desde:"' + perfiles_desde + '", Hasta:"' + perfiles_hasta + '", Centros:' + JSON.stringify(centrosPerfiles) + '}'

            wsPerfiles();

        });


        function wsTotalPerfiles() {

            $.ajax({
                url: "WebMethods/wsRegistradoTablero.asmx/dashCaraTotalPerfiles",
                data: ajax_data,
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var mydata = data.d;
                    dtTotalPerfiles = mydata.totalPerfiles;
                    dtTotalReferidosCara = mydata.totalReferidosCara;
                    dtTotalMasculino = mydata.totalMasculino;
                    dtTotalFemenino = mydata.totalFemenino;
                    dtPerMasculino = mydata.perMasculino;
                    dtPerFemenino = mydata.perFemenino;
                    dtEdadPromedio = mydata.edadPromedio;
                },
                error: function () {
                    alert("Error");
                }
            }).done(function () {
                $("#totalPerfiles").html(dtTotalPerfiles);
                $("#totalReferidosCara").html(dtTotalReferidosCara);
                $("#totalMasculino").html(dtTotalMasculino);
                $("#totalFemenino").html(dtTotalFemenino);
                $("#edadPromedioCara").html(dtEdadPromedio);

                document.getElementById('perMasculino').setAttribute("style", "width:" + dtPerMasculino + "%");
                document.getElementById('perFemenino').setAttribute("style", "width:" + dtPerFemenino + "%");
            });
        }

        function wsFuenteReferido() {
            $.ajax({
                url: "WebMethods/wsRegistradoTablero.asmx/dashCaraFuenteReferido",
                data: ajax_data,
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    dtFuenteReferido = data.d;
                },
                error: function () {
                    alert("Error");
                }
            }).done(function () {
                google.charts.setOnLoadCallback(fuenteReferido);
            });
        }

        function wsSobredosis() {
            $.ajax({
                url: "WebMethods/wsRegistradoTablero.asmx/dashCaraSobredosis",
                data: ajax_data,
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    dtSobredosis = data.d;
                },
                error: function () {
                    alert("Error");
                }
            }).done(function () {
                google.charts.setOnLoadCallback(sobredosis);
            });
        }

        function wsDrogaSobredosis() {
            $.ajax({
                url: "WebMethods/wsRegistradoTablero.asmx/dashCaraDrogaSobredosis",
                data: ajax_data,
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    dtDrogaSobredosis = data.d;
                },
                error: function () {
                    alert("Error");
                }
            }).done(function () {
                google.charts.setOnLoadCallback(drogaSobredosis);
            });
        }

        function wsNivelCuidado() {
            $.ajax({
                url: "WebMethods/wsRegistradoTablero.asmx/dashCaraNivelCuidado",
                data: ajax_data,
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    dtNivelCuidado = data.d;
                },
                error: function () {
                    alert("Error");
                }
            }).done(function () {
                google.charts.setOnLoadCallback(nivelCuidado);
            });
        }

        function wsDrogaUso() {
            $.ajax({
                url: "WebMethods/wsRegistradoTablero.asmx/dashCaraDrogasUso",
                data: ajax_data,
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    dtDrogasUso = data.d;
                },
                error: function () {
                    alert("Error");
                }
            }).done(function () {
                google.charts.setOnLoadCallback(drogasUso);
            });
        }

        function wsPerfiles() {
            $.ajax({
                url: "WebMethods/wsRegistradoTablero.asmx/dashPerfiles",
                data: perfiles_data,
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    dtPerfiles = data.d;
                },
                error: function () {
                    alert("Error");
                }
            }).done(function () {
                google.charts.setOnLoadCallback(perfiles);
            });
        }

        function changeFechaPerfiles() {
            perfiles_desde = document.getElementById("<%=txtPerfilesDesde.ClientID %>").value;
            perfiles_hasta = document.getElementById("<%=txtPerfilesHasta.ClientID %>").value;

            listCentroPerfiles();

            perfiles_data = '{Desde:"' + perfiles_desde + '", Hasta:"' + perfiles_hasta + '", Centros:' + JSON.stringify(centrosPerfiles) + '}'

            wsPerfiles();
        }

        function changeFecha() {
            dtDesde = document.getElementById("<%=txtFechaDesde.ClientID %>").value;
            dtHasta = document.getElementById("<%=txtFechaHasta.ClientID %>").value;

            listGenero();

            listNivelCuidado();

            listCentro();

            ajax_data = '{Desde:"' + dtDesde + '", Hasta:"' + dtHasta + '", gen:' + JSON.stringify(generos) + ', Niveles:' + JSON.stringify(niveles) + ', Centros:' + JSON.stringify(centros) +'}'

            wsTotalPerfiles();

            wsFuenteReferido();

            wsNivelCuidado();

            wsSobredosis();

            wsDrogaSobredosis();

            wsDrogaUso();
        }

        function listGenero() {
            generos = [];
            var listGenero = document.getElementById("<%=lbxGenero.ClientID%>");

            var a = 0;
            for (var i = 0; i < listGenero.options.length; i++) {
                if (listGenero.options[i].selected == true) {
                    generos[a] = { pk_genero: listGenero.options[i].value };
                    a++;
                }
            }
        }

        function listNivelCuidado() {
            niveles = [];
            var listNiveles = document.getElementById("<%=lbxNivelSustancia.ClientID%>");

            var a = 0;
            for (var i = 0; i < listNiveles.options.length; i++) {
                if (listNiveles.options[i].selected == true) {
                    niveles[a] = { pk_nivel: listNiveles.options[i].value };
                    a++;
                }
            }
        }

        function listCentro() {
            centros = [];
            var listCentros = document.getElementById("<%=lbxCentro.ClientID%>");

            var a = 0;
            for (var i = 0; i < listCentros.options.length; i++) {
                if (listCentros.options[i].selected == true) {
                    centros[a] = { pk_centro: listCentros.options[i].value };
                    a++;
                }
            }
        }

        function listCentroPerfiles() {
            centrosPerfiles = [];
            var listCentros = document.getElementById("<%=lbxCentroPerfiles.ClientID%>");

            var a = 0;
            for (var i = 0; i < listCentros.options.length; i++) {
                if (listCentros.options[i].selected == true) {
                    centrosPerfiles[a] = { pk_centro: listCentros.options[i].value };
                    a++;
                }
            }
        }

        function fuenteReferido() {
            <%--var data = new google.visualization.arrayToDataTable(<%=datosTablero()%>);--%>
            var data = new google.visualization.arrayToDataTable(dtFuenteReferido);
            var options = {
                title: 'Fuente de Referidos Principales',
                bars: 'horizontal',
                legend: { position: "none" },
                axes: {
                    x: {
                        0: { side: 'top', label: 'Perfiles' } // Top x-axis.
                    }
                },
                bar: { groupWidth: "90%" }

            };
            var referido_chart = new google.charts.Bar(document.getElementById("referido_chart"));
            referido_chart.draw(data, options);
        };

        function drogasUso() {

            var data = new google.visualization.arrayToDataTable(dtDrogasUso);

            var options = {
                chartArea: { left: 0, top: 0, width: '100%', height: '100%' }
            };

            var chart = new google.visualization.PieChart(document.getElementById('drogas_chart'));

            chart.draw(data, options);
        }

        function sobredosis() {

            var data = google.visualization.arrayToDataTable(dtSobredosis);

            var options = {
                chartArea: { left: 0, top: 0, width: '100%', height: '100%' }
            };

            var chart = new google.visualization.PieChart(document.getElementById('sobredosis_chart'));

            chart.draw(data, options);
        }

        function drogaSobredosis() {

            var data = new google.visualization.arrayToDataTable(dtDrogaSobredosis);

            var options = {
                chartArea: { left: 0, top: 0, width: '100%', height: '100%' }
            };

            var chart = new google.visualization.PieChart(document.getElementById('drogaSobredosis_chart'));

            chart.draw(data, options);
        }
        
        function nivelCuidado() {
            var data = new google.visualization.arrayToDataTable(dtNivelCuidado);

            var options = {
                legend: { position: 'none' },
                axes: {
                    x: {
                        0: { side: 'top', label: 'Nivel de Cuidado' } // Top x-axis.
                    }
                },
                bar: { groupWidth: "60%" }
            };

            var chart = new google.charts.Bar(document.getElementById('nivelCuidado_div'));
            // Convert the Classic options to Material options.
            chart.draw(data, google.charts.Bar.convertOptions(options));
        };

        function perfiles() {
            var data = new google.visualization.arrayToDataTable(dtPerfiles);

            var table = new google.visualization.Table(document.getElementById('perfiles_table'));

            table.draw(data, { showRowNumber: true, width: '100%', height: '100%' });
        }

        function descargarPerfil() {
            var browserIsIE;
            var csvColumns;
            var csvContent;
            var downloadLink;
            var fileName;
            var date;

            date = new Date().toDateString();

            var data = new google.visualization.arrayToDataTable(dtPerfiles);
            // build column headings
            csvColumns = '';
            for (var i = 0; i < data.getNumberOfColumns(); i++) {
                csvColumns += data.getColumnLabel(i);
                if (i < (data.getNumberOfColumns() - 1)) {
                    csvColumns += ',';
                }
            }
            csvColumns += '\n';

            // build data rows
            csvContent = csvColumns + google.visualization.dataTableToCsv(data);

            // download file
            browserIsIE = false || !!document.documentMode;
            fileName = 'perfiles_' + date + '.csv';
            if (browserIsIE) {
                window.navigator.msSaveBlob(new Blob([csvContent], { type: 'data:text/csv' }), fileName);
            } else {
                downloadLink = document.createElement('a');
                downloadLink.href = 'data:text/csv;charset=utf-8,' + encodeURI(csvContent);
                downloadLink.download = fileName;
                raiseEvent(downloadLink, 'click');
                downloadLink = null;
            }
        }

        function raiseEvent(element, eventType) {
            var eventRaised;
            if (document.createEvent) {
                eventRaised = document.createEvent('MouseEvents');
                eventRaised.initEvent(eventType, true, false);
                element.dispatchEvent(eventRaised);
            } else if (document.createEventObject) {
                eventRaised = document.createEventObject();
                element.fireEvent('on' + eventType, eventRaised);
            }
        }


    </script>

</asp:Content>
