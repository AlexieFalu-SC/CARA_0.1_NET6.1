<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucanaliticaPlanificacion.ascx.cs" Inherits="CARA_Draftv0._1.App.wucanaliticaPlanificacion" %>

<div class="row">
    <div class="col-md-3 col-lg-2 px-md-0">
        <ul class="list-group">
            <li class="list-group-item">
                <div class="row">
                    <h6 class="list-item">Fecha de Admisión</h6>
                </div>
                <div class="row">
                    <span class="list-item">Desde</span>
                    <asp:textbox runat="server" ID="txtFechaDesde" CssClass="form-control" TextMode="Date" onChange="changeFilter();"/>
                    <span class="list-item">Hasta</span>
                    <asp:textbox runat="server" ID="txtFechaHasta" CssClass="form-control" TextMode="Date" onChange="changeFilter();"/>
                </div>
                          
            </li>
            <li class="list-group-item">
                <div class="row">
                    <h6 class="list-item">Centro de Servicio</h6>
                </div>
                <div class="row">
                    <asp:ListBox runat="server" ID="lbxCentro" SelectionMode="Multiple" onChange="changeFilter();" CssClass="form-control">
                </asp:ListBox>
                </div>
            </li>
            <li class="list-group-item">
                <div class="row">
                    <h6 class="list-item">Género</h6>
                </div>
                <div class="row">
                    <asp:ListBox runat="server" ID="lbxGenero" SelectionMode="Multiple" CssClass="form-control" onChange="changeFilter();"></asp:ListBox>
                </div>
            </li>
            <li class="list-group-item">
                <div class="row">
                    <h6 class="list-item">Grupo de Edades</h6>
                </div>
                <div class="row">
                    <asp:ListBox runat="server" ID="lbxGrupoEdades" SelectionMode="Multiple" CssClass="form-control" onChange="changeFilter();"></asp:ListBox>
                </div>
            </li>
            <li class="list-group-item">
                <div class="row">
                    <h6 class="list-item">Nivel de Cuidado</h6>
                </div>
                <div class="row">
                    <asp:ListBox ID="lbxNivelSustancia" runat="server" SelectionMode="Multiple" onChange="changeFilter();" CssClass="form-control"></asp:ListBox>
                </div>
            </li>
            <li class="list-group-item">
                <div class="row">
                    <h6 class="list-item">Evento de Sobredosis</h6>
                </div>
                <div class="row">
                    <asp:ListBox runat="server" ID="lbxSobredosis" SelectionMode="Multiple" CssClass="form-control" onChange="changeFilter();"></asp:ListBox>
                </div>
            </li>
            <li class="list-group-item">
                <div class="row">
                    <h6 class="list-item">Fuente de Referido</h6>
                </div>
                <div class="row">
                    <asp:ListBox runat="server" ID="lbxFuenteReferido" SelectionMode="Multiple" CssClass="form-control" onChange="changeFilter();"></asp:ListBox>
                </div>
            </li>
            <li class="list-group-item">
                <div class="row">
                    <h6 class="list-item">Municipio</h6>
                </div>
                <div class="row">
                    <asp:ListBox runat="server" ID="lbxMunicipios" SelectionMode="Multiple" CssClass="form-control" onChange="changeFilter();"></asp:ListBox>
                </div>
            </li>
        </ul>
    </div>

    <div class="col-md-9 ml-sm-auto col-lg-10 px-md-3">
        <div class="row">
            
            <div class="col-xl-2 col-md-6 mb-4">
                <div class="card border-left-info shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-info text-uppercase mb-1" style="text-align:center">Total de Perfiles</div>
                                <div class="h5 mb-0 font-weight-bold text-gray-800" style="text-align:center" id="totalAdmisiones"></div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

            <div class="col-xl-4 col-md-6 mb-4">
                <div class="card border-left-info shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col">
                                <div class="text-xs font-weight-bold text-info text-uppercase mb-1" style="text-align:center">Género</div>
                                <div class="row">
                                    <div class="col-md-7">
                                        <div class="row no-gutters align-items-center">
                                            <div class="col-auto">
                                                <div class="h7 mb-0 mr-3 font-weight-bold text-gray-800">Masculino</div>
                                            </div>
                                            <div class="col">
                                                <div class="progress progress-sm mr-2">
                                                <div class="progress-bar bg-info" role="progressbar" id="plnperMasculino" aria-valuemin="0" aria-valuemax="100"></div>
                                                </div>
                                            </div>
                                                <div class="col">
                                                    <div class="font-weight-bold" id="plntotalMasculino"></div>
                                                </div>
                                            </div>
                                            <div class="row no-gutters align-items-center">
                                            <div class="col-auto">
                                                <div class="h7 mb-0 mr-3 font-weight-bold text-gray-800">Femenino</div>
                                            </div>
                                            <div class="col">
                                                <div class="progress progress-sm mr-2">
                                                <div class="progress-bar bg-info" role="progressbar" id="plnperFemenino" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                                                </div>
                                            </div>
                                                <div class="col">
                                                    <div class="font-weight-bold" id="plntotalFemenino"></div>
                                                </div>
                                            </div>
                                    </div>
                                    <div class="col-md-5">
                                        <div class="row no-gutters align-items-center">
                                        <div class="col-auto">
                                            <div class="h7 mb-0 mr-1 font-weight-bold text-gray-800">F -> M</div>
                                        </div>
                                        <div class="col">
                                            <div class="progress progress-sm mr-1">
                                            <div class="progress-bar bg-info" role="progressbar" id="plnperFM" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                                            </div>
                                        </div>
                                            <div class="col">
                                                <div class="font-weight-bold" id="plntotalFM">0</div>
                                            </div>
                                        </div>
                                        <div class="row no-gutters align-items-center">
                                        <div class="col-auto">
                                            <div class="h7 mb-0 mr-1 font-weight-bold text-gray-800">M -> F</div>
                                        </div>
                                        <div class="col">
                                            <div class="progress progress-sm mr-1">
                                            <div class="progress-bar bg-info" role="progressbar" id="plnperMF" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                                            </div>
                                        </div>
                                            <div class="col">
                                                <div class="font-weight-bold" id="plntotalMF">0</div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            </div>

                    </div>
                </div>
            </div>

            <div class="col-xl-4 col-md-6 mb-4">
                <div class="card border-left-info shadow h-100 py-2">
                <div class="card-body">
                     <div class="row no-gutters align-items-center">
                            <div class="col">
                                <div class="text-xs font-weight-bold text-info text-uppercase mb-1" style="text-align:center">Grupo de Edades</div>
                                <div class="row">
                                    <div class="col-md-7">
                                        <div class="row no-gutters align-items-center">
                                            <div class="col-auto">
                                                <div class="h7 mb-0 mr-3 font-weight-bold text-gray-800">18-24</div>
                                            </div>
                                            <div class="col">
                                                <div class="progress progress-sm mr-2">
                                                <div class="progress-bar bg-info" role="progressbar" id="plnper18_24" aria-valuemin="0" aria-valuemax="100"></div>
                                                </div>
                                            </div>
                                                <div class="col">
                                                    <div class="font-weight-bold" id="plntotal18_24"></div>
                                                </div>
                                            </div>
                                            <div class="row no-gutters align-items-center">
                                            <div class="col-auto">
                                                <div class="h7 mb-0 mr-3 font-weight-bold text-gray-800">25-44</div>
                                            </div>
                                            <div class="col">
                                                <div class="progress progress-sm mr-2">
                                                <div class="progress-bar bg-info" role="progressbar" id="plnper25_44" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                                                </div>
                                            </div>
                                                <div class="col">
                                                    <div class="font-weight-bold" id="plntotal25_44"></div>
                                                </div>
                                            </div>
                                    </div>
                                    <div class="col-md-5">
                                        <div class="row no-gutters align-items-center">
                                        <div class="col-auto">
                                            <div class="h7 mb-0 mr-1 font-weight-bold text-gray-800">45-65</div>
                                        </div>
                                        <div class="col">
                                            <div class="progress progress-sm mr-1">
                                            <div class="progress-bar bg-info" role="progressbar" id="plnper45_65" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                                            </div>
                                        </div>
                                            <div class="col">
                                                <div class="font-weight-bold" id="plntotal45_65">0</div>
                                            </div>
                                        </div>
                                        <div class="row no-gutters align-items-center">
                                        <div class="col-auto">
                                            <div class="h7 mb-0 mr-1 font-weight-bold text-gray-800">65+</div>
                                        </div>
                                        <div class="col">
                                            <div class="progress progress-sm mr-1">
                                            <div class="progress-bar bg-info" role="progressbar" id="plnper65" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                                            </div>
                                        </div>
                                            <div class="col">
                                                <div class="font-weight-bold" id="plntotal65">0</div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            </div>
                </div>
                </div>
            </div>

            <div class="col-xl-2 col-md-6 mb-4">
                <div class="card border-left-info shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                    <div class="col mr-2">
                        <div class="text-xs font-weight-bold text-info text-uppercase mb-1" style="text-align:center">Vía de Uso (más utilizada)</div>
                        <div class="h7 mb-0 font-weight-bold text-gray-800" style="text-align:center" id="viaUso"></div>
                    </div>
                    <div class="col-auto">
                        <i class="fas fa-calendar fa-2x text-gray-300"></i>
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
                    <h6 class="m-0 font-weight-bold text-primary">Tendencia de Eventos de Sobredosis y Admisiones</h6>
                </div>
                <!-- Card Body -->
                <div class="card-body">
                    <div class="chart-area">
                        <div id="icdx_chart" style="height: 250px"></div>
                    </div>
                </div>
                </div>
            </div>

            <!-- Chart: Fuente de Referidos Principales -->
            <div class="col-lg-6 mb-2">
                <div class="card shadow mb-4">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-primary">Porciento de atendidos (Admitidos+Traslados) con evento de sobredosis por municipio de residencia</h6>
                </div>
                <!-- Card Body -->
                <div class="card-body">
                    <div class="chart-area">
                        <div id="dsmv_chart" style="height: 250px"></div>
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
                    <h6 class="m-0 font-weight-bold text-primary">DROGAS DE USO (No Incluye Sobredosis)</h6>
                </div>
                <!-- Card Body -->
                <div class="card-body">
                    <div class="chart-area">
                        <div id="drogasuso_chart" style="height: 250px"></div>
                    </div>
                </div>
                </div>
            </div>

            <!-- Chart: Perfiles por Centro -->
            <div class="col-lg-6 mb-2">
                <div class="card shadow mb-4">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-primary">DROGAS DE SOBREDOSIS (No Incluye Drogas de Uso)</h6>
                </div>
                <!-- Card Body -->
                <div class="card-body">
                    <div class="chart-area">
                        <div id="condicionesfisicas_chart" style="height: 250px"></div>
                    </div>
                </div>
                </div>
            </div>

            </div>

        </div>

</div>


<script type="text/javascript">
    var plnDesde, plnHasta, plnAjax_data, plnTotalVia, plnTotalToxicologia, plnTotalCentros, plnTotalAdmisiones, plnDrogasUso, plnICDX, plnDSMV, plnCondicionesFisicas;
    var plnTotalMasculino, plnPerMasculino, plnTotalFemenino, plnPerFemenino, plnTotalFM, plnPerFM, plnTotalMF, plnPerFM;
    var plnTotal18_24, plnPer18_24, plnTotal25_44, plnPer25_44, plnTotal45_65, plnPer45_65, plnTotal65, plnPer65;
    var plnGeneros = [], plnNiveles = [], plnCentros = [], plnFuenteReferido = [], plnGrupoEdades = [], plnSobredosis = [], plnMunicipios = [];


    

    $(document).ready(function () {
        

        setTimeout(function () {
            plnDesde = document.getElementById("<%=txtFechaDesde.ClientID %>").value;
            plnHasta = document.getElementById("<%=txtFechaHasta.ClientID %>").value;

            plnlistGenero();

            plnlistNivelCuidado();

            plnlistCentro();

            plnlistFuenteReferido();

            plnlistGrupoEdades();

            plnlistSobredosis();

            plnlistMunicipios();

            plnAjax_data = '{Desde:"' + plnDesde + '", Hasta:"' + plnHasta + '", gen:' + JSON.stringify(plnGeneros) + ', Niveles:' + JSON.stringify(plnNiveles) + ', Centros:' + JSON.stringify(plnCentros) + ', Fuente:' + JSON.stringify(plnFuenteReferido) + ', Grupo:' + JSON.stringify(plnGrupoEdades) + ', Sobredosis:' + JSON.stringify(plnSobredosis) + ', Municipios:' + JSON.stringify(plnMunicipios) + '}'

            wsplnTotales();

            wsplnDrogasUso();

            wsplnICDX();

            wsplnDSMV();

            wsplnCondicionesFisicas();
           
        }, 1500);
        
    });

    function changeFilter() {
        plnDesde = document.getElementById("<%=txtFechaDesde.ClientID %>").value;
        plnHasta = document.getElementById("<%=txtFechaHasta.ClientID %>").value;

        plnlistGenero();

        plnlistNivelCuidado();

        plnlistCentro();

        plnlistFuenteReferido();

        plnlistGrupoEdades();

        plnlistSobredosis();

        plnlistMunicipios();

        plnAjax_data = '{Desde:"' + plnDesde + '", Hasta:"' + plnHasta + '", gen:' + JSON.stringify(plnGeneros) + ', Niveles:' + JSON.stringify(plnNiveles) + ', Centros:' + JSON.stringify(plnCentros) + ', Fuente:' + JSON.stringify(plnFuenteReferido) + ', Grupo:' + JSON.stringify(plnGrupoEdades) + ', Sobredosis:' + JSON.stringify(plnSobredosis) + ', Municipios:' + JSON.stringify(plnMunicipios) + '}'

        wsplnTotales();

        wsplnDrogasUso();

        wsplnICDX();

        wsplnDSMV();

        wsplnCondicionesFisicas();
    }

    function wsplnTotales() {

        $.ajax({
            url: "WebMethods/wsPlanificacionTablero.asmx/dashTotales",
            data: plnAjax_data,
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var mydata = data.d;
                //plnTotalToxicologia = mydata.totalToxicologia;
                plnTotalCentros = mydata.totalCentros;
                plnTotalAdmisiones = mydata.totalAdmisiones;
                plnTotalVia = mydata.viaUso;

             
                plnTotalMasculino = mydata.totalMasculino;
                plnTotalFemenino = mydata.totalFemenino;
                plnPerMasculino = mydata.perMasculino;
                plnPerFemenino = mydata.perFemenino;
                plnTotalMF = mydata.totalMF;
                plnTotalFM = mydata.totalFM;
                plnPerMF = mydata.perMF;
                plnPerFM = mydata.perFM;

                plnTotal18_24 = mydata.total18_24;
                plnTotal25_44 = mydata.total25_44;
                plnPer18_24 = mydata.per18_24;
                plnPer25_44 = mydata.per25_44;
                plnTotal45_65 = mydata.total45_65;
                plnTotal65 = mydata.total65;
                plnPer45_65 = mydata.per45_65;
                plnPer65 = mydata.per65;

                
            },
            error: function () {
                alert("Error");
            }
        }).done(function () {
           // $("#totalToxicologia").html(plnTotalToxicologia);
            $("#totalCentros").html(plnTotalCentros);
            $("#totalAdmisiones").html(plnTotalAdmisiones);
            $("#viaUso").html(plnTotalVia);

            $("#plntotalMasculino").html(plnTotalMasculino);
            $("#plntotalFemenino").html(plnTotalFemenino);
            $("#plntotalFM").html(plnTotalFM);
            $("#plntotalMF").html(plnTotalMF);


            document.getElementById('plnperMasculino').setAttribute("style", "width:" + plnPerMasculino + "%");
            document.getElementById('plnperFemenino').setAttribute("style", "width:" + plnPerFemenino + "%");
            document.getElementById('plnperFM').setAttribute("style", "width:" + plnPerFM + "%");
            document.getElementById('plnperMF').setAttribute("style", "width:" + plnPerMF + "%");

            $("#plntotal18_24").html(plnTotal18_24);
            $("#plntotal25_44").html(plnTotal25_44);
            $("#plntotal45_65").html(plnTotal45_65);
            $("#plntotal65").html(plnTotal65);


            document.getElementById('plnper18_24').setAttribute("style", "width:" + plnPer18_24 + "%");
            document.getElementById('plnper25_44').setAttribute("style", "width:" + plnPer25_44 + "%");
            document.getElementById('plnper45_65').setAttribute("style", "width:" + plnPer45_65 + "%");
            document.getElementById('plnper65').setAttribute("style", "width:" + plnPer65 + "%");
        });


    }

    function wsplnDrogasUso() {
        $.ajax({
            url: "WebMethods/wsPlanificacionTablero.asmx/dashDrogasUso",
            data: plnAjax_data,
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                plnDrogasUso = data.d;
            },
            error: function () {
                alert("Error");
            }
        }).done(function () {
            google.charts.setOnLoadCallback(plnChartDrogasUso);
        });
    }

    function wsplnICDX() {
        $.ajax({
            url: "WebMethods/wsPlanificacionTablero.asmx/dashCaraSobredosis",
            data: plnAjax_data,
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                plnICDX = data.d;
            },
            error: function () {
                alert("b");
                alert("Error");
            }
        }).done(function () {
            google.charts.setOnLoadCallback(plnChartICDX);
        });
    }

    function wsplnDSMV() {
        $.ajax({
            url: "WebMethods/wsPlanificacionTablero.asmx/dashMunicipio",
            data: plnAjax_data,
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                plnDSMV = data.d;
            },
            error: function () {
                alert("Error");
            }
        }).done(function () {
            google.charts.setOnLoadCallback(plnChartDSMV);
        });
    }

    function wsplnCondicionesFisicas() {
        $.ajax({
            url: "WebMethods/wsPlanificacionTablero.asmx/dashCaraDrogaSobredosis",
            data: plnAjax_data,
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                plnCondicionesFisicas = data.d;
            },
            error: function () {
                alert("a");
                alert("Error");
            }
        }).done(function () {
            google.charts.setOnLoadCallback(plnChartCondicionesFisicas);
        });
    }

    function plnChartDrogasUso() {

        var data = new google.visualization.arrayToDataTable(plnDrogasUso);
        var options = {
            title: 'Drogas de Uso',
            bars: 'horizontal',
            legend: { position: "none" },
            chartArea: { left: 0, top: 0, width: '100%', height: '100%' },
            axes: {
                x: {
                    0: { side: 'top', label: '% Porcentaje' } // Top x-axis.
                }
            },
            bar: { groupWidth: "90%" },
            sort: 'enable'

        };
        var drogas_chart = new google.charts.Bar(document.getElementById('drogasuso_chart'));
        drogas_chart.draw(data, options);
    };

    function plnChartICDX() {

        var data = new google.visualization.arrayToDataTable(plnICDX);
        var options = {
            title: 'Cantidad de Perfiles',
            //bars: 'horizontal',
            //legend: { position: "none" },
            //chartArea: { left: 0, top: 0, width: '100%', height: '100%' },
            //axes: {
            //    x: {
            //        0: { side: 'top', label: 'Cantidad' } // Top x-axis.
            //    }
            //},
            //bar: { groupWidth: "90%" },
            //sort: 'enable'
            curveType: 'function',
            legend: { position: 'bottom'}

        };
        var icdx_chart = new google.visualization.LineChart(document.getElementById('icdx_chart'));
        icdx_chart.draw(data, options);
    };

    function plnChartDSMV() {

        var data = new google.visualization.arrayToDataTable(plnDSMV);
        var options = {
            title: 'Municipios',
            bars: 'horizontal',
            legend: { position: "none" },
            chartArea: { left: 0, top: 0, width: '100%', height: '100%' },
            axes: {
                x: {
                    0: { side: 'top', label: '% porcentaje' } // Top x-axis.
                }
            },
            bar: { groupWidth: "90%" },
            sort: 'enable'

        };
        var dsmv_chart = new google.charts.Bar(document.getElementById('dsmv_chart'));
        dsmv_chart.draw(data, options);
    };

    function plnChartCondicionesFisicas() {

        var data = new google.visualization.arrayToDataTable(plnCondicionesFisicas);
        var options = {
            title: 'Drogas de Sobredosis',
            bars: 'horizontal',
            legend: { position: "none" },
            chartArea: { left: 0, top: 0, width: '100%', height: '100%' },
            axes: {
                x: {
                    0: { side: 'top', label: '% Porcentaje' } // Top x-axis.
                }
            },
            bar: { groupWidth: "90%" },
            sort: 'enable'

        };
        var condicionesfisicas_chart = new google.charts.Bar(document.getElementById('condicionesfisicas_chart'));
        condicionesfisicas_chart.draw(data, options);
    };

    function plnlistGenero() {
        plnGeneros = [];
        var plnlistGenero = document.getElementById("<%=lbxGenero.ClientID%>");

        var a = 0;
        for (var i = 0; i < plnlistGenero.options.length; i++) {
            if (plnlistGenero.options[i].selected == true) {
                plnGeneros[a] = { pk_genero: plnlistGenero.options[i].value };
                a++;
            }
        }
    }

    function plnlistNivelCuidado() {
        plnNiveles = [];
        var plnlistNiveles = document.getElementById("<%=lbxNivelSustancia.ClientID%>");

        var a = 0;
        for (var i = 0; i < plnlistNiveles.options.length; i++) {
            if (plnlistNiveles.options[i].selected == true) {
                plnNiveles[a] = { pk_nivel: plnlistNiveles.options[i].value };
                a++;
            }
        }
    }

    function plnlistCentro() {
        plnCentros = [];
        var plnlistCentros = document.getElementById("<%=lbxCentro.ClientID%>");

        var a = 0;
        for (var i = 0; i < plnlistCentros.options.length; i++) {
            if (plnlistCentros.options[i].selected == true) {
                plnCentros[a] = { pk_centro: plnlistCentros.options[i].value };
                a++;
            }
        }
    }

    function plnlistFuenteReferido() {
        plnFuenteReferido = [];
        var plnlistFuenteReferido = document.getElementById("<%=lbxFuenteReferido.ClientID%>");
   
        var a = 0;
        for (var i = 0; i < plnlistFuenteReferido.options.length; i++) {
            if (plnlistFuenteReferido.options[i].selected == true) {
                plnFuenteReferido[a] = { pk_fuentereferido: plnlistFuenteReferido.options[i].value };
                a++;
            }
        }
    }

    function plnlistGrupoEdades() {
        plnGrupoEdades = [];
        var plnlistGrupoEdades = document.getElementById("<%=lbxGrupoEdades.ClientID%>");

        var a = 0;
        for (var i = 0; i < plnlistGrupoEdades.options.length; i++) {
            if (plnlistGrupoEdades.options[i].selected == true) {
                plnGrupoEdades[a] = { pk_grupoedades: plnlistGrupoEdades.options[i].value };
                a++;
            }
        }
    }

    function plnlistSobredosis() {
        plnSobredosis = [];
        var plnlistSobredosis = document.getElementById("<%=lbxSobredosis.ClientID%>");

        var a = 0;
        for (var i = 0; i < plnlistSobredosis.options.length; i++) {
            if (plnlistSobredosis.options[i].selected == true) {
                plnSobredosis[a] = { pk_sobredosis: plnlistSobredosis.options[i].value };
                a++;
            }
        }
    }

    function plnlistMunicipios() {
        plnMunicipios = [];
        var plnlistMunicipios = document.getElementById("<%=lbxMunicipios.ClientID%>");

        var a = 0;
        for (var i = 0; i < plnlistMunicipios.options.length; i++) {
            if (plnlistMunicipios.options[i].selected == true) {
                plnMunicipios[a] = { pk_municipios: plnlistMunicipios.options[i].value };
                a++;
            }
        }
    }
</script>


