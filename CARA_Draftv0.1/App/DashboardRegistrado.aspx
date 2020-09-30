<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="DashboardRegistrado.aspx.cs" Inherits="CARA_Draftv0._1.App.DashboardRegistrado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-md-3">
      <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
        <h1 class="h2">Tablero Principal</h1>
        <div class="btn-toolbar mb-2 mb-md-0">
          <div class="btn-group mr-2">
            <button type="button" class="btn btn-sm btn-outline-secondary">Compartir</button>
            <button type="button" class="btn btn-sm btn-outline-secondary" onclick="javascript:window.print();">Imprimir</button>
          </div>
          <%--<button type="button" class="btn btn-sm btn-outline-secondary dropdown-toggle">
            <span data-feather="calendar"></span>
            Esta Semana
          </button>--%>
        </div>
      </div>

        <div class="container-fluid">
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
                               <h6 class="list-item">Fuente de Referido</h6>
                          </div>
                          <div class="row" id="filter_div">
                              <asp:ListBox runat="server" ID="lbxFuenteReferido" SelectionMode="Multiple" onChange="changeReferido();" CssClass="form-control"></asp:ListBox>
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

</main>



    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-multiselect/0.9.15/css/bootstrap-multiselect.css" type="text/css" />

    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-multiselect/0.9.15/js/bootstrap-multiselect.js"></script>
    
    <script type="text/javascript">
        var dtDesde, dtHasta, ajax_data, dtTotalPerfiles, dtTotalReferidosCara, dtTotalMasculino, dtPerMasculino, dtTotalFemenino, dtPerFemenino, dtEdadPromedio, dtFuenteReferido, dtNivelCuidado, dtDrogasUso, dtSobredosis, dtDrogaSobredosis;
        var generos = [], niveles = [], centros = [];

        $(function () {
            $(<%=lbxNivelSustancia.ClientID%>).multiselect({
                includeSelectAllOption: true,
                enableCaseInsensitiveFiltering: true,
                buttonClass: 'form-control',
                buttonWidth: '190px'
            });
            $(<%=lbxNivelSustancia.ClientID%>).multiselect('selectAll', false);
            $(<%=lbxNivelSustancia.ClientID%>).multiselect('updateButtonText');

            $(<%=lbxCentro.ClientID%>).multiselect({
                includeSelectAllOption: true,
                enableCaseInsensitiveFiltering: true,
                buttonClass: 'form-control',
                buttonWidth: '190px'
            });
            $(<%=lbxCentro.ClientID%>).multiselect('selectAll', false);
            $(<%=lbxCentro.ClientID%>).multiselect('updateButtonText');

            $(<%=lbxGenero.ClientID%>).multiselect({
                includeSelectAllOption: true,
                enableCaseInsensitiveFiltering: true,
                buttonClass: 'form-control',
                buttonWidth: '170px'
            });
            $(<%=lbxGenero.ClientID%>).multiselect('selectAll', false);
            $(<%=lbxGenero.ClientID%>).multiselect('updateButtonText');

            $(<%=lbxFuenteReferido.ClientID%>).multiselect({
                includeSelectAllOption: true,
                enableCaseInsensitiveFiltering: true,
                buttonClass: 'form-control',
                buttonWidth: '190px'
            });
            $(<%=lbxFuenteReferido.ClientID%>).multiselect('selectAll', false);
            $(<%=lbxFuenteReferido.ClientID%>).multiselect('updateButtonText');

        });

        google.charts.load('current', { 'packages': ['line', 'bar', 'corechart', 'controls'] });
       
        $(document).ready(function () {
            dtDesde = document.getElementById("<%=txtFechaDesde.ClientID %>").value;
            dtHasta = document.getElementById("<%=txtFechaHasta.ClientID %>").value;

            listGenero();

            listNivelCuidado();

            listCentro();

            ajax_data = '{Desde:"' + dtDesde + '", Hasta:"' + dtHasta + '", gen:' + JSON.stringify(generos) + ', Niveles:' + JSON.stringify(niveles) + ', Centros:' + JSON.stringify(centros) + '}'

            wsTotalPerfiles();

            wsFuenteReferido();

            wsNivelCuidado();

            wsSobredosis();

            wsDrogaSobredosis();

            wsDrogaUso();

        });


        //google.charts.setOnLoadCallback(drawDashboard);

        //function drawDashboard() {

           
        //    var data = google.visualization.arrayToDataTable([
        //        ['Name', 'Donuts eaten'],
        //        ['Michael', 5],
        //        ['Elisa', 7],
        //        ['Robert', 3],
        //        ['John', 2],
        //        ['Jessica', 6],
        //        ['Aaron', 1],
        //        ['Margareth', 8]
        //    ]);

        //    var dashboard = new google.visualization.Dashboard(
        //        document.getElementById('dashboard_div'));

         
        //    var donutRangeSlider = new google.visualization.ControlWrapper({
        //        'controlType': 'NumberRangeFilter',
        //        'containerId': 'filter_div',
        //        'options': {
        //            'filterColumnLabel': 'Donuts eaten'
        //        }
        //    });

        //    var pieChart = new google.visualization.ChartWrapper({
        //        'chartType': 'PieChart',
        //        'containerId': 'chart_div',
        //        'options': {
                    
        //            'pieSliceText': 'value',
        //            'legend': 'right'
        //        }
        //    });

     
        //    dashboard.bind(donutRangeSlider, pieChart);

        //    dashboard.draw(data);
        //}

        

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

        function changeReferido() {
           
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

            var data = google.visualization.arrayToDataTable(dtDrogasUso);

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

            var data = google.visualization.arrayToDataTable(dtDrogaSobredosis);

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


    </script>

</asp:Content>
