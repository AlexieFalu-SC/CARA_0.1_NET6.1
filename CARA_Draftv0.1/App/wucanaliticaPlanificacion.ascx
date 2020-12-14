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
                    <h6 class="list-item">Nivel de Cuidado</h6>
                </div>
                <div class="row">
                    <asp:ListBox ID="lbxNivelSustancia" runat="server" SelectionMode="Multiple" onChange="changeFilter();" CssClass="form-control"></asp:ListBox>
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
                        <div class="text-xs font-weight-bold text-info text-uppercase mb-1" style="text-align:center">Vía de Uso (más utilizada)</div>
                        <div class="h5 mb-0 font-weight-bold text-gray-800" style="text-align:center" id="viaUsada"></div>
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
                                <div class="text-xs font-weight-bold text-info text-uppercase mb-1" style="text-align:center">Toxicología</div>
                                <div class="h5 mb-0 font-weight-bold text-gray-800" style="text-align:center" id="totalToxicologia"></div>
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
                            <div class="text-xs font-weight-bold text-info text-uppercase mb-1" style="text-align:center">Total de Centros</div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800" style="text-align:center" id="totalCentros"></div>
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
                                <div class="text-xs font-weight-bold text-info text-uppercase mb-1" style="text-align:center">Total de Admisiones</div>
                                <div class="h5 mb-0 font-weight-bold text-gray-800" style="text-align:center" id="totalAdmisiones"></div>
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
                    <h6 class="m-0 font-weight-bold text-primary">DIAGNOSTICOS ICD 10 (Top 10)</h6>
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
                    <h6 class="m-0 font-weight-bold text-primary">DIAGNOSTICOS DSMV (Top 10)</h6>
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
                    <h6 class="m-0 font-weight-bold text-primary">CONDICIONES SALUD FÍSICAS</h6>
                </div>
                <!-- Card Body -->
                <div class="card-body">
                    <div class="chart-area">
                        <div id="saludfisicas_chart" style="height: 250px"></div>
                    </div>
                </div>
                </div>
            </div>

            <!-- Chart: Perfiles por Centro -->
            <div class="col-lg-6 mb-2">
                <div class="card shadow mb-4">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-primary">DROGAS DE USO (Confirmadas Toxicología)</h6>
                </div>
                <!-- Card Body -->
                <div class="card-body">
                    <div class="chart-area">
                        <div id="drogasuso_chart" style="height: 250px"></div>
                    </div>
                </div>
                </div>
            </div>

            </div>

        </div>

</div>


<script type="text/javascript">
    var plnDesde, plnHasta, plnAjax_data, plnTotalVia, plnTotalToxicologia, plnTotalCentros, plnTotalAdmisiones, plnDrogasUso;
    var plnGeneros = [], plnNiveles = [], plnCentros = [];

   

    $(document).ready(function () {
        plnDesde = document.getElementById("<%=txtFechaDesde.ClientID %>").value;
        plnHasta = document.getElementById("<%=txtFechaHasta.ClientID %>").value;

        plnlistGenero();

        plnlistNivelCuidado();

        plnlistCentro();

        plnAjax_data = '{Desde:"' + plnDesde + '", Hasta:"' + plnHasta + '", gen:' + JSON.stringify(plnGeneros) + ', Niveles:' + JSON.stringify(plnNiveles) + ', Centros:' + JSON.stringify(plnCentros) + '}'

        wsplnTotales();

        wsplnDrogasUso();
    });

    function changeFilter() {
        plnDesde = document.getElementById("<%=txtFechaDesde.ClientID %>").value;
        plnHasta = document.getElementById("<%=txtFechaHasta.ClientID %>").value;

        plnlistGenero();

        plnlistNivelCuidado();

        plnlistCentro();

        plnAjax_data = '{Desde:"' + plnDesde + '", Hasta:"' + plnHasta + '", gen:' + JSON.stringify(plnGeneros) + ', Niveles:' + JSON.stringify(plnNiveles) + ', Centros:' + JSON.stringify(plnCentros) + '}'

        wsplnTotales();

        wsplnDrogasUso();
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
                plnTotalToxicologia = mydata.totalToxicologia;
                plnTotalCentros = mydata.totalCentros;
                plnTotalAdmisiones = mydata.totalAdmisiones;
            },
            error: function () {
                alert("Error");
            }
        }).done(function () {
            $("#totalToxicologia").html(plnTotalToxicologia);
            $("#totalCentros").html(plnTotalCentros);
            $("#totalAdmisiones").html(plnTotalAdmisiones);
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

    function plnChartDrogasUso() {

        var data = new google.visualization.arrayToDataTable(plnDrogasUso);
        var options = {
            title: 'Drogas de Uso',
            bars: 'horizontal',
            legend: { position: "none" },
            chartArea: { left: 0, top: 0, width: '100%', height: '100%' },
            axes: {
                x: {
                    0: { side: 'top', label: 'Cantidad' } // Top x-axis.
                }
            },
            bar: { groupWidth: "90%" },
            sort: 'enable'

        };
        var drogas_chart = new google.charts.Bar(document.getElementById('drogasuso_chart'));
        drogas_chart.draw(data, options);
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
</script>


